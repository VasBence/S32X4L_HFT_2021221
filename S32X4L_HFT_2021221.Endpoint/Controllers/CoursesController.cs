using S32X4L_HFT_2021221.Logic;
using S32X4L_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
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
        //GETALL
        [HttpGet]
        public IEnumerable<Courses>Get()
        {
            return cl.GetAllCourses();
        }

        //GETCOURSE
        [HttpGet("{id}")]
        public Courses Get(int id)
        {
            return cl.ReadOneCourse(id);
        }
        //POSTCOURSE
        [HttpPost]
        public void Post([FromBody] Courses value)
        {       
            cl.CreateCourse(value);
        }

        //PUTCOURSE
        [HttpPut]
        public void Put([FromBody] int id, string name)
        {
            cl.UdpateCourseName(id, name);
        }
        //DELETECAR
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cl.DeleteCourse(id);
        }

    }
}
