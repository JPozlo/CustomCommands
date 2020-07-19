using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CustomCommands.Data;
using CustomCommands.DTOs;
using CustomCommands.Models;
using Microsoft.AspNetCore.JsonPatch;
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

            return CreatedAtRoute(nameof(GetCommand), new { commandReadDTO.ID }, commandReadDTO);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDTO commandUpdateDTO)
        {
            var commandModelFromRepo = _repo.GetCommand(id);
            if (commandModelFromRepo == null) return NotFound();

            _mapper.Map(commandUpdateDTO, commandModelFromRepo);

            _repo.UpdateCommand(commandModelFromRepo);
            _repo.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDTO> patchDocument)
        {
            var commandModelFromRepo = _repo.GetCommand(id);
            if (commandModelFromRepo == null) return NotFound();

            var commandToPatch = _mapper.Map<CommandUpdateDTO>(commandModelFromRepo);
            patchDocument.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch)) return ValidationProblem(ModelState);

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repo.UpdateCommand(commandModelFromRepo);
            _repo.SaveChanges();

            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = _repo.GetCommand(id);
            if (commandModelFromRepo == null) return NotFound();

            _repo.DeleteCommand(commandModelFromRepo);
            _repo.SaveChanges();

            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeleteCommands()
        {
            var commandsFromRepo = _repo.GetCommands();
            if (commandsFromRepo == null) return NotFound();

            _repo.DeleteCommands(commandsFromRepo);
            _repo.SaveChanges();

            return NoContent();
        }
    }
}