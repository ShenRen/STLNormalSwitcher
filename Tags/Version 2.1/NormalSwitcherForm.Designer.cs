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
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.reOrientAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reOrientSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.switchAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.switchSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.undoButton = new System.Windows.Forms.Button();
            this.rotationOriginTextBox = new System.Windows.Forms.TextBox();
            this.labelOrigin = new System.Windows.Forms.Label();
            this.selectedButton = new System.Windows.Forms.Button();
            this.allButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.clearHistoryButton = new System.Windows.Forms.Button();
            this.reorientSelectedButton = new System.Windows.Forms.Button();
            this.reorientAllButton = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.originTrackBar = new System.Windows.Forms.TrackBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.menuStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.originTrackBar)).BeginInit();
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
            this.resetToolStripMenuItem,
            this.clearHistoryToolStripMenuItem,
            this.toolStripSeparator2,
            this.reOrientAllToolStripMenuItem,
            this.reOrientSelectedToolStripMenuItem,
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
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.undoToolStripMenuItem.Text = "&Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.Undo);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Enabled = false;
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.resetToolStripMenuItem.Text = "&Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.Reset);
            // 
            // clearHistoryToolStripMenuItem
            // 
            this.clearHistoryToolStripMenuItem.Enabled = false;
            this.clearHistoryToolStripMenuItem.Name = "clearHistoryToolStripMenuItem";
            this.clearHistoryToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.clearHistoryToolStripMenuItem.Text = "&Clear History";
            this.clearHistoryToolStripMenuItem.Click += new System.EventHandler(this.ClearHistoryToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(173, 6);
            // 
            // reOrientAllToolStripMenuItem
            // 
            this.reOrientAllToolStripMenuItem.Enabled = false;
            this.reOrientAllToolStripMenuItem.Name = "reOrientAllToolStripMenuItem";
            this.reOrientAllToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.reOrientAllToolStripMenuItem.Text = "Re-Orient All";
            this.reOrientAllToolStripMenuItem.Click += new System.EventHandler(this.ReOrientAll);
            // 
            // reOrientSelectedToolStripMenuItem
            // 
            this.reOrientSelectedToolStripMenuItem.Enabled = false;
            this.reOrientSelectedToolStripMenuItem.Name = "reOrientSelectedToolStripMenuItem";
            this.reOrientSelectedToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.reOrientSelectedToolStripMenuItem.Text = "Re-Orient Selected";
            this.reOrientSelectedToolStripMenuItem.Click += new System.EventHandler(this.ReOrientSelected);
            // 
            // switchAllToolStripMenuItem
            // 
            this.switchAllToolStripMenuItem.Enabled = false;
            this.switchAllToolStripMenuItem.Name = "switchAllToolStripMenuItem";
            this.switchAllToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.switchAllToolStripMenuItem.Text = "Switch &All";
            this.switchAllToolStripMenuItem.Click += new System.EventHandler(this.SwitchAll);
            // 
            // switchSelectedToolStripMenuItem
            // 
            this.switchSelectedToolStripMenuItem.Enabled = false;
            this.switchSelectedToolStripMenuItem.Name = "switchSelectedToolStripMenuItem";
            this.switchSelectedToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
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
            this.tableLayoutPanel1.Controls.Add(this.rotationOriginTextBox, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.labelOrigin, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.selectedButton, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.allButton, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.resetButton, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.clearHistoryButton, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.reorientSelectedButton, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.reorientAllButton, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 13;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
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
            this.undoButton.Location = new System.Drawing.Point(18, 19);
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
            this.rotationOriginTextBox.Location = new System.Drawing.Point(18, 412);
            this.rotationOriginTextBox.Name = "rotationOriginTextBox";
            this.rotationOriginTextBox.Size = new System.Drawing.Size(94, 20);
            this.rotationOriginTextBox.TabIndex = 5;
            this.rotationOriginTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RotationOriginTextBox_KeyPress);
            // 
            // labelOrigin
            // 
            this.labelOrigin.AutoSize = true;
            this.labelOrigin.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelOrigin.Location = new System.Drawing.Point(18, 392);
            this.labelOrigin.Name = "labelOrigin";
            this.labelOrigin.Size = new System.Drawing.Size(94, 13);
            this.labelOrigin.TabIndex = 4;
            this.labelOrigin.Text = "Rotation origin:";
            // 
            // selectedButton
            // 
            this.selectedButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedButton.Enabled = false;
            this.selectedButton.Location = new System.Drawing.Point(18, 338);
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
            this.allButton.Location = new System.Drawing.Point(18, 308);
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
            this.resetButton.Location = new System.Drawing.Point(18, 79);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(94, 24);
            this.resetButton.TabIndex = 2;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.Reset);
            // 
            // clearHistoryButton
            // 
            this.clearHistoryButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clearHistoryButton.Enabled = false;
            this.clearHistoryButton.Location = new System.Drawing.Point(18, 49);
            this.clearHistoryButton.Name = "clearHistoryButton";
            this.clearHistoryButton.Size = new System.Drawing.Size(94, 24);
            this.clearHistoryButton.TabIndex = 6;
            this.clearHistoryButton.Text = "Clear History";
            this.clearHistoryButton.UseVisualStyleBackColor = true;
            this.clearHistoryButton.Click += new System.EventHandler(this.ClearHistoryToolStripMenuItem_Click);
            // 
            // reorientSelectedButton
            // 
            this.reorientSelectedButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reorientSelectedButton.Enabled = false;
            this.reorientSelectedButton.Location = new System.Drawing.Point(18, 268);
            this.reorientSelectedButton.Name = "reorientSelectedButton";
            this.reorientSelectedButton.Size = new System.Drawing.Size(94, 34);
            this.reorientSelectedButton.TabIndex = 7;
            this.reorientSelectedButton.Text = "Re-Orient Selected";
            this.reorientSelectedButton.UseVisualStyleBackColor = true;
            this.reorientSelectedButton.Click += new System.EventHandler(this.ReOrientSelected);
            // 
            // reorientAllButton
            // 
            this.reorientAllButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reorientAllButton.Enabled = false;
            this.reorientAllButton.Location = new System.Drawing.Point(18, 238);
            this.reorientAllButton.Name = "reorientAllButton";
            this.reorientAllButton.Size = new System.Drawing.Size(94, 24);
            this.reorientAllButton.TabIndex = 8;
            this.reorientAllButton.Text = "Re-Orient All";
            this.reorientAllButton.UseVisualStyleBackColor = true;
            this.reorientAllButton.Click += new System.EventHandler(this.ReOrientAll);
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
            this.splitContainer2.SplitterWidth = 1;
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
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.MinimumSize = new System.Drawing.Size(622, 240);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(747, 248);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.TabControl1_Selecting);
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
        private System.Windows.Forms.TrackBar originTrackBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label labelOrigin;
        private System.Windows.Forms.TextBox rotationOriginTextBox;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearHistoryToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button clearHistoryButton;
        private System.Windows.Forms.Button reorientSelectedButton;
        private System.Windows.Forms.ToolStripMenuItem reOrientAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reOrientSelectedToolStripMenuItem;
        private System.Windows.Forms.Button reorientAllButton;
    }
}

