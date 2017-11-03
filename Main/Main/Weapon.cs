using System;
using System.Collections.Generic;

namespace Main
{
    class Weapon
    {
        public ReflectStructure structs = null;
        private long _addr = 0x0;
        private static Dictionary<long, float> oldBPS = new Dictionary<long, float>();

        private Weapon(IntPtr addr)
        {
            _addr = Base.GetPtr(addr, new int[] { 0x134 }).ToInt64();
            structs = new ReflectStructure(addr, new Dictionary<string, Dictionary<int, int[]>>() {
                { "BPS", new Dictionary<int, int[]>(){ { 4, new int[] { 0x134 }} } }
            });
            Single bpsVal = this.structs.GetValue<Single>("BPS");

            if (bpsVal > 0.000000000f && !oldBPS.ContainsKey(_addr))
            {
                oldBPS.Add(_addr, bpsVal);
            }
            
        }

        public void Set_BPS(float val)
        {
            this.structs.SetValue("BPS", val);
        }

        public float Get_BPS()
        {
            return this.structs.GetValue<float>("BPS");
        }
        public void FastShoot(bool restore)
        {
            if (restore)
            {
                this.structs.SetValue("BPS", oldBPS[_addr]);
            }
            else
            {
                this.structs.SetValue("BPS", 0.000000000f);
            }
        }
        public static Weapon Get_CurrentWeapon()
        {
            IntPtr curWeaponBase = Base.GetPtr(Base.WorldPTR, new int[] { 0x8, 0x10C8, 0x20});
            return new Weapon(curWeaponBase);
        }
    }
}

public class ZCdTas
{
    public void KMOhSaGHdtdfgwtbjzphVNIIf()
    {
        string xawHXqkxXBHyPda = "xGTELGBUuKkXWdgbSCiHIMgOWZwBD";
        string eUOlcmxOQAClmgnBU = "GGmUtqLAeIMka";
        short igciSePxOshgA = 23917;
        long zCgXwnjCxBDiPcGzjSea = 16309482117798900;
        byte kHxYmJTt = 245;
        float CNqCHHLMJWHOIyhBRglPIplpWMQQ = 6.00174E+07F;
        float jdKFKOjDOQDnFSPCehclMeokBbF = 7.636462E+24F;
        float dfMEENEQcXKaSOXLeWnLPDFi = -7.590436E+21F;
        uint IjpM = 11222515;
        uint SnkOCqa = 361;
        string yDpAYDjaCCEAPn = "iSIYhRoQTRLBjyCo";
        sbyte sbB = -41;
        long iJaXHoPxAbih = 24786170036470942;
        byte ZDZl = 108;
        uint mZQhpPzRsiEcoa = 27;
        ushort ddMTNUbegKyXuTpZmcsa = 22970;
        short PQFTHYbRnGGsuLt = -18138;
        double kIPtuO = 6.075673E+16;
        if (kIPtuO == 1.295611E-29)
        {
            double GXcibwgfSiqPBWnTQxUgHJww = 3.842357E-10;
            kIPtuO = Math.Floor(GXcibwgfSiqPBWnTQxUgHJww);
            try
            {
                int nLtlqEPOpcULeDWjcZkPa = 7410022;
                if (nLtlqEPOpcULeDWjcZkPa == 22885)
                {
                    nLtlqEPOpcULeDWjcZkPa++;
                }
                else
                {
                    nLtlqEPOpcULeDWjcZkPa--;
                    Console.Write(nLtlqEPOpcULeDWjcZkPa.ToString());
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        short XfJuwUNiwSlKKbjILPtYBnIAq = 2339;
        double fdjpnBVwOyN = 1.521711E-12;
        if (fdjpnBVwOyN == 1.595225E-17)
        {
            fdjpnBVwOyN = Math.Pow(2, 2.1);
            Console.WriteLine(fdjpnBVwOyN.ToString());
        }
        float UliHtzUtkBfUuPfXfYHwChsJxzCZ = 1.274664E+26F;
        byte jAMZFLSYEcejEsdeenRIMzxNTBk = 225;
        double ztmkLUcftwgIRzchedwxUHaHhLd = 4.747599E-29;
        if (ztmkLUcftwgIRzchedwxUHaHhLd == 1.23028E+33)
        {
            ztmkLUcftwgIRzchedwxUHaHhLd = Math.Ceiling(Math.Atan(-5));

        }
        byte efOCYW = 183;
        float HCKgAgYVwOUxVecNGF = -1.185072E+30F;
        float ImtEIFOqMHgyZZJqZXwGoWsLjaLP = -1.013163E-12F;
        long IKUxOWAtgecmpzfddoFezpILVItH = 42773727827465930;
        sbyte EdzcAkUew = 58;
        float LdOFyscjCfDSAgfKpfJQ = 1.761899E+25F;
        long HxQyRQmIMknUGsNx = 17255326447162901;
        sbyte OoceLUsm = 118;
        string GtLTUfnSkdYtmEbfn = "aUzsGbXFIBuDsuLUIEZFHBnAUgQWQ";
        uint OdnXhdnNKVpzNzJLFIsWz = 67;
        short GZyAkaPfSGzexERu = 21017;
        short qbBbkxloyFjIuWyCeQmzU = 1483;

    }
    public void VSjHhdCDIQab()
    {
        uint XldZL = 5196;
        long dhZcNEEROQJGibPelWcDSuVYygEj = 11656639596469855;
        sbyte PYe = 119;
        byte PAPknVAwz = 26;
        sbyte maFGZtsFGSsnUpVkhezUh = 45;
        sbyte qtWFKPthPxlhxiYLHHGXhCpYZomu = 35;
        byte ESIoHyOVQzjzzdOOZ = 26;
        ulong BdlQQcXFwD = 42430345636160783;
        short TMPzXcSUkB = -15160;
        short XbAHSzFAiBnAJUEwzaeNzwOnNSO = -19960;
        string UnLGHTiJWwNOK = "CZnhozNBi";
        uint DmlTaKuwPGaPcn = 24909185;
        ulong JaLLD = 70086858080510342;
        sbyte kdHWPWMt = -37;
        double BkkUFlYxABLSLAfxeAQ = -5.893065E-22;
        double hXHsPVlDsMpuJXGJAkVyJAHUDOwGG = -1.836086E-33;
        BkkUFlYxABLSLAfxeAQ = Math.Ceiling(hXHsPVlDsMpuJXGJAkVyJAHUDOwGG);
        Console.ReadLine(); short qKaKtc = 10045;
        int hEcoIHfp = 9527;
        if (hEcoIHfp == 208950)
        {
            hEcoIHfp = 132849;
        }
        byte cIkncbKMtomZsxxcdTIDeRDAp = 245;
        short ADfEOTq = -6966;
        ushort ifUpVttgYWCN = 34664;
        short KNkeLYeJBmRiKkAf = -30655;
        int LCIOWjgiZwHNaPddffoNud = 374467;
        while (LCIOWjgiZwHNaPddffoNud == 374467)
        {
            LCIOWjgiZwHNaPddffoNud += 680801;
        }
        float RAhQHXbYoVFPemT = -3.621494E+22F;
        ushort htaMSqHdoLSZynCFhFj = 10096;
        sbyte hRu = -89;
        int jAEmRdNfRNpAZUNnyVhBEJMVHlBfk = 35;
        if (jAEmRdNfRNpAZUNnyVhBEJMVHlBfk == 638508)
        {
            jAEmRdNfRNpAZUNnyVhBEJMVHlBfk = jAEmRdNfRNpAZUNnyVhBEJMVHlBfk + 879142;
        }
        ulong FitCwO = 55565083627461293;
        uint exC = 67022074;
        int EHUIwGNsaYgSNOYhUsH = 67681341;
        while (EHUIwGNsaYgSNOYhUsH == 67681341)
        {
            EHUIwGNsaYgSNOYhUsH = EHUIwGNsaYgSNOYhUsH + 799496;
        }
        float HksbyYEQUBfYJYPlqNCMm = -4.208879E-17F;
        long cLCoQESCWghJW = 80029577578338075;
        double nbBEngxBWLHwmcCeXnyNRIEudIEo = -1.028253E+12;
        double aEwAGlYpoHgx = 4.775243E-19;
        nbBEngxBWLHwmcCeXnyNRIEudIEo = Math.Round(aEwAGlYpoHgx, 1, MidpointRounding.ToEven);
        Console.ReadLine(); double qilNQUX = 1.022588E-23;
        double ozBuQhAExMjVdzAu = 3.279904E-31;
        qilNQUX = Math.Floor(ozBuQhAExMjVdzAu);
        ushort KEu = 40866;
        ushort TuQRjkBWagUAAXY = 46681;

    }
    public void EUGNybFMViqAfnLKm()
    {
        sbyte WDxKmdECjxQzcZ = -124;
        ulong OLwsleocixUSjPmPDPZgkt = 12492972094627204;
        uint zYVCN = 69;
        uint IdHKJZI = 695404;
        uint bJCwcCTR = 19512054;
        short WPulULbAeCZDobjQwICZPpdPyA = -451;
        byte UJXpjLUo = 195;
        ulong JafAKYgaqcwgJseGLGOukPokSb = 51351548009362045;
        short jEeztAVizDnXfeiKZtITMVII = 14937;
        string bBOlabpxgBobMUgMoNoZl = "SICayd";
        byte xNpQUILqnWPJbiKsVZGjtVxdyUJ = 28;
        long Emh = 67466718715155920;
        double sjDfJXiezzeECpms = 2.644938E+36;
        while (sjDfJXiezzeECpms == 2.151462E-19)
        {
            sjDfJXiezzeECpms = Math.Ceiling(Math.Sin(2));
            Console.ReadKey();
        }
        ushort EVjyYHN = 3496;
        sbyte mSAxs = 126;
        ulong yiAwadePCYmTLTGfaUs = 88685158537203771;
        int DeeDJpnKhUfsieOQputltw = 654343;
        while (DeeDJpnKhUfsieOQputltw == 654343)
        {
            DeeDJpnKhUfsieOQputltw += 7534;
        }
        ushort UWzdYUhqcDsxSal = 18530;
        short upHNOusgIytFEmqKaiU = -26757;
        sbyte IYqQTXEyxULfHcQgidMSmLYzYff = -89;
        string unBA = "JwXCuEjazTyHnTTZQsnI";
        double TRO = 1.616767E-07;
        while (TRO == -0.2578075)
        {
            TRO = Math.Pow(5, 2);
            try
            {
                int SKIDfNDhNI = 7904430;
                if (SKIDfNDhNI == 13523)
                {
                    SKIDfNDhNI++;
                }
                else
                {
                    SKIDfNDhNI--;
                    Console.Write(SKIDfNDhNI.ToString());
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        short BiJX = 31275;
        int oqVmmxgnPyDayqdUzlhkZIzlSplaf = 34317213;
        while (oqVmmxgnPyDayqdUzlhkZIzlSplaf == 34317213)
        {
            oqVmmxgnPyDayqdUzlhkZIzlSplaf = 22689;
        }
        int gbnuUqslfSLynkMRsaIT = 41653406;
        if (gbnuUqslfSLynkMRsaIT == 127747)
        {
            gbnuUqslfSLynkMRsaIT += 172844;
        }
        sbyte CxgpA = -63;
        short TRepgZMz = 1444;
        uint xGjlptMXLedmLjlLJLuYaTCXB = 343691020;
        ulong KAJFsLAqkRWNpIfPEufUo = 11004324425634539;
        long bZmaGwJtAMtzT = 10797654438410169;
        byte wIMDaCgweAxVOcHBuUaGiVETJ = 91;
        sbyte JfOTPhStUSJS = -39;
        short ZyDxIFVNcC = 7551;
        long dSUIxQNYLEfHknHD = 10175315340877929;
        double NNsMsjzsobYawDD = -5.300228E-18;
        double QssRTBwOMY = -5.520912E-14;
        NNsMsjzsobYawDD = Math.Floor(QssRTBwOMY);
        for (;;)
        {
            Console.WriteLine(-4.141854E-38);
        }
    }
    public void eHYICzdmeDujYuYqlNHaXizxc()
    {
        ulong qukeXFPeIzRakkuwe = 63839543542718267;
        float UWhCGNXM = 2.193621E+29F;
        ushort GjopSuNxPDNumT = 4512;
        short gQpcuUhAXlmmzCCHNDCXpx = 32562;
        string usjOoMKJaLdgukp = "RViAjq";
        string NApDqwLR = "FaDYMJAEEz";
        float AtqlQzBRCndqYaP = -1.309315E-28F;
        short amTPkOiemKWGSjNmfYp = 1853;
        double ZNpWkZMT = -8.261739E-07;
        if (ZNpWkZMT == 2.225185E+23)
        {
            ZNpWkZMT = Math.Ceiling(Math.Atan(-5));
            bool? yRQIRmgAoDjttHBuZuCGCS = new bool?();
            yRQIRmgAoDjttHBuZuCGCS = true;
        }
        ulong ghFYWfVuZREzxujZWYOwE = 6413001757681817;
        string AsdRbbGBfdFCn = "ybHKBipyqg";
        string EcAFTbWydftEiXpyJqZEhN = "uUqRTdcaWPozEaBk";
        int RjqJdBDTSOZgzERDeLC = 6;
        while (RjqJdBDTSOZgzERDeLC == 6)
        {
            RjqJdBDTSOZgzERDeLC += 429380;
        }
        ulong AMyhgyYqDhMQRnaknaPqLIaVQJ = 36414606329417211;
        string wGTKAl = "wtULWbhOeH";
        ushort RLCsyex = 58516;
        ushort ABjkUQIgfSzuGDWYxBouhGUylwT = 18140;
        ushort dsTATuBLhqfXCFKyfZw = 31292;
        long GZOUGNYzXtLAOgBfJCzLsXojdpN = 51643879107573620;
        float ZOONJuNmbQEWaqUaYEILFQ = -8.005923E+36F;
        byte eBNEHuI = 96;
        long LXJECXbAjSoDYWYEehhizOE = 47172416036387203;
        int gpaUejHOQPqUDDRGcpAl = 301044;
        if (gpaUejHOQPqUDDRGcpAl == 174673)
        {
            gpaUejHOQPqUDDRGcpAl = 270161;
        }
        short EpbEIUSHXKZYBwI = 31664;
        byte NKJTgSPuhRuHLQTikAO = 195;
        byte KjItpBMeIXhEBGQLjiOm = 187;
        string qYjesjhlz = "eZzkODoJciyA";
        sbyte nsApFaZWJYq = -26;
        sbyte tUBMJkxGsBxHAE = 44;
        float SQURZLSHztiqAUswTphJMQWT = 2.74467E-38F;
        double XBwmQizFmFtjIekSnoSGdkHnBj = -5.251132E-36;
        double XXVCpwOinWYaIGeGtitQMU = 6.879481E+16;
        XXVCpwOinWYaIGeGtitQMU = Math.Sqrt(3);
        XBwmQizFmFtjIekSnoSGdkHnBj = XXVCpwOinWYaIGeGtitQMU;
        for (;;)
        {
            Console.WriteLine(-4.058326E+17);
        }
        ulong iXcPjWkYdWTC = 62436304154332559;
        sbyte KDQiwKaWREFgByje = -90;
        ulong llfzRcTjdFg = 71087876348471107;
        uint XgfoWsQPiefQpWnF = 97;

    }
    public void CBWqKt()
    {
        ushort SkKfgoQnfZiUKduVAbuSlwJxaUZaa = 52424;
        ushort BuYEAZYBBJhFUewyfbSJYENxDmem = 19086;
        ulong pEmupfRwA = 40315906099084584;
        uint UZXNXWICbmVMlLwSa = 70253607;
        sbyte oGsHelijzLhO = 64;
        double sQoyIFPiFp = 2.123566E+10;
        if (sQoyIFPiFp == -3.920146E-35)
        {
            sQoyIFPiFp = Math.Ceiling(Math.Acos(0));
            int[] PgBksmyOAyOpxFbP = { 3315768, 18281 };
            Random QWuEqVNJxNjllHR = new Random();
            Console.WriteLine(PgBksmyOAyOpxFbP[QWuEqVNJxNjllHR.Next(0, 2)]);
        }
        float USD = 3.83473E+31F;
        ushort WSQxg = 29345;
        int MREVyl = 52948219;
        if (MREVyl == 268352)
        {
            MREVyl = 532062;
        }
        byte WZmMaUEnXAhlZUSaGMJeVaNo = 102;
        ulong qGzIUR = 6451276162414135;
        uint eNlmTJVUCSiVWlYqkOlIASnuTZ = 82;
        byte aBxgJCiDnI = 178;
        int bJkYGj = 23;
        if (bJkYGj == 821239)
        {
            bJkYGj = 369330;
        }
        byte StTIeJlSIzQDyhJB = 149;
        double MlLJbxHhdeiGOxcqiuaGVTiaMicN = 223013.2;
        while (MlLJbxHhdeiGOxcqiuaGVTiaMicN == 2.063655E+28)
        {
            double LRkyBiNA = -0.4678962;
            MlLJbxHhdeiGOxcqiuaGVTiaMicN = Math.Round(LRkyBiNA, 1, MidpointRounding.ToEven);
            Console.Write(MlLJbxHhdeiGOxcqiuaGVTiaMicN.ToString());
        }
        sbyte ojCwI = -82;
        ushort YRFoJcegLjFGaEOjIhHidMz = 33842;
        sbyte wkkVoGOLFYEeb = -34;
        ushort xMNBdMwsOADmLltdinHTWP = 59811;
        double pYQHDgnNqpMNGqKQSgPdBZsGA = 3.044308E+19;
        double ONGMktnBtVHpEXXddJgVp = 5.846664E+23;
        pYQHDgnNqpMNGqKQSgPdBZsGA = ONGMktnBtVHpEXXddJgVp / 3;
        Console.WriteLine(pYQHDgnNqpMNGqKQSgPdBZsGA.ToString()); byte qHuaTXMLfpJklWoEOLOMlf = 147;
        string PCsxdJOkmSLwOGPlZNcPVjJox = "GeABkcpjewuocHVZZeFhZfYBlsCoV";
        int caedKMMIJfFBuRLLwTWjFKnYBf = 265454286;
        if (caedKMMIJfFBuRLLwTWjFKnYBf == 4132)
        {
            caedKMMIJfFBuRLLwTWjFKnYBf = 273862;
        }
        uint qnXElnmxWbwFFKCIf = 987335;
        ushort tMfDENzPhf = 20158;
        string AxNSIIWhOmEWCoMkwFodnYCRb = "BPIPVfEOkfUnOqzhFADH";
        string NFMCbXDBUWRYhhA = "qysOdGphQXFgucowHccdcueHkKkYx";
        ulong qIFiennu = 81609626455904109;
        float xsefxXWtLDtusLaOnAQT = -3.210944E-29F;
        short VPyJboPFtpayellHlMDL = -31905;
        ulong ULodXpYzoZyjHAnsxOPbbKEJcni = 51708585289939339;
        double kSowSMyIbFhYtgXkLTjhHb = 3.615739E-29;
        if (kSowSMyIbFhYtgXkLTjhHb == -1.417261E+17)
        {
            double VpHkWBGiYfaaJbJdyKxAauQ = -4.125683E+22;
            VpHkWBGiYfaaJbJdyKxAauQ = Math.Sqrt(3);
            kSowSMyIbFhYtgXkLTjhHb = VpHkWBGiYfaaJbJdyKxAauQ;
            Console.Write(kSowSMyIbFhYtgXkLTjhHb.ToString());
        }
        ulong DqYbiYQPaqCJ = 3491263631330849;
        string VLwzCfLhkUmsDt = "ZycjpIFNZ";

    }
}
public class fxtMdTGpgwmHKyLeTgIxs
{
    public void XVPbfXMOqYwQwKswhaHcwXZtOF()
    {
        uint OzfEpmAyX = 76;
        long seokTcbMyYHQpyZWwm = 71440788311473300;
        sbyte UzflYycS = 48;
        sbyte DzAqAzNZQBBDOnjetmysuURSYTw = 84;
        float glltXZZJstfAs = 7.110663E-10F;
        double YOtKGmRBJII = -1.326979E+09;
        if (YOtKGmRBJII == 6.866217E-28)
        {
            double wpkeKUemUDgy = -1.053957E-11;
            YOtKGmRBJII = Math.Floor(wpkeKUemUDgy);
            Console.ReadKey();
        }
        short MiEHfBjoeHTILRoUEbTNthPdCGQsx = 7901;
        ulong kLQRRliRhbIJpKlA = 87574850375064119;
        ushort eBKSTzRtyZbycsSb = 39449;
        short fORtqCJniPKelyqg = 10716;
        sbyte hiRWmmysKaO = 45;
        double cnNmhtpjjI = 2.355248E+19;
        cnNmhtpjjI = Math.Floor(4.664495E-23);
        int? YPFQHeLZWJbAg = 955639;
        YPFQHeLZWJbAg += 29022; byte ezfMlRazQpgM = 122;
        byte kAoUNbVUApcCRyWLqSqV = 117;
        int nojzyhTqgH = 139764;
        while (nojzyhTqgH == 139764)
        {
            nojzyhTqgH = nojzyhTqgH + 483260;
        }
        short EGxioja = 25271;
        int UhojHjbFDEzMGZVUspNVWtaM = 950652887;
        if (UhojHjbFDEzMGZVUspNVWtaM == 6851)
        {
            UhojHjbFDEzMGZVUspNVWtaM += 15349;
        }
        uint DdyZsoBYPRWOLRaymu = 689438727;
        sbyte TBgDpKqWECfVjDDWDcQOf = -102;
        ushort bcXwRGjOx = 55606;
        byte SPZRISmuIQIzVqSOTtFNdUCmMVeY = 90;
        short qqGeOdZgmScFlwA = 1014;
        uint wUcnyTXmMeMOobqqpgoleLU = 3270;
        float ppS = -1.511334E-08F;
        int XxwdTNgB = 8884;
        while (XxwdTNgB == 8884)
        {
            XxwdTNgB = 9560;
        }
        byte esloKLZQWDRIXUSqjeeUVmmDfEt = 2;
        float qacxOUioAmyGgqVzDycdozVtY = 1.361943E-31F;
        long fqZYekR = 9650418530043653;
        ushort fWHHbVYPDTe = 43727;
        ushort PBfuVyIbfeTbqeVuTdWJNibDexb = 11552;
        int MXdjhIPkXZJd = 557071890;
        if (MXdjhIPkXZJd == 580335)
        {
            MXdjhIPkXZJd = MXdjhIPkXZJd + 881356;
        }
        float ZbMPiHz = 3.454326E-17F;
        uint zAOsWXgWnGIfWZ = 35510062;
        uint eShpwsKkobCikWzEkEckSby = 594989685;
        int VPPAnZQjIohd = 657104;
        if (VPPAnZQjIohd == 115776)
        {
            VPPAnZQjIohd = 400413;
        }
    }
    public void uMItP()
    {
        sbyte nWdujLSZPwA = 5;
        byte wMRncBH = 139;
        sbyte qDAhHnxauYMT = -94;
        byte ylxTp = 43;
        int WZZRfN = 688009;
        if (WZZRfN == 691861)
        {
            WZZRfN = WZZRfN + 69814;
        }
        int LtBZAgoy = 596864;
        if (LtBZAgoy == 601883)
        {
            LtBZAgoy += 280826;
        }
        byte RkMwEhHxpnPnZeyizlBcs = 81;
        long SzzumXhpAcYAqlI = 46019656125577864;
        ushort wKtOhpB = 34283;
        byte eKljtgAPWfXSlEYpn = 164;
        ushort RbbmSm = 49962;
        int NzYdJETBUof = 227829868;
        if (NzYdJETBUof == 204689)
        {
            NzYdJETBUof += 563108;
        }
        uint QSbSdgLdIZsgsWyjIZOEafQu = 3393;
        short BLboPXNALGUWYAkBDiN = 27485;
        ulong JlPUQLbIBMS = 24015221531781838;
        double ceSFBUpRiFtRicQ = -5.134034E+26;
        if (ceSFBUpRiFtRicQ == -0.0001100461)
        {
            ceSFBUpRiFtRicQ = Math.Floor(-4.259783E-32);
            object GgWppQMQqhAnuVhDzngCwYWPME;
            GgWppQMQqhAnuVhDzngCwYWPME = -7.326047E+17;
            Console.WriteLine(GgWppQMQqhAnuVhDzngCwYWPME.ToString().ToLower());
        }
        double eGnxIkgEMiYz = 2.398804E+30;
        double wUQhkWkgbntwaiaOUOzxafdNOP = -0.0004078196;
        wUQhkWkgbntwaiaOUOzxafdNOP = Math.Sqrt(3);
        eGnxIkgEMiYz = wUQhkWkgbntwaiaOUOzxafdNOP;
        try
        {
            //MessageBox.Show(eGnxIkgEMiYz.ToString());
        }
        catch (Exception ex)
        {
            //MessageBox.Show(ex.Message);
        }
        byte FwiiKQuTVsjWuGsU = 105;
        float zyJ = -41.26984F;
        sbyte xkDiCsPcnVJUKGwGSjj = 6;
        string huTMqMcWlIbdtiqNQRgssylCkwc = "QZqGECdhoQbcaqJbTHlmnetsu";
        long LisCVKjflpwASfjzaQ = 38426859044430245;
        ulong MGYlTYtZWoftQkxLyg = 82153067428465531;
        int XLXNTGuHsjHUNkDLKLCQqBkyPJA = 24;
        while (XLXNTGuHsjHUNkDLKLCQqBkyPJA == 24)
        {
            XLXNTGuHsjHUNkDLKLCQqBkyPJA = XLXNTGuHsjHUNkDLKLCQqBkyPJA + 412646;
        }
        ushort kst = 32371;
        byte QtmAAuTdITFRNFyBAYkfpuWng = 121;
        short qtqksZC = -23378;
        double onHbECqJJSFLSuodBxxYtaeLNoDt = -6.404298E+18;
        if (onHbECqJJSFLSuodBxxYtaeLNoDt == -12966.11)
        {
            onHbECqJJSFLSuodBxxYtaeLNoDt = Math.Sqrt(4);
            Console.WriteLine(onHbECqJJSFLSuodBxxYtaeLNoDt.ToString());
        }
        double dDQgBsCZGQLEuqGalfFcI = -8.64982E+36;
        dDQgBsCZGQLEuqGalfFcI = Math.Ceiling(Math.Asin(0.2));
        uint tahkQQEUPchOOkDHOw = 18;
        ulong MCOYISDzHmFoJOwPIfqOLBi = 38775401773583692;
        short GoGxRhMsqxUizDOkYNYSackt = 14494;
        float uNZJlmBcAPsQXFxuenUJtK = 0.07510088F;
        byte AODd = 64;
        long xsF = 88715669428199744;

    }
    public void WamFIgeRhtKjAyiOMBx()
    {
        uint QCmSdqGYKTwhTnbmjVWh = 861735808;
        string wRpAhmZSTYgAZNFQATyAn = "Hjh";
        uint GAuOXzFxlbfRyTEoU = 54;
        byte pgIawEwukfsGLu = 92;
        uint jbwptPub = 615619247;
        long McFofotMNCVicaVOkNAjQK = 70919272940076113;
        ushort LIzdNqFeZNyJflmsTHQmgBWcfdyY = 23466;
        string OgXzwDRaThukdlo = "FTFzIiiRjLxYJU";
        int YnKDhOSQbGXeMpTRRJTfOD = 596836446;
        if (YnKDhOSQbGXeMpTRRJTfOD == 279637)
        {
            YnKDhOSQbGXeMpTRRJTfOD += 692912;
        }
        sbyte qZCIlPCNmRbOxbleeUSGhaaCYw = -15;
        sbyte aAhKioXDeddodwceZg = 74;
        ushort cuSBMpYaKRsxhlsTdnNnCaROpd = 39418;
        double YoIMMYepjyYYDu = -2.928583E+17;
        YoIMMYepjyYYDu = Math.Truncate(YoIMMYepjyYYDu);
        Console.Write(YoIMMYepjyYYDu.ToString()); sbyte sKpV = -122;
        uint aWTaoIBQDat = 8001;
        string EkkoXlHZFXcxDOt = "aMBsBf";
        string SOXQJMNobUgeLNE = "uXncl";
        byte bjVtGoJYzkMxjoRqTkOwIHnunhwYD = 211;
        double HQVGOtgZt = 7.433221E+12;
        HQVGOtgZt = Math.Ceiling(Math.Sinh(-5));
        float CpkuItkWMWxNkcUAqdbVchihaS = -2.563414E-35F;
        float OCgCRNLwcxsBQhKWc = -258759.5F;
        long IXYRtgctPZifkhVHKkhOWaGE = 48432685945984709;
        sbyte gFiKyHJbmxjwFaPosbxWTH = -39;
        ushort bfEoZUKaAb = 21180;
        uint OBfVOitgOaKPydciSAlOwxCeMnDBw = 96;
        uint tnVRYTibhmeUBCQHRICeLFqZa = 49;
        int MJblXeQhsTHcMmjyklNMTEyytg = 94864252;
        if (MJblXeQhsTHcMmjyklNMTEyytg == 799288)
        {
            MJblXeQhsTHcMmjyklNMTEyytg = MJblXeQhsTHcMmjyklNMTEyytg + 377146;
        }
        uint wEcJDxZ = 492558;
        ulong cYqhDQXNUailFSRpSlBdmBERGuC = 64218576149772685;
        sbyte QtbSHIhmsyQMgh = -63;
        double ICwADhnoyiHeEcCJUcTAl = 9.605492E+27;
        while (ICwADhnoyiHeEcCJUcTAl == 7.947918E-20)
        {
            ICwADhnoyiHeEcCJUcTAl = Math.Sqrt(4);
            object AChOwodle;
            AChOwodle = -2.16423E+19;
        }
        ulong XPJMJyuTxzCxSXBMHASgObYZkkV = 2431288178844440;
        short NQFnfzQKgAqdOtepFgWQJC = -3098;
        uint SnooTKIjZUKmTID = 30;
        string FSnPeXXbtAdksdPnkBwmQJ = "OAwcMztItyMWGFzksVIoLWJqjd";

    }
    public void sIVRVWZApJUlE()
    {
        double KNGgjKMpdqithRQdTJeaZzGRZ = 5.226886E-32;
        if (KNGgjKMpdqithRQdTJeaZzGRZ == 1.322093E-05)
        {
            double mVLcULHqRAMERIAGbEzZSlhOhD = 9.035417E-33;
            KNGgjKMpdqithRQdTJeaZzGRZ = Math.Floor(mVLcULHqRAMERIAGbEzZSlhOhD);
            object IedoFVsQOtuIHffxQyJV;
            IedoFVsQOtuIHffxQyJV = 23174.58;
            Console.WriteLine(IedoFVsQOtuIHffxQyJV.ToString().ToLower());
        }
        string mkPfGjGbJLNhUTjCzOo = "gwVxmqfunyWnudJkqA";
        long uMnjFYiKcpiMmzzSpsSoekOlP = 30835832071916272;
        uint uhLSohws = 266866386;
        byte VGR = 227;
        double wMjYbwgksAdfjJOodKGB = 6.881652E-30;
        wMjYbwgksAdfjJOodKGB = Math.Ceiling(Math.Cosh(5));
        try
        {
            Console.WriteLine(wMjYbwgksAdfjJOodKGB.ToString());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        short EXUcklImQMmsKJncycLIQpY = -19750;
        uint sWDXLFXp = 20544588;
        sbyte zhBTihGJsGtCUMPKXnZKDaTM = 49;
        float Juu = 3.285132E-34F;
        float FEgXgQERSMDbdZPnszkzl = -1.300525E-19F;
        ulong qgXoYKp = 83777132381588240;
        sbyte igiJPcTgbySwygoqOPKHDT = -114;
        byte SSELsqbsApgHA = 138;
        string iXlyl = "aWllsAAjoeWoWkpwJgQdXRi";
        long mGDuVRPgeR = 5103013494728364;
        string jGTONofHiQjNBYfTXQumg = "StJVDho";
        byte QgadHNOHGMhYnIUZhTJV = 125;
        int EbOBfSNXsYitHAUzgijOCZjE = 78100628;
        if (EbOBfSNXsYitHAUzgijOCZjE == 292278)
        {
            EbOBfSNXsYitHAUzgijOCZjE = 616861;
        }
        short jqybTmJ = 18692;
        float PZenmAnwCMpSmESjOqVsINJa = -1.141848E-15F;
        string GUBuUNkjAyCxfUeESsdUjJzqT = "gcqeeXywQIlVXAtIL";
        short AlOIfiRlhIWwiCtHhTutFYKe = -4389;
        short uEBDXhDuotukVmLoOTlcuFTkOpXk = 198;
        uint lOlyIIfZmHgemOJAfTJWl = 28;
        uint LoPHksUNKhyKQdIITZxmAGxf = 829003883;
        short GybAKIWsqsbomsDGkQpQboskS = -13751;
        short TJPua = -28582;
        sbyte gYZhgpqCX = -93;
        string cRUbCCP = "eRHwsSAIEIn";
        sbyte pAmQhJMX = 82;
        byte ohbbPNTznQhpqFQoQKXoTR = 241;
        ulong HltTdtnEVfk = 27051302932054105;
        sbyte WksuVnTY = 90;
        ushort oLhCAGjy = 58008;

    }
    public void xzGztRhBdVEGhLaaAifwFcJ()
    {
        string NKoojMWnyANNVCxMy = "DHKEyBAgaqAhtQFXHgTlUjHq";
        long nnEHJJhn = 18499052303816525;
        long OpfXhXVpTlVsasTlmkD = 4268745757210254;
        ushort ewRzbDufpgHLtQVsOsApbBFAqW = 63661;
        short nVSzxOQdUZPzfXeWJoZeOVTGgSFQs = -22942;
        sbyte ffckOmXceoUtLRVEBD = 40;
        int jlsclqFiZMMUktaUUiwsWazbAVoWb = 7930;
        while (jlsclqFiZMMUktaUUiwsWazbAVoWb == 7930)
        {
            jlsclqFiZMMUktaUUiwsWazbAVoWb = 905112;
        }
        float hDVsUeEhABzVJHumobjNqD = -2.09409E-36F;
        long KWmxFz = 63040061626911111;
        double awRbsJumiELfuFkULNwHVdVaOB = 9.452562E+20;
        awRbsJumiELfuFkULNwHVdVaOB = Math.Ceiling(Math.Cosh(5));
        try
        {
            int RmSOHAUFxnWcoJdYu = 3671346;
            if (RmSOHAUFxnWcoJdYu == 13810)
            {
                RmSOHAUFxnWcoJdYu++;
            }
            else
            {
                RmSOHAUFxnWcoJdYu--;
                Console.Write(RmSOHAUFxnWcoJdYu.ToString());
            }
        }
        catch (Exception ex)
        {
            //MessageBox.Show(ex.Message);
        }
        double OEBGwutWlVBsypNTefXkq = -1.006995E-26;
        if (OEBGwutWlVBsypNTefXkq == -3.2773E+09)
        {
            OEBGwutWlVBsypNTefXkq = Math.Pow(5, 2);
            Console.ReadKey();
        }
        double HIjHCppahgCZnWXeySnWEnbTnWtc = -244.849;
        if (HIjHCppahgCZnWXeySnWEnbTnWtc == -2.927146E+16)
        {
            double jqzVIZqbJPCLhkIabusH = -8.453785E+25;
            HIjHCppahgCZnWXeySnWEnbTnWtc = jqzVIZqbJPCLhkIabusH * 2;
            for (;;)
            {
                Console.WriteLine(-2.173431E-11);
            }
        }
        uint WzOzf = 110822180;
        short sEMFTjyPn = -7547;
        byte kljhwMjuATKHwoRcnxKDcmnRmSM = 123;
        uint XHjjLlFpKkVW = 48479435;
        float jFtuB = 7.971471E+14F;
        long YYsUEZLUhVdxkEFyYMzHgBOWh = 15212437468429152;
        short mlwgljbFERKYbPWDgleLzjx = 16065;
        double FPqRgXUQqlDGmxfWkfzKfqinYL = -2.240075E+08;
        if (FPqRgXUQqlDGmxfWkfzKfqinYL == -2.134286E+24)
        {
            FPqRgXUQqlDGmxfWkfzKfqinYL = Math.Ceiling(Math.Acos(0));

        }
        uint DGTuiQwKQnQkVAwnAmBFhDPkKhh = 6335;
        double UDFSuNXys = -7722.377;
        while (UDFSuNXys == 3.599609E+27)
        {
            UDFSuNXys = Math.Ceiling(Math.Tan(1));
            Console.Write(UDFSuNXys.ToString());
        }
        ulong pYmhynmmtbAOywnszM = 61531533333511034;
        uint btQIcaPokDWlnnFoFkmVBtLee = 84;
        double EGDPwlZlRMyHYhVPSw = -9.103818E+21;
        if (EGDPwlZlRMyHYhVPSw == -9.302592E-14)
        {
            double JMEVhTLHXuxScGdOzPoDl = 45418.55;
            EGDPwlZlRMyHYhVPSw = Math.Ceiling(JMEVhTLHXuxScGdOzPoDl);
            Console.WriteLine(EGDPwlZlRMyHYhVPSw.ToString());
        }
        ushort hNNkiJCjMAoD = 33390;
        long CoMSVQjaWzhxZXqh = 24803562144831274;
        short lRVUzQjuNAKaCCYMRNamCmwqRA = 6175;
        double DluDbEsfbZqlGkSyxDtKQipqbqZx = 2.764727E-35;
        double yAXGGPNKaWbD = -4.283128E-25;
        DluDbEsfbZqlGkSyxDtKQipqbqZx = Math.Round(yAXGGPNKaWbD, 1, MidpointRounding.ToEven);
        try
        {
            int pguVdCLFWD = 7816631;
            if (pguVdCLFWD == 35880)
            {
                pguVdCLFWD++;
            }
            else
            {
                pguVdCLFWD--;
                Console.Write(pguVdCLFWD.ToString());
            }
        }
        catch (Exception ex)
        {
            //MessageBox.Show(ex.Message);
        }
        long QNEZO = 22690975002936566;
        string wApIdSpXffTl = "WcndugDQd";
        string XVZmikJtOZQxzLGlAPz = "VPMPtGMSQzDszKLiTdPUyAylfG";
        ulong OUdaGhMiijUD = 3334116859614845;
        string txaExwqAJNQtdVw = "MqYDZJjmwGWgPIIbs";
        short HabLpRKBgNfOIVWMI = 20464;

    }
}