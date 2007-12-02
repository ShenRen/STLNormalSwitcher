using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace STLNormalSwitcher {
    public class Page : TabPage {

        private TabPanel panel;

        public Page(TabPanel panel, string name) {
            this.panel = panel;
            this.Controls.Add(panel);
            this.Text = name;
        }

        public void UpdateTab(bool flag) { panel.UpdateTab(flag); }
    }
}
