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
using System.IO;
using System.Windows.Forms;
using System.Globalization;

namespace STLNormalSwitcher {
    /// <summary>
    /// A parser for Binary or ASCII STL-files.
    /// </summary>
    public class STLParser {

        #region Fields

        private TriangleList triangleList = new TriangleList();
        private bool ascii;

        #endregion

        #region Properties

        /// <value>Gets the triangleList</value>
        public TriangleList TriangleList { get { return triangleList; } }

        /// <value>Gets true if the parsed file is an ASCII file</value>
        public bool ASCII { get { return ascii; } }

        #endregion

        #region Methods

        /// <summary>
        /// Parse the given Stream.
        /// </summary>
        /// <param name="file">Stream to parse</param>
        public void Parse(StreamReader file) {
            // First test, if the stream is ASCII or binary
            if (ascii = TestIfASCII(file)) {
                ParseASCII(file);
            } else {
                ParseBinary(file);
            }
        }

        /// <summary>
        /// Parses a binary STL file.
        /// </summary>
        /// <remarks>
        /// Because ASCII STL files can become very large, a binary version of STL exists. 
        /// A binary STL file has an 80 character header (which is generally ignored - but 
        /// which should never begin with 'solid' because that will lead most software to assume 
        /// that this is an ASCII STL file). Following the header is a 4 byte unsigned 
        /// integer indicating the number of triangular facets in the file. Following that 
        /// is data describing each triangle in turn. The file simply ends after the last triangle.
        /// Each triangle is described by twelve floating point numbers: three for the normal 
        /// and then three for the X/Y/Z coordinate of each vertex - just as with the ASCII version 
        /// of STL. After the twelve floats there is a two byte unsigned 'short' integer that 
        /// is the 'attribute byte count' - in the standard format, this should be zero because most 
        /// software does not understand anything else.( http://en.wikipedia.org/wiki/STL_(file_format) )
        /// </remarks>
        /// <param name="file">Stream to parse</param>
        private void ParseBinary(StreamReader file) {
            BinaryReader binReader = new BinaryReader(file.BaseStream);

            // Set stream back to null
            binReader.BaseStream.Position = 0;
            char[] charBuf = new char[80];

            // The first 80 bytes are trash
            binReader.Read(charBuf, 0, 80);

            // Next 4 bytes contain the count of the normal/3D-vertexes record
            int count = (int)binReader.ReadUInt32();

            // Throw InvalidDataException if size does not fit
            // 84 Byte for header+count, count * (size of data = 50 Bytes)
            if (binReader.BaseStream.Length != (84 + count * 50)) {
                throw new InvalidDataException();
            }

            try {

                // Read the records
                for (int i = 0; i < count; i++) {
                    Vertex[] tmp = new Vertex[4] { new Vertex(0, 0, 0), new Vertex(0, 0, 0), new Vertex(0, 0, 0), new Vertex(0, 0, 0) };

                    // Normal/vertices

                    // First one is the normal
                    for (int j = 0; j < 3; j++) {
                        tmp[3][j] = binReader.ReadSingle();
                    }

                    // Next three are vertices
                    for (int k = 0; k < 3; k++) {
                        for (int h = 0; h < 3; h++) {
                            tmp[k][h] = binReader.ReadSingle();
                        }
                    }

                    // Last two bytes are only to fill up to 50 bytes
                    binReader.Read(charBuf, 0, 2);

                    triangleList.AddTriangle(new Triangle(tmp));
                }

            } catch {
                MessageBox.Show("Parser-Error", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                binReader.Close();
                triangleList.Finish();
            }
        }

        /// <summary>
        /// Parse STL-ASCII-Format.
        /// </summary>
        /// <param name="file">Stream to parse</param>
        private void ParseASCII(StreamReader file) {
            String input = null;
            int count = 0;

            NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
            numberFormatInfo.NumberDecimalSeparator = ".";

            file.BaseStream.Position = 0;
            StreamReader sr = new StreamReader(file.BaseStream);

            Vertex[] tmp = new Vertex[4] { new Vertex(0, 0, 0), new Vertex(0, 0, 0), new Vertex(0, 0, 0), new Vertex(0, 0, 0) };

            try {
                while ((input = sr.ReadLine()) != null) {
                    input = input.Trim();
                    if (count == 4) {
                        count = 0;
                        triangleList.AddTriangle(new Triangle(tmp));
                        tmp = new Vertex[4] { new Vertex(0, 0, 0), new Vertex(0, 0, 0), new Vertex(0, 0, 0), new Vertex(0, 0, 0) };
                    }

                    // RemoveEmptyEntities removes empty entities, resulting from more than one whitespace
                    String[] v = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (v.Length > 0) {
                        if (v[0].ToLower() == "vertex") {
                            // Parse string, NumberStyles.Float secures that different formats can be parsed
                            // such as: "-2.23454e-001" (exponential format)
                            for (int i = 0; i < 3; i++) {
                                tmp[count - 1][i] = float.Parse(v[i+1], NumberStyles.Float, numberFormatInfo);
                            }
                            count++;
                        } else if (v[0].ToLower() == "facet") {
                            for (int j = 0; j < 3; j++) {
                                tmp[3][j] = float.Parse(v[j+2], NumberStyles.Float, numberFormatInfo);
                            }
                            count++;
                        }
                    }
                }
            } catch {
                MessageBox.Show("Parser-Error", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                sr.Close();
                triangleList.Finish();
            }
        }

        /// <summary>
        /// Tests whether the file is ASCII. This is true, if the file contains "vertex" and "normal".
        /// </summary>
        /// <param name="file">file to be tested</param>
        /// <returns>true, if it is ASCII. Otherwise false.</returns>
        private bool TestIfASCII(StreamReader file) {
            bool foundVertex = false;
            bool foundNormal = false;
            String input = "";
            while ((input = file.ReadLine()) != null) {
                input = input.Trim();
                String[] v = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (0 != v.Length) {
                    if ("vertex" == v[0].ToLower()) {
                        foundVertex = true;
                    } else if ("facet" == v[0].ToLower()) {
                        foundNormal = true;
                    }
                }
                if (foundNormal && foundVertex) { return true; }
            }
            return (foundVertex && foundNormal);
        }

        #endregion
    }
}
