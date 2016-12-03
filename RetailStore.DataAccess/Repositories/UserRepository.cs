using Retail.DataAccess;
using Retail.Repository.Interfaces;
using RetailStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStore.DataAccess.Repositories
{
    public class UserRepository : EFRepository<User>, IUserRepository
    {
        public UserRepository(RetailContext context) : base(context)
        {
        }
    }
}
