using FoodiesReview.Entity;
using FoodiesReview.DataBase;
using System;
using System.Collections.Generic;
using System.Data;

namespace FoodiesReview.Service
{
    public class RestaurantService
    {
        RestaurantDataAccess restaurantDataAccess = new RestaurantDataAccess();

        public int AddRestaurant(Restaurant restaurant)
        {
            return restaurantDataAccess.AddRestaurant(restaurant);
        }

        public int RemoveRestaurant(Restaurant restaurant)
        {
            return restaurantDataAccess.RemoveRestaurant(restaurant);
        }

        public String GetByRestaurant(Restaurant restaurant)
        {
            return restaurantDataAccess.GetByRestaurant(restaurant);
        }

        public String GetByLocation(Restaurant restaurant)
        {
            return restaurantDataAccess.GetByLocation(restaurant);
        }

        public int GetRID()
        {
            return restaurantDataAccess.GetRID();
        }

        public int GetRID(Restaurant restaurant)
        {
            return restaurantDataAccess.GetRID(restaurant);
        }

        public List<String> GetAllByLocation()
        {
            return restaurantDataAccess.GetAllByLocation();
        }

        public List<String> GetAllByName()
        {
            return restaurantDataAccess.GetAllByName();
        }

        public List<Restaurant> GetSearchListByName(Restaurant restaurant)
        {
            return restaurantDataAccess.GetSearchListByName(restaurant);
        }

        public List<Restaurant> GetSearchListByLocation(Restaurant restaurant)
        {
            return restaurantDataAccess.GetSearchListByLocation(restaurant);
        }

        public List<Restaurant> GetAllSearchList()
        {
            return restaurantDataAccess.GetAllSearchList();
        }

        public Restaurant GetAllRate(Restaurant restaurant)
        {
            return restaurantDataAccess.GetAllRate(restaurant);
        }

        public int RateEnvironment(Restaurant restaurant)
        {
            return restaurantDataAccess.RateEnvironment(restaurant);
        }

        public int RateBehaviour(Restaurant restaurant)
        {
            return restaurantDataAccess.RateBehaviour(restaurant);
        }

        public DataTable GetRestaurantTable()
        {
            return restaurantDataAccess.GetRestaurantTable();
        }
    }
}
