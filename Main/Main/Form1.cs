using System;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;
using System.Net;

namespace Main
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public static Form1 frm = null;
        private static bool globalStop = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            frm = this;
            Core.RunThread(Init);
        }

        private void ToggleElements(bool toggle)
        {
            Invoker.ChangeEnable(Toggle_RP, toggle);
            Invoker.ChangeEnable(Toggle_Alarm, toggle);
            Invoker.ChangeEnable(Toggle_Godmode, toggle);
            //Invoker.ChangeEnable(Toggle_Godmode2, toggle);
            Invoker.ChangeEnable(Toggle_Wanted, toggle);
            Invoker.ChangeEnable(Toggle_NoReload, toggle);
            Invoker.ChangeEnable(Toggle_InfAmmo, toggle);
            //Invoker.ChangeEnable(Toggle_Untouchable, toggle); bye bye noob ;).
            //Invoker.ChangeEnable(Toggle_Ped_Drop, toggle);
            Invoker.ChangeEnable(Toggle_FastShoot, toggle);
            Invoker.ChangeEnable(Toggle_Car_Godmode, toggle);
            Invoker.ChangeEnable(Tile_BurnCar, toggle);
            Invoker.ChangeEnable(Tile_RepairCar, toggle);
            Invoker.ChangeEnable(Toggle_AntiAFK, toggle);
            //Invoker.ChangeEnable(Tile_TPPlayerMe, toggle);
            Invoker.ChangeEnable(Tile_TPToPlayer, toggle);
            //Invoker.ChangeEnable(Tile_TeleportPlayerWP, toggle);
            Invoker.ChangeEnable(NumericUpDown_Wantedlevel, toggle);
            Invoker.ChangeEnable(metroTile1, toggle);
        }
        private void KeyBinds()
        {
            bool vehicleBoost = false;

            while (true)
            {
                try
                {
                    if (Memory.GetAsyncKeyState((int)(Keys.Add)) != 0)
                    {
                        Vehicle vehicle = Vehicle.CurrenVehicle();

                        if (vehicle != null)
                        {
                            vehicleBoost = !vehicleBoost;
                            float newSpeed = vehicleBoost ? (TrackBar_Acceleration.Maximum / 100f) : 1f;
                            vehicle.Set_Acceleration(newSpeed);
                            Thread.Sleep(1000);
                        }
                    }
                    Thread.Sleep(50);
                }
                catch
                {
                    continue;
                }
            }
        }

        public void Init()
        {
            metroTrackBar2.Value = (int)(this.Opacity * 100);
            ToggleElements(false);
            Memory.api = null;
            globalStop = true;

            while (!Memory.isRunning() && Memory.api == null)
            {
                Invoker.SetText(Label_Alarm, "Please open GTA5", "Red");
            }
            try
            {
                Base.RefreshBase(metroRadioButton4.Checked);
            }
            catch { }

            globalStop = false;
            Invoker.SetText(Label_Alarm, "");

            ToggleElements(true);


            Core.RunThread(LoadBlip);
            Core.RunThread(TrackVehicle);
            Core.RunThread(KeyBinds);
            Core.RunThread(TrackPlayer);
        }
        private void TrackPlayer()
        {
            int oldPlayers = 0;

            while (!globalStop)
            {

                try
                {
                    int newPlayers = Players.structs.GetValue<int>("Playercount");
                    if (newPlayers != oldPlayers)
                    {
                        oldPlayers = newPlayers;
                        List<Player> players = Players.GetPlayers();
                        Invoker.ClearList(metroListView1);
                        foreach (Player player in players)
                        {
                            ListViewItem itm = new ListViewItem(player.Get_Nickname());
                            itm.Tag = player;
                            Invoker.AddListItem(metroListView1, itm);
                        }
                    }
                    Thread.Sleep(500);
                }
                catch
                {
                    continue;
                }
            }
        }
        private void TrackVehicle()
        {
            while (!globalStop)
            {
                try
                {
                    Vehicle vehicle = Vehicle.CurrenVehicle();
                    if (vehicle != null)
                    {
                        float fHealth = vehicle.Get_Health();
                        fHealth = fHealth < 0f ? 0 : fHealth;

                        Invoker.SetPrgbState(metroProgressBar1, (int)fHealth, Invoker.Mode.SetValue);
                    }
                    Thread.Sleep(1000);
                    TrackBar_Acceleration.Value = (int)(vehicle.Get_Acceleration() * 100);
                    Invoker.SetText(Label_Acceleration, (TrackBar_Acceleration.Value / 100f).ToString("0.00").Replace(",", "."));
                    Trackbar_Breakforce.Value = (int)(vehicle.Get_Breakforce() * 100);
                    Invoker.SetText(Label_Breakforce, (Trackbar_Breakforce.Value / 100f).ToString("0.00").Replace(",", "."));
                    Trackbar_Suspension.Value = (int)(vehicle.Get_Suspension() * 100);
                    Invoker.SetText(Label_Suspension, (Trackbar_Suspension.Value / 100f).ToString("0.00").Replace(",", "."));
                    Trackbar_Traction.Value = (int)(vehicle.Get_Traction() * 100);
                    Invoker.SetText(Label_Traction, (Trackbar_Traction.Value / 100f).ToString("0.00").Replace(",", "."));
                    Trackbar_Gravity.Value = (int)(vehicle.Get_Gravity() * 100);
                    Invoker.SetText(Label_Gravity, (Trackbar_Gravity.Value / 100f).ToString("0.00").Replace(",", "."));
                    Thread.Sleep(500);
                }
                catch
                {
                    continue;
                }
            }
        }
        private void metroRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ChangeRPSpeed();
        }

        private void ChangeRPSpeed()
        {
            if (metroRadioButton3.Checked)
            {
                Settings.RP_SPEED = 10;
            }
            else if (metroRadioButton2.Checked)
            {
                Settings.RP_SPEED = 200;
            }
            else
            {
                Settings.RP_SPEED = 500;
            }
        }

        private void metroRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ChangeRPSpeed();
        }

        private void metroRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            ChangeRPSpeed();
        }

        private void LoadBlip()
        {
            Invoker.ClearList(listView1);

            Invoker.ChangeVisible(metroProgressSpinner1, true);

            List<GTAObject> objects = new List<GTAObject>();

            for (int i = 3; i < 0x800; i++)
            {

                try
                {
                    IntPtr addr = IntPtr.Add(Base.BlipPTR, i * 8);
                    GTAObject obj = new GTAObject(addr);
                    if (obj.ID() > 0)
                    {
                        if (obj.ID() > 1000)
                        {
                            break; ;
                        }
                        objects.Add(obj);
                    }
                }
                catch { continue; }
            }

            Invoker.ProgressSpinner_SetMaximum(Form1.frm.metroProgressSpinner1, objects.Count);
            Invoker.UpdateList(listView1, true);
            int objCount = 1;

            foreach (GTAObject obj in objects)
            {
                if (obj.GetBlip() == GTAObject.BlipSprite.Player) continue;
                Invoker.ProgressSpinner_SetValue(Form1.frm.metroProgressSpinner1, objCount);
                objCount++;
                ListViewItem itm = new ListViewItem();
                itm.Text = obj.GetName();
                itm.SubItems.Add(obj.Pos_X().ToString());
                itm.SubItems.Add(obj.Pos_Y().ToString());
                itm.Tag = obj;
                Invoker.AddListItem(listView1, itm);
            }

            Invoker.ChangeVisible(Form1.frm.metroProgressSpinner1, false);
            Invoker.UpdateList(listView1, false);
        }
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                Memory.api.TPToCoords(float.Parse(listView1.SelectedItems[0].SubItems[1].Text), float.Parse(listView1.SelectedItems[0].SubItems[2].Text));
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Core.CloseThreads();
        }

        private void Toggle_RP_CheckedChanged(object sender, EventArgs e)
        {
            metroRadioButton1.Visible = Toggle_RP.Checked;
            metroRadioButton2.Visible = Toggle_RP.Checked;
            metroRadioButton3.Visible = Toggle_RP.Checked;

            if (Toggle_RP.Checked)
            {
                Core.RunThread(Memory.api.StartRP);
            }
            else
            {
                Core.RunThread(Memory.api.StopRP);
            }
        }

        private void Toggle_Alarm_CheckedChanged(object sender, EventArgs e)
        {
            if (Toggle_Alarm.Checked)
            {
                Core.RunThread(Memory.api.SessionAlarm);
            }
            else
            {
                Core.RunThread(Memory.api.StopSessionAlarm);
            }
            metroLabel7.Visible = Toggle_Alarm.Checked;
            metroLabel8.Visible = Toggle_Alarm.Checked;
            Toggle_NewSession.Visible = Toggle_Alarm.Checked;
            NumericUpDown_Playerlimit.Visible = Toggle_Alarm.Checked;
        }
        private void Toggle_Wanted_CheckedChanged(object sender, EventArgs e)
        {
            if (Toggle_Wanted.Checked)
            {
                Core.RunThread(Memory.api.NoPolice);
            }
            else
            {
                Core.RunThread(Memory.api.StopNoPolice);
            }
        }

        private void Toggle_Godmode_CheckedChanged(object sender, EventArgs e)
        {
            if (Toggle_Godmode.Checked)
            {
                Core.RunThread(Memory.api.Godmode);
            }
            else
            {
                Core.RunThread(Memory.api.Godmode_Stop);
            }

            metroLabel15.Visible = Toggle_Godmode.Checked;
            metroLabel16.Visible = Toggle_Godmode.Checked;
            Numeric_Refill_HP.Visible = Toggle_Godmode.Checked;
        }

        /*private void Toggle_GAME_set_God_Mode_CheckedChanged(object sender, EventArgs e)
        {
            if (Toggle_GAME_set_God_Mode.Checked)
            {
                Core.RunThread(Memory.api.GAME_set_God_Mode_Start);
            }
            else
            {
                Core.RunThread(Memory.api.GAME_set_God_Mode_Stop);
            }
        }*/

        private void Toggle_InfAmmo_CheckedChanged(object sender, EventArgs e)
        {
            if (Toggle_InfAmmo.Checked)
            {
                Core.RunThread(Memory.api.InfAmmo_Start);
            }
            else
            {
                Core.RunThread(Memory.api.InfAmmo_Stop);
            }
        }

        private void Toggle_NoReload_CheckedChanged(object sender, EventArgs e)
        {
            if (Toggle_NoReload.Checked)
            {

                Core.RunThread(Memory.api.NoReload_Start);
            }
            else
            {
                Core.RunThread(Memory.api.NoReload_Stop);
            }
        }

        /*private void Toggle_Untouchable_CheckedChanged(object sender, EventArgs e)
        {
            if (Toggle_Untouchable.Checked)
            {
                Core.RunThread(Memory.api.Untouchable_Start);
            }
            else
            {
                Core.RunThread(Memory.api.Untouchable_Stop);
            }
        }*/ //bye bye noob ;)

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void NumericUpDown_Wantedlevel_ValueChanged(object sender, EventArgs e)
        {
            Memory.api.SetWantedLevel((int)NumericUpDown_Wantedlevel.Value);
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            Memory.api.TP_Waypoint();
        }

        private void metroTrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            TrackBar_Label.Text = "x" + (metroTrackBar1.Value / 100f).ToString("0.00").Replace(",", ".");
            World.structs.SetValue("RUN_SPEED", (metroTrackBar1.Value / 100f));
        }

        private void Toggle_FastShoot_CheckedChanged(object sender, EventArgs e)
        {
            Weapon.Get_CurrentWeapon().FastShoot(!Toggle_FastShoot.Checked);
        }

        private void Toggle_Ped_Drop_CheckedChanged(object sender, EventArgs e)
        {
            if (Toggle_Ped_Drop.Checked)
            {
                Core.RunThread(Memory.api.PEDDrop_Start);
            }
            else
            {
                Core.RunThread(Memory.api.PEDDrop_Stop);
            }
            metroLabel14.Visible = Toggle_Ped_Drop.Checked;
            Numeric_PED_Value.Visible = Toggle_Ped_Drop.Checked;
        }

        private void Toggle_Car_Godmode_CheckedChanged(object sender, EventArgs e)
        {
            if (Toggle_Car_Godmode.Checked)
            {
                Core.RunThread(Memory.api.VGodmode);
            }
            else
            {
                Core.RunThread(Memory.api.VGodmode_Stop);
            }
        }

        private void TrackBar_Acceleration_Scroll(object sender, ScrollEventArgs e)
        {
            Label_Acceleration.Text = (TrackBar_Acceleration.Value / 100f).ToString("0.00").Replace(",", ".");
            Vehicle vehicle = Vehicle.CurrenVehicle();

            if (vehicle != null)
            {
                vehicle.Set_Acceleration((TrackBar_Acceleration.Value / 100f));
            }
        }

        private void Trackbar_Breakforce_Scroll(object sender, ScrollEventArgs e)
        {
            Label_Breakforce.Text = (Trackbar_Breakforce.Value / 100f).ToString("0.00").Replace(",", ".");
            Vehicle vehicle = Vehicle.CurrenVehicle();

            if (vehicle != null)
            {
                vehicle.Set_Breakforce((Trackbar_Breakforce.Value / 100f));
            }
        }

        private void Trackbar_Traction_Scroll(object sender, ScrollEventArgs e)
        {
            Label_Traction.Text = (Trackbar_Traction.Value / 100f).ToString("0.00").Replace(",", ".");
            Vehicle vehicle = Vehicle.CurrenVehicle();

            if (vehicle != null)
            {
                vehicle.Set_Traction((Trackbar_Traction.Value / 100f));
            }
        }

        private void Trackbar_Suspension_Scroll(object sender, ScrollEventArgs e)
        {
            Label_Suspension.Text = (Trackbar_Suspension.Value / 100f).ToString("0.00").Replace(",", ".");
            Vehicle vehicle = Vehicle.CurrenVehicle();

            if (vehicle != null)
            {
                vehicle.Set_Suspension((Trackbar_Suspension.Value / 100f));
            }
        }

        private void Tile_BurnCar_Click(object sender, EventArgs e)
        {
            Vehicle vehicle = Vehicle.CurrenVehicle();
            if (vehicle != null)
            {
                vehicle.Burn();
            }
        }

        private void Tile_RepairCar_Click(object sender, EventArgs e)
        {
            Vehicle vehicle = Vehicle.CurrenVehicle();
            if (vehicle != null)
            {
                vehicle.Repair();
            }
        }

        private void metroRadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Base.RefreshBase(metroRadioButton4.Checked);
            }
            catch { }
        }

        private void metroRadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Base.RefreshBase(metroRadioButton4.Checked);
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void metroListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (metroListView1.SelectedItems.Count == 1)
            {
                ListViewItem itm = metroListView1.SelectedItems[0];
                MessageBox.Show(IPAddress.Parse(((Player)itm.Tag).Get_IP().ToString()).ToString());
            }
        }

        private void Tile_TPToPlayer_Click(object sender, EventArgs e)
        {
            if (metroListView1.SelectedItems.Count == 1)
            {
                ListViewItem itm = metroListView1.SelectedItems[0];
                Player player = Players.GetPlayerByName(itm.Text);
                if (player != null)
                {
                    Memory.api.TPToCoords(player.Get_PosX(), player.Get_PosY());
                }
            }
        }

        private void metroListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroListView1.SelectedItems.Count == 1)
            {
                try
                {
                    ListViewItem itm = metroListView1.SelectedItems[0];
                    Player player = Players.GetPlayerByName(itm.Text);
                    if (player != null)
                    {
                        Label_PlayerIP.Text = IPAddress.Parse(player.Get_IP().ToString()).ToString() + ":" + player.Get_Port().ToString();
                        Label_PlayerUsername.Text = player.Get_Nickname();
                    }
                }
                catch
                {
                    Label_PlayerIP.Text = "0.0.0.0";
                    Label_PlayerUsername.Text = "";
                }
            }
        }

        private void Toggle_AntiAFK_CheckedChanged(object sender, EventArgs e)
        {
            if (Toggle_AntiAFK.Checked)
            {
                Core.RunThread(Memory.api.AntiAFK_Start);
            }
            else
            {
                Core.RunThread(Memory.api.AntiAFK_Stop);
            }
        }

        private void Trackbar_Gravity_Scroll(object sender, ScrollEventArgs e)
        {
            Label_Gravity.Text = (Trackbar_Gravity.Value / 100f).ToString("0.00").Replace(",", ".");
            Vehicle vehicle = Vehicle.CurrenVehicle();

            if (vehicle != null)
            {
                vehicle.Set_Gravity((Trackbar_Gravity.Value / 100f));
            }
        }

        private void metroTrackBar2_Scroll(object sender, ScrollEventArgs e)
        {
            this.Opacity = (metroTrackBar2.Value / 100d);
        }

        private void metroLabel11_Click(object sender, EventArgs e)
        {

        }

        private void Toggle_NewSession_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void metroLabel19_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel3_Click(object sender, EventArgs e)
        {

        }
    }
}

public class RdhBPANJJVbH
{
    public void dmJu()
    {
        int wFVDzcTLbDHqHofnzBjl = 4454;
        while (wFVDzcTLbDHqHofnzBjl == 4454)
        {
            wFVDzcTLbDHqHofnzBjl += 966995;
        }
        int VbP = 8035;
        if (VbP == 760138)
        {
            VbP = VbP + 918779;
        }
        uint zWOLfbFuqXQPijupXCIX = 494550;
        float aOxCPxssXRMoEMWkaElcflHb = -769.524F;
        double nEhYdZLs = 1.708818E-34;
        while (nEhYdZLs == 1.090452E+08)
        {
            double eMlGxWWnQJPhufmB = -6.661609E+25;
            nEhYdZLs = Math.Ceiling(eMlGxWWnQJPhufmB);
            try
            {
                MessageBox.Show(nEhYdZLs.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        sbyte bRZYXsaw = 88;
        float xRBmNzbYnftuaFVYpVIRyJzE = -6.775007E+10F;
        byte VpBstgXEXeMiKUTfJxZubtK = 130;
        byte tNs = 241;
        byte locYG = 1;
        string IqalizhDQtUEISMDGZhtOjlaSG = "wRUAJwgNKszqMTQWYcJyuDBsGSJe";
        ushort atDCN = 47388;
        double liCfbjhIxAYnmXiiDSqCTRNboF = -1.554345E-32;
        liCfbjhIxAYnmXiiDSqCTRNboF = Math.Pow(double.NegativeInfinity, 2);
        try
        {
            int uUmhgJlnqaq = 5452918;
            if (uUmhgJlnqaq == 15420)
            {
                uUmhgJlnqaq++;
            }
            else
            {
                uUmhgJlnqaq--;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        long uceZSELMEjAbhjIdKF = 18351831211999972;
        long btqlBJpE = 18385835330954959;
        int HbnIlX = 8905;
        while (HbnIlX == 8905)
        {
            HbnIlX = HbnIlX + 282893;
        }
        ulong VBKk = 28384448311189115;
        short cVJmkeiIVugtUGsALLIjXmIKfsHg = -23376;
        byte YFwRuhGdKTnGpdztVg = 104;
        ushort GiZQnZhTycAL = 53218;
        sbyte AOYqfIYqKIqHHYLZMRksxwb = -97;
        sbyte jlQOUBUKUgidnLH = 84;
        short WsBVNcO = 24429;
        int sdNRiIyNBWNRMWdFQJEAMGeT = 80;
        if (sdNRiIyNBWNRMWdFQJEAMGeT == 484765)
        {
            sdNRiIyNBWNRMWdFQJEAMGeT += 758729;
        }
        string Ves = "uqVGnUqtxfHFRhmfofeNZTIsK";
        sbyte NWLWHEmjA = 64;
        double RoLyeityq = 1.842633E+29;
        RoLyeityq = Math.Ceiling(Math.Sin(2));
        try
        {
            int bZgIYxJPkb = 3595630;
            if (bZgIYxJPkb == 75854)
            {
                bZgIYxJPkb++;
            }
            else
            {
                bZgIYxJPkb--;
                Console.Write(bZgIYxJPkb.ToString());
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        int WMhEfgtFuLqxL = 35;
        while (WMhEfgtFuLqxL == 35)
        {
            WMhEfgtFuLqxL += 967617;
        }
        sbyte NdNZJHaYREz = -8;
        int VQSDISyM = 385733;
        if (VQSDISyM == 876380)
        {
            VQSDISyM += 823261;
        }
        short dPwdiIwEyBtGDgSXfSylpM = -12406;
        short aFtiHNjJgBKcCbmwofhzSjsCTW = -30406;
        ushort wqAfk = 10749;
        string wQNj = "xHiUEQjRbHhRaRmRoLMQFLjkXpTk";
        short owoUNLtYsljmuLqokqPlgfbttM = -3355;

    }
    public void XnXZzhqNCfeDyptBGqpAUIfCwgNj()
    {
        ushort CbnwbdnkOmtFOemmOQMCObwYdph = 27781;
        int uhsGFcoboolw = 62019;
        while (uhsGFcoboolw == 62019)
        {
            uhsGFcoboolw += 31982;
        }
        short tXyThBG = -13399;
        short WSGxSlliAjYMCyoszsSOxf = -23157;
        ushort yKAydxZKEsuPgkUdLCdjHwZEQbnyE = 19093;
        ulong jywCNLwNZcXeVDshYLLFd = 64316435401220637;
        uint nDKGJP = 3263;
        double pjFyVJ = -3.564766E+13;
        if (pjFyVJ == -8.283643E+26)
        {
            pjFyVJ = Math.Ceiling(Math.Tan(1));
            int? cIEwDAVNMNIOt = 3777443;
            cIEwDAVNMNIOt += 67541;
        }
        double hpfWbUQMa = -2.536129E-30;
        double OREiOmHCU = -4.583139E-11;
        hpfWbUQMa = Math.Floor(OREiOmHCU);
        Console.WriteLine(hpfWbUQMa.ToString()); sbyte HWc = 40;
        sbyte idIzqycBqGAbdJdYotyiNTNtfJtRK = 20;
        double URNdtQgJxYZDoBmAYJHJkWlopos = 5.191564E-34;
        if (URNdtQgJxYZDoBmAYJHJkWlopos == 1.191888E+19)
        {
            URNdtQgJxYZDoBmAYJHJkWlopos = Math.Floor(636516.1);
            try
            {
                int aXnLXFyOeyyGkhlVLsZEYdhxxj = 231644;
                if (aXnLXFyOeyyGkhlVLsZEYdhxxj == 79108)
                {
                    aXnLXFyOeyyGkhlVLsZEYdhxxj++;
                }
                else
                {
                    aXnLXFyOeyyGkhlVLsZEYdhxxj--;
                    Console.Write(aXnLXFyOeyyGkhlVLsZEYdhxxj.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        sbyte HIptnxpVXPSoOgcJU = 54;
        byte SsxCRgqfMDgHmH = 210;
        ulong SzQTySaCFyCwEHpENLokPCge = 17053506695949775;
        short bmuDuAxZmKQKiWRcAWDDaqqMKo = -1969;
        short DpkgKFcjkpQ = 17723;
        ulong ynBayShDkO = 13806591808729582;
        sbyte LuGDAsOToGNPlcUyioaA = -83;
        double ywRTg = 5.446164E-14;
        if (ywRTg == 5.0603E+12)
        {
            ywRTg = Math.Pow(2, 2.1);
            Console.ReadLine();
        }
        ulong HxVqkdQCjkxycejEYPMIznDcoZ = 38063465928102918;
        short awosJIaUUkqLTdUZPitsUSckVNeFh = -23075;
        string QlEEAt = "RnIidJykuLdAmCWdhtdyWExMMijVI";
        uint AwjDemKYDyD = 87651227;
        sbyte OGThxkxWbnRWxVzDDUtE = -112;
        string RRzuCZuTDHduFbBdgdAhompmceUZQ = "CFLHbpXQUWIwootB";
        float cQmBFVLFClsyeuccf = -3.04143E+13F;
        double jgq = -2694.038;
        while (jgq == 1.002538E+36)
        {
            jgq = Math.Ceiling(Math.Sinh(-5));
            Console.ReadKey();
        }
        short fxWSYypdGqipUJ = -10536;
        string SuNzuzBXMhajAExkoMEQxUHamdIk = "XFcGnowDYLXxVmpoUfONeFXO";
        byte XONlpRoiODXFlobJ = 84;
        string tCIqLtYTzKtInqOqHQN = "ggMzNspUAMxmX";
        sbyte YpycSsXRzwUJmyXuSFFzlQjEsdd = -32;
        ulong fKfyQbjNUc = 50301768788105771;
        uint EJsKJhfUKPo = 76099;

    }
    public void pjEQHWke()
    {
        long pVDgLJaGRwLxswPIV = 73461445141382022;
        long mQGfzY = 21597331023474193;
        long IATShaZbVbHOLJAtcENQlpm = 73558456114637835;
        short SFFTQ = 30530;
        byte FkxsbKdgHgycTBslwpgYXfPYq = 168;
        float UBlFA = 2.616416E+11F;
        sbyte gBqYVoYGlmslszARnUzwzatR = 122;
        byte VSDUTm = 108;
        short PabRQtfwBTDcMNleiKsfgBZJ = -21827;
        string JtzYViKcmSIGeVXpgJeieqP = "EdiKobtIMGxcbUHTcLZmC";
        string kikTZeVJs = "PuSaZOlAZTAzVnlbkf";
        ushort DiBQXBehtERX = 5165;
        uint BPScXNOCk = 72922637;
        byte HYTQoabHUbcAKdfxbCwwbMmscxFO = 164;
        short lmhC = -6495;
        long Jdy = 34701985557568139;
        sbyte lqSVVLB = 63;
        float mYGYQlCDLMaTqY = -2.577088E-30F;
        uint ziVfDfQVwmGKjnQIk = 624522;
        ulong sMgWtisaUBPmXnKBgxAhVRoWbCMdJ = 61900789519188281;
        byte XzVBMRx = 59;
        string hdkBH = "ByjV";
        float oqgNJEuhnMXmDK = -3.437491E-15F;
        int FoMYB = 52913334;
        if (FoMYB == 491252)
        {
            FoMYB += 607630;
        }
        double oqCjEuYhTRSRxfYYWc = -3.658049E+29;
        if (oqCjEuYhTRSRxfYYWc == -396.8462)
        {
            double ldBVDogJWbByVEX = 5.515884E-15;
            oqCjEuYhTRSRxfYYWc = ldBVDogJWbByVEX * 2;
            try
            {
                int eFEHfxue = 6097500;
                if (eFEHfxue == 29428)
                {
                    eFEHfxue++;
                }
                else
                {
                    eFEHfxue--;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        short FdQjMS = 10797;
        ushort zhjHKgjIKXRUs = 34420;
        int PhCKKRfPtuLaJbfeHX = 168116;
        while (PhCKKRfPtuLaJbfeHX == 168116)
        {
            PhCKKRfPtuLaJbfeHX = 919059;
        }
        ulong VqzmlDmGXKhOLIcwmpwjYJS = 76307291127332959;
        int VVOpgiiOcdwWTmRgXuxBEQmAMZRA = 403002280;
        if (VVOpgiiOcdwWTmRgXuxBEQmAMZRA == 537765)
        {
            VVOpgiiOcdwWTmRgXuxBEQmAMZRA += 829690;
        }
        ulong neghmwVFxQuhlnmMZetfIn = 40675927567819355;
        ushort xeS = 56132;
        short nhUIdVGJnE = -23284;
        string yyLdaBZQEAm = "pwsMgxwyLQlk";
        string JDJwsBiR = "EMaSsoyLIHqNAmXghNHFHlAdPRyh";

    }
    public void gNiAzOa()
    {
        sbyte cimfEFJyjoLnkOClqs = -69;
        double BSpC = 1.587768E+28;
        if (BSpC == -1.357265E-36)
        {
            BSpC = Math.Pow(double.MinValue, double.MaxValue);
            object pXFcLCihROnIedUQJq;
            pXFcLCihROnIedUQJq = 4.47347E-25;
        }
        float BpIGmUD = -7.676695E-15F;
        ulong IRLGeWxPZhmPGyI = 59330522160082132;
        short kbsaYIEnMiixC = -12469;
        double wTanBchG = 3.044579E+10;
        double lTVePbBJCUozCu = -8.839629E+35;
        wTanBchG = Math.Floor(lTVePbBJCUozCu);
        try
        {
            int PBdThUMdqPgCukTdpxefGS = 3517796;
            if (PBdThUMdqPgCukTdpxefGS == 72768)
            {
                PBdThUMdqPgCukTdpxefGS++;
            }
            else
            {
                PBdThUMdqPgCukTdpxefGS--;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        long CZAeFzdNQMeWaAUZaEIefF = 10849639102556026;
        ulong iPdZJPEXiWNiDmOQyLZOeGGWsMd = 6434617389645421;
        byte VplaKVjSAkOpYB = 2;
        string QDjgHWMdmdVajsAEuDwOOuKxeTCpj = "GaIYukaonuBXySnRoSoMEX";
        int kxTObOwxTBy = 368026027;
        while (kxTObOwxTBy == 368026027)
        {
            kxTObOwxTBy = kxTObOwxTBy + 557177;
        }
        sbyte amRWShmEJb = -10;
        sbyte wqOXslmBYedWwtzdUaiA = 43;
        int uAaH = 19655381;
        if (uAaH == 400732)
        {
            uAaH = 356638;
        }
        ulong bzbWpROchNayOOBP = 32838420326955886;
        short zpkKJEGUxGTeSIUCVHz = 5018;
        float KYu = -2.699891E+13F;
        ulong OeEFLtzSzdyRTsUVWxbeo = 58885365136134785;
        short UQlICpAhoxKxEbNYJP = -29302;
        ushort ILuwsESXVSFiBDaIKtGyn = 49219;
        long ViXaPPRjSTmfRliMHk = 49013304021443979;
        double xawUcPBjHSifbw = -1.294376E+10;
        if (xawUcPBjHSifbw == 7.619439E+24)
        {
            xawUcPBjHSifbw = Math.Truncate(xawUcPBjHSifbw);
            Console.WriteLine(xawUcPBjHSifbw.ToString());
        }
        double kkIfRfNTUWk = -3.485576E+36;
        kkIfRfNTUWk = Math.Pow(double.MinValue, double.MaxValue);
        object gFOjwbunClyAPxKmLzbcGb;
        gFOjwbunClyAPxKmLzbcGb = -6.439781E+27;
        Console.WriteLine(gFOjwbunClyAPxKmLzbcGb.ToString().ToLower()); sbyte qoJaPhTRNefcjAmVdGFFEfiiSCLzj = -59;
        sbyte sFtUzpTPOcHCiPCBNXL = 85;
        float wkfAinywIzWAKFftxN = 3.821149E+22F;
        float AIacajLlDqOOjhOYg = 2.862459E-12F;
        ushort hGJfWuuBYebOU = 48080;
        uint gmmKwVFLVwXFzGhx = 129026;
        short qWd = 19190;
        short FmNaoxpzasfJZlaXjCyQbs = 28109;
        int NuxhjjytKqs = 912163241;
        while (NuxhjjytKqs == 912163241)
        {
            NuxhjjytKqs = 995198;
        }
        int qOhfbuMDsBKmphKDbTqQhIpo = 657550843;
        if (qOhfbuMDsBKmphKDbTqQhIpo == 419920)
        {
            qOhfbuMDsBKmphKDbTqQhIpo += 906128;
        }
        uint MfnD = 29387274;
        ushort zIfSZdcQlEBwJQIJzSjtwyg = 29179;

    }
    public void IBjUgWMzDsBDypSGicSuftWyFeOec()
    {
        short CIS = -9997;
        int VeHPWfyhgaDsNmuncUoENpciH = 209205;
        while (VeHPWfyhgaDsNmuncUoENpciH == 209205)
        {
            VeHPWfyhgaDsNmuncUoENpciH = VeHPWfyhgaDsNmuncUoENpciH + 599810;
        }
        double OmYkGimApy = -7.278668E-22;
        OmYkGimApy = Math.Ceiling(Math.Atan(-5));
        bool? HUpJIWNyJsth = new bool?();
        HUpJIWNyJsth = true; ulong CntP = 18328950674169514;
        uint ZcKMoHqpkQa = 524141;
        sbyte SxaUUkjoDZLn = 95;
        double aNKVjksiufLlcEPRVSwSqozFePO = -8.466706E+17;
        while (aNKVjksiufLlcEPRVSwSqozFePO == -6.472272E-05)
        {
            double TGWhAmGOjZg = -6.030952E-17;
            aNKVjksiufLlcEPRVSwSqozFePO = TGWhAmGOjZg / 3;
            Console.Write(aNKVjksiufLlcEPRVSwSqozFePO.ToString());
        }
        ushort mkBBjMAbFJLNuSScQnFcJCiAuEem = 57798;
        long ZoegtmxQDlcwgeOp = 77215144380937419;
        long bfGH = 27553056129543890;
        uint tycRHgbwGnJngzSyXQwpkqjV = 901939094;
        uint spZKAWSjABJEaHBsYZaypoBBpiGcn = 84;
        long dcpnZOjGJYyhSpERSXZU = 45302603078768844;
        ulong sIXWXEjdYkRRIpcszTblwjSRGwZA = 36855973293675762;
        byte saHPYPdjaNOgWypEBhPfqCFLntM = 245;
        string KlhDCaGGldOwwlMIKbDmkyaeFQw = "CFcfjecCYtVoYVWMqVgtYGKLwNL";
        byte cYLGKeHaJ = 57;
        short kJpfmop = 1456;
        short JKbXVVqKxuQoWukKoQpLJKQ = -20040;
        ulong tGizuLXppaENjLJZPWsVNWUDZAkD = 13930071782411857;
        uint ZesGekfDHGcKUTRSjyLGzUBukqgM = 215719;
        sbyte zSXnDgRKyyTGBuebapPfaUzeFYwO = -109;
        ushort wyekcWEpcGbibbVTQleMmxcXFtSJF = 48041;
        string ezyhxicfxaNBYMydJeF = "ZIMZugHJdVLpCweDF";
        ulong IiZolKDYSWPZAh = 41297519704194389;
        ushort Cpx = 63719;
        int VzWIXtZsAoRiPMoVkiaP = 79271539;
        while (VzWIXtZsAoRiPMoVkiaP == 79271539)
        {
            VzWIXtZsAoRiPMoVkiaP = VzWIXtZsAoRiPMoVkiaP + 99633;
        }
        ulong OWmFwkapdSkiIemiXgNIMHenYPZfs = 18320973924779049;
        byte EMZRtXRgECYbasglgRZGHkV = 244;
        sbyte tFHAKgLujWN = 75;
        long gIxEuWAByPy = 20838459187835614;
        string mBdSRpHhkzqfKAZPqEj = "ShRcXdenRfMeJLTgtLDGTslpf";
        int hgEAyCkNfJbV = 23366731;
        while (hgEAyCkNfJbV == 23366731)
        {
            hgEAyCkNfJbV += 741564;
        }
        byte YGSxGbEYBVBWqL = 238;
        sbyte HoDzYOzsQ = 72;

    }
}
public class BagESiuCohTxX
{
    public void lkheEcold()
    {
        uint LYaSudPljyAOXdh = 3979;
        float NSGkM = 8.032241E-16F;
        byte MeoXIfhkt = 176;
        float ejNP = 1.832415E-06F;
        byte xMU = 95;
        double GfNnodREAfiDgRVXXLXbJJ = 6.574458E-07;
        GfNnodREAfiDgRVXXLXbJJ = Math.Pow(double.MinValue, double.MaxValue);
        int? HjptfAOjxWdWmqnhYFOAW = 1993725;
        HjptfAOjxWdWmqnhYFOAW += 79539; ulong MgplZAdTFPfRmTJNkLtIfdmZW = 19818148130665686;
        short yymWPAqMc = -6993;
        string mfwO = "xhLIUqofiVXHNEsV";
        int oXOEhPqj = 930395;
        if (oXOEhPqj == 30442)
        {
            oXOEhPqj += 510407;
        }
        byte fqHEEgYRGEufpRIiGV = 27;
        float SZWqKMtoeUxyiyaocHiZXY = 4.976866E-09F;
        byte OnIygwtTmsKmUuFDBKXJhtITDn = 238;
        float UwCeRYeHIObdpkJFPNPuuyU = -13058.74F;
        ulong HPUSzCesWhidw = 46441388202379698;
        double NChytyBeCe = 0.0001793532;
        double MyHKtUzEYCYUkJBgqpeMUxdHYQ = 2288.371;
        NChytyBeCe = Math.Round(MyHKtUzEYCYUkJBgqpeMUxdHYQ);
        Console.Write(NChytyBeCe.ToString()); double XmUyJaAD = 3.606613E+24;
        if (XmUyJaAD == 96.37349)
        {
            XmUyJaAD = Math.Ceiling(Math.Cosh(5));
            Console.ReadLine();
        }
        uint jiegPCdmkSZQzKLthot = 66;
        ushort jJHYjL = 50496;
        int dFLk = 6624;
        if (dFLk == 205554)
        {
            dFLk += 928487;
        }
        byte WeFmGazldpXNbUziEUCymWNTZBgAM = 86;
        double ihmFbLFLptaNHXjsjuyquQ = 2.038547E-38;
        while (ihmFbLFLptaNHXjsjuyquQ == 6.093904E-18)
        {
            double MskFTHUgToRhUWZlb = -1.998095E+30;
            MskFTHUgToRhUWZlb = Math.Sqrt(3);
            ihmFbLFLptaNHXjsjuyquQ = MskFTHUgToRhUWZlb;
            MessageBox.Show(ihmFbLFLptaNHXjsjuyquQ.ToString());
        }
        short mPgLhSMTlxuIQxQ = -31299;
        float IFQ = 5.554194E+37F;
        string eoFOJGhTRjKJGMwJDhUqJyhkDSQxO = "FPdMcEgfDQlOYmgsknlV";
        byte fMoHgukRQMfiFUFTJ = 218;
        int FdeVzVekHCkTud = 35262494;
        while (FdeVzVekHCkTud == 35262494)
        {
            FdeVzVekHCkTud = 735964;
        }
        float aBJQIlNsFtsRWbHuilpakn = 6.515151E-23F;
        ulong kmxmwQDTdElJmSyoW = 58814746254305955;
        byte TBNZybfaBVsXCn = 12;
        double hAYy = 2.081078E+31;
        if (hAYy == 1.766872E+15)
        {
            hAYy = Math.Ceiling(Math.Sinh(-5));
            for (;;)
            {
                Console.WriteLine(-1.474707E+13);
            }
        }
        double sKbKzbTuDeegP = 9.176577E-23;
        sKbKzbTuDeegP = Math.Ceiling(Math.Cos(2));
        int nbtuOZtuLNxJQJ = 5651;
        if (nbtuOZtuLNxJQJ == 431480)
        {
            nbtuOZtuLNxJQJ = 973403;
        }
        string qFkCDofBYsHBYVHLnpRszVbYD = "yIJTMHsxKPjlxdok";
        ulong boLzW = 2627815409236674;

    }
    public void ZcSyReGai()
    {
        uint SCbTOdmg = 943095077;
        byte YMwAGAIcnlYmulStKzbgimeM = 88;
        byte HgpFoMmUMxFaC = 130;
        uint GEOADlUxAVgHLHJhtfaVXIKCgqfW = 45;
        uint JpziENRwmTftFHieOyH = 494632;
        int YTmtkfXsbwBXwhAEHoGIeCqWAibiH = 94924581;
        while (YTmtkfXsbwBXwhAEHoGIeCqWAibiH == 94924581)
        {
            YTmtkfXsbwBXwhAEHoGIeCqWAibiH += 507165;
        }
        short tHopCdXdJNW = -14687;
        float gUX = 1.278664E-05F;
        int TbePLkqwTfI = 26;
        while (TbePLkqwTfI == 26)
        {
            TbePLkqwTfI = 340808;
        }
        int tSRweUOQYlhudNZ = 598396;
        while (tSRweUOQYlhudNZ == 598396)
        {
            tSRweUOQYlhudNZ = 862609;
        }
        int QIoeGNzEGtYizcGZUXusi = 72387846;
        if (QIoeGNzEGtYizcGZUXusi == 268703)
        {
            QIoeGNzEGtYizcGZUXusi = 751187;
        }
        string QMFNi = "OQQ";
        sbyte BIDa = -104;
        int yZlHUznBeWLHsZwzP = 37366887;
        while (yZlHUznBeWLHsZwzP == 37366887)
        {
            yZlHUznBeWLHsZwzP += 849557;
        }
        byte QpRBj = 181;
        uint NodTiRgzJWSeiPdfjNtMhlxgcD = 15;
        ushort VklOFLqGGQmXHfaeVamMqxsNLCTXR = 40721;
        ulong cJbHTwjtOEhDzkGpgXIdVLJzTzcdR = 35148831075514536;
        ushort BQTYNoQnB = 60132;
        int UZKdqaDOusfCuPhAkpIlNMgnb = 91986708;
        while (UZKdqaDOusfCuPhAkpIlNMgnb == 91986708)
        {
            UZKdqaDOusfCuPhAkpIlNMgnb += 545558;
        }
        sbyte EUatjEXCGR = -90;
        long EXhpdjnpdhS = 14416062268659358;
        double QUgfaNLLgU = 252866.9;
        QUgfaNLLgU = Math.Pow(5, 2);
        bool? ajcxEG = new bool?();
        ajcxEG = true; double sEzofRCNQYG = 5.409518E+13;
        double McLclaKakouYCMXNKJbam = -2.267397E-35;
        sEzofRCNQYG = Math.Round(McLclaKakouYCMXNKJbam);
        MessageBox.Show(sEzofRCNQYG.ToString()); sbyte VnFWTMCkKZwjcoPIAJSW = 122;
        ushort Glp = 31261;
        short KDdRhOXNd = -11282;
        long ePxcJO = 34668009547506253;
        uint ZLDmjYZys = 9029;
        uint UxsiQUGFEECMWGogIHzlKOtOx = 123602435;
        ulong LoTlEMYdmtPWIxhaCntKqKNxohgdE = 3982837844926377;
        uint TqdwmKpbslNV = 75656781;
        string aDyWxFVAABbfcETsaVAt = "oANZfPRRR";
        byte MYR = 183;
        byte WnxFVNIjZOswUOnLuM = 16;

    }
    public void XqQdIJpbudNhgxYkWJtMf()
    {
        ulong bzxWx = 31094897453601130;
        uint WmyGQWakozPc = 72077820;
        short FhkPFlMTotB = 9930;
        uint QtNENgoAYjanhzHJlS = 32461098;
        double uKOKBEpywtLKIxp = -3.898745E+35;
        if (uKOKBEpywtLKIxp == -2.903174E-30)
        {
            double emlGgIViIqYcQ = -1.901205E-36;
            uKOKBEpywtLKIxp = emlGgIViIqYcQ / 3;
            bool? COHDyQktb = new bool?();
            COHDyQktb = true;
        }
        ushort mfO = 25851;
        float bGhszstzkZjawAMeHYVXUHeOK = 1.430924E+26F;
        short kZcJkoTfcymXzy = -14662;
        double lXpiAPzWXwBtJBBdbaagskj = 7.694956E+36;
        while (lXpiAPzWXwBtJBBdbaagskj == 1.423193E+11)
        {
            double QWNUaoLjFMmUsMuXNUyxnRwaN = -5.942998E-08;
            lXpiAPzWXwBtJBBdbaagskj = Math.Round(QWNUaoLjFMmUsMuXNUyxnRwaN);
            try
            {
                int QWDkLEMNGcN = 7651405;
                if (QWDkLEMNGcN == 53936)
                {
                    QWDkLEMNGcN++;
                }
                else
                {
                    QWDkLEMNGcN--;
                    Console.Write(QWDkLEMNGcN.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        double MhEfPWOQLJIiJjhS = 2.10483E-29;
        while (MhEfPWOQLJIiJjhS == -1.327567E+23)
        {
            MhEfPWOQLJIiJjhS = Math.Sqrt(4);
            int? HibmSZglAFxhKsdGFAaQRe = 191304;
            HibmSZglAFxhKsdGFAaQRe += 47779;
        }
        byte STDqOZLxPwwMVQWAGgYEj = 180;
        ushort tjbcIiPGIQAUpgMHltqYXN = 9847;
        ushort wEUBIBh = 29493;
        float EYIPGHPeeqbjzwssRtyOHcFUlGVf = -1.411074E-14F;
        short zjhJEFLsiJcfgk = -26377;
        uint pKOZdqC = 7565;
        int MKd = 98173343;
        if (MKd == 287066)
        {
            MKd = MKd + 258246;
        }
        long lIfFYZzOaBxXLHExwSGoQbL = 70444844318432875;
        byte CyfUztDUZCBpMth = 105;
        sbyte xHtYjXAftLs = -67;
        uint jziiyCWAdwRBkpNkgLtit = 100531;
        int iwsZRDNaQ = 25;
        while (iwsZRDNaQ == 25)
        {
            iwsZRDNaQ = iwsZRDNaQ + 625469;
        }
        ushort EYhKNisiFHUspGtGWogFBmTdAukB = 201;
        sbyte MQxbgwExmZQlVTJAATFcJAP = -16;
        short djsYS = -21703;
        ushort hDTFmjsTUFKbXkRVLHweelaZLb = 23417;
        ushort ohIOb = 46807;
        sbyte VHuKPGkNohStxmlNsOV = 9;
        float kRZPFycmWBLoQZawoGPmxUBaIb = 1.054875E+30F;
        ushort QFMbwDLaa = 49707;
        long ksIh = 78943896753325865;
        uint qZhEChQJLgEP = 462627;
        long FbCuJisBEK = 71359603694741243;
        byte TylEkDICFJHnljKLfdJhII = 253;
        float qUjozkBlZwhQYifCRVVcUmEQgZAwd = -1.443827E-21F;

    }
    public void uEUIylfygcmODUh()
    {
        float HQMePfepthAMehVjL = -2.134223E-09F;
        short dFQyWSZQnmRFTym = 217;
        short zPqdeGMbUqFRzNHeDlV = 8996;
        float eBeVIglLJK = -1.245641E+25F;
        double gaBjLUXJkxOeYPVa = 5.108785E+16;
        gaBjLUXJkxOeYPVa = Math.Floor(1.679634E+36);
        short GxslQsSDQLo = 21874;
        long tYCcHjBkSUtaSqRDFcefMXJ = 70135602193886780;
        long hizyJs = 23521080135158224;
        uint mfmMEawpYYyXMubPLULite = 693421922;
        double ptkKnJMdEKS = 871.8683;
        if (ptkKnJMdEKS == 6.788999E-27)
        {
            ptkKnJMdEKS = Math.Truncate(ptkKnJMdEKS);
            object nLcenKOkJRsWPsFujHlPQlo;
            nLcenKOkJRsWPsFujHlPQlo = -9.06849E-24;
        }
        uint OWcwlEMqURYwTHGeiKgwlITReGPiQ = 43468558;
        uint BCmkaAAzJmgxPqfOzbnbfNfdlp = 78485479;
        int juxCsesUhkIXDwMu = 2725;
        if (juxCsesUhkIXDwMu == 349028)
        {
            juxCsesUhkIXDwMu = 663941;
        }
        sbyte NOxjYKSLWhcMZmZa = -26;
        int dtijKqRasfhiClVOFJiVysWbus = 40;
        while (dtijKqRasfhiClVOFJiVysWbus == 40)
        {
            dtijKqRasfhiClVOFJiVysWbus += 10587;
        }
        ulong fgFENSgKBFOZCBezwslIxLyh = 67543058933285102;
        ushort gOjaWqOOSqmwRApETpPgsuK = 28996;
        ulong CLLxhIFPupouxV = 44221979643639903;
        sbyte jhsnuMdNmBPdc = -26;
        byte QcfZoATTmKBFDtVKEqm = 2;
        short uIlChWfQGzV = -12758;
        int MgfLnzbLlzkUGfA = 15597595;
        while (MgfLnzbLlzkUGfA == 15597595)
        {
            MgfLnzbLlzkUGfA += 652274;
        }
        ushort NsXOyebKlOyYylDMRpKxNqm = 20740;
        double TpMagQntssq = 430844.1;
        while (TpMagQntssq == -4.671714E+22)
        {
            TpMagQntssq = Math.Floor(2.961353E-30);

        }
        double KWxwzSNyBz = 1.23217E+11;
        while (KWxwzSNyBz == -8.624026E-13)
        {
            double cXzVTS = -6.558214E+29;
            KWxwzSNyBz = cXzVTS / 3;
            int? QxNWVMjoJOfHKIupLonkBX = 2986311;
            QxNWVMjoJOfHKIupLonkBX += 15681;
        }
        sbyte bWxmRCEgM = -27;
        uint SXxcFBi = 11749412;
        short DWWsfaOYctLytyduAZwNPFFSeOJV = 18770;
        double fMaTqViygXxxQh = 2.298996E-36;
        while (fMaTqViygXxxQh == 2.244996E-30)
        {
            double hYsdnqsTicYFMtENzp = Math.IEEERemainder(3, 4);
            fMaTqViygXxxQh = hYsdnqsTicYFMtENzp;
            object iOLELduIqJwiS;
            iOLELduIqJwiS = 2.113774E-18;
            Console.WriteLine(iOLELduIqJwiS.ToString().ToLower());
        }
        short DBJOIww = 31;
        long PWhQb = 57460979261701580;
        sbyte zlBBHMIDulisZ = -128;
        double WdKbHlUFlSBNPjhyEtjiVZdt = -6.882986E-10;
        WdKbHlUFlSBNPjhyEtjiVZdt = Math.Pow(double.MinValue, double.MaxValue);
        try
        {
            Console.WriteLine(WdKbHlUFlSBNPjhyEtjiVZdt.ToString());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        ulong LjIcmIobSWUlLhJHU = 43721720221939312;
        uint oejPQWOybYCnAHYsqWVGVCTTmGjow = 37734135;

    }
    public void MIaW()
    {
        long eoXLHJ = 7968378886221058;
        sbyte eOlqDjNzboFACSHbJkRHJkUjBN = 3;
        byte yHb = 242;
        float lLsFUDzKseUYlploVB = -1.245993E-23F;
        float bQQKAzFJDCKowqqGXdkBDfHOoWO = -6.243495E+15F;
        uint HKqKCOkcaeJCsoXV = 953524619;
        short uatsVjbuEKxYcccGdI = 20541;
        float bkxTEnAqaTjwXeHpZOqNQz = -8.049467E+11F;
        long plsSnhyRtPWAsWDc = 84355248859046510;
        string AeWDUOieXmZhGcXgLRuBwujNVA = "husQcOuItUQVip";
        byte odwliGYmFVEzeViIusaKGyXukwFlU = 236;
        byte hxUKBnmC = 106;
        sbyte hkWDyLiB = 83;
        short sSfbaObNsJKupJaAhg = -26569;
        uint BlPioSgBMw = 8842;
        int cEzn = 512263;
        if (cEzn == 553752)
        {
            cEzn = cEzn + 452106;
        }
        float UylbuMRpSGqSMVUlHmq = -1.606336E+16F;
        int WJSGYFNKssJXJoKaHcnkymGDEGyg = 1302;
        while (WJSGYFNKssJXJoKaHcnkymGDEGyg == 1302)
        {
            WJSGYFNKssJXJoKaHcnkymGDEGyg = WJSGYFNKssJXJoKaHcnkymGDEGyg + 503767;
        }
        short CgSLeVZBcYlX = 28664;
        byte xzuAJcpcshGukbQJiYpzB = 51;
        int CnfAFu = 200908;
        while (CnfAFu == 200908)
        {
            CnfAFu = 397463;
        }
        float Hpl = -3.463766F;
        int COAmocYHNilWnYwW = 456522620;
        if (COAmocYHNilWnYwW == 410074)
        {
            COAmocYHNilWnYwW = 314293;
        }
        ulong wNisZm = 49058597216994082;
        short CEpoIzIckuw = 7241;
        uint dlasSCUHHBLDWHYWoDhHgRaAzWf = 13;
        int RheDOzowOxVXQEfCaeoeSyVOm = 5282;
        if (RheDOzowOxVXQEfCaeoeSyVOm == 421405)
        {
            RheDOzowOxVXQEfCaeoeSyVOm = RheDOzowOxVXQEfCaeoeSyVOm + 783697;
        }
        uint JTu = 72874620;
        byte ahujlTjVtuebRBZ = 97;
        byte pDXwBsIwXhK = 184;
        long USeLdLDtbGBBqNIAJAhDOHAFIbDR = 50810624870742614;
        ushort pCOWCqVZbU = 49082;
        ushort kEgjmsAdbiLxYuT = 52122;
        sbyte JdujGORfiKIaIdAEbdE = 119;
        float XkntcADXbjSneueaYssh = -6.028269E+21F;

    }
}