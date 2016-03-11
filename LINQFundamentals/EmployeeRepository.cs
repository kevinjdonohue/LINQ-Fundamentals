using System;
using System.Collections.Generic;

namespace LINQFundamentals
{
    public class EmployeeRepository
    {
        public IEnumerable<Employee> GetAll()
        {
            return new List<Employee>
            {
                new Employee {ID =1, Name = "Scott", DepartmentID = 1},
                new Employee {ID =2, Name = "Poonam", DepartmentID = 1},
                new Employee {ID =3, Name = "Linda", DepartmentID = 1},
                new Employee {ID =4, Name = "Paul", DepartmentID = 1},
                new Employee {ID =5, Name = "Igor", DepartmentID = 2},
                new Employee {ID =6, Name = "Anna", DepartmentID = 2}
            };
        }

        public List<Employee> GetEmployeesWithDepartmentIDs()
        {
            return new List<Employee>()
            {
                new Employee
                {
                    ID = 1,
                    Name = "Scott",
                    DepartmentID = 1
                },
                new Employee
                {
                    ID = 2,
                    Name = "Poonam",
                    DepartmentID = 1
                },
                new Employee
                {
                    ID = 3,
                    Name = "Andy",
                    DepartmentID = 2
                }
            };
        }

        public List<Employee> GetEmployeesWithHireDates()
        {
            return new List<Employee>()
            {
                new Employee
                {
                    ID = 1,
                    Name = "Scott",
                    HireDate = new DateTime(2001, 3, 5)
                },
                new Employee
                {
                    ID = 2,
                    Name = "Poonam",
                    HireDate = new DateTime(2002, 10, 15)
                },
                new Employee
                {
                    ID = 3,
                    Name = "Paul",
                    HireDate = new DateTime(2007, 10, 11)
                }
            };
        }

        public Employee[] GetArrayOfEmployeesWithHireDates()
        {
            return GetEmployeesWithHireDates().ToArray();
        }
    }
}
