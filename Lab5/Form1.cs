using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /*
            Name: Yassine Adaam Ammantoola
            Course: PROG1017: Introduction to Programming - Lab 5: Functions and Loops
            
         */
        // Constant to display name
        const string PROGRAMMER = "Yassine Adaam Ammantoola";
        int loginAttempts = 0;

        //Function to get random number from minimum to maximum
        public static int GetRandom(int min, int max)
        {
            Random randomNum = new Random();
            int number = randomNum.Next(min, max);
            return number;
        }

        //On form load, generate random number and hide the groupboxes
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + " " + PROGRAMMER;
            grpChoose.Visible = false;
            grpText.Visible = false;
            grpStats.Visible = false;
            txtCode.Focus();
            lblCode.Text = GetRandom(100000, 200001).ToString();

            //string text = form1.title + PROGRAMMER;
        }
        //On login button click, Check login details if it matches
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (lblCode.Text == txtCode.Text)
            {
                grpChoose.Visible = true;
                grpLogin.Enabled = false;
            }
            else
            {
                loginAttempts++;
                if (loginAttempts < 3)
                {
                    MessageBox.Show(loginAttempts + " Incorrect code(s) entered\n " + "Try again - only 3 attempts allowed", PROGRAMMER);
                }
                else
                {
                    MessageBox.Show("3 Attempts to login\n " + "Account locked - Closing program", PROGRAMMER);
                    this.Close();

                }
            }
        }

        // function to reset textbox strings and  checkbox and lable results
        public void ResetTextGrp()
        {
            txtString1.Text = "";
            txtString2.Text = "";
            chkSwap.Checked = false;
            lblResults.Text = "";

        }

        //Reset Stats groupbox labels and listbox 
        public void ResetStatsGrp()
        {
            lblSum.Text = "";
            lblMean.Text = "";
            lblOdd.Text = "";
            lstNumbers.Items.Clear();
        }
        //function to check id radio button is clicked
        public void SetupOption()
        {
            if (radText.Checked == true)
            {
                grpText.Visible = true;
                grpStats.Visible = false;
                ResetStatsGrp();
            }
            if (radStats.Checked == true)
            {
                grpStats.Visible = true;
                grpText.Visible = false;
                ResetStatsGrp();
            }
        }
        // When text radio button is checked, call SetupOption()
        private void radText_CheckedChanged(object sender, EventArgs e)
        {
            SetupOption();
        }
        // When stats radio button is checked, call SetupOption()
        private void radStats_CheckedChanged(object sender, EventArgs e)
        {
            SetupOption();
        }
        // When button reset is clicked call ResetTextGrp()
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetTextGrp();
        }
        // When button clear is clicked call ResetStatsGrp()
        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetStatsGrp();
        }

        // Function Swap that accepts to strings and swaps them
        public void Swap(string string1, string string2)
        {
            string1 = string1 + string2;

            string2 = string1.Substring(0, string1.Length - string2.Length);
            string1 = string1.Substring(string2.Length);
            txtString1.Text = string2;
            txtString2.Text = string1;
        }
        //Function CheckInput to check if string1 and string2 is empty
        public bool CheckInput()
        {
            bool testData = true;
            if ((txtString1.Text == "" && txtString2.Text == ""))
            {
                testData = false;
            }
            return testData;


        }

        //When swap checkbox is clicked, interchange strings
        private void chkSwap_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSwap.Checked == true && !(txtString1.Text == "" && txtString2.Text == ""))
            {
                string String_1 = txtString1.Text;
                string String_2 = txtString2.Text;

                CheckInput();
                Swap(String_2, String_1);

                lblResults.Text = "Strings have been swapped!";

            }
        }

        //On click of Join Button, Join the strings
        private void btnJoin_Click(object sender, EventArgs e)
        {

            if (!(txtString1.Text == "" && txtString2.Text == ""))
            {

                lblResults.Text = "First String = " + txtString1.Text +
                              "\nSecond String = " + txtString2.Text +
                              "\nJoined = " + txtString1.Text + "-->" + txtString2.Text;
            }
        }
        //On click of Analyze Button, Calculate the number of characters
        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            if (!(txtString1.Text == "" && txtString2.Text == ""))
            {

                lblResults.Text = "First string = " + txtString1.Text +
                                  "\n Characters = " + txtString1.Text.Length +    
                              "\nSecond String = " + txtString2.Text +
                               "\n Characters = " + txtString2.Text.Length;
            }
        }
        /* On click of Generate Button, Generate random numbers between 1000 and 5000 
          and display on appropriate labels
         */
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            lstNumbers.Text = "";
            
            Random rnd = new Random(733);
            for (int i = 1; i <= numericUpDown1.Value; i++)
            {
               
                lstNumbers.Items.Add(rnd.Next(1000,5001).ToString());

            }
            AddList();
            lblMean.Text = "";
            double avg = 0, summation = 0;
            int lstCount = lstNumbers.Items.Count; //Get Count of Listbox Items
            for (int i = 0; i < lstCount; i++)
            {
                summation += Convert.ToDouble(lstNumbers.Items[i]);
            }
            avg = summation / lstCount;
            lblMean.Text = String.Format("{0:n}", avg).ToString();

            CountOdd();
        }

        //function AddList() to add the values in the listbox
        public int AddList()
        {
            int i = 0;
            int sum = 0;
            while(i < lstNumbers.Items.Count)
            {
                sum += Convert.ToInt32(lstNumbers.Items[i]);
                lblSum.Text = String.Format("{0:n0}", sum).ToString();
                i++;
            }
            return sum;
        }

        //Function to count the odd numbers in the listbox
        public int CountOdd()
        {
            int i = 0;
            int odd = 0;
            do
            {
                if(Convert.ToInt32(lstNumbers.Items[i]) % 2 != 0)
                {
                    odd++;
                    lblOdd.Text = odd.ToString();
                   
                }
                i++;
            }
            while (i < lstNumbers.Items.Count);
       
            return odd;
        }
    }
}

    
