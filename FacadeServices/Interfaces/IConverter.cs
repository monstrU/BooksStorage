namespace FacadeServices.Interfaces
{
    public  interface IConverter<T, TOut>
    {
        T Convert(TOut source);
        TOut Convert(T source);
    }
}
