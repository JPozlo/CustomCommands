﻿using CustomCommands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomCommands.Data
{
    public class MockCommandRepo : ICommandRepo
    {
        public void CreateCommand(Command command)
        {
            throw new NotImplementedException();
        }

        public void DeleteCommand(Command command)
        {
            throw new NotImplementedException();
        }

        public void DeleteCommands()
        {
            throw new NotImplementedException();
        }

        public void DeleteCommands(IEnumerable<Command> commands)
        {
            throw new NotImplementedException();
        }

        public Command GetCommand(int id)
        {
            return new Command { ID = 0, HowTo = "Demo", Line = "Demo LIne", Platform = "THis Machine" };
        }

        public IEnumerable<Command> GetCommands()
        {
            var commands = new List<Command>
            {
                new Command { ID = 0, HowTo = "Demo", Line = "Demo LIne", Platform = "THis Machine" },
                new Command { ID = 1, HowTo = "Egg", Line = "Boil Egg", Platform = "Pan" },
                new Command { ID = 2, HowTo = "Rice", Line = "Boil Rice", Platform = "Large Pot" }
            };
            return commands;
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateCommand(Command command)
        {
            throw new NotImplementedException();
        }
    }
}
