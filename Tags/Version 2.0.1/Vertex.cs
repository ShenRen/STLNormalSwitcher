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
    /// A Vertex can be either the corner of a Triangle or a normal vector.
    /// </summary>
    internal class Vertex : List<float> {

        #region Fields

        private Triangle owner;
        private string asString;

        #endregion

        #region Properties

        /// <value>Gets the owner or sets it</value>
        internal Triangle Owner {
            get { return owner; }
            set { owner = value; }
        }

        /// <value>Gets the Vertex as a string</value>
        public string AsString { get { return asString; } }

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
            asString = this.ToString();
        }

        #endregion

        #region Methods

        #region Operators

        /// <summary>
        /// Calculates the distance of this Vertex from the Vertex given by <paramref name="v2"/>.
        /// </summary>
        /// <param name="tri">Another Vertex</param>
        /// <returns>Distance between the Vertices</returns>
        internal double DistanceFrom(Vertex v2) {
            return Math.Pow(this[0] - v2[0], 2) + Math.Pow(this[1] - v2[1], 2) + Math.Pow(this[2] - v2[2], 2);
        }

        /// <summary>
        /// Calculates the Vertex's length, when seen as a vector
        /// </summary>
        /// <returns></returns>
        internal float Length() {
            return (float)System.Math.Sqrt(SqrLength());
        }

        /// <summary>
        /// Calculates the square of the Vertex's length, when seen as a vector
        /// </summary>
        /// <returns></returns>
        internal float SqrLength() {
            return this[0] * this[0] + this[1] * this[1] + this[2] * this[2];
        }

        /// <summary>
        /// Normalizes the Vertex, when seen as a vector, to a length of 1
        /// </summary>
        internal void Normalize() {
            float l = 1.0f / Length();
            this[0] *= l;
            this[1] *= l;
            this[2] *= l;
        }

        /// <summary>
        /// Calculate's the cross product (or inner product)
        /// </summary>
        /// <param name="v1">The first Vertex for the cross product</param>
        /// <param name="v2">The second Vertex for the cross product</param>
        /// <returns>The Cross product</returns>
        internal static Vertex Cross(Vertex v1, Vertex v2) {
            return new Vertex(v1[1] * v2[2] - v1[2] * v2[1], v1[2] * v2[0] - v1[0] * v2[2],
                v1[0] * v2[1] - v1[1] * v2[0]);
        }

        /// <summary>
        /// Calculates the difference of the given vertices.
        /// </summary>
        /// <param name="v1">The first Vertex</param>
        /// <param name="v2">The second Vertex</param>
        /// <returns>The Difference</returns>
        public static Vertex operator -(Vertex v1, Vertex v2) {
            return new Vertex(v1[0] - v2[0], v1[1] - v2[1], v1[2] - v2[2]);
        }

        /// <summary>
        /// Calculates the product of a Vertex and a factor
        /// </summary>
        /// <param name="factor">the factor</param>
        /// <param name="v">The Vertex</param>
        /// <returns>The Product</returns>
        public static Vertex operator *(float factor, Vertex v) {
            return new Vertex(v[0] * factor, v[1] * factor, v[2] * factor);
        }

        /// <summary>
        /// Calculates the cross product
        /// </summary>
        /// <param name="v1">The first Vertex for the cross product</param>
        /// <param name="v2">The second Vertex for the cross product</param>
        /// <returns>The Cross product</returns>
        public static Vertex operator %(Vertex v1, Vertex v2) {
            return Vertex.Cross(v1, v2);
        }

        /// <summary>
        /// Calculates the additive inverse.
        /// </summary>
        /// <param name="v">The Vertex</param>
        /// <returns>The Vertex times -1</returns>
        public static Vertex operator -(Vertex v) {
            return -1.0f * v;
        }


        #endregion

        /// <summary>
        /// Sets asString to the correct value;
        /// </summary>
        internal void Finish() {
            asString = this.ToString();
        }

        /// <summary>
        /// Returns a copy of this Vertex.
        /// </summary>
        /// <returns>Copy of this Vertex</returns>
        internal Vertex Copy() { return new Vertex(this[0], this[1], this[2]); }

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
                if (this.asString == (obj as Vertex).AsString) {
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
