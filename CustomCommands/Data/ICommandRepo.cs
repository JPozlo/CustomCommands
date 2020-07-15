using CustomCommands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomCommands.Data
{
    public interface ICommandRepo
    {
        IEnumerable<Command> GetCommands();

        Command GetCommand(int id);
    }
}
