using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using BussinessLogic;


namespace xTest
{
    class MockRepository : Iuserrepository
    {
        private List<User> _user; 

        public MockRepository()
        {
            _user = new List<User>()
            {
                //class constructor and will initialize list of users when instantiated 

                new User{ Id = 20, fullname = "Rob" },
                new User{ Id = 16, fullname = "Dav" },
            };

        }
        public void CreateUser(object user)
        {
            //method to create a new user

            _user.Add((User)user);
        }

        public void DeleteUser(int user)
        {
            throw new NotImplementedException();
        }

        public object GetUserbyid(int Userid)
        {
            return _user.FirstOrDefault(u => u.Id == Userid);
        }

      

        public void UpdateUser(object user)
        {
            //confirm the object expected type
           if(user is User confirm )
            {
                var userToUpdate = _user.FirstOrDefault(u => u.Id == confirm.Id);
                //check if user was found or not 
                if(userToUpdate != null)
                {
                    userToUpdate.fullname = confirm.fullname;
                }
            }
            else
                throw new ArgumentException("Invalid user object type");

        }
        public List<User> GetAllUser()
        {
            //method to return list of all users
            return _user;
        }
    }
}
