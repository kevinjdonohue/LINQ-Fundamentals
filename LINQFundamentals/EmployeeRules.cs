using System.Collections.Generic;

namespace LINQFundamentals
{
    public class EmployeeRules
    {
        public List<Rule<Employee>> GetAllRules()
        {
            return new List<Rule<Employee>>()
            {
                new Rule<Employee>
                {
                    Test = e => !string.IsNullOrWhiteSpace(e.Name),
                    Message = "Employee name cannot be empty!"
                },
                new Rule<Employee>
                {
                    Test = e => e.DepartmentID >= 1,
                    Message = "Employee must have an assigned department!"
                },
                new Rule<Employee>
                {
                    Test = e => e.ID >= 1,
                    Message = "Employee must have an ID!"
                }
            };
        }
    }
}
