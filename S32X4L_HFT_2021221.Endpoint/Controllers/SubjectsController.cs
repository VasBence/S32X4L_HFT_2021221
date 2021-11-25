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
        //GETALL
        [HttpGet]
        public IEnumerable<Subjects> Get()
        {
            return sl.ReadAllSubjects();
        }

        //GETCOURSE
        [HttpGet("{id}")]
        public Subjects Get(int id)
        {
            return sl.ReadOneSubject(id);
        }
        //POSTCOURSE
        [HttpPost]
        public void Post([FromBody] Subjects value)
        {
            sl.CreateSubject(value);
        }

        //PUTCOURSE
        [HttpPut]
        public void Put([FromBody] int id, string name)
        {
            sl.UpdateSubjectName(id, name);
        }
        public void Put2([FromBody] int id, int credit)
        {
            sl.UpdateCredit(id, credit);
        }
        //DELETECAR
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            sl.DeleteSubject(id);
        }

    }
}

