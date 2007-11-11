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
//
// Check out PAVEl (http://pavel.sourceforge.net/) another great program brought to you by PG500.

namespace STLNormalSwitcher {
    partial class NormalSwitcherForm {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Select a File!");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NormalSwitcherForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearUndoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearRedoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearUndoRedoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.switchAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.switchSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.undoButton = new System.Windows.Forms.Button();
            this.rotationOriginTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.selectedButton = new System.Windows.Forms.Button();
            this.allButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.redoButton = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.originTrackBar = new System.Windows.Forms.TrackBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.normalListView = new System.Windows.Forms.ListView();
            this.columnHeader0 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.tabPage2 = new System.Windows.Forms.TabPage();
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
            this.acceptButton = new System.Windows.Forms.Button();
            this.nextNeighborsTextBox = new System.Windows.Forms.TextBox();
            this.nextNeighborsButton = new System.Windows.Forms.Button();
            this.hookButtonA = new System.Windows.Forms.Button();
            this.hookButtonB = new System.Windows.Forms.Button();
            this.hookButtonC = new System.Windows.Forms.Button();
            this.aNeighbors = new System.Windows.Forms.ComboBox();
            this.bNeighbors = new System.Windows.Forms.ComboBox();
            this.cNeighbors = new System.Windows.Forms.ComboBox();
            this.normalZ = new System.Windows.Forms.TextBox();
            this.normalY = new System.Windows.Forms.TextBox();
            this.normalX = new System.Windows.Forms.TextBox();
            this.labelNormal = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.originTrackBar)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.workToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(747, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenFile);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveFile);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As ...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAs);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Enabled = false;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.closeToolStripMenuItem.Text = "&Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseFile);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(136, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.Exit);
            // 
            // workToolStripMenuItem
            // 
            this.workToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.resetToolStripMenuItem,
            this.clearHistoryToolStripMenuItem,
            this.toolStripSeparator2,
            this.switchAllToolStripMenuItem,
            this.switchSelectedToolStripMenuItem});
            this.workToolStripMenuItem.Name = "workToolStripMenuItem";
            this.workToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.workToolStripMenuItem.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Enabled = false;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.undoToolStripMenuItem.Text = "&Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.Undo);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Enabled = false;
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.redoToolStripMenuItem.Text = "Re&do";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.Redo);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Enabled = false;
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.resetToolStripMenuItem.Text = "&Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.Reset);
            // 
            // clearHistoryToolStripMenuItem
            // 
            this.clearHistoryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearUndoToolStripMenuItem,
            this.clearRedoToolStripMenuItem,
            this.clearUndoRedoToolStripMenuItem});
            this.clearHistoryToolStripMenuItem.Enabled = false;
            this.clearHistoryToolStripMenuItem.Name = "clearHistoryToolStripMenuItem";
            this.clearHistoryToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.clearHistoryToolStripMenuItem.Text = "&Clear ...";
            // 
            // clearUndoToolStripMenuItem
            // 
            this.clearUndoToolStripMenuItem.Name = "clearUndoToolStripMenuItem";
            this.clearUndoToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.clearUndoToolStripMenuItem.Text = "... Undo List";
            this.clearUndoToolStripMenuItem.Click += new System.EventHandler(this.ClearUndoToolStripMenuItem_Click);
            // 
            // clearRedoToolStripMenuItem
            // 
            this.clearRedoToolStripMenuItem.Name = "clearRedoToolStripMenuItem";
            this.clearRedoToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.clearRedoToolStripMenuItem.Text = "... Redo List";
            this.clearRedoToolStripMenuItem.Click += new System.EventHandler(this.ClearRedoToolStripMenuItem_Click);
            // 
            // clearUndoRedoToolStripMenuItem
            // 
            this.clearUndoRedoToolStripMenuItem.Name = "clearUndoRedoToolStripMenuItem";
            this.clearUndoRedoToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.clearUndoRedoToolStripMenuItem.Text = "... Undo and Redo List";
            this.clearUndoRedoToolStripMenuItem.Click += new System.EventHandler(this.ClearUndoRedoToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(157, 6);
            // 
            // switchAllToolStripMenuItem
            // 
            this.switchAllToolStripMenuItem.Enabled = false;
            this.switchAllToolStripMenuItem.Name = "switchAllToolStripMenuItem";
            this.switchAllToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.switchAllToolStripMenuItem.Text = "Switch &All";
            this.switchAllToolStripMenuItem.Click += new System.EventHandler(this.SwitchAll);
            // 
            // switchSelectedToolStripMenuItem
            // 
            this.switchSelectedToolStripMenuItem.Enabled = false;
            this.switchSelectedToolStripMenuItem.Name = "switchSelectedToolStripMenuItem";
            this.switchSelectedToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.switchSelectedToolStripMenuItem.Text = "Switch &Selected";
            this.switchSelectedToolStripMenuItem.Click += new System.EventHandler(this.SwitchSelected);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(747, 710);
            this.splitContainer1.SplitterDistance = 458;
            this.splitContainer1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.splitContainer2, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(747, 458);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.undoButton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.rotationOriginTextBox, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.selectedButton, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.allButton, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.resetButton, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.redoButton, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(130, 452);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // undoButton
            // 
            this.undoButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.undoButton.Enabled = false;
            this.undoButton.Location = new System.Drawing.Point(18, 26);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(94, 24);
            this.undoButton.TabIndex = 3;
            this.undoButton.Text = "Undo";
            this.undoButton.UseVisualStyleBackColor = true;
            this.undoButton.Click += new System.EventHandler(this.Undo);
            // 
            // rotationOriginTextBox
            // 
            this.rotationOriginTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rotationOriginTextBox.Enabled = false;
            this.rotationOriginTextBox.Location = new System.Drawing.Point(18, 405);
            this.rotationOriginTextBox.Name = "rotationOriginTextBox";
            this.rotationOriginTextBox.Size = new System.Drawing.Size(94, 20);
            this.rotationOriginTextBox.TabIndex = 5;
            this.rotationOriginTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RotationOriginTextBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(18, 385);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Rotation origin:";
            // 
            // selectedButton
            // 
            this.selectedButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedButton.Enabled = false;
            this.selectedButton.Location = new System.Drawing.Point(18, 331);
            this.selectedButton.Name = "selectedButton";
            this.selectedButton.Size = new System.Drawing.Size(94, 24);
            this.selectedButton.TabIndex = 0;
            this.selectedButton.Text = "Switch Selected";
            this.selectedButton.UseVisualStyleBackColor = true;
            this.selectedButton.Click += new System.EventHandler(this.SwitchSelected);
            // 
            // allButton
            // 
            this.allButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.allButton.Enabled = false;
            this.allButton.Location = new System.Drawing.Point(18, 301);
            this.allButton.Name = "allButton";
            this.allButton.Size = new System.Drawing.Size(94, 24);
            this.allButton.TabIndex = 1;
            this.allButton.Text = "Switch All";
            this.allButton.UseVisualStyleBackColor = true;
            this.allButton.Click += new System.EventHandler(this.SwitchAll);
            // 
            // resetButton
            // 
            this.resetButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resetButton.Enabled = false;
            this.resetButton.Location = new System.Drawing.Point(18, 86);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(94, 24);
            this.resetButton.TabIndex = 2;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.Reset);
            // 
            // redoButton
            // 
            this.redoButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.redoButton.Enabled = false;
            this.redoButton.Location = new System.Drawing.Point(18, 56);
            this.redoButton.Name = "redoButton";
            this.redoButton.Size = new System.Drawing.Size(94, 24);
            this.redoButton.TabIndex = 6;
            this.redoButton.Text = "Redo";
            this.redoButton.UseVisualStyleBackColor = true;
            this.redoButton.Click += new System.EventHandler(this.Redo);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(139, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.originTrackBar);
            this.splitContainer2.Size = new System.Drawing.Size(605, 452);
            this.splitContainer2.SplitterDistance = 41;
            this.splitContainer2.TabIndex = 5;
            // 
            // originTrackBar
            // 
            this.originTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.originTrackBar.Location = new System.Drawing.Point(0, 0);
            this.originTrackBar.Name = "originTrackBar";
            this.originTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.originTrackBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.originTrackBar.Size = new System.Drawing.Size(41, 452);
            this.originTrackBar.TabIndex = 4;
            this.originTrackBar.Visible = false;
            this.originTrackBar.ValueChanged += new System.EventHandler(this.OriginTrackBar_ValueChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.MinimumSize = new System.Drawing.Size(622, 240);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(747, 248);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.normalListView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(754, 310);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "List of Normal Vectors and Triangles";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // normalListView
            // 
            this.normalListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader0,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.normalListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.normalListView.FullRowSelect = true;
            this.normalListView.GridLines = true;
            this.normalListView.HideSelection = false;
            listViewItem1.Tag = "-2";
            this.normalListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.normalListView.Location = new System.Drawing.Point(3, 3);
            this.normalListView.Name = "normalListView";
            this.normalListView.ShowGroups = false;
            this.normalListView.Size = new System.Drawing.Size(748, 304);
            this.normalListView.TabIndex = 2;
            this.normalListView.UseCompatibleStateImageBehavior = false;
            this.normalListView.View = System.Windows.Forms.View.Details;
            this.normalListView.SelectedIndexChanged += new System.EventHandler(this.NormalListView_SelectedIndexChanged);
            this.normalListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.NormalListView_ColumnClick);
            // 
            // columnHeader0
            // 
            this.columnHeader0.Text = "Normal Vector";
            this.columnHeader0.Width = 200;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Vertex A";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Vertex B";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Vertex C";
            this.columnHeader3.Width = 200;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.tableLayoutPanel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(739, 222);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Edit the First Selected Triangle";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            this.tableLayoutPanel3.Controls.Add(this.acceptButton, 7, 7);
            this.tableLayoutPanel3.Controls.Add(this.nextNeighborsTextBox, 6, 1);
            this.tableLayoutPanel3.Controls.Add(this.nextNeighborsButton, 7, 1);
            this.tableLayoutPanel3.Controls.Add(this.hookButtonA, 8, 2);
            this.tableLayoutPanel3.Controls.Add(this.hookButtonB, 8, 3);
            this.tableLayoutPanel3.Controls.Add(this.hookButtonC, 8, 4);
            this.tableLayoutPanel3.Controls.Add(this.aNeighbors, 6, 2);
            this.tableLayoutPanel3.Controls.Add(this.bNeighbors, 6, 3);
            this.tableLayoutPanel3.Controls.Add(this.cNeighbors, 6, 4);
            this.tableLayoutPanel3.Controls.Add(this.normalZ, 4, 6);
            this.tableLayoutPanel3.Controls.Add(this.normalY, 3, 6);
            this.tableLayoutPanel3.Controls.Add(this.normalX, 2, 6);
            this.tableLayoutPanel3.Controls.Add(this.labelNormal, 1, 6);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
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
            this.tableLayoutPanel3.Size = new System.Drawing.Size(733, 216);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // cZ
            // 
            this.cZ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cZ.Location = new System.Drawing.Point(298, 102);
            this.cZ.Name = "cZ";
            this.cZ.Size = new System.Drawing.Size(114, 20);
            this.cZ.TabIndex = 10;
            // 
            // cY
            // 
            this.cY.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cY.Location = new System.Drawing.Point(178, 102);
            this.cY.Name = "cY";
            this.cY.Size = new System.Drawing.Size(114, 20);
            this.cY.TabIndex = 11;
            // 
            // cX
            // 
            this.cX.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cX.Location = new System.Drawing.Point(58, 102);
            this.cX.Name = "cX";
            this.cX.Size = new System.Drawing.Size(114, 20);
            this.cX.TabIndex = 9;
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
            this.bZ.Location = new System.Drawing.Point(298, 72);
            this.bZ.Name = "bZ";
            this.bZ.Size = new System.Drawing.Size(114, 20);
            this.bZ.TabIndex = 8;
            // 
            // bY
            // 
            this.bY.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bY.Location = new System.Drawing.Point(178, 72);
            this.bY.Name = "bY";
            this.bY.Size = new System.Drawing.Size(114, 20);
            this.bY.TabIndex = 7;
            // 
            // bX
            // 
            this.bX.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bX.Location = new System.Drawing.Point(58, 72);
            this.bX.Name = "bX";
            this.bX.Size = new System.Drawing.Size(114, 20);
            this.bX.TabIndex = 6;
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
            this.aX.Location = new System.Drawing.Point(58, 42);
            this.aX.Name = "aX";
            this.aX.Size = new System.Drawing.Size(114, 20);
            this.aX.TabIndex = 3;
            // 
            // aY
            // 
            this.aY.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.aY.Location = new System.Drawing.Point(178, 42);
            this.aY.Name = "aY";
            this.aY.Size = new System.Drawing.Size(114, 20);
            this.aY.TabIndex = 4;
            // 
            // aZ
            // 
            this.aZ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.aZ.Location = new System.Drawing.Point(298, 42);
            this.aZ.Name = "aZ";
            this.aZ.Size = new System.Drawing.Size(114, 20);
            this.aZ.TabIndex = 5;
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
            // acceptButton
            // 
            this.acceptButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.acceptButton.Enabled = false;
            this.acceptButton.Location = new System.Drawing.Point(588, 178);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(94, 35);
            this.acceptButton.TabIndex = 20;
            this.acceptButton.Text = "Accept";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // nextNeighborsTextBox
            // 
            this.nextNeighborsTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.nextNeighborsTextBox.Location = new System.Drawing.Point(438, 12);
            this.nextNeighborsTextBox.Name = "nextNeighborsTextBox";
            this.nextNeighborsTextBox.Size = new System.Drawing.Size(64, 20);
            this.nextNeighborsTextBox.TabIndex = 21;
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
            // hookButtonA
            // 
            this.hookButtonA.Dock = System.Windows.Forms.DockStyle.Left;
            this.hookButtonA.Enabled = false;
            this.hookButtonA.Location = new System.Drawing.Point(688, 38);
            this.hookButtonA.Name = "hookButtonA";
            this.hookButtonA.Size = new System.Drawing.Size(42, 24);
            this.hookButtonA.TabIndex = 23;
            this.hookButtonA.Text = "Hook";
            this.hookButtonA.UseVisualStyleBackColor = true;
            this.hookButtonA.Click += new System.EventHandler(this.HookButtonA_Click);
            // 
            // hookButtonB
            // 
            this.hookButtonB.Dock = System.Windows.Forms.DockStyle.Left;
            this.hookButtonB.Enabled = false;
            this.hookButtonB.Location = new System.Drawing.Point(688, 68);
            this.hookButtonB.Name = "hookButtonB";
            this.hookButtonB.Size = new System.Drawing.Size(42, 24);
            this.hookButtonB.TabIndex = 24;
            this.hookButtonB.Text = "Hook";
            this.hookButtonB.UseVisualStyleBackColor = true;
            this.hookButtonB.Click += new System.EventHandler(this.HookButtonB_Click);
            // 
            // hookButtonC
            // 
            this.hookButtonC.Dock = System.Windows.Forms.DockStyle.Left;
            this.hookButtonC.Enabled = false;
            this.hookButtonC.Location = new System.Drawing.Point(688, 98);
            this.hookButtonC.Name = "hookButtonC";
            this.hookButtonC.Size = new System.Drawing.Size(42, 24);
            this.hookButtonC.TabIndex = 25;
            this.hookButtonC.Text = "Hook";
            this.hookButtonC.UseVisualStyleBackColor = true;
            this.hookButtonC.Click += new System.EventHandler(this.HookButtonC_Click);
            // 
            // aNeighbors
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.aNeighbors, 2);
            this.aNeighbors.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.aNeighbors.FormattingEnabled = true;
            this.aNeighbors.Location = new System.Drawing.Point(438, 41);
            this.aNeighbors.Name = "aNeighbors";
            this.aNeighbors.Size = new System.Drawing.Size(244, 21);
            this.aNeighbors.TabIndex = 26;
            // 
            // bNeighbors
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.bNeighbors, 2);
            this.bNeighbors.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bNeighbors.FormattingEnabled = true;
            this.bNeighbors.Location = new System.Drawing.Point(438, 71);
            this.bNeighbors.Name = "bNeighbors";
            this.bNeighbors.Size = new System.Drawing.Size(244, 21);
            this.bNeighbors.TabIndex = 27;
            // 
            // cNeighbors
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.cNeighbors, 2);
            this.cNeighbors.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cNeighbors.FormattingEnabled = true;
            this.cNeighbors.Location = new System.Drawing.Point(438, 101);
            this.cNeighbors.Name = "cNeighbors";
            this.cNeighbors.Size = new System.Drawing.Size(244, 21);
            this.cNeighbors.TabIndex = 28;
            // 
            // normalZ
            // 
            this.normalZ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.normalZ.Location = new System.Drawing.Point(298, 152);
            this.normalZ.Name = "normalZ";
            this.normalZ.Size = new System.Drawing.Size(114, 20);
            this.normalZ.TabIndex = 29;
            // 
            // normalY
            // 
            this.normalY.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.normalY.Location = new System.Drawing.Point(178, 152);
            this.normalY.Name = "normalY";
            this.normalY.Size = new System.Drawing.Size(114, 20);
            this.normalY.TabIndex = 30;
            // 
            // normalX
            // 
            this.normalX.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.normalX.Location = new System.Drawing.Point(58, 152);
            this.normalX.Name = "normalX";
            this.normalX.Size = new System.Drawing.Size(114, 20);
            this.normalX.TabIndex = 31;
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
            // NormalSwitcherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 734);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(755, 700);
            this.Name = "NormalSwitcherForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Normal Vector Switcher";
            this.SizeChanged += new System.EventHandler(this.NormalSwitcherForm_SizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NormalSwitcherForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.originTrackBar)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button selectedButton;
        private System.Windows.Forms.Button allButton;
        private System.Windows.Forms.ToolStripMenuItem workToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem switchAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem switchSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.Button undoButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView normalListView;
        private System.Windows.Forms.ColumnHeader columnHeader0;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TrackBar originTrackBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox rotationOriginTextBox;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearHistoryToolStripMenuItem;
        private System.Windows.Forms.Button redoButton;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label labelA;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelC;
        private System.Windows.Forms.TextBox aX;
        private System.Windows.Forms.TextBox aY;
        private System.Windows.Forms.TextBox aZ;
        private System.Windows.Forms.TextBox bX;
        private System.Windows.Forms.TextBox bY;
        private System.Windows.Forms.TextBox bZ;
        private System.Windows.Forms.TextBox cX;
        private System.Windows.Forms.TextBox cZ;
        private System.Windows.Forms.TextBox cY;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelZ;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.TextBox nextNeighborsTextBox;
        private System.Windows.Forms.Button nextNeighborsButton;
        private System.Windows.Forms.ToolStripMenuItem clearUndoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearRedoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearUndoRedoToolStripMenuItem;
        private System.Windows.Forms.Button hookButtonA;
        private System.Windows.Forms.Button hookButtonB;
        private System.Windows.Forms.Button hookButtonC;
        private System.Windows.Forms.ComboBox aNeighbors;
        private System.Windows.Forms.ComboBox bNeighbors;
        private System.Windows.Forms.ComboBox cNeighbors;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TextBox normalZ;
        private System.Windows.Forms.TextBox normalY;
        private System.Windows.Forms.TextBox normalX;
        private System.Windows.Forms.Label labelNormal;
    }
}

