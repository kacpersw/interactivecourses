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
    public class CourseController : ApiController
    {
        private readonly ICContext dbContext;

        public CourseController()
        {
            this.dbContext = new ICContext();
        }

        [HttpGet, Route("api/course/{id}")]
        public CourseDTO GetCourse(int id)
        {
            var course = dbContext
                .Courses
                .Where(c => c.Id == id)
                .Select(c => new CourseDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .FirstOrDefault();

            var stages = dbContext
                .Stages
                .Where(s => s.CourseId == id)
                .Select(s => new CourseStageDTO
                {
                    Id = s.Id,
                    Name = s.Name,
                    Stage = s.Nr
                })
                .ToList();

            course.Stages = stages;

            return course;
        }

        [HttpGet, Route("api/stage/{id}")]
        public StageDTO GetStage(int id)
        {
            return dbContext
                .Stages
                .Where(s => s.Id == id)//Where(s => s.CourseId == id)
                .Select(s => new StageDTO
                {
                    Id = s.Id,
                    HtmlContent = s.HtmlContent,
                    Name = s.Name
                })
                .FirstOrDefault();
        }

        [HttpGet, Route("api/progress/{id}")]
        public IEnumerable<ProgressDTO> GetProgressByUser(int id)
        {
            var categoriesFromDb = dbContext
                .Categories
                .ToList();

            var progresses = new List<ProgressDTO>();
            var progressesFromDb = dbContext
                .Progresses
                .ToList();

            foreach (var categoryFromDb in categoriesFromDb)
            {
                var coursesProgresses = new List<CourseProgressDTO>();
                var progress = new ProgressDTO
                {
                    CategoryName = categoryFromDb.Name
                };

                foreach (var course in categoryFromDb.Courses.Where(c=>c.Users.Any(uc=>uc.Id == id)))
                {
                    var lastCompletedStage = progressesFromDb
                        .Where(p => p.CourseId == course.Id && p.CategoryId == categoryFromDb.Id && p.UserId == id)
                        .Select(cs=>cs.StageId)
                        .FirstOrDefault();

                    var courseProgress = new CourseProgressDTO
                    {
                        CourseName = course.Name,
                        StageNames = course.Stages.Select(s => s.Name).ToList(),
                        LastCompletedStage = course.Stages.Where(s=>s.Id == lastCompletedStage).Select(s=>s.Nr).FirstOrDefault()
                    };

                    coursesProgresses.Add(courseProgress);
                }
                progress.Progresses = coursesProgresses;

                progresses.Add(progress);
            }

            return progresses;
        }

        [HttpPost, Route("api/course/add")]
        public HttpResponseMessage AddCategory(AddCourseDTO course)
        {
            var newCourse = new Course()
            {
                Name = course.Name,
                Path = course.Path
            };

            dbContext.Courses.Add(newCourse);
            dbContext.SaveChanges();

            foreach (var id in course.CategoriesIds)
            {
                var category = dbContext.Categories.Where(c => c.Id == id).FirstOrDefault();

                if (category != null)
                    newCourse.Categories.Add(category);
            }

            dbContext.SaveChanges();

            foreach (var stage in course.Stages)
            {
                newCourse.Stages.Add(new Stage
                {
                    CourseId = newCourse.Id,
                    Name = stage.Name,
                    HtmlContent = stage.HtmlContent,
                    Nr = stage.Nr
                });
            }

            dbContext.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
