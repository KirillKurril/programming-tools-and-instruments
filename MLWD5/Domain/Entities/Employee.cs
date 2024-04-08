using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLWD5.Domain.Entities
{
    public class Employee : Entity
    {
        public string? Name { get; set; }
        public int? Age { get; private set; }
        public string? PhotoPath { get; private set; }
        public string? PersonalData { get; private set; }

        private List<Duty>? _duties;
        private Employee() { }
        public Employee(string name, int age, string photoPath, string personalData )
        {
            Name = name;
            Age = age;
            PhotoPath = photoPath;
            PersonalData = personalData;
        }

        public void AddDuty(Duty duty)+
            => _duties.Add(duty);

        public void RemoveDutyById(int id)
            => _duties.Remove(_duties.FirstOrDefault(duty => duty.Id == id));
        public IReadOnlyList<Duty>? Duties
        {
            get => _duties.AsReadOnly();
        }
    }
}

