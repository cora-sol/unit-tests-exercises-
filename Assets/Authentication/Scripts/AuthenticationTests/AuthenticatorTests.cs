using Authentication;
using NUnit.Framework;

namespace AuthenticationTests
{
    public class AuthenticatorTests
    {
        private Authenticator authenticator;

        [SetUp]
        private void SetUp()
        {
            authenticator = new Authenticator();
        }

        [TearDown]
        private void TearDown()
        {
            authenticator = null;
        }

        [Test]
        public void XXX()
        {

        }
    }
}
