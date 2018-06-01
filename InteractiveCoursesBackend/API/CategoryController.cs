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
    public class CategoryController : ApiController
    {
        private readonly ICContext dbContext;

        public CategoryController()
        {
            this.dbContext = new ICContext();
        }

        [HttpGet, Route("api/categories")]
        public IEnumerable<ShowCategoryDTO> GetCategories() => dbContext.Categories
                .Select(c => new ShowCategoryDTO
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();

        [HttpPost, Route("api/categories/add")]
        public HttpResponseMessage AddCategory(AddCategoryDTO category)
        {
            dbContext.Categories.Add(new Category
            {
                ImageUrl = category.ImageUrl,
                Name = category.Name
            });

            dbContext.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
