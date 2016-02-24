using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace LINQFundamentalsTests
{
    [TestFixture]
    public class LINQToObjectTests
    {
        [Test]
        public void ShouldReturnListOfProcessesNamedSVCHost()
        {
            //act
            List<Process> processList = Process.GetProcesses()
                .Where(p => p.ProcessName == "svchost")
                .OrderByDescending(p => p.WorkingSet64).ToList();

            //assert
            processList.Count.Should().BeGreaterThan(10);
        }

        [Test]
        public void ShouldReturnListOfPublicTypes()
        {
            //act
            List<Type> types = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.IsPublic).ToList();

            //assert
            types.Count.Should().BeGreaterOrEqualTo(5, "there are at least 4 public types.");
            types.Should().Contain(t => t.Name == "LINQToObjectTests");
        }
    }
}
