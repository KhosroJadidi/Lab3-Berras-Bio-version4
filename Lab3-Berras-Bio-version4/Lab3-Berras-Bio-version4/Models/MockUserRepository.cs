using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3_Berras_Bio_version4.Models
{
    public class MockUserRepository : IUserRepository
    {
        public IEnumerable<User> AllUsers =>
            new List<User> 
            { 
                new User
                {
                    Id=1,
                    Email="khosro@mail.com",
                    Password="1234"
                },
                new User
                {
                    Id=2,
                    Email="Pontus@mail.com",
                    Password="5678"
                }
            };

        public User GetUserById(int userId)
        {
            return AllUsers.FirstOrDefault(user=>user.Id==userId);
        }
    }
}
