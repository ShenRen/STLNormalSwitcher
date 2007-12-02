using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace STLNormalSwitcher {
    public partial class TabPanel : UserControl {

        protected NormalSwitcherForm owner;

        public TabPanel() {
            InitializeComponent();
        }

        public virtual void UpdateTab() { }

        /// <summary>
        /// Prevents the user from entering anything, but a floating point number in the TextBoxes for
        /// editing or adding Triangles.
        /// </summary>
        /// <param name="sender">Any one of the TextBoxes for editing or adding Triangles</param>
        /// <param name="e">Standard KeyPressEventArgs</param>
        protected void TriangleValue_KeyPress(object sender, KeyPressEventArgs e) {
            if ((!char.IsNumber(e.KeyChar)) & (e.KeyChar != '.') & (e.KeyChar != '-') & (e.KeyChar != (char)Keys.Back)) {
                e.Handled = true;
            } else if (e.KeyChar == '.') {
                if ((sender as TextBox).Text.Contains(".")) {
                    e.Handled = true;
                }
            } else if (e.KeyChar == '-') {
                if ((sender as TextBox).Text.StartsWith("-")) {
                    e.Handled = true;
                } else {
                    int temp = (sender as TextBox).SelectionStart;
                    (sender as TextBox).Text = "-" + (sender as TextBox).Text;
                    (sender as TextBox).SelectionStart = temp + 1;
                    e.Handled = true;
                }
            }
        }
    }
}
