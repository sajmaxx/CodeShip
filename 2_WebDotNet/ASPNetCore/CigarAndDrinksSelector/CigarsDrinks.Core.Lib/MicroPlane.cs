using System;
using System.Collections.Generic;
using System.Text;

namespace CigarsDrinks.Core.Lib
{
    public enum EngineType
    {
        none,
        jet,
        prop,
        turboprop
    }
    public class MicroPlane
    {
        public string Company { get; set; }
        public string ModelName { get; set; }
        public int ModelNo { get; set; }
        public double WingSpan { get; set; }
        public double Length { get; set; }
        public EngineType Engine { get; set; }

        // todo: what to do
        public MicroPlane()
        {
            
        }
        // todo: what is this
        public MicroPlane(string company, string modelName, int modelNo, EngineType engine)
        {
            Company = company;
            ModelName = modelName;
            ModelNo = modelNo;
            Engine = engine;
        }


        // bug: what to do here is to make this smaller
        public MicroPlane(string company, string modelName, int modelNo, double wingSpan, double length, EngineType engine)
        {
            Company = company;
            ModelName = modelName;
            ModelNo = modelNo;
            WingSpan = wingSpan;
            Length = length;
            Engine = engine;
        }


        private sealed class MakerEqualityComparer : IEqualityComparer<MicroPlane>
        {
            public bool Equals(MicroPlane x, MicroPlane y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Company == y.Company && x.ModelName == y.ModelName;
            }

            public int GetHashCode(MicroPlane obj)
            {
                return HashCode.Combine(obj.Company, obj.ModelName);
            }
        }

        public static IEqualityComparer<MicroPlane> MakerComparer { get; } = new MakerEqualityComparer();

        private sealed class DimensionEqualityComparer : IEqualityComparer<MicroPlane>
        {
            public bool Equals(MicroPlane x, MicroPlane y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.WingSpan.Equals(y.WingSpan) && x.Length.Equals(y.Length);
            }

            public int GetHashCode(MicroPlane obj)
            {
                return HashCode.Combine(obj.WingSpan, obj.Length);
            }
        }

        public static IEqualityComparer<MicroPlane> DimensionComparer { get; } = new DimensionEqualityComparer();
    }
}
