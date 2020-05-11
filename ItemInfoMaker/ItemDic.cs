using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemInfoMaker
{
    class ItemDic
    {
        static public string LimitID(Dictionary<int, Item> dic)
        {
            string wrn_msg = "";

            List<int> idlist = dic.Keys.ToList();
            foreach ( int id in idlist)
            {
                if( id >= 0x10000)
                {
                    int newid = id % 0x10000;
                    Item newitem = dic[id];
                    newitem.id = newid;
                    dic.Remove(id);
                    if ( dic.ContainsKey(newid))
                    {
                         wrn_msg += dic[newid].identifiedDisplayName + "(" + newid.ToString() + ")が"
                            + newitem.identifiedDisplayName + "(" + id.ToString() + ")と重複したため削除されました" + Environment.NewLine;
                        dic.Remove(newid);
                    }
                    dic.Add(newid, newitem);

                }
            }
            return wrn_msg;
        }
        static public List<Item> ToList(Dictionary<int, Item> dic,bool sort)
        {
            List < Item > list = new List<Item>(dic.Values);
            if (sort)
            {
                list.Sort();
            }
            return list;
        }
        static public void FillDummy(List<Item> list)
        {
            foreach( Item x in list)
            {
                x.FillDummyData();
            }
        }
    }
}
