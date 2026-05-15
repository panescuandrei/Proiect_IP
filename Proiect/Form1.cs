using DevTycoon.Engine;
using DevTycoon.Patterns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Proiect
{
    public partial class Form1 : Form
    {
        private GameManager _manager;
        private List<Label> _floatingTexts = new List<Label>();
        private Random _random = new Random();
        private readonly string _saveFilePath = Path.Combine(
    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
    "CodeClicker",
    "savegame.json");

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;

            _manager = new GameManager();

           // LoadGame();
            UpdateUI();

            this.FormClosing += Form1_FormClosing;
        }

        private void UpdateUI()
        {
            double currentCps = _manager.GetTotalCPS();

            labelLinesOfCode.Text = $"Lines of Code: {_manager.LinesOfCode.ToString("F1")}\nTeam Size: {_manager.Team.Count}\nCode Per Second: {currentCps.ToString("F1")}";


            double juniorCost = _manager.GetNextCost("junior");
            if(_manager.TotalLinesOfCode < 40)
            {
                labelTeam.Visible = false;
                buttonHireJunior.Visible = false;

                labelPermanent.Visible = false;
                buttonBuyKeyboard.Visible = false;
            }
            else
            {
                buttonHireJunior.Visible = true;
                labelTeam.Visible = true;

                labelPermanent.Visible = true;
                buttonBuyKeyboard.Visible = true;
            }

            if (_manager.TotalLinesOfCode < 100)
                buttonHireSenior.Visible = false;
            else
                buttonHireSenior.Visible = true;

                buttonHireJunior.Text = $"Hire Junior Dev (Cost: {Math.Ceiling(juniorCost)})";
            UpdateButtonVisuals(buttonHireJunior, juniorCost);

            double seniorCost = _manager.GetNextCost("senior");
            buttonHireSenior.Text = $"Hire Senior Dev (Cost: {Math.Ceiling(seniorCost)})";
            UpdateButtonVisuals(buttonHireSenior, seniorCost);

            if (_manager.HasMechanicalKeyboard)
            {
                buttonBuyKeyboard.Text = "Mechanical Keyboard (Owned)";
                buttonBuyKeyboard.BackColor = Color.LightGreen;
                buttonBuyKeyboard.ForeColor = Color.Black;
                buttonBuyKeyboard.Enabled = false;
            }
            else
            {
                buttonBuyKeyboard.Text = "Buy Mechanical Keyboard (Cost: 250)";
                UpdateButtonVisuals(buttonBuyKeyboard, 250);
            }

            buttonReleaseVersion.Text = $"Release v{_manager.CurrentVersion + 1}.0 (Cost: {_manager.NextVersionCost})";
            UpdateButtonVisuals(buttonReleaseVersion, _manager.NextVersionCost);


            if (_manager.IsBugActive)
            {
                if (buttonBug.Visible == false)
                {
                    int maxX = this.ClientSize.Width - buttonBug.Width;
                    int maxY = this.ClientSize.Height - buttonBug.Height;

                    buttonBug.Left = _random.Next(0, Math.Max(1, maxX));
                    buttonBug.Top = _random.Next(0, Math.Max(1, maxY));
                }

                buttonBug.Visible = true;
                buttonBug.BringToFront();
                buttonBug.Text = $"CRITICAL BUG!\nClick {Math.Max(0, _manager.BugClicksRemaining)} times to fix!";

                buttonWriteCode.Enabled = false;
            }
            else
            {
                buttonBug.Visible = false;
                buttonWriteCode.Enabled = true;
            }
        }

        private void UpdateButtonVisuals(Button btn, double cost)
        {
            if (_manager.LinesOfCode >= cost)
            {
                btn.BackColor = SystemColors.Control;
                btn.ForeColor = SystemColors.ControlText;
            }
            else
            {
                btn.BackColor = Color.LightGray;
                btn.ForeColor = Color.DimGray;
            }
        }

        private void buttonWriteCode_Click(object sender, EventArgs e)
        {
            _manager.WriteCode();
            UpdateUI();

            if (_manager.HasMechanicalKeyboard)
            {
                SpawnFloatingText("+2");
            }
            else
            {
                SpawnFloatingText("+1");
            }
        }

        private void buttonHireJunior_Click(object sender, EventArgs e)
        {
            try
            {
                _manager.BuyEmployee("junior");
                UpdateUI();
            }
            catch (NotEnoughCodeException ex)
            {
                MessageBox.Show(ex.Message, "Not Enough Code!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonHireSenior_Click(object sender, EventArgs e)
        {
            try
            {
                _manager.BuyEmployee("senior");
                UpdateUI();
            }
            catch (NotEnoughCodeException ex)
            {
                MessageBox.Show(ex.Message, "Not Enough Code!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (!_manager.IsBugActive && _random.Next(0, 100) < 5)
            {
                _manager.TriggerBug();
            }

            _manager.GeneratePassiveCode();
            UpdateUI();
        }

        private void SpawnFloatingText(string text)
        {
            Label floatLabel = new Label();
            floatLabel.Text = text;
            floatLabel.ForeColor = Color.Green;
            floatLabel.Font = new Font("Consolas", 14, FontStyle.Bold);
            floatLabel.AutoSize = true;
            floatLabel.BackColor = Color.Transparent;

            floatLabel.Top = buttonWriteCode.Top - 30 + _random.Next(-10, 10);


            floatLabel.Left = buttonWriteCode.Left + _random.Next(0, buttonWriteCode.Width);

            this.Controls.Add(floatLabel);
            floatLabel.BringToFront();
            _floatingTexts.Add(floatLabel);
        }

        private void animationTimer_Tick(object sender, EventArgs e)
        {

            for (int i = _floatingTexts.Count - 1; i >= 0; i--)
            {
                Label lbl = _floatingTexts[i];
                lbl.Top -= 3;


                if (lbl.Top < buttonWriteCode.Top - 50)
                {
                    this.Controls.Remove(lbl);
                    _floatingTexts.RemoveAt(i);
                    lbl.Dispose();
                }
            }
        }

        private void labelLinesOfCode_Click(object sender, EventArgs e)
        {

            if (_manager.Team.Count == 0)
            {
                MessageBox.Show("You haven't hired anyone yet! Start clicking!", "Team Roster", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            int juniors = 0;
            int seniors = 0;


            foreach (IEmployee employee in _manager.Team)
            {
                if (employee.Name == "Junior Developer")
                {
                    juniors++;
                }
                else if (employee.Name == "Senior Developer")
                {
                    seniors++;
                }
            }


            string rosterMessage = "Current Dev Team:\n\n";
            rosterMessage += $"- Junior Developers: {juniors}\n";
            rosterMessage += $"- Senior Developers: {seniors}";


            MessageBox.Show(rosterMessage, "Team Roster", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonBuyKeyboard_Click(object sender, EventArgs e)
        {
            var upgrade = _manager.Upgrades
                .FirstOrDefault(u => u.Name == "Mechanical Keyboard");
            try
            {
                upgrade?.Purchase(_manager);
                UpdateUI();
            }
            catch (NotEnoughCodeException ex)
            {
                MessageBox.Show(ex.Message, "Not Enough Code!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonReleaseVersion_Click(object sender, EventArgs e)
        {
            try
            {
                _manager.ReleaseVersion();
                UpdateUI();
                MessageBox.Show($"Congratulations! You successfully released Version {_manager.CurrentVersion}.0!", "Launch Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (NotEnoughCodeException ex)
            {
                MessageBox.Show(ex.Message, "Not Ready For Release!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonBug_Click(object sender, EventArgs e)
        {
            _manager.SquashBug();
            UpdateUI();
        }

        private void SaveGame()
        {
            string folder = Path.GetDirectoryName(_saveFilePath);

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            using (FileStream stream = new FileStream(_saveFilePath, FileMode.Create))
            {
                DataContractJsonSerializer serializer =
                    new DataContractJsonSerializer(typeof(GameSaveData));

                serializer.WriteObject(stream, _manager.CreateSaveData());
            }
        }

        private void LoadGame()
        {
            if (!File.Exists(_saveFilePath))
            {
                return;
            }

            using (FileStream stream = new FileStream(_saveFilePath, FileMode.Open))
            {
                DataContractJsonSerializer serializer =
                    new DataContractJsonSerializer(typeof(GameSaveData));

                GameSaveData saveData = (GameSaveData)serializer.ReadObject(stream);
                _manager.LoadSaveData(saveData);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                SaveGame();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save game: " + ex.Message,
                    "Save Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonSaveGame_Click_1(object sender, EventArgs e)
        {
            try
            {
                SaveGame();
                MessageBox.Show("Game saved successfully!",
                    "Save Game",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save game: " + ex.Message,
                    "Save Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void buttonLoadGame_Click_1(object sender, EventArgs e)
        {
            try
            {
                LoadGame();
                UpdateUI();

                MessageBox.Show("Game loaded successfully!",
                    "Load Game",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load game: " + ex.Message,
                    "Load Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
