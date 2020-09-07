using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDataReader.CSV.Tests
{
    class MockFileLoader : ICSVFileLoader
    {
        private string _dataType;

        public MockFileLoader(string dataType)
        {
            _dataType = dataType;
        }

        public string LoadFile()
        {
            switch (_dataType)
            {
                case "Good": return PersonTestData.WithGoodRecords;
                case "Mixed": return PersonTestData.WithGoodAndBadRecords;
                case "Bad": return PersonTestData.WithOnlyBadRecords;
                case "Empty": return string.Empty;
                default: return PersonTestData.WithGoodRecords;
            }
        }
    }
}
