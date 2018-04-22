using InteractiveCoursesBackend.DTO;
using InteractiveCoursesBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InteractiveCoursesBackend.API
{
    public class UserController : ApiController
    {
        private readonly ICContext dbContext;

        public UserController()
        {
            this.dbContext = new ICContext();
        }

        [HttpGet, Route("api/user/{id}")]
        public UserProfileDTO GetUserById(int id)
        {
            return dbContext
                .Users
                .Where(u => u.Id == id)
                .Select(u => new UserProfileDTO
                {
                    Id = u.Id,
                    Email = u.Email,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Username = u.Username
                })
                .FirstOrDefault();
        }
    }
}
