using SimpleJSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Data
{
    public class FactionInfo
    {
        public string name;
        public int num;

        public void processFactionInfo (JSONNode faction)
        {
            name = faction["name"].Value;
            num = faction["num"].AsInt;
        }
    }
}
