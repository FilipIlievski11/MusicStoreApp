namespace MusicStorev1
{
    partial class MusicStoreRegister
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.tryAgain = new System.Windows.Forms.Label();
            this.panelE = new System.Windows.Forms.Label();
            this.drzavi = new System.Windows.Forms.ComboBox();
            this.back = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Country = new System.Windows.Forms.TextBox();
            this.inputPW = new System.Windows.Forms.TextBox();
            this.Username = new System.Windows.Forms.TextBox();
            this.SecondName = new System.Windows.Forms.TextBox();
            this.FirstName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel1.Controls.Add(this.tryAgain);
            this.panel1.Controls.Add(this.panelE);
            this.panel1.Controls.Add(this.drzavi);
            this.panel1.Controls.Add(this.back);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.Country);
            this.panel1.Controls.Add(this.inputPW);
            this.panel1.Controls.Add(this.Username);
            this.panel1.Controls.Add(this.SecondName);
            this.panel1.Controls.Add(this.FirstName);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-2, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(680, 414);
            this.panel1.TabIndex = 0;
            // 
            // tryAgain
            // 
            this.tryAgain.AutoSize = true;
            this.tryAgain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tryAgain.ForeColor = System.Drawing.Color.Firebrick;
            this.tryAgain.Location = new System.Drawing.Point(504, 218);
            this.tryAgain.Name = "tryAgain";
            this.tryAgain.Size = new System.Drawing.Size(148, 13);
            this.tryAgain.TabIndex = 18;
            this.tryAgain.Text = "Username already exists.";
            this.tryAgain.Visible = false;
            // 
            // panelE
            // 
            this.panelE.AutoSize = true;
            this.panelE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelE.ForeColor = System.Drawing.Color.Firebrick;
            this.panelE.Location = new System.Drawing.Point(333, 138);
            this.panelE.Name = "panelE";
            this.panelE.Size = new System.Drawing.Size(132, 13);
            this.panelE.TabIndex = 17;
            this.panelE.Text = "Fill all BLANK spaces!";
            this.panelE.Visible = false;
            // 
            // drzavi
            // 
            this.drzavi.FormattingEnabled = true;
            this.drzavi.Items.AddRange(new object[] {
            "Macedonia",
            "Greece",
            "Albania",
            "Serbia",
            "Croatia",
            "United States",
            "United Kingdom",
            "Bulgaria",
            "France",
            "Germany",
            "Russia",
            "Denmark",
            "Spain",
            "Sweden",
            "Others"});
            this.drzavi.Location = new System.Drawing.Point(300, 278);
            this.drzavi.Name = "drzavi";
            this.drzavi.Size = new System.Drawing.Size(198, 21);
            this.drzavi.TabIndex = 16;
            // 
            // back
            // 
            this.back.BackColor = System.Drawing.SystemColors.Highlight;
            this.back.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back.Location = new System.Drawing.Point(171, 312);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(101, 32);
            this.back.TabIndex = 15;
            this.back.Text = "Back";
            this.back.UseVisualStyleBackColor = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(395, 312);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 32);
            this.button1.TabIndex = 14;
            this.button1.Text = "Register";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Country
            // 
            this.Country.Location = new System.Drawing.Point(300, 277);
            this.Country.Name = "Country";
            this.Country.Size = new System.Drawing.Size(198, 20);
            this.Country.TabIndex = 13;
            // 
            // inputPW
            // 
            this.inputPW.Location = new System.Drawing.Point(300, 245);
            this.inputPW.Name = "inputPW";
            this.inputPW.Size = new System.Drawing.Size(198, 20);
            this.inputPW.TabIndex = 12;
            this.inputPW.TextChanged += new System.EventHandler(this.inputPW_TextChanged);
            // 
            // Username
            // 
            this.Username.Location = new System.Drawing.Point(300, 215);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(198, 20);
            this.Username.TabIndex = 11;
            // 
            // SecondName
            // 
            this.SecondName.Location = new System.Drawing.Point(300, 184);
            this.SecondName.Name = "SecondName";
            this.SecondName.Size = new System.Drawing.Size(198, 20);
            this.SecondName.TabIndex = 10;
            // 
            // FirstName
            // 
            this.FirstName.Location = new System.Drawing.Point(300, 154);
            this.FirstName.Name = "FirstName";
            this.FirstName.Size = new System.Drawing.Size(198, 20);
            this.FirstName.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(168, 278);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 17);
            this.label7.TabIndex = 8;
            this.label7.Text = "Country:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(168, 246);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "Password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(168, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Username:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(168, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Second Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(168, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "First Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Mistral", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(261, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "buy your favourite songs";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(221, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 49);
            this.label1.TabIndex = 0;
            this.label1.Text = "MusicStore";
            // 
            // MusicStoreRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(675, 406);
            this.Controls.Add(this.panel1);
            this.Name = "MusicStoreRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MusicStore";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Country;
        private System.Windows.Forms.TextBox inputPW;
        private System.Windows.Forms.TextBox Username;
        private System.Windows.Forms.TextBox SecondName;
        private System.Windows.Forms.TextBox FirstName;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox drzavi;
        private System.Windows.Forms.Label panelE;
        private System.Windows.Forms.Label tryAgain;
    }
}