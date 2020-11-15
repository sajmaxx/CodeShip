using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using CigarsDrinks.Core.Lib;

namespace CigarAccessService
{
    public interface IMicroAirplane
    {
        IEnumerable<MicroPlane> GetMicroPlanes();
        IEnumerable<MicroPlane> GetMicroPlanesByCompany(string compName);
    }

    
    public class MicroAirplaneDataReader : IMicroAirplane
    {
        private List<MicroPlane> myMicroPlanes;

        public MicroAirplaneDataReader()
        {
            myMicroPlanes = new List<MicroPlane>()
            {
                new MicroPlane("Boeing","Y222",222,EngineType.prop),
                new MicroPlane("Boeing","Y422",222,EngineType.turboprop),
                new MicroPlane("Airbus","cz595",595,444,555,EngineType.turboprop),
                new MicroPlane("Airbus","cz7545",7545,444,555,EngineType.jet)


            };

        }

        public IEnumerable<MicroPlane> GetMicroPlanes()
        {
            return from microplane in myMicroPlanes
                orderby microplane.Company
                select microplane;
        }

        public IEnumerable<MicroPlane> GetMicroPlanesByCompany(string compName)
        {
            return from microplane in myMicroPlanes
                where string.IsNullOrEmpty(compName) || (microplane.ModelName.Contains(compName))
                orderby microplane.ModelNo
                select microplane;
        }


        public void DoWorkOnSimilarPlanes()
        {
            var lastmicro  = myMicroPlanes.Last();
            foreach(MicroPlane micro in myMicroPlanes) 
            {
                if (micro.Equals(lastmicro))
                {
                    return ;
                }
            }

        }
    }
}
