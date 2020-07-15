using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomCommands.Data;
using CustomCommands.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomCommands.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly MockCommandRepo _repo = new MockCommandRepo();
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commands = _repo.GetCommands();
            return Ok(commands);
        }
        
        [HttpGet("{id}")]
        public ActionResult <Command> GetCommand(int id)
        {
            var command = _repo.GetCommand(id);
            return Ok(command);
        }
    }
}