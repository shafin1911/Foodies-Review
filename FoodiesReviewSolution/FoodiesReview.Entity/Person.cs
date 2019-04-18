using System;
using System.Collections.Generic;

namespace FoodiesReview.Entity
{
    public enum EGender
    {
        male, female
    }

    public abstract class Person
    {
        private String name,id,email,password;
        private EGender gender;
	    private int age, keyCheck;
	
	    //Getting Informations of person
	    public String Name
	    {
            set
            {
                this.name = value;
            }
            get
            {
               return this.name;
            }
        }

        public String ID
        {
            set
            {
                this.id = value;
            }
            get
            {
                return this.id;
            }
        }

        public String Email
        {
            set
            {
                this.email = value;
            }
            get
            {
                return this.email;
            }
        }

        public EGender Gender
        {
            set
            {
                this.gender = value;
            }
            get
            {
                return gender;
            }
        }

        public String Password
        {
            set
            {
                this.password = value;
            }
            get
            {
                return this.password;
            }
        }

        public int Age
        {
            set
            {
                this.age = value;
            }
            get
            {
                return this.age;
            }
        }

        //Only for admin key verify
        public int KeyCheck
        {
            set
            {
                this.keyCheck = value;
            }
            get
            {
                return this.keyCheck;
            }
        }
    }
}
