using AutoMapper;
using CustomCommands.DTOs;
using CustomCommands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomCommands.Profiles
{
    public class CommandsProfile: Profile
    {
        public CommandsProfile()
        {
            CreateMap<Command, CommandReadDTO>();
        }
    }
}
