using Moq;
using NUnit.Framework;
using System;
using WebShop_DataAccess.Context.Entities;
using WebShop_Services.Managers;
using WebShop_Services.Repositories;

namespace WebShop_Services.Tests.Managers
{
    internal class UserManagerTests
    {
        private Mock<IUserRepository> _mockUserRepository;
        private IUserManager _userManager;

        [SetUp]
        public void Setup()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _userManager = new UserManager(_mockUserRepository.Object);
        }

        [Test]
        public void AddUser_UserIsValid_ShouldSucceed()
        {
            // ARRANGE
            var user = new User
            {
                Username = "username",
                Password = "password"
            };

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            _mockUserRepository.Setup(mur => mur.AddUser(user)).Verifiable();

            //  ACT
            _userManager.AddUser(user);

            // ASSERT
            _mockUserRepository.Verify();
        }

        [Test]
        public void AddUser_UserIsNull_ShouldThrowUserIsNull()
        {
            // ARRANGE == mock up data to test the method
            var user = (User)null;

            //  ACT == action that the method performs
            var exception = Assert.Throws<Exception>(() => _userManager.AddUser(user));

            // ASSERT == the expected result
            Assert.That(exception.Message == "user is null");
        }

        [Test]
        public void GetUserFromDb_CorrectUsernameAndPassword_ShouldSuceed()
        {
            // ARRANGE == mock up data to test the method
            string username = "username";
            string password = "password";

            var user = new User
            {
                Username = username,
                Password = password
            };
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            _mockUserRepository.Setup(mur => mur.GetUserByUsername(username)).Returns(user).Verifiable();

            //  ACT == action that the method performs
            var actual = _userManager.GetUserFromDb(username, password);

            // ASSERT == the expected result
            _mockUserRepository.Verify();
            Assert.IsNotNull(actual);
            Assert.AreEqual(user.Username, actual.Username);
            Assert.AreEqual(user.Password, actual.Password);

        }

        [Test]
        public void GetUserFromDb_CorrectUsernameAndWrongPassword_ShouldReturnNull()
        {
            // ARRANGE == mock up data to test the method
            string username = "username";
            string password = "password";
            string incorrectPassword = "incorrect";

            var user = new User
            {
                Username = username,
                Password = password
            };
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            _mockUserRepository.Setup(mur => mur.GetUserByUsername(username)).Returns(user).Verifiable();

            //  ACT == action that the method performs
            var actual = _userManager.GetUserFromDb(username, incorrectPassword);

            // ASSERT == the expected result
            _mockUserRepository.Verify();
            Assert.IsNull(actual);

        }

        [Test]
        public void GetUserFromDb_WrongUsername_ShouldReturnNull()
        {
            // ARRANGE == mock up data to test the method
            string incorrectUsername = "incorrect";
            string password = "password";

            _mockUserRepository.Setup(mur => mur.GetUserByUsername(incorrectUsername)).Returns((User)null).Verifiable();

            //  ACT == action that the method performs
            var actual = _userManager.GetUserFromDb(incorrectUsername, password);

            // ASSERT == the expected result
            _mockUserRepository.Verify();
            Assert.IsNull(actual);

        }

        [Test]
        public void IsUsernameValid_ValidUsername_ShouldSuceed()
        {
            // ARRANGE == mock up data to test the method
            string username = "username";

            var user = new User
            {
                Username = username
            };

            _mockUserRepository.Setup(mur => mur.GetUserByUsername(username)).Returns((User)null).Verifiable();

            //  ACT == action that the method performs
            var actual = _userManager.IsUsernameValid(username);

            // ASSERT == the expected result
            _mockUserRepository.Verify();
            Assert.IsTrue(actual);

        }

        [Test]
        public void IsUsernameValid_InvalidUsername_ShouldReturnFalse()
        {
            // ARRANGE == mock up data to test the method
            string username = "username";

            var user = new User
            {
                Username = username
            };

            _mockUserRepository.Setup(mur => mur.GetUserByUsername(username)).Returns(user).Verifiable();

            //  ACT == action that the method performs
            var actual = _userManager.IsUsernameValid(username);

            // ASSERT == the expected result
            _mockUserRepository.Verify();
            Assert.IsFalse(actual);

        }

        [Test]
        public void IsUsernameValid_UsernameIsNull_ShouldThroughExceptionUsernameIsNull()
        {
            // ARRANGE == mock up data to test the method
            string username = null;

            //  ACT == action that the method performs
            var exception = Assert.Throws<Exception>(() => _userManager.IsUsernameValid(username));

            // ASSERT == the expected result
            _mockUserRepository.Verify();
            Assert.AreEqual(exception.Message, "username is null");

        }

        [Test]
        public void IsEmailValid_ValidEmail_ShouldSuceed()
        {
            // ARRANGE == mock up data to test the method
            string email = "test@email.com";

            var user = new User
            {
                Email = email
            };

            _mockUserRepository.Setup(mur => mur.GetUserByEmail(email)).Returns((User)null).Verifiable();

            //  ACT == action that the method performs
            var actual = _userManager.IsEmailValid(email);

            // ASSERT == the expected result
            _mockUserRepository.Verify();
            Assert.IsTrue(actual);

        }

        [Test]
        public void IsEmailValid_InvalidEmail_ShouldReturnFalse()
        {
            // ARRANGE == mock up data to test the method
            string email = "test@email.com";

            var user = new User
            {
                Email = email
            };

            _mockUserRepository.Setup(mur => mur.GetUserByEmail(email)).Returns(user).Verifiable();

            //  ACT == action that the method performs
            var actual = _userManager.IsEmailValid(email);

            // ASSERT == the expected result
            _mockUserRepository.Verify();
            Assert.IsFalse(actual);

        }

        [Test]
        public void IsEmailValid_EmailIsNull_ShouldThrowExceptionEmailIsNull()
        {
            // ARRANGE == mock up data to test the method
            string email = null;

            //  ACT == action that the method performs
            var exception = Assert.Throws<Exception>(() => _userManager.IsEmailValid(email));

            // ASSERT == the expected result
            _mockUserRepository.Verify();
            Assert.AreEqual(exception.Message, "email is null");
        }
    }
}
