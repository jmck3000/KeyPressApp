using KeyPressApp.Engine;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace KeyPressApp.Test
{
    public class LoggerShould
    {

        [Test]
        public void WriteLogContain()
        {
            var sut = new Logger();

            sut.WriteLog("Test123");

            Assert.That(sut.LogText, Does.Contain("Test123"));
        }

        [Test]
        public void WriteLogDoesNotContain()
        {
            var sut = new Logger();

            sut.WriteLog("Test123");

            Assert.That(sut.LogText, Does.Not.Contain("ABC"));
        }

        [Test]
        public void CanClearLog()
        {
            var sut = new Logger();

            sut.WriteLog("Test123");
            sut.ClearLog();

            Assert.That(sut.LogText, Is.EqualTo(""));
        }
    }
}
