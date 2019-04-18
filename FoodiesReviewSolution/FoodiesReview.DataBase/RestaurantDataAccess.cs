using FoodiesReview.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace FoodiesReview.DataBase
{
    public class RestaurantDataAccess
    {
        public int AddRestaurant(Restaurant restaurant)
        {
            string query = string.Format("INSERT INTO Restaurant(RID, Name, Location, Environment, Behaviour) VALUES('{0}', '{1}', '{2}', '{3}', '{4}')", restaurant.Rid, restaurant.Name, restaurant.Location, restaurant.Environment, restaurant.Behaviour);
            return DataAccess.ExecuteQuery(query);
        }

        public int RemoveRestaurant(Restaurant restaurant)
        {
            string query = string.Format("DELETE FROM Restaurant WHERE RID = '{0}'", restaurant.Rid);
            return DataAccess.ExecuteQuery(query);
        }

        public int RateEnvironment(Restaurant restaurant)
        {
            int result = 0;
            int count = 0;
            string query = string.Format("SELECT Environment FROM Restaurant WHERE RID = '{0}'", restaurant.Rid);
            SqlDataReader reader = DataAccess.GetData(query);
            reader.Read();
            if (reader.HasRows)
            {
                result = reader.GetInt32(0);
            }

            count = (result + restaurant.Environment) / 2;
            string query2 = string.Format("UPDATE Restaurant SET Environment = '{0}' WHERE RID = '{1}'", count, restaurant.Rid);
            return DataAccess.ExecuteQuery(query2);
        }

        public int RateBehaviour(Restaurant restaurant)
        {
            int result = 0;
            int count = 0;
            string query = string.Format("SELECT Behaviour FROM Restaurant WHERE RID = '{0}'", restaurant.Rid);
            SqlDataReader reader = DataAccess.GetData(query);
            reader.Read();
            if (reader.HasRows)
            {
                result = reader.GetInt32(0);
            }

            count = (result + restaurant.Behaviour) / 2;
            string query2 = string.Format("UPDATE Restaurant SET Behaviour = '{0}' WHERE RID = '{1}'", count, restaurant.Rid);
            return DataAccess.ExecuteQuery(query2);
        }

        public String GetByRestaurant(Restaurant restaurant)
        {
            string query = string.Format("SELECT Name FROM Restaurant WHERE Name = '{0}'", restaurant.Name);
            SqlDataReader reader = DataAccess.GetData(query);
            reader.Read();
            if (reader.HasRows)
            {
                return "exist";
            }
            else
                return "non-exist";
        }

        public String GetByLocation(Restaurant restaurant)
        {
            string query = string.Format("SELECT Name FROM Restaurant WHERE Location = '{0}' and Name = '{1}'", restaurant.Location, restaurant.Name);
            SqlDataReader reader = DataAccess.GetData(query);
            reader.Read();
            if (reader.HasRows)
            {
                return "exist";
            }
            else
                return "non-exist";
        }

        public int GetRID()
        {
            string query = string.Format("SELECT Top 1 RID FROM Restaurant Order By RID DESC");
            SqlDataReader reader = DataAccess.GetData(query);
            reader.Read();
            if (reader.HasRows)
            {
                return reader.GetInt32(0);
            }
            return 0;
        }

        public int GetRID(Restaurant restaurant)
        {
            string query = string.Format("SELECT RID FROM Restaurant WHERE Location = '{0}' and Name = '{1}'", restaurant.Location, restaurant.Name);
            SqlDataReader reader = DataAccess.GetData(query);
            reader.Read();
            if (reader.HasRows)
            {
                return reader.GetInt32(0);
            }
            return 0;
        }

        public List<String> GetAllByLocation()
        {
            string query = "SELECT Location FROM Restaurant";
            SqlDataReader reader = DataAccess.GetData(query);

            List<String> location = new List<String>();
            while (reader.Read())
            {
                location.Add(reader.GetString(0));
            }
            return location;
        }

        public List<String> GetAllByName()
        {
            string query = "SELECT Name FROM Restaurant";
            SqlDataReader reader = DataAccess.GetData(query);

            List<String> name = new List<String>();
            while (reader.Read())
            {
                name.Add(reader.GetString(0));
            }
            return name;
        }

        public List<Restaurant> GetSearchListByName(Restaurant restaurant)
        {
            string query = string.Format("SELECT Name, RID, Location FROM Restaurant where Name = '{0}'", restaurant.Name);
            SqlDataReader reader = DataAccess.GetData(query);

            List<Restaurant> SearchList = new List<Restaurant>();
            while (reader.Read())
            {
                Restaurant restaurant1 = new Restaurant();
                restaurant1.Name = reader.GetString(0);
                restaurant1.Rid = reader.GetInt32(1);
                restaurant1.Location = reader.GetString(2);
                SearchList.Add(restaurant1);
            }
            return SearchList;
        }

        public List<Restaurant> GetSearchListByLocation(Restaurant restaurant)
        {
            string query = string.Format("SELECT Name, RID, Location FROM Restaurant where Location = '{0}'", restaurant.Location);
            SqlDataReader reader = DataAccess.GetData(query);

            List<Restaurant> SearchList = new List<Restaurant>();
            while (reader.Read())
            {
                Restaurant restaurant1 = new Restaurant();
                restaurant1.Name = reader.GetString(0);
                restaurant1.Rid = reader.GetInt32(1);
                restaurant1.Location = reader.GetString(2);
                SearchList.Add(restaurant1);
            }
            return SearchList;
        }

        public List<Restaurant> GetAllSearchList()
        {
            string query = "SELECT Name, Location FROM Restaurant";
            SqlDataReader reader = DataAccess.GetData(query);

            List<Restaurant> SearchList = new List<Restaurant>();
            while (reader.Read())
            {
                Restaurant restaurant = new Restaurant();
                restaurant.Name = reader.GetString(0);
                restaurant.Location = reader.GetString(1);
                SearchList.Add(restaurant);
            }
            return SearchList;
        }

        public Restaurant GetAllRate(Restaurant restaurant)
        {
            string query = string.Format("SELECT RID, Environment, Behaviour FROM Restaurant where Location = '{0}' and Name = '{1}'", restaurant.Location, restaurant.Name);
            SqlDataReader reader = DataAccess.GetData(query);
            Restaurant RateList = new Restaurant();
            while (reader.Read())
            {
                RateList.Environment = reader.GetInt32(1);
                RateList.Rid = reader.GetInt32(0);
                RateList.Behaviour = reader.GetInt32(2);
            }
            return RateList;
        }

        public DataTable GetRestaurantTable()
        {
            string query = "SELECT Name, Location FROM Restaurant";
            SqlDataReader reader = DataAccess.GetData(query);

            DataTable table = new DataTable();
            DataColumn column1 = new DataColumn("Name");
            DataColumn column2 = new DataColumn("Location");
            table.Columns.Add(column1);
            table.Columns.Add(column2);

            while (reader.Read())
            {
                table.Rows.Add(reader.GetString(0), reader.GetString(1));
            }
            return table;
        }
    }
}
