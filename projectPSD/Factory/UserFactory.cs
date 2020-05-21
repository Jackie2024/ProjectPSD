using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Factory
{
    public class UserFactory
    {
        public static Users createUser(int roleId, String name, String email, String password, String gender, String status)
        {
            return new Users()
            {
                RoleID = roleId,
                Name = name,
                Email = email,
                Password = password,
                Gender = gender,
                Status = status
            };
        }
    }
}