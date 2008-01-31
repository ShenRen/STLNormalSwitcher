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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace STLNormalSwitcher {
    /// <summary>
    /// The GUI of the STLNormalSwitcher.
    /// </summary>
    internal partial class NormalSwitcherForm : Form {

        #region Fields

        private NormalSwitcherControl visualization;
        private STLParser parser = new STLParser();

        private String currentFile;

        private TriangleList triangleList;
        private TriangleList backupList;

        private float origin;
        private float[] triVertices = new float[9];
        private float[] corners = new float[9];
        private bool changed = false;

        private List<Event> history = new List<Event>();
        private Event currentSelection = new Event();

        #endregion

        #region Properties

        /// <value>Gets the TriangleList or sets it</value>
        internal TriangleList TriangleList {
            get { return triangleList; }
            set { triangleList = value; }
        }

        /// <value>
        /// Gets the positions of the owners of the Vertices selected on the "Add/Remove"-Tab
        /// and the positions of those Vertices in that Triangle.
        /// </value>
        internal float[] TriVertices {
            get { return triVertices; }
            set { triVertices = value; }
        }

        /// <value> Gets the positions of the corners of the selected triangle</value>
        internal float[] Corners { get { return corners; } }

        /// <value>Gets the origin, the z-value to rotate around</value>
        internal float Origin { get { return origin; } }

        /// <value>Gets the currentSelection or sets it</value>
        internal Event CurrentSelection {
            get { return currentSelection; }
            set { currentSelection = value; }
        }

        /// <value>Gets the visualization or sets it</value>
        internal NormalSwitcherControl Visualization {
            get { return visualization; }
            set { visualization = value; }
        }

        /// <value>Gets the history or sets it. Sets changed to true, when the history is changed.</value>
        internal List<Event> History {
            get { return history; }
            set {
                history = value;
                changed = true;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes the NormalSwitcherForm and subscribes to events.
        /// </summary>
        internal NormalSwitcherForm() {
            InitializeComponent();
            currentFile = "";

            BindEvents();
        }

        /// <summary>
        /// Initializes the NormalSwitcherForm and opens the file given by <paramref name="file"/>
        /// </summary>
        /// <param name="file">Path of the file to be displayed</param>
        internal NormalSwitcherForm(string file) {
            InitializeComponent();

            BindEvents();

            StreamReader reader = new StreamReader(file);
            try {
                parser.Parse(reader);
                triangleList = parser.TriangleList;
                backupList = triangleList.Copy();
                SetOrigin();
                originTrackBar.Visible = true;
                InitVisualization();

                currentFile = file;
                allButton.Enabled = true;

                InitializePages();
            } catch (Exception exception) {
                MessageBox.Show(exception.Message, "Error");
            } finally {
                reader.Close();
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Subscribes to the events neccessary to enable or disable the buttons.
        /// </summary>
        private void BindEvents() {
            undoButton.EnabledChanged += new EventHandler(Undo_EnabledChanged);
            allButton.EnabledChanged += new EventHandler(FileCondition_EnabledChanged);
        }

        /// <summary>
        /// Creates the new TabPages and adds them to tabControl1.
        /// </summary>
        private void InitializePages() {
            tabControl1.TabPages.Add(new Page(new ListPanel(this), "List of Triangles"));
            tabControl1.TabPages.Add(new Page(new EditPanel(this), "Edit Selected Triangle"));
            tabControl1.TabPages.Add(new Page(new AddPanel(this), "Add/Remove Triangle"));

            (tabControl1.SelectedTab as Page).UpdateTab();
        }

        /// <summary>
        /// Creates a new NormalSwitcherControl and adds it to the NormalSwitcherForm.
        /// </summary>
        private void InitVisualization() {
            visualization = new NormalSwitcherControl(this);
            splitContainer2.Panel2.Controls.Add(visualization);
            visualization.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Sets the origin for rotation.
        /// </summary>
        internal void SetOrigin() {
            originTrackBar.Minimum = -100;
            originTrackBar.Maximum = 100;
            originTrackBar.Value = 0;
            origin = 0.0f;
            rotationOriginTextBox.Text = origin.ToString();
        }

        /// <summary>
        /// Sets the colorArray of the visualization and refreshes the visualization.
        /// </summary>
        internal void RefreshVisualization() {
            visualization.SetColorArray();
            visualization.Fresh = true;
        }

        /// <summary>
        /// Enables the undoButton and the corresponding menu-item or disables them.
        /// </summary>
        /// <param name="value">True, if the undoButton should be enabled</param>
        internal void SetUndoButton(bool value) { undoButton.Enabled = value; }
        
        /// <summary>
        /// Marks the triangles picked in the visualization.
        /// </summary>
        /// <param name="selected">List of the selected triangles</param>
        /// <param name="additive">If true, the <paramref name="selected"/> triangles will be selected
        /// in addition to the previously selected ones. Selecting a triangle twice deselects it.</param>
        internal void PickTriangle(List<int> selected, bool additive) {
            visualization.Fresh = false;
            if (additive) {
                if (selected.Count > 0) {
                    for (int i = 0; i < triangleList.Count; i++) {
                        if (triangleList[i].Position == selected[0]) {
                            if (currentSelection.Contains(triangleList[i])) {
                                currentSelection.Remove(triangleList[i]);
                            } else {
                                currentSelection.Add(triangleList[i]);
                            }
                        }
                    }
                }
            } else {
                currentSelection.Clear();
                if (selected.Count > 0) {
                    for (int i = 0; i < triangleList.Count; i++) {
                        if (triangleList[i].Position == selected[0]) {
                            currentSelection.Add(triangleList[i]);
                        }
                    }
                }
            }

            (tabControl1.SelectedTab as Page).UpdateTab();
            RefreshVisualization();

        }

        /// <summary>
        /// Fills the corners array with the values of the vertices of the currently selected Triangle.
        /// </summary>
        internal void SetCorners() {
            if (currentSelection[0] != null) {
                for (int i = 0; i < 9; i++) {
                    corners[i] = triangleList.VertexArray[currentSelection[0].Position * 9 + i];
                }
            }
        }

        /// <summary>
        /// Sets the changed-flag for all Pages in the tabControl to true.
        /// </summary>
        internal void SetPanelsChanged() {
            for (int i = 0; i < 3; i++) {
                (tabControl1.TabPages[i] as Page).Changed = true;
            }
        }

        #endregion

        #region Event Handling Stuff

        #region Menu

        /// <summary>
        /// Closes a previously opened file and opens a new one.
        /// Parses the file and initializes the arrays and GUI-elements.
        /// </summary>
        /// <param name="sender">openToolStripMenuItem</param>
        /// <param name="e">Standard EventArgs</param>
        private void OpenFile(object sender, EventArgs e) {
            try {
                CloseFile(sender, e);

                OpenFileDialog ofd = new OpenFileDialog();
                ofd.CheckFileExists = true;
                ofd.DefaultExt = "stl";
                ofd.Filter = "STL Files (*.stl)|*.stl";
                ofd.Multiselect = false;
                ofd.Title = "Open STL-file";
                if (ofd.ShowDialog() == DialogResult.OK) {
                    StreamReader reader = new StreamReader(ofd.FileName);
                    try {
                        parser.Parse(reader);

                        triangleList = parser.TriangleList;
                        backupList = triangleList.Copy();
                        SetOrigin();
                        originTrackBar.Visible = true;
                        InitVisualization();

                        currentFile = ofd.FileName;
                        allButton.Enabled = true;

                        InitializePages();
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message, "Error");
                    } finally {
                        reader.Close();
                    }
                }
                ofd.Dispose();
            } catch { }
        }

        /// <summary>
        /// Overwrites the opened file with the STL-data in the same format (ASCII or binary).
        /// </summary>
        /// <param name="sender">saveToolStripMenuItem</param>
        /// <param name="e">Standard EventArgs</param>
        private void SaveFile(object sender, EventArgs e) {
            if (triangleList.Count == 0) {
                MessageBox.Show("You need at least one triangle to save!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else {
                if (parser.ASCII) {
                    SwitchersHelpers.WriteToASCII(this.currentFile, triangleList);
                } else {
                    SwitchersHelpers.WriteToBinary(this.currentFile, triangleList);
                }
                changed = false;
            }
        }

        /// <summary>
        /// Saves the STL-data in the chosen file and the chosen format (ASCII or binary).
        /// </summary>
        /// <param name="sender">saveAsToolStripMenuItem</param>
        /// <param name="e">Standard EventArgs</param>
        private void SaveAs(object sender, EventArgs e) {
            if (triangleList.Count == 0) {
                MessageBox.Show("You need at least one triangle to save!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.AddExtension = true;
                sfd.DefaultExt = "stl";
                sfd.Filter = "ASCII STL File (*.stl)|*.stl|Binary STL File (*.stl)|*.stl";
                sfd.OverwritePrompt = true;
                if (sfd.ShowDialog() == DialogResult.OK) {
                    if (sfd.FilterIndex == 1) {
                        SwitchersHelpers.WriteToASCII(sfd.FileName, triangleList);
                    } else {
                        SwitchersHelpers.WriteToBinary(sfd.FileName, triangleList);
                    }
                    changed = false;
                }
            }
        }

        /// <summary>
        /// Destroys the NormalSwitcherControl and resets the GUI-elements.
        /// </summary>
        /// <param name="sender">closeToolStripMenuItem</param>
        /// <param name="e">Standard EventArgs</param>
        private void CloseFile(object sender, EventArgs e) {
            if (currentFile != "") {
                if (changed && (MessageBox.Show("Do you want to save your changes?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)) {
                    if ((triangleList.Count == 0) && (MessageBox.Show("You need at least one triangle to save!", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)) {
                        throw new Exception();
                    } else if (triangleList.Count > 0) {
                        this.SaveAs(sender, e);
                    }
                }

                splitContainer2.Panel2.Controls.Clear();
                visualization = null;
                originTrackBar.Visible = false;
                history.Clear();
                currentSelection.Clear();
                currentFile = "";
                allButton.Enabled = false;
                undoButton.Enabled = false;

                triangleList = backupList = null;
                parser = new STLParser();
                changed = false;
                triVertices = new float[9];
                corners = new float[9];

                tabControl1.TabPages.Clear();
            }
        }

        /// <summary>
        /// Closes the NormalSwitcherForm.
        /// </summary>
        /// <param name="sender">exitToolStripMenuItem</param>
        /// <param name="e">Standard EventArgs</param>
        private void Exit(object sender, EventArgs e) {
            this.Close();
        }

        /// <summary>
        /// Reverts the last change.
        /// </summary>
        /// <param name="sender">undoToolStripMenuItem or undoButton</param>
        /// <param name="e">Standard EventArgs</param>
        private void Undo(object sender, EventArgs e) {
            visualization.Fresh = false;
            if (history.Count >= 1) {
                currentSelection = history[history.Count - 1];
                if (currentSelection.eventType == Event.EventType.SwitchAll) {
                    triangleList.SwitchAll();
                } else if (currentSelection.eventType == Event.EventType.Edit) {
                    for (int i = 0; i < currentSelection.Count; i++) {
                        triangleList.EditTriangle(currentSelection[i]);
                    }
                } else if (currentSelection.eventType == Event.EventType.Add) {
                    triangleList.RemoveAt(currentSelection[0].Position);
                    triangleList.SetPositions();
                    currentSelection.Clear();
                } else {
                    triangleList.Insert(currentSelection[0].Position, currentSelection[0]);
                    triangleList.SetPositions();
                }
                history.RemoveAt(history.Count - 1);
            }
            if (history.Count == 0) {
                undoButton.Enabled = false;
            }

            triangleList.CalculateArrays();
            visualization.SetColorArray();
            visualization.SetPickingColors();
            SetOrigin();
            SetPanelsChanged();
            (tabControl1.SelectedTab as Page).UpdateTab();
        }

        /// <summary>
        /// Sets all triangles back to the values from the STL-file.
        /// </summary>
        /// <param name="sender">resetToolStripMenuItem or resetButton</param>
        /// <param name="e">Standard EventArgs</param>
        private void Reset(object sender, EventArgs e) {
            triangleList = null;
            triangleList = backupList.Copy();
            currentSelection.Clear();
            history.Clear();

            undoButton.Enabled = false;
            changed = false;
            visualization.SetColorArray();
            visualization.SetPickingColors();
            SetOrigin();
            SetPanelsChanged();
            (tabControl1.SelectedTab as Page).UpdateTab();
        }

        /// <summary>
        /// Clears the history to free memory.
        /// </summary>
        /// <param name="sender">clearHistoryToolStripMenuItem</param>
        /// <param name="e">Standard EventArgs</param>
        private void ClearHistoryToolStripMenuItem_Click(object sender, EventArgs e) {
            history.Clear();
            undoButton.Enabled = false;
        }

        /// <summary>
        /// Switches all normal vectors.
        /// </summary>
        /// <param name="sender">switchAllToolStripMenuItem or allButton</param>
        /// <param name="e">Standard EventArgs</param>
        private void SwitchAll(object sender, EventArgs e) {
            Event temp = new Event(Event.EventType.SwitchAll);
            history.Add(temp);
            triangleList.SwitchAll();

            undoButton.Enabled = true;
            changed = true;
            SetPanelsChanged();
            SetPanelsChanged();
            (tabControl1.SelectedTab as Page).UpdateTab();
        }

        /// <summary>
        /// Switches the selected normal vectors.
        /// </summary>
        /// <param name="sender">switchSelectedToolStripMenuItem or selectedButton</param>
        /// <param name="e">Standard EventArgs</param>
        private void SwitchSelected(object sender, EventArgs e) {
            if (currentSelection.Count > 0) {
                Event temp = new Event(Event.EventType.Edit);
                for (int i = 0; i < currentSelection.Count; i++) {
                    temp.Add(currentSelection[i].Copy());
                }
                history.Add(temp);

                triangleList.SwitchSelected(currentSelection);

                undoButton.Enabled = true;
                changed = true;
                SetPanelsChanged();
                (tabControl1.SelectedTab as Page).UpdateTab();
            }
        }

        /// <summary>
        /// Shows the About dialog with information about the STLNormalSwitcher.
        /// </summary>
        /// <param name="sender">aboutToolStripMenuItem</param>
        /// <param name="e">Standard EventArgs</param>
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e) {
            About about = new About();
            about.ShowDialog();
        }

        #region Activation/Deaktivation

        /// <summary>
        /// The undoToolStripMenuItem and the undoButton are enabled and disabled at the same time.
        /// </summary>
        /// <param name="sender">undoButton</param>
        /// <param name="e">Standard EventArgs</param>
        private void Undo_EnabledChanged(object sender, EventArgs e) {
            undoToolStripMenuItem.Enabled = undoButton.Enabled;
        }

        /// <summary>
        /// The closeToolStripMenuItem, the saveToolStripMenuItem, the saveAsToolStripMenuItem,
        /// the switchAllToolStripMenuItem, the switchSelectedToolStripMenuItem, the selectedButton,
        /// the rotationOriginTextBox, the resetButton, the resetToolStripMenuItem
        /// and the allButton are enabled and disabled at the same time.
        /// </summary>
        /// <param name="sender">allButton</param>
        /// <param name="e">Standard EventArgs</param>
        private void FileCondition_EnabledChanged(object sender, EventArgs e) {
            closeToolStripMenuItem.Enabled =
                saveToolStripMenuItem.Enabled =
                saveAsToolStripMenuItem.Enabled =
                switchAllToolStripMenuItem.Enabled =
                switchSelectedToolStripMenuItem.Enabled =
                selectedButton.Enabled =
                rotationOriginTextBox.Enabled =
                resetButton.Enabled =
                resetToolStripMenuItem.Enabled =
                clearHistoryToolStripMenuItem.Enabled =
                clearHistoryButton.Enabled =
                allButton.Enabled;
        }

        #endregion

        #endregion

        /// <summary>
        /// Updates the rotationOriginTextBox and the origin,
        /// when the value of the originTrackBar is changed and refreshes the NormalSwitcherControl.
        /// </summary>
        /// <param name="sender">originTrackBar</param>
        /// <param name="e">Standard EventArgs</param>
        private void OriginTrackBar_ValueChanged(object sender, EventArgs e) {
            origin = triangleList.Scale * originTrackBar.Value / 100;
            rotationOriginTextBox.Text = originTrackBar.Value.ToString();
            visualization.Refresh();
        }

        /// <summary>
        /// Updates the originTrackBar when an integer is entered in the roationOriginTextBox.
        /// </summary>
        /// <param name="sender">rotationOriginTextBox</param>
        /// <param name="e">Standard EventArgs</param>
        private void RotationOriginTextBox_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Return) {
                try {
                    int value = Convert.ToInt32(rotationOriginTextBox.Text);
                    if (value < originTrackBar.Minimum) {
                        originTrackBar.Value = originTrackBar.Minimum;
                        OriginTrackBar_ValueChanged(sender, e);
                    } else if (value > originTrackBar.Maximum) {
                        originTrackBar.Value = originTrackBar.Maximum;
                        OriginTrackBar_ValueChanged(sender, e);
                    } else {
                        originTrackBar.Value = value;
                        OriginTrackBar_ValueChanged(sender, e);
                    }
                } catch { rotationOriginTextBox.Text = originTrackBar.Value.ToString(); }
            }
            if ((!char.IsNumber(e.KeyChar)) & (e.KeyChar != '-') & (e.KeyChar != (char)Keys.Back)) {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Closes a previously opened file and ends the Application.
        /// </summary>
        /// <param name="sender">FormClosing event</param>
        /// <param name="e">Standard FormClosingEventArgs</param>
        private void NormalSwitcherForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (changed && (MessageBox.Show("Do you want to save your changes?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)) {
                this.SaveAs(sender, e);
            }
            if (visualization != null) {
                visualization.DestroyContexts();
            }
        }

        /// <summary>
        /// Adjusts the colorArray depending on the chosen Tab.
        /// </summary>
        /// <param name="sender">tabControl1</param>
        /// <param name="e">Standard TabControlCancelEventArgs</param>
        private void TabControl1_Selecting(object sender, TabControlCancelEventArgs e) {
            if (currentFile != "") {
                (e.TabPage as Page).UpdateTab();
            }
        }

        #endregion

    }
}