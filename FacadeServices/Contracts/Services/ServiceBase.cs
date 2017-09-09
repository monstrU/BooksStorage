using FacadeServices.Interfaces.DataBases;

namespace FacadeServices.Contracts.Services
{
    public abstract class ServiceBase
    {
        protected IBookStorageDb BookStorageDb { get; }

        protected ServiceBase(IBookStorageDb bookStorageDb)
        {
            BookStorageDb = bookStorageDb;
        }

        
    }
}