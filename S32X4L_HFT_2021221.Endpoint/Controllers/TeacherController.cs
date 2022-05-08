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
    public class TeacherController : ControllerBase
    {
        ITeacherLogic tl;
        IHubContext<SignalRHub> hub;

        public TeacherController(ITeacherLogic tl,IHubContext<SignalRHub> hub)
        {
            this.tl = tl;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("TeacherCreated", value);
        }


        [HttpPut]
        public void Put([FromBody] Teacher teacher)
        {
            tl.UpdateTeacherProps(teacher);
            this.hub.Clients.All.SendAsync("TeacherUpdated", teacher);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var teachertodelete = this.tl.ReadOneTeacher(id);
            tl.DeleteTeacher(id);
            this.hub.Clients.All.SendAsync("TeacherDeleted", teachertodelete);

        }

    }
}
