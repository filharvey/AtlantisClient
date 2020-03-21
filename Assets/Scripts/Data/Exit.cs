using SimpleJSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Data
{
    public class Exit
    {
        public string type;
        public int x;
        public int y;
        public string region;

        public void processExit (JSONNode exit)
        {
            type = exit["type"].Value;
            x = exit["x"].AsInt;
            y = exit["y"].AsInt;
            region = exit["region"].Value;
        }
    }
}
