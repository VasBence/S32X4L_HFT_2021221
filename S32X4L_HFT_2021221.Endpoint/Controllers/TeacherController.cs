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

        [HttpGet]
        public IEnumerable<Teacher> Get()
        {
            return tl.ReadAllTeacher();
        }

     
        [HttpGet("{id}")]
        public Teacher Get(int id)
        {
            return tl.ReadOneTeacher(id);
        }
    
        [HttpPost]
        public void Post([FromBody] Teacher value)
        {
            tl.CreateTeacher(value);
        }

    
        [HttpPut]
        public void Put([FromBody] Teacher teacher)
        {
            tl.UpdateTeacherProps(teacher);
        }
      
    
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            tl.DeleteTeacher(id);
        }

    }
}
