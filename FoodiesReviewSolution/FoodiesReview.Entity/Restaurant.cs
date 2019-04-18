using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodiesReview.Entity
{
    
    public class Restaurant
    {
        private int environment, rid, behaviour;
        private String name,location;

        //Getting Informations of restaurant
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

        public String Location
        {
            set
            {
                this.location = value;
            }
            get
            {
                return this.location;
            }
        }

        public int Rid
        {
            set
            {
                this.rid = value;
            }
            get
            {
                return this.rid;
            }
        }

        public int Behaviour
        {
            set
            {
                this.behaviour = value;
            }
            get
            {
                return this.behaviour;
            }
        }

        public int Environment
        {
            set
            {
                this.environment = value;
            }
            get
            {
                return this.environment;
            }
        }
    }
}
