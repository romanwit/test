using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testdome
{
    public partial class Form1 : Form
    {
        public class TextInput
        {

            string _value = "";

            virtual public void Add(char c)
            {
                _value += c.ToString();
            }

            public string GetValue()
            {
                MessageBox.Show("here:" + _value);
                return _value;
            }

        }

        public class NumericInput : TextInput
        {

            string _value = "";

            override public void Add(char c)
            {
                if (Char.IsDigit(c))
                {
                    _value += c.ToString();
                }
                MessageBox.Show(_value, "add");
            }

        }

        public Form1()
        {
            InitializeComponent();
        }

        public static IEnumerable<string> FolderNames(string xml, char startingLetter)
        {
            int index = -1;
            List<string> list = new List<string>();


            while (index < xml.Length)
            {

                index = xml.IndexOf("<folder name=\"" + startingLetter.ToString(), index+1);

                if (index != -1)
                {
                    
                    list.Add(xml.Substring(xml.IndexOf(startingLetter, index), xml.IndexOf("\"", xml.IndexOf(startingLetter, index)) -
                                           xml.IndexOf(startingLetter, index)));
                }
                else
                {
                    break;
                }

            }
            string[] result = list.ToArray();
            return result;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*   TextInput input = new NumericInput();
               input.Add('1');
               input.Add('a');
               input.Add('0');

               MessageBox.Show(input.GetValue());
               */

            //string s = "Deleveled";
            //MessageBox.Show(s.Substring(s.Length-1,1).ToLower());

            string xml =
            "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
            "<folder name=\"uty\">" +
                "<folder name=\"program files\">" +
                    "<folder name=\"uninstall information\" />" +
                "</folder>" +
                "<folder name=\"users\" />" +
            "</folder>";

            foreach (string name in FolderNames(xml, 'u'))
            {
                MessageBox.Show(name);
            }
        }
    }
}
