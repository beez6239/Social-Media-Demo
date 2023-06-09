using System;
using System.Collections.Generic;
using System.Text;


namespace DataAccess
{
    public interface Iuserrepository
    {
        object GetUserbyid(int user);
        void CreateUser(object user);
        void UpdateUser(object user);
        void DeleteUser(int user);
        
    }
    class datalogic
    {
       
    }
}
