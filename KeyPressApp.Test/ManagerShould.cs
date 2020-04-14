using KeyPressApp.Engine;
using KeyPressApp.Managers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace KeyPressApp.Test
{
    public class ManagerShould
    {

        Manager _sut;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var mockIKeyPress = new Mock<IKeyPress>();
            var mockILogger = new Mock<ILogger>();

            _sut = new Manager(mockIKeyPress.Object, mockILogger.Object);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {

            foreach (var process in Process.GetProcessesByName("notepad"))
            {
                process.Kill();
            }
        }

        [Test]
        public void GivingThatAnAppIsNotRunning()
        {
            Assert.That(_sut.IsAppRunning("MyDummy.app"), Is.False);
        }

        [Test]
        public void GivingThatAnAppIsRunning()
        {
            Process.Start("notepad.exe");

            Assert.That(_sut.IsAppRunning("notepad"), Is.True);
        }


        [Test]
        public void GetLogIsText()
        {
            var mockIKeyPress = new Mock<IKeyPress>();
            var mockILogger = new Mock<ILogger>();

            mockILogger.Setup(x => x.LogText).Returns("Hello Wrold");

            var sut = new Manager(mockIKeyPress.Object, mockILogger.Object);

            Assert.That(sut.GetLog(), Is.EqualTo("Hello Wrold"));
        }



    }
}