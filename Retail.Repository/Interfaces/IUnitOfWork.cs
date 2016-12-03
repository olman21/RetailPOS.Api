using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get; }
        IContactRepository Contacts { get; }
        IUserRepository Users { get; }
        IContactTypeRepository ContactTypes { get; }
        IContactMethodTypeRepository ContactMethodTypes { get; }
        IContactMethodValueRepository ContactMethodValues { get; }
        IMeasureUnitRepository MasureUnits { get; }
        IOrderDetailRepository OrderDetails { get; }
        IOrderRepository Orders { get; }
        IOrderTypeRepository OrderTypes { get; }
        IPaymentMethodRepository PaymentMethods { get; }
        IPersonRepository People { get; }
        IProductRepository Products { get; }
        IMeasureUnitRepository MeasureUnits { get; }

        int Complete();
    }
}

