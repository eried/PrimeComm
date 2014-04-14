using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Searching;

namespace SkipListTest
{
    public partial class Form1 : Form
    {
        public static SkipList CurList = new SkipList();

        public Form1()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            CurList.Add(AddTextBox.Text);
            AddTextBox.Text = "";
            RefreshLists();
        }

        private void AddToList(string value)
        {
            CurList.Add(value);
        }
        
        private void RemoveFromList(string value)
        {
            CurList.Remove(value);
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (RemoveDropDownList.SelectedIndex >= 0)
            {
                CurList.Remove((String)RemoveDropDownList.Items[RemoveDropDownList.SelectedIndex]);
                RefreshLists();
            }
        }

        private void RefreshLists()
        {
            RemoveDropDownList.Items.Clear();
            CurrentList.Items.Clear();

            RemoveDropDownList.Items.AddRange((object[])CurList);
            CurrentList.Items.AddRange((object[])CurList);
            if (RemoveDropDownList.Items.Count > 0)
            {
                RemoveDropDownList.SelectedIndex = 0;
            }
        }

        private void TestWindowOpenButton_Click(object sender, EventArgs e)
        {
            TestWindow window = new TestWindow();
            window.ShowDialog();
        }
    }
}
