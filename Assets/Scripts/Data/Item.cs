using SimpleJSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Data
{
    public class Item
    {
        public int amount = 1;
        public string type;
        public string abr;
        public int price = 0;

        public void processItem (JSONNode item)
        {
            amount = item["amount"].AsInt;
            type = item["type"].Value;
            abr = item["abr"].Value;
            price = item["price"].AsInt;
        }
    }
}
