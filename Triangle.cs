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
    /// This class represents a triangle. It is basically just a list of Vertices, with a few extras.
    /// There are supposed to be three vertices for the corners of the triangle, and the last one is
    /// for the normal vector. (Attention: Since it is just a list, it could be abused and have more vertices)
    /// It also contains the minimum and maximum coordinates of the triangle.
    /// In addition it can contain the position of the triangle in a TriangleList.
    /// </summary>
    public class Triangle : List<Vertex> {

        #region Fields

        private float[] max = new float[3] { 0, 0, 0 };
        private float[] min = new float[3] { 0, 0, 0 };
        private int position = -1;

        #endregion

        #region Properties

        /// <value>Gets the Triangle as a string</value>
        public string AsString { get { return this.ToString(); } }

        /// <value>Gets the maximum coordinates</value>
        public float[] Max { get { return max; } }

        /// <value>Gets the minimum coordinates</value>
        public float[] Min { get { return min; } }

        /// <value>Gets the position in the TriangleList or sets it.</value>
        public int Position {
            get { return position; }
            set { position = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// A constructor that creates a new Triangle from the given <paramref name="vertices"/>.
        /// There should be three vertices for the corners of the triangle, and a last one
        /// for the normal vector.
        /// </summary>
        /// <param name="vertices">The corners of the triangle and the normal vector</param>
        public Triangle(IEnumerable<Vertex> vertices) {
            this.AddRange(vertices);

            for (int i = 0; i < this.Count; i++) {
                this[i].Owner = this;
            }

            SetExtrema();
        }

        /// <summary>
        /// This constructor creates a new Triangle from the given corners and
        /// calculates the normal vector of that triangle.
        /// </summary>
        /// <param name="a">The first corner</param>
        /// <param name="b">The second corner</param>
        /// <param name="c">The third corner</param>
        public Triangle(Vertex a, Vertex b, Vertex c) {
            this.Add(a);
            this.Add(b);
            this.Add(c);
            if (!IsTriangle()) { throw new ArgumentException("The selected vertices do not form a triangle!"); }
            this.Add(CalculateNormal());

            for (int i = 0; i < this.Count; i++) {
                this[i].Owner = this;
            }

            SetExtrema();
        }

        /// <summary>
        /// This constructor creates a new Triangle from the given corners and
        /// the normalizes the given normal vector.
        /// </summary>
        /// <param name="a">The first corner</param>
        /// <param name="b">The second corner</param>
        /// <param name="c">The third corner</param>
        /// <param name="n">The normal vector</param>
        public Triangle(Vertex a, Vertex b, Vertex c, Vertex n) {
            this.Add(a);
            this.Add(b);
            this.Add(c);
            if (!IsTriangle()) { throw new ArgumentException("The selected vertices do not form a triangle!"); }
            this.Add(n.Normalize());

            for (int i = 0; i < this.Count; i++) {
                this[i].Owner = this;
            }

            SetExtrema();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Calculates the normal vector for the triangle.
        /// </summary>
        /// <returns>The normal vector</returns>
        private Vertex CalculateNormal() {
            Vertex ab = new Vertex(this[1][0] - this[0][0], this[1][1] - this[0][1], this[1][2] - this[0][2]);
            Vertex ac = new Vertex(this[2][0] - this[0][0], this[2][1] - this[0][1], this[2][2] - this[0][2]);

            Vertex n = new Vertex(ab[1] * ac[2] - ab[2] * ac[1], ab[2] * ac[0] - ab[0] * ac[2], ab[0] * ac[1] - ab[1] * ac[0]);

            double factor = 0;
            for (int i = 0; i < 3; i++) {
                n[i] = this[0][i] - n[i];
                factor += n[i] * n[i];
            }
            factor = Math.Sqrt(factor);
            for (int i = 0; i < 3; i++) {
                n[i] /= (float)factor;
            }

            return n;
        }

        /// <summary>
        /// Returns a copy of this Triangle.
        /// </summary>
        /// <returns>A copy of this Triangle</returns>
        public Triangle Copy() {
            Triangle tri = new Triangle(new Vertex[4] { this[0].Copy(), this[1].Copy(), this[2].Copy(), this[3].Copy() });
            tri.Position = this.position;
            return tri;
        }

        /// <summary>
        /// Checks, whether the vertices really form a triangle or are alligned.
        /// </summary>
        /// <returns>true, if the vertices form a triangle</returns>
        private bool IsTriangle() {
            Vertex ab = new Vertex(this[1][0] - this[0][0], this[1][1] - this[0][1], this[1][2] - this[0][2]);
            Vertex ac = new Vertex(this[2][0] - this[0][0], this[2][1] - this[0][1], this[2][2] - this[0][2]);
            float[] factors = new float[3];

            for (int i = 0; i < 3; i++) {
                factors[i] = ab[i] / ac[i];  
            }

            if ((float.IsNaN(factors[0]) && float.IsNaN(factors[1]) && float.IsNaN(factors[2])) ||
            (float.IsNaN(factors[0]) && float.IsNaN(factors[1])) ||
            (float.IsNaN(factors[0]) && float.IsNaN(factors[2])) ||
            (float.IsNaN(factors[1]) && float.IsNaN(factors[2]))) {
                return false;
            } else if (float.IsNaN(factors[0])) {
                if (factors[1] == factors[2]) { return false; } else { return true; }
            } else if (float.IsNaN(factors[1])) {
                if (factors[0] == factors[2]) { return false; } else { return true; }
            } else if (float.IsNaN(factors[2])) {
                if (factors[0] == factors[1]) { return false; } else { return true; }
            } else {
                if ((factors[0] == factors[1]) && (factors[1] == factors[2])) { return false; } else { return true; }
            }
        }

        /// <summary>
        /// Returns the normal vector as a string.
        /// </summary>
        /// <returns>The normal vector as a string</returns>
        public string NormalToString() {
            return this[3].ToString();
        }

        /// <summary>
        /// Calculates the minimum and maximum coordinates of this triangle
        /// </summary>
        private void SetExtrema() {
            for (int i = 0; i < 3; i++) {
                if (this[1][i] <= this[0][i]) {
                    min[i] = this[1][i];
                    max[i] = this[0][i];
                } else {
                    min[i] = this[0][i];
                    max[i] = this[1][i];
                }

                if (this[2][i] < min[i]) { min[i] = this[2][i]; }
                if (this[2][i] > max[i]) { max[i] = this[2][i]; }
            }
        }

        /// <summary>
        /// Switches the normal vector. Each value of the normal is multiplied by -1.
        /// </summary>
        public void SwitchNormal() {
            for (int i = 0; i < 3; i++) {
                this[3][i] *= -1;
            }
        }

        /// <summary>
        /// Returns a string containing the corners of this Triangle as strings.
        /// </summary>
        /// <returns>The corners of this Triangle as a string</returns>
        public override string ToString() {
            string triangle = "{" + this[0].ToString() + " " + this[1].ToString() + " " + this[2].ToString() + "}";
            return triangle;
        }

        #endregion
    }
}
