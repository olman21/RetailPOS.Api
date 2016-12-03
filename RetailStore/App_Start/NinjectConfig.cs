using Ninject;
using Ninject.Web.Common;
using Retail.Repository.Interfaces;
using RetailStore.DataAccess;
using System;
using System.Reflection;
using System.Web;

namespace RetailStore.App_Start
{
    public static class NinjectConfig
    {
        public static Lazy<IKernel> CreateKernel = new Lazy<IKernel>(() =>
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            RegisterServices(kernel);

            return kernel;
        });

        private static void RegisterServices(KernelBase kernel)
        {
            kernel.Bind<IUnitOfWork>().To<EFUnitOfWork>();
        }
    }

}