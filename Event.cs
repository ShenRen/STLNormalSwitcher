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

namespace STLNormalSwitcher {
    /// <summary>
    /// A list of Triangles with additional information
    /// about the type of changes made.
    /// </summary>
    public class Event : List<Triangle> {

        /// <summary>
        /// Enumeration for the different types of Events
        /// </summary>
        public enum EventType { SwitchAll, Edit, Add, Remove }

        #region Fields

        public EventType eventType;

        #endregion

        #region Constructors

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public Event() { }

        /// <summary>
        /// Constructor that sets the EventType
        /// </summary>
        /// <param name="type">EventType</param>
        public Event(EventType type) { this.eventType = type; }

        /// <summary>
        /// Constructor that adds a single Triangle to the list
        /// and sets the EventType.
        /// </summary>
        /// <param name="triangle">Triangle to be added.</param>
        /// <param name="type">EventType</param>
        public Event(Triangle triangle, EventType type) {
            this.Add(triangle);
            this.eventType = type;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a copy of this Event.
        /// </summary>
        /// <returns>Copy of this Event</returns>
        public Event Copy() {
            Event ev = new Event(this.eventType);
            for (int i = 0; i < this.Count; i++) {
                ev.Add(this[i].Copy());
            }
            return ev;
        }

        #endregion
    }

}
