using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItemInfoMaker
{
    public partial class FormInputConfig : Form
    {
        public string type;
        public string path;
        public FormInputConfig()
        {
            InitializeComponent();

            foreach (FileType v in Enum.GetValues(typeof(FileType)))
            {
                comboBox1.Items.Add(Enum.GetName(typeof(FileType), v));
            }
            comboBox1.SelectedIndex = 0;
            textBoxPath.Text = "";
        }

        public void SetConfig(string initial_type,string initial_path)
        {
            comboBox1.Text = initial_type;
            textBoxPath.Text = initial_path;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            type = comboBox1.Text;
            path = textBoxPath.Text;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonSelectPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofDialog = new OpenFileDialog();

            // デフォルトのフォルダを指定する
            if (textBoxPath.Text == "" || !Directory.Exists(Directory.GetParent(textBoxPath.Text).FullName))
            {
                ofDialog.InitialDirectory = Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName;
            }
            else
            {
                ofDialog.InitialDirectory = Directory.GetParent(textBoxPath.Text).FullName;
            }

            //ダイアログのタイトルを指定する
            ofDialog.Title = "ファイルを選択して下さい";
            ofDialog.Filter = "(*.txt;*.lua;*.lub)|*.txt;*.lua;*.lub|すべてのファイル(*.*)|*.*";

            //ダイアログを表示する
            if (ofDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            textBoxPath.Text = ofDialog.FileName;
        }
    }
}
