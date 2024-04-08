using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLWD5.Domain.Entities
{
    public class Duty : Entity
    {
        public string? Name { get; private set; }
        public int? Importance { get; private set; }
        public int? Сomplexity { get; private set; }
        public string? Description { get; private set; }
        public Employee? Employee { get; private set; }
        public int? EmployeeId { get; private set; }
        private Duty() { }
        public Duty(string name, int importance, int complexity, string description, int employeeId)
        {
            Name = name;
            Importance = importance;
            Сomplexity = complexity;
            Description = description;
            EmployeeId = employeeId;
        }

        public void AssignEmployee(int employeeId)
        {
            if (employeeId <= 0) return;
            EmployeeId = employeeId;
        }

        public void Relieve()
            => EmployeeId = 0;

        public void SetImpotance(int importance)
        {
            if (importance < 0 || importance > 10) return;
            Importance = importance;
        }
    }
}
