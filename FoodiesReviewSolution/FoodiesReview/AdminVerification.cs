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
    public delegate void AdminVerifyDelegate();

    public partial class AdminVerification : Form
    {
        int key;
        string name;
        string email;
        string password;
        int age;
        int gender;
        Register register;
        AdminVerifyDelegate adminVerifyDel;

        public AdminVerification(string name, string email, int gender, string password, int age, Register register)
        {
            InitializeComponent();
            this.name = name;
            this.email = email;
            this.gender = gender;
            this.password = password;
            this.age = age;
            this.register = register;
            adminVerifyDel = VerifyAdmin;
        }

        //Key accessor
        public int Key
        {
            set
            {
                key = value;
            }
            get
            {
                return key;
            }
        }

        //Verify Admin
        void VerifyAdmin()
        {
            if (KeyTextBox.Text.ToString() == "")
            {
                MessageBox.Show("Please provide the key given by the root admin!");
            }
            else
            {
                try
                {
                    key = int.Parse(KeyTextBox.Text.ToString());
                    Person person = new Admin(name, email, gender, password, age, key);
                    //check if key is matched
                    if (person.KeyCheck == 1)
                    {
                        PersonService personService = new PersonService();
                        //Check if email already exist
                        if (personService.GetByEmail(email) == "non-exist")
                        {
                            if (personService.Add(person) == 1)
                            {
                                MessageBox.Show("You are an Admin now!");
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
                    else
                    {
                        MessageBox.Show("Contact With Admin For The Key!");
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Key should be a number");
                }
            }
        }

        //Verify Admin and go to login page
        private void button1_Click(object sender, EventArgs e)
        {
            adminVerifyDel.Invoke();
        }

        //Go back to Register
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            register.Show();
        }
    }
}
