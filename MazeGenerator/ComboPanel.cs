using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using MazeGenerator.Networks;

namespace MazeGenerator
{
    using FormDictionary = Dictionary<string, object>;

    public class ComboPanel : Panel
    {
        private FormDictionary dictionary = new FormDictionary();
        private ComboBox comboBox;
        private object selectedObj = null;
    
        public object SelectedItem
        {
            get
            {
                return selectedObj;
            }
        }

        public ComboPanel()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBox
            // 
            this.comboBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(4, 4);
            this.comboBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 3);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(192, 21);
            this.comboBox.TabIndex = 0;
            this.comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // ComboPanel
            // 
            this.Controls.Add(this.comboBox);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Resize += new System.EventHandler(this.ComboPanel_Resize);
            this.ResumeLayout(false);

        }

        private void ComboPanel_Resize(object sender, EventArgs e)
        {
            // THis can be automated, by inserting forms in a predefined panel. and making the forms dock state to fill. (or something)
            foreach (KeyValuePair<string, object> item in dictionary)
            {
                if (item.Value is Form)
                {
                    Form form = (Form)item.Value;
                    form.Size = new System.Drawing.Size(this.Size.Width - 3, this.Size.Height - 9 - comboBox.Size.Height);
                }
            }
        }

        public bool AddComboItem(string str, object obj)
        {
            if (dictionary.ContainsKey(str) == false) // Check for duplicates
            {
                dictionary.Add(str, obj);
                comboBox.Items.Add(str);

                if (obj is Form)
                {
                    Form form = (Form)obj;

                    form.CreateControl();
                    form.TopLevel = false;
                    form.Parent = this;
                    form.Dock = DockStyle.None;// | DockStyle.Right | DockStyle.Bottom;
                    form.FormBorderStyle = FormBorderStyle.None;
                    form.Location = new System.Drawing.Point(0, 8 + comboBox.Size.Height);
                    form.Size = new System.Drawing.Size(this.Size.Width - 3, this.Size.Height - 9 - comboBox.Size.Height);

                    this.Controls.Add(form);                    
                }

                if (selectedObj == null)
                {
                    comboBox.SelectedIndex = 0;
                    selectedObj = obj;
                    if (obj is Form)
                    {
                        ((Form)selectedObj).Show();
                    }
                }


                return true;
            }

            return false;
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            //string networkType = (string)comboBox.SelectedItem;
            if (selectedObj is Form)
            {
                ((Form)selectedObj).Hide();
            }

            if (dictionary.TryGetValue((string)comboBox.SelectedItem, out selectedObj))
            {
                if (selectedObj is Form)
                {
                    ((Form)selectedObj).Show();
                }
            }  

        }
    }
}