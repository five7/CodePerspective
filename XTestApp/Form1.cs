﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using XTestLib;
using System.Reflection;

namespace XTestApp
{
    public partial class Form1 : Form
    {
        string testVar = null;

        Object ButtonAsObject;
        Control ButtonAsControl;

        public static int[] StaticArray = new int[] { 11,22,33,44 };

        Dictionary<int, string> TestMap = new Dictionary<int, string>();

        public Form1()
        {
            InitializeComponent();

            ButtonAsObject = button1;
            ButtonAsControl = button1;
        }

        public void TryStuff()
        {
            // checks whats been added to il for static constructor

            // read in static consructor with decompiler and see what load field value is set to

            var aa = typeof(StaticMan);

            var bb = typeof(StaticTemplateClass<int>);


            /*var z = typeof(StaticTemplateClass<int>);

            foreach (var x in z.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static).OrderBy(f => f.Name))
            {
                var name = x.Name;

                var value = x.GetValue(null);

                int i = 0;
                i++;
            }*/
            
            try
            {
                StaticMan.HolyCow();

                var a = new NestedClass();

                string yy = null;
                yy = testVar;
                //testVar = "hello";

                a.DoStuff();

                var x = new int[] { 1, 2, 3, 4 };

                var y = x.Where(i => i > 2).ToArray();
            }
            catch (Exception ex)
            {

            }


            var t = new LibClass();
            t.TestMe = 5;
            t.DoMoreStuff();
        }

        public class NestedClass
        {
            int testVar2 = 33;

            public void DoStuff()
            {
                int i = 0;
                i += 5;

                int j = 5;
                i += j;

                i = testVar2;

                j = i;

                DivideByZero();
            }

            public int DivideByZero()
            {
                int x = 0;
                x++;

                int y = 1;
                y--;

                return x / y;
            }
        }

        private void throwButton_Click(object sender, EventArgs e)
        {
            TryStuff();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GC.Collect();
        }

        public int CountUp;

        private void TestTimer_Tick(object sender, EventArgs e)
        {
            CountUp++;
        }

        private void StartTimerButton_Click(object sender, EventArgs e)
        {
            TestTimer.Enabled = !TestTimer.Enabled;
        }
    }
}