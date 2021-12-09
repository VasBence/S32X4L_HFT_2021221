using Microsoft.AspNetCore.Mvc;
using S32X4L_HFT_2021221.Logic;
using S32X4L_HFT_2021221.Models;
using System.Collections.Generic;

namespace S32X4L_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CoursesController
    {
        ICoursesLogic cl;
        public CoursesController(ICoursesLogic cl)
        {
            this.cl = cl;
        }

        [HttpGet]
        public IEnumerable<Courses> Get()
        {
            return cl.GetAllCourses();
        }


        [HttpGet("{id}")]
        public Courses Get(int id)
        {
            return cl.ReadOneCourse(id);
        }

        [HttpPost]
        public void Post([FromBody] Courses value)
        {
            cl.CreateCourse(value);
        }


        [HttpPut]
        public void Put([FromBody] Courses courses)
        {
            cl.UdpateCourseName(courses);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cl.DeleteCourse(id);
        }

    }
}
