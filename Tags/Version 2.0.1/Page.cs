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
    /// A TabPage that contains a TabPanel and a method UpdateTab to call that TabPanels UpdateTab-method.
    /// </summary>
    internal class Page : TabPage {

        #region Fields

        private TabPanel panel;

        #endregion

        #region Properties

        /// <value>Sets the value of panel.Changed</value>
        internal bool Changed { set { panel.Changed = value; }}

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes the Page.
        /// </summary>
        /// <param name="panel">The TabPanel to be included in this Page</param>
        /// <param name="name">The text to be displayed on the tab</param>
        internal Page(TabPanel panel, string name) {
            this.panel = panel;
            this.Controls.Add(panel);
            this.Text = name;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Updates the panel.
        /// </summary>
        internal void UpdateTab() { panel.UpdateTab(); }

        #endregion
    }
}
