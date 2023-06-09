using System;
using System.Collections.Generic;
using DataAccess;


namespace BussinessLogic
{
   public class User
    {
        
        public int Id { get; set; }
        public string fullname { get; set; }
        private string username { get; set; }
        private string email { get; set; }
        private string phone_number { get; set; }
        private DateTime date_of_birth { get; set; }
       
    }

    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public User Author { get; set; }
    }


    public class Notification
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public User Recipient { get; set; }
    }

    public class Email
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime SentAt { get; set; }
    }


    public class Friendship
    {
        public int User1Id { get; set; }
        public int User2Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
    public class UserService
    {
        private readonly Iuserrepository _userrepository;

        public UserService(Iuserrepository iuserrepository)
        {
            this._userrepository = iuserrepository;
        }
        
        public void CreateUser(User user)
        {
            //create a new user
            _userrepository.CreateUser(user);
        }

        public object GetUserId(int Userid)
        {
            //Search for a using a unique id 
          return  _userrepository.GetUserbyid(Userid);
        }

        public void updateUser(User user)
        {
            //update existing user
            _userrepository.UpdateUser(user);
        }
       
        public void DeleteUser(int UserId)
        {
            //delete a user with unique id
            _userrepository.DeleteUser(UserId);
        }
        
    }
  
}
