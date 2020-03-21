using SimpleJSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Data
{
    public class FactionStatus
    {
        public int taxRegions;
        public int maxTaxRegions;
        public int tradeRegions;
        public int maxTradeRegions;
        public int quartermasters;
        public int maxQuartermasters;
        public int mages;
        public int maxMages;
        public int apprentice;
        public int maxApprentice;

        public void processFactionStatus (JSONNode status)
        {
            taxRegions = status["taxRegions"].AsInt;
            maxTaxRegions = status["maxTaxRegions"].AsInt;
            tradeRegions = status["tradeRegions"].AsInt;
            maxTradeRegions = status["maxTradeRegions"].AsInt;
            quartermasters = status["quartermasters"].AsInt;
            maxQuartermasters = status["maxQuartermasters"].AsInt;
            mages = status["mages"].AsInt;
            maxMages = status["maxMages"].AsInt;
            apprentice = status["apprentice"].AsInt;
            maxApprentice = status["maxApprentice"].AsInt;
        }
    }
}
