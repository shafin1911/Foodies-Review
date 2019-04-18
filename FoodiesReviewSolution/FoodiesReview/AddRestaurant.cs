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
    public partial class AddRestaurant : Form
    {
        bool cellFlag = true;

        public AddRestaurant()
        {
            InitializeComponent();
            LoadRestaurant();
        }

        //Verify rate is a number greater than 0 and less than 11
        private bool RateVerify(TextBox ob)
        {
            if (ob.Text.ToString() == "")
            {
                MessageBox.Show("Please check Rate is field or not");
                return false;
            }
            else
            {
                try
                {
                    int rate = int.Parse(ob.Text.ToString());
                    if (rate > 0 && rate <= 10)
                        return true;
                    else
                    {
                        MessageBox.Show("Rate should be less than 10 and a positive number");
                        return false;
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Rate should be in number");
                    return false;
                }
            }
        }

        //Populate gridview with all restaurant
        private void LoadRestaurant()
        {
            RestaurantService restaurantService = new RestaurantService();
            DataTable table = new DataTable();
            table = restaurantService.GetRestaurantTable();
            dataGridView1.DataSource = table;
        }

        //Populate gridview with all item of a restaurant
        private void LoadItem(int rid)
        {
            Item item = new Item();
            item.Rid = rid;
            ItemService itemService = new ItemService();
            DataTable table = new DataTable();
            table = itemService.GetTable(item);
            dataGridView1.DataSource = table;
        }

        //Check all field value given to add restaurant
        private bool fieldCheckForRestaurant(String name, String location, String environment, String behaviour)
        {
            if (name == "" || location == "" || environment == "" || behaviour == "")
            {
                return false;
            }
            else
                return true;
        }

        //Check all field value given to add item
        private bool fieldCheckForItem(String name, String location, String iname, String irate)
        {
            if (name == "" || location == "" || iname == "" || irate == "")
            {
                return false;
            }
            else
                return true;
        }

        //Check all field value given to load item
        private bool fieldCheckForLoadItem(String name, String location)
        {
            if (name == "" || location == "")
            {
                return false;
            }
            else
                return true;
        }

        //Restaurant add button - recieves texts from RestaurantName, RestaurantLocation, EnvironmentRate, BehaviourRate and add to restaurant table
        private void button1_Click(object sender, EventArgs e)
        {
            String name = RestaurantName.Text.ToString();
            String location = RestaurantLocation.Text.ToString();
            String stringEnvironment = EnvironmentRate.Text.ToString();
            String stringBehaviour = BehaviourRate.Text.ToString();
            int environment = 0;
            int behaviour = 0;
            int eflag = 0;
            int bflag = 0;
            if (fieldCheckForRestaurant(name, location, stringEnvironment, stringBehaviour))
            {
                if (RateVerify(EnvironmentRate))
                {
                    environment = int.Parse(stringEnvironment);
                    eflag = 1;
                }
                if (RateVerify(BehaviourRate))
                {
                    behaviour = int.Parse(stringBehaviour);
                    bflag = 1;
                }

                if (eflag == 1 && bflag == 1)
                {
                    Restaurant restaurant = new Restaurant();
                    restaurant.Name = name;
                    restaurant.Environment = environment;
                    restaurant.Location = location;
                    restaurant.Behaviour = behaviour;

                    RestaurantService restaurantService = new RestaurantService();
                    if (restaurantService.GetByLocation(restaurant) == "non-exist")
                    {
                        int RID = restaurantService.GetRID();
                        restaurant.Rid = RID + 1;
                        if (restaurantService.AddRestaurant(restaurant) == 1)
                        {
                            MessageBox.Show("Restaurant Added Successfully!");
                            LoadRestaurant();
                        }
                        else
                        {
                            MessageBox.Show("Couldn't Add Restaurant!");
                        }
                    }
                    else if (restaurantService.GetByLocation(restaurant) == "exist")
                    {
                        MessageBox.Show("Restaurant Already Exist");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please check all field is filled or not");
            }

        }

        //Item add button recieves texts from ItemName, ItemRate and add to item table
        private void button2_Click(object sender, EventArgs e)
        {
            String name = RestaurantName.Text.ToString();
            String location = RestaurantLocation.Text.ToString();
            String IName = ItemName.Text.ToString();
            String IRate = ItemRate.Text.ToString();
            int rate = 0;
            int rflag = 0;

            if (fieldCheckForItem(name, location, IName, IRate))
            {
                if (RateVerify(ItemRate))
                {
                    rate = int.Parse(IRate);
                    rflag = 1;
                }

                if (rflag == 1)
                {
                    Item item = new Item();
                    item.Name = IName;
                    item.Rating = rate;

                    ItemService itemService = new ItemService();

                    Restaurant restaurant = new Restaurant();
                    restaurant.Name = name;
                    restaurant.Location = location;

                    RestaurantService restaurantService = new RestaurantService();

                    if (restaurantService.GetByLocation(restaurant) == "exist")
                    {
                        int RID = restaurantService.GetRID(restaurant);
                        item.Rid = RID;
                        if (itemService.GetByItemName(item) == "non-exist")
                        {
                            int IID = itemService.GetIID();
                            item.Iid = IID + 1;

                            if (itemService.AddItem(item) == 1)
                            {
                                MessageBox.Show("Item Added Successfully!");
                                LoadItem(item.Rid);
                            }
                            else
                            {
                                MessageBox.Show("Couldn't Add Item!");
                            }
                        }
                        else if (itemService.GetByItemName(item) == "exist")
                        {
                            MessageBox.Show("Item Already Exist!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Restaurant Doesn't Exist");
                    }
                }
                else
                {
                    MessageBox.Show("Please check new item rate is given or not");
                }
            }
            else
            {
                MessageBox.Show("Please check restaurant Name, Location, Item Name and Rate is filled or not");
            }
        }

        //Go back to search page of admin
        private void button3_Click(object sender, EventArgs e)
        {
            AdminHomepage adminRestaurant = new AdminHomepage();
            this.Hide();
            adminRestaurant.Closed += (s, args) => this.Close();
            adminRestaurant.Show();
        }

        //Load Restaurant
        private void button4_Click(object sender, EventArgs e)
        {
            Load.Text = "All Restaurant";
            cellFlag = true;
            LoadRestaurant();
        }

        //Load Item
        private void button5_Click(object sender, EventArgs e)
        {
            String name = RestaurantName.Text.ToString();
            String location = RestaurantLocation.Text.ToString();
            if (fieldCheckForLoadItem(name, location))
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

        //Cell click event - fill textbox values accordingly
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
        }
    }
}
