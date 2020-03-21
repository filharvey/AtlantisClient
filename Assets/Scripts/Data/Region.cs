using SimpleJSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Data
{
    public class Region
    {
        public int x = 0;
        public int y = 0;
        public string type;
        public string regionName;
        public string townName;
        public string townType;
        public string population;
        public string populationRace;
        public int wealth = 0;

        public List<Unit> units = new List<Unit>();
        public List<Item> wanted = new List<Item>();
        public List<Item> forSale = new List<Item>();
        public List<Item> products = new List<Item>();
        public List<Structure> structures = new List<Structure>();

        public Dictionary<string, Exit> exits = new Dictionary<string, Exit>();

        public void processRegion (JSONNode region)
        {
            x = region["x"].AsInt;
            y = region["y"].AsInt;
            type = region["type"].Value;
            regionName = region["region"].Value;
            townName = region["townName"].Value;
            townType = region["townType"].Value;
            population = region["population"].Value;
            populationRace = region["populationRace"].Value;
            wealth = region["wealth"].AsInt;

            // economy
            JSONNode economy = region["economy"];
            JSONNode ewanted = economy["wanted"];
            for (var a = 0; a < ewanted.Count; a++)
            {
                Item item = new Item();
                item.processItem(ewanted[a]);

                wanted.Add(item);
            }
            JSONNode eforSale = economy["forSale"];
            for (var a = 0; a < eforSale.Count; a++)
            {
                Item item = new Item();
                item.processItem(eforSale[a]);

                forSale.Add(item);
            }
            JSONNode eproducts = economy["products"];
            for (var a = 0; a < eproducts.Count; a++)
            {
                Item item = new Item();
                item.processItem(eproducts[a]);

                products.Add(item);
            }

            //exits
            JSONNode jexits = region["exits"];
            List<string> keyList = new List<string>((jexits as JSONClass).m_Dict.Keys);
            for (var a = 0; a < jexits.Count; a++)
            {
                JSONNode jexit = jexits[a];
                Exit exit = new Exit();
                exit.processExit(jexit);

                exits.Add(keyList[a], exit);
            }

            //units
            JSONNode jsonUnits = region["units"];
            for (var u = 0; u < jsonUnits.Count; u++)
            {
                Unit unit = new Unit();
                unit.processUnit(jsonUnits[u]);

                units.Add(unit);
            }

            //structures
            JSONNode jstructures = region["structures"];
            for (var a = 0; a < jstructures.Count; a++)
            {
                Structure structure = new Structure();
                structure.processStructure(jstructures[a]);

                structures.Add(structure);
            }
        }
    }
}
