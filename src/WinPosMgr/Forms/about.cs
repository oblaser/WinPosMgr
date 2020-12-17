using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinPosMgr.Forms
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.icon;
            this.Text = Properties.Strings.about_title;

            this.textBox1.Text = "License\r\n" +
"\r\n" +
"GNU GPL v3\r\n" +
"\r\n" +
"Copyright (C) 2020  Oliver Blaser\r\n" +
"\r\n" +
"This program is free software: you can redistribute it and/or modify " +
"it under the terms of the GNU General Public License as published by " +
"the Free Software Foundation, either version 3 of the License, or " +
"(at your option) any later version.\r\n" +
"\r\n" +
"This program is distributed in the hope that it will be useful, " +
"but WITHOUT ANY WARRANTY; without even the implied warranty of " +
"MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the " +
"GNU General Public License for more details.\r\n" +
"\r\n" +
"You should have received a copy of the GNU General Public License " +
"along with this program.  If not, see https://www.gnu.org/licenses/.";
        }
    }
}
