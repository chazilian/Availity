using Exercise4;

namespace Exercise4Tests
{


    public class ParenthesesServiceTests
    {
        private readonly IParenthesesService service;

        public ParenthesesServiceTests()
        {
            service = new ParenthesesService();
        }

        [Test]
        public void Empty_String_Test()
        {
            //Arrange
            //Act
            //Assert
            Assert.AreEqual(true, service.checkParaentheses(""));
        }

        [Test]
        public void Null_Test()
        {
            //Arrange
            //Act
            //Assert
            Assert.AreEqual(false, service.checkParaentheses(null));
        }

        [Test]
        public void Only_Fuzz_Test()
        {
            //Arrange
            //Act
            //Assert
            Assert.AreEqual(true, service.checkParaentheses("abc123"));
        }

        [Test]
        public void Valid_Paraentheses_Test()
        {
            //Arrange
            //Act
            //Assert
            Assert.AreEqual(true, service.checkParaentheses("()"));
        }

        [Test]
        public void Valid_Paraentheses_Nested_Test()
        {
            //Arrange
            //Act
            //Assert
            Assert.AreEqual(true, service.checkParaentheses("((())(()))"));
        }

        [Test]
        public void Valid_Paraentheses_With_Fuzz_Test()
        {
            //Arrange
            //Act
            //Assert
            Assert.AreEqual(true, service.checkParaentheses("1(2(3)4)a(b(c)d)e"));
        }

        [Test]
        public void Invalid_Paraentheses_Test()
        {
            //Arrange
            //Act
            //Assert
            Assert.AreEqual(false, service.checkParaentheses("())"));
        }

        [Test]
        public void Invalid_Paraentheses_Nested_Test()
        {
            //Arrange
            //Act
            //Assert
            Assert.AreEqual(false, service.checkParaentheses("(()()(()()"));
        }

        [Test]
        public void Invalid_Paraentheses_With_Fuzz_Test()
        {
            //Arrange
            //Act
            //Assert
            Assert.AreEqual(false, service.checkParaentheses("1(2(3)4(a(b)c(d)e"));
        }
    }
}