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
        private Manager _sut;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            foreach (var process in Process.GetProcessesByName("notepad"))
            {
                process.Kill();
            }
        }

        [SetUp]
        public void Setup()
        {
            var mockIKeyPress = new Mock<IKeyPress>();
            var mockILogger = new Mock<ILogger>();

            _sut = new Manager(mockIKeyPress.Object, mockILogger.Object);
        }

        [Test]
        public void GivingThatAnAppIsNotRunning()
        {        
            Assert.That(_sut.IsAppRunning("ABC.app"), Is.False);
        }

        [Test]
        public void GivingThatAnAppIsRunning()
        {
            Process.Start("notepad.exe");

            Assert.That(_sut.IsAppRunning("notepad"), Is.True);
        }





    }
}