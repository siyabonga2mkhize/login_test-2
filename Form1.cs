using System;
using System.IO;
using System.Windows.Forms;

namespace Login_and_create_Acc
{
    public partial class frmCreate : Form
    {
        public frmCreate()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (txtName.Text == " " || txtSurname.Text == " " || txtEmail.Text == " " || txtID.Text == " " || txtPassword.Text == " " || txtConfirmPassword.Text == " ")
            {
                MessageBox.Show("Empty Flieds", "Registation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
            }
            string Data = @"C:\Users\thesm\OneDrive - Durban University of Technology\Desktop\Data.txt";
            string Name, Surname, Email, Password, ConfirmPassword;
            long ID;
            Name = txtName.Text;
            Surname = txtSurname.Text;
            Email = txtEmail.Text;
            Password = txtPassword.Text;
            ConfirmPassword = txtConfirmPassword.Text;
            ID = long.Parse(txtID.Text);
            string[] Array = new string[6];



            StreamReader objSR = new StreamReader(Data, false);
            {
                string LineRec;
                using (objSR)
                {
                    LineRec = objSR.ReadToEnd();
                    Array = LineRec.Split('\t');
                    ID = long.Parse(Array[3]);
                }
            }
            StreamWriter objSW = new StreamWriter(Data, true);
            using (objSW)
            {
                if (Password == ConfirmPassword)
                {
                    if (Array[3] == ID.ToString())
                    {
                        MessageBox.Show("Already exist", "Registation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        objSW.WriteLine(Name + '\t' + Surname + '\t' + Email + '\t' + ID + '\t' + Password + '\t' + ConfirmPassword);
                        MessageBox.Show("Created", "Registation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Password Don't Match", "Registation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }




            }


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Text = " ";
            txtSurname.Text = " ";
            txtEmail.Text = " ";
            txtID.Text = " ";
            txtPassword.Text = " ";
            txtConfirmPassword.Text = " ";
        }
    }
}
