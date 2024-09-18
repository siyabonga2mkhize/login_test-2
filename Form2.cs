using System;
using System.IO;
using System.Windows.Forms;

namespace Login_and_create_Acc
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string LineRec = " ";
            string[] Array = new string[6];
            string Email = txtEmail.Text, Password = txtPassword.Text;
            string Path = @"C:\Users\thesm\OneDrive - Durban University of Technology\Desktop\Data.txt";
            StreamReader objSR = new StreamReader(Path);
            using (objSR)
            {

                while ((LineRec = objSR.ReadLine()) != null)
                {
                    Array = LineRec.Split('\t');
                    if (Email == Array[2])
                    {
                        if (Password == Array[4])
                        {
                            MessageBox.Show("Registered", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Password Incorrect", "Login UnSuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Email Not Found", "Login UnSuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }




                }
            }



        }

        private void chkShow_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShow.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }
    }
}
