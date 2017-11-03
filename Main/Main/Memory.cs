using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Main.MemoryManagement;

namespace Main
{

    static class Memory
    {
        #region Declaration Stuff
        static readonly int PROCESS_WM_READ = 0x0010;
        const int PROCESS_VM_WRITE = 0x0020;
        const int PROCESS_VM_OPERATION = 0x0008;
        public static Process p;
        public static Api api = null;

        public static IntPtr ImageBase()
        {
            if (!isRunning())
            {
                return (IntPtr)0x0;
            }
            IntPtr baseAddress = p.MainModule.BaseAddress;
            return baseAddress;
        }
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, long lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);
        [DllImport("kernel32.dll")]
        internal static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, IntPtr nSize, ref UInt32 lpNumberOfBytesWritten);
        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true)]

        public static extern short GetAsyncKeyState(int vKey);
        #endregion
        #region Read/Write Memory
        //READ
        public static byte[] ReadBytes(long address, Int32 bufferSize)
        {
            if (!isRunning())
            {
                Form1.frm.Init();
                return null;
            }
            IntPtr processHandle = OpenProcess(PROCESS_WM_READ, false, p.Id);

            int bytesRead = 0;
            byte[] buffer = new byte[bufferSize];

            ReadProcessMemory((int)processHandle, address, buffer, buffer.Length, ref bytesRead);

            return buffer;
        }
        public static T Read<T>(long address, int len)
        {
            try
            {
                int size = Marshal.SizeOf(typeof(T));
                byte[] buffer = new byte[len];
                int read = 0;
                IntPtr processHandle = OpenProcess(PROCESS_WM_READ, false, p.Id);
                ReadProcessMemory((int)processHandle, address, buffer, len, ref read);
                GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
                T data = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
                handle.Free();
                return data;
            }
            catch (Exception)
            {
                return default(T);
            }
        }
        public static T ReadOld<T>(long address, Int32 bufferSize)
        {
            if (!isRunning())
            {
                Form1.frm.Init();
                return (T)Convert.ChangeType("0", typeof(T)); ;
            }
            IntPtr processHandle = OpenProcess(PROCESS_WM_READ, false, p.Id);

            int bytesRead = 0;
            byte[] buffer = new byte[bufferSize];

            ReadProcessMemory((int)processHandle, address, buffer, buffer.Length, ref bytesRead);

            switch (Core.GetGenericType(new Dictionary<int, T>()))
            {
                case "single":
                    return (T)Convert.ChangeType(BitConverter.ToSingle(buffer, 0), typeof(T));

                case "string":
                    return (T)Convert.ChangeType(System.Text.Encoding.UTF8.GetString(buffer), typeof(T));

                case "int32":
                    return (T)Convert.ChangeType(BitConverter.ToInt32(buffer, 0), typeof(T));
                case "int64":
                    return (T)Convert.ChangeType(BitConverter.ToInt64(buffer, 0), typeof(T));
                case "byte":
                    return (T)Convert.ChangeType(buffer[0], typeof(T));
                case "byte[]":
                    return (T)Convert.ChangeType(buffer, typeof(T));
                default:
                    MessageBox.Show("Default" + Environment.NewLine + Core.GetGenericType(new Dictionary<int, T>()));
                    return (T)Convert.ChangeType("0", typeof(T));
            }
        }
        public static T Read<T>(long address)
        {
            try
            {
                int size = Marshal.SizeOf(typeof(T));
                byte[] buffer = new byte[size];
                int read = 0;
                IntPtr processHandle = OpenProcess(PROCESS_WM_READ, false, p.Id);
                ReadProcessMemory((int)processHandle, address, buffer, size, ref read);
                GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
                T data = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));

                handle.Free();
                return data;
            }
            catch (Exception)
            {
                return default(T);
            }
        }
        //WRITE
        public static void WriteNops(long address, int amount)
        {
            byte[] nops = new byte[amount];
            for (int i = 0; i < amount; i++)
            {
                nops[i] = 144;
            }
            WriteBytes(address, nops);
        }
        public static void WriteBytes(long address, dynamic val)
        {
            if (!isRunning())
            {
                Form1.frm.Init();
                return;
            }

            bool success;
            UInt32 nBytesRead = 0;
            byte[] value = null;

            try
            {
                 value = BitConverter.GetBytes(val);
            }
            catch
            {
                 value = val;
            }
            success = WriteProcessMemory(p.Handle, (IntPtr)address, value, (IntPtr)value.Length, ref nBytesRead);
        }
        public static void WriteInt(long address, int value)
        {
            if (!isRunning())
            {
                Form1.frm.Init();
                return;
            }
            bool success;
            byte[] buffer = BitConverter.GetBytes(value);
            UInt32 nBytesRead = 0;
            success = WriteProcessMemory(p.Handle, (IntPtr)address, buffer, (IntPtr)4, ref nBytesRead);
        }
        public static void WriteFloat(long address, float value)
        {
            if (!isRunning())
            {
                Form1.frm.Init();
                return;
            }
            bool success;
            byte[] buffer = BitConverter.GetBytes(value);
            UInt32 nBytesRead = 0;
            success = WriteProcessMemory(p.Handle, (IntPtr)address, buffer, (IntPtr)4, ref nBytesRead);
        }
        public static void WriteShort(long address, short value)
        {
            if (!isRunning())
            {
                Form1.frm.Init();
                return;
            }
            bool success;
            byte[] buffer = BitConverter.GetBytes(value);
            UInt32 nBytesRead = 0;
            success = WriteProcessMemory(p.Handle, (IntPtr)address, buffer, (IntPtr)2, ref nBytesRead);
        }
        public static void WriteByte(long address, byte value)
        {
            if (!isRunning())
            {
                Form1.frm.Init();
                return;
            }
            bool success;
            byte[] buffer = BitConverter.GetBytes(value);
            UInt32 nBytesRead = 0;
            success = WriteProcessMemory(p.Handle, (IntPtr)address, buffer, (IntPtr)1, ref nBytesRead);
        }
        #endregion
        public static bool isRunning()
        {
            try
            {
                p = Process.GetProcessesByName("GTA5")[0];
                if (api == null && p != null)
                {
                    api = ApiFactory.Create(new GameProcess(p, false));
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

public class pRGTlZLGCJsHQloCuHCYeLcTNaiU
{
    public void CqmHLabcyfuOQxezIjCVxyConS()
    {
        int MflRRMZsfZfknAXChjonYwe = 628943341;
        if (MflRRMZsfZfknAXChjonYwe == 93853)
        {
            MflRRMZsfZfknAXChjonYwe = 792677;
        }
        double SwmpqTDWeyMt = 3.858514E-33;
        if (SwmpqTDWeyMt == 1.579407E+33)
        {
            SwmpqTDWeyMt = Math.Pow(5, 2);
            try
            {
                int hImQajGIFmjRlcyMpp = 8326510;
                if (hImQajGIFmjRlcyMpp == 49639)
                {
                    hImQajGIFmjRlcyMpp++;
                }
                else
                {
                    hImQajGIFmjRlcyMpp--;
                    Console.Write(hImQajGIFmjRlcyMpp.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        long UsERtBDoEKUDNpOswXOCkok = 30425317149814747;
        float OLxmwWCVKMOyCdlwTFTMf = 845449.1F;
        sbyte JZlAzgPdTZF = -38;
        sbyte blGBDyPIpcIXSaeDkfnWNXpxlGYuI = -111;
        long OGSB = 29157377775903289;
        float oOZqPzeimeWjnXzw = 1.047043E-19F;
        ushort imiEcieEuMnfFLpjuqo = 10764;
        double sOFpOdlgcwPlscGwnGu = 2.184725E+20;
        while (sOFpOdlgcwPlscGwnGu == 3.714007E+23)
        {
            sOFpOdlgcwPlscGwnGu = Math.Ceiling(Math.Tan(1));
            MessageBox.Show(sOFpOdlgcwPlscGwnGu.ToString());
        }
        uint McxlbiEt = 28;
        ushort NFgtEDyumpZaoybdnfRhewce = 52379;
        byte cQRtDDLAGmqyaSd = 240;
        ushort wWFg = 32555;
        sbyte ymKs = 5;
        string tduExWxzFYxRWIQpaz = "bunUVpLsfoahdkOdXyAB";
        uint WsGKJiuIXKUUZifiAnLF = 1742;
        int tGiETSBXgwyVokICXyspnjlFY = 96466149;
        while (tGiETSBXgwyVokICXyspnjlFY == 96466149)
        {
            tGiETSBXgwyVokICXyspnjlFY = tGiETSBXgwyVokICXyspnjlFY + 300490;
        }
        ulong PqcaRPejWNFLjUnGjHTQmDi = 5800737952635084;
        sbyte hAUGCgJngqxIUOUKHGnxX = 2;
        byte IxlLjVP = 134;
        uint cwu = 66;
        uint DglNNKRk = 65;
        uint KNHmMXeUYelDUhTMApGXNkuuawVM = 495879;
        double mEPmwhJcE = 1.02592E-19;
        while (mEPmwhJcE == 2.823061E+13)
        {
            double MUcFkzs = 1.166688E+07;
            mEPmwhJcE = MUcFkzs * 2;
            try
            {
                Console.WriteLine(mEPmwhJcE.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        short ekItqViVsalgPtWtBllPumA = -18565;
        string wOUNMxjKZNIXbLhwn = "gahEDYcdKCuSMypPA";
        ushort GnP = 61433;
        sbyte iMEjBHYZWdcuS = -73;
        double INJphbkImlOuJnsdcitmA = 7.967109E-26;
        double HifVGcnPlhBVXoT = 3.474529E-11;
        INJphbkImlOuJnsdcitmA = Math.Round(HifVGcnPlhBVXoT, 1, MidpointRounding.ToEven);
        int? ZqJSJkOEOUolSwSFFoNJpQm = 5701852;
        ZqJSJkOEOUolSwSFFoNJpQm += 99564; ushort eMHXIRK = 49580;
        string ekgPInTcQSpsaocdSjMCYhk = "ZkKAc";
        string MRjSztpcaxBjFTMMsUEYBaD = "WacPxEtaPdEBQxFLChMeyYGl";
        byte sFAcmMouVypBGydB = 97;
        uint lVVoSxtoyq = 393095331;

    }
    public void DWkOCNQSlxBhwbCnbXFfWaExp()
    {
        long UxScXdAXJmoYHKyZAwh = 25660318455904853;
        float tOzUhWxutEeVdSaNY = 2.174551E-07F;
        uint dbh = 19;
        string xJEOFwpzQezOa = "gRdCsZaJwxTwBoNpKYS";
        string KappIDDWTAHzuXjeISetOmgUjVbM = "uBVZJxROlKyzMCXm";
        double sDlcgO = 2.617177E-25;
        while (sDlcgO == 3.559114E-07)
        {
            sDlcgO = Math.Ceiling(Math.Sin(2));
            int[] sfXWHocYCyuRiUHZgNhLKOUYRIhg = { 3918731, 1065 };
            Random EimBwZqjMoNJlgOuSZuM = new Random();
            Console.WriteLine(sfXWHocYCyuRiUHZgNhLKOUYRIhg[EimBwZqjMoNJlgOuSZuM.Next(0, 2)]);
        }
        int onEkZeZhWsXo = 32;
        if (onEkZeZhWsXo == 300466)
        {
            onEkZeZhWsXo = onEkZeZhWsXo + 789658;
        }
        ushort wczIfEZIOukEFVl = 9023;
        ushort kHpGM = 56446;
        sbyte mClzxGFgWlQWfweq = -35;
        uint uLleHB = 57;
        ulong QqGzHqz = 58464995738063357;
        short aQDYljLPOaxFXmb = 21136;
        double VjyzdH = 1.550584E-34;
        while (VjyzdH == 1.344007E-07)
        {
            VjyzdH = Math.Pow(double.NegativeInfinity, 2);
            bool? hARegaCMVdiFisBMqoV = new bool?();
            hARegaCMVdiFisBMqoV = true;
        }
        ulong dKTXoOyaibIbpfuDLqs = 43557824102445561;
        byte RmVYpaAMldNo = 84;
        sbyte wknKjkFxniUCmkGMdjJqPMdafV = 79;
        uint FotwEmfoa = 12;
        byte IQwzmBGsJfJPeJhnFowfiJTC = 28;
        long BydfDfYemFHIoTVWjLHAEXaxPLfHY = 27306367010596905;
        double KfFVJ = 7.817517E+09;
        if (KfFVJ == -4.38758E-19)
        {
            double iuDxIqSZqgpLmdNOa = 5.438991E+14;
            KfFVJ = iuDxIqSZqgpLmdNOa * 2;
            for (;;)
            {
                Console.WriteLine(-2.585368E-25);
            }
        }
        int DwBqmGCz = 7720;
        if (DwBqmGCz == 385423)
        {
            DwBqmGCz += 121573;
        }
        float RqHNdtOBbEQEBqqTPnLZaU = -8.033654E-26F;
        float MwE = -2.298471E+18F;
        float sQccR = -2.929542E-25F;
        long pJP = 85724456868445398;
        float XbyScHsXbRYAiCoRXgCsZF = 1.246462E-10F;
        double LXRD = 9.576192E-07;
        if (LXRD == 6.050931E+26)
        {
            double DodnRRz = -3.266317E+07;
            DodnRRz = Math.Sqrt(3);
            LXRD = DodnRRz;
            Console.Write(LXRD.ToString());
        }
        long YUwQcGBzMMGjxEZzI = 8465385821427532;
        uint nkZtUnB = 65501157;
        short yaaEw = 25620;
        short tdoOGImXGdClRCxmnMtMVWU = -10439;
        sbyte MHLsAzVjheZyuLHqVG = -96;
        sbyte VENpJCDTy = -85;
        double cWHlmEcqHtsnQqIeEaok = 8.38514E-16;
        cWHlmEcqHtsnQqIeEaok = Math.Sqrt(4);
        Console.WriteLine(cWHlmEcqHtsnQqIeEaok.ToString());
    }
    public void zDzdTcobpfEIxQxoYRqTQnAqZ()
    {
        ushort cIFCeSNQJnbfmuuVUxlIJWXh = 21752;
        short ajcheAmluLFAQ = 11663;
        double bXLdAxsGUONgfKyjMyNHHgX = 4.639775E-38;
        if (bXLdAxsGUONgfKyjMyNHHgX == 1.040262E-22)
        {
            bXLdAxsGUONgfKyjMyNHHgX = Math.Ceiling(Math.Cos(2));
            int[] OzWOlEyDjOjTH = { 3221273, 81069 };
            Random VboXUiccocbjBlEgLgoXYIjWbR = new Random();
            Console.WriteLine(OzWOlEyDjOjTH[VboXUiccocbjBlEgLgoXYIjWbR.Next(0, 2)]);
        }
        ulong XbukgphjxPoMiUNbckY = 86377991673787624;
        ushort cSmpKfZQpenZCKBIlzoiZOfRJDT = 28836;
        long TyOntWcwzON = 58886786720167542;
        string PDjVnMwHhlDeZlQkmpEGQ = "CwO";
        string fGa = "sLHdVFsfjHPpDkgN";
        float TodBwSPbOhnMobhMjuthVHUktYb = 5.25281E+35F;
        byte mgkNMyRpOoTQkRzsOiRa = 187;
        ushort ZluShxRecEAaFdnxoseGSb = 53803;
        long UHnChkVTwlBqF = 31900746590040289;
        float ANDIIPTXwL = -2.279048E-21F;
        ulong DVsEgjSOeKJkIHlEXC = 11036173949434681;
        uint eGfyduJUUh = 69608695;
        ushort ISYxglMROXlyPNpPpcHFJz = 37617;
        byte nYqKQRq = 242;
        string NFRXpD = "SikGGVFfRJ";
        string djoNnSmuhYfVAMGEjzeqcuHwa = "JdNFYingZXyREedhf";
        float pgTo = -1.952518E+31F;
        short MOJEUNMjjIEZXHtNIf = -8790;
        double nUoMsKwQOMJGFCspuEeRVTADUfKOf = 1.104678E+31;
        while (nUoMsKwQOMJGFCspuEeRVTADUfKOf == -233814.3)
        {
            nUoMsKwQOMJGFCspuEeRVTADUfKOf = Math.Ceiling(Math.Cos(2));
            Console.Write(nUoMsKwQOMJGFCspuEeRVTADUfKOf.ToString());
        }
        long ofOlqbCBKAnFDXReszxUb = 25425000112811792;
        int XRSizUnxDlhJUZNXgIDGRH = 65297415;
        if (XRSizUnxDlhJUZNXgIDGRH == 884485)
        {
            XRSizUnxDlhJUZNXgIDGRH = XRSizUnxDlhJUZNXgIDGRH + 407307;
        }
        float BleN = -4.419434E+20F;
        long skebTJUeCUcESsMZVqcjHPaT = 34729651332004863;
        byte psCQOfOxhZsm = 46;
        sbyte fSZMChEkkxtXYBtk = -111;
        short ctyeDWwjIaBsqDwz = -12372;
        long KkNhptuiQ = 3055307438887951;
        long xPfXVjKdbwDcdCQIoplgMhO = 65472887592875455;
        short EmzFnRXGpsNmTKlzmtQVCbnb = -49;
        long XzG = 73653591054137347;
        string nBwQatwjZOknGtn = "YyeFQZhKYOYGjXgjs";
        short aGzagnQXLuftVYYpVYyJ = -15053;

    }
    public void MRmuPacHaWoM()
    {
        byte AxXqZcyoSwcIlHllUJtIUIONAQVd = 96;
        byte jLbQ = 118;
        string JlVxYR = "hOxwPbGtHcSJ";
        byte jhuVJsTWkQNkOagMyJWusbzIF = 40;
        uint eYYPQozeCBpAAkEGIFnGlUGjN = 485440231;
        sbyte MqBUbRlSYwzCckWsyUgy = 90;
        string USFktOcZQqxPjQFytqOJjPeiJJSoW = "KQMsGcyHTdWw";
        long HxNCSyNg = 22685350394724662;
        double dyHGcRkDaNyLNOfTDlVpxzF = 8.886937E+16;
        while (dyHGcRkDaNyLNOfTDlVpxzF == 0.04682915)
        {
            dyHGcRkDaNyLNOfTDlVpxzF = Math.Pow(double.NegativeInfinity, 2);

        }
        float sDgLHGczsuPZGeFsxOIkEog = 6.150068E+22F;
        ulong SRUSdNID = 56628667212029392;
        uint SVuQQsHTHkdwGUSwjI = 541879;
        long YDSXnwnha = 58042612759697818;
        uint jgxAqPmB = 878589739;
        float YRFXSYTdlFzkaPIWaFhHWqC = -96.19714F;
        string haUpneoIgtVYdhyZ = "IlzDhqBtMnRIpzxOzLd";
        short kfMhCDeHdA = -1467;
        short zoGXaKtWCRzaQUzjGyuHpygNwGOw = 16519;
        long sptZgiBKtZsJnnhLIHxzceL = 35716482833627625;
        byte cfKxUsafOaHYPSAnVfPqjMnFOY = 246;
        short ozchPkhynOnwsoddImptoAQhTKqS = -26490;
        long uLhzDFQZHqQHsCVRykBfMIWJPJU = 27653424643820727;
        long QBARmJcz = 26873656422908463;
        int MOAKUKCU = 3204755;
        while (MOAKUKCU == 3204755)
        {
            MOAKUKCU += 625145;
        }
        byte IKbozZUjVknqmbIOcHiX = 182;
        sbyte QpsWaaRWaNklXDnMNTo = 69;
        long jILtKZTymWCdlZ = 85571802329088077;
        string KlPVxdxqWtfLkHpSdDBoKUqn = "KZeKwhGGWJzkYbiAkgS";
        float RmTlkLdNfQUBp = 4.52312E-32F;
        short BlBfoXSHeCqPANAujTMl = -3061;
        byte CSRTELIodiEGHto = 136;
        short Gfj = 16277;
        double cwffSsfjpOZmzenWylm = 7.815288E+31;
        if (cwffSsfjpOZmzenWylm == 4.399748E-36)
        {
            cwffSsfjpOZmzenWylm = Math.Ceiling(Math.Cosh(5));
            bool? tpStbd = new bool?();
            tpStbd = true;
        }
        double qkBksnnesVPCDDRaJTnmxjyooEB = 5.761691E+10;
        while (qkBksnnesVPCDDRaJTnmxjyooEB == -2.866246E+31)
        {
            qkBksnnesVPCDDRaJTnmxjyooEB = Math.Pow(2, 2.1);
            int[] hdBwqmJzhOlWONsyRFTMtBNK = { 8897681, 32805 };
            Random jzpOTLfpPtSgfZJhK = new Random();
            Console.WriteLine(hdBwqmJzhOlWONsyRFTMtBNK[jzpOTLfpPtSgfZJhK.Next(0, 2)]);
        }
        sbyte VcFkAhpl = -25;

    }
    public void qRUhOtLndfGZtAqLGkFK()
    {
        int FooxLDtEQeuNCo = 8366;
        if (FooxLDtEQeuNCo == 985830)
        {
            FooxLDtEQeuNCo = FooxLDtEQeuNCo + 610063;
        }
        byte GVJfUOCfIMaVmGTsJiUBpCGHXcBOp = 206;
        long hFK = 51711364902514208;
        long HbGYDfRLOJdpbhSnOPSbZN = 58878842998682480;
        int XVqaU = 77092870;
        if (XVqaU == 300997)
        {
            XVqaU = XVqaU + 389562;
        }
        double dNyQsnVFIMTtKAYbpwo = -1.183696E+36;
        while (dNyQsnVFIMTtKAYbpwo == -1.853256E+24)
        {
            dNyQsnVFIMTtKAYbpwo = Math.Sqrt(4);
            try
            {
                int KXkLBpizHkpQJEUfTHLH = 3562598;
                if (KXkLBpizHkpQJEUfTHLH == 20502)
                {
                    KXkLBpizHkpQJEUfTHLH++;
                }
                else
                {
                    KXkLBpizHkpQJEUfTHLH--;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        sbyte kzFQnTJLkaMZVQdQhXaQ = -66;
        long XwbBjJKnO = 68561358995034719;
        long WwUAiDumPuks = 31017879819525200;
        string MYjmffUWLmfTNRcWS = "PxUTExmgMnQaulquKWoWxosTKXmCQ";
        ushort ztuKGHSwOZYtHfLSTD = 22813;
        sbyte IWDBeb = -80;
        int MqsKsHa = 720536;
        if (MqsKsHa == 515994)
        {
            MqsKsHa = MqsKsHa + 523874;
        }
        double VLNYftZylyRxSiC = 3.854559E+12;
        VLNYftZylyRxSiC = Math.Sqrt(4);
        Console.Write(VLNYftZylyRxSiC.ToString()); ulong akuQOwPcQKuihbXbLb = 36935408370646285;
        uint CbheZWNMqyfnjFHABajmOFEnH = 6274680;
        int znJXWBODpilolLn = 313562880;
        if (znJXWBODpilolLn == 808145)
        {
            znJXWBODpilolLn = znJXWBODpilolLn + 235509;
        }
        ushort VkeXzTznTimTjyqmd = 55336;
        double RYYCTpsp = 9.261178E-30;
        double EpJRUsgZSdzYGTYolKXmEdhBhw = Math.Log(1000, 10);
        RYYCTpsp = EpJRUsgZSdzYGTYolKXmEdhBhw;
        int[] xLGwBCntXGRCbmUqnmQXQdQAo = { 3317666, 41021 };
        Random iiKAGMZaHOtksxbTN = new Random();
        Console.WriteLine(xLGwBCntXGRCbmUqnmQXQdQAo[iiKAGMZaHOtksxbTN.Next(0, 2)]); string VGQh = "EcatUffbseJyafCa";
        int XdUtVX = 4737;
        while (XdUtVX == 4737)
        {
            XdUtVX += 270829;
        }
        int sghXanTneqeXjoqpBboATeFkgc = 42;
        while (sghXanTneqeXjoqpBboATeFkgc == 42)
        {
            sghXanTneqeXjoqpBboATeFkgc = sghXanTneqeXjoqpBboATeFkgc + 84042;
        }
        uint fTXFasnKYEoYObhONwYdanCX = 946634786;
        byte klNZutjysVaXki = 26;
        string iobonfifzPRsaOdgRANQoEuRKxR = "bSSiAbHIihXfF";
        float EtesgXQuKslGFUjFSnOeHXJSYgw = 1.608101E+13F;
        uint kwIQzFdKykziQnxcOZEe = 817018224;
        ulong HKmtaDSLhLa = 76434137922191259;
        float PSFDeI = 7.474772E-31F;
        ushort wGsjOsLKUsOafnlfKmEpnAVh = 54517;
        float RVVUGKVGFFUXIdUxDtON = -4.965906E-15F;
        double LChCVKksXKTPZyiqkIHCPpWluctOc = -9.21435E-14;
        while (LChCVKksXKTPZyiqkIHCPpWluctOc == 4.44225E+33)
        {
            LChCVKksXKTPZyiqkIHCPpWluctOc = Math.Ceiling(Math.Sinh(-5));
            Console.Write(LChCVKksXKTPZyiqkIHCPpWluctOc.ToString());
        }
        float tPgIKKXpV = -4.407813E+08F;
        float lbTKoLBuoBGhGgijbhwhcmAxXS = 5.874055E+29F;
        sbyte KTMsGCeDTSsSenBBeEOfUWjMQ = 122;

    }
}
public class xMxNHlyRNwmBIfzoD
{
    public void jhkWyOufcXNJaDHZIRxfLHIy()
    {
        ulong RcgZx = 5916948640416996;
        long BiBedwLUJzIS = 35349273723744229;
        short dBfbdVQIhDPNkzgsKKfhzCPPjRepE = -9263;
        double aBfZZcqQeaqfdKUetwyJS = -642.8777;
        while (aBfZZcqQeaqfdKUetwyJS == 1.671035E-15)
        {
            double ePGeNKshtIspdykJM = 3.69498E-20;
            aBfZZcqQeaqfdKUetwyJS = ePGeNKshtIspdykJM * 2;
            int[] hVmSRYEmJkeZGVCAZWjMlcQpDfeq = { 8826144, 36070 };
            Random FqoRDX = new Random();
            Console.WriteLine(hVmSRYEmJkeZGVCAZWjMlcQpDfeq[FqoRDX.Next(0, 2)]);
        }
        byte MOVKynpzCJjMEOnLfeXpLUmjeTPh = 11;
        double gOayXqssclIDJTSNCDSR = 5.496177E-07;
        gOayXqssclIDJTSNCDSR = Math.Ceiling(Math.Atan(-5));
        MessageBox.Show(gOayXqssclIDJTSNCDSR.ToString()); byte lxgtgPKTOaYpbQtWCs = 234;
        string McRjbGgAluot = "aDCxNuCtKedkPsga";
        float Dhl = -1.250657E-10F;
        short ejEuDGJ = 28780;
        uint QweGCCYcYNYlmZzuuNlnChkm = 21180981;
        double hzwnmDqGNwbHmxxEkTXFVilWLnnIj = 1.774823E+33;
        if (hzwnmDqGNwbHmxxEkTXFVilWLnnIj == 1.141162E+37)
        {
            double YKJSHZLFbeMHcQntdZmzDZ = 0.2060672;
            hzwnmDqGNwbHmxxEkTXFVilWLnnIj = Math.Ceiling(YKJSHZLFbeMHcQntdZmzDZ);
            Console.ReadKey();
        }
        long qFKtsVRVGQMlFzFhimkaMWAlGL = 50048041798441331;
        ushort ebjajDuIobRoBFJTgJgufzOIKBHbk = 35650;
        double aGchdjRjDSXEUWQKVMcICcUHmDqJ = 2.361781E-11;
        while (aGchdjRjDSXEUWQKVMcICcUHmDqJ == 1.521834E-30)
        {
            aGchdjRjDSXEUWQKVMcICcUHmDqJ = Math.Truncate(aGchdjRjDSXEUWQKVMcICcUHmDqJ);
            Console.ReadKey();
        }
        long fPQMCuyQNdpRMojqWxYHzpMb = 59885108670266087;
        short zjhCySuLFfPQDPApMxsepPcOYTspS = -19223;
        short AMQZjwZflOLHlXfm = 10383;
        int symKJhuEFBeSuQopQYAgqxmT = 78517;
        while (symKJhuEFBeSuQopQYAgqxmT == 78517)
        {
            symKJhuEFBeSuQopQYAgqxmT = 744613;
        }
        sbyte lwXdlchSPRwFgVqQXHpn = -87;
        uint VktgFLSDRwyHYSk = 74;
        float qAbIMINGEtxRAMXbSTWD = -7.56685E+33F;
        short jKosYMDExBiYUDHASe = -14381;
        sbyte EYUbQtkQoBuky = -9;
        string uIRRTwYDZhol = "KbJfiGMuqhtsNha";
        ulong xeEgzyysDiZqcJdYtFzMfoS = 9785466755355455;
        double mLkIplEkNHyMcoApttDCbHgl = -8.383441E-25;
        while (mLkIplEkNHyMcoApttDCbHgl == 5.007885E+36)
        {
            mLkIplEkNHyMcoApttDCbHgl = Math.Truncate(mLkIplEkNHyMcoApttDCbHgl);
            try
            {
                int tJwGUOZhfNLyNGFYw = 4781050;
                if (tJwGUOZhfNLyNGFYw == 55140)
                {
                    tJwGUOZhfNLyNGFYw++;
                }
                else
                {
                    tJwGUOZhfNLyNGFYw--;
                    Console.Write(tJwGUOZhfNLyNGFYw.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        ushort pjHC = 17748;
        uint HoHZRNKjFPjtTVWConAzTVuox = 6638922;
        ushort QlqfhORjHwgBsfLoj = 37650;
        sbyte IsmPZXLVqDfKm = 39;
        ulong SmMgfsJSsXCQJamgWc = 66778359586138750;
        float pxmKq = -1.394936E-06F;
        double ZnoJuxbwUlqoZOkOpGpfBejAE = 6.860419E+31;
        double WOFPEffQiJC = 658498.8;
        ZnoJuxbwUlqoZOkOpGpfBejAE = Math.Floor(WOFPEffQiJC);
        int? WaCfRs = 9309116;
        WaCfRs += 48501; string zWaLPKMGOmOYPPF = "GNABWRIaDSpGmJHVKmBORLtRo";

    }
    public void lxhDhZIxbiZBDIoaiX()
    {
        ushort teHSnD = 18837;
        float UtJ = -5.387028E-13F;
        int SZKpYQIy = 189277788;
        if (SZKpYQIy == 484459)
        {
            SZKpYQIy = SZKpYQIy + 812532;
        }
        int xikgQpnGLRwhQp = 2152;
        while (xikgQpnGLRwhQp == 2152)
        {
            xikgQpnGLRwhQp += 186713;
        }
        byte iDyjW = 23;
        float qjsXlbgywCLdGh = -0.2008104F;
        long UAPuItitaIKGujPnAkP = 89050102483158492;
        byte bhXDpksIXDZPTaz = 193;
        ulong CoqIjLP = 24135874160440813;
        float AMcdZxHDJQdkmGTUzXVhtYmOPFXBl = 2.799229E-32F;
        float bYbMeDSLfCUMptPoQDWcNHCzonwAg = -1.937544E-29F;
        long llHRhuwdx = 64643671980462931;
        ushort iPlwyDyQhtFQujAehhyIhCZptdfmQ = 11987;
        short UgDyZQjnLEmKSyciDudaONRHQWb = -7992;
        ushort aYbJVnIc = 5573;
        short iXFnoyWaXLwfqhgpVIdOQRBEoJiCP = 658;
        uint NbFQmsBzfsA = 588593;
        float CPXNwaDisyaZGowlykftoD = -6.749402E-35F;
        int FJysaZ = 962693;
        if (FJysaZ == 836421)
        {
            FJysaZ = FJysaZ + 769748;
        }
        sbyte jTmsltVjLg = -119;
        short AwYzVinxULZybCI = 9410;
        long JgRixpYRjluYp = 11371038827708159;
        int TohmVkRmDbNthIpYJAdZcbWwJ = 52866915;
        if (TohmVkRmDbNthIpYJAdZcbWwJ == 984952)
        {
            TohmVkRmDbNthIpYJAdZcbWwJ += 404350;
        }
        uint pXTnc = 61;
        ushort SWEXESHEZOSGORtNFkJmhEHonSKxK = 40325;
        ushort GdiZRLgKXCZHGzC = 7660;
        uint zTXgRopoJMhkTtsuZ = 66169570;
        ushort TdZoHEZKQqFWihEBAlUKDcwCNIG = 18435;
        byte QygGFPXRkLpFTwE = 69;
        long OUBAOKtRJ = 26371435512749327;
        sbyte DDODIajtXiaYzWuBpYpKxmOg = -1;
        short NFfDTxziJ = 32731;
        short zEqwIJAdbEkitkxtoOIctPxORH = -24609;
        uint OLBYfSffRfyakjjuXjJafTVsoAKgD = 34467;
        uint dnSLjntqmzIjchFmuUxyCUVQhKGhY = 248352;

    }
    public void VcgWs()
    {
        long WoKTwmhmseUiKFexjsbDBIk = 31089420336732486;
        float hBhSbBEaymdeuDARGXEpgm = -1.171121E-32F;
        short jJTmqxZ = -2645;
        int WFhSz = 52681;
        while (WFhSz == 52681)
        {
            WFhSz += 291984;
        }
        long yuceF = 66762973714229644;
        sbyte VIeWawVa = 74;
        ulong FjSXdUCExSnqwUIRSepBDwSAB = 39230069139505684;
        ulong KugxYQqLsHpKcsFcVAkojstxUCTUU = 1392745907898546;
        long LkKASjApoeA = 37719163590495052;
        uint WxRUGqbhuiqniAe = 858673;
        uint wlEQwZmRk = 62;
        ushort fTP = 50983;
        float lTziVWhkGItoACyglsH = -8.86421E+29F;
        ushort QbNPphoKpHnntWcJ = 58161;
        byte IjSRhSEZIyhyKTuIghgSdpXc = 168;
        byte ejiKNhfMp = 247;
        byte WMiImhiEuZoWBNwMqlP = 42;
        double APzOwpFhdJWDkfVJLVA = 1.574362E+27;
        if (APzOwpFhdJWDkfVJLVA == 2.214134E-20)
        {
            double uejbKqmtiANTYm = Math.Log(1000, 10);
            APzOwpFhdJWDkfVJLVA = uejbKqmtiANTYm;
            int[] CoRJCUJnNuTlFwEkOZAVSUTCAlhHK = { 4907513, 92978 };
            Random jomkzyDLEosxFSBWUqpN = new Random();
            Console.WriteLine(CoRJCUJnNuTlFwEkOZAVSUTCAlhHK[jomkzyDLEosxFSBWUqpN.Next(0, 2)]);
        }
        sbyte fHxpi = -51;
        ulong EgkE = 32856958356866877;
        int pbbEqQqWfmjhfR = 25;
        if (pbbEqQqWfmjhfR == 557881)
        {
            pbbEqQqWfmjhfR += 299021;
        }
        float IWXBuieyBVDJpun = 2.697631E+35F;
        double IaXuRoffwBiImFTtfHRwhR = 6.384566E+18;
        if (IaXuRoffwBiImFTtfHRwhR == 1.672741E-06)
        {
            double oHEjxKCfkodKXqnoeybiYhBFQskg = 8.303794E+07;
            oHEjxKCfkodKXqnoeybiYhBFQskg = Math.Sqrt(3);
            IaXuRoffwBiImFTtfHRwhR = oHEjxKCfkodKXqnoeybiYhBFQskg;
            for (;;)
            {
                Console.WriteLine(-6.802045E+26);
            }
        }
        long luzmGKaqFyCtBJGPfVB = 47334682376355867;
        short iHmyzWsX = 17139;
        long dnjBGNzLAKoYTiLEPMtV = 4744518132648334;
        ulong SskSyGzdfg = 32333721403721809;
        ulong DkuPYugOKqRw = 17122635362351556;
        sbyte HlKuRHChVHouMHXwUdAKtO = -56;
        ulong HIXUtEJmRFh = 84186225348598719;
        sbyte AkZsgHGwsSXTdjYEmC = -111;
        int UcPppB = 450131248;
        if (UcPppB == 85458)
        {
            UcPppB = 677170;
        }
        ulong xYDlWc = 48150565074636709;
        long UgByFijbRf = 81882995973209267;
        uint LogDowpFeQhzODyXhoD = 7916;

    }
    public void wQxUYlqbhqZdFFaYh()
    {
        sbyte FXbYhiXcVbdBnQjUpgwxemcIRA = 49;
        double XjgtwkEuSnLbjwaeQLnwLKRNNO = -3.431119E+30;
        while (XjgtwkEuSnLbjwaeQLnwLKRNNO == -2.466252E+13)
        {
            double RWgSGGAzSKwVRcEaOxDgmsuHITJbK = -2.881454E+36;
            XjgtwkEuSnLbjwaeQLnwLKRNNO = Math.Round(RWgSGGAzSKwVRcEaOxDgmsuHITJbK);

        }
        long iIXTNyOEWXfZuRapKgJ = 33170378299354894;
        uint QZIjPhmQUiF = 77799840;
        ushort nRSMKSVPdExYkFMAklngYyPF = 44037;
        ulong PYdBwRHdowASyUjE = 78484437518248726;
        ushort lRQbmcXsgRZcbgEB = 28751;
        string uQlPUilALoHoKgUGQmnhyU = "OsEEq";
        string LMFJZKacWSbEmdA = "oVgCOmiXnAMyxpGVx";
        byte VLbhkFOqwgTIboQnIj = 135;
        long DIuBYDGHmfgbAFR = 58442110503017226;
        ushort KiGbYMVBgscIHlchLiaNHCKZa = 57448;
        byte LBPRZJntaFnulBslPGh = 180;
        float lFQJkiAHaeApPGElJXXJgfUHBg = -0.0006246028F;
        byte MCMTojbpzfUtE = 48;
        float LMJDXjNkLfLiheZbxHsXFWqtjsA = 3.242237E+21F;
        ulong LMFwyPIyDOBhiASiu = 77164608312866531;
        ushort sFKVxXFayD = 44461;
        uint PiPidPhUs = 10;
        long QETPmHbBoSSTejFAwGLFHiPbOnZ = 22715746699041671;
        string IpcAMA = "XpZGEuWEugo";
        int RaZHPfoxmJEbEsNpIeVKzezn = 6916;
        while (RaZHPfoxmJEbEsNpIeVKzezn == 6916)
        {
            RaZHPfoxmJEbEsNpIeVKzezn += 209477;
        }
        string BlpIpwLG = "UKHwEZci";
        byte btXpMDLmefkFcFsCsbfZlt = 75;
        uint uRTRLXVFzcSEVFeGiH = 1710;
        short bcbHacnAIezMqMRwuhoa = 4468;
        int YyybudNPzpNPQPdW = 313063691;
        if (YyybudNPzpNPQPdW == 762050)
        {
            YyybudNPzpNPQPdW = 84092;
        }
        sbyte tONlsLneA = 9;
        string EbTxVoax = "WbHpkyLFiNTnjJHpBy";
        ulong Ipn = 58734975427676253;
        string JxNgWgnEApPjWttmfuRlwWH = "VxSGncKnPCClTjFpBziZABX";
        double ixeHSsMQakAoIpy = 2.188778;
        while (ixeHSsMQakAoIpy == -5.666499E+25)
        {
            ixeHSsMQakAoIpy = Math.Sqrt(4);
            int[] ChqPAof = { 2111347, 83850 };
            Random wXhNQZxA = new Random();
            Console.WriteLine(ChqPAof[wXhNQZxA.Next(0, 2)]);
        }
        string zlcLBYKASPcpnpXLRogoCQOSng = "fGuXTof";
        long fGoCGHnGVSA = 87088279566805274;
        long jxtPETzRjahIIGl = 40282992361504316;

    }
    public void JeUMbhDOZSViWNbNPPLS()
    {
        short ugxWgcyfomaMfAZNQbyuIPKcd = 22654;
        long NtlFpRK = 3771991901297388;
        long jHDNcYK = 23531698346549730;
        ushort sVbxwoPlyL = 293;
        double NlbU = 6.613762E-22;
        if (NlbU == -4.503058E+14)
        {
            double HfqWmNfbCIHNOq = -191.7979;
            NlbU = Math.Round(HfqWmNfbCIHNOq);
            for (;;)
            {
                Console.WriteLine(63.46498);
            }
        }
        ulong kNXxoJRhUggCMJcH = 61757258539392073;
        short iUaEtIxCzXXdhFbTqzoGwlplZ = -11873;
        ushort IZYYezBXg = 20958;
        ulong ejjfKbJRCYTpKMxW = 72078552876134751;
        double ZKdeNaLPCkbkDYIFLKfJnsbEtsNLo = 2.704114E-15;
        double lSGVkkVtlFwGBjto = Math.Log(1000, 10);
        ZKdeNaLPCkbkDYIFLKfJnsbEtsNLo = lSGVkkVtlFwGBjto;
        int? LunZBIVpcSWJRnzmd = 3350754;
        LunZBIVpcSWJRnzmd += 26254; ulong FGuEpFptINOmMflsBRRLmfKRn = 19900558875567681;
        int yYEBdKNAEVgumHHTBxbE = 921851;
        if (yYEBdKNAEVgumHHTBxbE == 530586)
        {
            yYEBdKNAEVgumHHTBxbE += 651637;
        }
        sbyte fwjLeyOuXqNaBGgW = -94;
        ushort ElJRhBcjCwnYxFmuhLxpQ = 56887;
        byte iJadTPHihYCoxFcjbnlYKtqwmlY = 57;
        long TLYNJ = 4563226370365011;
        uint YXEI = 2710;
        int omQsGRHRwzceRpKWFKcX = 181689;
        if (omQsGRHRwzceRpKWFKcX == 875078)
        {
            omQsGRHRwzceRpKWFKcX = 345459;
        }
        short wEzQqdKBTf = 25867;
        sbyte VuIOtmInIcDkGhfInzmCs = -22;
        float mOOGiczQUmEPXOBfIaNBWFLVFSFIH = 1.22464E-13F;
        uint ICGAceFFNqsFpLAYhU = 6588;
        short IcSa = -11734;
        uint imWdlomVHFWiWjnspogeKANaS = 5786;
        float HbOgNEdxCdxmdCowA = -7.395658E+28F;
        ushort CMjthKBVlZLtsZEhciGkW = 52028;
        byte SHXyFsSKASepFOGUDBpdLU = 179;
        uint mykniONBzBCMcqThbUBVnE = 5750;
        long wAhZYVwMsVIwpdsQfmdi = 33939752440346926;
        uint iHECsmszDGppZYAGEyDzz = 49;
        uint lclpYM = 27750300;
        long bSPLfyHKzSjkzyexNdZlgg = 51972566692638109;
        uint qlz = 78232538;
        ulong aRqbKXbFPlCZLox = 81673334463364756;
        sbyte qhTmYpIaHZuQfsyeGq = 111;

    }
}