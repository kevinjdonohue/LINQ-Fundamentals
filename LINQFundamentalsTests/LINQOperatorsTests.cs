using FluentAssertions;
using LINQFundamentals;
using NUnit.Framework;
using System.Collections;
using System.Linq;

namespace LINQFundamentalsTests
{
    [TestFixture]
    public class LINQOperatorsTests
    {
        [Test]
        public void DemonstratesFiltering_OfType_OnAnIEnumerable()
        {
            //arrange
            ArrayList list = new ArrayList();
            list.Add("Dash");
            list.Add(new Employee
            {
                ID = 1,
                Name = "Kevin",
                DepartmentID = 1,
                HireDate = new System.DateTime(1973, 9, 19)
            });
            list.Add("Skitty");
            list.Add(new Employee
            {
                ID = 2,
                Name = "Kim",
                DepartmentID = 2,
                HireDate = new System.DateTime(1970, 10, 8)
            });

            //act
            var stringQuery = list.OfType<string>();

            //assert
            stringQuery.Should().NotBeNullOrEmpty();
            stringQuery.Should().HaveCount(2);
        }

        [Test]
        public void DemonstratesSetOperators()
        {
            //arrange
            int[] startYearsTeam1 = { 2000, 2002, 2004, 2006 };
            int[] startYearsTeam2 = { 2000, 2001, 2003, 2005, 2007 };
            int[] startYearsWithDuplicates = { 2000, 2000, 2000, 2001, 2002 };

            //act
            var intersectionYears = startYearsTeam1.Intersect(startYearsTeam2);
            var exceptYears = startYearsTeam1.Except(startYearsTeam2);
            var unionYears = startYearsTeam1.Union(startYearsTeam2);
            var distinctYears = startYearsWithDuplicates.Distinct();

            //assert
            intersectionYears.Should().HaveCount(1);
            intersectionYears.Should().Contain(2000);

            exceptYears.Should().HaveCount(3);
            exceptYears.Should().ContainInOrder(new int[] { 2002, 2004, 2006 });

            unionYears.Should().HaveCount(8);
            unionYears.Should().ContainInOrder(new int[] { 2000, 2002, 2004, 2006, 2001, 2003, 2005, 2007 });

            distinctYears.Should().HaveCount(3);
            distinctYears.Should().ContainInOrder(new int[] { 2000, 2001, 2002 });
        }

    }
}
