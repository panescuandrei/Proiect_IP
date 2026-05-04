namespace Proiect
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.labelLinesOfCode = new System.Windows.Forms.Label();
            this.buttonWriteCode = new System.Windows.Forms.Button();
            this.buttonHireJunior = new System.Windows.Forms.Button();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.buttonHireSenior = new System.Windows.Forms.Button();
            this.animationTimer = new System.Windows.Forms.Timer(this.components);
            this.buttonBuyKeyboard = new System.Windows.Forms.Button();
            this.labelPermanent = new System.Windows.Forms.Label();
            this.labelTeam = new System.Windows.Forms.Label();
            this.buttonReleaseVersion = new System.Windows.Forms.Button();
            this.buttonBug = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelLinesOfCode
            // 
            this.labelLinesOfCode.AutoSize = true;
            this.labelLinesOfCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLinesOfCode.Location = new System.Drawing.Point(39, 218);
            this.labelLinesOfCode.Name = "labelLinesOfCode";
            this.labelLinesOfCode.Size = new System.Drawing.Size(124, 20);
            this.labelLinesOfCode.TabIndex = 0;
            this.labelLinesOfCode.Text = "Lines of Code: 0";
            this.labelLinesOfCode.Click += new System.EventHandler(this.labelLinesOfCode_Click);
            // 
            // buttonWriteCode
            // 
            this.buttonWriteCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonWriteCode.Location = new System.Drawing.Point(22, 181);
            this.buttonWriteCode.Name = "buttonWriteCode";
            this.buttonWriteCode.Size = new System.Drawing.Size(158, 34);
            this.buttonWriteCode.TabIndex = 1;
            this.buttonWriteCode.Text = "Write Code";
            this.buttonWriteCode.UseVisualStyleBackColor = true;
            this.buttonWriteCode.Click += new System.EventHandler(this.buttonWriteCode_Click);
            // 
            // buttonHireJunior
            // 
            this.buttonHireJunior.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHireJunior.Location = new System.Drawing.Point(507, 117);
            this.buttonHireJunior.Name = "buttonHireJunior";
            this.buttonHireJunior.Size = new System.Drawing.Size(273, 34);
            this.buttonHireJunior.TabIndex = 2;
            this.buttonHireJunior.Text = "Hire Junior Dev (Cost: 50)";
            this.buttonHireJunior.UseVisualStyleBackColor = true;
            this.buttonHireJunior.Click += new System.EventHandler(this.buttonHireJunior_Click);
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 1000;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // buttonHireSenior
            // 
            this.buttonHireSenior.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHireSenior.Location = new System.Drawing.Point(507, 167);
            this.buttonHireSenior.Name = "buttonHireSenior";
            this.buttonHireSenior.Size = new System.Drawing.Size(273, 34);
            this.buttonHireSenior.TabIndex = 3;
            this.buttonHireSenior.Text = "Hire Senior Dev (Cost: 500)";
            this.buttonHireSenior.UseVisualStyleBackColor = true;
            this.buttonHireSenior.Click += new System.EventHandler(this.buttonHireSenior_Click);
            // 
            // animationTimer
            // 
            this.animationTimer.Enabled = true;
            this.animationTimer.Tick += new System.EventHandler(this.animationTimer_Tick);
            // 
            // buttonBuyKeyboard
            // 
            this.buttonBuyKeyboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBuyKeyboard.Location = new System.Drawing.Point(257, 117);
            this.buttonBuyKeyboard.Name = "buttonBuyKeyboard";
            this.buttonBuyKeyboard.Size = new System.Drawing.Size(233, 48);
            this.buttonBuyKeyboard.TabIndex = 4;
            this.buttonBuyKeyboard.Text = "Buy Mechanical Keyboard \r\n(Cost: 250)";
            this.buttonBuyKeyboard.UseVisualStyleBackColor = true;
            this.buttonBuyKeyboard.Click += new System.EventHandler(this.buttonBuyKeyboard_Click);
            // 
            // labelPermanent
            // 
            this.labelPermanent.AutoSize = true;
            this.labelPermanent.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPermanent.Location = new System.Drawing.Point(278, 80);
            this.labelPermanent.Name = "labelPermanent";
            this.labelPermanent.Size = new System.Drawing.Size(189, 24);
            this.labelPermanent.TabIndex = 5;
            this.labelPermanent.Text = "Permanent Upgrades";
            // 
            // labelTeam
            // 
            this.labelTeam.AutoSize = true;
            this.labelTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTeam.Location = new System.Drawing.Point(574, 80);
            this.labelTeam.Name = "labelTeam";
            this.labelTeam.Size = new System.Drawing.Size(146, 24);
            this.labelTeam.TabIndex = 6;
            this.labelTeam.Text = "Team Upgrades";
            // 
            // buttonReleaseVersion
            // 
            this.buttonReleaseVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReleaseVersion.Location = new System.Drawing.Point(12, 12);
            this.buttonReleaseVersion.Name = "buttonReleaseVersion";
            this.buttonReleaseVersion.Size = new System.Drawing.Size(776, 32);
            this.buttonReleaseVersion.TabIndex = 7;
            this.buttonReleaseVersion.Text = "Release Version";
            this.buttonReleaseVersion.UseVisualStyleBackColor = true;
            this.buttonReleaseVersion.Click += new System.EventHandler(this.buttonReleaseVersion_Click);
            // 
            // buttonBug
            // 
            this.buttonBug.BackColor = System.Drawing.Color.Red;
            this.buttonBug.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBug.ForeColor = System.Drawing.Color.White;
            this.buttonBug.Location = new System.Drawing.Point(186, 157);
            this.buttonBug.Name = "buttonBug";
            this.buttonBug.Size = new System.Drawing.Size(358, 120);
            this.buttonBug.TabIndex = 8;
            this.buttonBug.Text = "BUG";
            this.buttonBug.UseVisualStyleBackColor = false;
            this.buttonBug.Visible = false;
            this.buttonBug.Click += new System.EventHandler(this.buttonBug_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonBug);
            this.Controls.Add(this.buttonReleaseVersion);
            this.Controls.Add(this.labelTeam);
            this.Controls.Add(this.labelPermanent);
            this.Controls.Add(this.buttonBuyKeyboard);
            this.Controls.Add(this.buttonHireSenior);
            this.Controls.Add(this.buttonHireJunior);
            this.Controls.Add(this.buttonWriteCode);
            this.Controls.Add(this.labelLinesOfCode);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLinesOfCode;
        private System.Windows.Forms.Button buttonWriteCode;
        private System.Windows.Forms.Button buttonHireJunior;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Button buttonHireSenior;
        private System.Windows.Forms.Timer animationTimer;
        private System.Windows.Forms.Button buttonBuyKeyboard;
        private System.Windows.Forms.Label labelPermanent;
        private System.Windows.Forms.Label labelTeam;
        private System.Windows.Forms.Button buttonReleaseVersion;
        private System.Windows.Forms.Button buttonBug;
    }
}

