﻿// Part of STLNormalSwitcher: A program to switch normal vectors in STL-files
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
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Globalization;

namespace STLNormalSwitcher {
    /// <summary>
    /// The main class of the STLNormalSwitcher.
    /// </summary>
    internal static class STLNormalSwitcher {
        /// <summary>
        /// Main method sets the CurrentCulture and starts the Application.
        /// </summary>
        [STAThread]
        internal static void Main(string[] args) {
            Application.EnableVisualStyles();
            Application.CurrentCulture = new CultureInfo("en-US");
            if (args.Length == 0) {
                Application.Run(new NormalSwitcherForm());
            } else {
                if (args[1] == "Open") {
                    Application.Run(new NormalSwitcherForm(args[0]));
                }
            }
        }
    }
}