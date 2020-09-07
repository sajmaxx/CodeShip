using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PeopleViewer.Presentation.Tests
{
    [TestClass]
    public class DataReaderTest
    {
        [TestMethod]
        public void People_OnRefreshPeople_IsPopulated()
        {

            //Arrange
            var reader = new MockReader();
            var mockviewModel = new PeopleViewModel(reader);

            //Act
            mockviewModel.RefreshPeople();

            //Assert
            Assert.IsNotNull(mockviewModel.People);
            Assert.AreEqual(2, mockviewModel.People.Count());
        }

        [TestMethod]
        public void KorangaMoonjiTEst()
        {
            //arrange
            var reader = new MockReader();
            var mockviewModel = new PeopleViewModel(reader);

            mockviewModel.RefreshPeople();
            
            //act
            mockviewModel.ClearPeople();


            //assert
            Assert.AreEqual(0, mockviewModel.People.Count());
        }
    }
}
