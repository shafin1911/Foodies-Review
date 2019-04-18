using FoodiesReview.Entity;
using FoodiesReview.DataBase;
using System;
using System.Collections.Generic;

namespace FoodiesReview.Service
{
    public class PersonService
    {
        PersonDataAccess personDataAccess = new PersonDataAccess();

        public int Add(Person person)
        {
            return personDataAccess.Add(person);
        }

        public int Remove(Person person)
        {
            return personDataAccess.Remove(person);
        }

        public String GetByEmail(String email)
        {
            return personDataAccess.GetByEmail(email);
        }

        public String CheckPassword(String password, String email)
        {
            return personDataAccess.CheckPassword(password, email);
        }

        public String GetID(String email)
        {
            return personDataAccess.GetID(email);
        }
    }
}
