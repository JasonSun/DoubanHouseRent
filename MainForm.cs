using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DoubanHouseRent
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.txtOut.Clear();
            this.btnSearch.Enabled = false;
            HouseRent rent = new HouseRent();
            UrlParameter request = new UrlParameter();
            Dictionary<string, string> group = request.GetGroup();
            List<string> keyword = request.GetKeyword(this.txtKey.Text);
            if (keyword.Count == 0)
            {
                MessageBox.Show("请输入搜索关键字");
                this.btnSearch.Enabled = true;
                return;
            }
            rent.GetHouse(this.txtOut, this.dtPicker, group, keyword);
            this.txtOut.AppendText("查询完毕!");
            this.btnSearch.Enabled = true;
        }

        private void txtOut_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }
    }
}
