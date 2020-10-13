using CustomCommands.Helpers;
using CustomCommands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomCommands.Data
{
    public class SQLCommandRepo : ICommandRepo
    {
        private readonly DataContext _context;

        public SQLCommandRepo(DataContext context)
        {
            _context = context;
        }

        public void CreateCommand(Command command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            _context.Commands.Add(command);
        }

        public void DeleteCommand(Command command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            _context.Commands.Remove(command);
        }

        public void DeleteCommands(IEnumerable<Command> commands)
        {
            if (commands is null)
            {
                throw new ArgumentNullException(nameof(commands));
            }

            _context.Commands.RemoveRange(commands);
        }

        public Command GetCommand(int id)
        {
            return _context.Commands.FirstOrDefault(p => p.ID == id);
        }

        public IEnumerable<Command> GetCommands()
        {            
            return _context.Commands.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()) >= 0;
        }

        public void UpdateCommand(Command command)
        {
            // Implemented          
        }
    }
}
