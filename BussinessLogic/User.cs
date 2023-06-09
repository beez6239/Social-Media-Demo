using System;
using System.Collections.Generic;
using DataAccess;



namespace BussinessLogic
{
    //User class 
   public class User
    { 
        public int Id { get; set; }
        public string fullname { get; set; }
        private string username { get; set; }
        private string email { get; set; }
        private string phone_number { get; set; }
        private DateTime date_of_birth { get; set; }
       
    }

    //Post class 
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public User Author { get; set; }
    }

    //Notification class 
    public class Notification
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public User Recipient { get; set; }
    }
    //Email class
    public class Email
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime SentAt { get; set; }
    }

    //Friendship class
    public class Friendship
    {
        public int User1Id { get; set; }
        public int User2Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    //User manipulation class 
    public class UserService
    {

        //User repository Interface
        private readonly Iuserrepository _userrepository;

        public UserService(Iuserrepository iuserrepository)
        {
            // class constructor 
            this._userrepository = iuserrepository;
        }
        
        public void CreateUser(User user)
        {
            //method to create a new user
            _userrepository.CreateUser(user);
        }

        public object GetUserId(int Userid)
        {
            //method to search for a user using a unique id 
          return  _userrepository.GetUserbyid(Userid);
        }

        public void updateUser(User user)
        {
            //method to update existing user
            _userrepository.UpdateUser(user);
        }
       
        public void DeleteUser(int UserId)
        {
            //method to delete a user with unique id
            _userrepository.DeleteUser(UserId);
        }

    }


    //Api controller class
    public class UserController
    {
        private readonly UserService _userservice;
        public UserController(UserService userService)
        {
            //class constructor
            _userservice = userService;
        }

        public void CreateUser(User user)
        {
            _userservice.CreateUser(user);
        }

        public bool GetUser(int id)
        {
            //Method to get the user by unique id through Api controller
            bool con = false; 
            User user = (User)_userservice.GetUserId(id);
            if (user != null)
                con = true;
            return con;

             
        }
    }

}
