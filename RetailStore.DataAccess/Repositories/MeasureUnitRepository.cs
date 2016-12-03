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
    public class MeasureUnitRepository : EFRepository<MeasureUnit>, IMeasureUnitRepository
    {
        public MeasureUnitRepository(RetailContext context) : base(context)
        {
        }
    }
}
