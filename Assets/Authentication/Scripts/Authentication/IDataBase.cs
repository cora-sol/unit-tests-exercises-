namespace Authentication
{
    public interface IDataBase
    {
        void Initialize();
        void Add(UserData user);
        bool TryGet(string email, out UserData user);
        void Dispose();
    }
}