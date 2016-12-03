using Retail.Repository.Interfaces;
using RetailStore.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStore.DataAccess
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly RetailContext _context;

        public EFUnitOfWork(RetailContext context)
        {
            _context = context;
            Categories = new CategoryRepository(_context);
            Contacts = new ContactRepository(_context);
            Users = new UserRepository(_context);
            ContactTypes = new ContactTypeRepository(_context);
            MasureUnits = new MeasureUnitRepository(_context);
            OrderDetails = new OrderDetailRepository(_context);
            Orders = new OrderRepository(_context);
            OrderTypes = new OrderTypeRepository(_context);
            PaymentMethods = new PaymentMethodRepository(_context);
            People = new PersonRepository(_context);
            Products = new ProductRepository(_context);
            ContactMethodTypes = new ContactMethodTypeRepository(_context);
            ContactMethodValues = new ContactMethodValueRepository(_context);
            MeasureUnits = new MeasureUnitRepository(_context);
        }

        public ICategoryRepository Categories { get; private set; }
        public IContactRepository Contacts { get; private set; }
        public IUserRepository Users { get; private set; }

        public IContactTypeRepository ContactTypes { get; }
        public IContactMethodTypeRepository ContactMethodTypes { get; }

        public IContactMethodValueRepository ContactMethodValues { get; }
        public IMeasureUnitRepository MasureUnits { get; }
        public IOrderDetailRepository OrderDetails { get; }
        public IOrderRepository Orders { get; }
        public IOrderTypeRepository OrderTypes { get; }
        public IPaymentMethodRepository PaymentMethods { get; }
        public IPersonRepository People { get; }
        public IProductRepository Products { get; }
        public IMeasureUnitRepository MeasureUnits { get; }
        

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
