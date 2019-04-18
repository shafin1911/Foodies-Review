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
    public delegate void DeleteDelegate();

    public partial class DeleteRestaurant : Form
    {
        bool cellFlag = true;
        DeleteDelegate deleteDel;

        public DeleteRestaurant()
        {
            InitializeComponent();
            deleteDel = LoadRestaurant;
            deleteDel.Invoke();
        }

        //Remove Restaurant and All item
        public void RemoveRestaurant()
        {
            String name = RestaurantName.Text.ToString();
            String location = RestaurantLocation.Text.ToString();

            if (fieldCheckForRestaurant(name, location))
            {
                Restaurant restaurant = new Restaurant();
                restaurant.Name = name;
                restaurant.Location = location;

                RestaurantService restaurantService = new RestaurantService();
                Item item = new Item();

                if (restaurantService.GetByLocation(restaurant) == "exist")
                {
                    int rid = restaurantService.GetRID(restaurant);
                    ItemService itemService = new ItemService();
                    item.Rid = rid;
                    restaurant.Rid = rid;

                    if (restaurantService.RemoveRestaurant(restaurant) == 1)
                    {
                        MessageBox.Show("Restaurant Removed Successfully!");
                        LoadRestaurant();
                    }
                    else
                    {
                        MessageBox.Show("Couldn't Remove Restaurant!");
                    }

                    if (itemService.RemoveAllItem(item) == 1)
                    {
                        MessageBox.Show("Item of that Restaurant Removed Successfully!");
                    }
                    else
                    {
                        MessageBox.Show("No Item Exist For This Restaurant!");
                    }
                }
                else
                {
                    MessageBox.Show("Restaurant Doesn't Exist");
                }
            }
            else
            {
                MessageBox.Show("Please fill Restaurant name and location to delete");
            }
        }

        //Remove Particular item
        public void RemoveItem()
        {
            String name = RestaurantName.Text.ToString();
            String location = RestaurantLocation.Text.ToString();
            String iname = textBox3.Text.ToString();

            if (fieldCheckForItem(name, location, iname))
            {
                Restaurant restaurant = new Restaurant();
                restaurant.Name = name;
                restaurant.Location = location;
                RestaurantService restaurantService = new RestaurantService();

                if (restaurantService.GetByLocation(restaurant) == "exist")
                {
                    int rid = restaurantService.GetRID(restaurant);
                    ItemService itemService = new ItemService();
                    Item item = new Item();
                    item.Rid = rid;
                    item.Name = iname;
                    if (itemService.RemoveItem(item) == 1)
                    {
                        MessageBox.Show("Item Removed Successfully!");
                        LoadItem(rid);
                    }
                    else
                    {
                        MessageBox.Show("Item Doesn't Exist!");
                    }
                }
                else
                {
                    MessageBox.Show("Restaurant Doesn't Exist");
                }
            }
            else
            {
                MessageBox.Show("Please fill Restaurant name, location and item name to delete");
            }
        }

        //Load restaurant in data grid view
        private void LoadRestaurant()
        {
            RestaurantService restaurantService = new RestaurantService();
            DataTable table = new DataTable();
            table = restaurantService.GetRestaurantTable();
            dataGridView1.DataSource = table;
        }

        //Load item in data grid view
        private void LoadItem(int rid)
        {
            ItemService itemService = new ItemService();
            DataTable table = new DataTable();
            Item item = new Item();
            item.Rid = rid;
            table = itemService.GetTable(item);
            dataGridView1.DataSource = table;
        }

        //Check restaurant name, location is given or not
        private bool fieldCheckForRestaurant(String name, String location)
        {
            if (name == "" || location == "")
            {
                return false;
            }
            else
                return true;
        }

        //Check item restaurant name, location and item name is given to delete particular item 
        private bool fieldCheckForItem(String name, String location, String iname)
        {
            if (name == "" || location == "" || iname == "")
            {
                return false;
            }
            else
                return true;
        }

        //removes restaurant button
        private void button1_Click(object sender, EventArgs e)
        {
            RemoveRestaurant();
        }

        //removes item button
        private void button2_Click(object sender, EventArgs e)
        {
            RemoveItem();
        }

        // opens AdminHomepage
        private void button3_Click(object sender, EventArgs e)
        {
            AdminHomepage adminRestaurant = new AdminHomepage();
            this.Hide();
            adminRestaurant.Closed += (s, args) => this.Close();
            adminRestaurant.Show();
        }

        //Load Restaurant button
        private void button4_Click(object sender, EventArgs e)
        {
            Load.Text = "All Restaurant";
            cellFlag = true;
            textBox3.Text = "";
            LoadRestaurant();
        }

        //Load Item Button
        private void button5_Click(object sender, EventArgs e)
        {
            String name = RestaurantName.Text.ToString();
            String location = RestaurantLocation.Text.ToString();

            if (fieldCheckForRestaurant(name, location))
            {
                Restaurant restaurant = new Restaurant();
                restaurant.Name = name;
                restaurant.Location = location;
                RestaurantService restaurantService = new RestaurantService();
                if (restaurantService.GetByLocation(restaurant) == "exist")
                {
                    int RID = restaurantService.GetRID(restaurant);
                    Load.Text = name + '-' + location;
                    cellFlag = false;
                    LoadItem(RID);
                }
                else if (restaurantService.GetByLocation(restaurant) == "non-exist")
                {
                    MessageBox.Show("Restaurant Doesn't Exist!");
                }
            }
            else
            {
                MessageBox.Show("To load item kindly provide the restaurant name and location!");
            }
        }

        //shows the selected texts in RestaurantName, RestaurantLocation and textBox3
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (cellFlag == true)
            {
                if (dataGridView1.CurrentCell.ColumnIndex.Equals(0))
                {
                    if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.Value != null && e.RowIndex >= 0)
                    {
                        RestaurantName.Text = dataGridView1.CurrentCell.Value.ToString();
                        RestaurantLocation.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    }
                }
                else if (dataGridView1.CurrentCell.ColumnIndex.Equals(1))
                {
                    if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.Value != null && e.RowIndex >= 0)
                    {
                        RestaurantLocation.Text = dataGridView1.CurrentCell.Value.ToString();
                        RestaurantName.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    }
                }
            }
            else
            {
                if (dataGridView1.CurrentCell.ColumnIndex.Equals(0))
                {
                    if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.Value != null)
                    {
                        textBox3.Text = dataGridView1.CurrentCell.Value.ToString();
                    }
                }
            }
        }
    }
}