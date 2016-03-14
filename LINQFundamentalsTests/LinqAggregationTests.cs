using FluentAssertions;
using LINQFundamentals;
using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace LINQFundamentalsTests
{
    [TestFixture]
    public class LinqAggregationTests
    {
        [Test]
        public void ShouldReturnSummaryProcessInformationUsingSumMinMaxAndAverage()
        {
            //arrange

            //act
            Process[] runningProcesses = Process.GetProcesses();
            var summaryOfProcesses = new
            {
                ProcessCount = runningProcesses.Count(),
                TotalThreads = runningProcesses.Sum(p => p.Threads.Count),
                MinThreads = runningProcesses.Min(p => p.Threads.Count),
                MaxTheads = runningProcesses.Max(p => p.Threads.Count),
                AverageThreads = runningProcesses.Average(p => p.Threads.Count)
            };

            //assert
            summaryOfProcesses.Should().NotBeNull();
        }

        [Test]
        public void ShouldExecuteAllEmployeeRulesAgainstAllEmployees()
        {
            //arrange
            List<Employee> employees = new EmployeeRepository().GetEmployeesWithDepartmentIDs();
            employees[2].DepartmentID = 0;  //change to a nonsense dept id so that one of the rules breaks
            List<Rule<Employee>> employeeRules = new EmployeeRules().GetAllRules();
            Employee lastEmployee = employees[2];

            //act
            bool allEmployeesAreValid = employees.All(e => employeeRules.All(r => r.Test(e)));
            IEnumerable<Rule<Employee>> failedEmployeeRules = employeeRules.Where(r => r.Test(lastEmployee) == false);
            string errorMessages = failedEmployeeRules.Aggregate(new StringBuilder(),
                                                                (sb, r) => sb.AppendLine(r.Message),
                                                                sb => sb.ToString());

            //assert
            allEmployeesAreValid.Should().BeFalse();
            errorMessages.Should().NotBeNullOrWhiteSpace();
            errorMessages.Should().Contain("Employee must have an assigned department");
        }
    }
}
