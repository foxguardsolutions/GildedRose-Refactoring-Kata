﻿using System;
using System.IO;
using System.Reflection;
using GildedRoseApp;
using NUnit.Framework;

namespace GildedRoseTests
{
    [TestFixture]
    public class ProgramTests
    {
        [Test]
        public void Program_CompareConsoleOutputToGoldenMaster_ReturnTrue()
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"ThirtyDays.txt");
            var lines = File.ReadAllLines(path);

            var sw = new StringWriter();
            Console.SetOut(sw);
            Console.SetIn(new StringReader("a\n"));

            Program.Main(new string[] { });
            var outputLines = sw.ToString().Replace("\r", "").Split('\n');

            Assert.That(outputLines.ToString().Trim(), Is.EqualTo(lines.ToString().Trim()));
        }
    }
}
