﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InteractiveCoursesBackend.DTO
{
    public class UserDTO
    {
        public string Password { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}