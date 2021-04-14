using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using MarsRover.Infrastructure.Geography;
using Xunit;

namespace MarsRover.Infrastructure.UnitTests.Geography
{
    // ReSharper disable once UnusedMember.Global
    public class Point_Tests
    {

        [Fact]
        public void EqualOpeator_Should_False()
        {
            var point1 = new Point(0, 0);
            var point2 = new Point(2, 3);

            var output = point1 == point2;
            output.Should().BeFalse();
        }
        [Fact]
        public void EqualOpeator_Should_True()
        {
            var point1 = new Point(0, 0);
            var point2 = new Point(0, 0);

            var output = point1 == point2;
            output.Should().BeTrue();
        }
        [Fact]
        public void NotEqualOpeator_Should_True()
        {
            var point1 = new Point(0, 0);
            var point2 = new Point(2, 3);

            var output = point1 != point2;
            output.Should().BeTrue();
        }
        [Fact]
        public void NotEqualOpeator_Should_False()
        {
            var point1 = new Point(0, 0);
            var point2 = new Point(0, 0);

            var output = point1 != point2;
            output.Should().BeFalse();
        }

        [Fact]
        public void Equal_Should_True()
        {
            var point1 = new Point(0, 0);
            var point2 = new Point(2, 3);

            var output = point1.Equals(point2);
            output.Should().BeFalse();
        }
        [Fact]
        public void Equal_Should_False()
        {
            var point1 = new Point(0, 0);
            var point2 = new Point(0, 0);

            var output = point1.Equals(point2);
            output.Should().BeTrue();
        }
    }
}
