using System.Collections.Generic;
using UnityEngine;

namespace Authentication
{
    public class PlayerPrefsDataBase : IDataBase
    {
        private const string DataBaseUsersPlayerPref = nameof(DataBaseUsersPlayerPref);

        private Dictionary<string, UserData> users;

        void IDataBase.Initialize()
        {
            string serializedUsers = PlayerPrefs.GetString(DataBaseUsersPlayerPref, null);
            if (serializedUsers == null)
            {
                users = new Dictionary<string, UserData>();
                return;
            }
            users = JsonUtility.FromJson<Dictionary<string, UserData>>(serializedUsers) ?? new Dictionary<string, UserData>();
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
            string serializedUsers = JsonUtility.ToJson(users);
            PlayerPrefs.SetString(DataBaseUsersPlayerPref, serializedUsers);
        }
    }
}