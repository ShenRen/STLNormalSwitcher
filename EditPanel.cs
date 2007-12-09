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

namespace STLNormalSwitcher {
    /// <summary>
    /// The TabPanel for editing Triangles.
    /// </summary>
    internal class EditPanel : TabPanel {

        #region Designer

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox cZ;
        private System.Windows.Forms.TextBox cY;
        private System.Windows.Forms.TextBox cX;
        private System.Windows.Forms.Label labelC;
        private System.Windows.Forms.TextBox bZ;
        private System.Windows.Forms.TextBox bY;
        private System.Windows.Forms.TextBox bX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox aX;
        private System.Windows.Forms.TextBox aY;
        private System.Windows.Forms.TextBox aZ;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelZ;
        private System.Windows.Forms.Label labelA;
        private System.Windows.Forms.TextBox nextNeighborsTextBox;
        private System.Windows.Forms.Button nextNeighborsButton;
        private System.Windows.Forms.Button copyA;
        private System.Windows.Forms.Button copyB;
        private System.Windows.Forms.Button copyC;
        private System.Windows.Forms.TextBox normalZ;
        private System.Windows.Forms.TextBox normalY;
        private System.Windows.Forms.TextBox normalX;
        private System.Windows.Forms.Label labelNormal;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button resetTriangleBoxesButton;
        private System.Windows.Forms.Button acceptTriangleButton;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox aNeighbors;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox bNeighbors;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cNeighbors;

        private void InitializeComponent() {
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.cZ = new System.Windows.Forms.TextBox();
            this.cY = new System.Windows.Forms.TextBox();
            this.cX = new System.Windows.Forms.TextBox();
            this.labelC = new System.Windows.Forms.Label();
            this.bZ = new System.Windows.Forms.TextBox();
            this.bY = new System.Windows.Forms.TextBox();
            this.bX = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.aX = new System.Windows.Forms.TextBox();
            this.aY = new System.Windows.Forms.TextBox();
            this.aZ = new System.Windows.Forms.TextBox();
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.labelZ = new System.Windows.Forms.Label();
            this.labelA = new System.Windows.Forms.Label();
            this.nextNeighborsTextBox = new System.Windows.Forms.TextBox();
            this.nextNeighborsButton = new System.Windows.Forms.Button();
            this.copyA = new System.Windows.Forms.Button();
            this.copyB = new System.Windows.Forms.Button();
            this.copyC = new System.Windows.Forms.Button();
            this.normalZ = new System.Windows.Forms.TextBox();
            this.normalY = new System.Windows.Forms.TextBox();
            this.normalX = new System.Windows.Forms.TextBox();
            this.labelNormal = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.resetTriangleBoxesButton = new System.Windows.Forms.Button();
            this.acceptTriangleButton = new System.Windows.Forms.Button();
            this.acceptButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.aNeighbors = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bNeighbors = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cNeighbors = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel3.ColumnCount = 9;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.cZ, 4, 4);
            this.tableLayoutPanel3.Controls.Add(this.cY, 3, 4);
            this.tableLayoutPanel3.Controls.Add(this.cX, 2, 4);
            this.tableLayoutPanel3.Controls.Add(this.labelC, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.bZ, 4, 3);
            this.tableLayoutPanel3.Controls.Add(this.bY, 3, 3);
            this.tableLayoutPanel3.Controls.Add(this.bX, 2, 3);
            this.tableLayoutPanel3.Controls.Add(this.label3, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.aX, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.aY, 3, 2);
            this.tableLayoutPanel3.Controls.Add(this.aZ, 4, 2);
            this.tableLayoutPanel3.Controls.Add(this.labelX, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.labelY, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.labelZ, 4, 1);
            this.tableLayoutPanel3.Controls.Add(this.labelA, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.nextNeighborsTextBox, 6, 1);
            this.tableLayoutPanel3.Controls.Add(this.nextNeighborsButton, 7, 1);
            this.tableLayoutPanel3.Controls.Add(this.copyA, 8, 2);
            this.tableLayoutPanel3.Controls.Add(this.copyB, 8, 3);
            this.tableLayoutPanel3.Controls.Add(this.copyC, 8, 4);
            this.tableLayoutPanel3.Controls.Add(this.normalZ, 4, 6);
            this.tableLayoutPanel3.Controls.Add(this.normalY, 3, 6);
            this.tableLayoutPanel3.Controls.Add(this.normalX, 2, 6);
            this.tableLayoutPanel3.Controls.Add(this.labelNormal, 1, 6);
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel1, 5, 7);
            this.tableLayoutPanel3.Controls.Add(this.panel1, 6, 2);
            this.tableLayoutPanel3.Controls.Add(this.panel2, 6, 3);
            this.tableLayoutPanel3.Controls.Add(this.panel3, 6, 4);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.MinimumSize = new System.Drawing.Size(608, 208);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 8;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(739, 222);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // cZ
            // 
            this.cZ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cZ.Enabled = false;
            this.cZ.Location = new System.Drawing.Point(298, 102);
            this.cZ.Name = "cZ";
            this.cZ.Size = new System.Drawing.Size(114, 20);
            this.cZ.TabIndex = 10;
            this.cZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TriangleValue_KeyPress);
            // 
            // cY
            // 
            this.cY.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cY.Enabled = false;
            this.cY.Location = new System.Drawing.Point(178, 102);
            this.cY.Name = "cY";
            this.cY.Size = new System.Drawing.Size(114, 20);
            this.cY.TabIndex = 11;
            this.cY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TriangleValue_KeyPress);
            // 
            // cX
            // 
            this.cX.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cX.Enabled = false;
            this.cX.Location = new System.Drawing.Point(58, 102);
            this.cX.Name = "cX";
            this.cX.Size = new System.Drawing.Size(114, 20);
            this.cX.TabIndex = 9;
            this.cX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TriangleValue_KeyPress);
            // 
            // labelC
            // 
            this.labelC.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelC.AutoSize = true;
            this.labelC.Location = new System.Drawing.Point(21, 112);
            this.labelC.Name = "labelC";
            this.labelC.Size = new System.Drawing.Size(17, 13);
            this.labelC.TabIndex = 2;
            this.labelC.Text = "C:";
            // 
            // bZ
            // 
            this.bZ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bZ.Enabled = false;
            this.bZ.Location = new System.Drawing.Point(298, 72);
            this.bZ.Name = "bZ";
            this.bZ.Size = new System.Drawing.Size(114, 20);
            this.bZ.TabIndex = 8;
            this.bZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TriangleValue_KeyPress);
            // 
            // bY
            // 
            this.bY.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bY.Enabled = false;
            this.bY.Location = new System.Drawing.Point(178, 72);
            this.bY.Name = "bY";
            this.bY.Size = new System.Drawing.Size(114, 20);
            this.bY.TabIndex = 7;
            this.bY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TriangleValue_KeyPress);
            // 
            // bX
            // 
            this.bX.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bX.Enabled = false;
            this.bX.Location = new System.Drawing.Point(58, 72);
            this.bX.Name = "bX";
            this.bX.Size = new System.Drawing.Size(114, 20);
            this.bX.TabIndex = 6;
            this.bX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TriangleValue_KeyPress);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "B:";
            // 
            // aX
            // 
            this.aX.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.aX.Enabled = false;
            this.aX.Location = new System.Drawing.Point(58, 42);
            this.aX.Name = "aX";
            this.aX.Size = new System.Drawing.Size(114, 20);
            this.aX.TabIndex = 3;
            this.aX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TriangleValue_KeyPress);
            // 
            // aY
            // 
            this.aY.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.aY.Enabled = false;
            this.aY.Location = new System.Drawing.Point(178, 42);
            this.aY.Name = "aY";
            this.aY.Size = new System.Drawing.Size(114, 20);
            this.aY.TabIndex = 4;
            this.aY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TriangleValue_KeyPress);
            // 
            // aZ
            // 
            this.aZ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.aZ.Enabled = false;
            this.aZ.Location = new System.Drawing.Point(298, 42);
            this.aZ.Name = "aZ";
            this.aZ.Size = new System.Drawing.Size(114, 20);
            this.aZ.TabIndex = 5;
            this.aZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TriangleValue_KeyPress);
            // 
            // labelX
            // 
            this.labelX.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(108, 22);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(14, 13);
            this.labelX.TabIndex = 12;
            this.labelX.Text = "X";
            // 
            // labelY
            // 
            this.labelY.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(226, 22);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(17, 13);
            this.labelY.TabIndex = 13;
            this.labelY.Text = " Y";
            // 
            // labelZ
            // 
            this.labelZ.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelZ.AutoSize = true;
            this.labelZ.Location = new System.Drawing.Point(348, 22);
            this.labelZ.Name = "labelZ";
            this.labelZ.Size = new System.Drawing.Size(14, 13);
            this.labelZ.TabIndex = 14;
            this.labelZ.Text = "Z";
            // 
            // labelA
            // 
            this.labelA.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelA.AutoSize = true;
            this.labelA.Location = new System.Drawing.Point(21, 52);
            this.labelA.Name = "labelA";
            this.labelA.Size = new System.Drawing.Size(17, 13);
            this.labelA.TabIndex = 0;
            this.labelA.Text = "A:";
            // 
            // nextNeighborsTextBox
            // 
            this.nextNeighborsTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.nextNeighborsTextBox.Enabled = false;
            this.nextNeighborsTextBox.Location = new System.Drawing.Point(438, 12);
            this.nextNeighborsTextBox.Name = "nextNeighborsTextBox";
            this.nextNeighborsTextBox.Size = new System.Drawing.Size(64, 20);
            this.nextNeighborsTextBox.TabIndex = 21;
            this.nextNeighborsTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NextNeighborsTextBox_KeyPress);
            // 
            // nextNeighborsButton
            // 
            this.nextNeighborsButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.nextNeighborsButton.Enabled = false;
            this.nextNeighborsButton.Location = new System.Drawing.Point(508, 9);
            this.nextNeighborsButton.Name = "nextNeighborsButton";
            this.nextNeighborsButton.Size = new System.Drawing.Size(174, 23);
            this.nextNeighborsButton.TabIndex = 22;
            this.nextNeighborsButton.Text = "Next Neighbors:";
            this.nextNeighborsButton.UseVisualStyleBackColor = true;
            this.nextNeighborsButton.Click += new System.EventHandler(this.NextNeighborsButton_Click);
            // 
            // copyA
            // 
            this.copyA.Dock = System.Windows.Forms.DockStyle.Left;
            this.copyA.Enabled = false;
            this.copyA.Location = new System.Drawing.Point(688, 38);
            this.copyA.Name = "copyA";
            this.copyA.Size = new System.Drawing.Size(42, 24);
            this.copyA.TabIndex = 23;
            this.copyA.Text = "Copy";
            this.copyA.UseVisualStyleBackColor = true;
            this.copyA.Click += new System.EventHandler(this.CopyA_Click);
            // 
            // copyB
            // 
            this.copyB.Dock = System.Windows.Forms.DockStyle.Left;
            this.copyB.Enabled = false;
            this.copyB.Location = new System.Drawing.Point(688, 68);
            this.copyB.Name = "copyB";
            this.copyB.Size = new System.Drawing.Size(42, 24);
            this.copyB.TabIndex = 24;
            this.copyB.Text = "Copy";
            this.copyB.UseVisualStyleBackColor = true;
            this.copyB.Click += new System.EventHandler(this.CopyB_Click);
            // 
            // copyC
            // 
            this.copyC.Dock = System.Windows.Forms.DockStyle.Left;
            this.copyC.Enabled = false;
            this.copyC.Location = new System.Drawing.Point(688, 98);
            this.copyC.Name = "copyC";
            this.copyC.Size = new System.Drawing.Size(42, 24);
            this.copyC.TabIndex = 25;
            this.copyC.Text = "Copy";
            this.copyC.UseVisualStyleBackColor = true;
            this.copyC.Click += new System.EventHandler(this.CopyC_Click);
            // 
            // normalZ
            // 
            this.normalZ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.normalZ.Enabled = false;
            this.normalZ.Location = new System.Drawing.Point(298, 152);
            this.normalZ.Name = "normalZ";
            this.normalZ.Size = new System.Drawing.Size(114, 20);
            this.normalZ.TabIndex = 29;
            this.normalZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TriangleValue_KeyPress);
            // 
            // normalY
            // 
            this.normalY.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.normalY.Enabled = false;
            this.normalY.Location = new System.Drawing.Point(178, 152);
            this.normalY.Name = "normalY";
            this.normalY.Size = new System.Drawing.Size(114, 20);
            this.normalY.TabIndex = 30;
            this.normalY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TriangleValue_KeyPress);
            // 
            // normalX
            // 
            this.normalX.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.normalX.Enabled = false;
            this.normalX.Location = new System.Drawing.Point(58, 152);
            this.normalX.Name = "normalX";
            this.normalX.Size = new System.Drawing.Size(114, 20);
            this.normalX.TabIndex = 31;
            this.normalX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TriangleValue_KeyPress);
            // 
            // labelNormal
            // 
            this.labelNormal.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelNormal.AutoSize = true;
            this.labelNormal.Location = new System.Drawing.Point(8, 162);
            this.labelNormal.Name = "labelNormal";
            this.labelNormal.Size = new System.Drawing.Size(43, 13);
            this.labelNormal.TabIndex = 32;
            this.labelNormal.Text = "Normal:";
            // 
            // flowLayoutPanel1
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.flowLayoutPanel1, 4);
            this.flowLayoutPanel1.Controls.Add(this.resetTriangleBoxesButton);
            this.flowLayoutPanel1.Controls.Add(this.acceptTriangleButton);
            this.flowLayoutPanel1.Controls.Add(this.acceptButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(418, 178);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(318, 41);
            this.flowLayoutPanel1.TabIndex = 33;
            // 
            // resetTriangleBoxesButton
            // 
            this.resetTriangleBoxesButton.Enabled = false;
            this.resetTriangleBoxesButton.Location = new System.Drawing.Point(3, 3);
            this.resetTriangleBoxesButton.Name = "resetTriangleBoxesButton";
            this.resetTriangleBoxesButton.Size = new System.Drawing.Size(44, 30);
            this.resetTriangleBoxesButton.TabIndex = 34;
            this.resetTriangleBoxesButton.Text = "Reset";
            this.resetTriangleBoxesButton.UseVisualStyleBackColor = true;
            this.resetTriangleBoxesButton.Click += new System.EventHandler(this.ResetTriangleBoxesButton_Click);
            // 
            // acceptTriangleButton
            // 
            this.acceptTriangleButton.Enabled = false;
            this.acceptTriangleButton.Location = new System.Drawing.Point(53, 3);
            this.acceptTriangleButton.Name = "acceptTriangleButton";
            this.acceptTriangleButton.Size = new System.Drawing.Size(94, 30);
            this.acceptTriangleButton.TabIndex = 20;
            this.acceptTriangleButton.Text = "Accept Triangle";
            this.acceptTriangleButton.UseVisualStyleBackColor = true;
            this.acceptTriangleButton.Click += new System.EventHandler(this.AcceptTriangleButton_Click);
            // 
            // acceptButton
            // 
            this.acceptButton.Enabled = false;
            this.acceptButton.Location = new System.Drawing.Point(153, 3);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(155, 30);
            this.acceptButton.TabIndex = 21;
            this.acceptButton.Text = "Accept Triangle and Normal";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Yellow;
            this.tableLayoutPanel3.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.aNeighbors);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(438, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(244, 24);
            this.panel1.TabIndex = 34;
            // 
            // aNeighbors
            // 
            this.aNeighbors.BackColor = System.Drawing.SystemColors.Window;
            this.aNeighbors.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.aNeighbors.Enabled = false;
            this.aNeighbors.FormattingEnabled = true;
            this.aNeighbors.Location = new System.Drawing.Point(0, 3);
            this.aNeighbors.Name = "aNeighbors";
            this.aNeighbors.Size = new System.Drawing.Size(244, 21);
            this.aNeighbors.TabIndex = 26;
            this.aNeighbors.SelectedIndexChanged += new System.EventHandler(this.Neighbors_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Green;
            this.tableLayoutPanel3.SetColumnSpan(this.panel2, 2);
            this.panel2.Controls.Add(this.bNeighbors);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(438, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(244, 24);
            this.panel2.TabIndex = 35;
            // 
            // bNeighbors
            // 
            this.bNeighbors.BackColor = System.Drawing.SystemColors.Window;
            this.bNeighbors.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bNeighbors.Enabled = false;
            this.bNeighbors.FormattingEnabled = true;
            this.bNeighbors.Location = new System.Drawing.Point(0, 3);
            this.bNeighbors.Name = "bNeighbors";
            this.bNeighbors.Size = new System.Drawing.Size(244, 21);
            this.bNeighbors.TabIndex = 27;
            this.bNeighbors.SelectedIndexChanged += new System.EventHandler(this.Neighbors_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Blue;
            this.tableLayoutPanel3.SetColumnSpan(this.panel3, 2);
            this.panel3.Controls.Add(this.cNeighbors);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(438, 98);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(244, 24);
            this.panel3.TabIndex = 36;
            // 
            // cNeighbors
            // 
            this.cNeighbors.BackColor = System.Drawing.SystemColors.Window;
            this.cNeighbors.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cNeighbors.Enabled = false;
            this.cNeighbors.FormattingEnabled = true;
            this.cNeighbors.Location = new System.Drawing.Point(0, 3);
            this.cNeighbors.Name = "cNeighbors";
            this.cNeighbors.Size = new System.Drawing.Size(244, 21);
            this.cNeighbors.TabIndex = 28;
            this.cNeighbors.SelectedIndexChanged += new System.EventHandler(this.Neighbors_SelectedIndexChanged);
            // 
            // EditPanel
            // 
            this.Controls.Add(this.tableLayoutPanel3);
            this.Name = "EditPanel";
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        #region Fields

        private List<Vertex> neighborsOfA = new List<Vertex>();
        private List<Vertex> neighborsOfB = new List<Vertex>();
        private List<Vertex> neighborsOfC = new List<Vertex>();

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes the panel and sets the owner.
        /// </summary>
        /// <param name="owner">The NormalSwitcherForm that contains this EditPanel</param>
        internal EditPanel(NormalSwitcherForm owner) {
            InitializeComponent();
            this.owner = owner;

            Neighbors_SelectedIndexChanged(new object(), new EventArgs());

            acceptButton.EnabledChanged += new EventHandler(AcceptButton_EnabledChanged);
            copyA.EnabledChanged += new EventHandler(CopyButton_EnabledChanged);
        }

        #endregion

        #region Methods

        /// <summary>
        /// The main method of all TabPanels. Updates the elements on the panel.
        /// </summary>
        /// <param name="flag">Not used for this TabPanel</param>
        internal override void UpdateTab(bool flag) {
            owner.Visualization.Fresh = false;
            owner.Visualization.Vertices = false;

            if ((owner.CurrentSelection.Count == 1) && (owner.CurrentSelection[0] != null)) {
                aX.Text = owner.CurrentSelection[0][0][0].ToString();
                aY.Text = owner.CurrentSelection[0][0][1].ToString();
                aZ.Text = owner.CurrentSelection[0][0][2].ToString();
                bX.Text = owner.CurrentSelection[0][1][0].ToString();
                bY.Text = owner.CurrentSelection[0][1][1].ToString();
                bZ.Text = owner.CurrentSelection[0][1][2].ToString();
                cX.Text = owner.CurrentSelection[0][2][0].ToString();
                cY.Text = owner.CurrentSelection[0][2][1].ToString();
                cZ.Text = owner.CurrentSelection[0][2][2].ToString();
                normalX.Text = owner.CurrentSelection[0][3][0].ToString();
                normalY.Text = owner.CurrentSelection[0][3][1].ToString();
                normalZ.Text = owner.CurrentSelection[0][3][2].ToString();
                acceptButton.Enabled = true;
                owner.Visualization.Corners = true;
                owner.SetCorners();
            } else {
                aX.Text = aY.Text = aZ.Text = bX.Text = bY.Text = bZ.Text = cX.Text = cY.Text = cZ.Text =
                    normalX.Text = normalY.Text = normalZ.Text = "";
                acceptButton.Enabled = copyA.Enabled = owner.Visualization.Corners = false;
            }
            nextNeighborsTextBox.Text = "";
            aNeighbors.DataSource = bNeighbors.DataSource = cNeighbors.DataSource = null;

            owner.RefreshVisualization();
        }

        /// <summary>
        /// Fills the Neighbors ComboBoxes with <paramref name="number"/> neighbors.
        /// </summary>
        /// <param name="number">Number of Neighbors</param>
        private void CalculateNeighbors(int number) {
            aNeighbors.DataSource = bNeighbors.DataSource = cNeighbors.DataSource = null;
            neighborsOfA.Clear();
            neighborsOfB.Clear();
            neighborsOfC.Clear();

            SortedList<string, Vertex> tempA = new SortedList<string, Vertex>();
            SortedList<string, Vertex> tempB = new SortedList<string, Vertex>();
            SortedList<string, Vertex> tempC = new SortedList<string, Vertex>();
            double dist;

            for (int i = 0; i < owner.TriangleList.Vertices.Length; i++) {
                dist = owner.CurrentSelection[0][0].DistanceFrom(owner.TriangleList.Vertices[i]);
                tempA.Add(SwitchersHelpers.GenerateKey(dist, i, owner.TriangleList.Vertices.Length), owner.TriangleList.Vertices[i]);
                dist = owner.CurrentSelection[0][1].DistanceFrom(owner.TriangleList.Vertices[i]);
                tempB.Add(SwitchersHelpers.GenerateKey(dist, i, owner.TriangleList.Vertices.Length), owner.TriangleList.Vertices[i]);
                dist = owner.CurrentSelection[0][2].DistanceFrom(owner.TriangleList.Vertices[i]);
                tempC.Add(SwitchersHelpers.GenerateKey(dist, i, owner.TriangleList.Vertices.Length), owner.TriangleList.Vertices[i]);
            }

            for (int k = 0; k < number; k++) {
                neighborsOfA.Add(tempA[tempA.Keys[k]]);
                neighborsOfB.Add(tempB[tempB.Keys[k]]);
                neighborsOfC.Add(tempC[tempC.Keys[k]]);
            }

            aNeighbors.DataSource = neighborsOfA;
            aNeighbors.DisplayMember = "AsString";
            aNeighbors.SelectedIndex = 0;
            bNeighbors.DataSource = neighborsOfB;
            bNeighbors.DisplayMember = "AsString";
            bNeighbors.SelectedIndex = 0;
            cNeighbors.DataSource = neighborsOfC;
            cNeighbors.DisplayMember = "AsString";
            cNeighbors.SelectedIndex = 0;
            owner.Visualization.Vertices = true;
            copyA.Enabled = true;

            owner.Visualization.Fresh = true;
        }

        #endregion

        #region Event Handling Stuff

        /// <summary>
        /// Initializes the filling of the Neighbors ComboBoxes.
        /// </summary>
        /// <param name="sender">nextNeighborsButton</param>
        /// <param name="e">Standard EventArgs</param>
        private void NextNeighborsButton_Click(object sender, EventArgs e) {
            try {
                int number = Convert.ToInt32(nextNeighborsTextBox.Text);
                if (number >= 1) {
                    if (number >= owner.TriangleList.Vertices.Length) {
                        number = owner.TriangleList.Vertices.Length;
                        nextNeighborsTextBox.Text = number.ToString();
                    }
                    CalculateNeighbors(number);
                } else { MessageBox.Show("You need to enter an Integer greater than 0!"); }
            } catch {
                MessageBox.Show("You need to enter an Integer greater than 0!");
            }
        }

        /// <summary>
        /// Fills the Neighbors ComboBoxes, when the Return-Key is pressed in the nextNeighborsTextBox.
        /// Prevents the user from entering anything, but numbers.
        /// </summary>
        /// <param name="sender">nextNeighborsTextBox</param>
        /// <param name="e">Standard KeyPressEventArgs</param>
        private void NextNeighborsTextBox_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Return) {
                NextNeighborsButton_Click(sender, e);
            }
            if ((!char.IsNumber(e.KeyChar)) & (e.KeyChar != (char)Keys.Back)) {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Adjusts the values of the A-Vertex of the Triangle on the
        /// "Edit Selected Triangle"-Tab to the Vertex in the aNeighbors ComboBox.
        /// </summary>
        /// <param name="sender">hookButtonA</param>
        /// <param name="e">Standard EventArgs</param>
        private void CopyA_Click(object sender, EventArgs e) {
            aX.Text = (aNeighbors.SelectedItem as Vertex)[0].ToString();
            aY.Text = (aNeighbors.SelectedItem as Vertex)[1].ToString();
            aZ.Text = (aNeighbors.SelectedItem as Vertex)[2].ToString();
        }

        /// <summary>
        /// Adjusts the values of the B-Vertex of the Triangle on the
        /// "Edit Selected Triangle"-Tab to the Vertex in the bNeighbors ComboBox.
        /// </summary>
        /// <param name="sender">hookButtonB</param>
        /// <param name="e">Standard EventArgs</param>
        private void CopyB_Click(object sender, EventArgs e) {
            bX.Text = (bNeighbors.SelectedItem as Vertex)[0].ToString();
            bY.Text = (bNeighbors.SelectedItem as Vertex)[1].ToString();
            bZ.Text = (bNeighbors.SelectedItem as Vertex)[2].ToString();
        }

        /// <summary>
        /// Adjusts the values of the C-Vertex of the Triangle on the
        /// "Edit Selected Triangle"-Tab to the Vertex in the cNeighbors ComboBox.
        /// </summary>
        /// <param name="sender">hookButtonC</param>
        /// <param name="e">Standard EventArgs</param>
        private void CopyC_Click(object sender, EventArgs e) {
            cX.Text = (cNeighbors.SelectedItem as Vertex)[0].ToString();
            cY.Text = (cNeighbors.SelectedItem as Vertex)[1].ToString();
            cZ.Text = (cNeighbors.SelectedItem as Vertex)[2].ToString();
        }

        /// <summary>
        /// Resets the boxes on the "Edit Selected Triangle"-Tab.
        /// </summary>
        /// <param name="sender">resetTriangleBoxesButton</param>
        /// <param name="e">Standard EventArgs</param>
        private void ResetTriangleBoxesButton_Click(object sender, EventArgs e) {
            UpdateTab(true);
        }

        /// <summary>
        /// Makes the changes to the selected Triangle.
        /// </summary>
        /// <param name="sender">acceptTriangleButton</param>
        /// <param name="e">Standard EventArgs</param>
        private void AcceptTriangleButton_Click(object sender, EventArgs e) {
            try {
                Vertex a = new Vertex((float)Convert.ToDouble(aX.Text), (float)Convert.ToDouble(aY.Text), (float)Convert.ToDouble(aZ.Text));
                Vertex b = new Vertex((float)Convert.ToDouble(bX.Text), (float)Convert.ToDouble(bY.Text), (float)Convert.ToDouble(bZ.Text));
                Vertex c = new Vertex((float)Convert.ToDouble(cX.Text), (float)Convert.ToDouble(cY.Text), (float)Convert.ToDouble(cZ.Text));
                Triangle tri = new Triangle(a, b, c);
                tri.Position = owner.CurrentSelection[0].Position;
                Event temp = new Event(owner.CurrentSelection[0], Event.EventType.Edit);
                owner.History.Add(temp);
                owner.TriangleList.EditTriangle(tri);

                owner.CurrentSelection.Clear();
                owner.CurrentSelection.Add(tri);
                owner.SetUndoButton(true);
                owner.SetOrigin();
                UpdateTab(true);
                owner.Flag = true;
            } catch (ArgumentException ex) {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch {
                MessageBox.Show("Make sure all values are floating point numbers!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Makes the changes to the selected Triangle and the normal vector.
        /// </summary>
        /// <param name="sender">acceptButton</param>
        /// <param name="e">Standard EventArgs</param>
        private void AcceptButton_Click(object sender, EventArgs e) {
            try {
                Vertex a = new Vertex((float)Convert.ToDouble(aX.Text), (float)Convert.ToDouble(aY.Text), (float)Convert.ToDouble(aZ.Text));
                Vertex b = new Vertex((float)Convert.ToDouble(bX.Text), (float)Convert.ToDouble(bY.Text), (float)Convert.ToDouble(bZ.Text));
                Vertex c = new Vertex((float)Convert.ToDouble(cX.Text), (float)Convert.ToDouble(cY.Text), (float)Convert.ToDouble(cZ.Text));
                Vertex n = new Vertex((float)Convert.ToDouble(normalX.Text), (float)Convert.ToDouble(normalY.Text), (float)Convert.ToDouble(normalZ.Text));
                Triangle tri = new Triangle(a, b, c, n);
                tri.Position = owner.CurrentSelection[0].Position;
                Event temp = new Event(owner.CurrentSelection[0], Event.EventType.Edit);
                owner.History.Add(temp);
                owner.TriangleList.EditTriangle(tri);

                owner.CurrentSelection.Clear();
                owner.CurrentSelection.Add(tri);
                owner.SetUndoButton(true);
                owner.SetOrigin();
                UpdateTab(true);
                owner.Flag = true;
            } catch (ArgumentException ex) {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch {
                MessageBox.Show("Make sure all values are floating point numbers!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Enables or disables the Hook-Buttons simultaneously.
        /// </summary>
        /// <param name="sender">hookButtonA</param>
        /// <param name="e">Standard EventArgs</param>
        private void CopyButton_EnabledChanged(object sender, EventArgs e) {
            copyB.Enabled = copyC.Enabled = copyA.Enabled;
        }

        /// <summary>
        /// Enables the acceptButton, the acceptTriangleButton, the resetTriangleBoxesButton
        /// and the nextNeighborsButton simultaneously.
        /// </summary>
        /// <param name="sender">acceptButton</param>
        /// <param name="e">Standard EventArgs</param>
        private void AcceptButton_EnabledChanged(object sender, EventArgs e) {
            acceptTriangleButton.Enabled = nextNeighborsButton.Enabled = resetTriangleBoxesButton.Enabled =
                nextNeighborsTextBox.Enabled = aX.Enabled = aY.Enabled = aZ.Enabled = bX.Enabled = bY.Enabled =
                bZ.Enabled = cX.Enabled = cY.Enabled = cZ.Enabled = normalX.Enabled = normalY.Enabled =
                normalZ.Enabled = aNeighbors.Enabled = bNeighbors.Enabled = cNeighbors.Enabled = acceptButton.Enabled;
        }

        /// <summary>
        /// Marks the neighbor Triangles in the visualization.
        /// </summary>
        /// <param name="sender">aNeighbors or bNeighbors or cNeighbors ComboBox</param>
        /// <param name="e">Standard EventArgs</param>
        private void Neighbors_SelectedIndexChanged(object sender, EventArgs e) {
            if ((aNeighbors.SelectedItem != null) && (bNeighbors.SelectedItem != null) && (cNeighbors.SelectedItem != null)) {
                owner.TriVertices[0] = owner.TriangleList.VertexArray[owner.TriangleList.IndexOf((aNeighbors.SelectedItem as Vertex).Owner) * 9 +
                    (aNeighbors.SelectedItem as Vertex).Owner.IndexOf(aNeighbors.SelectedItem as Vertex) * 3];
                owner.TriVertices[1] = owner.TriangleList.VertexArray[owner.TriangleList.IndexOf((aNeighbors.SelectedItem as Vertex).Owner) * 9 +
                    (aNeighbors.SelectedItem as Vertex).Owner.IndexOf(aNeighbors.SelectedItem as Vertex) * 3 + 1];
                owner.TriVertices[2] = owner.TriangleList.VertexArray[owner.TriangleList.IndexOf((aNeighbors.SelectedItem as Vertex).Owner) * 9 +
                    (aNeighbors.SelectedItem as Vertex).Owner.IndexOf(aNeighbors.SelectedItem as Vertex) * 3 + 2];
                owner.TriVertices[3] = owner.TriangleList.VertexArray[owner.TriangleList.IndexOf((bNeighbors.SelectedItem as Vertex).Owner) * 9 +
                    (bNeighbors.SelectedItem as Vertex).Owner.IndexOf(bNeighbors.SelectedItem as Vertex) * 3];
                owner.TriVertices[4] = owner.TriangleList.VertexArray[owner.TriangleList.IndexOf((bNeighbors.SelectedItem as Vertex).Owner) * 9 +
                    (bNeighbors.SelectedItem as Vertex).Owner.IndexOf(bNeighbors.SelectedItem as Vertex) * 3 + 1];
                owner.TriVertices[5] = owner.TriangleList.VertexArray[owner.TriangleList.IndexOf((bNeighbors.SelectedItem as Vertex).Owner) * 9 +
                    (bNeighbors.SelectedItem as Vertex).Owner.IndexOf(bNeighbors.SelectedItem as Vertex) * 3 + 2];
                owner.TriVertices[6] = owner.TriangleList.VertexArray[owner.TriangleList.IndexOf((cNeighbors.SelectedItem as Vertex).Owner) * 9 +
                    (cNeighbors.SelectedItem as Vertex).Owner.IndexOf(cNeighbors.SelectedItem as Vertex) * 3];
                owner.TriVertices[7] = owner.TriangleList.VertexArray[owner.TriangleList.IndexOf((cNeighbors.SelectedItem as Vertex).Owner) * 9 +
                    (cNeighbors.SelectedItem as Vertex).Owner.IndexOf(cNeighbors.SelectedItem as Vertex) * 3 + 1];
                owner.TriVertices[8] = owner.TriangleList.VertexArray[owner.TriangleList.IndexOf((cNeighbors.SelectedItem as Vertex).Owner) * 9 +
                    (cNeighbors.SelectedItem as Vertex).Owner.IndexOf(cNeighbors.SelectedItem as Vertex) * 3 + 2];

                owner.RefreshVisualization();
            }
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

        #endregion
    }
}