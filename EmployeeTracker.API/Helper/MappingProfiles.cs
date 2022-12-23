using AutoMapper;
using EmployeeTracker.API.DTO;
using EmployeeTracker.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTracker.API.Helper
{
    public class MappingProfiles :Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<Machine, MachineDTO>();
        }
    }
}
