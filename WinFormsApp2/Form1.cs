using System;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Management;

//Created by Loathe (Sinnisterly on GitHub) 
namespace WinFormsApp2
{
    partial class Form1 : Form
    {
        private bool button1Clicked = false;
        private bool button2Clicked = false;

        public Form1()
        {
            InitializeComponent();
        DoubleBuffered = true;
            PopulateNetworkAdapters();
        }

        private void PopulateNetworkAdapters()
        {
            comboBox1.Items.Clear();
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.OperationalStatus == OperationalStatus.Up && ni.NetworkInterfaceType!= NetworkInterfaceType.Loopback)
                {
                    comboBox1.Items.Add(ni.Name);
                }
            }

            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle selected item change
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar!= '\b')
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem!= null)
            {
                MessageBox.Show($"Selected adapter: {comboBox1.SelectedItem}", "Adapter Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button1Clicked = true;
            }
            else
            {
                MessageBox.Show("Please select a network adapter first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int timeInSeconds))
            {
                MessageBox.Show($"Time set: {timeInSeconds} seconds", "Time Set", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button2Clicked = true;
            }
            else
            {
                MessageBox.Show("Please enter a valid time in seconds.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (!button1Clicked ||!button2Clicked)
            {
                MessageBox.Show("Please ensure both Adapter Selection and Time Set actions have been performed.", "Precondition Not Met", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBox1.SelectedItem == null ||!int.TryParse(textBox1.Text, out int timeInSeconds) || timeInSeconds <= 0)
            {
                MessageBox.Show("Please select a network adapter and enter a valid time in seconds.", "Selection and Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedAdapterName = comboBox1.SelectedItem.ToString();
            var result = await ToggleNetworkAdapterWithNetshAsync(selectedAdapterName, timeInSeconds);

            if (result)
            {
                MessageBox.Show($"Network adapter '{selectedAdapterName}' has been disabled and re-enabled.", "Adapter Toggled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"An error occurred while toggling network adapter '{selectedAdapterName}'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Optionally, reset the flags if required to enforce the sequence for future button3 clicks
            // button1Clicked = false;
            // button2Clicked = false;
        }

        private async Task<bool> ToggleNetworkAdapterWithNetshAsync(string adapterName, int timeInSeconds)
        {
            try
            {
                // Disable the network adapter
                ExecuteNetshCommand($"interface set interface \"{adapterName}\" admin=disable");

                // Wait for the specified time
                await Task.Delay(timeInSeconds * 1000);

                // Enable the network adapter
                ExecuteNetshCommand($"interface set interface \"{adapterName}\" admin=enable");

                return true;
            }
            catch (Exception ex)
            {
                // Log the error or display a message here if needed
                return false;
            }
        }

        private void ExecuteNetshCommand(string command)
        {
            using (var process = new System.Diagnostics.Process())
            {
                process.StartInfo.FileName = "netsh";
                process.StartInfo.Arguments = command;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                // Optional: Use output or error for logging or additional error handling
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string githubUrl = "https://github.com/Sinnisterly/Network-Toggler/";
            var psi = new System.Diagnostics.ProcessStartInfo
            {
                UseShellExecute = true,
                FileName = githubUrl
            };
            System.Diagnostics.Process.Start(psi);
        }
    }
}