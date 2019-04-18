using FoodiesReview.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace FoodiesReview.DataBase
{
    public class PersonDataAccess
    {
        public int Add(Person person)
        {
            string query = string.Format("INSERT INTO Person(Name, Email, ID, Gender, Password, Age) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", person.Name, person.Email, person.ID, person.Gender.ToString(), person.Password, person.Age);
            return DataAccess.ExecuteQuery(query);
        }

        public int Remove(Person person)
        {
            string query = string.Format("DELETE FROM Person WHERE Email = '{0}'", person.Email);
            return DataAccess.ExecuteQuery(query);
        }

        public String GetByEmail(String email)
        {
            string query = string.Format("SELECT Email FROM Person WHERE Email = '{0}'", email);
            SqlDataReader reader = DataAccess.GetData(query);
            reader.Read();
            if (reader.HasRows)
            {
                return "exist";
            }
            else
                return "non-exist";
        }

        public String CheckPassword(String password, String email)
        {
            string query = string.Format("SELECT Email, Password FROM Person WHERE Email = '{0}' and Password = '{1}'", email, password);
            using (SqlDataReader reader = DataAccess.GetData(query))
            {
                reader.Read();
                try
                {
                    if (reader.HasRows)
                    {
                        return "match";
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception caught: {0}", e);
                }
                return "unmatch";
            }
        }

        public String GetID(String email)
        {
            string query = string.Format("SELECT ID FROM Person WHERE Email = '{0}'", email);
            SqlDataReader reader = DataAccess.GetData(query);
            reader.Read();
            if (reader.HasRows)
            {
                return reader.GetString(0);
            }
            else
                return "non-exist";
        }
    }
}
