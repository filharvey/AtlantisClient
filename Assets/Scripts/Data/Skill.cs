using SimpleJSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Data
{
    public class Skill
    {
        public string name;
        public string abbr;
        public int level;
        public int days;

        public void processSkill (JSONNode skill)
        {
            name = skill["name"].Value;
            abbr = skill["abbr"].Value;
            level = skill["level"].AsInt;
            days = skill["days"].AsInt;
        }
    }
}
