using System;
using FoodiesReview.Service;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FoodiesReview.Entity;

namespace FoodiesReview
{
    public delegate void LoginDelegate();

    public partial class Login : Form
    {
        LoginDelegate loginDel;

        public Login()
        {
            InitializeComponent();
            loginDel = null;
            loginDel += loginCheck;
        }

        //Login verification Check
        void loginCheck()
        {
            PersonService personService = new PersonService();
            //Check email if exist
            if (personService.GetByEmail(email.Text.ToString()) == "exist")
            {
                //Check password is matched
                if (personService.CheckPassword(password.Text.ToString(), email.Text.ToString()) == "match")
                {
                    //fetch person id
                    String ID = personService.GetID(email.Text.ToString());
                    //Open Admin Homepage
                    if (ID == "AD")
                    {
                        AdminHomepage adminRestaurant = new AdminHomepage();
                        this.Hide();
                        adminRestaurant.Closed += (s, args) => this.Close();
                        adminRestaurant.Show();
                    }
                    //Open User Homepage
                    else
                    {
                        UserHomepage userHomepage = new UserHomepage();
                        this.Hide();
                        userHomepage.Closed += (s, args) => this.Close();
                        userHomepage.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Password Mismatch!!");
                }
            }
            else
            {
                MessageBox.Show("Email does not exist in database");
            }
        }

        //Login Submit Button
        private void LoginButton_Click(object sender, EventArgs e)
        {
            loginDel.Invoke();
        }

        //Create Register Form using LinkLabel
        private void registerNow_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = new Register();
            this.Hide();
            register.Closed += (s, args) => this.Close();
            register.Show();
        }
    }
}
