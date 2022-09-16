namespace src
{
    public interface IRepo<T>
    {

        Task<List<T>> Get();
        Task Save(T data);

    }

    public interface IRepodb<T, C>
    {

        Task<List<T>> Get();
        Task Save(T data, C contact);

    }
}