using S32X4L_HFT_2021221.Logic;
using S32X4L_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace S32X4L_HFT_2021221.Endpoint.Controllers
{ 
    [Route("[controller]")]
    [ApiController]
    public class StudentsController
    {
        IStudentsLogic sl;
        public StudentsController(IStudentsLogic sl)
        {
            this.sl = sl;
        }
        //GETALL
        [HttpGet]
        public IEnumerable<Students> Get()
        {
            return sl.ReadAllStudents();
        }

        //GETCOURSE
        [HttpGet("{id}")]
        public Students Get(string id)
        {
            return sl.ReadOneStudent(id);
        }
        //POSTCOURSE
        [HttpPost]
        public void Post([FromBody] Students value)
        {
            sl.CreateStudent(value);
        }

        //PUTCOURSE
        [HttpPut]
        public void Put([FromBody] string id, string name)
        {
            sl.UpdateStudentName(id, name);
        }

        public void Put2([FromBody] string id, int age)
        {
            sl.UpdateStudentAge(id, age);
        }
        //DELETECAR
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            sl.DeleteStudent(id);
        }

    }

}
