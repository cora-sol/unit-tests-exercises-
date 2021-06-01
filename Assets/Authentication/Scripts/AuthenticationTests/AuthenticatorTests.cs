using Authentication;
using NUnit.Framework;
using Assert = UnityEngine.Assertions.Assert;

namespace AuthenticationTests
{
    public class AuthenticatorTests
    {
        private const string ValidFirstName = "nombresito";
        private const string ValidLastName = "apellidito";
        private const string ValidEmail = "cosito@cosiato.com";
        private const string ValidPassword = "brainz11";
        private const string ShortString = "aa";
        private const string LongStringWithSpaces = "  dad ajkdha djkha skjhdas kj kjfkljsdafk sdgfksdgf jgfuhwoq gfuhoweqb fouwbfo wbqefbw bsadf bsdk ";

        private Authenticator authenticator;
        private IDataBase mockDataBase;

        [SetUp]
        public void SetUp()
        {
            mockDataBase = new MockDataBase();
            authenticator = new Authenticator(mockDataBase);
        }

        [TearDown]
        public void TearDown()
        {
            authenticator = null;
        }

        [Test]
        public void IsNotLoggedInAtStart()
        {
            Assert.IsFalse(authenticator.IsLoggedIn);
        }

        [Test]
        public void IsInSignUpPanelAtStart()
        {
            Assert.AreEqual(PanelType.SignUp, authenticator.CurrentPanel);
        }

        #region SignUp

        [TestCase(ValidFirstName, ValidLastName, "", ValidPassword)]
        [TestCase(ValidFirstName, ValidLastName, "   ", ValidPassword)]
        [TestCase(ValidFirstName, ValidLastName, "23813", ValidPassword)]
        [TestCase(ValidFirstName, ValidLastName, "@23813", ValidPassword)]
        [TestCase(ValidFirstName, ValidLastName, "23813@", ValidPassword)]
        [TestCase(ValidFirstName, ValidLastName, LongStringWithSpaces, ValidPassword)]
        public void IsNotLoggedInAfterInvalidTrySignUpWithInvalidEmail(string firstName, string lastName, string email, string password)
        {
            authenticator.SignUp(firstName, lastName, email, password);
            Assert.IsFalse(authenticator.IsLoggedIn);
        }

        [TestCase("", ValidLastName, ValidEmail, ValidPassword)]
        [TestCase("     ", ValidLastName, ValidEmail, ValidPassword)]
        [TestCase("  a   ", ValidLastName, ValidEmail, ValidPassword)]
        [TestCase(ShortString, ValidLastName, ValidEmail, ValidPassword)]
        [TestCase(LongStringWithSpaces, ValidLastName, ValidEmail, ValidPassword)]
        public void IsNotLoggedInAfterInvalidTrySignUpWithInvalidFirstName(string firstName, string lastName, string email, string password)
        {
            authenticator.SignUp(firstName, lastName, email, password);
            Assert.IsFalse(authenticator.IsLoggedIn);
        }

        [TestCase(ValidFirstName, "", ValidEmail, ValidPassword)]
        [TestCase(ValidFirstName, "     ", ValidEmail, ValidPassword)]
        [TestCase(ValidFirstName, "  a   ", ValidEmail, ValidPassword)]
        [TestCase(ValidFirstName, ShortString, ValidEmail, ValidPassword)]
        [TestCase(ValidFirstName, LongStringWithSpaces, ValidEmail, ValidPassword)]
        public void IsNotLoggedInAfterInvalidTrySignUpWithInvalidLastName(string firstName, string lastName, string email, string password)
        {
            authenticator.SignUp(firstName, lastName, email, password);
            Assert.IsFalse(authenticator.IsLoggedIn);
        }

        [TestCase(ValidFirstName, "", ValidEmail, ValidPassword)]
        [TestCase(ValidFirstName, "     ", ValidEmail, ValidPassword)]
        [TestCase(ValidFirstName, "  a   ", ValidEmail, ValidPassword)]
        [TestCase(ValidFirstName, ShortString, ValidEmail, ValidPassword)]
        [TestCase(ValidFirstName, LongStringWithSpaces, ValidEmail, ValidPassword)]
        public void IsNotLoggedInAfterInvalidTrySignUpWithInvalidPassword(string firstName, string lastName, string email, string password)
        {
            authenticator.SignUp(firstName, lastName, email, password);
            Assert.IsFalse(authenticator.IsLoggedIn);
        }

        [TestCase("", ValidLastName, ValidEmail, ValidPassword)]
        [TestCase(ValidFirstName, "", ValidEmail, ValidPassword)]
        [TestCase(ValidFirstName, ValidLastName, "", ValidPassword)]
        [TestCase(ValidFirstName, ValidLastName, ValidEmail, "")]
        public void IsInSignUpPanelAfterInvalidSignUp(string firstName, string lastName, string email, string password)
        {
            authenticator.SignUp(firstName, lastName, email, password);
            Assert.AreEqual(PanelType.SignUp, authenticator.CurrentPanel);
        }

        [TestCase(ValidFirstName, ValidLastName, ValidEmail, ValidPassword)]
        public void IsLoggedAfterSignUpWithValidParameters(string firstName, string lastName, string email, string password)
        {
            authenticator.SignUp(firstName, lastName, email, password);
            Assert.IsTrue(authenticator.IsLoggedIn);
        }

        [TestCase(ValidFirstName, ValidLastName, ValidEmail, ValidPassword)]
        public void IsInSettingsPanelAfterSignUp(string firstName, string lastName, string email, string password)
        {
            authenticator.SignUp(firstName, lastName, email, password);
            Assert.AreEqual(PanelType.Settings, authenticator.CurrentPanel);
        }

        #endregion

        #region SignIn

        [TestCase(ValidFirstName, ValidLastName, ValidEmail, ValidPassword)]
        public void IsNotLoggedInAfterInvalidTrySignInWhenNotInDataBase(string firstName, string lastName, string email, string password)
        {
            authenticator.SignIn(email, password);
            Assert.IsFalse(authenticator.IsLoggedIn);
        }

        [TestCase(ValidFirstName, ValidLastName, ValidEmail, ValidPassword)]
        public void IsLoggedInAfterSignInWhenInDataBase(string firstName, string lastName, string email, string password)
        {
            mockDataBase.Add(new UserData(firstName, lastName, email, password));
            authenticator.SignIn(email, password);
            Assert.IsTrue(authenticator.IsLoggedIn);
        }

        #endregion
    }
}
