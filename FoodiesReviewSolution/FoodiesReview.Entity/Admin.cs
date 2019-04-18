using System;
using System.Collections.Generic;

namespace FoodiesReview.Entity
{
    public class Admin : Person
    {
        private int key = 1001;
        public Admin(String name, String email, int gender, String password, int age, int k)
        {
            //If key is matched
            if (k == key)
            {
                String id = "AD";
                Name = name;
                Email = email;
                ID = id;
                Gender = (EGender)gender;
                Password = password;
                Age = age;
                KeyCheck = 1;
            }
            else
            {
                KeyCheck = 0;
            }
        }
    }
}
