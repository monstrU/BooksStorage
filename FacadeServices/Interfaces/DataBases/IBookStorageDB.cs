namespace FacadeServices.Interfaces.DataBases
{
    public interface IBookStorageDb
    {
        IBooksMapper BooksMapper { get; }
    }
}
