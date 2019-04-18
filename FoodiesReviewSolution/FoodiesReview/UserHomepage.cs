using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FoodiesReview.Service;
using FoodiesReview.Entity;

namespace FoodiesReview
{
    public delegate void UserSearchResultDelegate();

    public partial class UserHomepage : Form
    {
        UserSearchResultDelegate searchDel;

        public UserHomepage()
        {
            InitializeComponent();
            autoComplete();
            searchDel = showAll;
            searchDel.Invoke();
        }

        //Show all restaurant name and location
        void showAll()
        {
            List<Restaurant> restaurantList;
            RestaurantService restaurantService = new RestaurantService();
            restaurantList = restaurantService.GetAllSearchList();
            listBox1.Items.Clear();
            foreach (var item in restaurantList)
            {
                string listItem = string.Format("{0}-{1}", item.Name, item.Location);
                listBox1.Items.Add(listItem);
            }
        }

        //Show selected restaurant by name
        void showAllByName()
        {
            Restaurant restaurant = new Restaurant();
            List<Restaurant> restaurantList;

            RestaurantService restaurantService = new RestaurantService();

            String name = ByNameTextBox.Text.ToString();
            restaurant.Name = name;

            restaurantList = restaurantService.GetSearchListByName(restaurant);

            int flag = 0;
            if (fieldCheckForSearchbyName(name))
            {
                listBox1.Items.Clear();
                foreach (var item in restaurantList)
                {
                    flag = 1;
                    string listItem = string.Format("{0}-{1}", item.Name, item.Location);
                    listBox1.Items.Add(listItem);
                }
                //Check if there is any result
                if (flag == 0)
                {
                    MessageBox.Show("No result found!");
                }
            }
            else
            {
                MessageBox.Show("Please enter name!");
            }
        }

        //Show selected restaurant by location
        void showAllByLocation()
        {
            Restaurant restaurant = new Restaurant();
            String location = ByLocationTextBox.Text.ToString();
            restaurant.Location = location;
            List<Restaurant> restaurantList;
            RestaurantService restaurantService = new RestaurantService();
            restaurantList = restaurantService.GetSearchListByLocation(restaurant);
            int flag = 0;
            if (fieldCheckForSearchbyName(location))
            {
                listBox1.Items.Clear();
                foreach (var item in restaurantList)
                {
                    flag = 1;
                    string listItem = string.Format("{0}-{1}", item.Name, item.Location);
                    listBox1.Items.Add(listItem);
                }
                //Check if there is any result
                if (flag == 0)
                {
                    MessageBox.Show("No result found!");
                }
            }
            else
            {
                MessageBox.Show("Please enter location!");
            }
        }

        //perform Logout
        private void button1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Closed += (s, args) => this.Close();
            login.Show();
        }

        //Auto Complete Suggestion in textbox
        void autoComplete()
        {
            RestaurantService restaurantService = new RestaurantService();

            ByNameTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            ByNameTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var autoComplete1 = new AutoCompleteStringCollection();
            autoComplete1.AddRange(restaurantService.GetAllByName().ToArray());
            ByNameTextBox.AutoCompleteCustomSource = autoComplete1;

            ByLocationTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            ByLocationTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var autoComplete2 = new AutoCompleteStringCollection();
            autoComplete2.AddRange(restaurantService.GetAllByLocation().ToArray());
            ByLocationTextBox.AutoCompleteCustomSource = autoComplete2;
        }

        //checks if ByNameTextBox is empty
        private bool fieldCheckForSearchbyName(String name)
        {
            if (name == "")
            {
                return false;
            }
            else
                return true;
        }

        //checks if byLocationTextBox is empty
        private bool fieldCheckForSearchbyLocation(String location)
        {
            if (location == "")
            {
                return false;
            }
            else
                return true;
        }

        //populates the names of restaurants in listBox1 by name
        private void button2_Click(object sender, EventArgs e)
        {
            searchDel = showAllByName;
            searchDel.Invoke();
        }


        //populates the names of restaurants in listBox1 by location
        private void button3_Click(object sender, EventArgs e)
        {
            searchDel = showAllByLocation;
            searchDel.Invoke();
        }


        //DoubleClick mouse event - shows the item interface of the selected item
        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            String name;
            String location;
            if (listBox1.SelectedItem != null)
            {
                if (listBox1.SelectedItem.ToString().Length != 0)
                {
                    String item = listBox1.SelectedItem.ToString();
                    string[] words = item.Split('-');
                    name = words[0];
                    location = words[1];
                    ItemInterface itemInterface = new ItemInterface(name, location, "US");
                    this.Hide();
                    itemInterface.Closed += (s, args) => this.Close();
                    itemInterface.Show();
                }
            }
        }


        //populates all the names and location of restaurants in listBox1
        private void button6_Click(object sender, EventArgs e)
        {
            searchDel = showAll;
            searchDel.Invoke();
        }

        //Mouse click event in listbox - Fill text fields
        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            String name;
            String location;
            if (listBox1.SelectedItem != null)
            {
                if (listBox1.SelectedItem.ToString().Length != 0)
                {
                    String item = listBox1.SelectedItem.ToString();
                    string[] words = item.Split('-');
                    name = words[0];
                    location = words[1];
                    ByNameTextBox.Text = name;
                    ByLocationTextBox.Text = location;
                }
            }
        }
    }
}
