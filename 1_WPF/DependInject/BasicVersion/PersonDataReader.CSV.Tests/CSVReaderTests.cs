using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PersonDataReader.CSV.Tests
{
    [TestClass]
    public class CSVReaderTests
    {
        [TestMethod]
        public void GetPeopleWithGoodRecords_ReturnsAllRecords()
        {
            //arrange
             var reader = new CSVReader();
             reader.FileLoader = new MockFileLoader("Good");


             //act
             var result = reader.GetPeople(); 

             //assert
             Assert.AreEqual(2, result.Count());

        }
    }
}
