using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using S32X4L_HFT_2021221.Endpoint.Services;
using S32X4L_HFT_2021221.Logic;
using S32X4L_HFT_2021221.Models;
using System.Collections.Generic;

namespace S32X4L_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        ISubjectsLogic sl;
        IHubContext<SignalRHub> hub;
        public SubjectsController(ISubjectsLogic sl, IHubContext<SignalRHub> hub)
        {
            this.sl = sl;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("SubjectCreated", value);
        }


        [HttpPut]
        public void Put([FromBody] Subjects subjects)
        {
            sl.UpdateSubjectProps(subjects);
            this.hub.Clients.All.SendAsync("SubjectUpdated", subjects);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var subjecttodelete = this.sl.ReadOneSubject(id);
            sl.DeleteSubject(id);
            this.hub.Clients.All.SendAsync("SubjectDeleted", subjecttodelete);
        }

    }
}

