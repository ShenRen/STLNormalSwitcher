// Part of STLNormalSwitcher: A program to switch normal vectors in STL-files
//
// Copyright (C) 2007  PG500, ISF, University of Dortmund
//      PG500 are: Christoph Begau, Christoph Heuel, Raffael Joliet, Jan Kolanski,
//                 Mandy Kröller, Christian Moritz, Daniel Niggemann, Mathias Stöber,
//                 Timo Stönner, Jan Varwig, Dafan Zhai
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License along
// with this program. If not, see <http://www.gnu.org/licenses/>.
//
// For more information and contact details look at STLNormalSwitchers website:
//      http://normalswitcher.sourceforge.net/

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using Tao.OpenGl;
using Tao.Platform.Windows;

namespace STLNormalSwitcher {
    /// <summary>
    /// The Control visualizing the STL-data.
    /// </summary>
    internal class NormalSwitcherControl : Control {

        #region Fields

        private NormalSwitcherForm owner;

        private float[] colorArray;
        private float[] pickingColors;
        private float zoom;
        private float xRot, yRot, xDiff, yDiff;
        private float scale;
        private bool picking;
        private bool fresh = true;
        private bool[] vertices = new bool[3] { false, false, false };
        private bool corners = false;
        private int colorDist;

        private float[] uColor = new float[3] { Color.Aqua.R / 255, Color.Aqua.G / 255, Color.Aqua.B / 255 };
        private float[] sColor = new float[3] { Color.Red.R / 255, Color.Red.G / 255, Color.Red.B / 255 };
        private float[] aColor = new float[3] { Color.Yellow.R / 255, Color.Yellow.G / 255, Color.Yellow.B / 255 };
        private float[] bColor = new float[3] { 0, 0.5f, 0 };
        private float[] cColor = new float[3] { 0, 0, 1.0f };

        private IntPtr deviceContext = IntPtr.Zero;
        private IntPtr renderContext = IntPtr.Zero;

        #endregion

        #region Properties

        /// <value>Sets the value of fresh and refreshes the visualization, if the value is true</value>
        internal bool Fresh {
            set {
                fresh = value;
                if (fresh) { this.Refresh(); }
            }
        }

        /// <value>Sets the value of vertices</value>
        internal bool[] Vertices {
            get { return vertices; }
            set { vertices = value; }
        }

        /// <value>Sets the value of corners</value>
        internal bool Corners { set { corners = value; } }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes the NormalSwitcherControl.
        /// </summary>
        /// <param name="owner">The NormalSwitcherForm owning this Control</param>
        internal NormalSwitcherControl(NormalSwitcherForm owner) {
            this.InitStyles();
            this.InitContexts();
            this.InitOpenGL();

            this.owner = owner;
            this.scale = owner.TriangleList.Scale;

            this.picking = false;
            this.SetPickingColors();

            this.MouseWheel += this.MouseWheelEvent;
            this.MouseDown += this.MouseDownEvent;
            this.MouseMove += this.MouseMoveEvent;
        }

        #endregion

        #region Methods

        #region OpenGL

        /// <summary>
        /// Initialize the properties of OpenGL.
        /// </summary>
        private void InitOpenGL() {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.glShadeModel(Gl.GL_FLAT);

            Gl.glEnable(Gl.GL_LINE_SMOOTH);
            Gl.glEnable(Gl.GL_BLEND);
            Gl.glEnable(Gl.GL_NORMALIZE);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
            Gl.glEnableClientState(Gl.GL_VERTEX_ARRAY);
            Gl.glEnableClientState(Gl.GL_NORMAL_ARRAY);
            Gl.glEnableClientState(Gl.GL_COLOR_ARRAY);

            //Light settings
            float[] ambientLight = { 0.4f, 0.4f, 0.4f, 1.0f };
            float[] diffuseLight = { 0.8f, 0.8f, 0.8f, 1.0f };
            float[] matSpecular = { 0.6f, 0.6f, 0.6f, 1f };
            float[] matShininess = { 40.0f };
            float[] lightPosition = { 20.0f, 0.0f, 400.0f, 1.0f };
            float[] lmodelAmbient = { 0.2f, 0.2f, 0.2f, 1.0f };
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, matSpecular);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SHININESS, matShininess);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_AMBIENT, ambientLight);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, diffuseLight);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, lightPosition);
            Gl.glLightModelfv(Gl.GL_LIGHT_MODEL_AMBIENT, lmodelAmbient);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
        }

        /// <summary>
        /// Initializes the styles.
        /// </summary>
        private void InitStyles() {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, false);
            this.SetStyle(ControlStyles.Opaque, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        /// <summary>
        /// Creates and sets the pixel format and creates and connects the deviceContext and renderContext.
        /// </summary>
        internal void InitContexts() {
            int selectedPixelFormat;

            //Make sure the handle for this control has been created
            if (this.Handle == IntPtr.Zero) {
                throw new Exception("InitContexts: The control's window handle has not been created!");
            }

            //Setup pixel format
            Gdi.PIXELFORMATDESCRIPTOR pixelFormat = new Gdi.PIXELFORMATDESCRIPTOR();
            pixelFormat.nSize = (short)Marshal.SizeOf(pixelFormat);
            pixelFormat.nVersion = 1;
            pixelFormat.dwFlags = Gdi.PFD_DRAW_TO_WINDOW | Gdi.PFD_SUPPORT_OPENGL |
                Gdi.PFD_DOUBLEBUFFER;
            pixelFormat.iPixelType = (byte)Gdi.PFD_TYPE_RGBA;
            pixelFormat.cColorBits = 32;
            pixelFormat.cRedBits = 0;
            pixelFormat.cRedShift = 0;
            pixelFormat.cGreenBits = 0;
            pixelFormat.cGreenShift = 0;
            pixelFormat.cBlueBits = 0;
            pixelFormat.cBlueShift = 0;
            pixelFormat.cAlphaBits = 0;
            pixelFormat.cAlphaShift = 0;
            pixelFormat.cAccumBits = 0;
            pixelFormat.cAccumRedBits = 0;
            pixelFormat.cAccumGreenBits = 0;
            pixelFormat.cAccumBlueBits = 0;
            pixelFormat.cAccumAlphaBits = 0;
            pixelFormat.cDepthBits = 16;
            pixelFormat.cStencilBits = 0;
            pixelFormat.cAuxBuffers = 0;
            pixelFormat.iLayerType = (byte)Gdi.PFD_MAIN_PLANE;
            pixelFormat.bReserved = 0;
            pixelFormat.dwLayerMask = 0;
            pixelFormat.dwVisibleMask = 0;
            pixelFormat.dwDamageMask = 0;

            //Create device context
            this.deviceContext = User.GetDC(this.Handle);
            if (this.deviceContext == IntPtr.Zero) {
                MessageBox.Show("InitContexts: Unable to create an OpenGL device context!", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }

            //Choose the Pixel Format that is the closest to our pixelFormat
            selectedPixelFormat = Gdi.ChoosePixelFormat(this.deviceContext, ref pixelFormat);

            //Make sure the requested pixel format is available
            if (selectedPixelFormat == 0) {
                MessageBox.Show("InitContexts: Unable to find a suitable pixel format!", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }

            //Sets the selected Pixel Format
            if (!Gdi.SetPixelFormat(this.deviceContext, selectedPixelFormat, ref pixelFormat)) {
                MessageBox.Show("InitContexts: Unable to set the requested pixel format!", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }

            //Create rendering context
            this.renderContext = Wgl.wglCreateContext(this.deviceContext);
            if (this.renderContext == IntPtr.Zero) {
                MessageBox.Show("InitContexts: Unable to create an OpenGL rendering context!", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }

            this.MakeCurrentContext();
        }

        /// <summary>
        /// Connects the deviceContext with the renderContext.
        /// </summary>
        internal void MakeCurrentContext() {
            if (!Wgl.wglMakeCurrent(this.deviceContext, this.renderContext)) {
                MessageBox.Show("MakeCurrentContext: Unable to activate this control's OpenGL rendering context!", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }
        }

        /// <summary>
        /// Deletes the deviceContext and renderContext.
        /// </summary>
        internal void DestroyContexts() {
            if (this.renderContext != IntPtr.Zero) {
                Wgl.wglMakeCurrent(IntPtr.Zero, IntPtr.Zero);
                Wgl.wglDeleteContext(this.renderContext);
                this.renderContext = IntPtr.Zero;
            }

            if (this.deviceContext != IntPtr.Zero) {
                if (this.Handle != IntPtr.Zero) {
                    User.ReleaseDC(this.Handle, this.deviceContext);
                }
                this.deviceContext = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Swaps the back and front buffer.
        /// </summary>
        internal void SwapBuffers() {
            Gdi.SwapBuffersFast(this.deviceContext);
        }

        /// <summary>
        /// Sets view to correct size.
        /// </summary>
        private void SetView() {
            Gl.glViewport(0, 0, this.Width, this.Height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glOrtho(-scale + zoom, scale - zoom, -scale + zoom, scale - zoom, -1000, 1000);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Gl.glFlush();
        }

        /// <summary>
        /// Everything, that has to be rendered, should be put here.
        /// </summary>
        private void RenderScene() {
            this.SetView();
            Gl.glLoadIdentity();

            Gl.glDrawBuffer(Gl.GL_BACK);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glPushMatrix();
            Gl.glRotatef(-this.xRot, 1.0f, 0.0f, 0.0f);
            Gl.glRotatef(this.yRot, 0.0f, 0.0f, 1.0f);
            Gl.glTranslatef(0.0f, 0.0f, -owner.Origin);

            this.DrawSTL();
            if (!picking) {
                this.DrawVertices();
            }
            if (!picking && corners) {
                this.DrawCorners();
            }

            Gl.glPopMatrix();
        }

        #endregion

        #region Drawing

        /// <summary>
        /// Initializes the colorArray. All vertices of unselected triangles get the color Aqua.
        /// Selected triangles get the color Red.
        /// </summary>
        internal void SetColorArray() {
            this.colorArray = new float[owner.TriangleList.Count * 9];
            for (int i = 0; i < owner.TriangleList.Count; i++) {
                if ((owner.CurrentSelection.Count != 0) && (owner.CurrentSelection.Contains(owner.TriangleList[i]))) {
                    colorArray[i * 9] = colorArray[i * 9 + 3] = colorArray[i * 9 + 6] = sColor[0];
                    colorArray[i * 9 + 1] = colorArray[i * 9 + 4] = colorArray[i * 9 + 7] = sColor[1];
                    colorArray[i * 9 + 2] = colorArray[i * 9 + 5] = colorArray[i * 9 + 8] = sColor[2];
                } else {
                    colorArray[i * 9] = colorArray[i * 9 + 3] = colorArray[i * 9 + 6] = uColor[0];
                    colorArray[i * 9 + 1] = colorArray[i * 9 + 4] = colorArray[i * 9 + 7] = uColor[1];
                    colorArray[i * 9 + 2] = colorArray[i * 9 + 5] = colorArray[i * 9 + 8] = uColor[2];
                }
            }
        }

        /// <summary>
        /// Draws the colored workpiece.
        /// </summary>
        private void DrawSTL() {
            Gl.glLineWidth(1.0f);
            Gl.glVertexPointer(3, Gl.GL_FLOAT, 0, owner.TriangleList.VertexArray);
            Gl.glNormalPointer(Gl.GL_FLOAT, 0, owner.TriangleList.NormalArray);
            if (picking) {
                Gl.glColorPointer(3, Gl.GL_FLOAT, 0, this.pickingColors);
            } else {
                Gl.glColorPointer(3, Gl.GL_FLOAT, 0, this.colorArray);
            }
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 0, owner.TriangleList.Count * 3);
        }

        /// <summary>
        /// Draws three selected vertices as spheres.
        /// </summary>
        private void DrawVertices() {
            Glu.GLUquadric quadobj = Glu.gluNewQuadric();
            Glu.gluQuadricDrawStyle(quadobj, Glu.GLU_FILL);

            if (vertices[0]) {
                Gl.glColor3fv(aColor);
                Gl.glPushMatrix();
                Gl.glTranslatef(owner.TriVertices[0], owner.TriVertices[1], owner.TriVertices[2]);
                Glu.gluSphere(quadobj, scale / 200, 10, 10);
                Gl.glPopMatrix();
            }

            if (vertices[1]) {
                Gl.glColor3fv(bColor);
                Gl.glPushMatrix();
                Gl.glTranslatef(owner.TriVertices[3], owner.TriVertices[4], owner.TriVertices[5]);
                Glu.gluSphere(quadobj, scale / 200, 10, 10);
                Gl.glPopMatrix();
            }

            if (vertices[2]) {
                Gl.glColor3fv(cColor);
                Gl.glPushMatrix();
                Gl.glTranslatef(owner.TriVertices[6], owner.TriVertices[7], owner.TriVertices[8]);
                Glu.gluSphere(quadobj, scale / 200, 10, 10);
                Gl.glPopMatrix();
            }

            Glu.gluDeleteQuadric(quadobj);
        }

        /// <summary>
        /// Draws the corners of one selected Triangle as spheres.
        /// </summary>
        private void DrawCorners() {
            Glu.GLUquadric quadobj = Glu.gluNewQuadric();
            Glu.gluQuadricDrawStyle(quadobj, Glu.GLU_FILL);

            Gl.glColor3fv(aColor);
            Gl.glPushMatrix();
            Gl.glTranslatef(owner.Corners[0],owner.Corners[1], owner.Corners[2]);
            Glu.gluSphere(quadobj, scale / 400, 10, 10);
            Gl.glPopMatrix();

            Gl.glColor3fv(bColor);
            Gl.glPushMatrix();
            Gl.glTranslatef(owner.Corners[3], owner.Corners[4], owner.Corners[5]);
            Glu.gluSphere(quadobj, scale / 400, 10, 10);
            Gl.glPopMatrix();

            Gl.glColor3fv(cColor);
            Gl.glPushMatrix();
            Gl.glTranslatef(owner.Corners[6], owner.Corners[7], owner.Corners[8]);
            Glu.gluSphere(quadobj, scale / 400, 10, 10);
            Gl.glPopMatrix();

            Glu.gluDeleteQuadric(quadobj);
        }

        #endregion

        #region Picking

        /// <summary>
        /// Sets a different color for each triangle for picking.
        /// </summary>
        internal void SetPickingColors() {
            RGB color;

            this.colorDist = 256 * 256 * 256 / (owner.TriangleList.Count + 2);
            this.pickingColors = new float[owner.TriangleList.Count * 9];

            for (int i = 0; i < owner.TriangleList.Count; i++) {
                color = SwitchersHelpers.GetRGBFromInt(i * colorDist);
                pickingColors[i * 9] = pickingColors[i * 9 + 3] = pickingColors[i * 9 + 6] = color.R;
                pickingColors[i * 9 + 1] = pickingColors[i * 9 + 4] = pickingColors[i * 9 + 7] = color.G;
                pickingColors[i * 9 + 2] = pickingColors[i * 9 + 5] = pickingColors[i * 9 + 8] = color.B;
            }
        }

        /// <summary>
        /// Reads the color of the pixel at the given position and picks the corresponding triangle
        /// </summary>
        /// <param name="rect">Contains, in this order,
        /// the X- and Y-coordinates of the lower left corner of the picking rectangle
        /// and its width and height.</param>
        /// <param name="additive">True, if the selected Triangle is to be added to the selection</param>
        private void PickTriangle(int[] rect, bool additive) {
            Gl.glDisable(Gl.GL_LIGHTING);
            Gl.glDisable(Gl.GL_LIGHT0);
            this.picking = true;

            float[] color = new float[3 * rect[2] * rect[3]];

            RenderScene();
            Gl.glReadBuffer(Gl.GL_BACK);
            Gl.glReadPixels(rect[0], rect[1], rect[2], rect[3], Gl.GL_RGB, Gl.GL_FLOAT, color);

            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            this.picking = false;

            owner.PickTriangle(SwitchersHelpers.UniqueSelection(color, colorDist, owner.TriangleList.Count), additive);
        }

        #endregion

        #endregion

        #region Event Handling Stuff

        /// <summary>
        /// When a button of the mouse is pressed, the values for the rotation are initialized.
        /// </summary>
        /// <param name="sender"> The mouse </param>
        /// <param name="ev"> Standard MouseEventArgs </param>
        private void MouseDownEvent(object sender, MouseEventArgs ev) {
            if (ev.Button == MouseButtons.Left) {
                int[] pickingRectangle = SwitchersHelpers.GetPickingRectangle(ev.X, this.Height - ev.Y, ev.X, this.Height - ev.Y);
                if (Control.ModifierKeys == Keys.Control) {
                    this.PickTriangle(pickingRectangle, true);
                } else {
                    this.PickTriangle(pickingRectangle, false);
                }
            }
            this.xDiff = ev.X - this.yRot;
            this.yDiff = ev.Y + this.xRot;
        }

        /// <summary>
        /// When the mouse is moved with the left or the right mouse button pressed, a rotation will be conducted.
        /// </summary>
        /// <param name="sender"> The mouse </param>
        /// <param name="ev"> Standard MouseEventArgs </param>
        private void MouseMoveEvent(object sender, MouseEventArgs ev) {
            if (ev.Button == MouseButtons.Right) {
                this.yRot = ev.X - this.xDiff;
                this.xRot = -ev.Y + this.yDiff;
                this.Invalidate();
            }
        }

        /// <summary>
        /// When the mouse wheel is moved, the view is zoomed in or out. 
        /// </summary>
        /// <param name="sender"> The mouse wheel </param>
        /// <param name="ev"> Standard MouseEventArgs </param>
        private void MouseWheelEvent(object sender, MouseEventArgs ev) {
            if (this.zoom + scale * ev.Delta / 1000 < scale) {
                this.zoom += scale * ev.Delta / 1000;
                this.SetView();
                this.Invalidate();
            }
        }

        /// <summary>
        /// Handles the MouseEnter event.
        /// </summary>
        /// <param name="e">Standard EventArgs</param>
        protected override void OnMouseEnter(EventArgs e) {
            base.OnMouseEnter(e);
            this.Focus();
        }

        /// <summary>
        /// Handles the Paint event.
        /// </summary>
        /// <param name="e">Standard PaintEventArgs</param>
        protected override void OnPaint(PaintEventArgs e) {
            if (fresh) {
                if (this.deviceContext == IntPtr.Zero || this.renderContext == IntPtr.Zero) {
                    MessageBox.Show("No device or rendering context available!");
                    return;
                }

                base.OnPaint(e);

                //Only switch contexts if this is already not the current context
                if (this.renderContext != Wgl.wglGetCurrentContext()) {
                    this.MakeCurrentContext();
                }
                this.RenderScene();
                this.SwapBuffers();
            }
        }

        #endregion
    }
}
