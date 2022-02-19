using System;
using Xunit;
using GradeApp;
using System.Collections.Generic;

namespace GradeApp.Tests
{
    public class TvSeriesTests
    {
        [Fact]
        public void TvSeriesSeasonCountTest()
        {
            var serial = new TvSeries("Dark", "sci-fi");
            Assert.Equal(1, serial.Seasons.Count);
        }
        [Fact]
        public void TvSeriesAddSeasonTest()
        {
            var serial = new TvSeries("Dark", "sci-fi");
            serial.AddSeason();
            serial.AddSeason();
            Assert.Equal(3, serial.Seasons.Count);
        }
        [Fact]
        public void TvSeriesSetActualSeaonTest()
        {
            var serial = new TvSeries("Dark", "sci-fi");
            serial.AddSeason();
            serial.AddSeason();
            serial.SetActualSeason(3);
            Assert.Equal(3, serial.ActualSeason);
        }
        [Fact]
        public void TvSeriesAddGradeTestToSeasonTwo()
        {
            var serial = new TvSeries("Dark", "sci-fi");
            serial.AddSeason();
            serial.AddSeason();
            serial.SetActualSeason(2);
            serial.AddGrade("3");
            var result = serial.GetStatistics();
            Assert.Equal(3, result.Average);

            serial.SetActualSeason(1);
            try
            {
                result = serial.GetStatistics();
            }
            catch (Exception exp)
            {
                Assert.Equal("Brak ocen", exp.Message);
            }
        }

    }
}
