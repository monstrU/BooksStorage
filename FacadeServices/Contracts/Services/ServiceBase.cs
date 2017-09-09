using FacadeServices.Interfaces.DataBases;

namespace FacadeServices.Contracts.Services
{
    public abstract class ServiceBase
    {
     
        protected IMemoryStorage MemoryStorage { get; set; }
        protected ServiceBase(IMemoryStorage memoryStorage)
        {
            
            MemoryStorage = memoryStorage;
        }

        
    }
}