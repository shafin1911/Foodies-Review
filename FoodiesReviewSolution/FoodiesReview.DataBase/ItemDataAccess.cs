using FoodiesReview.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FoodiesReview.DataBase
{
    public class ItemDataAccess
    {
        public int AddItem(Item item)
        {
            string query = string.Format("INSERT INTO Item(RID, IID, Name, Rating) VALUES('{0}', '{1}', '{2}', '{3}')", item.Rid, item.Iid, item.Name, item.Rating);
            return DataAccess.ExecuteQuery(query);
        }

        public int RemoveItem(Item item)
        {
            string query = string.Format("DELETE FROM Item WHERE Name = '{0}' and RID ='{1}'", item.Name, item.Rid);
            return DataAccess.ExecuteQuery(query);
        }

        public int RemoveAllItem(Item item)
        {
            string query = string.Format("DELETE FROM Item WHERE RID = '{0}'", item.Rid);
            return DataAccess.ExecuteQuery(query);
        }

        public int RateItem(Item item)
        {
            int result = 0;
            int count = 0;
            string query = string.Format("SELECT Rating FROM Item WHERE RID = '{0}' and Name = '{1}'", item.Rid, item.Name);
            SqlDataReader reader = DataAccess.GetData(query);
            reader.Read();
            if (reader.HasRows)
            {
                result = reader.GetInt32(0);
            }

            count = (result + item.Rating) / 2;
            string query2 = string.Format("UPDATE Item SET Rating = '{0}' WHERE RID = '{1}' and Name = '{2}'", count, item.Rid, item.Name);
            return DataAccess.ExecuteQuery(query2);
        }

        public int GetIID()
        {
            string query = string.Format("SELECT Top 1 IID FROM Item Order By IID DESC");
            SqlDataReader reader = DataAccess.GetData(query);
            reader.Read();
            if (reader.HasRows)
            {
                return reader.GetInt32(0);
            }
            return 0;
        }

        public String GetByItemName(Item item)
        {
            string query = string.Format("SELECT Name FROM Item WHERE RID = '{0}' and Name = '{1}'", item.Rid, item.Name);
            SqlDataReader reader = DataAccess.GetData(query);
            reader.Read();
            if (reader.HasRows)
            {
                return "exist";
            }
            else
                return "non-exist";
        }

        public int GetItemsRating(Item item)
        {
            string query = string.Format("SELECT Rating FROM Item WHERE RID = '{0}'", item.Rid);
            SqlDataReader reader = DataAccess.GetData(query);
            int result = 0;
            int count = 0;
            while (reader.Read())
            {
                count++;
                result = result + reader.GetInt32(0);
            }

            if (count == 0)
            {
                return 0;
            }
            else
                return result / count;
        }

        public DataTable GetTable(Item item)
        {
            string query = string.Format("SELECT Name, Rating FROM Item where RID = '{0}'", item.Rid);
            SqlDataReader reader = DataAccess.GetData(query);
            DataTable table = new DataTable();
            DataColumn column1 = new DataColumn("Name");
            DataColumn column2 = new DataColumn("Rate");
            table.Columns.Add(column1);
            table.Columns.Add(column2);

            while (reader.Read())
            {
                table.Rows.Add(reader.GetString(0), reader.GetInt32(1));
            }
            return table;
        }
    }
}
