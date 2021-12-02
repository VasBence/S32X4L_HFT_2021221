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
       
        [HttpGet]
        public IEnumerable<Students> Get()
        {
            return sl.ReadAllStudents();
        }

      
        [HttpGet("{id}")]
        public Students Get(string id)
        {
            return sl.ReadOneStudent(id);
        }
      
        [HttpPost]
        public void Post([FromBody] Students value)
        {
            sl.CreateStudent(value);
        }

     
        [HttpPut]
        public void Put([FromBody] Students students)
        {
            sl.UpdateStudentProps(students);
        }

       
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            sl.DeleteStudent(id);
        }

    }

}
