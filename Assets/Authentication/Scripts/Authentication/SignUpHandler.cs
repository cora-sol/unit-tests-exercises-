namespace Authentication
{
    public class SignUpHandler
    {
        private readonly LoginParametersValidator loginParametersValidator = new LoginParametersValidator();

        public bool SignUp(IDataBase dataBase, string firstName, string lastName, string email, string password)
        {
            bool success = loginParametersValidator.AreValidParameters(firstName, lastName, email, password);
            if (!success)
                return false;
            UserData userData = new UserData(firstName, lastName, email, password);
            dataBase.Add(userData);
            return true;
        }
    }
}