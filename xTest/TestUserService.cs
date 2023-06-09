using System;
using Xunit;
using BussinessLogic;

namespace xTest
{
    public class TestUserService
    {
        [Fact]
        public void GetUserIDTest()
        {
            var userRepo = new MockRepository();
            var userService = new UserService(userRepo);

            var result = userService.GetUserId(20);
           Assert.NotNull(result);
        }

        [Fact]
        public void UpdateUserTest()
        {
            //arrange
            var userRepo = new MockRepository();
            var service = new UserService(userRepo);

            var update = new User { Id = 2, fullname = "Digle Mike" };
            userRepo.UpdateUser(update);
            var updatedUser = new User { Id = 2, fullname = "Diggle Mike" };

            //act 
            service.updateUser(updatedUser);
            var updatedUserFromRepository = userRepo.GetUserbyid(2);

            //assert
            Assert.Equal("Diggle Mike", updatedUser.fullname);
        }

        [Fact]
        public void CreateUserTest()
        {
            //arrange
            var userRepository = new MockRepository();
            var userService = new UserService(userRepository);
            var newUser = new User { Id = 1, fullname = "Aiden" };
            //act 
            userService.CreateUser(newUser);
            //assert 
            Assert.Equal("Aiden", newUser.fullname);
        }

        //Post test 
        [Fact]
        public void Post_Test()
        {
            // Arrange
            var id = 1;
            var title = "Demo";
            var content = "This is a demo post";
            var createdAt = DateTime.Now;
            var author = new User { Id = 1, fullname = "Joe" };

            // Act
            var post = new Post
            {
                Id = id,
                Title = title,
                Content = content,
                CreatedAt = createdAt,
                Author = author
            };
            //Assert
            Assert.Equal(id, post.Id);
           
        }

        [Fact]
        public void Email_SentDate_Test()
        {
            var from = "sender@demo.com";
            var to = "recipient@demo.com";
            var subject = "Test Email";
            var body = "This is a test email";

            // Act
            var email = new Email { From = from, To = to, Subject = subject, Body = body };

            // Assert
            Assert.Equal(default(DateTime), email.SentAt);
        }

        [Fact]
        public void Friendship_Details_Test()
        {
            
                // Arrange
                var user1Id = 1;
                var user2Id = 2;

                // Act
                var friendship = new Friendship { User1Id = user1Id, User2Id = user2Id };

                // Assert
                Assert.Equal(user1Id, friendship.User1Id);
                Assert.Equal(user2Id, friendship.User2Id);
            
        }

        [Fact]
        public void Friendship_CreatetAt()
        {
            var user1Id = 1;
            var user2Id = 2;

            // Act
            var friendship = new Friendship { User1Id = user1Id, User2Id = user2Id };

            // Assert
            Assert.Equal(default(DateTime), friendship.CreatedAt);
        }

       

    }

    public class Test_Notification_component
    {
        [Fact]
        public void Notification_Details_Test()
        {
            var message = "New message";
            var recipient = new User { Id = 7, fullname = "Sam" };

            // Act
            var notification = new Notification { Message = message, Recipient = recipient };

            // Assert
            Assert.Equal(message, notification.Message);
            Assert.Equal(recipient, notification.Recipient);
        }

        [Fact]
        public void Notification_SentDate_Test()
        {
            var message = "message alert";
            var recipient = new User { Id = 1, fullname = "Harry" };

            // Act
            var notification = new Notification { Message = message, Recipient = recipient };

            // Assert
            Assert.Equal(default(DateTime), notification.CreatedAt);
        }


    }

    public class Test_Email_component
    {
        [Fact]
        public void Email_Details_Test()
        {

            // arrange
            var from = "sender@demo.com";
            var to = "recipient@demo.com";
            var subject = "Test Email";
            var body = "This is a test email";

            // act
            var email = new Email { From = from, To = to, Subject = subject, Body = body };

            // assert
            Assert.Equal(from, email.From);
            Assert.Equal(to, email.To);
        }

        [Fact]
        public void Email_SentDate_Test()
        {
            var from = "sender@demo.com";
            var to = "recipient@demo.com";
            var subject = "Test Email";
            var body = "This is a test email";

            // Act
            var email = new Email { From = from, To = to, Subject = subject, Body = body };

            // Assert
            Assert.Equal(default(DateTime), email.SentAt);
        }


    }
    public class Test_Api_component
    {
        [Fact]
        public void Test_Api()
        {
            var userRepository = new MockRepository();
            var userService = new UserService(userRepository);
            var user = new User { Id = 2, fullname = "Sam" };
            var userController = new UserController(userService);

            // Act
            userController.GetUser(2);

            // Assert
            Assert.False(userController.GetUser(2));
        }
    }

}
