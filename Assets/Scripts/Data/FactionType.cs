using SimpleJSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Data
{
    public class FactionType
    {
        public int war;
        public int trade;
        public int magic;

        public void processFactionType (JSONNode factionType)
        {
            war = factionType["War"].AsInt;
            trade = factionType["Trade"].AsInt;
            magic = factionType["Magic"].AsInt;
        }
    }
}
