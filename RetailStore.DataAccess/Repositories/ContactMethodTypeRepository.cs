using Retail.DataAccess;
using Retail.Repository;
using Retail.Repository.Interfaces;
using RetailStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStore.DataAccess.Repositories
{
    public class ContactMethodTypeRepository : EFRepository<ContactMethodType>, IContactMethodTypeRepository
    {
        public ContactMethodTypeRepository(RetailContext context) : base(context)
        {
        }
    }
}
