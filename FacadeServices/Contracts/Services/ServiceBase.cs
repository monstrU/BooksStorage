using FacadeServices.Interfaces.DataBases;

namespace FacadeServices.Contracts.Services
{
    public abstract class ServiceBase
    {
        protected IBookStorageDb BookStorageDb { get; }

        public IMemoryStorage MemoryStorage { get; set; }
        protected ServiceBase(IBookStorageDb bookStorageDb, IMemoryStorage memoryStorage)
        {
            BookStorageDb = bookStorageDb;
            MemoryStorage = memoryStorage;
        }

        
    }
}