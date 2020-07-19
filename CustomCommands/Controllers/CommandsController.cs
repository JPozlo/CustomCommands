using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CustomCommands.Data;
using CustomCommands.DTOs;
using CustomCommands.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomCommands.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandRepo _repo;
        private readonly IMapper _mapper;

        public CommandsController(ICommandRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDTO>> GetAllCommands()
        {
            var commands = _repo.GetCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDTO>>(commands));
        }
        
        [HttpGet("{id}", Name = "GetCommand")]
        public ActionResult<CommandReadDTO> GetCommand(int id)
        {
            var command = _repo.GetCommand(id);
            if (command != null) return Ok(_mapper.Map<CommandReadDTO>(command));
            return NotFound();
        }

        [HttpPost]
        public ActionResult<CommandReadDTO> CreateCommand(CommandCreateDTO commandCreateDTO)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDTO);
            _repo.CreateCommand(commandModel);
            _repo.SaveChanges();

            var commandReadDTO = _mapper.Map<CommandReadDTO>(commandModel);

            return CreatedAtRoute(nameof(GetCommand), new { ID = commandReadDTO.ID, commandReadDTO });

            // return Ok(commandReadDTO);
        }
    }
}