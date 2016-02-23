using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;

namespace LINQFundamentalsTests
{
    [TestFixture]
    public class LINQToXMLTests
    {
        [Test]
        public void ShouldGenerateXMLViaFunctionalConstrution()
        {
            //arrange
            const string instructor = "instructor";

            //act
            //functional construction - pass everything needed in via the constructor of the XElement
            XElement instructors = new XElement("instructors",
                new XElement(instructor, "Aaron"),
                new XElement(instructor, "Fritz"),
                new XElement(instructor, "Keith"),
                new XElement(instructor, "Scott"));

            int numberOfScotts = instructors.Elements("instructor").Where(i => i.Value == "Scott").Count();

            //assert
            instructors.Should().NotBeNull();
            instructors.Should().BeOfType(typeof(XElement));
            instructors.FirstNode.Should().BeOfType(typeof(XElement));
            (instructors.FirstNode as XElement).Value.Should().Be("Aaron");

            numberOfScotts.Should().Be(1);
        }

        [Test]
        public void ShouldReturnXMLOfAllProcesses()
        {
            //act
            XDocument processDoc = new XDocument(
                new XElement("Processes",
                    Process.GetProcesses()
                    .Select(p => new XElement("Process", new XAttribute("Name", p.ProcessName), new XAttribute("PID", p.Id))))
                );

            IEnumerable<string> pids = processDoc.Descendants("Process")
                .Where(e => e.Attribute("Name").Value == "svchost")
                .Select(e => e.Attribute("PID").Value);

            //assert
            processDoc.Should().NotBeNull();
            pids.Should().NotBeNullOrEmpty();
            pids.Count().Should().BeGreaterThan(10);
        }
    }
}
