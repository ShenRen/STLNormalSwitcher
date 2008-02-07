// Part of STLNormalSwitcher: A program to switch normal vectors in STL-files
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

namespace STLNormalSwitcher {
    /// <summary>
    /// A list of Triangles with some extras. The minimum and maximum coordinates of all Triangles
    /// in the list are available. A scale and the vertices and normals as arrays used for drawing
    /// are also contained in the TriangleList.
    /// </summary>
    internal class TriangleList : List<Triangle> {

        #region Fields

        private float[] min = new float[3] { 0, 0, 0 };
        private float[] max = new float[3] { 0, 0, 0 };
        private float[] center = new float[3] { 0, 0, 0 };
        private float scale;
        private float[] vertexArray;
        private float[] normalArray;
        private List<Vertex> vertices = new List<Vertex>();

        #endregion

        #region Properties

        /// <value>Gets the normalized vertices of all triangles in an array</value>
        internal float[] VertexArray { get { return vertexArray; } }

        /// <value>Gets the normal vectors of all triangles expanded to all corners as an array</value>
        internal float[] NormalArray { get { return normalArray; } }

        /// <value>Gets a list of all vertices of all Triangles</value>
        internal Vertex[] Vertices { get { return vertices.ToArray(); } }

        /// <value>Gets the scale used for drawing</value>
        internal float Scale { get { return scale; } }

        /// <value>Gets the center of the object</value>
        internal float[] Center { get { return center; } }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a new Triangle to the TriangleList, sets its position and recalculates
        /// the minimum and maximum of the TriangleList.
        /// </summary>
        /// <param name="tri">The Triangle to be added</param>
        internal void AddTriangle(Triangle tri) {
            this.Add(tri);
            tri.Position = this.Count - 1;
        }


        /// <summary>
        /// Recalculates both the vertex- and the normalArray.
        /// </summary>
        internal void CalculateArrays() {
            CalculateNormalArray();
            CalculateVertexArray();
        }

        /// <summary>
        /// The normalArray is calculated. The normal vectors of the triangles are copied to
        /// all three corners of the corresponding triangle and saved in an array.
        /// </summary>
        internal void CalculateNormalArray() {
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
        internal void CalculateVertexArray() {
            vertexArray = new float[9 * this.Count];
            for (int i = 0; i < this.Count; i++) {
                for (int j = 0; j < 3; j++) {
                    for (int k = 0; k < 3; k++) {
                        vertexArray[i * 9 + j * 3 + k] = this[i][j][k];
                    }
                }
            }
        }

        /// <summary>
        /// Returns a copy of the TriangleList.
        /// </summary>
        /// <returns>Copy of the TriangleList</returns>
        internal TriangleList Copy() {
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
        internal void EditTriangle(Triangle newTriangle) {
            this[newTriangle.Position] = newTriangle;
            Finish();
        }

        /// <summary>
        /// Fills "vertices" with all vertices from all Triangles,
        /// every Vertex is in the list only once.
        /// </summary>
        internal void FillVertexList() {
            vertices.Clear();
            SortedList<string, Vertex> tmp = new SortedList<string, Vertex>();
            string key;
            for (int i = 0; i < this.Count; i++) {
                for (int j = 0; j < 3; j++) {
                    key = this[i][j].AsString;
                    if (!tmp.ContainsKey(key)) {
                        tmp.Add(key, this[i][j]);
                    }
                }
            }

            for (int i = 0; i < tmp.Count; i++) {
                vertices.Add(tmp.Values[i]);
            }
        }

        /// <summary>
        /// Calculates the scale as the maximum of the differences between the maxima and minima.
        /// </summary>
        internal void Finish() {
            SetExtrema();

            CalculateArrays();
            FillVertexList();
        }

        /// <summary>
        /// Sets the position of each Triangle to the correct position in this list.
        /// </summary>
        internal void SetPositions() {
            for (int i = 0; i < this.Count; i++) {
                this[i].Position = i;
            }

            Finish();
        }

        /// <summary>
        /// Calculates the extrema, the scale and the center.
        /// </summary>
        private void SetExtrema() {
            for (int k = 0; k < 3; k++) {
                min[k] = this[0].Min[k];
                max[k] = this[0].Max[k];
            }

            for (int i = 1; i < this.Count; i++) {
                for (int j = 0; j < 3; j++) {
                    if (this[i].Min[j] < min[j]) { min[j] = this[i].Min[j]; }
                    if (this[i].Max[j] > max[j]) { max[j] = this[i].Max[j]; }
                }
            }

            for (int i = 0; i < 3; i++) {
                center[i] = (max[i] + min[i]) / 2;
            }

            scale = max[0] - min[0];
            if (max[1] - min[1] > scale) { scale = max[1] - min[1]; }
            if (max[2] - min[2] > scale) { scale = max[2] - min[2]; }
        }

        /// <summary>
        /// Changes the orientation of all Triangles.
        /// </summary>
        internal void ReorientAll() {
            for (int i = 0; i < this.Count; i++) {
                this[i].Reorient();
            }
        }

        /// <summary>
        /// Changes the orientation of the selected Triangles.
        /// </summary>
        internal void ReorientSelected(List<Triangle> selection) {
            for (int i = 0; i < selection.Count; i++) {
                this[selection[i].Position].Reorient();
            }
        }

        /// <summary>
        /// Switches the normal vectors of all Triangles.
        /// </summary>
        internal void SwitchAll() {
            for (int i = 0; i < this.Count; i++) {
                this[i].SwitchNormal();
            }

            CalculateNormalArray();
        }

        /// <summary>
        /// Switches only the normal vectors of the selected Triangles.
        /// </summary>
        /// <param name="selection">A List of Triangles</param>
        internal void SwitchSelected(List<Triangle> selection) {
            for (int i = 0; i < selection.Count; i++) {
                this[selection[i].Position].SwitchNormal();
            }

            CalculateNormalArray();
        }

        #endregion
    }
}
