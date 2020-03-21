using Assets.Scripts.Data;
using SimpleJSON;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{
    public List<Region> regions = new List<Region> ();

    public Dictionary<int, List<Unit>> knownFactions = new Dictionary<int, List<Unit>>();

    // Start is called before the first frame update
    void Start()
    {
        Layout flat = new Layout(Layout.flat, new Point(10.0, 10.0), new Point(0, 0));

        DoubledCoord d1 = new DoubledCoord(0, 0);
        DoubledCoord d2 = new DoubledCoord(1, 1);
        DoubledCoord d3 = new DoubledCoord(1, -1);
        Hex h1 = d1.QdoubledToCube();
        Hex h2 = d2.QdoubledToCube();
        Hex h3 = d3.QdoubledToCube();

        Point points1 = flat.HexToPixel(h1);
        Point points2 = flat.HexToPixel(h2);
        Point points3 = flat.HexToPixel(h3);

        FractionalHex p = flat.PixelToHex(new Point (0, 1));
        DoubledCoord dp = DoubledCoord.QdoubledFromCube(p.HexRound());

        DoubledCoord d1n0 = DoubledCoord.QdoubledFromCube(h1.Neighbor(0));
        DoubledCoord d1n1 = DoubledCoord.QdoubledFromCube(h1.Neighbor(1));
        DoubledCoord d1n2 = DoubledCoord.QdoubledFromCube(h1.Neighbor(2));
        DoubledCoord d1n3 = DoubledCoord.QdoubledFromCube(h1.Neighbor(3));
        DoubledCoord d1n4 = DoubledCoord.QdoubledFromCube(h1.Neighbor(4));
        DoubledCoord d1n5 = DoubledCoord.QdoubledFromCube(h1.Neighbor(5));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey (KeyCode.Space))
        {
            loadJSON();
        }
    }

    void loadJSON ()
    {
        TextAsset txt = (TextAsset)Resources.Load("report.3", typeof(TextAsset));

        if (txt)
        {
            string text = txt.text;

            JSONNode json = JSON.Parse(text);

            Faction faction = new Faction();
            faction.processFaction(json);

            int month = json["month"].AsInt;
            int year = json["year"].AsInt;

            string engineVersion = json["engineVersion"].Value;
            string ruleSet = json["ruleSet"].Value;
            string ruleSetVersion = json["ruleSetVersion"].Value;
            JSONNode events = json["events"];
            JSONNode itemReports = json["itemReports"];

            JSONNode regions = json["regions"];
            for (var a = 0; a < regions.Count; a++)
            {
                Region region = new Region();
                region.processRegion(regions[a]);

                for (var u = 0; u < region.units.Count; u++)
                {
                    Unit unit = region.units[u];

                    if (unit.own)
                    {
                        faction.units.Add(unit);
                    }
                    else
                    {
                        if (knownFactions.ContainsKey (unit.factionInfo.num))
                        {
                            knownFactions[unit.factionInfo.num].Add(unit);
                        }
                        else
                        {
                            knownFactions.Add(unit.factionInfo.num, new List<Unit>());
                            knownFactions[unit.factionInfo.num].Add(unit);
                        }
                    }
                }

                this.regions.Add(region);
            }
        }
    }
}
