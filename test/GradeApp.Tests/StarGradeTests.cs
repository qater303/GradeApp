using System;
using Xunit;
using GradeApp;

namespace GradeApp.Tests
{
    public class StarGradeTests
    {
        [Fact]
        public void StarsGradeTest()
        {
            var film = new Movie("Test", "test");
            film.AddGrade("1");
            film.AddGrade("10");
            var stat = new Statistics();
            stat = film.GetStatistics();
            Assert.Equal("***", stat.Stars);
        }
    }
}
