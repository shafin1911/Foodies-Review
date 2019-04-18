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
    public delegate void ItemInterfaceDelegate();
    public delegate void RatingSetDelegate(String name, String location);

    public partial class ItemInterface : Form
    {
        String name, location, pid;
        int rid, foodRating, totalRating;
        ItemInterfaceDelegate itemDel;
        RatingSetDelegate ratingsetDel;

        public ItemInterface(String name, String location, String pid)
        {
            InitializeComponent();
            this.name = name;
            this.location = location;
            this.pid = pid;
            ratingsetDel = setRating;
            itemDel = null;
            ratingsetDel.Invoke(name,location);
        }

        //Rate Item method
        public void rateItem()
        {
            String ItemName = iName.Text.ToString();
            String ItemRate = iRate.Text.ToString();

            int rate = 0;
            int rflag = 0;

            //Check field is filled or not
            if (fieldCheckForItemRate(ItemName, ItemRate))
            {
                //Check rate if it's a number from 0 - 10
                if (numberVerify(iRate))
                {
                    rate = int.Parse(ItemRate);
                    rflag = 1;
                }

                if (rflag == 1)
                {
                    Item item = new Item();
                    item.Name = ItemName;
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
                        if (itemService.GetByItemName(item) == "exist")
                        {
                            if (itemService.RateItem(item) == 1)
                            {
                                MessageBox.Show("Item Rated Successfully!");
                                ratingsetDel.Invoke(name, location);
                            }
                            else
                            {
                                MessageBox.Show("Couldn't Rate Item!");
                            }
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
                    MessageBox.Show("Please check item rate is given or not");
                }
            }
            else
            {
                MessageBox.Show("Please check Item Name and Rate is filled or not");
            }
        }

        //Rate Environment method
        public void rateEnvironment()
        {
            String Environement = eRate.Text.ToString();

            if (numberVerify(eRate))
            {
                Restaurant restaurant = new Restaurant();
                restaurant.Name = name;
                restaurant.Location = location;
                restaurant.Environment = int.Parse(Environement);
                restaurant.Rid = rid;
                RestaurantService restaurantService = new RestaurantService();

                if (restaurantService.RateEnvironment(restaurant) == 1)
                {
                    MessageBox.Show("Environement Rated Successfully!");
                    setRating(name, location);
                }
                else
                {
                    MessageBox.Show("Couldn't Environement Item!");
                }
            }
        }

        //Rate Behaviour
        public void rateBehaviour()
        {
            String Behaviour = bRate.Text.ToString();

            if (numberVerify(bRate))
            {
                Restaurant restaurant = new Restaurant();
                restaurant.Name = name;
                restaurant.Location = location;
                restaurant.Rid = rid;
                restaurant.Behaviour = int.Parse(Behaviour);

                RestaurantService restaurantService = new RestaurantService();

                if (restaurantService.RateBehaviour(restaurant) == 1)
                {
                    MessageBox.Show("Behaviour Rated Successfully!");
                    setRating(name, location);
                }
                else
                {
                    MessageBox.Show("Couldn't Rate Behaviour!");
                }
            }
        }

        //Add new item method
        public void addNewItem()
        {
            String ItemName = textBox5.Text.ToString();
            String ItemRate = textBox6.Text.ToString();
            int rate = 0;
            int rflag = 0;

            if (fieldCheckForItemRate(ItemName, ItemRate))
            {
                if (numberVerify(textBox6))
                {
                    rate = int.Parse(ItemRate);
                    rflag = 1;
                }

                if (rflag == 1)
                {
                    Item item = new Item();
                    item.Name = ItemName;
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
                                MessageBox.Show("Item Created and Rated Successfully!");
                                ratingsetDel.Invoke(name, location);
                            }
                            else
                            {
                                MessageBox.Show("Couldn't Create Item!");
                            }
                        }
                        else
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
                MessageBox.Show("Please check Item Name and Rate is filled or not");
            }
        }

        //Set all the ratings and datagridview table
        public void setRating(String name, String location)
        {
            Item item = new Item();
            RestaurantService restaurantService = new RestaurantService();
            Restaurant restaurant = new Restaurant();

            restaurant.Name = name;
            restaurant.Location = location;

            restaurant = restaurantService.GetAllRate(restaurant);
            label17.Text = name + " (" + location + ")";
            label6.Text = restaurant.Environment.ToString();
            label8.Text = restaurant.Behaviour.ToString();
            rid = restaurant.Rid;

            ItemService itemService = new ItemService();

            item.Rid = rid;
            foodRating = itemService.GetItemsRating(item);

            label4.Text = foodRating.ToString();

            DataTable table = new DataTable();
            table = itemService.GetTable(item);
            dataGridView1.DataSource = table;

            totalRating = (restaurant.Environment + restaurant.Behaviour + foodRating) / 3;
            label2.Text = totalRating.ToString();
        }

        //Check if rate is a number from 0-10 or not
        private bool numberVerify(TextBox ob)
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

        //Check Field is filled for item rating
        private bool fieldCheckForItemRate(String name, String location)
        {
            if (name == "" || location == "")
            {
                return false;
            }
            else
                return true;
        }

        //Go back button to search page base on user ID type
        private void button1_Click(object sender, EventArgs e)
        {
            if (pid == "AD")
            {
                AdminHomepage adminRestaurant = new AdminHomepage();
                this.Hide();
                adminRestaurant.Closed += (s, args) => this.Close();
                adminRestaurant.Show();
            }
            else if (pid == "US")
            {
                UserHomepage userHomepage = new UserHomepage();
                this.Hide();
                userHomepage.Closed += (s, args) => this.Close();
                userHomepage.Show();
            }
        }

        //Rate Item(button) of the restaurant
        private void button2_Click(object sender, EventArgs e)
        {
            itemDel = rateItem;
            itemDel.Invoke();
        }

        //Add new item button
        private void button5_Click(object sender, EventArgs e)
        {
            itemDel = addNewItem;
            itemDel.Invoke();
        }

        //Rate environment button
        private void button3_Click(object sender, EventArgs e)
        {
            itemDel = rateEnvironment;
            itemDel.Invoke();
        }

        //Rate behaviour button
        private void button4_Click(object sender, EventArgs e)
        {
            itemDel = rateBehaviour;
            itemDel.Invoke();
        }

        //Cellclick event shows item name and rating in iName and iRate textbox if cell is selected
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex.Equals(0))
            {
                if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.Value != null)
                {
                    iName.Text = dataGridView1.CurrentCell.Value.ToString();
                    iRate.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                }
            }
            else if (dataGridView1.CurrentCell.ColumnIndex.Equals(1))
            {
                if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.Value != null)
                {
                    iRate.Text = dataGridView1.CurrentCell.Value.ToString();
                    iName.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                }
            }
        }
    }
}

