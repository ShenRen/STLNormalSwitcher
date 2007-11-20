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
        private int[] triVertices = new int[6];
        private bool changed = false;

        private List<Event> history = new List<Event>();
        private Event currentSelection = new Event();

        private List<Vertex> neighborsOfA = new List<Vertex>();
        private List<Vertex> neighborsOfB = new List<Vertex>();
        private List<Vertex> neighborsOfC = new List<Vertex>();

        #endregion

        #region Properties

        /// <value>Gets the TriangleList or sets it</value>
        public TriangleList TriangleList {
            get { return triangleList; }
            set { triangleList = value; }
        }

        /// <value>
        /// Gets the positions of the owners of the Vertices selected on the "Add/Remove"-Tab
        /// and the positions of those Vertices in that Triangle.
        /// </value>
        public int[] TriVertices { get { return triVertices; } }

        /// <value>Gets the origin, the z-value to rotate around</value>
        public float Origin { get { return (float)origin; } }

        /// <value>Gets the currentSelection</value>
        public Event CurrentSelection { get { return currentSelection; } }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes the NormalSwitcherForm and subscribes to events.
        /// </summary>
        public NormalSwitcherForm() {
            InitializeComponent();
            currentFile = "";

            normalListView.Columns[0].Width = normalListView.Columns[1].Width =
                normalListView.Columns[2].Width = normalListView.Columns[3].Width =
                (this.Width - 30) / 4;

            BindEvents();
        }

        /// <summary>
        /// Initializes the NormalSwitcherForm and opens the file given by <paramref name="file"/>
        /// </summary>
        /// <param name="file">Path of the file to be displayed</param>
        public NormalSwitcherForm(string file) {
            InitializeComponent();

            normalListView.Columns[0].Width = normalListView.Columns[1].Width =
                normalListView.Columns[2].Width = normalListView.Columns[3].Width =
                (this.Width - 30) / 4;

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

                FillTab();
            } catch (Exception exception) {
                MessageBox.Show(exception.Message, "Error");
            } finally {
                reader.Close();
            }
        }

        #endregion

        #region Methods

        private void BindEvents() {
            triangleComboBox.DisplayMember = "AsString";
            verticesA.DisplayMember = "AsString";
            verticesB.DisplayMember = "AsString";
            verticesC.DisplayMember = "AsString";

            undoButton.EnabledChanged += new EventHandler(Undo_EnabledChanged);
            allButton.EnabledChanged += new EventHandler(FileCondition_EnabledChanged);
            acceptButton.EnabledChanged += new EventHandler(AcceptButton_EnabledChanged);
            hookButtonA.EnabledChanged += new EventHandler(HookButton_EnabledChanged);
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
        private void SetOrigin() {
            originTrackBar.Minimum = -(int)(triangleList.Scale / 2);
            originTrackBar.Maximum = (int)(triangleList.Scale / 2);
            originTrackBar.Value = origin = 0;
            rotationOriginTextBox.Text = origin.ToString();
        }

        /// <summary>
        /// Fills the currently open Tab.
        /// For tabPage1 the normalListView is filled.
        /// For tabPage2 the TextBoxes are filled with the values of the selected Triangle
        /// or emptied, if not exactly one Triangle is selected.
        /// For tabPage3 the triangleComboBox and the vertices ComboBoxes are updated.
        /// </summary>
        private void FillTab() {
            if (tabControl1.SelectedTab == tabPage1) {
                visualization.Vertices = false;
                normalListView.BeginUpdate();
                normalListView.Items.Clear();
                normalListView.Sorting = SortOrder.None;
                for (int i = 0; i < triangleList.Count; i++) {
                    normalListView.Items.Add(new ListViewItem(new string[4] { triangleList[i].NormalToString(), triangleList[i][0].ToString(), triangleList[i][1].ToString(), triangleList[i][2].ToString() }));
                    normalListView.Items[i].Tag = i;
                }

                normalListView.SelectedIndexChanged -= NormalListView_SelectedIndexChanged;
                normalListView.SelectedIndices.Clear();
                for (int j = 0; j < currentSelection.Count; j++) {
                    if (currentSelection[j].Position > -1) {
                        normalListView.SelectedIndices.Add(currentSelection[j].Position);
                    }
                }
                normalListView.SelectedIndexChanged += NormalListView_SelectedIndexChanged;
                if (normalListView.SelectedItems.Count > 0) {
                    normalListView.TopItem = normalListView.SelectedItems[0];
                }

                normalListView.EndUpdate();
                visualization.SetColorArray();
            } else if (tabControl1.SelectedTab == tabPage2) {
                visualization.Vertices = false;
                if (normalListView.SelectedIndices.Count == 1) {
                    aX.Text = triangleList[(int)normalListView.SelectedItems[0].Tag][0][0].ToString();
                    aY.Text = triangleList[(int)normalListView.SelectedItems[0].Tag][0][1].ToString();
                    aZ.Text = triangleList[(int)normalListView.SelectedItems[0].Tag][0][2].ToString();
                    bX.Text = triangleList[(int)normalListView.SelectedItems[0].Tag][1][0].ToString();
                    bY.Text = triangleList[(int)normalListView.SelectedItems[0].Tag][1][1].ToString();
                    bZ.Text = triangleList[(int)normalListView.SelectedItems[0].Tag][1][2].ToString();
                    cX.Text = triangleList[(int)normalListView.SelectedItems[0].Tag][2][0].ToString();
                    cY.Text = triangleList[(int)normalListView.SelectedItems[0].Tag][2][1].ToString();
                    cZ.Text = triangleList[(int)normalListView.SelectedItems[0].Tag][2][2].ToString();
                    normalX.Text = triangleList[(int)normalListView.SelectedItems[0].Tag][3][0].ToString();
                    normalY.Text = triangleList[(int)normalListView.SelectedItems[0].Tag][3][1].ToString();
                    normalZ.Text = triangleList[(int)normalListView.SelectedItems[0].Tag][3][2].ToString();
                    acceptButton.Enabled = true;
                } else {
                    aX.Text = aY.Text = aZ.Text = bX.Text = bY.Text = bZ.Text = cX.Text = cY.Text = cZ.Text =
                        normalX.Text = normalY.Text = normalZ.Text = nextNeighborsTextBox.Text = "";
                    acceptButton.Enabled = hookButtonA.Enabled = false;
                    aNeighbors.DataSource = bNeighbors.DataSource = cNeighbors.DataSource = null;
                }
            } else {
                visualization.Vertices = true;
                visualization.Fresh = false;

                triangleComboBox.SelectedIndexChanged -= TriangleComboBox_SelectedIndexChanged;
                triangleComboBox.DataSource = null;
                triangleComboBox.DataSource = triangleList;

                verticesA.DataSource = verticesB.DataSource = verticesC.DataSource = null;
                verticesA.DataSource = triangleList.Vertices;
                verticesB.DataSource = triangleList.Vertices;
                verticesC.DataSource = triangleList.Vertices;
                
                UpdateAddRemoveTab();
                triangleComboBox.SelectedIndexChanged += TriangleComboBox_SelectedIndexChanged;
            }

            visualization.Refresh();
        }

        /// <summary>
        /// Updates the Boxes on the "Add/Remove"-Tab.
        /// </summary>
        private void UpdateAddRemoveTab() {
            triangleComboBox.SelectedIndexChanged -= TriangleComboBox_SelectedIndexChanged;
            Triangle temp;
            if ((currentSelection.Count > 0) && (currentSelection[0] != null)) {
                temp = currentSelection[0];
                triangleComboBox.SelectedIndex = temp.Position;
            } else {
                temp = triangleComboBox.SelectedItem as Triangle;
            }
            currentSelection.Clear();
            currentSelection.Add(temp);
            if (currentSelection[0] != null) {
                verticesA.SelectedItem = currentSelection[0][0];
                verticesB.SelectedItem = currentSelection[0][1];
                verticesC.SelectedItem = currentSelection[0][2];
                triVertices[0] = triangleList.IndexOf((verticesA.SelectedItem as Vertex).Owner);
                triVertices[1] = (verticesA.SelectedItem as Vertex).Owner.IndexOf(verticesA.SelectedItem as Vertex);
                triVertices[2] = triangleList.IndexOf((verticesB.SelectedItem as Vertex).Owner);
                triVertices[3] = (verticesB.SelectedItem as Vertex).Owner.IndexOf(verticesB.SelectedItem as Vertex);
                triVertices[4] = triangleList.IndexOf((verticesC.SelectedItem as Vertex).Owner);
                triVertices[5] = (verticesC.SelectedItem as Vertex).Owner.IndexOf(verticesC.SelectedItem as Vertex);
                visualization.SetColorArray();
            }
            triangleComboBox.SelectedIndexChanged += TriangleComboBox_SelectedIndexChanged;

            visualization.Fresh = true;
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
            if ((selected.Count > 0) && (selected[0] < triangleComboBox.Items.Count) && (tabControl1.SelectedTab == tabPage3)) {
                triangleComboBox.SelectedIndex = selected[0];
            }
            if ((selected.Count == 1) && (tabControl1.SelectedTab == tabPage2)) {
                FillTab();
            }
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

            for (int i = 0; i < triangleList.Count; i++) {
                if (i != currentSelection[0].Position) {
                    for (int j = 0; j < 3; j++) {
                        dist = currentSelection[0][0].DistanceFrom(triangleList[i][j]);
                        tempA.Add(dist.ToString() + "t" + i.ToString() + "v" + j.ToString(), triangleList[i][j]);
                        dist = currentSelection[0][1].DistanceFrom(triangleList[i][j]);
                        tempB.Add(dist.ToString() + "t" + i.ToString() + "v" + j.ToString(), triangleList[i][j]);
                        dist = currentSelection[0][2].DistanceFrom(triangleList[i][j]);
                        tempC.Add(dist.ToString() + "t" + i.ToString() + "v" + j.ToString(), triangleList[i][j]);
                    }
                }
            }

            for (int k = 0; k < number; k++) {
                neighborsOfA.Add(tempA[tempA.Keys[k]]);
                neighborsOfB.Add(tempB[tempB.Keys[k]]);
                neighborsOfC.Add(tempC[tempC.Keys[k]]);
            }

            aNeighbors.DataSource = neighborsOfA;
            aNeighbors.DisplayMember = "AsString";
            bNeighbors.DataSource = neighborsOfB;
            bNeighbors.DisplayMember = "AsString";
            cNeighbors.DataSource = neighborsOfC;
            cNeighbors.DisplayMember = "AsString";
            hookButtonA.Enabled = true;
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

                        FillTab();
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
                triVertices = new int[6];
                visualization.Vertices = false;
                visualization.Fresh = true;

                tabControl1.SelectedIndex = 0;
                normalListView.Items.Clear();
                normalListView.Items.Add(new ListViewItem(new string[4] { "Select a File!", "Select a File!", "Select a File!", "Select a File!" }));
                normalListView.Items[0].Tag = -2;

                triangleComboBox.SelectedIndexChanged -= TriangleComboBox_SelectedIndexChanged;
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
                    triangleList.Finish();
                    triangleList.SetPositions();
                } else {
                    triangleList.Insert(currentSelection[0].Position, currentSelection[0]);
                    triangleList.Finish();
                    triangleList.SetPositions();
                }
                history.RemoveAt(history.Count - 1);
            }
            if (history.Count == 0) {
                undoButton.Enabled = false;
            }

            triangleList.CalculateArrays();
            SetOrigin();
            FillTab();
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
            SetOrigin();
            FillTab();
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
            FillTab();
        }

        /// <summary>
        /// Switches the selected normal vectors.
        /// </summary>
        /// <param name="sender">switchSelectedToolStripMenuItem or selectedButton</param>
        /// <param name="e">Standard EventArgs</param>
        private void SwitchSelected(object sender, EventArgs e) {
            if (normalListView.SelectedItems.Count >= 1) {
                MakeCurrentSelection();
                if (currentSelection.Count > 0) {
                    Event temp = new Event(Event.EventType.Edit);
                    for (int i = 0; i < currentSelection.Count; i++) {
                        temp.Add(currentSelection[i].Copy());
                    }
                    history.Add(temp);
                }
            }

            if (currentSelection.Count > 0) {
                triangleList.SwitchSelected(currentSelection);

                undoButton.Enabled = true;
                changed = true;
                FillTab();
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
            normalListView.Columns[0].Width = normalListView.Columns[1].Width =
                normalListView.Columns[2].Width = normalListView.Columns[3].Width =
                (this.Width - 30) / 4;
        }

        #endregion

        #region Edit Triangle

        /// <summary>
        /// Initiates the filling of the Neighbors ComboBoxes.
        /// </summary>
        /// <param name="sender">nextNeighborsButton</param>
        /// <param name="e">Standard EventArgs</param>
        private void NextNeighborsButton_Click(object sender, EventArgs e) {
            try {
                int number = Convert.ToInt32(nextNeighborsTextBox.Text);
                if (number >= 1) {
                    if (number >= (triangleList.Count - 1) * 3) {
                        number = (triangleList.Count - 1) * 3;
                        nextNeighborsTextBox.Text = number.ToString();
                    }
                    CalculateNeighbors(number);
                } else { MessageBox.Show("You need to enter an Integer greater than 0!"); }
            } catch {
                MessageBox.Show("You need to enter an Integer greater than 0!");
            }
        }

        /// <summary>
        /// Adjusts the values of the A-Vertex of the Triangle on the
        /// "Edit the First Selected Triangle"-Tab to the Vertex in the aNeighbors ComboBox.
        /// </summary>
        /// <param name="sender">hookButtonA</param>
        /// <param name="e">Standard EventArgs</param>
        private void HookButtonA_Click(object sender, EventArgs e) {
            aX.Text = (aNeighbors.SelectedItem as Vertex)[0].ToString();
            aY.Text = (aNeighbors.SelectedItem as Vertex)[1].ToString();
            aZ.Text = (aNeighbors.SelectedItem as Vertex)[2].ToString();
        }

        /// <summary>
        /// Adjusts the values of the B-Vertex of the Triangle on the
        /// "Edit the First Selected Triangle"-Tab to the Vertex in the bNeighbors ComboBox.
        /// </summary>
        /// <param name="sender">hookButtonB</param>
        /// <param name="e">Standard EventArgs</param>
        private void HookButtonB_Click(object sender, EventArgs e) {
            bX.Text = (bNeighbors.SelectedItem as Vertex)[0].ToString();
            bY.Text = (bNeighbors.SelectedItem as Vertex)[1].ToString();
            bZ.Text = (bNeighbors.SelectedItem as Vertex)[2].ToString();
        }

        /// <summary>
        /// Adjusts the values of the C-Vertex of the Triangle on the
        /// "Edit the First Selected Triangle"-Tab to the Vertex in the cNeighbors ComboBox.
        /// </summary>
        /// <param name="sender">hookButtonC</param>
        /// <param name="e">Standard EventArgs</param>
        private void HookButtonC_Click(object sender, EventArgs e) {
            cX.Text = (cNeighbors.SelectedItem as Vertex)[0].ToString();
            cY.Text = (cNeighbors.SelectedItem as Vertex)[1].ToString();
            cZ.Text = (cNeighbors.SelectedItem as Vertex)[2].ToString();
        }

        /// <summary>
        /// Resets the boxes on the "Edit the First Selected Triangle"-Tab.
        /// </summary>
        /// <param name="sender">resetTriangleBoxesButton</param>
        /// <param name="e">Standard EventArgs</param>
        private void ResetTriangleBoxesButton_Click(object sender, EventArgs e) {
            FillTab();
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
                tri.Position = currentSelection[0].Position;
                Event temp = new Event(currentSelection[0], Event.EventType.Edit);
                history.Add(temp);
                triangleList.EditTriangle(tri);

                currentSelection.Clear();
                currentSelection.Add(tri);
                undoButton.Enabled = true;
                changed = true;
                SetOrigin();
                FillTab();
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
                tri.Position = currentSelection[0].Position;
                Event temp = new Event(currentSelection[0], Event.EventType.Edit);
                history.Add(temp);
                triangleList.EditTriangle(tri);

                currentSelection.Clear();
                currentSelection.Add(tri);
                undoButton.Enabled = true;
                changed = true;
                SetOrigin();
                FillTab();
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
        private void HookButton_EnabledChanged(object sender, EventArgs e) {
            hookButtonC.Enabled = hookButtonB.Enabled = hookButtonA.Enabled;
        }

        /// <summary>
        /// Enables the acceptButton, the acceptTriangleButton
        /// and the nextNeighborsButton simultaneously.
        /// </summary>
        /// <param name="sender">acceptButton</param>
        /// <param name="e">Standard EventArgs</param>
        private void AcceptButton_EnabledChanged(object sender, EventArgs e) {
            acceptTriangleButton.Enabled = nextNeighborsButton.Enabled = acceptButton.Enabled;
        }

        /// <summary>
        /// Marks the neighbor Triangles in the visualization.
        /// </summary>
        /// <param name="sender">aNeighbors or bNeighbors or cNeighbors ComboBox</param>
        /// <param name="e">Standard EventArgs</param>
        private void Neighbors_SelectedIndexChanged(object sender, EventArgs e) {
            if ((aNeighbors.SelectedItem != null) && (bNeighbors.SelectedItem != null) && (cNeighbors.SelectedItem != null)) {
                int[] neighbor = new int[3];
                neighbor[0] = (aNeighbors.SelectedItem as Vertex).Owner.Position;
                neighbor[1] = (bNeighbors.SelectedItem as Vertex).Owner.Position;
                neighbor[2] = (cNeighbors.SelectedItem as Vertex).Owner.Position;
                visualization.SetNeighborColors(neighbor);
                visualization.Refresh();
            }
        }

        #endregion

        #region Add/Remove Triangle

        /// <summary>
        /// Copies the values of the selected Triangle to the TextBoxes
        /// on the "Add/Remove Triangle"-Tab.
        /// </summary>
        /// <param name="sender">triangleCopyButton</param>
        /// <param name="e">Standard EventArgs</param>
        private void TriangleCopyButton_Click(object sender, EventArgs e) {
            aX2.Text = (triangleComboBox.SelectedItem as Triangle)[0][0].ToString();
            aY2.Text = (triangleComboBox.SelectedItem as Triangle)[0][1].ToString();
            aZ2.Text = (triangleComboBox.SelectedItem as Triangle)[0][2].ToString();
            bX2.Text = (triangleComboBox.SelectedItem as Triangle)[1][0].ToString();
            bY2.Text = (triangleComboBox.SelectedItem as Triangle)[1][1].ToString();
            bZ2.Text = (triangleComboBox.SelectedItem as Triangle)[1][2].ToString();
            cX2.Text = (triangleComboBox.SelectedItem as Triangle)[2][0].ToString();
            cY2.Text = (triangleComboBox.SelectedItem as Triangle)[2][1].ToString();
            cZ2.Text = (triangleComboBox.SelectedItem as Triangle)[2][2].ToString();
            normalX2.Text = (triangleComboBox.SelectedItem as Triangle)[3][0].ToString();
            normalY2.Text = (triangleComboBox.SelectedItem as Triangle)[3][1].ToString();
            normalZ2.Text = (triangleComboBox.SelectedItem as Triangle)[3][2].ToString();
        }

        /// <summary>
        /// Marks the Triangle selected in the triangleComboBox in the visualization
        /// and selects the corresponding Vertices in the vertices-ComboBoxes.
        /// </summary>
        /// <param name="sender">triangleComboBox</param>
        /// <param name="e">Standard EventArgs</param>
        private void TriangleComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            currentSelection.Clear();
            currentSelection.Add(triangleComboBox.SelectedItem as Triangle);
            UpdateAddRemoveTab();
        }

        /// <summary>
        /// Add the new Triangle to the triangleList, with the normal vector calculated by the CalculateNormal() method.
        /// </summary>
        /// <param name="sender">addTriangleButton</param>
        /// <param name="e">Standard EventArgs</param>
        private void AddTriangleButton_Click(object sender, EventArgs e) {
            try {
                Vertex a = new Vertex((float)Convert.ToDouble(aX2.Text), (float)Convert.ToDouble(aY2.Text), (float)Convert.ToDouble(aZ2.Text));
                Vertex b = new Vertex((float)Convert.ToDouble(bX2.Text), (float)Convert.ToDouble(bY2.Text), (float)Convert.ToDouble(bZ2.Text));
                Vertex c = new Vertex((float)Convert.ToDouble(cX2.Text), (float)Convert.ToDouble(cY2.Text), (float)Convert.ToDouble(cZ2.Text));
                Triangle tri = new Triangle(a, b, c);
                Event temp = new Event(currentSelection[0], Event.EventType.Add);
                history.Add(temp);
                triangleList.AddTriangle(tri);
                triangleList.Finish();

                undoButton.Enabled = true;
                changed = true;
                SetOrigin();
                visualization.SetPickingColors();
                FillTab();
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
                Vertex a = new Vertex((float)Convert.ToDouble(aX2.Text), (float)Convert.ToDouble(aY2.Text), (float)Convert.ToDouble(aZ2.Text));
                Vertex b = new Vertex((float)Convert.ToDouble(bX2.Text), (float)Convert.ToDouble(bY2.Text), (float)Convert.ToDouble(bZ2.Text));
                Vertex c = new Vertex((float)Convert.ToDouble(cX2.Text), (float)Convert.ToDouble(cY2.Text), (float)Convert.ToDouble(cZ2.Text));
                Vertex n = new Vertex((float)Convert.ToDouble(normalX2.Text), (float)Convert.ToDouble(normalY2.Text), (float)Convert.ToDouble(normalZ2.Text));
                Triangle tri = new Triangle(a, b, c, n);
                Event temp = new Event(currentSelection[0], Event.EventType.Add);
                history.Add(temp);
                triangleList.AddTriangle(tri);
                triangleList.Finish();

                undoButton.Enabled = true;
                changed = true;
                SetOrigin();
                visualization.SetPickingColors();
                FillTab();
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
            visualization.Fresh = false;
            Event temp = new Event((triangleComboBox.SelectedItem as Triangle), Event.EventType.Remove);
            history.Add(temp);
            triangleList.RemoveAt((triangleComboBox.SelectedItem as Triangle).Position);
            triangleList.Finish();
            triangleList.SetPositions();
            currentSelection.Clear();

            undoButton.Enabled = true;
            changed = true;
            SetOrigin();
            FillTab();
            visualization.SetPickingColors();
            if (triangleComboBox.Items.Count > 0) {
                triangleComboBox.SelectedIndex = 0;
            } else {
                visualization.Vertices = false;
            }
            visualization.Fresh = true;
        }

        /// <summary>
        /// Adjusts the values of the A-Vertex of the Triangle on the
        /// "Add/Remove Triangle"-Tab to the Vertex in the verticesA ComboBox.
        /// </summary>
        /// <param name="sender">aVertexHook</param>
        /// <param name="e">Standard EventArgs</param>
        private void AVertexHook_Click(object sender, EventArgs e) {
            aX2.Text = (verticesA.SelectedItem as Vertex)[0].ToString();
            aY2.Text = (verticesA.SelectedItem as Vertex)[1].ToString();
            aZ2.Text = (verticesA.SelectedItem as Vertex)[2].ToString();
        }

        /// <summary>
        /// Adjusts the values of the B-Vertex of the Triangle on the
        /// "Add/Remove Triangle"-Tab to the Vertex in the verticesB ComboBox.
        /// </summary>
        /// <param name="sender">bVertexHook</param>
        /// <param name="e">Standard EventArgs</param>
        private void BVertexHook_Click(object sender, EventArgs e) {
            bX2.Text = (verticesB.SelectedItem as Vertex)[0].ToString();
            bY2.Text = (verticesB.SelectedItem as Vertex)[1].ToString();
            bZ2.Text = (verticesB.SelectedItem as Vertex)[2].ToString();
        }

        /// <summary>
        /// Adjusts the values of the C-Vertex of the Triangle on the
        /// "Add/Remove Triangle"-Tab to the Vertex in the verticesC ComboBox.
        /// </summary>
        /// <param name="sender">cVertexHook</param>
        /// <param name="e">Standard EventArgs</param>
        private void CVertexHook_Click(object sender, EventArgs e) {
            cX2.Text = (verticesC.SelectedItem as Vertex)[0].ToString();
            cY2.Text = (verticesC.SelectedItem as Vertex)[1].ToString();
            cZ2.Text = (verticesC.SelectedItem as Vertex)[2].ToString();
        }


        private void VerticesA_SelectedIndexChanged(object sender, EventArgs e) {
            if (verticesA.SelectedItem != null) {
                triVertices[0] = (verticesA.SelectedItem as Vertex).Owner.Position;
                triVertices[1] = (verticesA.SelectedItem as Vertex).Owner.IndexOf(verticesA.SelectedItem as Vertex);
                visualization.Refresh();
            }
        }

        private void VerticesB_SelectedIndexChanged(object sender, EventArgs e) {
            if (verticesB.SelectedItem != null) {
                triVertices[2] = (verticesB.SelectedItem as Vertex).Owner.Position;
                triVertices[3] = (verticesB.SelectedItem as Vertex).Owner.IndexOf(verticesB.SelectedItem as Vertex);
                visualization.Refresh();
            }
        }

        private void VerticesC_SelectedIndexChanged(object sender, EventArgs e) {
            if (verticesC.SelectedItem != null) {
                triVertices[4] = (verticesC.SelectedItem as Vertex).Owner.Position;
                triVertices[5] = (verticesC.SelectedItem as Vertex).Owner.IndexOf(verticesC.SelectedItem as Vertex);
                visualization.Refresh();
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
                visualization.Fresh = false;
                FillTab();
                if (tabControl1.SelectedTab == tabPage2) {
                    // Neighbor colors
                    Neighbors_SelectedIndexChanged(sender, e);
                }
                visualization.Fresh = true;
            } else { tabControl1.SelectedTab = tabPage1; }
        }

        #endregion

    }
}