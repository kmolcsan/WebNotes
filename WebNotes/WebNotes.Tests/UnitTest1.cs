using System;
using NUnit.Framework;
using WebNotes.ServiceInterface;
using WebNotes.ServiceModel;
using ServiceStack.Testing;
using ServiceStack;

namespace WebNotes.Tests
{
    [TestFixture]
    public class UnitTests
    {
        private readonly ServiceStackHost appHost;

        public UnitTests()
        {
            appHost = new BasicAppHost(typeof(NotesService).Assembly)
            {
                ConfigureContainer = container =>
                {
                    //Add your IoC dependencies here
                }
            }
            .Init();
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            appHost.Dispose();
        }

        [Test]
        public void TestMethod1()
        {
            var service = appHost.Container.Resolve<NotesService>();

            var response = (GetNotesResponse)service.Get(new GetNotes { });

            Assert.That(response.Results, Is.Empty);
        }
    }
}
