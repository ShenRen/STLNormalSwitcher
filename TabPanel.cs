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

        public virtual void UpdateTab(bool flag) { }
    }
}
