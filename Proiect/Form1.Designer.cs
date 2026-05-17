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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.buttonBuyDualMonitor = new System.Windows.Forms.Button();
            this.buttonBuyAutomatedPipeline = new System.Windows.Forms.Button();
            this.buttonBuyEspressoMachine = new System.Windows.Forms.Button();
            this.buttonHireIntern = new System.Windows.Forms.Button();
            this.buttonHireArchi = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelLinesOfCode
            // 
            this.labelLinesOfCode.AutoSize = true;
            this.labelLinesOfCode.Cursor = System.Windows.Forms.Cursors.Help;
            this.labelLinesOfCode.Font = new System.Drawing.Font("Consolas", 11.78182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelLinesOfCode.Location = new System.Drawing.Point(273, 106);
            this.labelLinesOfCode.Name = "labelLinesOfCode";
            this.labelLinesOfCode.Size = new System.Drawing.Size(170, 22);
            this.labelLinesOfCode.TabIndex = 0;
            this.labelLinesOfCode.Text = "Lines of Code: 0";
            this.labelLinesOfCode.Click += new System.EventHandler(this.labelLinesOfCode_Click);
            // 
            // buttonWriteCode
            // 
            this.buttonWriteCode.BackColor = System.Drawing.Color.Green;
            this.buttonWriteCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonWriteCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonWriteCode.Font = new System.Drawing.Font("Consolas", 13.74545F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonWriteCode.Location = new System.Drawing.Point(59, 106);
            this.buttonWriteCode.Name = "buttonWriteCode";
            this.buttonWriteCode.Size = new System.Drawing.Size(183, 88);
            this.buttonWriteCode.TabIndex = 1;
            this.buttonWriteCode.Text = "Write Code";
            this.buttonWriteCode.UseVisualStyleBackColor = false;
            this.buttonWriteCode.Click += new System.EventHandler(this.buttonWriteCode_Click);
            // 
            // buttonHireJunior
            // 
            this.buttonHireJunior.BackColor = System.Drawing.Color.Transparent;
            this.buttonHireJunior.Font = new System.Drawing.Font("Consolas", 11.12727F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonHireJunior.Location = new System.Drawing.Point(492, 372);
            this.buttonHireJunior.Name = "buttonHireJunior";
            this.buttonHireJunior.Size = new System.Drawing.Size(252, 62);
            this.buttonHireJunior.TabIndex = 2;
            this.buttonHireJunior.Text = "Hire Junior Dev (Cost: 50)";
            this.buttonHireJunior.UseVisualStyleBackColor = false;
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
            this.buttonHireSenior.BackColor = System.Drawing.Color.Transparent;
            this.buttonHireSenior.Font = new System.Drawing.Font("Consolas", 11.12727F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonHireSenior.Location = new System.Drawing.Point(492, 458);
            this.buttonHireSenior.Name = "buttonHireSenior";
            this.buttonHireSenior.Size = new System.Drawing.Size(252, 62);
            this.buttonHireSenior.TabIndex = 3;
            this.buttonHireSenior.Text = "Hire Senior Dev (Cost: 500)";
            this.buttonHireSenior.UseVisualStyleBackColor = false;
            this.buttonHireSenior.Click += new System.EventHandler(this.buttonHireSenior_Click);
            // 
            // animationTimer
            // 
            this.animationTimer.Enabled = true;
            this.animationTimer.Tick += new System.EventHandler(this.animationTimer_Tick);
            // 
            // buttonBuyKeyboard
            // 
            this.buttonBuyKeyboard.BackColor = System.Drawing.Color.Transparent;
            this.buttonBuyKeyboard.Font = new System.Drawing.Font("Consolas", 11.12727F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonBuyKeyboard.Location = new System.Drawing.Point(71, 286);
            this.buttonBuyKeyboard.Name = "buttonBuyKeyboard";
            this.buttonBuyKeyboard.Size = new System.Drawing.Size(310, 62);
            this.buttonBuyKeyboard.TabIndex = 4;
            this.buttonBuyKeyboard.Text = "Buy Mechanical Keyboard\r\n(Cost: 250)";
            this.buttonBuyKeyboard.UseVisualStyleBackColor = false;
            this.buttonBuyKeyboard.Click += new System.EventHandler(this.buttonBuyKeyboard_Click);
            // 
            // labelPermanent
            // 
            this.labelPermanent.AutoSize = true;
            this.labelPermanent.Font = new System.Drawing.Font("Consolas", 15.70909F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPermanent.Location = new System.Drawing.Point(112, 239);
            this.labelPermanent.Name = "labelPermanent";
            this.labelPermanent.Size = new System.Drawing.Size(246, 28);
            this.labelPermanent.TabIndex = 5;
            this.labelPermanent.Text = "Permanent Upgrades";
            // 
            // labelTeam
            // 
            this.labelTeam.AutoSize = true;
            this.labelTeam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(13)))), ((int)(((byte)(6)))));
            this.labelTeam.Font = new System.Drawing.Font("Consolas", 15.70909F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTeam.Location = new System.Drawing.Point(533, 243);
            this.labelTeam.Name = "labelTeam";
            this.labelTeam.Size = new System.Drawing.Size(181, 28);
            this.labelTeam.TabIndex = 6;
            this.labelTeam.Text = "Team Upgrades";
            // 
            // buttonReleaseVersion
            // 
            this.buttonReleaseVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(191)))), ((int)(((byte)(63)))));
            this.buttonReleaseVersion.Font = new System.Drawing.Font("Consolas", 11.78182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonReleaseVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(13)))), ((int)(((byte)(6)))));
            this.buttonReleaseVersion.Location = new System.Drawing.Point(12, 44);
            this.buttonReleaseVersion.Name = "buttonReleaseVersion";
            this.buttonReleaseVersion.Size = new System.Drawing.Size(776, 32);
            this.buttonReleaseVersion.TabIndex = 7;
            this.buttonReleaseVersion.Text = "Release Version";
            this.buttonReleaseVersion.UseVisualStyleBackColor = false;
            this.buttonReleaseVersion.Click += new System.EventHandler(this.buttonReleaseVersion_Click);
            // 
            // buttonBug
            // 
            this.buttonBug.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(44)))));
            this.buttonBug.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonBug.BackgroundImage")));
            this.buttonBug.Cursor = System.Windows.Forms.Cursors.Cross;
            this.buttonBug.Font = new System.Drawing.Font("Courier New", 15.70909F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonBug.ForeColor = System.Drawing.Color.White;
            this.buttonBug.Location = new System.Drawing.Point(492, 106);
            this.buttonBug.Name = "buttonBug";
            this.buttonBug.Size = new System.Drawing.Size(267, 116);
            this.buttonBug.TabIndex = 8;
            this.buttonBug.Text = "BUG";
            this.buttonBug.UseVisualStyleBackColor = false;
            this.buttonBug.Visible = false;
            this.buttonBug.Click += new System.EventHandler(this.buttonBug_Click);
            // 
            // buttonBuyDualMonitor
            // 
            this.buttonBuyDualMonitor.BackColor = System.Drawing.Color.Transparent;
            this.buttonBuyDualMonitor.Font = new System.Drawing.Font("Consolas", 11.12727F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonBuyDualMonitor.Location = new System.Drawing.Point(71, 372);
            this.buttonBuyDualMonitor.Name = "buttonBuyDualMonitor";
            this.buttonBuyDualMonitor.Size = new System.Drawing.Size(310, 62);
            this.buttonBuyDualMonitor.TabIndex = 11;
            this.buttonBuyDualMonitor.Text = "Buy Dual Monitor\r\n(Cost: 500)";
            this.buttonBuyDualMonitor.UseVisualStyleBackColor = false;
            this.buttonBuyDualMonitor.Click += new System.EventHandler(this.buttonBuyDualMonitor_Click);
            // 
            // buttonBuyAutomatedPipeline
            // 
            this.buttonBuyAutomatedPipeline.BackColor = System.Drawing.Color.Transparent;
            this.buttonBuyAutomatedPipeline.Font = new System.Drawing.Font("Consolas", 11.12727F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonBuyAutomatedPipeline.Location = new System.Drawing.Point(71, 457);
            this.buttonBuyAutomatedPipeline.Name = "buttonBuyAutomatedPipeline";
            this.buttonBuyAutomatedPipeline.Size = new System.Drawing.Size(310, 62);
            this.buttonBuyAutomatedPipeline.TabIndex = 12;
            this.buttonBuyAutomatedPipeline.Text = "Buy Automated CI/CD Pipeline\r\n(Cost: 700)";
            this.buttonBuyAutomatedPipeline.UseVisualStyleBackColor = false;
            this.buttonBuyAutomatedPipeline.Click += new System.EventHandler(this.buttonBuyAutomatedPipeline_Click);
            // 
            // buttonBuyEspressoMachine
            // 
            this.buttonBuyEspressoMachine.BackColor = System.Drawing.Color.Transparent;
            this.buttonBuyEspressoMachine.Font = new System.Drawing.Font("Consolas", 11.12727F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonBuyEspressoMachine.Location = new System.Drawing.Point(71, 545);
            this.buttonBuyEspressoMachine.Name = "buttonBuyEspressoMachine";
            this.buttonBuyEspressoMachine.Size = new System.Drawing.Size(310, 62);
            this.buttonBuyEspressoMachine.TabIndex = 13;
            this.buttonBuyEspressoMachine.Text = "Buy Espresso Machine\r\n(Cost: 1000)";
            this.buttonBuyEspressoMachine.UseVisualStyleBackColor = false;
            this.buttonBuyEspressoMachine.Click += new System.EventHandler(this.buttonBuyEspressoMachine_Click);
            // 
            // buttonHireIntern
            // 
            this.buttonHireIntern.BackColor = System.Drawing.Color.Transparent;
            this.buttonHireIntern.Font = new System.Drawing.Font("Consolas", 11.12727F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonHireIntern.Location = new System.Drawing.Point(492, 286);
            this.buttonHireIntern.Name = "buttonHireIntern";
            this.buttonHireIntern.Size = new System.Drawing.Size(252, 62);
            this.buttonHireIntern.TabIndex = 14;
            this.buttonHireIntern.Text = "Hire intern (Cost: 15)";
            this.buttonHireIntern.UseVisualStyleBackColor = false;
            this.buttonHireIntern.Click += new System.EventHandler(this.buttonHireIntern_Click);
            // 
            // buttonHireArchi
            // 
            this.buttonHireArchi.BackColor = System.Drawing.Color.Transparent;
            this.buttonHireArchi.Font = new System.Drawing.Font("Consolas", 11.12727F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonHireArchi.Location = new System.Drawing.Point(492, 545);
            this.buttonHireArchi.Name = "buttonHireArchi";
            this.buttonHireArchi.Size = new System.Drawing.Size(252, 62);
            this.buttonHireArchi.TabIndex = 15;
            this.buttonHireArchi.Text = "Hire System Architect (Cost: 500)";
            this.buttonHireArchi.UseVisualStyleBackColor = false;
            this.buttonHireArchi.Click += new System.EventHandler(this.buttonHireArchi_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Courier New", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(798, 25);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.saveGameToolStripMenuItem,
            this.loadGameToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(224, 6);
            // 
            // saveGameToolStripMenuItem
            // 
            this.saveGameToolStripMenuItem.Name = "saveGameToolStripMenuItem";
            this.saveGameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveGameToolStripMenuItem.Size = new System.Drawing.Size(227, 24);
            this.saveGameToolStripMenuItem.Text = "Save Game";
            this.saveGameToolStripMenuItem.Click += new System.EventHandler(this.saveGameToolStripMenuItem_Click);
            // 
            // loadGameToolStripMenuItem
            // 
            this.loadGameToolStripMenuItem.Name = "loadGameToolStripMenuItem";
            this.loadGameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.loadGameToolStripMenuItem.Size = new System.Drawing.Size(227, 24);
            this.loadGameToolStripMenuItem.Text = "Load Game";
            this.loadGameToolStripMenuItem.Click += new System.EventHandler(this.loadGameToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getHelpToolStripMenuItem,
            this.adminModeToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // getHelpToolStripMenuItem
            // 
            this.getHelpToolStripMenuItem.Name = "getHelpToolStripMenuItem";
            this.getHelpToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.getHelpToolStripMenuItem.Size = new System.Drawing.Size(290, 24);
            this.getHelpToolStripMenuItem.Text = "Get Help";
            this.getHelpToolStripMenuItem.Click += new System.EventHandler(this.getHelpToolStripMenuItem_Click);
            // 
            // adminModeToolStripMenuItem
            // 
            this.adminModeToolStripMenuItem.Name = "adminModeToolStripMenuItem";
            this.adminModeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.M)));
            this.adminModeToolStripMenuItem.Size = new System.Drawing.Size(290, 24);
            this.adminModeToolStripMenuItem.Text = "Admin Mode";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(13)))), ((int)(((byte)(6)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(798, 635);
            this.Controls.Add(this.buttonHireArchi);
            this.Controls.Add(this.buttonHireIntern);
            this.Controls.Add(this.buttonBuyEspressoMachine);
            this.Controls.Add(this.buttonBuyAutomatedPipeline);
            this.Controls.Add(this.buttonBuyDualMonitor);
            this.Controls.Add(this.buttonBug);
            this.Controls.Add(this.buttonReleaseVersion);
            this.Controls.Add(this.labelTeam);
            this.Controls.Add(this.labelPermanent);
            this.Controls.Add(this.buttonBuyKeyboard);
            this.Controls.Add(this.buttonHireSenior);
            this.Controls.Add(this.buttonHireJunior);
            this.Controls.Add(this.buttonWriteCode);
            this.Controls.Add(this.labelLinesOfCode);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Consolas", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(191)))), ((int)(((byte)(63)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Code Clicker";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.Button buttonBuyDualMonitor;
        private System.Windows.Forms.Button buttonBuyAutomatedPipeline;
        private System.Windows.Forms.Button buttonBuyEspressoMachine;
        private System.Windows.Forms.Button buttonHireIntern;
        private System.Windows.Forms.Button buttonHireArchi;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getHelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminModeToolStripMenuItem;
    }
}

