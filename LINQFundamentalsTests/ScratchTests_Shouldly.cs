using LINQFundamentals;
using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;
using System.Linq;

namespace LINQFundamentalsTests
{
    [TestFixture]
    public class ScratchTests_Shouldly
    {
        [Test]
        public void ShouldReturnAnOrderedListOfInstrutors()
        {
            //arrange
            Scratch scratch = new Scratch();
            string[] expectedInstructors = new string[] 
            {
                "Scott",
                "Keith",
                "Fritz",
                "Aaron"
            };

            //act
            //IEnumerable<string> rawInstructors = from instructor in scratch.Instructors
            //                                      where instructor.Length == 5
            //                                      orderby instructor descending
            //                                      select instructor;

            List<string> instructors = scratch.Instructors.Where(i => i.Length == 5).OrderByDescending(i => i).ToList();

            //assert        
            instructors.ShouldNotBeNull();
            instructors.Count.ShouldBe(4);
            instructors.ShouldBe(expectedInstructors);            
        }
            
    }
}
