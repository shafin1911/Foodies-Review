using System;
using System.Collections.Generic;

namespace FoodiesReview.Entity
{
    public class User: Person
    {
        public User(String name, String email, int gender, String password, int age)
        {
            String id = "US";
            Name = name;
            Email = email;
            ID = id;
            Gender = (EGender)gender;
            Password = password;
            Age = age;
        }
    }
}
