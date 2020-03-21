using SimpleJSON;
using System.Collections.Generic;

namespace Assets.Scripts.Data
{
    public class Faction
    {
        public string name;
        public FactionType factionType = new FactionType ();
        public FactionStatus factionStatus = new FactionStatus ();
        public Attitudes attitudes = new Attitudes ();
        public int unclaimedSilver = 0;

        public List<Unit> units = new List<Unit>();

        public void processFaction (JSONNode json)
        {
            name = json["faction"].Value;
            factionType.processFactionType (json["factionType"]);
            factionStatus.processFactionStatus (json["factionStatus"]);
            attitudes.processAttitudes (json["attitudes"]);
            unclaimedSilver = json["unclaimedSilver"].AsInt;
        }
    }
}
