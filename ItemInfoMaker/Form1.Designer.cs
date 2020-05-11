namespace ItemInfoMaker
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonMake = new System.Windows.Forms.Button();
            this.checkBox_2ByteID = new System.Windows.Forms.CheckBox();
            this.listViewInput = new System.Windows.Forms.ListView();
            this.columnHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonPriorityUp = new System.Windows.Forms.Button();
            this.buttonPriorityDown = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.buttonMakeItemDB = new System.Windows.Forms.Button();
            this.checkBox_FillDummy = new System.Windows.Forms.CheckBox();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.checkBoxSortID = new System.Windows.Forms.CheckBox();
            this.textBoxErrMsg = new System.Windows.Forms.TextBox();
            this.checkBoxCostume = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonMake
            // 
            this.buttonMake.Location = new System.Drawing.Point(34, 351);
            this.buttonMake.Name = "buttonMake";
            this.buttonMake.Size = new System.Drawing.Size(115, 23);
            this.buttonMake.TabIndex = 0;
            this.buttonMake.Text = "ItemInfo出力";
            this.buttonMake.UseVisualStyleBackColor = true;
            this.buttonMake.Click += new System.EventHandler(this.buttonMake_Click);
            // 
            // checkBox_2ByteID
            // 
            this.checkBox_2ByteID.AutoSize = true;
            this.checkBox_2ByteID.Location = new System.Drawing.Point(34, 256);
            this.checkBox_2ByteID.Name = "checkBox_2ByteID";
            this.checkBox_2ByteID.Size = new System.Drawing.Size(263, 16);
            this.checkBox_2ByteID.TabIndex = 1;
            this.checkBox_2ByteID.Text = "IDを2Byteに制限する(ItemID拡張前のRagexe用)";
            this.checkBox_2ByteID.UseVisualStyleBackColor = true;
            // 
            // listViewInput
            // 
            this.listViewInput.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderType,
            this.columnHeaderPath});
            this.listViewInput.FullRowSelect = true;
            this.listViewInput.HideSelection = false;
            this.listViewInput.Location = new System.Drawing.Point(34, 12);
            this.listViewInput.MultiSelect = false;
            this.listViewInput.Name = "listViewInput";
            this.listViewInput.Size = new System.Drawing.Size(742, 237);
            this.listViewInput.TabIndex = 2;
            this.listViewInput.UseCompatibleStateImageBehavior = false;
            this.listViewInput.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderType
            // 
            this.columnHeaderType.Text = "種別";
            this.columnHeaderType.Width = 138;
            // 
            // columnHeaderPath
            // 
            this.columnHeaderPath.Text = "パス";
            this.columnHeaderPath.Width = 599;
            // 
            // buttonPriorityUp
            // 
            this.buttonPriorityUp.Location = new System.Drawing.Point(782, 53);
            this.buttonPriorityUp.Name = "buttonPriorityUp";
            this.buttonPriorityUp.Size = new System.Drawing.Size(75, 23);
            this.buttonPriorityUp.TabIndex = 3;
            this.buttonPriorityUp.Text = "▲";
            this.buttonPriorityUp.UseVisualStyleBackColor = true;
            this.buttonPriorityUp.Click += new System.EventHandler(this.buttonPriorityUp_Click);
            // 
            // buttonPriorityDown
            // 
            this.buttonPriorityDown.Location = new System.Drawing.Point(782, 82);
            this.buttonPriorityDown.Name = "buttonPriorityDown";
            this.buttonPriorityDown.Size = new System.Drawing.Size(75, 23);
            this.buttonPriorityDown.TabIndex = 4;
            this.buttonPriorityDown.Text = "▼";
            this.buttonPriorityDown.UseVisualStyleBackColor = true;
            this.buttonPriorityDown.Click += new System.EventHandler(this.buttonPriorityDown_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(782, 111);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 5;
            this.buttonAdd.Text = "追加";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDel
            // 
            this.buttonDel.Location = new System.Drawing.Point(782, 169);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(75, 23);
            this.buttonDel.TabIndex = 6;
            this.buttonDel.Text = "削除";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // buttonMakeItemDB
            // 
            this.buttonMakeItemDB.Location = new System.Drawing.Point(155, 351);
            this.buttonMakeItemDB.Name = "buttonMakeItemDB";
            this.buttonMakeItemDB.Size = new System.Drawing.Size(115, 23);
            this.buttonMakeItemDB.TabIndex = 7;
            this.buttonMakeItemDB.Text = "ItemDB出力";
            this.buttonMakeItemDB.UseVisualStyleBackColor = true;
            this.buttonMakeItemDB.Visible = false;
            // 
            // checkBox_FillDummy
            // 
            this.checkBox_FillDummy.AutoSize = true;
            this.checkBox_FillDummy.Location = new System.Drawing.Point(34, 278);
            this.checkBox_FillDummy.Name = "checkBox_FillDummy";
            this.checkBox_FillDummy.Size = new System.Drawing.Size(282, 16);
            this.checkBox_FillDummy.TabIndex = 8;
            this.checkBox_FillDummy.Text = "エラーにならないように不足箇所にダミー設定を入力する";
            this.checkBox_FillDummy.UseVisualStyleBackColor = true;
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(782, 140);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonEdit.TabIndex = 9;
            this.buttonEdit.Text = "編集";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // checkBoxSortID
            // 
            this.checkBoxSortID.AutoSize = true;
            this.checkBoxSortID.Location = new System.Drawing.Point(34, 301);
            this.checkBoxSortID.Name = "checkBoxSortID";
            this.checkBoxSortID.Size = new System.Drawing.Size(91, 16);
            this.checkBoxSortID.TabIndex = 10;
            this.checkBoxSortID.Text = "IDでソートする";
            this.checkBoxSortID.UseVisualStyleBackColor = true;
            // 
            // textBoxErrMsg
            // 
            this.textBoxErrMsg.Location = new System.Drawing.Point(34, 380);
            this.textBoxErrMsg.Multiline = true;
            this.textBoxErrMsg.Name = "textBoxErrMsg";
            this.textBoxErrMsg.ReadOnly = true;
            this.textBoxErrMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxErrMsg.Size = new System.Drawing.Size(742, 251);
            this.textBoxErrMsg.TabIndex = 11;
            // 
            // checkBoxCostume
            // 
            this.checkBoxCostume.AutoSize = true;
            this.checkBoxCostume.Location = new System.Drawing.Point(34, 324);
            this.checkBoxCostume.Name = "checkBoxCostume";
            this.checkBoxCostume.Size = new System.Drawing.Size(119, 16);
            this.checkBoxCostume.TabIndex = 12;
            this.checkBoxCostume.Text = "costumeを出力する";
            this.checkBoxCostume.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 643);
            this.Controls.Add(this.checkBoxCostume);
            this.Controls.Add(this.textBoxErrMsg);
            this.Controls.Add(this.checkBoxSortID);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.checkBox_FillDummy);
            this.Controls.Add(this.buttonMakeItemDB);
            this.Controls.Add(this.buttonDel);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonPriorityDown);
            this.Controls.Add(this.buttonPriorityUp);
            this.Controls.Add(this.listViewInput);
            this.Controls.Add(this.checkBox_2ByteID);
            this.Controls.Add(this.buttonMake);
            this.Name = "Form1";
            this.Text = "ItemInfoMaker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonMake;
        private System.Windows.Forms.CheckBox checkBox_2ByteID;
        private System.Windows.Forms.ListView listViewInput;
        private System.Windows.Forms.ColumnHeader columnHeaderType;
        private System.Windows.Forms.ColumnHeader columnHeaderPath;
        private System.Windows.Forms.Button buttonPriorityUp;
        private System.Windows.Forms.Button buttonPriorityDown;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonMakeItemDB;
        private System.Windows.Forms.CheckBox checkBox_FillDummy;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.CheckBox checkBoxSortID;
        private System.Windows.Forms.TextBox textBoxErrMsg;
        private System.Windows.Forms.CheckBox checkBoxCostume;
    }
}

