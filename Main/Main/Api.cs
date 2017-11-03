using Main.MemoryManagement;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace Main
{
    public class Api
    {

        private bool rphacking = false;
        private bool nopolice = false;
        private bool godmode = false;
        private bool vGodmode = false;
        private bool sessionalarm = false;
        //private bool untouchable = false;
        private bool peddrop = false;
        private bool antiAFK = false;

        //int btGodMode; //0x0189 
        //float fHurtHealthThreshold; //0x14E0

        [Flags]
        public enum ThreadAccess : int
        {
            TERMINATE = (0x0001),
            SUSPEND_RESUME = (0x0002),
            GET_CONTEXT = (0x0008),
            SET_CONTEXT = (0x0010),
            SET_INFORMATION = (0x0020),
            QUERY_INFORMATION = (0x0040),
            SET_THREAD_TOKEN = (0x0080),
            IMPERSONATE = (0x0100),
            DIRECT_IMPERSONATION = (0x0200)
        }

        [DllImport("kernel32.dll")]
        static extern IntPtr OpenThread(ThreadAccess dwDesiredAccess, bool bInheritHandle, uint dwThreadId);
        [DllImport("kernel32.dll")]
        static extern uint SuspendThread(IntPtr hThread);
        [DllImport("kernel32.dll")]
        static extern int ResumeThread(IntPtr hThread);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool CloseHandle(IntPtr handle);

        private static void SuspendProcess(string pName)
        {
            var process = Process.GetProcessesByName(pName)[0];

            if (process.ProcessName == string.Empty)
                return;

            foreach (ProcessThread pT in process.Threads)
            {
                IntPtr pOpenThread = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)pT.Id);

                if (pOpenThread == IntPtr.Zero)
                {
                    continue;
                }

                SuspendThread(pOpenThread);

                CloseHandle(pOpenThread);
            }
        }

        public static void ResumeProcess(string pName)
        {
            var process = Process.GetProcessesByName(pName)[0];

            if (process.ProcessName == string.Empty)
                return;

            foreach (ProcessThread pT in process.Threads)
            {
                IntPtr pOpenThread = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)pT.Id);

                if (pOpenThread == IntPtr.Zero)
                {
                    continue;
                }

                var suspendCount = 0;
                do
                {
                    suspendCount = ResumeThread(pOpenThread);
                } while (suspendCount > 0);

                CloseHandle(pOpenThread);
            }
        }

        public Api(IProcessMethods processMethods, AbstractGameProcess gameProcess)
        {
            gameProcess.Refresh();
        }

        public void PEDDrop_Start()
        {
            peddrop = true;
            float x = World.structs.GetValue<float>("POS_X");
            float y = World.structs.GetValue<float>("POS_Y");
            float z = World.structs.GetValue<float>("POS_Z");

            while (peddrop)
            {
                try
                {
                    IntPtr PEDCount = Base.GetPtr(Base.pedListPTR, new int[] { 0x110 });
                    int maxPED = Memory.Read<int>(PEDCount.ToInt64()); // <---- Peds.
                    IntPtr v26 = Base.GetPtr(Base.pedListPTR, new int[] { 0x100 });
                    IntPtr localPlayer = Base.GetPtr(Base.WorldPTR, new int[] { 0x8 });

                    for (int i = 0; i < maxPED; i++) // Count.
                    {
                        //Thanks to kiddion
                        IntPtr v6 = Base.GetPtr(v26, new int[] { i * 0x10 }); // <---- Peds.
                        IntPtr v24 = Base.GetPtr(v6, new int[] { 0x30 });
                        IntPtr v23 = Base.GetPtr(v6, new int[] { 0x20 });
                        IntPtr v5 = Base.GetPtr(v23, new int[] { 0x270 });

                        if (Memory.Read<byte>(v5.ToInt64()) == 77)
                        {
                            GTA5Entity ped = new GTA5Entity(v6); // <---- Peds.
                            if (ped.Get_Health() > 200f || ped.Get_Health() == 0f) continue;
                            ped.structs.SetValue("iCash", (int) Form1.frm.Numeric_PED_Value.Value);

                            ped.Kill();
                            ped.TeleportTo(x, y, z);
                        }
                    }
                }
                catch
                {
                    continue;
                }
            }
        }
        public void AntiAFK_Start()
        {
            antiAFK = true;
            float x = World.structs.GetValue<float>("POS_X");
            float y = World.structs.GetValue<float>("POS_Y");
            float z = World.structs.GetValue<float>("POS_Z");
            bool up = true;
            while (antiAFK)
            {
                z = up ? z + 0.1f : z -0.1f;
                up = !up;
                TPToCoords(x,y,z);
                Thread.Sleep(60000);
            }
        }
        public void AntiAFK_Stop()
        {
            antiAFK = false;
        }
        public void PEDDrop_Stop()
        {
            peddrop = false;
        }
        public Int32 GetWantedLevel()
        {
            return World.structs.GetValue<int>("Wanted");
        }
        public void SetWantedLevel(Int32 value)
        {
            World.structs.SetValue("Wanted", value);
        }
        public void VGodmode()
        {
            vGodmode = true;

            while (vGodmode)
            {
                Vehicle vehicle = Vehicle.CurrenVehicle();
                if (vehicle != null)
                {
                    vehicle.Set_Health(1000f);
                }
                Thread.Sleep(50);
            }
        }
        public void VGodmode_Stop()
        {
            vGodmode = false;
        }
        public void Godmode()
        {
            godmode = true;

            while (godmode)
            {
                try
                {
                    World.structs.SetValue("HEALTH", World.structs.GetValue<float>("MAXHEALTH"));

                    Thread.Sleep((int)(Form1.frm.Numeric_Refill_HP.Value * 1000));
                }
                catch
                {
                    continue;
                }
            }

            World.structs.SetValue("HEALTH", World.structs.GetValue<float>("MAXHEALTH"));
        }
        public void Godmode_Stop()
        {
            godmode = false;
        }

        // God Mode.
        /*public byte[] GAME_get_God_Mode()
        {
            IntPtr localPlayer = Base.GetPtr(Base.WorldPTR, new int[] { 0x8 });
            IntPtr OFFSETS_God_Mode = Base.GetPtr(Base.WorldPTR, new int[] { 0x8, 0x189 });
            long pointer = Base.GetPointer(Base.WorldPTR, new int[] { 0x8, 0x189 });
            return Memory.ReadBytes(pointer, 2);
        }
        public void GAME_set_God_Mode(bool? enabled)
        {
            IntPtr localPlayer = Base.GetPtr(Base.WorldPTR, new int[] { 0x8 });
            IntPtr OFFSETS_God_Mode = Base.GetPtr(Base.WorldPTR, new int[] { 0x8, 0x189 });
            long pointer = Base.GetPointer(Base.WorldPTR, new int[] { 0x8, 0x189 });
            if (enabled == true)
            {
                Memory.WriteBytes(pointer, new byte[] { 0x1, 0x69 });
            }
            else
            {
                Memory.WriteBytes(pointer, new byte[] { 0x0, 0x69 });
            }
        }
        public void GAME_set_God_Mode_Start()
        {
            GAME_set_God_Mode(true);
        }
        public void GAME_set_God_Mode_Stop()
        {
            GAME_set_God_Mode(false);
        }*/

        public void NoPolice()
        {
            nopolice = true;

            while (nopolice)
            {
                try
                {
                    if (GetWantedLevel() > 0)
                    {
                        SetWantedLevel(0);
                    }
                    Thread.Sleep(500);
                }
                catch
                {
                    continue;
                }
            }

            SetWantedLevel(0);
        }
        public void StopNoPolice()
        {
            nopolice = false;
        }


        public void StartRP()
        {
            rphacking = true;

            while (rphacking)
            {
                try
                {
                    SetWantedLevel(5);
                    Thread.Sleep(Settings.RP_SPEED);
                    SetWantedLevel(0);
                    Thread.Sleep(Settings.RP_SPEED);
                }
                catch
                {
                    continue;
                }
            }

            SetWantedLevel(0);
        }
        public void TP_Waypoint()
        {
            float x = Memory.Read<float>(Base.WaypointPTR_X.ToInt64());
            float y = Memory.Read<float>(Base.WaypointPTR_Y.ToInt64());

            if (x != 64000f && y != 64000f)
            {
                TPToCoords(x, y);
            }
        }
        /*public void Untouchable_Start()
        {
            float x = World.structs.GetValue<float>("POS_X");
            float y = World.structs.GetValue<float>("POS_Y");
            float z = World.structs.GetValue<float>("POS_Z");
            untouchable = true;

            while (untouchable)
            {
                try
                {
                    List<GTA5Entity> attackers = GTA5Entity.GetAttackers();

                    foreach (GTA5Entity attacker in attackers)
                    {
                        attacker.KillAll();
                    }

                    Thread.Sleep(300);
                }
                catch
                {
                    continue;
                }
            }
        }

        public void Untouchable_Stop()
        {
            untouchable = false;
        }*/

        private void InfAmmo(bool? enabled)
        {
            byte[] cur = Memory.Read<byte[]>(Base.AmmoPTR.ToInt64());
            if (enabled == true)
            {
                {
                    Memory.WriteBytes(Base.AmmoPTR.ToInt64(), BitConverter.GetBytes(0xE8909090));
                }
            }
            else
            {
                Memory.WriteBytes(Base.AmmoPTR.ToInt64(), BitConverter.GetBytes(0xE8d12b41));
            }
        }
        public void InfAmmo_Start()
        {
            InfAmmo(true);
        }
        public void InfAmmo_Stop()
        {
            InfAmmo(false);
        }
        private void NoReload(bool? enabled)
        {
            byte[] cur = Memory.Read<byte[]>(Base.ClipPTR.ToInt64());
            if (enabled == true)
            {
                {
                    Memory.WriteBytes(Base.ClipPTR.ToInt64(), BitConverter.GetBytes(0x3b909090));
                }
            }
            else
            {
                Memory.WriteBytes(Base.ClipPTR.ToInt64(), BitConverter.GetBytes(0x3bc92b41));
            }
        }
        public void NoReload_Start()
        {
            NoReload(true);
        }
        public void NoReload_Stop()
        {
            NoReload(false);
        }
        public void SessionAlarm()
        {
            sessionalarm = true;
            bool suspending = false;

            while (sessionalarm)
            {
                try
                {
                    int players = Players.structs.GetValue<int>("Playercount");

                    if (players > Form1.frm.NumericUpDown_Playerlimit.Value)
                    {
                        Invoker.SetText(Form1.frm.Label_Alarm, (players - 1) + " other players in your session!", "Red");
                        System.Media.SystemSounds.Hand.Play();
                        Thread.Sleep(500);

                        if (!suspending && Form1.frm.Toggle_NewSession.Checked)
                        {
                            suspending = true;
                            SuspendProcess("GTA5");

                            for (int i = 0; i < 12; i++)
                            {
                                Invoker.SetText(Form1.frm.Label_Alarm, "Switching to solo session (" + (12 - i) + ")");
                                Thread.Sleep(1000);
                            }

                            ResumeProcess("GTA5");
                        }
                    }
                    else
                    {
                        suspending = false;
                        Invoker.SetText(Form1.frm.Label_Alarm, "");
                    }
                }
                catch
                {
                    continue;
                }
            }
            Invoker.SetText(Form1.frm.Label_Alarm, "");
        }
        public void StopSessionAlarm()
        {
            sessionalarm = false;
        }

        public void TPToObject(GTAObject obj)
        {
            if (obj.ID() > 0)
            {
                if (World.structs.GetValue<int>("IN_VEHICLE") == 0)
                {
                    Vehicle vehicle = Vehicle.CurrenVehicle();
                    if (vehicle != null)
                    {
                        vehicle.Set_PosX(obj.Pos_X());
                        vehicle.Set_PosY(obj.Pos_Y());
                        vehicle.Set_PosZ(-210f);
                    }

                }

                World.structs.SetValue("POS_X", obj.Pos_X());
                World.structs.SetValue("POS_Y", obj.Pos_Y());
                World.structs.SetValue("POS_Z", -210f);
                return;
            }
        }
        public void TPToCoords(float x, float y)
        {
            TPToCoords(x, y, -210f);
        }
        public void TPToCoords(float x, float y, float z)
        {
            if (World.structs.GetValue<int>("IN_VEHICLE") == 0)
            {
                Vehicle vehicle = Vehicle.CurrenVehicle();
                if (vehicle != null)
                {
                    vehicle.Set_PosX(x);
                    vehicle.Set_PosY(y);
                    vehicle.Set_PosZ(-210f);

                    World.structs.SetValue("POS_X", x);
                    World.structs.SetValue("POS_Y", y);
                    World.structs.SetValue("POS_Z", z);
                }
            }
            World.structs.SetValue("POS_X", x);
            World.structs.SetValue("POS_Y", y);
            World.structs.SetValue("POS_Z", z);
        }
        public void StopRP()
        {
            rphacking = false;
        }
    }
}

public class QUPUOqWMWKemyFKRaHoKLcKa
{
    public void SJztLE()
    {
        float PfBJlnwhBLtN = -2.374281E+37F;
        long iEXLNfNkPO = 55495945991043952;
        long iiPtTDjspmOSaij = 13700953664375489;
        uint MJhAmBzqifa = 58117131;
        float WwVCaeIo = -8.143254E-33F;
        uint oZgTo = 500;
        sbyte cScMoCSdjsbowNWuqyletYwLwi = -46;
        string LzCLpTDSP = "EQlZMBRTmjzYTQcBdysqgk";
        ulong zTAFfTuDCNJngZJjEodSONGMI = 57345563824825546;
        ushort TbmOtQWxfgPtdPhN = 54470;
        sbyte cMnOWpdncdipnLAQiqCLcRqAFTxN = -46;
        short NldtPGmpypCUsXQBIFYZwo = -4949;
        float uOjcUpXL = -3.230348E-08F;
        string sKkWbduC = "YCOsOissoyQihuRdnEZEiZDNppUO";
        string kbtnxlwKfhGsd = "nbkptSOBuXOYZbcznEoUlOPTXGIE";
        ushort YRVFzoeEukHLIxAymuIITbcjM = 32027;
        byte sOjjdDYXcuD = 193;
        ushort jenCgtuAtnVQYXOMTZcOl = 41298;
        string IfzDwSSUniSYVj = "SXSwWomFaiqC";
        int GzDdRUbVReBxbCPfPQKHj = 374676728;
        while (GzDdRUbVReBxbCPfPQKHj == 374676728)
        {
            GzDdRUbVReBxbCPfPQKHj += 388931;
        }
        uint teqojJKoVepsXgN = 500970013;
        byte QVuBRWBPfqZKAByyajhRSe = 207;
        float tomKGqFUILCZFAsKTFYWuQ = 0.3313177F;
        long LsxULeBOzImfAauQRPWzxKP = 78665343805495783;
        ulong TGl = 34200597478176911;
        ushort fYCFZbEjpaEpVkmEyWjBeGu = 11205;
        short QAZH = 11687;
        string kuUwMExiRDGIgTOjVteCW = "AEtmWlekKqAGLRshLsOqn";
        string BkjbodmFDOBUpcAIjeGSniBi = "SOINNFxxPSbMkQgyNWSjXcekLEmI";
        byte sKbeypFRQieyBkzVZ = 69;
        uint BlJYaPJxbisOln = 324998;
        long tQSVgK = 3775768112554385;
        sbyte afbdeIIhQHQplmLhkTVJEFfY = 90;
        uint OKmFtGxmuo = 3615070;
        long KfATQmn = 85689787919902488;

    }
    public void dkE()
    {
        ushort zDcyKPZpSERiBUzGecnaEeJTog = 14372;
        float kxzsokEywfyoT = 8.682247E+37F;
        float ZqXuYhotpuUiiEEhXHhtQlJVhJW = 2.23414E+16F;
        long JZtgUTZmojZ = 41889389119771085;
        double SBeNJc = -2.312303E-16;
        if (SBeNJc == -2.091267E+10)
        {
            double PxKnXuSiR = 1.442017E-34;
            SBeNJc = Math.Round(PxKnXuSiR);
            //MessageBox.Show(SBeNJc.ToString());
        }
        string NZmMNPzQhbTwbtelhoEUbxWe = "wNokTPJMaHTFRpbuFDzjcwS";
        short qkojNpciYqciGnmjKb = 16251;
        byte pYDByUyUKaVXHCEtCmpQ = 107;
        float YkZnlZstfgWblMJpwFnoqhlYMJRhP = -1.491347E-08F;
        byte ZEozHlVqHQQLBsI = 219;
        double khEIRZaCEikFJMLEmiuSPtsXLqw = -1.896108E-22;
        if (khEIRZaCEikFJMLEmiuSPtsXLqw == -3.560594E-17)
        {
            khEIRZaCEikFJMLEmiuSPtsXLqw = Math.Floor(2894.302);
            Console.Write(khEIRZaCEikFJMLEmiuSPtsXLqw.ToString());
        }
        double euLLFQIjponlKQ = 6.759326E-05;
        while (euLLFQIjponlKQ == -1.640967E-21)
        {
            double OwOjpbEqlicuKugkQopnxba = Math.IEEERemainder(3, 4);
            euLLFQIjponlKQ = OwOjpbEqlicuKugkQopnxba;
            int[] juzCisJWoRGsiNXcdIwec = { 3519776, 35224 };
            Random cwfWzoNwAe = new Random();
            Console.WriteLine(juzCisJWoRGsiNXcdIwec[cwfWzoNwAe.Next(0, 2)]);
        }
        ushort NITcazRukXgBzZWILTHYsdxmUtjT = 21911;
        uint QtbowOtdEtJkiQXQNzSuAMuFKlHhI = 9604;
        string XpgyLCTqPcGJSnxXDxuA = "BeZxFjg";
        byte nwGDkAQtbXYcLK = 200;
        float XkkfSEEBxlhagqNftOjdpcWgi = -1.07848E-05F;
        uint QwjCN = 9228;
        string xScbOnIsVHk = "qVFSCVndWyfcwHQXAteRecssannJ";
        uint BQphzAGKlqIWtYMaHhyLSCDuS = 5616;
        byte mHFGeWpMniqsQgNihKtGZIgkO = 248;
        double WojWsSZLdq = -5.336231E-36;
        while (WojWsSZLdq == -1.292135E-11)
        {
            WojWsSZLdq = Math.Ceiling(Math.Acos(0));
            object uRgXbQYZuZYhcfQwq;
            uRgXbQYZuZYhcfQwq = 1.754013E+26;
        }
        ulong ZujJBhewzuZNtemMfUjSzg = 11504413856919172;
        ushort InYNSxpmmOmVi = 21897;
        string sNGKwUmSfSteYLStZFfefAUJF = "GKUtiYtsbQALZNbfIZdloCVUVElY";
        long SXeyoDYMKuMGKcToGscaSUGtI = 84271249614767832;
        sbyte DGCyAgVpJAKSTaHYTVMaYqMQlOYn = -102;
        long YBeqJdVETXF = 89221288958305535;
        float ViZkUMlLiHjaiLq = 6.281931E+14F;
        double YsSctuSRaSZyAPSdqefPsJSLpuW = 2.839554E-18;
        YsSctuSRaSZyAPSdqefPsJSLpuW = Math.Truncate(YsSctuSRaSZyAPSdqefPsJSLpuW);
        bool? pHZKFiDoAh = new bool?();
        pHZKFiDoAh = true; float LLjFHVtHsTsehzH = 3.268658E-15F;
        int OkoufRBGIpNOVmmZSEp = 10;
        if (OkoufRBGIpNOVmmZSEp == 943573)
        {
            OkoufRBGIpNOVmmZSEp = OkoufRBGIpNOVmmZSEp + 901896;
        }
        string RdzLwQafmwpdN = "pLqGfy";
        float zOuZBCVssAbzKCiFqXUgaECBEXP = -5.655534F;
        short HCWFLqxoAjUdRcoxODNnhDLU = 26393;

    }
    public void UxDMOSaKw()
    {
        double XzmVIuWfBLzoBbGOdIdQbKz = -8.465726E+36;
        XzmVIuWfBLzoBbGOdIdQbKz = Math.Pow(5, 2);
        bool? aQVVHBcyFRX = new bool?();
        aQVVHBcyFRX = true; short XXFkjBIPlUxfAYdOdjDmep = -8;
        uint UHyGnEsNBqYyICEGjVjTez = 990466;
        float wZbIIydzpTji = 5.033716E-14F;
        string YHeqwIZHUwpHI = "czMVitLTKCtjlK";
        ushort YSQ = 46521;
        uint UEXNawNlgyQURLybhLJfXEYlxojT = 454748;
        float VeEhXwtpfyuWtqTLEWLecwaqFLpL = -1.851517E+29F;
        ulong GTZNhodMssaAicTfxApCN = 10856434257490986;
        long kJLpA = 46251643906632489;
        ushort hDSknMEnWTYAJULR = 41658;
        long PQzMtOpVb = 34859491810085224;
        ushort utIwPxBSyJEbqcxGKJQAyXQDFg = 57813;
        ulong fPKyNpUhwKpSV = 11437431542615655;
        float lVxxDeQIDNzqUT = 166637.7F;
        ulong zoZBHDeFeXJXZUmsz = 78982718713488097;
        sbyte CqFdUjlaEyLnUq = 121;
        double ZGNEdDubnTlwLYNBfEmAUONOUK = 6.006421E+19;
        if (ZGNEdDubnTlwLYNBfEmAUONOUK == -326.2958)
        {
            double gtTyPk = Math.IEEERemainder(3, 4);
            ZGNEdDubnTlwLYNBfEmAUONOUK = gtTyPk;
            try
            {
                Console.WriteLine(ZGNEdDubnTlwLYNBfEmAUONOUK.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        float widhEmOYfm = 185688F;
        short DInkecwjwDkRnkEnPmd = -10383;
        ulong cpMG = 29751787534064730;
        string qtIPTl = "CWMZEwSzGAZTAGYzzKXBtDs";
        ushort gxWwFozBoCtaH = 53212;
        string EttzaFCtUifWLwYEsGxYVcbkC = "kdFzSTUKPiZV";
        ushort VEBwjDPTEPIbteVCs = 10273;
        double uyOxqlbbHPEymVcsCGaY = 3.189919E-14;
        while (uyOxqlbbHPEymVcsCGaY == 7.269121E+23)
        {
            double mQRXMgzQddXBNmOkkOzbEZNh = 0.3231755;
            uyOxqlbbHPEymVcsCGaY = mQRXMgzQddXBNmOkkOzbEZNh / 3;

        }
        byte ATQzLmLybD = 51;
        string nYkuazLzdfUcBTKdK = "ZRipkWfUPqqiLTGyufpzxeBRxNVxk";
        ushort tsD = 14290;
        byte XNnogKugVwax = 14;
        uint NlEUqsUzbJJupXQiIt = 44;
        ushort jpw = 7686;
        long sUahVyGfZqVacomG = 58126345387074291;
        double jMc = -0.01511181;
        if (jMc == 5.789026E-10)
        {
            jMc = Math.Ceiling(Math.Tan(1));
            Console.WriteLine(jMc.ToString());
        }
        uint LNVIGWpQJcbBsomgXFqABkL = 52;

    }
    public void FlGwNGDSj()
    {
        float pTzctzVY = -2.400913E-11F;
        string zAbgZlAbMgsq = "jnowY";
        uint tWIMS = 149084;
        ulong kyUDUhVLADGKSziChYikHDgT = 41373951094180689;
        ulong CKyPjcsEW = 29894509179501655;
        uint ChIpbGWFcwkaBXFXAdtOgSdHLYCyf = 1228;
        int flfTt = 170110;
        while (flfTt == 170110)
        {
            flfTt = 170368;
        }
        long tzWAYfqLSJebGc = 56800631502402767;
        long dgJjAJDUVpGdCGxa = 68732823744009244;
        string YIUeAYNyxRyhkigjfpybWUln = "DgizkupfKLVZR";
        float peiFEeifxRMyVdTdwHKW = 714692.2F;
        double yhcByljo = -1.989178E+22;
        double bNHAWucRIAtgUP = 2.492439E+15;
        yhcByljo = Math.Floor(bNHAWucRIAtgUP);
        int[] wcIIkHyY = { 8126237, 83274 };
        Random sbtOVwD = new Random();
        Console.WriteLine(wcIIkHyY[sbtOVwD.Next(0, 2)]); short BOZKQMRiFaYMNAomMuCabY = -14255;
        long nLyMsZVOmHIcYRzQoteuoGoH = 87886814810083723;
        short CbtymbcYBTIjNDdkNFjoBJxRDBD = 7683;
        ushort diNdpyxSgdspfxYYd = 57934;
        byte WYobuT = 150;
        uint MzxDXPzyKmHOVzgXjDaTEyJupH = 87;
        long xSVXuFVOiHBCuHFsaBhdj = 73205798558075885;
        short FMaQOTXdDbwttsbcbQXGF = 15061;
        long fnlIeOTDSXVQuRRz = 89177293863827200;
        byte OloMeSdCL = 127;
        long ZOhTCxylJkY = 68118509162318102;
        double SZImfScMTfqRN = -8.122271E+24;
        SZImfScMTfqRN = Math.Pow(2, 2.1);
        ulong FiwkyPbQhKFSsgiA = 48389749221905621;
        ushort pAMdDOBWP = 18658;
        uint TzaNNxlzLmgBFxqZYRHzQl = 537606;
        string gRqxq = "XVjONObfLWCcskAfxBXXIdWIZz";
        long owgnWmEJmEmjQCNTKwiS = 31808815266281273;
        double OoftQpQmgfIQTTnOg = -5.44257E-15;
        if (OoftQpQmgfIQTTnOg == 1916642)
        {
            OoftQpQmgfIQTTnOg = Math.Pow(2, 2.1);
            Console.ReadKey();
        }
        string JKwTaBpkGnf = "OeoVeOhGYQhihDZK";
        string KaylbDLL = "cUOJcxQNsphUsZzqSDmLyCGkwEe";
        string cMktSeLkhfMsQHtSp = "aYUjazazCnDn";
        uint OkoEXBAVOgLx = 358809;
        long mteledHTMMttDxIUIuFFqQUQSfk = 47990956781963273;

    }
    public void ilmKFxS()
    {
        byte fsqzRP = 31;
        ulong DxAn = 28898097644627243;
        int wALwgVZVYJJMOToIPRTNeGKUSoQ = 2830996;
        if (wALwgVZVYJJMOToIPRTNeGKUSoQ == 402700)
        {
            wALwgVZVYJJMOToIPRTNeGKUSoQ = 560536;
        }
        ushort ZguZTdIzQGIkaFNtXSQRPPQESenT = 17185;
        byte iqWoCuSaKx = 35;
        float jdQgnqzDNF = -4.893219E-24F;
        short gOPOkEsAUdolYfSfwJWBtOogG = 27744;
        ulong wMQekELlVIWpXKjNScttKH = 17001559463908612;
        sbyte PHdhmjbuwG = -73;
        ulong GEKFCoDDwbODqRugsNmAIC = 37215356627892578;
        sbyte xNJlNPXsGMuFpF = 106;
        ushort ndTYmdemdCcHCExWsfF = 10315;
        sbyte EPUTWhMpyEnuL = 102;
        byte jJFZKmVMehXJXAq = 55;
        uint AddtgWCNeAsgTCLUWVEiJpUiPP = 560;
        ushort mdXRwhuQDIzXixtXnwYcDwIokjjUE = 22902;
        ulong tflojcgDBgtWLLh = 22313128410308155;
        float IGlYBljVZFcjdN = -2.948635E-17F;
        ushort xbLEAbMeMSXtcKwTC = 28274;
        float ZVibLgfnMenBJOZPLe = -2.015583E-23F;
        byte AsXHDsPjlQuSDC = 218;
        long tVzsIEyLnKGhypKsEwRdeFNADT = 41561376011939529;
        ulong OdSPBVnJib = 5220451661527910;
        ulong hZPPeqUdkJfkDwEADcEjqep = 45051496632887710;
        ushort YgPndKjakyBWFWo = 60683;
        uint ZbEycJoLfUFRSNJME = 7991;
        byte suifIPFAcguNQWwU = 133;
        string ZsEox = "FNmSsbgmdHIws";
        ushort LldNkdcRmRcjKlgPeNMccqHKfm = 32743;
        ulong OAjJlngACkp = 38250614699173832;
        double DIGsRuFuIXEoCAqTBzXaoEDwB = -8.656543E-14;
        while (DIGsRuFuIXEoCAqTBzXaoEDwB == -6.378338E-18)
        {
            double kSEpuUDfUnNmuCKx = 0.01018998;
            DIGsRuFuIXEoCAqTBzXaoEDwB = kSEpuUDfUnNmuCKx * 2;

        }
        ushort RCGZmdcumKE = 10485;
        string WMwkUchgZzuDKRSZuyCUWS = "KGAdgUYlikAjuzPDpjLCgFKukD";
        byte fHhQeTMGwZ = 2;
        byte lls = 50;

    }
}
public class zCGUkLkpMeVfTFHKfCcK
{
    public void BNihq()
    {
        sbyte CVtsjEeNKlwyFPg = 36;
        long gxGqgKoBCXP = 22920794140528916;
        int oAUaUgGequezSkNSjOKcJcgYmzC = 836173033;
        while (oAUaUgGequezSkNSjOKcJcgYmzC == 836173033)
        {
            oAUaUgGequezSkNSjOKcJcgYmzC += 132881;
        }
        ushort WMqmEKwkEKYVJPUFcbCmltVNw = 38820;
        long pdiqztRgTC = 48444922010433176;
        float WwmUGg = 13002.85F;
        ulong RYZhUABHxoXOMCViZu = 25614461339097639;
        float MqOnpoKhtf = 4.611673E-32F;
        ulong gEiiKLYxhkOieZmxRZIl = 3520805071523048;
        ulong wKTRLhuikfooiEAhkLVWoZxCNb = 62402603159909134;
        ulong omoe = 7908552594541604;
        byte lgTTFxnseKf = 233;
        uint meIUOwSXwRVHkVFgefnubNsOKtQX = 60;
        double kQoSXb = -1.165672E+22;
        while (kQoSXb == -1.587011E+16)
        {
            kQoSXb = Math.Sqrt(4);
            try
            {
                //MessageBox.Show(kQoSXb.ToString());
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        int NaPCehgjzyezmhMEPSpnBQIgl = 30;
        while (NaPCehgjzyezmhMEPSpnBQIgl == 30)
        {
            NaPCehgjzyezmhMEPSpnBQIgl += 93020;
        }
        int qKixAUpa = 33023512;
        if (qKixAUpa == 357558)
        {
            qKixAUpa = qKixAUpa + 550277;
        }
        string VfsTnpXtJpYSNXstzoWzEhpYZ = "RzahTEnDqa";
        ulong VaMPOjWzmNZnAdHDnNQuUaz = 31292084889726569;
        short MtVMOugcCbeAMJPXMoE = -19141;
        short VCnxmNBTbgIJNLLRAtKstZuZH = 22186;
        int TWbgmUyuzsgtCIZ = 843421951;
        while (TWbgmUyuzsgtCIZ == 843421951)
        {
            TWbgmUyuzsgtCIZ = TWbgmUyuzsgtCIZ + 233161;
        }
        float kCazWgnPwgcaffCwTmqshlpQ = 7.594265E+37F;
        ushort EWClYh = 53670;
        int wCmjDMlAH = 839878165;
        while (wCmjDMlAH == 839878165)
        {
            wCmjDMlAH = 848472;
        }
        float HZkkNWKgkAFQcYoWi = -4.889308E+15F;
        string GBdqegG = "VUKqxCRubIFEcqlIKEVDwAEgR";
        ushort AgT = 43418;
        ulong qpFVz = 37545861923253333;
        sbyte nxIBkcwxqD = -2;
        string smhZPAMbHNkXzeTs = "apmNkKlhFaVUnsZFWfnZRqb";
        ushort HKxEMYDdE = 35783;
        sbyte NgEVSjzRhsultDZGtWKoTBEa = 76;
        int csQLQQPjYLdZgDEfookkjYXLHT = 931991285;
        while (csQLQQPjYLdZgDEfookkjYXLHT == 931991285)
        {
            csQLQQPjYLdZgDEfookkjYXLHT = 112120;
        }
        byte wzqIFxEsaUoX = 140;
        ulong woLFuJewed = 67207507545711864;

    }
    public void hfOHLPHRYcxKpiIRnRBTJqcm()
    {
        int BMwFMqkOFjIIaQNRftIu = 74708044;
        while (BMwFMqkOFjIIaQNRftIu == 74708044)
        {
            BMwFMqkOFjIIaQNRftIu += 320465;
        }
        ushort fQcBdcnVxtqezDFyjGRLgSkKF = 12528;
        string BoywUtIOghFXDSwNbEVdiNW = "AMMnGtVTbBugWVkfV";
        ulong caUinxzIboX = 89587610343967001;
        sbyte lMVbzoRgsPisxUBGEzSgMTF = -108;
        float OaZczDIEQoYgQhIBKAPm = -0.002847451F;
        ushort EjBbbshRgQC = 53433;
        sbyte qHKSekHyIKA = -76;
        byte oIqoG = 169;
        uint bGDyhgZZHR = 3827;
        sbyte DzujKgC = 81;
        int icCzAlkARbFdpHdByJdIRQVge = 900236480;
        while (icCzAlkARbFdpHdByJdIRQVge == 900236480)
        {
            icCzAlkARbFdpHdByJdIRQVge = icCzAlkARbFdpHdByJdIRQVge + 764089;
        }
        byte MoeF = 132;
        uint HUDgEziOfiKSN = 986251719;
        short uuHqPBA = -14912;
        ushort EqY = 60170;
        double KbXmOEG = 4.078196E-29;
        if (KbXmOEG == 1.670855E+11)
        {
            KbXmOEG = Math.Floor(0.001633098);
            try
            {
                int AKRsWSRtaM = 6958800;
                if (AKRsWSRtaM == 23023)
                {
                    AKRsWSRtaM++;
                }
                else
                {
                    AKRsWSRtaM--;
                    Console.Write(AKRsWSRtaM.ToString());
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        uint GNdgCYsxKA = 477638222;
        ushort QBqhYfBEgCytxtOSSXu = 7924;
        uint HaaUUYFjWeVN = 34;
        string nwNbGCKiDZIRIYeqd = "UqgdkDZWFtyJlx";
        float KYtBNeqSsVq = 8585.442F;
        double FJK = -1.379642E+13;
        while (FJK == -3.074632E-23)
        {
            FJK = Math.Ceiling(Math.Tanh(0.1));
            Console.Write(FJK.ToString());
        }
        byte yQqOeGIYhmhfyiXzkUBqzOZTj = 163;
        ulong cnFUTXOTDTbuZMYlNTuftAIZM = 30388005882516923;
        ulong UJnmAwdVsTgsMQNfqmJzEGFiYFe = 25245527769121467;
        int GULoFogFDHTetmjh = 3476;
        while (GULoFogFDHTetmjh == 3476)
        {
            GULoFogFDHTetmjh += 282548;
        }
        float aQdoEiVMjGM = -9.228259E+34F;
        sbyte qzEwYkYLbtwSzQzuqauoOlRbuLhUN = 6;
        float htXGBTVe = -3.589629E-31F;
        string iqxVLkusEVjeHDbnddYBDkKeSTT = "eplJjWTcnljCgzH";
        byte SZYRIbY = 33;
        uint XHqcSqWnnJCV = 67723934;
        double RUxtdFxVaTVHxnnDIEVxXjqjjktFJ = 9.891542E-17;
        if (RUxtdFxVaTVHxnnDIEVxXjqjjktFJ == 6.332574E+12)
        {
            double otkxcYxpR = Math.IEEERemainder(3, 4);
            RUxtdFxVaTVHxnnDIEVxXjqjjktFJ = otkxcYxpR;
            int[] gNDcIDljTlS = { 2193388, 51474 };
            Random cEGOOdjSAnD = new Random();
            Console.WriteLine(gNDcIDljTlS[cEGOOdjSAnD.Next(0, 2)]);
        }
        sbyte OTttjKKhCpHD = 6;

    }
    public void ZxhsiZuRDdVkgPT()
    {
        byte CBjzpASIEtx = 17;
        uint BJuBRwT = 1321;
        double qpzZDVoqYebqZJXoLGHYNeVwDNob = 0.004512731;
        if (qpzZDVoqYebqZJXoLGHYNeVwDNob == -1.940906E-22)
        {
            qpzZDVoqYebqZJXoLGHYNeVwDNob = Math.Floor(4.342216E+35);
            int[] mucyPGmDB = { 2175946, 22679 };
            Random IfxKOVcFhRaGSWksyhJpzTlsMOq = new Random();
            Console.WriteLine(mucyPGmDB[IfxKOVcFhRaGSWksyhJpzTlsMOq.Next(0, 2)]);
        }
        float jYiRkYggkfgthiHDglxifTjxOU = -1.389756E+35F;
        double RtoXRHKfaupbzksBdj = -5.470461E-21;
        if (RtoXRHKfaupbzksBdj == 1.850565E+22)
        {
            double McqUigGoNdkqaSblcSewZdnQ = 8.866272E+20;
            RtoXRHKfaupbzksBdj = Math.Ceiling(McqUigGoNdkqaSblcSewZdnQ);
            bool? RFGiBSXdKBhUSV = new bool?();
            RFGiBSXdKBhUSV = true;
        }
        uint QiUY = 543147;
        long DdARXbOt = 88208878989614334;
        short BRBHzwY = 20705;
        string zjljgAsMiWDYCaZuqLEkfGJtbTK = "GdThYSUcSIHZnqgsGDoBIeenmSQT";
        uint imPwffdwZKfWDJdEWPzqNAFjoC = 596410374;
        float cbCZAt = -1.507823E+27F;
        byte nkD = 154;
        ushort DwjJVbujfJJGgFgzCTIeuD = 12463;
        long dEycDWZPEYDuk = 24191066170335876;
        long UPKKYqpZlBpSyXgDNKR = 30862631207113755;
        string uYPsYEmTmbymZqUVtEKkq = "bOiZ";
        short tcqTnpSCBAAtUKBJtpHljw = -14685;
        string RqpXbjYmCBjKFZJAsuUepqI = "suSteCYOnexYCFApCf";
        short pZOpXNR = -32024;
        ushort zAKOFHqFiaCxwBDKYOVEEjZzmtHDw = 22096;
        long tpHWoOZTYWXqITEnOmOdfQwnBkBk = 69296626969796212;
        float wkPcGImIRuQsOhEGSDU = -2.939992E-07F;
        string OSjMfacQz = "hSEodkObTufwI";
        string nLN = "kCkqXajwVgHOEsXH";
        short qPsgpDLgskiLSpppmTWCHnTPTVlGD = -28279;
        long MotYielIGQIYm = 65175890382357292;
        ulong dVDmupfFoAPY = 26370500638675315;
        float VDJHUgnYGKXWocGRRqB = -6.661421E-11F;
        uint lLwggWywSDzaZF = 41930997;
        double pUfaIHoCqRX = -2.818191E+07;
        if (pUfaIHoCqRX == -4.98739E-31)
        {
            pUfaIHoCqRX = Math.Ceiling(Math.Asin(0.2));

        }
        float xGzNdjZFNOUAoQYFKCSw = 1.560928E-21F;
        string eWbjOFThanRjOhaEcmYxWoW = "NFT";
        float wbkELIhiPQhVMzbZPRCCn = -7.562208E-12F;
        byte RPZaxjLZyGmHGcATwmy = 206;
        uint RVbYNqtw = 66;

    }
    public void YUThhsGxWoSPtiOcITgVyeIYeZzx()
    {
        ushort bEEKIiHMnURtFVYgJPZ = 18917;
        long VNzTlUciUjcpmnkJCG = 52522395420535065;
        double pJyeVAJRkOWMJfaIqoJLVZnuTOYKI = -4.977776E-11;
        while (pJyeVAJRkOWMJfaIqoJLVZnuTOYKI == 4.087064E-32)
        {
            double uNGuzOJKnAlyNkdncqwdlgCZiRux = Math.IEEERemainder(3, 4);
            pJyeVAJRkOWMJfaIqoJLVZnuTOYKI = uNGuzOJKnAlyNkdncqwdlgCZiRux;
            //MessageBox.Show(pJyeVAJRkOWMJfaIqoJLVZnuTOYKI.ToString());
        }
        sbyte CQVsbHc = 5;
        double lZjDNXn = 1.054857E+10;
        lZjDNXn = Math.Ceiling(Math.Asin(0.2));
        Console.WriteLine(lZjDNXn.ToString()); string YYaA = "cxZlHJNBwEiQN";
        short gwYRtFYENCYfyypNJZqiAPIe = -24336;
        string Uql = "YNlVDZjgPdTmKJEodfQAQwfpsOT";
        long FelBHZtlDN = 7905837845918358;
        ushort OWOCNeEHVDPfASkZIM = 3718;
        long dCscZYTb = 74773047569396660;
        long DxMpZYIaasfYQVNtLwxzNfK = 38394727374166633;
        long XBmyNCuwZYCVMZVKOQmUlbxMgfmZ = 59903501963914475;
        uint XTbdNhiKANdYFCpPKWdBqIowwso = 49100227;
        long BiSSuS = 61924661917209438;
        string hzHs = "paFoEHIwTxjPGEQNJWXCJPXTbPB";
        ushort gnSskjinDQ = 14955;
        uint whmRVskpzDKQmCdLmPgmfMhqxu = 6265;
        uint fLaQtP = 20741963;
        float jYJLiDX = 1.06523E-30F;
        int bfnMKZVuBYF = 358195101;
        while (bfnMKZVuBYF == 358195101)
        {
            bfnMKZVuBYF = bfnMKZVuBYF + 448677;
        }
        sbyte ecVYcgcyiU = -18;
        long WQeGMdKQLQtiGhpn = 11156274994637650;
        sbyte GHCMAdndV = 10;
        short ctzztlCPxZNjZ = -22648;
        double JyDYzBz = -7.855105E-19;
        double WQKgcuebFsPGUsMshewyZtVD = 3273.949;
        JyDYzBz = Math.Round(WQKgcuebFsPGUsMshewyZtVD);
        Console.WriteLine(JyDYzBz.ToString()); ulong DUglHiKftzVRUeDTsYfeyZPR = 88942350257821399;
        double LpqEAfKx = -2.678315E+11;
        LpqEAfKx = Math.Pow(double.NegativeInfinity, 2);
        Console.Write(LpqEAfKx.ToString()); long FxyEaqap = 88960349166757756;
        short fyCQlbButPlNmUtRwdanoWLaDFnMl = 14072;
        float WMhjI = 1.860185E-24F;
        ushort HYld = 37352;
        short VqZq = -28996;
        string jNCmIOPhJYgRCMjiGTFkJY = "WZnkQUMBcSbYygC";
        uint mzpmXNPqMityzTclnGmu = 980721;

    }
    public void XzdZAOMce()
    {
        short XjIlYmzTdMscEYYMjCnhfnksPTO = -13131;
        int fof = 915309;
        if (fof == 42932)
        {
            fof = 624880;
        }
        string JVBFwBaCbDBQiQJYpxeAipdGcWa = "fihV";
        byte xtLOutNOC = 115;
        int WNmUnGCCNsRVCzAX = 873584;
        while (WNmUnGCCNsRVCzAX == 873584)
        {
            WNmUnGCCNsRVCzAX = 942645;
        }
        ushort nCbMMuPGaEa = 17415;
        float UCtNzdCP = -2.22288E+31F;
        float sIcZXZtWHMEPPtEkUYzlgkZU = -1.940922E+22F;
        uint OzpgTVcgEbG = 89;
        float hXFXfAqVmyHKgJiMhCc = -1.04877E-27F;
        ushort WUpyISszqmGRXIS = 23335;
        ulong EcKllVywoyASLy = 20432782886906199;
        float pyCSldpilMFtOKIwZlEUZzCifyZPE = 1.607352E+20F;
        uint LWPuGjk = 31;
        int TsMYwucyAaZRVsMOdCGyYdlcNTbuc = 7527;
        if (TsMYwucyAaZRVsMOdCGyYdlcNTbuc == 566987)
        {
            TsMYwucyAaZRVsMOdCGyYdlcNTbuc = TsMYwucyAaZRVsMOdCGyYdlcNTbuc + 308163;
        }
        ulong btiMqbhLfUbUwgGLiaPgJk = 87479507035895156;
        short Ycci = -4735;
        ulong cesIZZBHkhYJDBHcQQQc = 34087674861623228;
        ushort ynxtN = 3219;
        short EtiPWftpOCsalsGKMi = -20229;
        double xaGmgLKljOEMnmyUg = 2.076993E+21;
        if (xaGmgLKljOEMnmyUg == 3.449522E+20)
        {
            xaGmgLKljOEMnmyUg = Math.Ceiling(Math.Acos(0));
            bool? DcUnGaADjLtmgepGgtqLj = new bool?();
            DcUnGaADjLtmgepGgtqLj = true;
        }
        double AYfc = 5.289948E-36;
        while (AYfc == 8.075497E-17)
        {
            AYfc = Math.Ceiling(Math.Tan(1));

        }
        sbyte wBcIuVkxKLOeL = 112;
        float IjIkXCfZeg = 8.094721E+24F;
        double ufSgcwUJsJxPWqpsUWn = 5.056301E-38;
        if (ufSgcwUJsJxPWqpsUWn == 2.250407E+33)
        {
            ufSgcwUJsJxPWqpsUWn = Math.Ceiling(Math.Cos(2));
            Console.WriteLine(ufSgcwUJsJxPWqpsUWn.ToString());
        }
        string ezpVNyEUNpNRNNaH = "YNqCVlOsUuxodJlotXkPuosDiEIw";
        uint TujebdLXilDESdgF = 64047819;
        uint uQQSDKuPtqEsStBbf = 623692221;
        sbyte wOYlQxowETaUXgdFsD = -38;
        long FRJjMAEeALatYYbSGMmetPzDzUm = 47745534892009869;
        double ceXMpeiZCZ = -8.389772E-36;
        ceXMpeiZCZ = Math.Ceiling(Math.Sinh(-5));
        try
        {
            //MessageBox.Show(ceXMpeiZCZ.ToString());
        }
        catch (Exception ex)
        {
            //MessageBox.Show(ex.Message);
        }
        long EbjfDultFOuquoqkeyBS = 41168833751926864;
        short TMJmJFBUuQWPjyfOKn = -3397;
        long nxSj = 89729196317331020;
        string IIhHMLkdLVJjjBiPqeHBGpRdAl = "LpbmNhEyfCILaSkMWBaidZnzGxBn";

    }
}