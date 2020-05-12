using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace ItemInfoMaker
{
    class ItemDic
    {
        static public string LimitID(Dictionary<int, Item> dic)
        {
            string wrn_msg = "";

            // 重複優先設定が存在する場合読み込み
            Dictionary<int, List<int>> whitelist = new Dictionary<int, List<int>>();
            string file = Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName + "\\DuplicateConfig.xml";
            try
            {
                XElement xml = XElement.Load(file);

                //入力設定
                IEnumerable<XElement> infos = from item in xml.Elements("IDPair")
                                              select item;
                int use_id;
                foreach (XElement info in infos)
                {
                    string useid_str = info.XPathSelectElement("UseID").Value;
                    if (int.TryParse(useid_str, out use_id))
                    {
                        List<int> ignore_id_list = new List<int>();
                        IEnumerable<String> ignoreid_strs = from item in xml.Elements("IDPair")
                                                             where item.Element("UseID").Value == useid_str
                                                             select item.Element("IgnoreID").Value;
                        foreach (String ignoreid_str in ignoreid_strs)
                        {
                            int ignore_id;
                            if (int.TryParse(ignoreid_str, out ignore_id))
                            {
                                ignore_id_list.Add(ignore_id);
                            }
                        }
                        if(ignore_id_list.Count > 0)
                        {
                            whitelist.Add(use_id, ignore_id_list);
                        }
                    }
                }
            }
            catch
            {
                wrn_msg += "DuplicateConfig.xmlのリードに失敗しました" + Environment.NewLine;
            }

            // 重複削除処理

            List<int> idlist = dic.Keys.ToList();
            foreach ( int id in idlist)
            {
                if( id >= 0x10000)
                {
                    int newid = id % 0x10000;
                    Item newitem = dic[id];
                    newitem.id = newid;
                    dic.Remove(id);
                    if (dic.ContainsKey(newid))
                    {
                        if (whitelist.ContainsKey(newid) && whitelist[newid].Contains(id))
                        {
                            //元々登録されているものを優先する
                        }
                        else
                        {
                            //変換するものを優先する
                            if (!whitelist.ContainsKey(id) || !whitelist[id].Contains(newid))
                            {
                                //リストにない場合は警告を出す
                                wrn_msg += dic[newid].identifiedDisplayName + "(" + newid.ToString() + ")が"
                               + newitem.identifiedDisplayName + "(" + id.ToString() + ")と重複したため削除されました" + Environment.NewLine;
                            }
                            dic.Remove(newid);
                            dic.Add(newid, newitem);
                        }
                    }
                    else
                    {
                        dic.Add(newid, newitem);
                    }

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
