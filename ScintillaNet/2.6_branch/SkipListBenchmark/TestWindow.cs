using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Searching;
using System.Diagnostics;

namespace SkipListTest
{
    public partial class TestWindow : Form
    {
        static List<String> ListOfWordsToUse = new List<String>();

        public static SkipList CurSkipList = new SkipList();
        public static List<String> CurStandList = new List<String>();
        
        public TestWindow()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            StartTest();
        }

        private void StartTest()
        {
            StartButton.Enabled = false;

            SkipListAddResult.Text = " Miliseconds";
            SkipListRemoveResult.Text = " Miliseconds";
            StandListAddResult.Text = " Miliseconds";
            StandListRemoveResult.Text = " Miliseconds";


            StreamReader rdr = new StreamReader(Application.StartupPath + "\\TestList.txt");
            Int32 currentItemNumb = 0;
            while (currentItemNumb < 100000)
            {
                ListOfWordsToUse.Add(rdr.ReadLine());
                rdr.BaseStream.Flush();
                currentItemNumb++;
            }
            rdr.Close();
            rdr.Dispose();
            

            SkipListAddTest();
            StreamWriter fil = new StreamWriter("confermation.txt", false, System.Text.Encoding.ASCII);
            foreach (string s in CurSkipList)
            {
                fil.WriteLine(s);
                fil.Flush();
            }
            fil.Flush();
            fil.Close();
            SkipListRemoveTest();

            StandListAddTest();
            StandListRemoveTest();


            StartButton.Enabled = true;
            ListOfWordsToUse.Clear();
        }

        #region SkipListTests
        private void SkipListAddTest()
        {
            var t1 = Stopwatch.StartNew();
            foreach (string s in ListOfWordsToUse)
            {
                CurSkipList.Add(s);
            }
            t1.Stop();
            SkipListAddResult.Text = ((t1.ElapsedMilliseconds.ToString()) + " Miliseconds");
            this.SkipListAddResult.Refresh();
        }

        private void SkipListRemoveTest()
        {
            var t2 = Stopwatch.StartNew();
            foreach (string s in ListOfWordsToUse)
            {
                CurSkipList.Remove(s);
            }
            t2.Stop();
            SkipListRemoveResult.Text = ((t2.ElapsedMilliseconds.ToString()) + " Miliseconds");
            this.SkipListRemoveResult.Refresh();
        }
        #endregion

        #region StandardListTests
        private void StandListAddTest()
        {
            var t3 = Stopwatch.StartNew();
            foreach (string s in ListOfWordsToUse)
            {
                CurStandList.Add(s);
            }
            t3.Stop();
            StandListAddResult.Text = ((t3.ElapsedMilliseconds.ToString()) + " Miliseconds");
            this.StandListAddResult.Refresh();
        }

        private void StandListRemoveTest()
        {
            var t4 = Stopwatch.StartNew();
            foreach (string s in ListOfWordsToUse)
            {
                CurStandList.Remove(s);
            }
            t4.Stop();
            StandListRemoveResult.Text = ((t4.ElapsedMilliseconds.ToString()) + " Miliseconds");
            this.StandListRemoveResult.Refresh();
        }
        #endregion


    }
}
