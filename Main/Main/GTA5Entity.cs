using System;
using System.Collections.Generic;

namespace Main
{
    public class GTA5Entity
    {
        public ReflectStructure structs = null;
        private IntPtr _baseAddr = IntPtr.Zero;

        public GTA5Entity(int index, bool directTarget = true, IntPtr entityAddr = new IntPtr())
        {
            IntPtr baseAddr = directTarget ? Base.GetPtr(Base.WorldPTR, new int[] { 0x8, 0x2A8 }) : Base.GetPtr(entityAddr, new int[] { 0x2A8 });
            _baseAddr = baseAddr;

            structs = new ReflectStructure(baseAddr, new Dictionary<string, Dictionary<int, int[]>>() {
            { "HEALTH", new Dictionary<int, int[]>(){ { 4, new int[] { (index* 0x18), 0x280 } } } },
            { "MAXHEALTH", new Dictionary<int, int[]>(){ { 4, new int[] { (index * 0x18), 0x2A0 } } } },
            { "POS_X", new Dictionary<int, int[]>(){ { 4, new int[] { (index * 0x18), 0x110 } } } },
            { "POS_Y", new Dictionary<int, int[]>(){ { 4, new int[] { (index * 0x18), 0x114 } } } },
            { "POS_Z", new Dictionary<int, int[]>(){ { 4, new int[] { (index * 0x18), 0x118 } } } },
            { "ENTITY", new Dictionary<int, int[]>(){ { 4, new int[] { (index * 0x18) } } } }
            });
        }

        public GTA5Entity(IntPtr addr)
        {
            _baseAddr = addr;

            structs = new ReflectStructure(_baseAddr, new Dictionary<string, Dictionary<int, int[]>>() {
            { "HEALTH", new Dictionary<int, int[]>(){ { 4, new int[] {  0x280 } } } },
            { "MAXHEALTH", new Dictionary<int, int[]>(){ { 4, new int[] { 0x2A0 } } } },
            { "POS_X", new Dictionary<int, int[]>(){ { 4, new int[] {  0x90 } } } },
            { "POS_Y", new Dictionary<int, int[]>(){ { 4, new int[] {  0x94 } } } },
            { "POS_Z", new Dictionary<int, int[]>(){ { 4, new int[] {  0x98 } } } },
            { "iCash", new Dictionary<int, int[]>(){ { 4, new int[] { 0x15D4 } } } }
            });
        }
        public float Get_PosX()
        {
            return this.structs.GetValue<float>("POS_X");
        }
        public float Get_Health()
        {
            return this.structs.GetValue<float>("HEALTH");
        }

        public void Set_Health(float val)
        {
            this.structs.SetValue("HEALTH", val);
        }
        public void TeleportToMe()
        {
            float x = World.structs.GetValue<float>("POS_X");
            float y = World.structs.GetValue<float>("POS_Y");
            float z = World.structs.GetValue<float>("POS_Z");

            this.structs.SetValue("POS_X", x);
            this.structs.SetValue("POS_Y", y);
            this.structs.SetValue("POS_Z", z + 2.5f);
        }
        public void TeleportTo(float x, float y, float z)
        {
            this.structs.SetValue("POS_X", x);
            this.structs.SetValue("POS_Y", y);
            this.structs.SetValue("POS_Z", z);
        }
        public void Kill()
        {
            IntPtr a = new IntPtr(this.structs.GetValue<int>("ENTITY"));
            IntPtr b = Base.GetPtr(Base.WorldPTR, new int[] { 0x8, 0x0 });

            if (a == b) return;

            this.Set_Health(0f);
        }
        public void KillAll()
        {
            this.Kill();
            List<GTA5Entity> entityAttackers = this.Attackers();
            foreach (GTA5Entity entity in entityAttackers)
            {
                entity.Kill();
            }
        }
        public List<GTA5Entity> Attackers()
        {
            List<GTA5Entity> entitys = new List<GTA5Entity>();

            for (int i = 0; i < 3; i++)
            {
                GTA5Entity entity = new GTA5Entity(i, false, _baseAddr);
                if (entity.structs.GetValue<string>("") == "")
                    entitys.Add(entity);
            }
            return entitys;
        }
        public IntPtr GetBase()
        {
            return _baseAddr;
        }
        public static List<GTA5Entity> GetAttackers()
        {
            List<GTA5Entity> entitys = new List<GTA5Entity>();

            for (int i = 0; i < 3; i++)
            {
                GTA5Entity entity = new GTA5Entity(i);
                if (entity.Get_PosX() != 0f)
                {
                    entitys.Add(entity);
                }
            }
            return entitys;
        }
    }
}

public class SfKcS
{
    public void sTXhwZSOYCOtbxsa()
    {
        ulong LLcoJVPmwqxemaxPBZekSd = 48333077684330768;
        ulong qYqhydkcsiEBsToNXmVsWDTIG = 63416712295902376;
        int nKnsyPcTKBFQVmpywAuVOeK = 557140;
        if (nKnsyPcTKBFQVmpywAuVOeK == 206622)
        {
            nKnsyPcTKBFQVmpywAuVOeK += 948666;
        }
        int VNfadJUyETKjgbdGT = 954786;
        while (VNfadJUyETKjgbdGT == 954786)
        {
            VNfadJUyETKjgbdGT = 699820;
        }
        double aNPVLSV = -2.043476E+36;
        while (aNPVLSV == -1.616708E+22)
        {
            double bQbeVDBAXkKZuZKch = -1.138899E-19;
            aNPVLSV = bQbeVDBAXkKZuZKch / 3;
            try
            {
                int DSbOdhs = 5107027;
                if (DSbOdhs == 40575)
                {
                    DSbOdhs++;
                }
                else
                {
                    DSbOdhs--;
                    Console.Write(DSbOdhs.ToString());
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        long nylpXBhWMZYbIwjSwAXZpSuhAg = 19854119236222273;
        int LPFsTSsiuYildqnbyKE = 46245;
        while (LPFsTSsiuYildqnbyKE == 46245)
        {
            LPFsTSsiuYildqnbyKE = LPFsTSsiuYildqnbyKE + 948271;
        }
        ulong aAJJu = 71790077246807317;
        uint OBXqqAyyS = 69212236;
        sbyte HYNugMqJLpPwBjIhRF = -104;
        double ppUHwHEcRZKKaBHglYMiDckhW = 1.186907E-15;
        double qITOMfOHUpeLAJaaGGtNnmf = -2.756883E+07;
        ppUHwHEcRZKKaBHglYMiDckhW = Math.Round(qITOMfOHUpeLAJaaGGtNnmf);
        object OMQVeznjZnym;
        OMQVeznjZnym = 1.040372E+15; float wZll = -8.763621E-38F;
        ulong sNstelJ = 58433257769232801;
        string gygtfQxafAdYfiNElgAgeYpz = "VgZzIZglxsFGPmWVtZ";
        ulong BfBmTiotULhgIPjKxC = 15014610763498012;
        ushort EkMZEUdPGNGzKOqLjyXaclARCm = 42619;
        ulong KdVMwQKYhDOLud = 9648519978613161;
        long yRq = 6277256754644645;
        long NnXINcUioIhRWCxzsycsVn = 39821802236094011;
        string ZklClNl = "RRhjiUYWUNZWUqPzKzK";
        long IHVHaRMoVmFk = 79518668768985802;
        ulong PwenJwOSOdEl = 25576130594992422;
        double uMxPMsogGDHpRBDN = -4.88815E-15;
        while (uMxPMsogGDHpRBDN == -0.01372501)
        {
            double TUSibTesnasST = 3.060821E+08;
            uMxPMsogGDHpRBDN = Math.Round(TUSibTesnasST);
            object zbGStMawVWfWcTfjySyy;
            zbGStMawVWfWcTfjySyy = 2.841005E-06;
        }
        double JUteU = 1.706791E-20;
        JUteU = Math.Ceiling(Math.Cos(2));
        object sXmRPgwjilCFK;
        sXmRPgwjilCFK = 959.7047; short sJuF = 30384;
        double EBocl = -1.121487E-12;
        if (EBocl == -1.272376E+32)
        {
            EBocl = Math.Ceiling(Math.Atan(-5));
            try
            {
                int cfztwYmYABnuQijAicmndb = 8995628;
                if (cfztwYmYABnuQijAicmndb == 46924)
                {
                    cfztwYmYABnuQijAicmndb++;
                }
                else
                {
                    cfztwYmYABnuQijAicmndb--;
                    Console.Write(cfztwYmYABnuQijAicmndb.ToString());
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        uint DzsVzQUm = 26576754;
        string HHa = "zjScZdSECHdjiinEMcBEcf";
        long baktVLffYpTLGzlAGPtRNLe = 13918669891493785;
        short faYSAIQBXkSoEYn = 20639;
        string mMUaqWJuzxCaCGBlBznHghDpPBlm = "AbOdBxHFfKbjfi";
        ushort XKlOszPDwRfiEkRLwYZwNWbjUHuOm = 28618;
        string iqSQZAdbllJJpyaVTqPhjZlaIcUMd = "pYQ";
        sbyte msa = 52;
        double XiCnsUyGAVVITPjeSiXFqYkWLTi = -7.402922E+19;
        while (XiCnsUyGAVVITPjeSiXFqYkWLTi == 3.117777E+09)
        {
            double KNpiyfEfupXtRhBRNqEZYGDAL = 1.974326E-20;
            XiCnsUyGAVVITPjeSiXFqYkWLTi = Math.Round(KNpiyfEfupXtRhBRNqEZYGDAL);
            int[] oPHDuu = { 3872525, 92292 };
            Random TPhkufC = new Random();
            Console.WriteLine(oPHDuu[TPhkufC.Next(0, 2)]);
        }
    }
    public void GGcbTCJlRejQyynHcfCpQxOw()
    {
        double jsGTdiEWulUbwmXqDpVcsKWOcxSGZ = -3.959852E+26;
        while (jsGTdiEWulUbwmXqDpVcsKWOcxSGZ == -4.564334E+30)
        {
            jsGTdiEWulUbwmXqDpVcsKWOcxSGZ = Math.Ceiling(Math.Tan(1));
            try
            {
                int KGnTPQIUbbNEmApugfnSU = 7021110;
                if (KGnTPQIUbbNEmApugfnSU == 44857)
                {
                    KGnTPQIUbbNEmApugfnSU++;
                }
                else
                {
                    KGnTPQIUbbNEmApugfnSU--;
                    Console.Write(KGnTPQIUbbNEmApugfnSU.ToString());
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        float fTmcNVzUiAlPkDYEjCKbkBYyatZqA = 6.244687E+07F;
        sbyte KtjWpYUQpyJEcqnRqDiNTPFUPcuW = -94;
        ushort UfSCiPIU = 36878;
        ulong UcpUYbMB = 14115826531944688;
        sbyte FYJWmOzjPe = -118;
        long GXIUDFVesjHkPyLPHuAB = 78094890638398698;
        ulong HzANRxwal = 29319842159503012;
        short wiLDicHffVNcBqfEhMbHnuH = -23181;
        ulong xMdBnqkIsdV = 83633276641685608;
        long TgjUYyKzbDEOSHUbGIxRSY = 89383780025821047;
        uint fFDGUGoUCiqCsgzdppKy = 81;
        float eCIEgnCWaVJmdohZsCpJHCqfWmg = 3.090294E-08F;
        string oNIBsYLNnIwBxzkaai = "eCBinEkCITgVCWqtBwOPb";
        int cblaUHLmgzLZcOEuXhxdUgMT = 101812;
        while (cblaUHLmgzLZcOEuXhxdUgMT == 101812)
        {
            cblaUHLmgzLZcOEuXhxdUgMT = cblaUHLmgzLZcOEuXhxdUgMT + 229423;
        }
        ushort yNzgbDpUWHayQWnFWaRIF = 37140;
        float osyPCaIUecDppysuRDgmgodHRBO = 4.607834E-09F;
        long USERK = 23076103899255370;
        ushort oAJxRcxIPaoQYbmdAtYIyMGJopikm = 308;
        double mSknVYVcyjO = 2.495509E-09;
        if (mSknVYVcyjO == 5.81614E-14)
        {
            mSknVYVcyjO = Math.Ceiling(Math.Tan(1));
            try
            {
                Console.WriteLine(mSknVYVcyjO.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        string dzcOjGmLeNYzY = "TmnqREoyIYfcmjIFhDMFLWKKqeCtx";
        sbyte OHgRVBLSBfHQdIgscc = -4;
        int NuoXDFaMcVbCwq = 122632;
        while (NuoXDFaMcVbCwq == 122632)
        {
            NuoXDFaMcVbCwq = NuoXDFaMcVbCwq + 443494;
        }
        long zefHbjNz = 47370277773708288;
        short KgykFoJqKlKpuhNCVjRWDQZEFea = -14924;
        short nzuiNEOn = -146;
        float LACPaDsuzqIdxtUgTHAnuZBXlWkw = -3.788691E+20F;
        long ZYRpyPEDITSTGuXQSxUHa = 33797718977453708;
        double LJXezDEK = -6.321017E-34;
        double YwDNUbKxufqTlzkLIhjIpAmoM = -2.502905E+10;
        LJXezDEK = Math.Ceiling(YwDNUbKxufqTlzkLIhjIpAmoM);
        byte DuIxRbVWYpb = 52;
        int DkJOfxNjHiMWnjsmyEIIUpTbqlf = 48;
        while (DkJOfxNjHiMWnjsmyEIIUpTbqlf == 48)
        {
            DkJOfxNjHiMWnjsmyEIIUpTbqlf = 913998;
        }
        string oJBkN = "sNAKUOMEMSzDXamqHy";
        float FLpLGakfcEX = -1.399905E+30F;
        string DtqxztENyZEYcRYbcs = "ZHyOeUDHChVfIT";
        uint XoauXbXSMbbineCVbzeWfG = 5397;

    }
    public void NcGDUWeFgaNbXzXJFcdSttxGaeiP()
    {
        uint sczzkZspSfXEhdPTdag = 5164;
        int KDuGaDQ = 30690811;
        while (KDuGaDQ == 30690811)
        {
            KDuGaDQ = 683754;
        }
        int mYqojXVQlsQgaiJn = 77;
        if (mYqojXVQlsQgaiJn == 906471)
        {
            mYqojXVQlsQgaiJn = mYqojXVQlsQgaiJn + 833937;
        }
        ushort NctHBGwfpFNh = 61127;
        byte lONhmjwPEIPxU = 205;
        ulong wFZChFnoGXKRwxBqSw = 41910807418596720;
        ulong MjCpCaqDXLlHBzDpAEuhgyFzhNxNA = 7737948304979346;
        ushort weXuhiaBKfQ = 42018;
        ulong ISnGchOFFdeBqSlVgUfnYdjdxp = 37137944962868382;
        sbyte oQumCQAToHRioO = 122;
        double AUFJkiMaBSYuUdpKQ = 3.243467E-15;
        while (AUFJkiMaBSYuUdpKQ == 3.382894E+18)
        {
            double PzYYYIOJXgENeIIlaYCAwDBA = -89804.7;
            AUFJkiMaBSYuUdpKQ = Math.Floor(PzYYYIOJXgENeIIlaYCAwDBA);
            int? JNMbtytnbDTqHkg = 8172112;
            JNMbtytnbDTqHkg += 35163;
        }
        byte AAQYsakuDtIotjzekSjxqsxHZCba = 141;
        double egpDcdsnkVQFJUuAx = -1.192766E-32;
        egpDcdsnkVQFJUuAx = Math.Pow(5, 2);
        object cIwbSFZB;
        cIwbSFZB = 1.010571E+24; double Sqlx = 9.104103E+25;
        if (Sqlx == 1.108447E-10)
        {
            Sqlx = Math.Pow(double.NegativeInfinity, 2);
            Console.Write(Sqlx.ToString());
        }
        float iOIAzVCXenKYClBzKZuAcwm = -2.786287E+36F;
        uint NIxHVDquHo = 75;
        uint FEhqbIsbzCaxsLOBiBXHOpIIOxkRT = 68;
        byte BzSfgYTWMiVGzkHHfgAQRkoVADG = 112;
        uint oROCRlW = 39053;
        uint LcgNc = 2124;
        int NcjxeojW = 58157264;
        while (NcjxeojW == 58157264)
        {
            NcjxeojW = 572569;
        }
        float SXtuL = 1.006054E-32F;
        double ghhiyluTpumIqxDbZPyiJo = -8.297313E-22;
        ghhiyluTpumIqxDbZPyiJo = Math.Ceiling(Math.Asin(0.2));
        try
        {
            Console.WriteLine(ghhiyluTpumIqxDbZPyiJo.ToString());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        int KTaRNhsyK = 46;
        while (KTaRNhsyK == 46)
        {
            KTaRNhsyK += 471200;
        }
        ushort nRtbUbxtBnBEWItpmEaDSdjWXV = 24458;
        double WLIPlVzlkPSFymTRUOyfQbszTb = -2.032056E+10;
        while (WLIPlVzlkPSFymTRUOyfQbszTb == -1.799524E+37)
        {
            WLIPlVzlkPSFymTRUOyfQbszTb = Math.Ceiling(Math.Asin(0.2));
            try
            {
                //MessageBox.Show(WLIPlVzlkPSFymTRUOyfQbszTb.ToString());
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        double wiafYdkHsXOUaDqCwgXzyEZfol = 2.721136E+11;
        if (wiafYdkHsXOUaDqCwgXzyEZfol == -3.295665E-36)
        {
            wiafYdkHsXOUaDqCwgXzyEZfol = Math.Pow(2, 2.1);
            int[] CTQaBwRiVRMBDzVUhEXqfmi = { 4856606, 37104 };
            Random jXxCnJ = new Random();
            Console.WriteLine(CTQaBwRiVRMBDzVUhEXqfmi[jXxCnJ.Next(0, 2)]);
        }
        int HDmGQIuctwpnYDgRolWHGnLMQDYp = 232724701;
        while (HDmGQIuctwpnYDgRolWHGnLMQDYp == 232724701)
        {
            HDmGQIuctwpnYDgRolWHGnLMQDYp = 616450;
        }
        float ICNoXcTNOVZU = -7.786986E-07F;
        ushort yZqsSBPnK = 5462;
        sbyte dXtsLO = -81;
        ulong HKDwXXVEeVzReVVo = 86280647783006584;
        ulong QDHiHlINRpOXUDUKGiJpY = 55969503084186446;
        string IKnhsWVnmjseGCDGERPaKmxLO = "FXtjH";
        ulong zfmHwDOKUxfHXRCJHAjlbgun = 35536676020423818;

    }
    public void ohwoZhobpPRpdQndnNK()
    {
        ushort OqMZdbowNZtEbJKf = 25227;
        long UkLsEXAEYnJ = 33528493369788641;
        double ZGEPyM = -3.604753E-28;
        while (ZGEPyM == 2.332077E+30)
        {
            ZGEPyM = Math.Ceiling(Math.Sinh(-5));
            try
            {
                int eMkUGhEfkxxupPd = 9433766;
                if (eMkUGhEfkxxupPd == 82108)
                {
                    eMkUGhEfkxxupPd++;
                }
                else
                {
                    eMkUGhEfkxxupPd--;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        short aUgKcTSwClgIHJWpyJOZLQU = -26558;
        int BxiIMIlixwZoIJ = 949718513;
        if (BxiIMIlixwZoIJ == 566263)
        {
            BxiIMIlixwZoIJ = 250659;
        }
        ulong USEncocjZbgIs = 75866107885780963;
        uint ibebOjyCpHg = 307076;
        string FWfmwXhapCLNXdR = "htDwmXnoaCB";
        float lTW = 1.923041E-36F;
        float qZfsaaOAcxByApZi = 2.238811E+12F;
        byte JRlTypZeIOWVjpZimkul = 45;
        ulong EbcsLlLih = 20292984342052349;
        string RnBFniqQVDnYzUFISuYoT = "GOeWAzwaoKkAWYdxPjtwPHTSPXWf";
        ushort NMQUJMBqKSwUmFOY = 62531;
        int wGPVyhYUlhCDpHPXzK = 29;
        while (wGPVyhYUlhCDpHPXzK == 29)
        {
            wGPVyhYUlhCDpHPXzK = wGPVyhYUlhCDpHPXzK + 497013;
        }
        uint Uto = 81;
        double CYVXQsMKRn = -2.003659E-27;
        if (CYVXQsMKRn == -2.856886E-18)
        {
            double VqlAhowymGG = -6.970476E+10;
            CYVXQsMKRn = Math.Floor(VqlAhowymGG);
            object PITZJqqFBJn;
            PITZJqqFBJn = -1.967497E-14;
        }
        uint lfTGc = 6089;
        int GXENMQUXjCHLZsOyoAifp = 4185;
        if (GXENMQUXjCHLZsOyoAifp == 281061)
        {
            GXENMQUXjCHLZsOyoAifp = 564964;
        }
        ushort hGbpXiGBkEJUMkuStlNeiN = 52868;
        ushort ttCMlymAkbVGubii = 61174;
        string AlEcbZgcQpEuQFRFQdPZfxuCiAmZ = "EWlKTXnP";
        short MfwxjIIebEyseheQ = -28631;
        float TDNh = 4.746221E-21F;
        ushort LWIEQAEcULZk = 57437;
        uint lwNlReFcTxMyX = 953228821;
        int PpWhuaIT = 101498;
        while (PpWhuaIT == 101498)
        {
            PpWhuaIT += 613285;
        }
        sbyte hCNfaEmgTOg = -109;
        string dWiPwEGlSuftpZtXQQDg = "ykyjlcPnHUERUboXnjGMVKsZ";
        long nNWXpCVRG = 32035545941595158;
        uint CwXeaDHWwTOSyCZPc = 6759;
        int VcwE = 6527;
        while (VcwE == 6527)
        {
            VcwE += 952455;
        }
        uint zfRqJVuKFAYSTnejLOGDWAHtC = 773126;
        float RAWoaZwhztxnUyweEKY = 1.37026E+24F;
        ushort qWVZAz = 52062;

    }
    public void hBeOab()
    {
        int nJcmujncckoYRPqOxsFteaWJJl = 7769;
        if (nJcmujncckoYRPqOxsFteaWJJl == 408136)
        {
            nJcmujncckoYRPqOxsFteaWJJl = nJcmujncckoYRPqOxsFteaWJJl + 50359;
        }
        double KVOgNhJTWnjRqsipsIyjOnMtF = -1.306569E+31;
        while (KVOgNhJTWnjRqsipsIyjOnMtF == -5.721878E-11)
        {
            double fwZoGyLkdJASUWFAqNGQdwiwDEliG = 2.086932E-21;
            fwZoGyLkdJASUWFAqNGQdwiwDEliG = Math.Sqrt(3);
            KVOgNhJTWnjRqsipsIyjOnMtF = fwZoGyLkdJASUWFAqNGQdwiwDEliG;
            int[] qmNpccaAEkdUNoYUOccHiWKmFN = { 5315050, 98912 };
            Random kCFAk = new Random();
            Console.WriteLine(qmNpccaAEkdUNoYUOccHiWKmFN[kCFAk.Next(0, 2)]);
        }
        int SinLFpAjfCQonoSCwqKwD = 722229;
        while (SinLFpAjfCQonoSCwqKwD == 722229)
        {
            SinLFpAjfCQonoSCwqKwD += 952415;
        }
        double TsNLncGOsbSxAgdWNWmNYP = -5.273958E-16;
        if (TsNLncGOsbSxAgdWNWmNYP == -2.022424E-14)
        {
            double tCzlicEZllNdoSYcuIumTLkO = Math.IEEERemainder(3, 4);
            TsNLncGOsbSxAgdWNWmNYP = tCzlicEZllNdoSYcuIumTLkO;
            Console.ReadKey();
        }
        ushort sebA = 49437;
        uint WKKE = 2388;
        double cPtljqQFpMToj = -1.678874;
        while (cPtljqQFpMToj == -1.065956E-16)
        {
            cPtljqQFpMToj = Math.Pow(double.NegativeInfinity, 2);
            object GGQMKLlMDBLNUkUSjmpdtUpZ;
            GGQMKLlMDBLNUkUSjmpdtUpZ = 2.024692E-28;
            Console.WriteLine(GGQMKLlMDBLNUkUSjmpdtUpZ.ToString().ToLower());
        }
        string EFqKhS = "hPuSNwLoRusDwuKD";
        uint PDpFwANamqLIIjpqjcEqiKYoy = 4030;
        string NTcQStpiDuUeNitFiNim = "jIYkJ";
        sbyte bhaeNtAzJSPQZiIJJm = -20;
        uint LnIlNDDldFjmMhwtQs = 6634;
        float qXsnWDYpYmFZqTtSZQXmGmGEmal = -9.696867E+26F;
        float SKPX = 3.169131E+28F;
        uint ZmOHXJNRCaYsELJpdsPa = 323698913;
        long djMpCWJYBiXZRGI = 4913845683455730;
        sbyte ATs = -106;
        uint JFqENWyoFsZRuOJzyKUBMH = 5599;
        uint FoccpUbynuBcUXcUeXULet = 60;
        ushort jYaclOccshmDbfPWAnYu = 52539;
        double RCwJPGkWbHJKdyl = -3.063007E+18;
        RCwJPGkWbHJKdyl = Math.Ceiling(Math.Sinh(-5));
        object YAUUzqSaGQ;
        YAUUzqSaGQ = 4.079591E-13; int VXXDqktYPtkoDYhjENFJBTUPqWC = 78462484;
        if (VXXDqktYPtkoDYhjENFJBTUPqWC == 207311)
        {
            VXXDqktYPtkoDYhjENFJBTUPqWC = VXXDqktYPtkoDYhjENFJBTUPqWC + 986901;
        }
        double GqhbytzJpksZwbAck = -9.608523E+34;
        while (GqhbytzJpksZwbAck == -7.074894E-34)
        {
            GqhbytzJpksZwbAck = Math.Ceiling(Math.Cos(2));
            int? ZbCBDiWHOJoGRjbsZAHIzd = 7600909;
            ZbCBDiWHOJoGRjbsZAHIzd += 58969;
        }
        ulong WFgiJbkWtjIdF = 48471189606168842;
        ulong dBVitKbEn = 55082146971514068;
        int VWnVg = 924079903;
        while (VWnVg == 924079903)
        {
            VWnVg = VWnVg + 392100;
        }
        ulong itdIOSRm = 60346290159574235;
        ulong QxfSpQFP = 62046162513603881;
        sbyte skxCOREoTDLAGtkg = 18;
        short qdmdY = 991;
        ushort pwCuxjRxEOoJnoaXcdTSgR = 6126;
        short TQxehzaufmUsiooOWIsnH = 21869;
        string paUI = "FzplLEtusxpooibfG";
        float EdjjMacbOtPgFsSBPFfzMWuF = -5.372275E-35F;
        double JbXLheezunEk = 165.9865;
        while (JbXLheezunEk == -62683.02)
        {
            JbXLheezunEk = Math.Sqrt(4);
            int[] mufBbUQjqtbWscVbP = { 2030155, 68177 };
            Random kMbzPPpUjYiSFAp = new Random();
            Console.WriteLine(mufBbUQjqtbWscVbP[kMbzPPpUjYiSFAp.Next(0, 2)]);
        }
    }
}
public class CMAG
{
    public void ToqEcqZOqXZTmAPGqkg()
    {
        long bzODHhtTAdWGghiylnDkjRVGH = 83469918074562841;
        ulong REbwjHUSUcmgqHheWFAHjEhWFx = 8948183745414763;
        short kSsFpZbDtVumofEOwhJmweROhyD = -11042;
        uint PcomUelVqkDGDJblh = 96;
        float jHeAfaFySxK = -4.02918E+24F;
        sbyte XblACAQyKPDh = 59;
        float tsImFwkNPdI = -0.003191164F;
        ulong CMEKogYApQuiuLESSCDcqyEBWN = 79185273368082215;
        byte FcHjwTsxklQcllPWWMCehcNDS = 132;
        string QcAExMmPVtHyeh = "LWkljdduXoj";
        long pdqUQVGiMmGAYabEe = 51828780114922847;
        float MIDnmdLARbMI = -655.0713F;
        sbyte JGMldcRSkjJPnyLFWEUBjZswmBjC = -38;
        ushort zGeXbEInKRKcduWkuqhLGIHO = 44839;
        byte ZDToAPukjjB = 171;
        string ojKAXoaqoP = "kMjQZpnP";
        byte LRCknJjNbTIfypzWoMXpI = 67;
        string odjwk = "mUQGFtioKGREnWDfnUscbCRVay";
        ulong VkAOChHOpRMeOZc = 83967778884231638;
        short hSMc = 25302;
        int GLtzgc = 11;
        while (GLtzgc == 11)
        {
            GLtzgc = GLtzgc + 439943;
        }
        sbyte nbzAxWyGVN = -21;
        sbyte toULwmFzdGFkxbURNtshPU = 81;
        byte yIKZPHcXqJQwdujDPk = 105;
        float aUDPitebWA = -2.369913E+08F;
        sbyte FVznZCmetdwJYhGaKwunxNgkHmYWw = -83;
        short WxFIpXxsbWCztAwWwVQdlTCR = 18431;
        byte NDqJjMHNDDYKNZblBlIS = 34;
        float BBtn = 4.241443E-35F;
        float TdpKQLmqNNNTtykddkHaGgw = 5.406275E+28F;
        uint iRydKIPfHyplBnVVeuZJcopk = 4266;
        float MIPPoVe = 4.689898E-18F;
        long kEsF = 27968156703191594;
        sbyte RNUBmLmOHtZICWGjuGwpOeLKKxu = -50;
        sbyte BqJTyijabYQxWZG = 119;

    }
    public void bBEpGVQhM()
    {
        string QRqXIiT = "YJAyZuEyAqiLeMisPDhU";
        ushort LMfajkHTPNfXZFDdFVbypQEqee = 42316;
        double fbYmfXN = -2.38692E+35;
        if (fbYmfXN == -2.673291E+24)
        {
            fbYmfXN = Math.Ceiling(Math.Cos(2));
            try
            {
                int PNHLJHKniMWtcjxgOgoD = 9082855;
                if (PNHLJHKniMWtcjxgOgoD == 87090)
                {
                    PNHLJHKniMWtcjxgOgoD++;
                }
                else
                {
                    PNHLJHKniMWtcjxgOgoD--;
                    Console.Write(PNHLJHKniMWtcjxgOgoD.ToString());
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        long zRYaYqCiqTHYdaM = 4582842329256936;
        int lFGUyOu = 261540;
        while (lFGUyOu == 261540)
        {
            lFGUyOu = 182030;
        }
        uint mXXKwHybtnMHqLycBuRNNVoU = 25;
        uint CkxnRNLdyHiDODmGLhdQQwaL = 7237;
        string JdGihIBiSzP = "ZuGTknYjJKiWjJZfjM";
        double Kuwtb = -1.477906E-08;
        if (Kuwtb == -5.502146E-33)
        {
            Kuwtb = Math.Ceiling(Math.Acos(0));
            object UGZlSkTRhFWWELTEpclRsS;
            UGZlSkTRhFWWELTEpclRsS = 4.824085E-29;
        }
        int eWVMs = 86;
        if (eWVMs == 516212)
        {
            eWVMs = eWVMs + 179819;
        }
        double zAplVgJgLOXG = -1.509173E-29;
        double FiMXpCqUROfmDl = -6.320381E+20;
        zAplVgJgLOXG = Math.Floor(FiMXpCqUROfmDl);
        bool? gYXtiXfWW = new bool?();
        gYXtiXfWW = true; short UaStTUfJN = -30368;
        long ykaORtGgMDA = 31353889507642256;
        uint LzhfNdbeBBmNsBJpQym = 22;
        uint ChQnDTBoygLM = 85147087;
        long pEblb = 69097948724583500;
        short wkhHXWPzkZlPGIPW = -2401;
        sbyte WxjoookGjUXj = -59;
        sbyte oBFkLhBfQlQxqDoMyiJw = -107;
        byte SsNqFFnPXJZsnsmyjxqucASUcVh = 125;
        string LDdGNTXRVBCySNskauk = "zYORTtAToKxONsYxnJFtBt";
        uint SGHeCSUOoqhMPmNuteCkeOKB = 90688534;
        double PRkezXZnMwqy = 1.353859E+12;
        while (PRkezXZnMwqy == -9.316488E-25)
        {
            PRkezXZnMwqy = Math.Pow(double.MinValue, double.MaxValue);
            object UwFROmilVsG;
            UwFROmilVsG = -6.598612E-15;
        }
        ulong DcJNUoQHPMtbguH = 52839015906226971;
        string hNlYjGxfYcPfAnWfMR = "qBhpwYpRkyqBj";
        int NDEJGfWW = 34;
        if (NDEJGfWW == 315087)
        {
            NDEJGfWW += 834589;
        }
        long ukzLcZyQZ = 89223138262082743;
        short uCcknuFZXEMaaDkWp = 14498;
        double NfNJNq = 7.584921E-19;
        while (NfNJNq == 2.771466E-19)
        {
            double LsakpzaAmnSP = 1.292514E-38;
            NfNJNq = Math.Floor(LsakpzaAmnSP);
            bool? TDiPnOtyWJ = new bool?();
            TDiPnOtyWJ = true;
        }
        uint UDcRQGulRBaWZ = 261571;
        long CsWqSd = 17597448597871518;
        long YEuHAJCVL = 75284920697344734;
        uint nEdbzIVJ = 4415317;
        short zsKaZTaITQb = 7426;
        long hsCieZYStKUCVZFZSTxSMVUENuW = 13930992494452191;

    }
    public void gCXpsGYZgzXbdTYhj()
    {
        float lzYwLcf = 7.410359E+28F;
        sbyte iqzcSpVgBfWUyo = -18;
        float zBwnBwndifmmmfdSKoGDaaIl = -4.050134E-13F;
        string EBgnhobwMhJ = "kYKkJTnZTbNZRqPzSilitYAJZZf";
        double JgCHK = -3.641257E-36;
        if (JgCHK == -13515.31)
        {
            JgCHK = Math.Pow(2, 2.1);
            object VkVltgZNgwGc;
            VkVltgZNgwGc = -2.004104E+13;
            Console.WriteLine(VkVltgZNgwGc.ToString().ToLower());
        }
        sbyte FggfEplUwOhkHCOpQN = -19;
        sbyte UumKBftgzTufsHmZUjRiLHqhqsue = -71;
        uint eXGKMTwckTNWVOfnUBpWDG = 235779937;
        byte ftiL = 67;
        double hohNWBgzgGoYKxukeAEVDhAYtxJOc = 0.1899547;
        while (hohNWBgzgGoYKxukeAEVDhAYtxJOc == 7.116078E+33)
        {
            double XajzxZKnEHLhekKay = 0.01527561;
            XajzxZKnEHLhekKay = Math.Sqrt(3);
            hohNWBgzgGoYKxukeAEVDhAYtxJOc = XajzxZKnEHLhekKay;
            Console.Write(hohNWBgzgGoYKxukeAEVDhAYtxJOc.ToString());
        }
        float iTZh = 1.3469E+34F;
        ulong BJgouoqUoIQoBzSOonXlyyfwTaD = 60182113755326760;
        int DeysVRPsDDLblTEZEzdEMxuM = 58873627;
        while (DeysVRPsDDLblTEZEzdEMxuM == 58873627)
        {
            DeysVRPsDDLblTEZEzdEMxuM = 50248;
        }
        uint mZMiBUCH = 491;
        short SEdezeJCkbdgLLH = -11379;
        uint HAbBPlg = 4925;
        long xnJeXUgBnhIuZZkVGyPmkhgxRwsP = 30855958345323192;
        ushort ORA = 53103;
        byte Yfc = 131;
        int BXLyMogmnCC = 6799;
        while (BXLyMogmnCC == 6799)
        {
            BXLyMogmnCC += 411293;
        }
        ushort yCFKXNuW = 6241;
        ushort sRlBxgUCTAHhNlohgVXWLI = 19946;
        sbyte WmNKqtcPEjLgiTXiUCMQuRzI = 22;
        byte hCa = 176;
        uint MBThR = 125386;
        int jbFbYbaORgFp = 1077;
        if (jbFbYbaORgFp == 99635)
        {
            jbFbYbaORgFp += 72188;
        }
        short nDAjbxtdbcZFlcHxdDoYgNjDXOq = -6880;
        sbyte MyOJ = -111;
        long waDJXNPhZeszsbDOt = 88260082426494468;
        double pCRDYZUIDNpjawwYKZVNajKwVDnGi = 0.0001244736;
        pCRDYZUIDNpjawwYKZVNajKwVDnGi = Math.Floor(-1.060468E+07);
        for (;;)
        {
            Console.WriteLine(6.742528E-07);
        }
        long tmbLzuAHWqVjdq = 40295015544820717;
        ushort cdoJIeMYWVXQouxPT = 75;
        ulong yDJDFuaqHOyUQzIw = 8864206536334912;
        ushort fPhPeZIXfBwMemeush = 29517;
        string QMbKcaYTBoAjaokjRKzmTthauMMNk = "fMpFocffcYKdFkVCdYT";

    }
    public void CzZQfxFb()
    {
        short okJViNTxZhd = 14244;
        long DPPWeSJOUadIMAzT = 3418405181881776;
        string JHYLgQR = "nqIIWyIBqISBbuYg";
        long VVQdtfTWjbQiUnRmlglRiseihORDg = 49197387209378325;
        byte COanGLiNFKPhRUSQDRHVGnqPVtXg = 192;
        short DbjKchezzZbmTsgRXjqsedoqnyk = -9156;
        byte bZlOlgIkQJysiVFazyODaXx = 2;
        float MSxGXMlLXbbefZj = 1.142419E-10F;
        long NVuNmYOFKMeDkXNwPOkLMfyXDZt = 64515416343207129;
        int eiHihDYTAQh = 5869;
        while (eiHihDYTAQh == 5869)
        {
            eiHihDYTAQh = eiHihDYTAQh + 943486;
        }
        sbyte yyknGyQqzCPeTjdKFFD = 18;
        int edikYjYowRXyfUU = 8590941;
        if (edikYjYowRXyfUU == 216787)
        {
            edikYjYowRXyfUU = 505764;
        }
        short LniBLtEuFcZtheuAGtigY = -22616;
        ushort jPJF = 53692;
        byte YNtyXPKmVRxs = 99;
        sbyte MRGlMSqkMESfpVKZE = -33;
        long GOI = 76953664828080905;
        string JdSYFABHDIUeKtqkSSYKfVXjiCQM = "WjNQ";
        sbyte SSbZUjudgNtbDPbxKSsS = 67;
        sbyte QcJOEGzgnCNztRSdALSRx = 75;
        uint XbAAVzpTNi = 9519;
        byte RyJHeAQpJGSOSg = 234;
        byte aCuQCgYlP = 56;
        float jGUScUuiPLazItUIhGiXzW = -5.55217E-07F;
        float pqKwonWFzZXVQmCfypB = 4.345134E-26F;
        sbyte qdjcWmnwz = -123;
        ushort dAuwNDcUUKlQVxtzVV = 59766;
        uint esqflaq = 5890;
        uint tKyGdUOtfnsHSthBTPAEfYxZgdo = 539455;
        long plsylYNwagCsUMLANeBzw = 43461239034036066;
        int RuEcwBWVC = 37;
        while (RuEcwBWVC == 37)
        {
            RuEcwBWVC = 630535;
        }
        uint wEDxbmnkq = 46424;
        double nwuUKXpKpZQiYscF = -1.804448E-24;
        nwuUKXpKpZQiYscF = Math.Pow(2, 2.1);
        //MessageBox.Show(nwuUKXpKpZQiYscF.ToString()); long DPbgtggXbjOIniZCiEWIYzqEkVg = 49609868986866902;
        int GTXeoDwUesPOXQnob = 77799858;
        while (GTXeoDwUesPOXQnob == 77799858)
        {
            GTXeoDwUesPOXQnob = 468325;
        }
    }
    public void uAK()
    {
        double KlUyaDLZEKWWJgDq = 0.2274879;
        while (KlUyaDLZEKWWJgDq == 1.560208E+38)
        {
            double dLwWKPS = 2.674963E-30;
            KlUyaDLZEKWWJgDq = Math.Round(dLwWKPS);
            try
            {
                //MessageBox.Show(KlUyaDLZEKWWJgDq.ToString());
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        sbyte sWSpdUUeznMxxHDmuLzTc = 21;
        short AmlPKyVIZjZaxmlEsdbBczmQzVGP = -13542;
        byte NIVRQIfubtdxlICRgzUC = 250;
        int TaZxqOSfsNDlsCxwVlJahZb = 18;
        if (TaZxqOSfsNDlsCxwVlJahZb == 472558)
        {
            TaZxqOSfsNDlsCxwVlJahZb += 316730;
        }
        ushort JkUbQRlPGimLKKwjpKdZop = 35066;
        int YYmwKtPYbTbyAHEJycSUnsqOMOO = 4089;
        while (YYmwKtPYbTbyAHEJycSUnsqOMOO == 4089)
        {
            YYmwKtPYbTbyAHEJycSUnsqOMOO = 273443;
        }
        sbyte TZtVPyNIQuMQdApRmKLGGHAJW = 25;
        uint FCsjsPLKegcyCKBua = 700839869;
        ulong GeYDB = 30957577298986513;
        string bDzoOHNgIn = "WgfJY";
        float yZxtHRDAjthSCqIlsyAwazS = 4.321973E-13F;
        short pfwbaogNdTIVHM = -14249;
        ushort YPMOnVNkAAOY = 8797;
        ushort swmu = 50964;
        short EuFEsL = 2944;
        float LbAaDDIbkIRCPtOWwGEkA = 3.490198E+12F;
        string kqjLDcJGRcXIyAPNljgBGObQI = "fYIjRtziqkzpIGiVYqRoYfOzmLDB";
        byte ptcFWKYHlEjnhF = 73;
        float BsLQLZsYZkjWfRXXU = 7.859125E-32F;
        byte JzXq = 24;
        byte KXiis = 47;
        string BHGuKHX = "OLfMlqnKjIzRUOz";
        int mobbaEWPPynoLExMZiGZCT = 6921;
        while (mobbaEWPPynoLExMZiGZCT == 6921)
        {
            mobbaEWPPynoLExMZiGZCT = mobbaEWPPynoLExMZiGZCT + 721333;
        }
        byte NhZIyqVyOg = 48;
        double TZuAebfUGSHkuV = -623.4468;
        if (TZuAebfUGSHkuV == 1.997516E-23)
        {
            double ocffRDw = Math.IEEERemainder(3, 4);
            TZuAebfUGSHkuV = ocffRDw;
            for (;;)
            {
                Console.WriteLine(-1.134444E+21);
            }
        }
        int JnIJ = 8088;
        while (JnIJ == 8088)
        {
            JnIJ = 805329;
        }
        double IORd = 2.851853E+32;
        while (IORd == 6.809045E-32)
        {
            IORd = Math.Ceiling(Math.Cosh(5));
            int? hbtzeSzzGMIcHUtNY = 597593;
            hbtzeSzzGMIcHUtNY += 98060;
        }
        long NjNYjQeWEJAbV = 83999319519787987;
        byte JkfSnsOokOSFjWNCYgRXhUuTR = 131;
        float WpyCCseOeYREQtnmc = -1.893094E+21F;
        float FLgbmLOQlbNBlsVqqdS = 1.424437E+37F;
        ushort pmh = 51285;
        int QMMYVq = 332241;
        while (QMMYVq == 332241)
        {
            QMMYVq += 310739;
        }
        double XddEasWMbWbIiLQPfVhKxoaCqa = -1.505804E+37;
        XddEasWMbWbIiLQPfVhKxoaCqa = Math.Ceiling(Math.Sinh(-5));
        object miUBLiMinyIcClZbXUmMBGFIEGCh;
        miUBLiMinyIcClZbXUmMBGFIEGCh = -9.469094E+14;
        Console.WriteLine(miUBLiMinyIcClZbXUmMBGFIEGCh.ToString().ToLower());
    }
}