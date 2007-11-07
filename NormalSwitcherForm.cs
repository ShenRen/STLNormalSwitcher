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
    public partial class NormalSwitcherForm : Form {

        #region Fields

        private NormalSwitcherControl visualization;
        private STLParser parser = new STLParser();

        private String currentFile;

        private TriangleList triangleList;
        private TriangleList backupList;

        private int origin;

        private List<List<Triangle>> history = new List<List<Triangle>>();
        private List<Triangle> currentSelection = new List<Triangle>();

        #endregion

        #region Properties

        /// <value>Gets the TriangleList or sets it</value>
        public TriangleList TriangleList {
            get { return triangleList; }
            set { triangleList = value; }
        }

        /// <value>Gets the origin, the z-value to rotate around</value>
        public float Origin { get { return (float)origin; } }

        /// <value>Gets the currentSelection</value>
        public List<Triangle> CurrentSelection { get { return currentSelection; } }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes the NormalSwitcherForm and subscribes to events.
        /// </summary>
        public NormalSwitcherForm() {
            InitializeComponent();
            currentFile = "";

            undoButton.EnabledChanged += new EventHandler(Undo_EnabledChanged);
            allButton.EnabledChanged += new EventHandler(FileCondition_EnabledChanged);
        }

        /// <summary>
        /// Initializes the NormalSwitcherForm and opens the file given by <paramref name="file"/>
        /// </summary>
        /// <param name="file">Path of the file to be displayed</param>
        public NormalSwitcherForm(string file) {
            InitializeComponent();

            undoButton.EnabledChanged += new EventHandler(Undo_EnabledChanged);
            allButton.EnabledChanged += new EventHandler(FileCondition_EnabledChanged);

            StreamReader reader = new StreamReader(file);
            try {
                parser.Parse(reader);
                triangleList = parser.TriangleList;
                backupList = triangleList.Copy();
                originTrackBar.Minimum = -(int)(triangleList.Scale / 2);
                originTrackBar.Maximum = (int)(triangleList.Scale / 2);
                originTrackBar.Value = origin = 0;
                rotationOriginTextBox.Text = origin.ToString();
                originTrackBar.Visible = true;
                InitVisualization();

                currentFile = file;
                allButton.Enabled = true;

                FillListView();
            } catch (Exception exception) {
                MessageBox.Show(exception.Message, "Error");
            } finally {
                reader.Close();
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates a new NormalSwitcherControl and adds it to the NormalSwitcherForm.
        /// </summary>
        private void InitVisualization() {
            visualization = new NormalSwitcherControl(this);
            splitContainer2.Panel2.Controls.Add(visualization);
            visualization.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Fills the normalListView. The normal vectors are in the first column and the
        /// corresponding triangles are in the second column.
        /// </summary>
        private void FillListView() {
            normalListView.BeginUpdate();
            normalListView.Items.Clear();
            normalListView.Sorting = SortOrder.None;
            for (int i = 0; i < triangleList.Count; i++) {
                normalListView.Items.Add(new ListViewItem(new string[2] { triangleList[i].NormalToString(), triangleList[i].ToString() }));
                normalListView.Items[i].Tag = i;
            }
            MarkSelectedItems();
            normalListView.EndUpdate();
            visualization.SetColorArray();
        }

        /// <summary>
        /// Creates a new currentSelection and adds it to the history.
        /// </summary>
        private void MakeHistory() {
            if (normalListView.SelectedItems.Count >= 1) {
                MakeCurrentSelection();
                if (currentSelection.Count > 0) {
                    List<Triangle> temp = new List<Triangle>();
                    for (int i = 0; i < currentSelection.Count; i++) {
                        temp.Add(currentSelection[i].Copy());
                    }
                    history.Add(temp);
                }
            }
        }

        /// <summary>
        /// Creates a new currentSelection from the normalListView.SelectedItems.
        /// </summary>
        private void MakeCurrentSelection() {
            currentSelection.Clear();
            if (normalListView.SelectedItems.Count >= 1) {
                for (int j = 0; j < normalListView.SelectedItems.Count; j++) {
                    currentSelection.Add(triangleList[(int)normalListView.SelectedItems[j].Tag]);
                }
            }
        }

        /// <summary>
        /// Marks the items from the currentSelection in the normalListView and
        /// jumps to the first selected item.
        /// </summary>
        private void MarkSelectedItems() {
            normalListView.SelectedIndexChanged -= NormalListView_SelectedIndexChanged;
            for (int j = 0; j < currentSelection.Count; j++) {
                if (currentSelection[j].Position > -1) {
                    normalListView.SelectedIndices.Add(currentSelection[j].Position);
                }
            }
            normalListView.SelectedIndexChanged += NormalListView_SelectedIndexChanged;
            if (normalListView.SelectedItems.Count > 0) {
                normalListView.TopItem = normalListView.SelectedItems[0];
            }
        }

        /// <summary>
        /// Marks the triangles picked in the visualization.
        /// </summary>
        /// <param name="selected">List of the selected triangles</param>
        /// <param name="additive">If true, the <paramref name="selected"/> triangles will be selected
        /// in addition to the previously selected ones. Selecting a triangle twice deselects it.</param>
        public void PickTriangle(List<int> selected, bool additive) {
            if (additive) {
                if (selected.Count > 0) {
                    for (int i = 0; i < normalListView.Items.Count; i++) {
                        if ((int)normalListView.Items[i].Tag == selected[0]) {
                            if (normalListView.SelectedIndices.Contains(normalListView.Items.IndexOf(normalListView.Items[i]))) {
                                normalListView.SelectedIndices.Remove(normalListView.Items.IndexOf(normalListView.Items[i]));
                            } else {
                                normalListView.SelectedIndices.Add(normalListView.Items.IndexOf(normalListView.Items[i]));
                            }
                        }
                    }
                }
            } else {
                if (selected.Count > 0) {
                    normalListView.SelectedItems.Clear();
                    for (int i = 0; i < normalListView.Items.Count; i++) {
                        if ((int)normalListView.Items[i].Tag == selected[0]) {
                            normalListView.SelectedIndices.Add(normalListView.Items.IndexOf(normalListView.Items[i]));
                        }
                    }
                } else {
                    normalListView.SelectedItems.Clear();
                    currentSelection.Clear();
                    visualization.SetColorArray();
                    visualization.Refresh();
                }
            }
            if (normalListView.SelectedItems.Count > 0) {
                normalListView.TopItem = normalListView.SelectedItems[0];
            } else {
                normalListView.TopItem = normalListView.Items[0];
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
                    originTrackBar.Minimum = -(int)(triangleList.Scale / 2);
                    originTrackBar.Maximum = (int)(triangleList.Scale / 2);
                    originTrackBar.Value = origin = 0;
                    rotationOriginTextBox.Text = origin.ToString();
                    originTrackBar.Visible = true;
                    InitVisualization();

                    currentFile = ofd.FileName;
                    allButton.Enabled = true;

                    FillListView();
                } catch (Exception exception) {
                    MessageBox.Show(exception.Message, "Error");
                } finally {
                    reader.Close();
                }
            }
            ofd.Dispose();
        }

        /// <summary>
        /// Overwrites the opened file with the STL-data in the same format (ASCII or binary).
        /// </summary>
        /// <param name="sender">saveToolStripMenuItem</param>
        /// <param name="e">Standard EventArgs</param>
        private void SaveFile(object sender, EventArgs e) {
            if (parser.ASCII) {
                SwitchersHelpers.WriteToASCII(this.currentFile, triangleList);
            } else {
                SwitchersHelpers.WriteToBinary(this.currentFile, triangleList);
            }
        }

        /// <summary>
        /// Saves the STL-data in the chosen file and the chosen format (ASCII or binary).
        /// </summary>
        /// <param name="sender">saveAsToolStripMenuItem</param>
        /// <param name="e">Standard EventArgs</param>
        private void SaveAs(object sender, EventArgs e) {
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
            }
        }

        /// <summary>
        /// Destroys the NormalSwitcherControl and resets the GUI-elements.
        /// </summary>
        /// <param name="sender">closeToolStripMenuItem</param>
        /// <param name="e">Standard EventArgs</param>
        private void CloseFile(object sender, EventArgs e) {
            if (currentFile != "") {
                if ((undoButton.Enabled) && (MessageBox.Show("Do you want to save your changes?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)) {
                    this.SaveAs(sender, e);
                }

                splitContainer2.Panel2.Controls.Clear();
                visualization = null;
                originTrackBar.Visible = false;
                history.Clear();
                currentSelection.Clear();
                currentFile = "";
                allButton.Enabled = false;
                undoButton.Enabled = false;

                triangleList = null;
                parser = new STLParser();

                normalListView.Items.Clear();
                normalListView.Items.Add(new ListViewItem(new string[2] { "Select a File!", "Select a File!" }));
                normalListView.Items[0].Tag = -2;
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
        /// Reverts the last switch.
        /// </summary>
        /// <param name="sender">undoToolStripMenuItem or undoButton</param>
        /// <param name="e">Standard EventArgs</param>
        private void Undo(object sender, EventArgs e) {
            if (history.Count >= 1) {
                currentSelection = history[history.Count - 1];
                for (int i = 0; i < currentSelection.Count; i++) {
                    triangleList[currentSelection[i].Position] = currentSelection[i];
                }
                history.RemoveAt(history.Count - 1);
            }
            if (history.Count >= 1) {
                currentSelection = history[history.Count - 1];
            } else if (history.Count == 0) {
                currentSelection.Clear();
                undoButton.Enabled = false;
            }

            triangleList.CalculateArrays();
            FillListView();
            visualization.Refresh();
        }

        /// <summary>
        /// Sets all normal vectors back to the values from the STL-file.
        /// </summary>
        /// <param name="sender">resetToolStripMenuItem or resetButton</param>
        /// <param name="e">Standard EventArgs</param>
        private void Reset(object sender, EventArgs e) {
            triangleList = null;
            triangleList = backupList.Copy();
            currentSelection.Clear();
            history.Clear();

            undoButton.Enabled = false;
            FillListView();
            visualization.Refresh();
        }

        /// <summary>
        /// Switches all normal vectors.
        /// </summary>
        /// <param name="sender">switchAllToolStripMenuItem or allButton</param>
        /// <param name="e">Standard EventArgs</param>
        private void SwitchAll(object sender, EventArgs e) {
            List<Triangle> temp = new List<Triangle>();
            for (int i = 0; i < triangleList.Count; i++) {
                temp.Add(triangleList[i].Copy());
            }
            history.Add(temp);
            triangleList.SwitchAll();

            undoButton.Enabled = true;
            FillListView();
            visualization.Refresh();
        }

        /// <summary>
        /// Switches the selected normal vectors.
        /// </summary>
        /// <param name="sender">switchSelectedToolStripMenuItem or selectedButton</param>
        /// <param name="e">Standard EventArgs</param>
        private void SwitchSelected(object sender, EventArgs e) {
            MakeHistory();
            if (currentSelection.Count > 0) {
                triangleList.SwitchSelected(currentSelection);

                undoButton.Enabled = true;
                FillListView();
                visualization.Refresh();
            }
        }

        /// <summary>
        /// Shows the About dialogue with information about the STLNormalSwitcher.
        /// </summary>
        /// <param name="sender">aboutToolStripMenuItem</param>
        /// <param name="e">Standard EventArgs</param>
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e) {
            About about = new About();
            about.ShowDialog();
        }


        #region Activation/Deaktivation

        /// <summary>
        /// The undoToolStripMenuItem, the resetButton, the resetToolStripMenuItem and
        /// the undoButton are enabled and disabled at the same time.
        /// </summary>
        /// <param name="sender">undoButton</param>
        /// <param name="e">Standard EventARgs</param>
        void Undo_EnabledChanged(object sender, EventArgs e) {
            undoToolStripMenuItem.Enabled =
                resetButton.Enabled =
                resetToolStripMenuItem.Enabled =
                undoButton.Enabled;
        }

        /// <summary>
        /// The closeToolStripMenuItem, the saveToolStripMenuItem, the saveAsToolStripMenuItem,
        /// the switchAllToolStripMenuItem, the switchSelectedToolStripMenuItem, the selectedButton,
        /// the rotationOriginTextBox and the allButton are enabled and disabled at the same time.
        /// </summary>
        /// <param name="sender">allButton</param>
        /// <param name="e">Standard EventArgs</param>
        void FileCondition_EnabledChanged(object sender, EventArgs e) {
            closeToolStripMenuItem.Enabled =
                saveToolStripMenuItem.Enabled =
                saveAsToolStripMenuItem.Enabled =
                switchAllToolStripMenuItem.Enabled =
                switchSelectedToolStripMenuItem.Enabled =
                selectedButton.Enabled =
                rotationOriginTextBox.Enabled =
                allButton.Enabled;
        }

        #endregion

        #endregion

        #region normalListView

        /// <summary>
        /// Updates the currentSelection and marks the selected triangles in the NormalSwitcherControl.
        /// </summary>
        /// <param name="sender">normalListView</param>
        /// <param name="e">Standard EventArgs</param>
        private void NormalListView_SelectedIndexChanged(object sender, EventArgs e) {
            MakeCurrentSelection();
            visualization.SetColorArray();
            visualization.Refresh();
        }

        /// <summary>
        /// Sorts the normalListView by the values of the clicked column.
        /// </summary>
        /// <param name="sender">normalListView ColumnHeader</param>
        /// <param name="e">Standard ColumnClickEventArgs</param>
        private void NormalListView_ColumnClick(object sender, ColumnClickEventArgs e) {
            if (normalListView.Sorting == SortOrder.None) {
                normalListView.Sorting = SortOrder.Ascending;
                normalListView.ListViewItemSorter = new ListViewComparer(e.Column, SortOrder.Ascending);
            } else if (normalListView.Sorting == SortOrder.Ascending) {
                normalListView.Sorting = SortOrder.Descending;
                normalListView.ListViewItemSorter = new ListViewComparer(e.Column, SortOrder.Descending);
            } else {
                normalListView.Sorting = SortOrder.Ascending;
                normalListView.ListViewItemSorter = new ListViewComparer(e.Column, SortOrder.Ascending);
            }
        }

        /// <summary>
        /// Stretches the second column of normalListView to fit the NormalSwitcherForm.
        /// </summary>
        /// <param name="sender">this NormalSwitcherForm</param>
        /// <param name="e">Standard EventArgs</param>
        private void NormalSwitcherForm_SizeChanged(object sender, EventArgs e) {
            if (this.Width > 740) {
                normalListView.Columns[1].Width = this.Width - normalListView.Columns[0].Width - 30;
            }
        }

        #endregion

        /// <summary>
        /// Updates the rotationOriginTextBox and the origin,
        /// when the value of the originTrackBar is changed and refreshes the NormalSwitcherControl.
        /// </summary>
        /// <param name="sender">originTrackBar</param>
        /// <param name="e">Standard EventArgs</param>
        private void OriginTrackBar_ValueChanged(object sender, EventArgs e) {
            origin = originTrackBar.Value;
            rotationOriginTextBox.Text = origin.ToString();
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
                    if (value < originTrackBar.Minimum) { originTrackBar.Value = originTrackBar.Minimum; } else if (value > originTrackBar.Maximum) { originTrackBar.Value = originTrackBar.Maximum; } else { originTrackBar.Value = value; }
                } catch { rotationOriginTextBox.Text = originTrackBar.Value.ToString(); }
            }
        }

        /// <summary>
        /// Closes a previously opened file and ends the Application.
        /// </summary>
        /// <param name="sender">FormClosing event</param>
        /// <param name="e">Standard FormClosingEventArgs</param>
        private void NormalSwitcherForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (visualization != null) {
                visualization.DestroyContexts();
            }
            if ((undoButton.Enabled) && (MessageBox.Show("Do you want to save your changes?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)) {
                this.SaveAs(sender, e);
            }
        }

        #endregion
    }
}