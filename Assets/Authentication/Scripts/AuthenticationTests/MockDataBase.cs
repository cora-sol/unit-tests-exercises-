using System.Collections.Generic;
using Authentication;

namespace AuthenticationTests
{
    public class MockDataBase : IDataBase
    {
        private readonly Dictionary<string, UserData> users = new Dictionary<string, UserData>();

        void IDataBase.Initialize()
        {
        }

        void IDataBase.Add(UserData user)
        {
            users.Add(user.Email, user);
        }

        bool IDataBase.TryGet(string email, out UserData user)
        {
            return users.TryGetValue(email, out user);
        }

        void IDataBase.Dispose()
        {
        }
    }
}