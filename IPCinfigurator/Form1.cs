using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.IO;
using IPCinfigurator.Properties;

namespace IPCinfigurator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        IPAddress gateway;

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = true;

            string newGateway = tbxGateway.Text;
            string http = @"http://" + newGateway;
            Process.Start(http);
        }

        public IPAddress GetDefaultGateway()
        {

            try
            {
                foreach (NetworkInterface f in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (f.OperationalStatus == OperationalStatus.Up)
                    {
                        foreach (GatewayIPAddressInformation d in f.GetIPProperties().GatewayAddresses)
                        {
                            gateway = d.Address;
                        }
                    }
                }

                return gateway;

            }
            catch (Exception)
            {
                MessageBox.Show("IP DOESNT EXIST");
                return null;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Visible = false;
            ArrayList AR = new ArrayList();
            comboBox1.Items.Insert(0, "-SELECT CLIENT-");
            comboBox1.SelectedIndex = 0;
            AR.Add("Gauteng Coaches");
            AR.Add("Ntambanana");
            AR.Add("Marblehall");
            AR.Add("Mokopane");
            AR.Add("UGU");
            AR.Add("DUZI");

            foreach (var item in AR)
            {
                comboBox1.Items.Add(item);
            }

            IPAddress gateWay = GetDefaultGateway();

            tbxGateway.Text = gateWay.ToString();

            if (tbxGateway.Text == "10.0.0.2")
            {
                lblClientname.Text = "Gauteng Coaches";
                lblDriver.Text = "30";
                lblPOS.Text = "29";
                lblCashier.Text = "9";
            }
            else if (tbxGateway.Text == "192.168.24.1")
            {
                lblClientname.Text = "Ntambanana";
                lblDriver.Text = "33";
                lblPOS.Text = "34";
                lblCashier.Text = "32";
            }
            else if (tbxGateway.Text == "192.168.8.1")
            {
                lblClientname.Text = "Marblehall";
                lblDriver.Text = "22";
                lblPOS.Text = "21";
                lblCashier.Text = "7";
            }
            else if (tbxGateway.Text == "192.168.14.1")
            {
                lblClientname.Text = "Mokopane";
                lblDriver.Text = "28";
                lblPOS.Text = "27";
                lblCashier.Text = "8";
            }
            else if (tbxGateway.Text == "10.10.10.254")
            {
                lblClientname.Text = "UGU";
                lblDriver.Text = "26";
                lblPOS.Text = "25";
                lblCashier.Text = "5";
            }
            else if (tbxGateway.Text == "10.10.10.254")
            {
                lblClientname.Text = "DUZI";
                lblDriver.Text = "24";
                lblPOS.Text = "23";
                lblCashier.Text = "6";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            button3.Visible = true;
            string ip;
            string subnet;
            string gateway;

            if (comboBox1.SelectedItem == "Gauteng Coaches")
            {
                ip = "10.0.0.253";
                subnet = "255.255.255.0";
                gateway = "10.0.0.2";
                setIP(ip, subnet);
                setGateway(gateway);

                //// check if file already exists in inboxbackup if it does then delete
                if (File.Exists(Settings.Default.NewPath + Settings.Default.FileName))
                {
                    File.Delete(Settings.Default.NewPath + Settings.Default.FileName);
                }
                // copy file to backup folder - no "file already exists errors as check above has removed any existing files
                File.Copy(Settings.Default.OldPath + Settings.Default.GautengCoaches, Settings.Default.NewPath + Settings.Default.FileName);
            }
            else if (comboBox1.SelectedItem == "Ntambanana")
            {
                ip = "192.168.24.253";
                subnet = "255.255.255.0";
                gateway = "192.168.24.1";
                setIP(ip, subnet);
                setGateway(gateway);
                //// check if file already exists in inboxbackup if it does then delete
                if (File.Exists(Settings.Default.NewPath + Settings.Default.FileName))
                {
                    File.Delete(Settings.Default.NewPath + Settings.Default.FileName);
                }
                // copy file to backup folder - no "file already exists errors as check above has removed any existing files
                File.Copy(Settings.Default.OldPath + Settings.Default.Ntambanana, Settings.Default.NewPath + Settings.Default.FileName);
            }
            else if (comboBox1.SelectedItem == "Marblehall")
            {
                ip = "192.168.8.9";
                subnet = "255.255.255.0";
                gateway = "192.168.8.1";
                setIP(ip, subnet);
                setGateway(gateway);
                //// check if file already exists in inboxbackup if it does then delete
                if (File.Exists(Settings.Default.NewPath + Settings.Default.FileName))
                {
                    File.Delete(Settings.Default.NewPath + Settings.Default.FileName);
                }
                // copy file to backup folder - no "file already exists errors as check above has removed any existing files
                File.Copy(Settings.Default.OldPath + Settings.Default.Marblehall, Settings.Default.NewPath + Settings.Default.FileName);
            }
            else if (comboBox1.SelectedItem == "Mokopane")
            {
                ip = "192.168.14.9";
                subnet = "255.255.255.0";
                gateway = "192.168.14.1";
                setIP(ip, subnet);
                setGateway(gateway);
                // check if file already exists in inboxbackup if it does then delete
                if (File.Exists(Settings.Default.NewPath + Settings.Default.FileName))
                {
                    File.Delete(Settings.Default.NewPath + Settings.Default.FileName);
                }
                // copy file to backup folder - no "file already exists errors as check above has removed any existing files
                File.Copy(Settings.Default.OldPath + Settings.Default.Mokopane, Settings.Default.NewPath + Settings.Default.FileName);
            }
            else if (comboBox1.SelectedItem == "UGU")
            {
                ip = "10.10.10.253";
                subnet = "255.255.255.0";
                gateway = "10.10.10.254";
                setIP(ip, subnet);
                setGateway(gateway);
                // check if file already exists in inboxbackup if it does then delete
                if (File.Exists(Settings.Default.NewPath + Settings.Default.FileName))
                {
                    File.Delete(Settings.Default.NewPath + Settings.Default.FileName);
                }
                // copy file to backup folder - no "file already exists errors as check above has removed any existing files
                File.Copy(Settings.Default.OldPath + Settings.Default.Marblehall, Settings.Default.NewPath + Settings.Default.FileName);
            }
            else if (comboBox1.SelectedItem == "DUZI")
            {
                ip = "10.10.10.253";
                subnet = "255.255.255.0";
                gateway = "10.10.10.254";
                setIP(ip, subnet);
                setGateway(gateway);
                // check if file already exists in inboxbackup if it does then delete
                if (File.Exists(Settings.Default.NewPath + Settings.Default.FileName))
                {
                    File.Delete(Settings.Default.NewPath + Settings.Default.FileName);
                }
                // copy file to backup folder - no "file already exists errors as check above has removed any existing files
                File.Copy(Settings.Default.OldPath + Settings.Default.Duzi, Settings.Default.NewPath + Settings.Default.FileName);
            }
        }

        public void setIP(string ip_address, string subnet_mask)
        {
            ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMC.GetInstances();

            foreach (ManagementObject objMO in objMOC)
            {
                if ((bool)objMO["IPEnabled"])
                {
                    try
                    {
                        ManagementBaseObject setIP;
                        ManagementBaseObject newIP =
                            objMO.GetMethodParameters("EnableStatic");

                        newIP["IPAddress"] = new string[] { ip_address };
                        newIP["SubnetMask"] = new string[] { subnet_mask };

                        setIP = objMO.InvokeMethod("EnableStatic", newIP, null);
                    }
                    catch (Exception)
                    {
                        throw;
                    }


                }
            }
        }

        public void setGateway(string gateway)
        {
            ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMC.GetInstances();

            foreach (ManagementObject objMO in objMOC)
            {
                if ((bool)objMO["IPEnabled"])
                {
                    try
                    {
                        ManagementBaseObject setGateway;
                        ManagementBaseObject newGateway =
                            objMO.GetMethodParameters("SetGateways");

                        newGateway["DefaultIPGateway"] = new string[] { gateway };
                        newGateway["GatewayCostMetric"] = new int[] { 1 };

                        setGateway = objMO.InvokeMethod("SetGateways", newGateway, null);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(Settings.Default.DeletePath);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }


            if (MessageBox.Show("Reboot Computer", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Process.Start("shutdown", "/r /t 0"); // the argument /r is to restart the computer
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            
            if (comboBox1.SelectedIndex == 1)
            {
                button1.Visible = true;
                lblDriver.Text = "30";
                lblPOS.Text = "29";
                lblCashier.Text = "9";
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                button1.Visible = true;
                lblDriver.Text = "33";
                lblPOS.Text = "34";
                lblCashier.Text = "32";
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                button1.Visible = true;
                lblDriver.Text = "22";
                lblPOS.Text = "21";
                lblCashier.Text = "7";
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                button1.Visible = true;
                lblDriver.Text = "28";
                lblPOS.Text = "27";
                lblCashier.Text = "8";
            }
            else if (comboBox1.SelectedIndex == 5)
            {
                button1.Visible = true;
                lblDriver.Text = "26";
                lblPOS.Text = "25";
                lblCashier.Text = "5";
            }
            else if (comboBox1.SelectedIndex == 6)
            {
                button1.Visible = true;
                lblDriver.Text = "24";
                lblPOS.Text = "23";
                lblCashier.Text = "6";
            }
        }

        private void comboBox1_DragDrop(object sender, DragEventArgs e)
        {
            button1.Visible = true;
        }
    }
}
