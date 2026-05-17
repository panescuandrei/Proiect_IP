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
        private Dictionary<string, Button> _upgradeButtons;
        private Dictionary<string, Button> _employeeButtons;
        private List<Label> _floatingTexts = new List<Label>();
        private DateTime _lastBrewTime = DateTime.MinValue;
        private Random _random = new Random();
        private readonly string _saveFilePath = Path.Combine(
    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
    "CodeClicker",
    "savegame.json");

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;

            _manager = GameManager.Instance;

            _upgradeButtons = new Dictionary<string, Button>
            {
                { "Mechanical Keyboard", buttonBuyKeyboard },
                { "Dual Monitor", buttonBuyDualMonitor },  // aici se adauga upgades in dictionar
                { "CI/CD Pipeline", buttonBuyAutomatedPipeline },
                { "Espresso Machine", buttonBuyEspressoMachine }
            };

            _employeeButtons = new Dictionary<string, Button>
                {
                    { "intern", buttonHireIntern },
                    { "junior", buttonHireJunior },
                    { "senior", buttonHireSenior },
                    { "sysarchitect", buttonHireArchi }
                };

            foreach (var btn in _upgradeButtons.Values)
            {
                btn.Visible = false; // update vizbilitate butoane perma upgrades
            }

            foreach (var btn in _employeeButtons.Values)
            {
                btn.Visible = false; // update vizibilitate butoane employee
            }


            // LoadGame();
            UpdateUI();

            this.FormClosing += Form1_FormClosing;
        }

        private void UpdateUI()
        {
            double currentCps = _manager.GetTotalCPS();

            labelLinesOfCode.Text = $"Lines of Code: {_manager.LinesOfCode.ToString("F1")}\nTeam Size: {_manager.Team.Count}\nCode Per Second: {currentCps.ToString("F1")}";

            foreach (var kvp in _employeeButtons)
            {
                double cost = _manager.GetNextCost(kvp.Key);
                string displayName = EmployeeFactory.GetDisplayName(kvp.Key);
                kvp.Value.Visible = _manager.TotalLinesOfCode >= EmployeeFactory.GetUnlockAt(kvp.Key);
                kvp.Value.Text = $"Hire {displayName} (Cost: {Math.Ceiling(cost)})";
                UpdateButtonVisuals(kvp.Value, cost);
            }

            foreach (var upgrade in _manager.Upgrades)
            {
                if (_upgradeButtons.TryGetValue(upgrade.Name, out Button btn))
                {
                    if (upgrade.Name == "Espresso Machine" && upgrade.IsPurchased)
                    {
                        // logica speciala pentru butonul de cafea dupa cumpărare
                        btn.Visible = true;
                        TimeSpan timeSinceBrew = DateTime.Now - _lastBrewTime;
                        bool canBrew = timeSinceBrew.TotalMinutes >= 3;

                        if (canBrew)
                        {
                            btn.Enabled = true;
                            btn.Text = "Brew a coffee";
                            btn.BackColor = Color.SaddleBrown;
                            btn.ForeColor = Color.White;
                        }
                        else if (_manager.IsEspressoBuffActive)
                        {
                            btn.Enabled = false;
                            TimeSpan buffRemaining = TimeSpan.FromMinutes(1) - timeSinceBrew;
                            btn.Text = $"CAFFEINE RUSH! ({buffRemaining.Seconds}s)";
                            btn.BackColor = Color.RosyBrown;
                            btn.ForeColor = Color.SaddleBrown;
                        }
                        else
                        {
                            btn.Enabled = false;
                            TimeSpan cooldownRemaining = TimeSpan.FromMinutes(3) - timeSinceBrew;
                            btn.Text = $"Emptying the tray... ({cooldownRemaining.Minutes}:{cooldownRemaining.Seconds:D2})";
                            btn.BackColor = Color.LightGray;
                            btn.ForeColor = Color.DimGray;
                        }
                    }
                    else
                    {
                        btn.Visible = upgrade.IsUnlocked || upgrade.IsPurchased;
                        btn.Enabled = !upgrade.IsPurchased;
                        btn.Text = upgrade.ButtonText;

                        if (upgrade.IsPurchased)
                        {
                            btn.BackColor = Color.LightGreen;
                            btn.ForeColor = Color.Black;
                        }
                        else
                        {
                            UpdateButtonVisuals(btn, upgrade.Cost);
                        }
                    }
                }
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

            int clickValue = _manager.HasMechanicalKeyboard ? 2 : 1;
            if (_manager.IsEspressoBuffActive)
            {
                clickValue *= 3;
            }

            SpawnFloatingText($"+{clickValue}");
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
            _manager.TryTriggerBug();
            _manager.GeneratePassiveCode();

            // verificare expirare buff de cafea (1 minut)
            if (_manager.IsEspressoBuffActive && (DateTime.Now - _lastBrewTime).TotalMinutes >= 1)
            {
                _manager.IsEspressoBuffActive = false;
            }

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

            int interns = 0;
            int juniors = 0;
            int seniors = 0;
            int arhitects = 0;


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
                else if (employee.Name == "Intern Developer")
                {
                    interns++;
                }
                else if (employee.Name == "System Architect")
                {
                    arhitects++;
                }
            }


            string rosterMessage = "Current Dev Team:\n\n";
            rosterMessage += $"- Intern Developers: {interns}\n";
            rosterMessage += $"- Junior Developers: {juniors}\n";
            rosterMessage += $"- Senior Developers: {seniors}\n";
            rosterMessage += $"- System Architects: {arhitects}";


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

        private void buttonBuyDualMonitor_Click(object sender, EventArgs e)
        {
            var upgrade = _manager.Upgrades
                .FirstOrDefault(u => u.Name == "Dual Monitor");
            try
            {
                upgrade?.Purchase(_manager); // TBA try catch block pt validare
                UpdateUI();
            }
            catch (NotEnoughCodeException ex)
            {
                MessageBox.Show(ex.Message, "Not Enough Code!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonBuyEspressoMachine_Click(object sender, EventArgs e)
        {
            var upgrade = _manager.Upgrades.FirstOrDefault(u => u.Name == "Espresso Machine");
            if (upgrade == null) return;

            if (!upgrade.IsPurchased)
            {
                try
                {
                    upgrade.Purchase(_manager);
                    UpdateUI();
                }
                catch (NotEnoughCodeException ex)
                {
                    MessageBox.Show(ex.Message, "Not Enough Code!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if ((DateTime.Now - _lastBrewTime).TotalMinutes >= 3)
                {
                    _lastBrewTime = DateTime.Now;
                    _manager.IsEspressoBuffActive = true;
                    UpdateUI(); 
                }
            }
        }

        private void buttonBuyAutomatedPipeline_Click(object sender, EventArgs e)
        {
            var upgrade = _manager.Upgrades
    .FirstOrDefault(u => u.Name == "CI/CD Pipeline");
            try
            {
                upgrade?.Purchase(_manager); // TBA try catch block pt validare
                UpdateUI();
            }
            catch (NotEnoughCodeException ex)
            {
                MessageBox.Show(ex.Message, "Not Enough Code!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonHireIntern_Click(object sender, EventArgs e)
        {
            try
            {
                _manager.BuyEmployee("intern");
                UpdateUI();
            }
            catch (NotEnoughCodeException ex)
            {
                MessageBox.Show(ex.Message, "Not Enough Code!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonHireArchi_Click(object sender, EventArgs e)
        {
            try
            {
                _manager.BuyEmployee("sysarchitect");
                UpdateUI();
            }
            catch (NotEnoughCodeException ex)
            {
                MessageBox.Show(ex.Message, "Not Enough Code!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void saveGameToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void loadGameToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void getHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Help.ShowHelp(this, "CodeClickerHelp.chm");
        }
    }
}
