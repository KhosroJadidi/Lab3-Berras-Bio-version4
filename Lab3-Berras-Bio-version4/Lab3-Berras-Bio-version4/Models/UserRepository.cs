using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3_Berras_Bio_version4.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext appDbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<User> AllUsers => appDbContext.Users;

        //public IEnumerable<User> AllUsers 
        //{
        //    get 
        //    {
        //        return appDbContext.Users;
        //    }
        //}

        public User GetUserById(int userId)
        {
            return appDbContext.Users.FirstOrDefault(user=>user.Id==userId);
        }
    }
}
