using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Password_ver;

namespace pwd_ver_test
{
    [TestClass]
    public class UnitTest1
    {
        PasswordValidator pv = new PasswordValidator();
        [TestMethod]
        public void GivingCorrectPassword_doesNotThrowAnException()
        {
            ExternalPwdValidator e = new ExternalPwdValidator();
            bool result = pv.Verify("abcD123xyz",e);
            Assert.AreEqual(true, result, "error");
        }

        [TestMethod, ExpectedException(typeof(Exception))]
        public void GivingEmptyPassword_VerifyingIt_ShouldThrowExceptionMessage()
        {
            ExternalPwdValidator e = new ExternalPwdValidator();
            bool result = pv.Verify("",e);
            Assert.AreEqual(false, result, "error");
        }

        [TestMethod, ExpectedException(typeof(Exception))]
        public void GivingPasswordLessThan8Characters_VerifyingIt_ShouldThrowExceptionMessage()
        {
            ExternalPwdValidator e = new ExternalPwdValidator();
            bool result = pv.Verify("ag3C",e);
            Assert.AreEqual(false, result, "error");
        }

        [TestMethod, ExpectedException(typeof(Exception))]
        public void GivingAllSmallCharactersAsPassword_VerifyingIt_ShouldThrowExceptionMessage()
        {
            ExternalPwdValidator e = new ExternalPwdValidator();
            bool result = pv.Verify("abcbcdefghi",e);
            Assert.AreEqual(false, result, "error");
        }

        [TestMethod, ExpectedException(typeof(Exception))]
        public void GivingNoSmallCharactersInAPassword_VerifyingIt_ShouldThrowExceptionMessage()
        {
            ExternalPwdValidator e = new ExternalPwdValidator();
            bool result = pv.Verify("ABCD12345",e);
            Assert.AreEqual(false, result, "error");
        }

        [TestMethod, ExpectedException(typeof(Exception))]
        public void GivingNoNumbersInAPassword_VerifyingIt_ShouldThrowExceptionMessage()
        {
            ExternalPwdValidator e = new ExternalPwdValidator();
            bool result = pv.Verify("ABCDcvhsfk",e);
            Assert.AreEqual(false, result, "error");
        }

        [TestMethod, ExpectedException(typeof(Exception))]
        public void PasswordNotSatisfyingThreeConditions_VerifyingIt_ShouldThrowExceptionMessage()
        {
            ExternalPwdValidator e = new ExternalPwdValidator();
            bool result = pv.Verify("ab",e);
            Assert.AreEqual(false, result, "error");
        }

        [TestMethod, ExpectedException(typeof(Exception))]
        public void GivingNoBigCharactersInAPassword_VerifyingIt_ShouldThrowExceptionMessage()
        {
            ExternalPwdValidator e = new ExternalPwdValidator();
            bool result = pv.Verify("ab",e);
            Assert.AreEqual(false, result, "error");
        }

        [TestMethod]
        public void GivingCharactersLengthGreaterThan8InAPassword_VerifyingIt_DoesThrowExceptionMessage()
        {
            InternalPwdValidator i = new InternalPwdValidator();
            bool result = pv.Verify("jadvoiadv76", i);
            Assert.AreEqual(true, result, "error");
        }

        [TestMethod, ExpectedException(typeof(Exception))]
        public void GivingCharactersLengthLessThan8InAPassword_VerifyingIt_DoesThrowExceptionMessage()
        {
            InternalPwdValidator i = new InternalPwdValidator();
            bool result = pv.Verify("abc", i);
            Assert.AreEqual(false, result, "error");
        }
    }
}
