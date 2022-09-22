using Exercise6.Models;
using Exercise6.Services;

namespace Exercise6Tests
{
    public class SeperateEnrolleeServceTests
    {
        [Test]
        public void Text_Constructor_Test()
        {
            //Arrange
            List<EnrolleeModel> list = new List<EnrolleeModel>();
            list.Add(new EnrolleeModel("abc123,Mike Jones,2,AllState"));
            list.Add(new EnrolleeModel("jedi433,Obi-Wan Kenobi,8,The Force"));
            //Act
            var svc = new SeperateEnrolleeService();
            var results = svc.SeperateEnrollee(list);
            //Assert
            Assert.That(results.ContainsKey("AllState"), Is.EqualTo(true));
            Assert.That(results.ContainsKey("The Force"), Is.EqualTo(true));
        }

       [Test]
        public void Text_Constructor_Missing_UserId_Test()
        {
            //Arrange
            List<EnrolleeModel> list = new List<EnrolleeModel>();
            list.Add(new EnrolleeModel(",Mike Jones,2,AllState"));
            var expected1 = new EnrolleeModel("", "Mike", "Jones", 2, "AllState");
            //Act
            var svc = new SeperateEnrolleeService();
            var results = svc.SeperateEnrollee(list);
            //Assert
            Assert.That(results["AllState"].Count(), Is.EqualTo(1));
            CompareEnrolleeAssert(results["AllState"].First(), expected1);
        }

        [Test]
        public void Text_Constructor_Test_Missing_Part_Of_Name_Test()
        {
            //Arrange
            List<EnrolleeModel> list = new List<EnrolleeModel>();
            list.Add(new EnrolleeModel("abc123,Jones,2,AllState"));
            var expected1 = new EnrolleeModel("abc123", "Jones", "Jones", 2, "AllState");
            //Act
            var svc = new SeperateEnrolleeService();
            var results = svc.SeperateEnrollee(list);
            //Assert
            Assert.That(results["AllState"].Count(), Is.EqualTo(1));
            CompareEnrolleeAssert(results["AllState"].First(), expected1);
        }

        [Test]
        public void Text_Constructor_Test_Missing_Whole_Name_Test()
        {
            //Arrange
            List<EnrolleeModel> list = new List<EnrolleeModel>();
            list.Add(new EnrolleeModel("abc123,,2,AllState"));
            var expected1 = new EnrolleeModel("abc123", "", "", 2, "AllState");
            //Act
            var svc = new SeperateEnrolleeService();
            var results = svc.SeperateEnrollee(list);
            //Assert
            Assert.That(results["AllState"].Count(), Is.EqualTo(1));
            CompareEnrolleeAssert(results["AllState"].First(), expected1);
        }

        [Test]
        public void Text_Constructor_Test_Missing_Version_Test()
        {
            //Arrange
            List<EnrolleeModel> list = new List<EnrolleeModel>();
            list.Add(new EnrolleeModel("abc123,Mike Jones,,AllState"));
            var expected1 = new EnrolleeModel("abc123", "Mike", "Jones", 0, "AllState");
            //Act
            var svc = new SeperateEnrolleeService();
            var results = svc.SeperateEnrollee(list);
            //Assert
            Assert.That(results["AllState"].Count(), Is.EqualTo(1));
            CompareEnrolleeAssert(results["AllState"].First(), expected1);
        }

        [Test]
        public void Text_Constructor_Test_Missing_Insurance_Test()
        {
            //Arrange
            List<EnrolleeModel> list = new List<EnrolleeModel>();
            list.Add(new EnrolleeModel("abc123,Mike Jones,2,"));
            var expected1 = new EnrolleeModel("abc123", "Mike", "Jones", 2, "");
            //Act
            var svc = new SeperateEnrolleeService();
            var results = svc.SeperateEnrollee(list);
            //Assert
            Assert.That(results[""].Count(), Is.EqualTo(1));
            CompareEnrolleeAssert(results[""].First(), expected1);
        }


        [Test]
        public void Grouping_By_Insurance_Companies_Test()
        {
            //Arrange
            List<EnrolleeModel> list = new List<EnrolleeModel>();
            list.Add(new EnrolleeModel("abc123", "Mike", "Jones", 2, "AllState"));
            list.Add(new EnrolleeModel("jedi433", "Obi-Wan", "Kenobi", 8, "The Force"));
            //Act
            var svc = new SeperateEnrolleeService();
            var results = svc.SeperateEnrollee(list);
            //Assert
            Assert.That(results.ContainsKey("AllState"), Is.EqualTo(true));
            Assert.That(results.ContainsKey("The Force"), Is.EqualTo(true));
        }

        [Test]
        public void Multiple_Clients_In_Different_Insurance_Companies_Test()
        {
            //Arrange
            List<EnrolleeModel> list = new List<EnrolleeModel>();
            list.Add(new EnrolleeModel("abc123", "Mike", "Jones", 2, "AllState"));
            list.Add(new EnrolleeModel("jedi433", "Obi-Wan", "Kenobi", 8, "The Force"));
            var expected1 = new EnrolleeModel("abc123", "Mike", "Jones", 2, "AllState");
            var expected2 = new EnrolleeModel("jedi433", "Obi-Wan", "Kenobi", 8, "The Force");
            //Act
            var svc = new SeperateEnrolleeService();
            var results = svc.SeperateEnrollee(list);
            //Assert
            Assert.That(results["AllState"].Count(), Is.EqualTo(1));
            Assert.That(results["The Force"].Count(), Is.EqualTo(1));
            CompareEnrolleeAssert(results["AllState"].First(), expected1);
            CompareEnrolleeAssert(results["The Force"].First(), expected2);
        }

        [Test]
        public void Multiple_Clients_In_Same_Insurance_Companies_Test()
        {
            //Arrange
            List<EnrolleeModel> list = new List<EnrolleeModel>();
            list.Add(new EnrolleeModel("abc123", "Mike", "Jones", 2, "The Force"));
            list.Add(new EnrolleeModel("jedi433", "Obi-Wan", "Kenobi", 8, "The Force"));
            var expected1 = new EnrolleeModel("abc123", "Mike", "Jones", 2, "The Force");
            var expected2 = new EnrolleeModel("jedi433", "Obi-Wan", "Kenobi", 8, "The Force");
            //Act
            var svc = new SeperateEnrolleeService();
            var results = svc.SeperateEnrollee(list);
            //Assert
            Assert.That(results["The Force"].Count(), Is.EqualTo(2));
            CompareEnrolleeAssert(results["The Force"][0], expected1);
            CompareEnrolleeAssert(results["The Force"][1], expected2);
        }

        [Test]
        public void Multiple_Clients_In_Same_Insurance_Companies_Missing_userId_Test()
        {
            //Arrange
            List<EnrolleeModel> list = new List<EnrolleeModel>();
            list.Add(new EnrolleeModel("", "Mike", "Jones", 2, "The Force"));
            list.Add(new EnrolleeModel(null, "Obi-Wan", "Kenobi", 8, "The Force"));
            var expected1 = new EnrolleeModel("", "Obi-Wan", "Kenobi", 8, "The Force");
            //Act
            var svc = new SeperateEnrolleeService();
            var results = svc.SeperateEnrollee(list);
            //Assert
            Assert.That(results["The Force"].Count(), Is.EqualTo(1));
            CompareEnrolleeAssert(results["The Force"][0], expected1);
        }

        [Test]
        public void Multiple_Clients_In_Same_Insurance_Companies_Missing_LastName_Test()
        {
            //Arrange
            List<EnrolleeModel> list = new List<EnrolleeModel>();
            list.Add(new EnrolleeModel("", "Mike", null, 2, "The Force"));
            list.Add(new EnrolleeModel("jedi433", "Obi-Wan", "", 8, "The Force"));
            var expected1 = new EnrolleeModel("", "Mike", "", 2, "The Force");
            var expected2 = new EnrolleeModel("jedi433", "Obi-Wan", "", 8, "The Force");
            //Act
            var svc = new SeperateEnrolleeService();
            var results = svc.SeperateEnrollee(list);
            //Assert
            Assert.That(results["The Force"].Count(), Is.EqualTo(2));
            CompareEnrolleeAssert(results["The Force"][0], expected1);
            CompareEnrolleeAssert(results["The Force"][1], expected2);
        }

        [Test]
        public void Multiple_Clients_In_Same_Insurance_Companies_Missing_FirstName_Test()
        {
            //Arrange
            List<EnrolleeModel> list = new List<EnrolleeModel>();
            list.Add(new EnrolleeModel("abc123", "", "Jones", 2, "The Force"));
            list.Add(new EnrolleeModel("jedi433", null, "Kenobi", 8, "The Force"));
            var expected1 = new EnrolleeModel("abc123", "", "Jones", 2, "The Force");
            var expected2 = new EnrolleeModel("jedi433", "", "Kenobi", 8, "The Force");
            //Act
            var svc = new SeperateEnrolleeService();
            var results = svc.SeperateEnrollee(list);
            //Assert
            Assert.That(results["The Force"].Count(), Is.EqualTo(2));
            CompareEnrolleeAssert(results["The Force"][0], expected1);
            CompareEnrolleeAssert(results["The Force"][1], expected2);
        }

        [Test]
        public void Multiple_Clients_In_Same_Insurance_Companies_Missing_InsuranceCompany_Test()
        {
            //Arrange
            List<EnrolleeModel> list = new List<EnrolleeModel>();
            list.Add(new EnrolleeModel("abc123", "Mike", "Jones", 2, ""));
            list.Add(new EnrolleeModel("jedi433", "Obi-Wan", "Kenobi", 8, null));
            var expected1 = new EnrolleeModel("abc123", "Mike", "Jones", 2, "");
            var expected2 = new EnrolleeModel("jedi433", "Obi-Wan", "Kenobi", 8, "");
            //Act
            var svc = new SeperateEnrolleeService();
            var results = svc.SeperateEnrollee(list);
            //Assert
            Assert.That(results[""].Count(), Is.EqualTo(2));
            CompareEnrolleeAssert(results[""][0], expected1);
            CompareEnrolleeAssert(results[""][1], expected2);
        }

        [Test]
        public void Multiple_Clients_In_Same_Insurance_Companies_With_The_Same_UserId_Test()
        {
            //Arrange
            List<EnrolleeModel> list = new List<EnrolleeModel>();
            list.Add(new EnrolleeModel("jedi433", "Mike", "Jones", 2, "The Force"));
            list.Add(new EnrolleeModel("jedi433", "Obi-Wan", "Kenobi", 8, "The Force"));
            var expected1 = new EnrolleeModel("jedi433", "Obi-Wan", "Kenobi", 8, "The Force");
            //Act
            var svc = new SeperateEnrolleeService();
            var results = svc.SeperateEnrollee(list);
            //Assert
            Assert.That(results["The Force"].Count(), Is.EqualTo(1));
            CompareEnrolleeAssert(results["The Force"][0], expected1);
        }

        [Test]
        public void Multiple_Clients_In_Same_Insurance_OrderedBy_Name_Test()
        {
            //Arrange
            List<EnrolleeModel> list = new List<EnrolleeModel>();
            list.Add(new EnrolleeModel("abc123", "Mike", "Jones", 2, "AllState"));
            list.Add(new EnrolleeModel("jedi433", "Obi-Wan", "Kenobi", 8, "AllState"));
            list.Add(new EnrolleeModel("fun543", "Robin", "Williams", 2, "AllState"));
            list.Add(new EnrolleeModel("fl1337", "Randy", "Williams", 3, "AllState"));
            list.Add(new EnrolleeModel("omg948", "Paris", "Hilton", 3, "AllState"));
            list.Add(new EnrolleeModel("hills90210", "Bev", "Hills", 2, "AllState"));
            var expected1 = new EnrolleeModel("hills90210", "Bev", "Hills", 2, "AllState");
            var expected2 = new EnrolleeModel("omg948", "Paris", "Hilton", 3, "AllState");
            var expected3 = new EnrolleeModel("abc123", "Mike", "Jones", 2, "AllState");
            var expected4 = new EnrolleeModel("jedi433", "Obi-Wan", "Kenobi", 8, "AllState");
            var expected5 = new EnrolleeModel("fl1337", "Randy", "Williams", 3, "AllState");
            var expected6 = new EnrolleeModel("fun543", "Robin", "Williams", 2, "AllState");
            //Act
            var svc = new SeperateEnrolleeService();
            var results = svc.SeperateEnrollee(list);
            //Assert
            Assert.That(results["AllState"].Count(), Is.EqualTo(6));
            CompareEnrolleeAssert(results["AllState"][0], expected1);
            CompareEnrolleeAssert(results["AllState"][1], expected2);
            CompareEnrolleeAssert(results["AllState"][2], expected3);
            CompareEnrolleeAssert(results["AllState"][3], expected4);
            CompareEnrolleeAssert(results["AllState"][4], expected5);
            CompareEnrolleeAssert(results["AllState"][5], expected6);
        }

        [Test]
        public void Multiple_Clients_In_Same_Insurance_With_The_Same_UserId_OrderedBy_Name_Test()
        {
            //Arrange
            List<EnrolleeModel> list = new List<EnrolleeModel>();
            list.Add(new EnrolleeModel("jedi433", "Mike", "Jones", 2, "AllState"));
            list.Add(new EnrolleeModel("jedi433", "Obi-Wan", "Kenobi", 8, "AllState"));
            list.Add(new EnrolleeModel("fl1337", "Robin", "Williams", 2, "AllState"));
            list.Add(new EnrolleeModel("fl1337", "Randy", "Williams", 3, "AllState"));
            list.Add(new EnrolleeModel("omg948", "Paris", "Hilton", 3, "AllState"));
            list.Add(new EnrolleeModel("hills90210", "Bev", "Hills", 2, "AllState"));
            var expected1 = new EnrolleeModel("hills90210", "Bev", "Hills", 2, "AllState");
            var expected2 = new EnrolleeModel("omg948", "Paris", "Hilton", 3, "AllState");
            var expected3 = new EnrolleeModel("jedi433", "Obi-Wan", "Kenobi", 8, "AllState");
            var expected4 = new EnrolleeModel("fl1337", "Randy", "Williams", 3, "AllState");
            //Act
            var svc = new SeperateEnrolleeService();
            var results = svc.SeperateEnrollee(list);
            //Assert
            Assert.That(results["AllState"].Count(), Is.EqualTo(4));
            CompareEnrolleeAssert(results["AllState"][0], expected1);
            CompareEnrolleeAssert(results["AllState"][1], expected2);
            CompareEnrolleeAssert(results["AllState"][2], expected3);
            CompareEnrolleeAssert(results["AllState"][3], expected4);
        }

        private void CompareEnrolleeAssert(EnrolleeModel result, EnrolleeModel expected)
        {
            Assert.That(result.UserId, Is.EqualTo(expected.UserId));
            Assert.That(result.InsuranceCompany, Is.EqualTo(expected.InsuranceCompany));
            Assert.That(result.FirstName, Is.EqualTo(expected.FirstName));
            Assert.That(result.LastName, Is.EqualTo(expected.LastName));
            Assert.That(result.Version, Is.EqualTo(expected.Version));
        }
    }
}