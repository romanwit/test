using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LINQ_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool IsEven(int val)
        {
            return val % 2 == 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var groups = arr.GroupBy(n => IsEven(n));
            string res = "";
            foreach (var group in groups)
            {
                res += group.Key + ", ";

                res += String.Join(", ", group) + "\n";
            }

            MessageBox.Show(res);
            
        }
    }
}
