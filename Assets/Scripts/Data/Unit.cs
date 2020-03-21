using SimpleJSON;
using System.Collections.Generic;

namespace Assets.Scripts.Data
{
    public class Unit
    {
        public string name;
        public int num;
        public FactionInfo factionInfo = new FactionInfo();
        public bool own;
        public string revealing;
        public string consume;
        public int weight;

        public List<Item> items = new List<Item>();
        public List<Item> readyWeapons = new List<Item>();
        public List<Item> readyArmors = new List<Item>();
        public Item readyItem = new Item ();

        public List<Skill> skills = new List<Skill>();
        public List<Skill> canStudy = new List<Skill>();

        public void processUnit (JSONNode unit)
        {
            name = unit["name"].Value;
            num = unit["num"].AsInt;
            factionInfo.processFactionInfo(unit["faction"]);
            own = unit["own"].AsBool;
            revealing = unit["revealing"].Value;
            consume = unit["consume"].Value;
            weight = unit["weight"].AsInt;

            JSONNode capacity = unit["capcity"];

            JSONNode jskills = unit["skills"];
            for (int a = 0; a < jskills.Count; a++)
            {
                Skill skill = new Skill();
                skill.processSkill(jskills[a]);

                skills.Add(skill);
            }

            JSONNode flags = unit["flags"];

            JSONNode jitems = unit["items"];
            for (int a = 0; a < jitems.Count; a++)
            {
                Item item = new Item();
                item.processItem(jitems[a]);

                items.Add(item);
            }

            JSONNode ready = unit["ready"];
            JSONNode readyWeapon = ready["weapon"];
            for (int a = 0; a < readyWeapon.Count; a++)
            {
                Item item = new Item();
                item.processItem(readyWeapon[a]);

                readyWeapons.Add(item);
            }
            JSONNode readyArmor = ready["armor"];
            for (int a = 0; a < readyArmor.Count; a++)
            {
                Item item = new Item();
                item.processItem(readyArmor[a]);

                readyArmors.Add(item);
            }

            readyItem.processItem (ready["item"]);

            JSONNode jcanStudy = unit["canStudy"];
            for (int a = 0; a < jcanStudy.Count; a++)
            {
                Skill skill = new Skill();
                skill.processSkill(jcanStudy[a]);

                canStudy.Add(skill);
            }
        }
    }
}
