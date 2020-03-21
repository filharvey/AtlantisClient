using SimpleJSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Data
{
    public class Attitudes
    {
        public string defaultAtt;
        public List<FactionInfo> hostile = new List<FactionInfo>();
        public List<FactionInfo> unfriendly = new List<FactionInfo>();
        public List<FactionInfo> neutral = new List<FactionInfo>();
        public List<FactionInfo> friendly = new List<FactionInfo>();
        public List<FactionInfo> ally = new List<FactionInfo>();

        public void processAttitudes (JSONNode attitude)
        {
            defaultAtt = attitude["default"].Value;

            JSONNode h = attitude["Hostile"];
            JSONNode u = attitude["Unfriendly"];
            JSONNode n = attitude["Neutral"];
            JSONNode f = attitude["Friendly"];
            JSONNode al = attitude["Ally"];

            for (var a = 0; a < h.Count; a++)
            {
                FactionInfo factionInfo = new FactionInfo();
                factionInfo.processFactionInfo(h[a]);

                hostile.Add(factionInfo);
            }

            for (var a = 0; a < u.Count; a++)
            {
                FactionInfo factionInfo = new FactionInfo();
                factionInfo.processFactionInfo(u[a]);

                unfriendly.Add(factionInfo);
            }

            for (var a = 0; a < n.Count; a++)
            {
                FactionInfo factionInfo = new FactionInfo();
                factionInfo.processFactionInfo(n[a]);

                neutral.Add(factionInfo);
            }

            for (var a = 0; a < f.Count; a++)
            {
                FactionInfo factionInfo = new FactionInfo();
                factionInfo.processFactionInfo(f[a]);

                friendly.Add(factionInfo);
            }

            for (var a = 0; a < al.Count; a++)
            {
                FactionInfo factionInfo = new FactionInfo();
                factionInfo.processFactionInfo(al[a]);

                ally.Add(factionInfo);
            }
        }
    }
}
