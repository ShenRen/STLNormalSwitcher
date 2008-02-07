// Part of STLNormalSwitcher: A program to switch normal vectors in STL-files
//
// Copyright (C) 2008  PG500, ISF, University of Dortmund
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

namespace STLNormalSwitcher {
    /// <summary>
    /// The TabPanel for adding and removing Triangles.
    /// </summary>
    internal class AddPanel : TabPanel {

        #region Designer

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TextBox normalX;
        private System.Windows.Forms.Label labelNormal;
        private System.Windows.Forms.TextBox normalY;
        private System.Windows.Forms.TextBox normalZ;
        private System.Windows.Forms.Button addTriangleButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label labelC;
        private System.Windows.Forms.TextBox cX;
        private System.Windows.Forms.TextBox cY;
        private System.Windows.Forms.TextBox cZ;
        private System.Windows.Forms.Label labelB;
        private System.Windows.Forms.TextBox bX;
        private System.Windows.Forms.TextBox bY;
        private System.Windows.Forms.TextBox bZ;
        private System.Windows.Forms.TextBox aX;
        private System.Windows.Forms.TextBox aY;
        private System.Windows.Forms.TextBox aZ;
        private System.Windows.Forms.Label labelZ;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelA;
        private System.Windows.Forms.ComboBox triangleComboBox;
        private System.Windows.Forms.Label labelTriangle;
        private System.Windows.Forms.Button copyA;
        private System.Windows.Forms.Button copyC;
        private System.Windows.Forms.Button copyB;
        private System.Windows.Forms.Label labelVertex;
        private System.Windows.Forms.Button triangleCopyButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox verticesA;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox verticesB;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox verticesC;

        private void InitializeComponent() {
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.normalX = new System.Windows.Forms.TextBox();
            this.labelNormal = new System.Windows.Forms.Label();
            this.normalY = new System.Windows.Forms.TextBox();
            this.normalZ = new System.Windows.Forms.TextBox();
            this.addTriangleButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.cX = new System.Windows.Forms.TextBox();
            this.cY = new System.Windows.Forms.TextBox();
            this.cZ = new System.Windows.Forms.TextBox();
            this.bX = new System.Windows.Forms.TextBox();
            this.bY = new System.Windows.Forms.TextBox();
            this.bZ = new System.Windows.Forms.TextBox();
            this.aX = new System.Windows.Forms.TextBox();
            this.aY = new System.Windows.Forms.TextBox();
            this.aZ = new System.Windows.Forms.TextBox();
            this.labelZ = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.triangleComboBox = new System.Windows.Forms.ComboBox();
            this.labelTriangle = new System.Windows.Forms.Label();
            this.copyA = new System.Windows.Forms.Button();
            this.copyC = new System.Windows.Forms.Button();
            this.copyB = new System.Windows.Forms.Button();
            this.labelVertex = new System.Windows.Forms.Label();
            this.triangleCopyButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.verticesA = new System.Windows.Forms.ComboBox();
            this.verticesB = new System.Windows.Forms.ComboBox();
            this.verticesC = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelA = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.labelB = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.labelC = new System.Windows.Forms.Label();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel4.ColumnCount = 13;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.normalX, 2, 7);
            this.tableLayoutPanel4.Controls.Add(this.labelNormal, 1, 7);
            this.tableLayoutPanel4.Controls.Add(this.normalY, 4, 7);
            this.tableLayoutPanel4.Controls.Add(this.normalZ, 5, 7);
            this.tableLayoutPanel4.Controls.Add(this.addTriangleButton, 7, 7);
            this.tableLayoutPanel4.Controls.Add(this.addButton, 8, 7);
            this.tableLayoutPanel4.Controls.Add(this.cX, 2, 5);
            this.tableLayoutPanel4.Controls.Add(this.cY, 4, 5);
            this.tableLayoutPanel4.Controls.Add(this.cZ, 5, 5);
            this.tableLayoutPanel4.Controls.Add(this.bY, 4, 4);
            this.tableLayoutPanel4.Controls.Add(this.bZ, 5, 4);
            this.tableLayoutPanel4.Controls.Add(this.aY, 4, 3);
            this.tableLayoutPanel4.Controls.Add(this.aZ, 5, 3);
            this.tableLayoutPanel4.Controls.Add(this.labelZ, 5, 2);
            this.tableLayoutPanel4.Controls.Add(this.labelY, 4, 2);
            this.tableLayoutPanel4.Controls.Add(this.triangleComboBox, 3, 1);
            this.tableLayoutPanel4.Controls.Add(this.copyA, 11, 3);
            this.tableLayoutPanel4.Controls.Add(this.copyC, 11, 5);
            this.tableLayoutPanel4.Controls.Add(this.copyB, 11, 4);
            this.tableLayoutPanel4.Controls.Add(this.labelVertex, 7, 2);
            this.tableLayoutPanel4.Controls.Add(this.triangleCopyButton, 9, 1);
            this.tableLayoutPanel4.Controls.Add(this.removeButton, 10, 1);
            this.tableLayoutPanel4.Controls.Add(this.verticesA, 7, 3);
            this.tableLayoutPanel4.Controls.Add(this.verticesB, 7, 4);
            this.tableLayoutPanel4.Controls.Add(this.verticesC, 7, 5);
            this.tableLayoutPanel4.Controls.Add(this.panel4, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.panel5, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.panel6, 1, 5);
            this.tableLayoutPanel4.Controls.Add(this.labelX, 2, 2);
            this.tableLayoutPanel4.Controls.Add(this.labelTriangle, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.aX, 2, 3);
            this.tableLayoutPanel4.Controls.Add(this.bX, 2, 4);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.MinimumSize = new System.Drawing.Size(608, 208);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 9;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(739, 222);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // normalX
            // 
            this.tableLayoutPanel4.SetColumnSpan(this.normalX, 2);
            this.normalX.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.normalX.Location = new System.Drawing.Point(58, 177);
            this.normalX.Name = "normalX";
            this.normalX.Size = new System.Drawing.Size(114, 20);
            this.normalX.TabIndex = 31;
            this.normalX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TriangleValue_KeyPress);
            // 
            // labelNormal
            // 
            this.labelNormal.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelNormal.AutoSize = true;
            this.labelNormal.Location = new System.Drawing.Point(8, 187);
            this.labelNormal.Name = "labelNormal";
            this.labelNormal.Size = new System.Drawing.Size(43, 13);
            this.labelNormal.TabIndex = 32;
            this.labelNormal.Text = "Normal:";
            // 
            // normalY
            // 
            this.normalY.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.normalY.Location = new System.Drawing.Point(178, 177);
            this.normalY.Name = "normalY";
            this.normalY.Size = new System.Drawing.Size(114, 20);
            this.normalY.TabIndex = 30;
            this.normalY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TriangleValue_KeyPress);
            // 
            // normalZ
            // 
            this.normalZ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.normalZ.Location = new System.Drawing.Point(298, 177);
            this.normalZ.Name = "normalZ";
            this.normalZ.Size = new System.Drawing.Size(114, 20);
            this.normalZ.TabIndex = 29;
            this.normalZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TriangleValue_KeyPress);
            // 
            // addTriangleButton
            // 
            this.addTriangleButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addTriangleButton.Location = new System.Drawing.Point(423, 173);
            this.addTriangleButton.Name = "addTriangleButton";
            this.tableLayoutPanel4.SetRowSpan(this.addTriangleButton, 2);
            this.addTriangleButton.Size = new System.Drawing.Size(104, 46);
            this.addTriangleButton.TabIndex = 20;
            this.addTriangleButton.Text = "Add Triangle";
            this.addTriangleButton.UseVisualStyleBackColor = true;
            this.addTriangleButton.Click += new System.EventHandler(this.AddTriangleButton_Click);
            // 
            // addButton
            // 
            this.tableLayoutPanel4.SetColumnSpan(this.addButton, 4);
            this.addButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addButton.Location = new System.Drawing.Point(533, 173);
            this.addButton.Name = "addButton";
            this.tableLayoutPanel4.SetRowSpan(this.addButton, 2);
            this.addButton.Size = new System.Drawing.Size(189, 46);
            this.addButton.TabIndex = 21;
            this.addButton.Text = "Add Triangle with Normal";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // cX
            // 
            this.tableLayoutPanel4.SetColumnSpan(this.cX, 2);
            this.cX.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cX.Location = new System.Drawing.Point(58, 132);
            this.cX.Name = "cX";
            this.cX.Size = new System.Drawing.Size(114, 20);
            this.cX.TabIndex = 9;
            this.cX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TriangleValue_KeyPress);
            this.cX.TextChanged += new System.EventHandler(this.C_Changed);
            // 
            // cY
            // 
            this.cY.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cY.Location = new System.Drawing.Point(178, 132);
            this.cY.Name = "cY";
            this.cY.Size = new System.Drawing.Size(114, 20);
            this.cY.TabIndex = 11;
            this.cY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TriangleValue_KeyPress);
            this.cY.TextChanged += new System.EventHandler(this.C_Changed);
            // 
            // cZ
            // 
            this.cZ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cZ.Location = new System.Drawing.Point(298, 132);
            this.cZ.Name = "cZ";
            this.cZ.Size = new System.Drawing.Size(114, 20);
            this.cZ.TabIndex = 10;
            this.cZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TriangleValue_KeyPress);
            this.cZ.TextChanged += new System.EventHandler(this.C_Changed);
            // 
            // bX
            // 
            this.tableLayoutPanel4.SetColumnSpan(this.bX, 2);
            this.bX.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bX.Location = new System.Drawing.Point(58, 102);
            this.bX.Name = "bX";
            this.bX.Size = new System.Drawing.Size(114, 20);
            this.bX.TabIndex = 6;
            this.bX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TriangleValue_KeyPress);
            this.bX.TextChanged += new System.EventHandler(this.B_Changed);
            // 
            // bY
            // 
            this.bY.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bY.Location = new System.Drawing.Point(178, 102);
            this.bY.Name = "bY";
            this.bY.Size = new System.Drawing.Size(114, 20);
            this.bY.TabIndex = 7;
            this.bY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TriangleValue_KeyPress);
            this.bY.TextChanged += new System.EventHandler(this.B_Changed);
            // 
            // bZ
            // 
            this.bZ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bZ.Location = new System.Drawing.Point(298, 102);
            this.bZ.Name = "bZ";
            this.bZ.Size = new System.Drawing.Size(114, 20);
            this.bZ.TabIndex = 8;
            this.bZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TriangleValue_KeyPress);
            this.bZ.TextChanged += new System.EventHandler(this.B_Changed);
            // 
            // aX
            // 
            this.tableLayoutPanel4.SetColumnSpan(this.aX, 2);
            this.aX.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.aX.Location = new System.Drawing.Point(58, 72);
            this.aX.Name = "aX";
            this.aX.Size = new System.Drawing.Size(114, 20);
            this.aX.TabIndex = 3;
            this.aX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TriangleValue_KeyPress);
            this.aX.TextChanged += new System.EventHandler(this.A_Changed);
            // 
            // aY
            // 
            this.aY.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.aY.Location = new System.Drawing.Point(178, 72);
            this.aY.Name = "aY";
            this.aY.Size = new System.Drawing.Size(114, 20);
            this.aY.TabIndex = 4;
            this.aY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TriangleValue_KeyPress);
            this.aY.TextChanged += new System.EventHandler(this.A_Changed);
            // 
            // aZ
            // 
            this.aZ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.aZ.Location = new System.Drawing.Point(298, 72);
            this.aZ.Name = "aZ";
            this.aZ.Size = new System.Drawing.Size(114, 20);
            this.aZ.TabIndex = 5;
            this.aZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TriangleValue_KeyPress);
            this.aZ.TextChanged += new System.EventHandler(this.A_Changed);
            // 
            // labelZ
            // 
            this.labelZ.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelZ.AutoSize = true;
            this.labelZ.Location = new System.Drawing.Point(348, 52);
            this.labelZ.Name = "labelZ";
            this.labelZ.Size = new System.Drawing.Size(14, 13);
            this.labelZ.TabIndex = 14;
            this.labelZ.Text = "Z";
            // 
            // labelY
            // 
            this.labelY.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(226, 52);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(17, 13);
            this.labelY.TabIndex = 13;
            this.labelY.Text = " Y";
            // 
            // labelX
            // 
            this.labelX.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelX.AutoSize = true;
            this.tableLayoutPanel4.SetColumnSpan(this.labelX, 2);
            this.labelX.Location = new System.Drawing.Point(108, 52);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(14, 13);
            this.labelX.TabIndex = 12;
            this.labelX.Text = "X";
            // 
            // triangleComboBox
            // 
            this.tableLayoutPanel4.SetColumnSpan(this.triangleComboBox, 6);
            this.triangleComboBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.triangleComboBox.FormattingEnabled = true;
            this.triangleComboBox.Location = new System.Drawing.Point(118, 11);
            this.triangleComboBox.Name = "triangleComboBox";
            this.triangleComboBox.Size = new System.Drawing.Size(484, 21);
            this.triangleComboBox.TabIndex = 35;
            this.triangleComboBox.SelectedIndexChanged += new System.EventHandler(this.TriangleComboBox_SelectedIndexChanged);
            // 
            // labelTriangle
            // 
            this.labelTriangle.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelTriangle.AutoSize = true;
            this.tableLayoutPanel4.SetColumnSpan(this.labelTriangle, 2);
            this.labelTriangle.Location = new System.Drawing.Point(13, 22);
            this.labelTriangle.Name = "labelTriangle";
            this.labelTriangle.Size = new System.Drawing.Size(93, 13);
            this.labelTriangle.TabIndex = 34;
            this.labelTriangle.Text = "Selected Triangle:";
            // 
            // copyA
            // 
            this.copyA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.copyA.Location = new System.Drawing.Point(678, 68);
            this.copyA.Name = "copyA";
            this.copyA.Size = new System.Drawing.Size(44, 24);
            this.copyA.TabIndex = 23;
            this.copyA.Text = "Copy";
            this.copyA.UseVisualStyleBackColor = true;
            this.copyA.Click += new System.EventHandler(this.CopyA_Click);
            // 
            // copyC
            // 
            this.copyC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.copyC.Location = new System.Drawing.Point(678, 128);
            this.copyC.Name = "copyC";
            this.copyC.Size = new System.Drawing.Size(44, 24);
            this.copyC.TabIndex = 25;
            this.copyC.Text = "Copy";
            this.copyC.UseVisualStyleBackColor = true;
            this.copyC.Click += new System.EventHandler(this.CopyC_Click);
            // 
            // copyB
            // 
            this.copyB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.copyB.Location = new System.Drawing.Point(678, 98);
            this.copyB.Name = "copyB";
            this.copyB.Size = new System.Drawing.Size(44, 24);
            this.copyB.TabIndex = 24;
            this.copyB.Text = "Copy";
            this.copyB.UseVisualStyleBackColor = true;
            this.copyB.Click += new System.EventHandler(this.CopyB_Click);
            // 
            // labelVertex
            // 
            this.labelVertex.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelVertex.AutoSize = true;
            this.tableLayoutPanel4.SetColumnSpan(this.labelVertex, 4);
            this.labelVertex.Location = new System.Drawing.Point(527, 52);
            this.labelVertex.Name = "labelVertex";
            this.labelVertex.Size = new System.Drawing.Size(40, 13);
            this.labelVertex.TabIndex = 33;
            this.labelVertex.Text = "Vertex:";
            // 
            // triangleCopyButton
            // 
            this.triangleCopyButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.triangleCopyButton.Location = new System.Drawing.Point(608, 8);
            this.triangleCopyButton.Name = "triangleCopyButton";
            this.triangleCopyButton.Size = new System.Drawing.Size(44, 24);
            this.triangleCopyButton.TabIndex = 36;
            this.triangleCopyButton.Text = "Copy";
            this.triangleCopyButton.UseVisualStyleBackColor = true;
            this.triangleCopyButton.Click += new System.EventHandler(this.TriangleCopyButton_Click);
            // 
            // removeButton
            // 
            this.tableLayoutPanel4.SetColumnSpan(this.removeButton, 2);
            this.removeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.removeButton.Location = new System.Drawing.Point(658, 8);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(64, 24);
            this.removeButton.TabIndex = 40;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // verticesA
            // 
            this.tableLayoutPanel4.SetColumnSpan(this.verticesA, 4);
            this.verticesA.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.verticesA.FormattingEnabled = true;
            this.verticesA.Location = new System.Drawing.Point(423, 71);
            this.verticesA.Name = "verticesA";
            this.verticesA.Size = new System.Drawing.Size(249, 21);
            this.verticesA.TabIndex = 26;
            // 
            // verticesB
            // 
            this.tableLayoutPanel4.SetColumnSpan(this.verticesB, 4);
            this.verticesB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.verticesB.FormattingEnabled = true;
            this.verticesB.Location = new System.Drawing.Point(423, 101);
            this.verticesB.Name = "verticesB";
            this.verticesB.Size = new System.Drawing.Size(249, 21);
            this.verticesB.TabIndex = 38;
            // 
            // verticesC
            // 
            this.tableLayoutPanel4.SetColumnSpan(this.verticesC, 4);
            this.verticesC.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.verticesC.FormattingEnabled = true;
            this.verticesC.Location = new System.Drawing.Point(423, 131);
            this.verticesC.Name = "verticesC";
            this.verticesC.Size = new System.Drawing.Size(249, 21);
            this.verticesC.TabIndex = 39;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.BackgroundImage = global::STLNormalSwitcher.Properties.Resources.yellowDot;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel4.Controls.Add(this.labelA);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(8, 68);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(44, 24);
            this.panel4.TabIndex = 41;
            // 
            // labelA
            // 
            this.labelA.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelA.AutoSize = true;
            this.labelA.BackColor = System.Drawing.Color.Transparent;
            this.labelA.Location = new System.Drawing.Point(13, 6);
            this.labelA.Name = "labelA";
            this.labelA.Size = new System.Drawing.Size(17, 13);
            this.labelA.TabIndex = 0;
            this.labelA.Text = "A:";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.BackgroundImage = global::STLNormalSwitcher.Properties.Resources.greenDot;
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel5.Controls.Add(this.labelB);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(8, 98);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(44, 24);
            this.panel5.TabIndex = 42;
            // 
            // labelB
            // 
            this.labelB.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelB.AutoSize = true;
            this.labelB.BackColor = System.Drawing.Color.Transparent;
            this.labelB.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelB.Location = new System.Drawing.Point(13, 6);
            this.labelB.Name = "labelB";
            this.labelB.Size = new System.Drawing.Size(17, 13);
            this.labelB.TabIndex = 1;
            this.labelB.Text = "B:";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.BackgroundImage = global::STLNormalSwitcher.Properties.Resources.blueDot;
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel6.Controls.Add(this.labelC);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(8, 128);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(44, 24);
            this.panel6.TabIndex = 43;
            // 
            // labelC
            // 
            this.labelC.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelC.AutoSize = true;
            this.labelC.BackColor = System.Drawing.Color.Transparent;
            this.labelC.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelC.Location = new System.Drawing.Point(13, 6);
            this.labelC.Name = "labelC";
            this.labelC.Size = new System.Drawing.Size(17, 13);
            this.labelC.TabIndex = 2;
            this.labelC.Text = "C:";
            // 
            // AddPanel
            // 
            this.Controls.Add(this.tableLayoutPanel4);
            this.Name = "AddPanel";
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes the panel and sets the owner.
        /// </summary>
        /// <param name="owner">The NormalSwitcherForm that contains this AddPanel</param>
        internal AddPanel(NormalSwitcherForm owner) {
            InitializeComponent();
            this.owner = owner;
        }

        #endregion

        #region Methods

        /// <summary>
        /// The main method of all TabPanels. Updates the elements on the panel.
        /// </summary>
        internal override void UpdateTab() {
            owner.Visualization.Fresh = false;

            if ((owner.CurrentSelection.Count == 1) && (owner.CurrentSelection[0] != null)) {
                owner.Visualization.Corners = true;
            } else {
                owner.Visualization.Corners = false;
            }

            BeginUpdate();
            aX.Text = aY.Text = aZ.Text = bX.Text = bY.Text = bZ.Text = cX.Text = cY.Text = cZ.Text =
                    normalX.Text = normalY.Text = normalZ.Text = "";

            if (changed) {
                FillTriangleComboBox();
                verticesA.DataSource = verticesB.DataSource = verticesC.DataSource = null;
                verticesA.DataSource = owner.TriangleList.Vertices;
                verticesB.DataSource = owner.TriangleList.Vertices;
                verticesC.DataSource = owner.TriangleList.Vertices;
                verticesA.DisplayMember = "AsString";
                verticesB.DisplayMember = "AsString";
                verticesC.DisplayMember = "AsString";
                changed = false;
            }

            if (triangleComboBox.Items.Count > 1) {
                triangleCopyButton.Enabled = removeButton.Enabled =
                    copyA.Enabled = copyB.Enabled = copyC.Enabled = true;
            } else {
                triangleCopyButton.Enabled = removeButton.Enabled =
                    copyA.Enabled = copyB.Enabled = copyC.Enabled = false;
            }

            EndUpdate();
            UpdateVerticesBoxes();
        }

        /// <summary>
        /// Updates the vertices boxes, when the selected Triangle is changed.
        /// </summary>
        private void UpdateVerticesBoxes() {
            BeginUpdate();
            Triangle temp;
            if ((owner.CurrentSelection.Count > 0) && (owner.CurrentSelection[0] != null)) {
                temp = owner.CurrentSelection[0];
                triangleComboBox.SelectedIndex = temp.Position + 1;
                owner.CurrentSelection.Clear();
                owner.CurrentSelection.Add(temp);
                owner.Visualization.Corners = true;
                verticesA.SelectedItem = owner.CurrentSelection[0][0];
                verticesB.SelectedItem = owner.CurrentSelection[0][1];
                verticesC.SelectedItem = owner.CurrentSelection[0][2];
                owner.SetCorners();
            } else {
                triangleComboBox.SelectedIndex = 0;
                owner.CurrentSelection.Clear();
                owner.Visualization.Corners = false;
            }
            EndUpdate();

            A_Changed(new object(), new EventArgs());
            B_Changed(new object(), new EventArgs());
            C_Changed(new object(), new EventArgs());

            owner.RefreshVisualization();
        }

        /// <summary>
        /// Fills the triangleComboBox with the value "None" and the strings of all triangles.
        /// </summary>
        private void FillTriangleComboBox() {
            triangleComboBox.Items.Clear();
            triangleComboBox.Items.Add("None");
            for (int i = 0; i < owner.TriangleList.Count; i++) {
                triangleComboBox.Items.Add(owner.TriangleList[i].ToString());
            }
        }

        /// <summary>
        /// Unbinds the TextChanged EventHandlers.
        /// </summary>
        private void BeginUpdate() {
            triangleComboBox.SelectedIndexChanged -= TriangleComboBox_SelectedIndexChanged;
            aX.TextChanged -= A_Changed;
            aY.TextChanged -= A_Changed;
            aZ.TextChanged -= A_Changed;
            bX.TextChanged -= B_Changed;
            bY.TextChanged -= B_Changed;
            bZ.TextChanged -= B_Changed;
            cX.TextChanged -= C_Changed;
            cY.TextChanged -= C_Changed;
            cZ.TextChanged -= C_Changed;
        }

        /// <summary>
        /// Binds the TextChanged EventHandlers again.
        /// </summary>
        private void EndUpdate() {
            triangleComboBox.SelectedIndexChanged += TriangleComboBox_SelectedIndexChanged;
            aX.TextChanged += A_Changed;
            aY.TextChanged += A_Changed;
            aZ.TextChanged += A_Changed;
            bX.TextChanged += B_Changed;
            bY.TextChanged += B_Changed;
            bZ.TextChanged += B_Changed;
            cX.TextChanged += C_Changed;
            cY.TextChanged += C_Changed;
            cZ.TextChanged += C_Changed;

            A_Changed(new object(), new EventArgs());
            B_Changed(new object(), new EventArgs());
            C_Changed(new object(), new EventArgs());
        }

        #endregion

        #region Event Handling Stuff

        /// <summary>
        /// Copies the values of the selected Triangle to the TextBoxes
        /// on the "Add/Remove Triangle"-Tab.
        /// </summary>
        /// <param name="sender">triangleCopyButton</param>
        /// <param name="e">Standard EventArgs</param>
        private void TriangleCopyButton_Click(object sender, EventArgs e) {
            if (triangleComboBox.SelectedIndex != 0) {
                int temp = triangleComboBox.SelectedIndex - 1;
                aX.Text = (owner.TriangleList[temp])[0][0].ToString();
                aY.Text = (owner.TriangleList[temp])[0][1].ToString();
                aZ.Text = (owner.TriangleList[temp])[0][2].ToString();
                bX.Text = (owner.TriangleList[temp])[1][0].ToString();
                bY.Text = (owner.TriangleList[temp])[1][1].ToString();
                bZ.Text = (owner.TriangleList[temp])[1][2].ToString();
                cX.Text = (owner.TriangleList[temp])[2][0].ToString();
                cY.Text = (owner.TriangleList[temp])[2][1].ToString();
                cZ.Text = (owner.TriangleList[temp])[2][2].ToString();
                normalX.Text = (owner.TriangleList[temp])[3][0].ToString();
                normalY.Text = (owner.TriangleList[temp])[3][1].ToString();
                normalZ.Text = (owner.TriangleList[temp])[3][2].ToString();
            }
        }

        /// <summary>
        /// Marks the Triangle selected in the triangleComboBox in the visualization
        /// and selects the corresponding Vertices in the vertices-ComboBoxes.
        /// </summary>
        /// <param name="sender">triangleComboBox</param>
        /// <param name="e">Standard EventArgs</param>
        private void TriangleComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            owner.CurrentSelection.Clear();
            if (triangleComboBox.SelectedIndex != 0) {
                owner.CurrentSelection.Add(owner.TriangleList[triangleComboBox.SelectedIndex - 1]);
            }
            UpdateVerticesBoxes();
        }

        /// <summary>
        /// Add the new Triangle to the triangleList, with the normal vector calculated by the CalculateNormal() method.
        /// </summary>
        /// <param name="sender">addTriangleButton</param>
        /// <param name="e">Standard EventArgs</param>
        private void AddTriangleButton_Click(object sender, EventArgs e) {
            try {
                Vertex a = new Vertex((float)Convert.ToDouble(aX.Text), (float)Convert.ToDouble(aY.Text), (float)Convert.ToDouble(aZ.Text));
                Vertex b = new Vertex((float)Convert.ToDouble(bX.Text), (float)Convert.ToDouble(bY.Text), (float)Convert.ToDouble(bZ.Text));
                Vertex c = new Vertex((float)Convert.ToDouble(cX.Text), (float)Convert.ToDouble(cY.Text), (float)Convert.ToDouble(cZ.Text));
                Triangle tri = new Triangle(a, b, c);
                owner.TriangleList.AddTriangle(tri);
                owner.TriangleList.Finish();
                Event temp = new Event(tri.Copy(), Event.EventType.Add);
                owner.History.Add(temp);

                owner.SetUndoButton(true);
                owner.SetOrigin();
                owner.Visualization.SetPickingColors();
                owner.SetPanelsChanged();
                UpdateTab();
            } catch (ArgumentException ex) {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch {
                MessageBox.Show("Make sure all values are floating point numbers!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Add the new Triangle to the triangleList, with the given normal vector.
        /// </summary>
        /// <param name="sender">addButton</param>
        /// <param name="e">Standard EventArgs</param>
        private void AddButton_Click(object sender, EventArgs e) {
            try {
                Vertex a = new Vertex((float)Convert.ToDouble(aX.Text), (float)Convert.ToDouble(aY.Text), (float)Convert.ToDouble(aZ.Text));
                Vertex b = new Vertex((float)Convert.ToDouble(bX.Text), (float)Convert.ToDouble(bY.Text), (float)Convert.ToDouble(bZ.Text));
                Vertex c = new Vertex((float)Convert.ToDouble(cX.Text), (float)Convert.ToDouble(cY.Text), (float)Convert.ToDouble(cZ.Text));
                Vertex n = new Vertex((float)Convert.ToDouble(normalX.Text), (float)Convert.ToDouble(normalY.Text), (float)Convert.ToDouble(normalZ.Text));
                Triangle tri = new Triangle(a, b, c, n);
                owner.TriangleList.AddTriangle(tri);
                owner.TriangleList.Finish();
                Event temp = new Event(tri.Copy(), Event.EventType.Add);
                owner.History.Add(temp);

                owner.SetUndoButton(true);
                owner.SetOrigin();
                owner.Visualization.SetPickingColors();
                owner.SetPanelsChanged();
                UpdateTab();
            } catch (ArgumentException ex) {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch {
                MessageBox.Show("Make sure all values are floating point numbers!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Removes the selected Triangle from the triangleList.
        /// </summary>
        /// <param name="sender">removeButton</param>
        /// <param name="e">Standard EventArgs</param>
        private void RemoveButton_Click(object sender, EventArgs e) {
            if (triangleComboBox.SelectedIndex != 0) {
                owner.Visualization.Fresh = false;
                Event temp = new Event(owner.TriangleList[triangleComboBox.SelectedIndex - 1].Copy(), Event.EventType.Remove);
                owner.History.Add(temp);
                BeginUpdate();
                if (temp[0].Position > 0) {
                    triangleComboBox.SelectedIndex = temp[0].Position - 1;
                } else if (temp[0].Position == 0) {
                    triangleComboBox.SelectedIndex = 0;
                }
                EndUpdate();

                owner.CurrentSelection.Clear();
                owner.TriangleList.RemoveAt(temp[0].Position);
                owner.TriangleList.SetPositions();

                owner.SetUndoButton(true);
                owner.SetOrigin();
                owner.Visualization.SetPickingColors();
                owner.SetPanelsChanged();
                UpdateTab();
            }
        }

        /// <summary>
        /// Adjusts the values of the A-Vertex of the Triangle on the
        /// "Add/Remove Triangle"-Tab to the Vertex in the verticesA ComboBox.
        /// </summary>
        /// <param name="sender">aVertexHook</param>
        /// <param name="e">Standard EventArgs</param>
        private void CopyA_Click(object sender, EventArgs e) {
            aX.Text = (verticesA.SelectedItem as Vertex)[0].ToString();
            aY.Text = (verticesA.SelectedItem as Vertex)[1].ToString();
            aZ.Text = (verticesA.SelectedItem as Vertex)[2].ToString();
        }

        /// <summary>
        /// Adjusts the values of the B-Vertex of the Triangle on the
        /// "Add/Remove Triangle"-Tab to the Vertex in the verticesB ComboBox.
        /// </summary>
        /// <param name="sender">bVertexHook</param>
        /// <param name="e">Standard EventArgs</param>
        private void CopyB_Click(object sender, EventArgs e) {
            bX.Text = (verticesB.SelectedItem as Vertex)[0].ToString();
            bY.Text = (verticesB.SelectedItem as Vertex)[1].ToString();
            bZ.Text = (verticesB.SelectedItem as Vertex)[2].ToString();
        }

        /// <summary>
        /// Adjusts the values of the C-Vertex of the Triangle on the
        /// "Add/Remove Triangle"-Tab to the Vertex in the verticesC ComboBox.
        /// </summary>
        /// <param name="sender">cVertexHook</param>
        /// <param name="e">Standard EventArgs</param>
        private void CopyC_Click(object sender, EventArgs e) {
            cX.Text = (verticesC.SelectedItem as Vertex)[0].ToString();
            cY.Text = (verticesC.SelectedItem as Vertex)[1].ToString();
            cZ.Text = (verticesC.SelectedItem as Vertex)[2].ToString();
        }

        /// <summary>
        /// Prevents the user from entering anything, but a floating point number in the TextBoxes for
        /// editing or adding Triangles.
        /// </summary>
        /// <param name="sender">Any one of the TextBoxes for editing or adding Triangles</param>
        /// <param name="e">Standard KeyPressEventArgs</param>
        private void TriangleValue_KeyPress(object sender, KeyPressEventArgs e) {
            if ((!char.IsNumber(e.KeyChar)) & (e.KeyChar != '.') & (e.KeyChar != '-') & (e.KeyChar != (char)Keys.Back)) {
                e.Handled = true;
            } else if ((sender as TextBox).SelectedText == (sender as TextBox).Text) {
                (sender as TextBox).Text = "";
            } else if (e.KeyChar == '.') {
                if (((sender as TextBox).Text.Contains(".")) && (!(sender as TextBox).SelectedText.Contains("."))) {
                    e.Handled = true;
                }
            } else if (e.KeyChar == '-') {
                if (((sender as TextBox).Text.StartsWith("-")) && (!(sender as TextBox).SelectedText.Contains("-"))) {
                    e.Handled = true;
                } else if ((sender as TextBox).SelectedText.Contains("-")) {
                    return;
                } else {
                    int temp = (sender as TextBox).SelectionStart;
                    (sender as TextBox).Text = "-" + (sender as TextBox).Text;
                    (sender as TextBox).SelectionStart = temp + 1;
                    e.Handled = true;
                }
            }
        }

        /// <summary>
        /// Updates owner.TriVertices, when the text in one of the TextBoxes of vertex a is changed.
        /// </summary>
        /// <param name="sender">aX, aY or aZ</param>
        /// <param name="e">Standard EventArgs</param>
        private void A_Changed(object sender, EventArgs e) {
            try {
                owner.TriVertices[0] = (float)Convert.ToDouble(aX.Text);
                owner.TriVertices[1] = (float)Convert.ToDouble(aY.Text);
                owner.TriVertices[2] = (float)Convert.ToDouble(aZ.Text);
                owner.Visualization.Vertices[0] = true;
            } catch { owner.Visualization.Vertices[0] = false; } finally { owner.Visualization.Refresh(); }
        }

        /// <summary>
        /// Updates owner.TriVertices, when the text in one of the TextBoxes of vertex b is changed.
        /// </summary>
        /// <param name="sender">bX, bY or bZ</param>
        /// <param name="e">Standard EventArgs</param>
        private void B_Changed(object sender, EventArgs e) {
            try {
                owner.TriVertices[3] = (float)Convert.ToDouble(bX.Text);
                owner.TriVertices[4] = (float)Convert.ToDouble(bY.Text);
                owner.TriVertices[5] = (float)Convert.ToDouble(bZ.Text);
                owner.Visualization.Vertices[1] = true;
            } catch { owner.Visualization.Vertices[1] = false; } finally { owner.Visualization.Refresh(); }
        }

        /// <summary>
        /// Updates owner.TriVertices, when the text in one of the TextBoxes of vertex c is changed.
        /// </summary>
        /// <param name="sender">cX, cY or cZ</param>
        /// <param name="e">Standard EventArgs</param>
        private void C_Changed(object sender, EventArgs e) {
            try {
                owner.TriVertices[6] = (float)Convert.ToDouble(cX.Text);
                owner.TriVertices[7] = (float)Convert.ToDouble(cY.Text);
                owner.TriVertices[8] = (float)Convert.ToDouble(cZ.Text);
                owner.Visualization.Vertices[2] = true;
            } catch { owner.Visualization.Vertices[2] = false; } finally { owner.Visualization.Refresh(); }
        }

        #endregion
    }
}