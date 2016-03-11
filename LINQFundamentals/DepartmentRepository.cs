using System.Collections.Generic;

namespace LINQFundamentals
{
    public class DepartmentRepository
    {
        public List<Department> GetDepartments()
        {
            return new List<Department>()
            {
                new Department()
                {
                    ID = 1,
                    Name = "Engineering"
                },
                new Department()
                {
                    ID = 2,
                    Name = "Sales"
                },
                new Department()
                {
                    ID = 3,
                    Name = "Skunkworks"
                }
            };
        }
    }
}
