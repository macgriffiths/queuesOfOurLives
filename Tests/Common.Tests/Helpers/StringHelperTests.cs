using Common.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Tests.Helpers
{
    [TestClass]
    public class StringHelperTests
    {
        [TestMethod]
        public void GetNameAfterCharacter_GiveSentenceAndCharacter_ShouldReturnName_Test()
        {
            var given = "Hello my name is, Griffiths";

            var expected = "Griffiths";

            var actual = StringHelper.GetNameAfterCharacter(given, ',');

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void GetNameAndSurnameAfterCharacter_GiveSentenceAndCharacter_ShouldReturnNameAndSurname_Test()
        {
            var given = "Hello my name is, Griffiths Sibeko";

            var expected = "Griffiths Sibeko";

            var actual = StringHelper.GetNameAfterCharacter(given, ',');

            Assert.AreEqual(actual, expected);
        }
    }
}
