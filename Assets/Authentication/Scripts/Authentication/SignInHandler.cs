namespace Authentication
{
    public class SignInHandler
    {
        private readonly LoginParametersValidator loginParametersValidator = new LoginParametersValidator();

        public bool SignIn(IDataBase dataBase, string email, string password)
        {
            bool success = loginParametersValidator.AreValidEmailAndPassword(email, password);
            if (!success)
                return false;
            bool isInDataBase = dataBase.TryGet(email, out UserData dataBaseUserData);
            if (!isInDataBase)
                return false;
            if (dataBaseUserData.Password != password)
                return false;
            return true;
        }
    }
}