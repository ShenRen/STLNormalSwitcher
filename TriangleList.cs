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
using System.Text;

namespace STLNormalSwitcher {
    /// <summary>
    /// A list of Triangles with some extras. The minimum and maximum coordinates of all Triangles
    /// in the list are available. A scale and the vertices and normals as arrays used for drawing
    /// are also contained in the TriangleList.
    /// </summary>
    public class TriangleList : List<Triangle> {

        #region Fields

        private float[] min;
        private float[] max;
        private float scale;
        private float[] vertexArray;
        private float[] normalArray;

        #endregion

        #region Properties

        /// <value>Gets the normalized vertices of all triangles in an array</value>
        public float[] VertexArray { get { return vertexArray; } }

        /// <value>Gets the normal vectors of all triangles expanded to all corners as an array</value>
        public float[] NormalArray { get { return normalArray; } }

        /// <value>Gets the scale used for drawing</value>
        public float Scale { get { return scale; } }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new empty TriangleList with minimum and maximum at 0.
        /// </summary>
        public TriangleList() {
            this.min = new float[3] { 0, 0, 0 };
            this.max = new float[3] { 0, 0, 0 };
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a new Triangle to the TriangleList, sets its position and recalculates
        /// the minimum and maximum of the TriangleList.
        /// </summary>
        /// <param name="tri">The Triangle to be added</param>
        public void AddTriangle(Triangle tri) {
            this.Add(tri);
            tri.Position = this.Count - 1;
            for (int i = 0; i < 3; i++) {
                if (tri.Min[i] < min[i]) { min[i] = tri.Min[i]; }
                if (tri.Max[i] > max[i]) { max[i] = tri.Max[i]; }
            }
        }


        /// <summary>
        /// Recalculates both the vertex- and the normalArray.
        /// </summary>
        public void CalculateArrays() {
            CalculateNormalArray();
            CalculateVertexArray();
        }

        /// <summary>
        /// The normalArray is calculated. The normal vectors of the triangles are copied to
        /// all three corners of the corresponding triangle and saved in an array.
        /// </summary>
        public void CalculateNormalArray() {
            normalArray = new float[9 * this.Count];
            for (int i = 0; i < this.Count; i++) {
                for (int j = 0; j < 3; j++) {
                    for (int k = 0; k < 3; k++) {
                        normalArray[i * 9 + j * 3 + k] = this[i][3][k];
                    }
                }
            }
        }

        /// <summary>
        /// The vertexArray is calculated. All vertices of all triangles are normalized
        /// and saved in an array.
        /// </summary>
        public void CalculateVertexArray() {
            vertexArray = new float[9 * this.Count];
            for (int i = 0; i < this.Count; i++) {
                for (int j = 0; j < 3; j++) {
                    for (int k = 0; k < 3; k++) {
                        vertexArray[i * 9 + j * 3 + k] = scale * (((this[i][j][k] - min[k]) / (scale)) - 0.5f);
                    }
                }
            }
        }

        /// <summary>
        /// Returns a copy of the TriangleList.
        /// </summary>
        /// <returns>Copy of the TriangleList</returns>
        public TriangleList Copy() {
            TriangleList tri = new TriangleList();
            for (int i = 0; i < this.Count; i++) {
                tri.AddTriangle(this[i].Copy());
            }
            tri.Finish();
            return tri;
        }

        /// <summary>
        /// Replaces a Triangle in the TriangleList with a new Triangle and recalculates the minimum and maximum.
        /// </summary>
        /// <param name="newTriangle"></param>
        public void EditTriangle(Triangle newTriangle) {
            this[newTriangle.Position] = newTriangle;
            for (int i = 0; i < 3; i++) {
                if (newTriangle.Min[i] < min[i]) { min[i] = newTriangle.Min[i]; }
                if (newTriangle.Max[i] < max[i]) { max[i] = newTriangle.Max[i]; }
            }

            Finish();
        }

        /// <summary>
        /// Calculates the scale as the maximum of the differences between the maxima and minima.
        /// </summary>
        public void Finish() {
            scale = max[0] - min[0];
            if (max[1] - min[1] > scale) { scale = max[1] - min[1]; }
            if (max[2] - min[2] > scale) { scale = max[2] - min[2]; }

            CalculateArrays();
        }

        /// <summary>
        /// Switches the normal vectors of all Triangles.
        /// </summary>
        public void SwitchAll() {
            for (int i = 0; i < this.Count; i++) {
                this[i].SwitchNormal();
            }

            CalculateNormalArray();
        }

        /// <summary>
        /// Switches only the normal vectors of the selected Triangles.
        /// </summary>
        /// <param name="selection">A List of Triangles</param>
        public void SwitchSelected(List<Triangle> selection) {
            for (int i = 0; i < selection.Count; i++) {
                this[selection[i].Position].SwitchNormal();
            }

            CalculateNormalArray();
        }

        #endregion
    }
}
