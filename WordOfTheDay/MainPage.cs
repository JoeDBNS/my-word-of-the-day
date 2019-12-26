using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordOfTheDay
{
    public partial class MainPage : Form
    {
        private Button btnGenerate;
        private GroupBox gboxWord;
        private Label lblWord;
        private Button btnCopy;

        public MainPage()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.btnGenerate = new System.Windows.Forms.Button();
            this.gboxWord = new System.Windows.Forms.GroupBox();
            this.picLoad = new System.Windows.Forms.PictureBox();
            this.lblWord = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.lblProun = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblDesc1 = new System.Windows.Forms.Label();
            this.lblDesc2 = new System.Windows.Forms.Label();
            this.gboxWord.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoad)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(12, 17);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(81, 30);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // gboxWord
            // 
            this.gboxWord.Controls.Add(this.picLoad);
            this.gboxWord.Controls.Add(this.lblDesc2);
            this.gboxWord.Controls.Add(this.lblDesc1);
            this.gboxWord.Controls.Add(this.lblType);
            this.gboxWord.Controls.Add(this.lblProun);
            this.gboxWord.Controls.Add(this.lblWord);
            this.gboxWord.Location = new System.Drawing.Point(12, 60);
            this.gboxWord.Name = "gboxWord";
            this.gboxWord.Size = new System.Drawing.Size(368, 278);
            this.gboxWord.TabIndex = 2;
            this.gboxWord.TabStop = false;
            // 
            // picLoad
            // 
            this.picLoad.Image = ((System.Drawing.Image)(resources.GetObject("picLoad.Image")));
            this.picLoad.Location = new System.Drawing.Point(6, 14);
            this.picLoad.Name = "picLoad";
            this.picLoad.Size = new System.Drawing.Size(355, 258);
            this.picLoad.TabIndex = 1;
            this.picLoad.TabStop = false;
            // 
            // lblWord
            // 
            this.lblWord.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWord.Location = new System.Drawing.Point(3, 16);
            this.lblWord.Name = "lblWord";
            this.lblWord.Size = new System.Drawing.Size(362, 34);
            this.lblWord.TabIndex = 0;
            this.lblWord.Text = "WordGoesHere";
            this.lblWord.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnCopy
            // 
            this.btnCopy.Enabled = false;
            this.btnCopy.Location = new System.Drawing.Point(299, 17);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(81, 30);
            this.btnCopy.TabIndex = 3;
            this.btnCopy.Text = "&Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            // 
            // lblProun
            // 
            this.lblProun.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProun.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProun.Location = new System.Drawing.Point(3, 50);
            this.lblProun.Name = "lblProun";
            this.lblProun.Size = new System.Drawing.Size(362, 27);
            this.lblProun.TabIndex = 0;
            this.lblProun.Text = "PronounceGoesHere";
            this.lblProun.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblType
            // 
            this.lblType.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(3, 77);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(362, 34);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "TypeGoesHere";
            this.lblType.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDesc1
            // 
            this.lblDesc1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDesc1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc1.Location = new System.Drawing.Point(3, 111);
            this.lblDesc1.Name = "lblDesc1";
            this.lblDesc1.Size = new System.Drawing.Size(362, 85);
            this.lblDesc1.TabIndex = 0;
            this.lblDesc1.Text = "Description1";
            this.lblDesc1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDesc2
            // 
            this.lblDesc2.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDesc2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc2.Location = new System.Drawing.Point(3, 196);
            this.lblDesc2.Name = "lblDesc2";
            this.lblDesc2.Size = new System.Drawing.Size(362, 79);
            this.lblDesc2.TabIndex = 0;
            this.lblDesc2.Text = "Description2";
            this.lblDesc2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MainPage
            // 
            this.AcceptButton = this.btnGenerate;
            this.ClientSize = new System.Drawing.Size(394, 351);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.gboxWord);
            this.Controls.Add(this.btnGenerate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainPage";
            this.Text = "Word Of The Day";
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.gboxWord.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLoad)).EndInit();
            this.ResumeLayout(false);

        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            LoadWord();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            LoadWord();
        }

        private void LoadWord()
        {
            picLoad.Show();
            picLoad.Update();
            var newWord = GenerateWordInfo.GetWord();
            lblWord.Text = newWord.Item1;
            lblProun.Text = newWord.Item2;
            lblType.Text = newWord.Item3;
            lblDesc1.Text = newWord.Item4;
            lblDesc2.Text = newWord.Item5;
            picLoad.Hide();
            picLoad.Update();
            btnCopy.Enabled = true;
        }
    }
}
