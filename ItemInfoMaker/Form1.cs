using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
using System.Runtime.CompilerServices;
using System.Xml.XPath;

namespace ItemInfoMaker
{
    public partial class Form1 : Form
    {
        private string output_inteminfo_path;
        private string output_intemdb_path;
        private string version = "0.3";

        public Form1()
        {
            InitializeComponent();
            this.Text += " v" + version;
            ReadSettings();
        }

        private void ReadSettings()
        {
            string file = Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName + "\\Config.xml";
            try
            {
                XElement xml = XElement.Load(file);

                //入力設定以外
                bool tmp_checked;
                if (bool.TryParse(xml.XPathSelectElement("LimitItemID").Value, out tmp_checked))
                {
                    checkBox_2ByteID.Checked = tmp_checked;
                }
                if (bool.TryParse(xml.XPathSelectElement("FillDummy").Value, out tmp_checked))
                {
                    checkBox_FillDummy.Checked = tmp_checked;
                }
                if (bool.TryParse(xml.XPathSelectElement("SortByID").Value, out tmp_checked))
                {
                    checkBoxSortID.Checked = tmp_checked;
                }
                if (bool.TryParse(xml.XPathSelectElement("Costume").Value, out tmp_checked))
                {
                    checkBoxCostume.Checked = tmp_checked;
                }
                output_inteminfo_path = xml.XPathSelectElement("iteminfo_path").Value;
                output_intemdb_path = xml.XPathSelectElement("itemdb_path").Value;

                //入力設定
                IEnumerable<XElement> infos = from item in xml.Elements("Input")
                                              select item;
                foreach (XElement info in infos)
                {
                    string[] add_item = { info.Element("type").Value, info.Element("path").Value };
                    listViewInput.Items.Add(new ListViewItem(add_item));
                }
                listViewInput.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            catch{

            }
        }

        private void WriteSettings()
        {
            string file = Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName + "\\Config.xml";
            XElement root = new XElement("root",
                new XElement("LimitItemID", checkBox_2ByteID.Checked
                ),
                new XElement("FillDummy", checkBox_FillDummy.Checked
                ),
                new XElement("SortByID", checkBoxSortID.Checked
                ),
                new XElement("Costume", checkBoxCostume.Checked
                ),
                new XElement("iteminfo_path", output_inteminfo_path
                ),
                new XElement("itemdb_path", output_intemdb_path
                )
                );

            //入力設定
            foreach( ListViewItem lvitem in listViewInput.Items)
            {
                root.Add(new XElement("Input",
                    new XElement("type", lvitem.SubItems[0].Text
                ),
                    new XElement("path", lvitem.SubItems[1].Text
                )
                ));
            }
            FileStream fs = new FileStream(file, FileMode.Create);
            root.Save(fs);
            fs.Close();
            fs.Dispose();
        }

        private void buttonMake_Click(object sender, EventArgs e)
        {

            SaveFileDialog sfDialog = new SaveFileDialog();

            // デフォルトのフォルダを指定する
            if (output_inteminfo_path == "" || !Directory.Exists(Directory.GetParent(output_inteminfo_path).FullName))
            {
                sfDialog.InitialDirectory = Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName;
            }
            else
            {
                sfDialog.InitialDirectory = Directory.GetParent(output_inteminfo_path).FullName;
                sfDialog.FileName = Path.GetFileName(output_inteminfo_path);
            }

            //ダイアログのタイトルを指定する
            sfDialog.Title = "ファイルを選択して下さい";
            sfDialog.Filter = "(*.lua;*.lub)|*.lua;*.lub|すべてのファイル(*.*)|*.*";

            //ダイアログを表示する
            if (sfDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            output_inteminfo_path = sfDialog.FileName;


            Dictionary<int, Item> dic = new Dictionary<int, Item>();

            textBoxErrMsg.Text = "";

            //読み込み
            for ( int i = listViewInput.Items.Count -1; i >= 0; i--)
            {
                ListViewItem item = listViewInput.Items[i];
                try
                {
                    Reader r = ReaderFactory.CreateInstance(item.SubItems[0].Text, item.SubItems[1].Text);
                    r.AddInfo(dic);
                }
                catch{
                    textBoxErrMsg.Text += item.SubItems[1].Text + "のリードに失敗しました" + Environment.NewLine;
                }
            }
            //ID2バイト化
            if (checkBox_2ByteID.Checked)
            {
                string msg = ItemDic.LimitID(dic);
                textBoxErrMsg.Text += msg;
            }

            //リスト化＋ソート
            List<Item> list = ItemDic.ToList(dic, checkBoxSortID.Checked);

            //ダミーデータ挿入
            if (checkBox_FillDummy.Checked)
            {
                ItemDic.FillDummy(list);
            }

            //書き込み
            string dir = Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName;
            Writer wr = new Writer(output_inteminfo_path, dir + "\\itemInfo_footer.lub");
            wr.Write(list, checkBoxCostume.Checked, true);
            System.Media.SystemSounds.Asterisk.Play();
            textBoxErrMsg.Text += "Done";
            textBoxErrMsg.SelectionStart = textBoxErrMsg.Text.Length;
            textBoxErrMsg.ScrollToCaret();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            WriteSettings();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FormInputConfig finput = new FormInputConfig();
            if( finput.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string[] add_item = { finput.type, finput.path };
            listViewInput.Items.Add(new ListViewItem(add_item));
            listViewInput.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewInput.SelectedIndices.Count == 0)
            {
                return;
            }
            FormInputConfig finput = new FormInputConfig();
            finput.SetConfig(listViewInput.SelectedItems[0].SubItems[0].Text, listViewInput.SelectedItems[0].SubItems[1].Text);
            if (finput.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            listViewInput.SelectedItems[0].SubItems[0].Text = finput.type;
            listViewInput.SelectedItems[0].SubItems[1].Text = finput.path;
            listViewInput.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (listViewInput.SelectedIndices.Count == 0)
            {
                return;
            }
            foreach (ListViewItem item in listViewInput.SelectedItems)
            {
                listViewInput.Items.Remove(item);
            }
        }

        private void buttonPriorityUp_Click(object sender, EventArgs e)
        {
            if((listViewInput.SelectedItems.Count == 0)
                || (listViewInput.SelectedItems[0].Index == 0))
            {
                return;
            }
            int insert_index = listViewInput.SelectedItems[0].Index - 1;
            ListViewItem selected_item = listViewInput.SelectedItems[0];
            listViewInput.Items.Remove(selected_item);
            listViewInput.Items.Insert(insert_index, selected_item);
        }

        private void buttonPriorityDown_Click(object sender, EventArgs e)
        {
            if ((listViewInput.SelectedItems.Count == 0)
                || (listViewInput.SelectedItems[0].Index == listViewInput.Items.Count - 1))
            {
                return;
            }
            int insert_index = listViewInput.SelectedItems[0].Index + 1;
            ListViewItem selected_item = listViewInput.SelectedItems[0];
            listViewInput.Items.Remove(selected_item);
            listViewInput.Items.Insert(insert_index, selected_item);
        }
    }
}
