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
    /// The TabPanel that lists the Triangles.
    /// </summary>
    internal class ListPanel : TabPanel {

        #region Designer

        private System.Windows.Forms.ListView normalListView;
        private System.Windows.Forms.ColumnHeader columnHeader0;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;

        private void InitializeComponent() {
            this.normalListView = new System.Windows.Forms.ListView();
            this.columnHeader0 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
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
            this.normalListView.Location = new System.Drawing.Point(0, 0);
            this.normalListView.Name = "normalListView";
            this.normalListView.ShowGroups = false;
            this.normalListView.Size = new System.Drawing.Size(739, 222);
            this.normalListView.TabIndex = 3;
            this.normalListView.UseCompatibleStateImageBehavior = false;
            this.normalListView.View = System.Windows.Forms.View.Details;
            this.normalListView.SelectedIndexChanged += new System.EventHandler(this.NormalListView_SelectedIndexChanged);
            this.normalListView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.NormalListView_MouseUp);
            this.normalListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.NormalListView_ColumnClick);
            this.normalListView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NormalListView_KeyUp);
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
            // ListPanel
            // 
            this.Controls.Add(this.normalListView);
            this.Name = "ListPanel";
            this.ResumeLayout(false);

        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes the panel and sets the owner.
        /// </summary>
        /// <param name="owner">The NormalSwitcherForm that contains this ListPanel</param>
        internal ListPanel(NormalSwitcherForm owner) {
            InitializeComponent();
            this.owner = owner;

            owner.SizeChanged += Owner_SizeChanged;

            Owner_SizeChanged(new object(), new EventArgs());
        }

        #endregion

        #region Methods

        /// <summary>
        /// The main method of all TabPanels. Updates the elements on the panel.
        /// </summary>
        /// <param name="flag">The ListView is only refilled, when flag == true</param>
        internal override void UpdateTab(bool flag) {
            owner.Visualization.Vertices = new bool[3] { false, false, false };
            owner.Visualization.Fresh = false;
            owner.Visualization.Corners = false;

            normalListView.BeginUpdate();
            normalListView.Sorting = SortOrder.None;

            if (flag) {
                normalListView.Items.Clear();
                for (int i = 0; i < owner.TriangleList.Count; i++) {
                    normalListView.Items.Add(new ListViewItem(new string[4] { owner.TriangleList[i].NormalToString(),
                    owner.TriangleList[i][0].ToString(), owner.TriangleList[i][1].ToString(), owner.TriangleList[i][2].ToString() }));
                    normalListView.Items[i].Tag = i;
                }
            }

            normalListView.SelectedIndexChanged -= NormalListView_SelectedIndexChanged;
            normalListView.SelectedIndices.Clear();
            for (int j = 0; j < owner.CurrentSelection.Count; j++) {
                if (owner.CurrentSelection[j] != null) {
                    normalListView.SelectedIndices.Add(owner.CurrentSelection[j].Position);
                }
            }
            normalListView.SelectedIndexChanged += NormalListView_SelectedIndexChanged;

            if (normalListView.SelectedItems.Count > 0) {
                normalListView.TopItem = normalListView.SelectedItems[0];
            }

            normalListView.EndUpdate();

            owner.RefreshVisualization();
        }

        #endregion

        #region Event Handling Stuff

        /// <summary>
        /// Updates the currentSelection and marks the selected triangles in the NormalSwitcherControl.
        /// </summary>
        /// <param name="sender">normalListView</param>
        /// <param name="e">Standard EventArgs</param>
        private void NormalListView_SelectedIndexChanged(object sender, EventArgs e) {
            if ((Control.ModifierKeys != Keys.Control) && (Control.ModifierKeys != Keys.Shift) && (Control.ModifierKeys != (Keys.Control | Keys.Shift)) && (Control.MouseButtons != MouseButtons.Left)) {
                Event temp = new Event();
                if (normalListView.SelectedItems.Count >= 1) {
                    for (int j = 0; j < normalListView.SelectedItems.Count; j++) {
                        temp.Add(owner.TriangleList[(int)normalListView.SelectedItems[j].Tag]);
                    }
                }
                owner.CurrentSelection = temp;

                owner.RefreshVisualization();
            }
        }

        /// <summary>
        /// Triggers an update of the currentSelection, when the ControlKey or the ShiftKey is released.
        /// </summary>
        /// <param name="sender">ControlKey or ShiftKey</param>
        /// <param name="e">Standard KeyEventArgs</param>
        private void NormalListView_KeyUp(object sender, KeyEventArgs e) {
            NormalListView_SelectedIndexChanged(sender, e);
        }

        /// <summary>
        /// Triggers an update of the currentSelection, when the left MouseButton is released.
        /// </summary>
        /// <param name="sender">Left MouseButton</param>
        /// <param name="e">Standard MouseEventArgs.</param>
        private void NormalListView_MouseUp(object sender, MouseEventArgs e) {
            NormalListView_SelectedIndexChanged(sender, e);
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

            if (normalListView.SelectedItems.Count > 0) {
                normalListView.TopItem = normalListView.SelectedItems[0];
            }
        }

        /// <summary>
        /// Stretches the columns of normalListView to fit the NormalSwitcherForm.
        /// </summary>
        /// <param name="sender">The NormalSwitcherForm</param>
        /// <param name="e">Standard EventArgs</param>
        private void Owner_SizeChanged(object sender, EventArgs e) {
            normalListView.Columns[0].Width = normalListView.Columns[1].Width =
                normalListView.Columns[2].Width = normalListView.Columns[3].Width =
                this.Width / 4;
        }

        #endregion
    }
}
