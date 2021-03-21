using RestaurantAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;
        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if(_dbContext.Database.CanConnect())
            {
                if(!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name = "KFC",
                    Category = "Fast Food",
                    Description = "KFC (short for Kentucky Fried Chicken) is an American fast food restaurant chain headquartered in Louisville, Kentucky, that specializes in fried chicken.",
                    ContactEmail = "contact@kfc.com",
                    HasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Nashville Hot Chicken",
                            Price = 10.30M,
                        },

                        new Dish()
                        {
                            Name = "Chicken Nuggets",
                            Price = 5.30M,
                        }
                    },
                    Address = new Address()
                    {
                        City = "Kraków",
                        Street = "Długa 5",
                        PostalCode = "30-001",
                    }
                },

                new Restaurant()
                {
                    Name = "McDonalds",
                    Category = "Fast Food",
                    Description = "McDonald's (MCD) is a fast food, limited service restaurant with more than 35,000 restaurants in over 100 countries.",
                    ContactEmail = "contact@mcdonalds.com",
                    HasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Cheese Burger",
                            Price = 2.80M,
                        },

                        new Dish()
                        {
                            Name = "Big Mac",
                            Price = 6.00M,
                        }
                    },
                    Address = new Address()
                    {
                        City = "Kraków",
                        Street = "Kwiatowa 6",
                        PostalCode = "30-001",
                    }
                }

            };

            return restaurants;
        }
    }
}
