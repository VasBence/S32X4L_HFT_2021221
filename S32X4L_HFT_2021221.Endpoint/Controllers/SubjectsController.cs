using S32X4L_HFT_2021221.Logic;
using S32X4L_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace S32X4L_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SubjectsController
    {
        ISubjectsLogic sl;
        public SubjectsController(ISubjectsLogic sl)
        {
            this.sl = sl;
        }
    
        [HttpGet]
        public IEnumerable<Subjects> Get()
        {
            return sl.ReadAllSubjects();
        }

     
        [HttpGet("{id}")]
        public Subjects Get(int id)
        {
            return sl.ReadOneSubject(id);
        }
       
        [HttpPost]
        public void Post([FromBody] Subjects value)
        {
            sl.CreateSubject(value);
        }

     
        [HttpPut]
        public void Put([FromBody] Subjects subjects)
        {
            sl.UpdateSubjectProps(subjects);
        }
      
       
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            sl.DeleteSubject(id);
        }

    }
}

