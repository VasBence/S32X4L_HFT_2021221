using S32X4L_HFT_2021221.Logic;
using S32X4L_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace S32X4L_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeacherController
    {
        ITeacherLogic tl;
        public TeacherController(ITeacherLogic tl)
        {
            this.tl = tl;
        }
        //GETALL
        [HttpGet]
        public IEnumerable<Teacher> Get()
        {
            return tl.ReadAllTeacher();
        }

        //GETCOURSE
        [HttpGet("{id}")]
        public Teacher Get(int id)
        {
            return tl.ReadOneTeacher(id);
        }
        //POSTCOURSE
        [HttpPost]
        public void Post([FromBody] Teacher value)
        {
            tl.CreateTeacher(value);
        }

        //PUTCOURSE
        [HttpPut]
        public void Put([FromBody] int id, string name)
        {
            tl.UpdateTeacherName(id, name);
        }
        public void Put2([FromBody] int id, int credit)
        {
            tl.UpdateTeacherAge(id, credit);
        }
        //DELETECAR
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            tl.DeleteTeacher(id);
        }

    }
}
