using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodiesReview.Entity
{
    public class Item
    {
        private int rid, iid, rating;
        private String name;

        //Getting Informations of item
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

        public int Iid
        {
            set
            {
                this.iid = value;
            }
            get
            {
                return this.iid;
            }
        }

        public int Rating
        {
            set
            {
                this.rating = value;
            }
            get
            {
                return this.rating;
            }
        }
    }
}
