using SimpleJSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Data
{
    public class Capacity
    {
        public int flying = 0;
        public int riding = 0;
        public int walking = 0;
        public int swimming = 0;

        public void processCapcity (JSONNode capacity)
        {
            flying = capacity["flying"].AsInt;
            riding = capacity["riding"].AsInt;
            walking = capacity["walking"].AsInt;
            swimming = capacity["swimming"].AsInt;
        }
    }
}
