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
    public class StudentsController : ControllerBase
    {
        IStudentsLogic sl;
        IHubContext<SignalRHub> hub;
        public StudentsController(IStudentsLogic sl, IHubContext<SignalRHub> hub)
        {
            this.sl = sl;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("StudentCreated", value);
        }


        [HttpPut]
        public void Put([FromBody] Students students)
        {
            sl.UpdateStudentProps(students);
            this.hub.Clients.All.SendAsync("StudentUpdated", students);
        }


        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var studenttodelete = this.sl.ReadOneStudent(id);
            sl.DeleteStudent(id);
            this.hub.Clients.All.SendAsync("StudentDeleted", studenttodelete);
        }

    }

}
