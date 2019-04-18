using System;
using FoodiesReview.Service;
using FoodiesReview.Entity;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodiesReview
{
    public delegate void RegisterDelegate();

    public partial class Register : Form
    {
        RegisterDelegate registerDel;

        public Register()
        {
            InitializeComponent();
            registerDel = RegisterCheck;
        }

        //Register user as admin if verfication complete
        private void AdminVerify(string name, string email, int gender, string password, int age)
        {
            //Go to admin verification form to check the key
            AdminVerification adminverification = new AdminVerification(name, email, gender, password, age, this);
            this.Hide();
            adminverification.Closed += (s, args) => this.Close();
            adminverification.Show();
        }

        //Register user as user if verfication complete
        private void UserVerify(string name, string email, int gender, string password, int age)
        {
            Person person = new User(name, email, gender, password, age);
            PersonService personService = new PersonService();
            
            //check if email already exist
            if (personService.GetByEmail(email) == "non-exist")
            {
                if (personService.Add(person) == 1)
                {
                    MessageBox.Show("Record Added Successfully!");
                    Login login = new Login();
                    this.Hide();
                    login.Closed += (s, args) => this.Close();
                    login.Show();
                }
                else
                {
                    MessageBox.Show("Couldn't Add to database");
                }
            }
            else
                MessageBox.Show("You are already in the database!");
        }

        //Check gender is male/female or not selected
        private int genderCheck()
        {
            if (RadioButtonMale.Checked)
            {
                return 0;
            }
            else if (RadioButtonFemale.Checked)
            {
                return 1;
            }
            else
                return 2;
        }

        //Check if age is a number
        private bool ageVerify()
        {
            if (Age.Text.ToString() == "")
            {
                MessageBox.Show("Please check Age  field is filled or not");
                return false;
            }
            else
            {
                try
                {
                    int.Parse(Age.Text.ToString());
                    return true;
                }
                catch (FormatException)
                {
                    MessageBox.Show("Age should be a number");
                    return false;
                }
            }
        }

        //Registration code
        public void RegisterCheck()
        {
            String name, email, password;
            int age;

            name = PersonName.Text.ToString();
            email = PersonEmail.Text.ToString();
            password = Password.Text.ToString();

            if (name == "" || email == "" || password == "")
            {
                MessageBox.Show("Please check Name,Email and Password  field is filled or not");
            }
            else
            {
                if (ageVerify())
                {
                    if (int.Parse(Age.Text.ToString()) > 16)
                    {
                        age = int.Parse(Age.Text.ToString());

                        int gender = genderCheck();
                        if (gender != 2)
                        {
                            //Admin Check
                            if (RadioButtonAdmin.Checked)
                            {
                                AdminVerify(name, email, gender, password, age);
                            }
                            //User Check
                            else if (RadioButtonUser.Checked)
                            {
                                UserVerify(name, email, gender, password, age);
                            }
                            //User type not selected
                            else
                            {
                                MessageBox.Show("Kindly select the user type");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please kindly select a gender");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Use this software after 16 years of age!");
                    }
                }
            }
        }

        //Submit Button
        private void button1_Click(object sender, EventArgs e)
        {
            registerDel.Invoke();
        }

        //Go to Login Page Button
        private void button2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Closed += (s, args) => this.Close();
            login.Show();
        }
    }
}
