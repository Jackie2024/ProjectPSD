using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Factory
{
    public class UserFactory
    {
        public static Users createUser(Dictionary<String, String> registerInputs)
        {
            return new Users()
            {
                RoleID = 2,
                Name = registerInputs["name"],
                Email = registerInputs["email"],
                Password = registerInputs["password"],
                Gender = registerInputs["gender"],
                Status = "Active"
            };
        }
    }
}