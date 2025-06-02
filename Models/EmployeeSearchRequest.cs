using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpSkills.Models
{
    public class EmployeeSearchRequest
    {
        public string Name { get; set; }
        public string ExpertLevel { get; set; }
        public List<int>? SkillIds { get; set; } = new List<int>();
    }
}