// Part of STLNormalSwitcher: A program to switch normal vectors in STL-files
//
// Copyright (C) 2007  PG500, ISF, University of Dortmund
//      PG500 are: Christoph Begau, Christoph Heuel, Raffael Joliet, Jan Kolanski,
//                 Mandy Kr�ller, Christian Moritz, Daniel Niggemann, Mathias St�ber,
//                 Timo St�nner, Jan Varwig, Dafan Zhai
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
    /// A Vertex can be either the corner of a Triangle or a normal vector.
    /// </summary>
    internal class Vertex : List<float> {

        #region Fields

        private Triangle owner;

        #endregion

        #region Properties

        /// <value>Gets the owner or sets it</value>
        internal Triangle Owner {
            get { return owner; }
            set { owner = value; }
        }

        /// <value>Gets the Vertex as a string</value>
        public string AsString { get { return this.ToString(); } }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new threedimensional vertex.
        /// </summary>
        /// <param name="x">x-coordinate</param>
        /// <param name="y">y-coordinate</param>
        /// <param name="z">z-coordinate</param>
        internal Vertex(float x, float y, float z) {
            this.Add(x);
            this.Add(y);
            this.Add(z);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a copy of this Vertex.
        /// </summary>
        /// <returns>Copy of this Vertex</returns>
        internal Vertex Copy() { return new Vertex(this[0], this[1], this[2]); }

        /// <summary>
        /// Calculates the distance of this Vertex from the Vertex given by <paramref name="v2"/>.
        /// </summary>
        /// <param name="tri">Another Vertex</param>
        /// <returns>Distance between the Vertices</returns>
        internal double DistanceFrom(Vertex v2) {
            return Math.Pow(this[0] - v2[0], 2) + Math.Pow(this[1] - v2[1], 2) + Math.Pow(this[2] - v2[2], 2);
        }

        /// <summary>
        /// Normalizes this Vertex, so the vector it represents has length 1.
        /// </summary>
        /// <returns>The normalized Vertex</returns>
        internal Vertex Normalize() {
            if ((this[0] == 0) && (this[1] == 0) && (this[2] == 0)) {
                throw new ArgumentException("The normal vector can not be [0,0,0]!");
            }
            double factor = Math.Sqrt(Math.Pow(this[0], 2) + Math.Pow(this[1], 2) + Math.Pow(this[2], 2));
            for (int i = 0; i < 3; i++) {
                this[i] /= (float)factor;
            }
            return this;
        }

        /// <summary>
        /// Returns the Vertex as a string.
        /// </summary>
        /// <returns>Vertex as a string</returns>
        public override string ToString() {
            string value = "[" + this[0].ToString() + ", " + this[1].ToString() + ", " + this[2].ToString() + "]";
            return value;
        }

        /// <summary>
        /// Compares this Vertex to a given object.
        /// Two vertices are equal, when their values are the same,
        /// they can have different owners.
        /// </summary>
        /// <param name="obj">An other Vertex</param>
        /// <returns>true, if obj == this</returns>
        public override bool Equals(object obj) {
            if (obj is Vertex) {
                if ((this[0] == (obj as Vertex)[0]) && (this[1] == (obj as Vertex)[1]) && (this[1] == (obj as Vertex)[1])) {
                    return true;
                } else { return false; }
            } else { return base.Equals(obj); }
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }

        #endregion

    }
}
