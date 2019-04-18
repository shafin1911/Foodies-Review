using FoodiesReview.Entity;
using FoodiesReview.DataBase;
using System;
using System.Collections.Generic;
using System.Data;

namespace FoodiesReview.Service
{
    public class ItemService
    {
        ItemDataAccess itemtDataAccess = new ItemDataAccess();

        public int AddItem(Item item)
        {
            return itemtDataAccess.AddItem(item);
        }

        public int RemoveItem(Item item)
        {
            return itemtDataAccess.RemoveItem(item);
        }

        public int RemoveAllItem(Item item)
        {
            return itemtDataAccess.RemoveAllItem(item);
        }

        public int GetIID()
        {
            return itemtDataAccess.GetIID();
        }

        public String GetByItemName(Item item)
        {
            return itemtDataAccess.GetByItemName(item);
        }

        public int GetItemsRating(Item item)
        {
            return itemtDataAccess.GetItemsRating(item);
        }

        public DataTable GetTable(Item item)
        {
            return itemtDataAccess.GetTable(item);
        }

        public int RateItem(Item item)
        {
            return itemtDataAccess.RateItem(item);
        }
    }
}
