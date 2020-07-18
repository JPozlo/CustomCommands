using CustomCommands.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomCommands.Data
{
    public class CustomCommandsContext: DbContext
    {
        public CustomCommandsContext(DbContextOptions<CustomCommandsContext> options): base(options)
        {

        }

        public DbSet<Command> Commands { get; set; }
    }

}
