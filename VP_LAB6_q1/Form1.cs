using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VP_LAB6_q1
{
    public partial class Form1 : Form
    {
        int bodpart = 0;
        bool isleapYear=false;
        String gender ="";
        int[] notleapyear ={ 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334, 365 };
        string[] monthNames = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        int[] leapyear = { 31, 60, 91, 121, 152, 182, 213, 244, 274, 305, 335, 366 };
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           

            String nic = txtnic.Text;
            if (nic.Length == 9)
            {
                nicyear(nic);
                nicgender(nic);
                nicbod(nic);
            }
            else if (nic.Length == 12)
            {
                nicyear(nic);
                nicgender(nic);
                nicbod(nic);

            }
            else
            {

            }
        }

        private void nicyear(String nic)
        {
            if (nic.Length == 9)
            {
                int y = int.Parse(nic.Substring(0, 2));
                lbyear.Text = (y + 1900).ToString();
                checkyear(y + 1900);
            }
            else
            {
                int y = int.Parse(nic.Substring(0, 4));
                checkyear(y);
                lbyear.Text = y.ToString();
            }

        }

        private void nicgender(string nic)
        {
            if (nic.Length == 9)
            {
                int y = int.Parse(nic.Substring(2, 3));
                if (y > 500)
                {
                    bodpart = y - 500;
                    lbgender.Text = "Female";
                    gender = "Female";
                }
                else
                {
                    bodpart = y;
                    lbgender.Text = "Male";
                    gender = "Male";
                }
            }
            else
            {
                int y = int.Parse(nic.Substring(4, 3));
                if (y > 500)
                {
                    bodpart = y - 500;
                    lbgender.Text = "Female";
                    gender = "Female";
                }
                else
                {
                    bodpart = y;
                    lbgender.Text = "Male";
                    gender = "Male";
                }
            }
        }
        private void checkyear(int year)
        {
            
            if (year % 400 == 0 & year % 4 == 0)
            {
                isleapYear = true;
            }
            else
            {
                isleapYear= false;
            }

        }
        private void nicbod(String nic)
        {
            int days = bodpart-1;

            if (isleapYear)
            {
                for (int i = 0; i < leapyear.Length; i++)
                {
                    if (days <= leapyear[i])
                    {
                        lbmonth.Text = monthNames[i];
                        lbdate.Text = (i == 0 ? days : days - leapyear[i - 1]).ToString();

                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < notleapyear.Length; i++)
                {
                    if (days <= notleapyear[i])
                    {
                        lbmonth.Text = monthNames[i];
                        lbdate.Text = (i == 0 ? days : days - notleapyear[i - 1]).ToString();
                       
                        break;
                    }
                }
            }
        }

    }
}
