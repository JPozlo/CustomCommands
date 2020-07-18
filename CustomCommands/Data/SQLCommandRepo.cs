using CustomCommands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomCommands.Data
{
    public class SQLCommandRepo : ICommandRepo
    {
        private readonly CustomCommandsContext _context;

        public SQLCommandRepo(CustomCommandsContext context)
        {
            _context = context;
        }
        public Command GetCommand(int id)
        {
            return _context.Commands.FirstOrDefault(p => p.ID == id);
        }

        public IEnumerable<Command> GetCommands()
        {            
            return _context.Commands.ToList();
        }
    }
}
