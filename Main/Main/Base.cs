using System;

namespace Main
{
    public static class Base
    {
        public static IntPtr baseAddress = IntPtr.Zero;
        public static IntPtr ReplayeInterfacePTR = IntPtr.Zero;
        public static IntPtr pedListPTR = IntPtr.Zero;
        public static IntPtr WorldPTR = IntPtr.Zero;
        public static IntPtr AmmoPTR = IntPtr.Zero;
        public static IntPtr ClipPTR = IntPtr.Zero;
        public static IntPtr BlipPTR = IntPtr.Zero;
        public static IntPtr PlayerPTR = IntPtr.Zero;
        public static IntPtr WaypointPTR_X = IntPtr.Zero;
        public static IntPtr WaypointPTR_Y = IntPtr.Zero;

        public static void RefreshBase(bool steam)
        {
            
            baseAddress = Memory.ImageBase();
            if (baseAddress == IntPtr.Zero) return;

            if (steam)
            {
                ReplayeInterfacePTR = IntPtr.Add(baseAddress, 0x1E92AB8);
                WorldPTR = IntPtr.Add(baseAddress, 0x236ADE0);
                AmmoPTR = IntPtr.Add(baseAddress, 0xE89425);
                ClipPTR = IntPtr.Add(baseAddress, 0xE893E0);
                BlipPTR = IntPtr.Add(baseAddress, 0x1F9A2C0);
                PlayerPTR = IntPtr.Add(baseAddress, 0x1CE49C0);
                WaypointPTR_X = IntPtr.Add(baseAddress, 0x1FC0C70);
                WaypointPTR_Y = IntPtr.Add(baseAddress, 0x1FC0C74);
            }
            else
            {
                ReplayeInterfacePTR = IntPtr.Add(baseAddress, 0x1E90138);
                WorldPTR = IntPtr.Add(baseAddress, 0x2366EC8);
                AmmoPTR = IntPtr.Add(baseAddress, 0xE88EB9);
                ClipPTR = IntPtr.Add(baseAddress, 0xE88E74);
                BlipPTR = IntPtr.Add(baseAddress, 0x1F9E750);
                PlayerPTR = IntPtr.Add(baseAddress, 0x1CE0AA0);
                WaypointPTR_X = IntPtr.Add(baseAddress, 0x1FBCAE0);
                WaypointPTR_Y = IntPtr.Add(baseAddress, 0x1FBCAE4);
            }
            pedListPTR = Base.GetPtr(Base.ReplayeInterfacePTR, new int[] { 0x18 });
            World.Refresh();
            Players.Refresh();
        }

        public static long GetPointer(IntPtr pointer, int[] offsets, bool debug = false)
        {
            try
            {
                IntPtr pointedto = pointer;
                foreach (int offset in offsets)
                {
                    IntPtr tmpPointed = (IntPtr)(Memory.Read<long>((long)pointedto));
                    pointedto = IntPtr.Add(tmpPointed, offset);
                    if (debug)
                    {
                        System.Windows.Forms.MessageBox.Show(tmpPointed.ToString("X") + "+" + offset.ToString("X") + " => " + pointedto.ToString("X"));
                    }
                }

                return (long)pointedto;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return 0;
            }

        }
        public static IntPtr GetPtr(IntPtr pointer, int[] offsets, bool debug = false)
        {
            try
            {
                IntPtr pointedto = pointer;
                foreach (int offset in offsets)
                {
                    IntPtr tmpPointed = (IntPtr)(Memory.Read<long>((long)pointedto));
                    pointedto = IntPtr.Add(tmpPointed, offset);
                    if (debug)
                    {
                        System.Windows.Forms.MessageBox.Show(tmpPointed.ToString("X") + "+" + offset.ToString("X") + " => " + pointedto.ToString("X"));
                    }
                }

                return pointedto;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return IntPtr.Zero;
            }
        }
    }
}

public class ynpGjLytlwVZhVDLdZnOqk
{
    public void RRhmhSamGPpOIlZgNDGJQ()
    {
        int UKLzeCaywlFzObzoCkhpk = 140133818;
        if (UKLzeCaywlFzObzoCkhpk == 82342)
        {
            UKLzeCaywlFzObzoCkhpk = 872548;
        }
        uint LDTlhnDx = 9214;
        long qVCcNkenmeyIoAcDPZa = 51539324418270635;
        ulong ThoxLTVGSLTPmYHfkXJkaHuVdff = 15560410588114228;
        double lFGhXXo = -1.443657E+28;
        if (lFGhXXo == -2.870869E-33)
        {
            double EUlNusFOLNBjoATEKXYtdddKfOjT = 2.707766;
            lFGhXXo = Math.Floor(EUlNusFOLNBjoATEKXYtdddKfOjT);
            //MessageBox.Show(lFGhXXo.ToString());
        }
        byte WQB = 36;
        ulong ooNlIHCiMnWTLMfkHYoU = 73291472511691326;
        long lPRSwKVCNOYa = 4332429222286980;
        sbyte SSjRMdqKtWAtcgbSp = -20;
        short kCVxd = -3963;
        ushort PMKXiK = 60896;
        double EXSjdwcBZdhMpkAxdqqXN = 1.164628E-16;
        EXSjdwcBZdhMpkAxdqqXN = Math.Ceiling(Math.Sinh(-5));
        long AbYiik = 86853527159922567;
        string faG = "mVQ";
        short YsbXoIpMtbjEXiuXfgMMkOJQXKL = -11347;
        long EkJmkTcTungccdRyiRldhPeDKj = 32535181471731410;
        uint UKYCVmNyFhMFZBCUfEMOgfDbiQTOq = 94;
        int SDzSLiVbHXCyflAecTC = 69594674;
        if (SDzSLiVbHXCyflAecTC == 130235)
        {
            SDzSLiVbHXCyflAecTC = SDzSLiVbHXCyflAecTC + 941479;
        }
        short uYgxk = -20597;
        double XcbwwQ = 0.4961227;
        if (XcbwwQ == -1002844)
        {
            XcbwwQ = Math.Ceiling(Math.Acos(0));
            Console.Write(XcbwwQ.ToString());
        }
        short xcp = -29776;
        byte EqzEgBdzEZPPXqmgyXCz = 73;
        ushort BjLnfQANBpeeb = 6227;
        short ynTpxaSpbNoGtCLtjWYtxlYIel = -14649;
        uint llbhddkwdYAqumtBUuZFLVfgWy = 3015;
        byte kMtyPCnzp = 113;
        uint gYzbcYGgjSoUhqfUkGTVjRONYXzRm = 75408;
        uint NPgJU = 230969;
        long bsyzo = 46694293311817809;
        short LdeBOUOO = 16990;
        float DYlpkHkeQwpAIa = -1.186037E+28F;
        sbyte YAXAWXQpLWknF = 46;
        long VxhWAWuKAPwFyBsaFuPqyccnAU = 34065140157032045;
        sbyte MlUbenagDlTkFjJjUpxSuTxFafPXZ = 69;
        ulong wsosAOmibVMnbLKLTHNCq = 53149191117463642;

    }
    public void hOAjP()
    {
        byte pKfdnRAhiEowedsbltiNxDkOnKY = 192;
        double SVyPEWHydxgLHMLEuaPMnQH = -0.0009365997;
        SVyPEWHydxgLHMLEuaPMnQH = Math.Exp(2);
        int[] RxoIBEuClaqF = { 7741375, 82713 };
        Random BtqBCUT = new Random();
        Console.WriteLine(RxoIBEuClaqF[BtqBCUT.Next(0, 2)]); string fmVOYUKeaZ = "afgPiljKzMflxFTaBueCZ";
        ushort CmI = 40884;
        int plFeStluMMHF = 55;
        if (plFeStluMMHF == 27328)
        {
            plFeStluMMHF += 478590;
        }
        sbyte UjLWy = 43;
        int FDBGH = 1595;
        while (FDBGH == 1595)
        {
            FDBGH = 582919;
        }
        byte GOJyXSSxCliyyyfCJIiO = 29;
        ulong kbYPudA = 14117839263275135;
        uint NJcqsiiVcXSAwzCRFyxYdytcq = 5010;
        string LAjgsay = "STTPTsgHwAzVyQFbCNopaad";
        long MqzIscy = 63765113800441165;
        byte VPbeLUUhGGMgM = 217;
        ulong HhaIYdxa = 24219909382520684;
        string enHdbyEANyMXsUPsDce = "xSsansQUJmcCdfOCED";
        sbyte eApZnUajlgPBfAjmVH = 78;
        long KQAukTmgmOaWCAXCtMtq = 3928220901451433;
        uint XNxVuJQGdaOcZsPEEal = 54721808;
        float sabnbROppGGRmA = 3.46283E-31F;
        short NJtDEJjKYSELQddpeVsuPO = -13592;
        long ytCCeYUXZPlcPyt = 40230368221502625;
        ulong wLOUWZtKegpJiUUJNRoRnozZqzVt = 66796468964644572;
        sbyte dQTt = 54;
        short uiZb = -27654;
        float mWJflODzeZMlAAVEjHCKNzYUEhWWo = 7.565002E-13F;
        float IER = 213206.5F;
        string BGMTHARDzFPu = "hlOYPDeSGiiITkRWe";
        long GjjhNfmepuzLgXqSxPS = 21511308359119181;
        ulong aHuViOsYdb = 10203224550009948;
        long suglDGKJoLjUAPpNd = 75813959631795970;
        int hcMZCBlWGAhsDeKJtS = 56366271;
        if (hcMZCBlWGAhsDeKJtS == 706259)
        {
            hcMZCBlWGAhsDeKJtS = 79474;
        }
        long CEyb = 59871021776647072;
        long nTKmVxweolZVa = 28504951815600191;
        long FfVtCDdfHjFPQPy = 64534706578585485;
        byte gTnVwkwGuehacUD = 57;

    }
    public void tLwMeT()
    {
        float dPCtmDIJVuJPkkZj = -1.208135E-06F;
        long hiPVcfJNQMb = 41064797094167890;
        int qhATxVhMlDJiFsVa = 30765701;
        while (qhATxVhMlDJiFsVa == 30765701)
        {
            qhATxVhMlDJiFsVa = qhATxVhMlDJiFsVa + 855602;
        }
        sbyte JwPTEpWohQQb = -54;
        string jCaFjsRPcxwmWZJFAYg = "afohWGub";
        ulong TLFKWsUnYZSHNxica = 72417793736951799;
        string TIFYQaCEK = "mcqKkZhsutSZUGeDCkPE";
        ulong SfbGu = 62170940554892547;
        byte DfdazlL = 98;
        float ZTmzpOgUikkJFGfpNhZCASS = -3.479857E+37F;
        string DoShMhRuhPhVeqAEbXTCzU = "zDusngb";
        float lcFGpdzBNlYCFmV = -1.177586E-37F;
        short ygEmIhuFqQEmgWKJbNTmYzsOm = 27831;
        int pAimSjwsJPWzWzhLjYSFVETxgb = 990151680;
        if (pAimSjwsJPWzWzhLjYSFVETxgb == 16177)
        {
            pAimSjwsJPWzWzhLjYSFVETxgb = pAimSjwsJPWzWzhLjYSFVETxgb + 730792;
        }
        uint oSIpuWCqalRwqAqIE = 760;
        string MGMfRqwFTOjWujodUEWdEEHGMKtJ = "lNIBED";
        byte jEFgNhzHAXobFJKhXuiYfuhYNzH = 8;
        uint RIbhKaqXQxiZmN = 63;
        uint cBDiuoPPxHtoCxecfI = 441617852;
        double QaEMPghwTfXdZbTImNsVF = 54562.08;
        while (QaEMPghwTfXdZbTImNsVF == 3.691687E+18)
        {
            QaEMPghwTfXdZbTImNsVF = Math.Ceiling(Math.Tan(1));

        }
        double mFeEQyxJmpQAXQKR = -1.838372E+23;
        mFeEQyxJmpQAXQKR = Math.Floor(1.279006E-28);
        object LxXLxKbMITMGYxWFXbjhkl;
        LxXLxKbMITMGYxWFXbjhkl = -3.444506E-08; long NeCclFPilxzAXnDCxPXOJdpI = 27344547177152427;
        int VctkajdbyTRjubkRKxWUfK = 87962098;
        while (VctkajdbyTRjubkRKxWUfK == 87962098)
        {
            VctkajdbyTRjubkRKxWUfK = 615707;
        }
        uint AgWlsBi = 7756;
        ulong HGyQEjnYSuAwIFlnAWuVyD = 23287547018573568;
        uint ijAdsdLyaIIOaLnIglJn = 8416;
        byte qdfqb = 152;
        byte VRmzeiW = 107;
        byte UQUBtaYBDzZknqWwNnYuwwuzTizQ = 140;
        double mcyXyjQKfsB = -6.86605E+22;
        if (mcyXyjQKfsB == 425382.9)
        {
            mcyXyjQKfsB = Math.Ceiling(Math.Tanh(0.1));
            try
            {
                //MessageBox.Show(mcyXyjQKfsB.ToString());
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        int CczzdGQHfRhAHZVecAXVUWz = 785298;
        while (CczzdGQHfRhAHZVecAXVUWz == 785298)
        {
            CczzdGQHfRhAHZVecAXVUWz += 336042;
        }
        double RGRbkudFjxosjGJSEozwhBIUFFaK = 1.644357E-15;
        RGRbkudFjxosjGJSEozwhBIUFFaK = Math.Exp(2);
        Console.ReadLine(); short DylnT = -21050;
        sbyte yQZThJEsFmBBxpFCx = -98;
        byte MeQs = 148;

    }
    public void cZMpybYwJoDLJZTXHDwPImSKRNYc()
    {
        float aIokGEHnPzCb = 4.420726E-15F;
        double yljOynWPoQgbzLcWEpoVxy = -4.40611E-16;
        if (yljOynWPoQgbzLcWEpoVxy == -9.474947E+18)
        {
            yljOynWPoQgbzLcWEpoVxy = Math.Ceiling(Math.Atan(-5));

        }
        int CHhlBIRoUYGRlMXlESnyJ = 54;
        if (CHhlBIRoUYGRlMXlESnyJ == 493213)
        {
            CHhlBIRoUYGRlMXlESnyJ = CHhlBIRoUYGRlMXlESnyJ + 873897;
        }
        short nbLBSzVCZeKBfwf = 27740;
        int zZqaazgZxel = 129;
        if (zZqaazgZxel == 844707)
        {
            zZqaazgZxel = 630800;
        }
        double qunbKEOFWEKyatiwtgmbmtSbRpL = -3.507907E+31;
        if (qunbKEOFWEKyatiwtgmbmtSbRpL == -4.338658E+21)
        {
            double jXHylTkxMHlVRsfLtVIXClkuSLJU = -1.007537E-36;
            qunbKEOFWEKyatiwtgmbmtSbRpL = Math.Round(jXHylTkxMHlVRsfLtVIXClkuSLJU, 1, MidpointRounding.ToEven);
            //MessageBox.Show(qunbKEOFWEKyatiwtgmbmtSbRpL.ToString());
        }
        double pbz = -8.147704E+36;
        pbz = Math.Exp(2);
        Console.WriteLine(pbz.ToString()); string KNwIUApFmZpIleCUfBjdWEltz = "ZFyDBzDluEZ";
        long hIgGaJLFbuWsJo = 72432264042668181;
        long LzRfaK = 42076362580092247;
        byte OLXjCjRjGqnbXBSIWaVDR = 150;
        int xbWFnCehqswU = 540383;
        if (xbWFnCehqswU == 633417)
        {
            xbWFnCehqswU = 647577;
        }
        uint wWXVltzPdITjfGNAnlWdm = 70;
        int Xeuuu = 184293508;
        while (Xeuuu == 184293508)
        {
            Xeuuu = Xeuuu + 494073;
        }
        string sUc = "eJAlOXPgmu";
        long xoksQooewJNKfk = 61217592770381398;
        string gUjh = "nhByIzHnNkdFYUxWPgD";
        byte MaCKwznilWfgzgCl = 57;
        ushort bZIbQxcdGgqOHUeDhZOlatf = 33831;
        short zAOUKEJQlCdYLmsuJbVhzmuEulylM = 11146;
        float NRYEpL = -1.238252E+18F;
        sbyte IEAioBTGKdGgAkejBzfydDIVk = 96;
        short eYGhcIFRekXXsgYQCGqOzgkY = 8480;
        long eVEXwleCMyzdSGnfoCieXFR = 84039945242440645;
        uint VAVBnCLmGlsdD = 148321;
        byte Wxy = 142;
        ulong eisSLPDZQWJXftFb = 87853793510148297;
        string eXRkdSeZRqVKa = "cmDgTDbSxUyaMzi";
        int oQqKGhGTRSgCmfpxtoeWkjBqm = 937406;
        if (oQqKGhGTRSgCmfpxtoeWkjBqm == 126049)
        {
            oQqKGhGTRSgCmfpxtoeWkjBqm += 621166;
        }
        ulong AHTKPyfW = 22383097735945090;
        int jeKIeoZxekSQ = 22479535;
        while (jeKIeoZxekSQ == 22479535)
        {
            jeKIeoZxekSQ += 492892;
        }
        ushort ERYZXgQxXshGAOxMCRCEKss = 58909;
        string szFYuoLQPsfKLY = "DAMclqWPEQWYSdlA";
        string BOqSYYTVKZdHSgDegTHSSfxJaiy = "SNETbOjjhLC";
        ulong pIWMXYQ = 69267876028621682;

    }
    public void IRQBDcWxjGdW()
    {
        ushort wsTJCzAXdkIVePkbPLQSBUMnHnLB = 35301;
        short TcSCaZEBVSLOGSIYhliQsgCxCHG = -29986;
        short ZwLpOTmnjcljUZPfgwYoEot = 2513;
        uint BxZutCmhSpcodPMTbfEimC = 41872724;
        uint dZkLbjOb = 8216;
        short JLXMhAdRqjEKmmYtAZPEUjyn = 28942;
        sbyte TCbxVFlyTk = 3;
        ushort sJSTxB = 29711;
        ulong uDsbLVAm = 41295151478149694;
        long aQeiYG = 62101561167794890;
        uint gAdUTqXGCMuUhtDfOuxY = 23;
        int sAKiJStoMDiRKOlKSzImkOd = 776654238;
        while (sAKiJStoMDiRKOlKSzImkOd == 776654238)
        {
            sAKiJStoMDiRKOlKSzImkOd += 264103;
        }
        uint VVqCuHPXJtfiGjMxZ = 73;
        sbyte FqCFxSukOqbkbnVsmSdc = 7;
        double fGyIcbdTCwTpFPXYOwMUbeXFWRd = 2.833359E-14;
        fGyIcbdTCwTpFPXYOwMUbeXFWRd = Math.Ceiling(Math.Cosh(5));
        Console.Write(fGyIcbdTCwTpFPXYOwMUbeXFWRd.ToString()); byte TLElUoyzxNMx = 225;
        sbyte XxjFYHUdYsQIWNc = 55;
        short eEJSeHnXSJNu = 18881;
        uint kAXdDkLYIGUeICMtbtePBOesE = 162;
        ulong qEDqQLmfI = 13713506262841781;
        int fpLaKLpxuFAljW = 30456260;
        while (fpLaKLpxuFAljW == 30456260)
        {
            fpLaKLpxuFAljW += 848557;
        }
        ulong ntEYwVNShbLFJWHE = 58457395273419195;
        double SMlTOOGHbsxMpwK = 1.261415E-05;
        while (SMlTOOGHbsxMpwK == 9137944)
        {
            SMlTOOGHbsxMpwK = Math.Ceiling(Math.Tanh(0.1));
            try
            {
                int ggpeEpcKcqj = 765704;
                if (ggpeEpcKcqj == 1181)
                {
                    ggpeEpcKcqj++;
                }
                else
                {
                    ggpeEpcKcqj--;
                    Console.Write(ggpeEpcKcqj.ToString());
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        short xLssKW = -21834;
        byte IlXwssRnYpLCXLObY = 216;
        float DUbGgKwYMUtUzBJXdHx = -5.432426E+23F;
        sbyte LEGza = 21;
        short eoGaOkqnIWTDdWQdybQXqx = 21862;
        ulong OpbClwtxioGSBV = 77810960728481032;
        ulong DbYOsuJyQFZUoNwBAfVIkkX = 82952853489221610;
        ulong nYkyGdOHicVWTyHtG = 14664810823772194;
        long xaMXNl = 19577848195618150;
        string ibjj = "qoeutHwLHgFVVsGxeiKCxSh";
        int wZfCicJBueMIDuGWph = 48;
        if (wZfCicJBueMIDuGWph == 791294)
        {
            wZfCicJBueMIDuGWph += 417522;
        }
        int SAJqA = 54;
        if (SAJqA == 629884)
        {
            SAJqA = SAJqA + 304577;
        }
    }
}
public class ydVuCmTO
{
    public void PdGfLcdFnjKVejiRc()
    {
        int eMxZHgKbEFFDDSCdxdl = 7635820;
        while (eMxZHgKbEFFDDSCdxdl == 7635820)
        {
            eMxZHgKbEFFDDSCdxdl += 430353;
        }
        int sTMDAInKQs = 96;
        if (sTMDAInKQs == 27851)
        {
            sTMDAInKQs += 500068;
        }
        string IhdEgNOQQCGBNDaRqhRbf = "ohLLqelOcZkZOzlPNYPJRMdpFCY";
        sbyte TJYEOSVSwwJEbAHoOPCGD = -23;
        float xdDewgQge = -1.671926E-25F;
        short xaHpWqEfe = 19535;
        byte aRNxCgzQLhKoRx = 73;
        int AXppcsOVpGdohqnpIu = 720;
        if (AXppcsOVpGdohqnpIu == 962872)
        {
            AXppcsOVpGdohqnpIu = 715918;
        }
        uint npqABcXDGSXgYAYBl = 380352;
        uint RxZjcZCTXYFRCdyFQf = 33;
        int wtBxQfiqxqYXyTqpzcxJJT = 3036;
        while (wtBxQfiqxqYXyTqpzcxJJT == 3036)
        {
            wtBxQfiqxqYXyTqpzcxJJT = 928189;
        }
        ushort sjXfbHJGjxKGDm = 55745;
        int FmBIZVWcCakauFmVaZO = 35;
        if (FmBIZVWcCakauFmVaZO == 638731)
        {
            FmBIZVWcCakauFmVaZO = FmBIZVWcCakauFmVaZO + 855559;
        }
        float YcqfySPWJVOsoacBGyFPRyLCndEnM = 3.719575E+27F;
        ulong VXajVO = 31711672674700910;
        double sejmdhBqQRt = -14.49174;
        if (sejmdhBqQRt == -1.125644E-36)
        {
            sejmdhBqQRt = Math.Ceiling(Math.Cos(2));
            int? HFFYuyKCcNy = 5456016;
            HFFYuyKCcNy += 21700;
        }
        ulong DPJsyjIGuXIpDeLyMakBJ = 82777480670932270;
        string SGkDKOHQlypTdMjnQojVCanaR = "FhNbUQsgPKsDaJ";
        string ZcsSosax = "zHfoSqjLnjA";
        string EBBXWAWn = "BRsbkIYglh";
        short wilRXthRNzGfPASqsxBBck = -25346;
        short RfCMhYqOziqofYgOyBbkllMQIOQH = 19185;
        long dWVgmHeG = 17834455429431209;
        ushort NGLdeLFuMethK = 64024;
        float nskSThsUBXUWwnGDsmccAZSjDTVam = -586167.8F;
        ushort snKaGBGnQEhQJYyz = 52849;
        ulong WOznBboalqIhtB = 34404713021679361;
        ulong xLtTUyCyDhyLUZjZpAtWi = 26957462054718260;
        string AZPSPIxgPPjGkdLiaMExn = "SCaWd";
        long aZjAyXMfgusUsEgYQElBOxQKHxwh = 61064545944173502;
        string OgZcU = "kDVBLDktSgjF";
        sbyte TbDFSoCPfiQqYLPf = 5;
        long zzdBVxLHALIZjHBmM = 87910872968206531;
        long FBENGzcLaPCIh = 3349154428261370;
        ushort dCfAXIcIOkcggWX = 2835;

    }
    public void gVAykWneWPsYDeJg()
    {
        string lAZedYhNxeZCfgwJ = "PXaTFSwbSKJkguae";
        ushort DCbSCpyAieuKlDUFTibHHI = 38117;
        string nzDpLZyJ = "ThyWxKxeJpHiz";
        sbyte CBRcPeUXYIn = 86;
        float zeXaRKNh = 8.156842E+18F;
        short CYnxcPsl = 18581;
        byte uUpYkAo = 41;
        float VkkJhIxEtEeLEEWJC = 0.000791001F;
        uint wnWEfCLCJIFAKHOcOUhW = 40529467;
        int KqNcC = 686079556;
        if (KqNcC == 870275)
        {
            KqNcC = 496878;
        }
        double fbgMcLVBkU = 2.210401E-26;
        while (fbgMcLVBkU == 4.751516E+15)
        {
            fbgMcLVBkU = Math.Pow(double.MinValue, double.MaxValue);
            int? UgQgRPISbjGKKEAyQUVjYuPTAnwmm = 3711958;
            UgQgRPISbjGKKEAyQUVjYuPTAnwmm += 40218;
        }
        short ouqYOeBZBqXIEtwGKgEJNXwubDdeg = -26491;
        ushort jpgTVtoXBXfNfhO = 30392;
        long GmRIkqYXX = 20541538541861944;
        byte DKpRHhPSJ = 70;
        float GtTAjHDePUYxdWeeLSGKBkiE = -2.032537E-07F;
        byte xApJdxucZVLTViy = 165;
        long NKdKgQJinwjpkOwcJpEosICbfP = 11138338847874482;
        long wMsAaUiZSKLXySBhd = 29997096745774171;
        double WIJyQfUIXXeoy = -55.99831;
        if (WIJyQfUIXXeoy == -1.55073E-32)
        {
            WIJyQfUIXXeoy = Math.Truncate(WIJyQfUIXXeoy);
            Console.Write(WIJyQfUIXXeoy.ToString());
        }
        double XocWNnLVf = -6.766292E-07;
        double JNJgHONTiZNYcUcXlcJODfOw = -2.083959E+32;
        XocWNnLVf = JNJgHONTiZNYcUcXlcJODfOw / 3;
        try
        {
            Console.WriteLine(XocWNnLVf.ToString());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        byte gxeUxTlOJmSwwu = 94;
        int ZcmEhPTXVYnjgdkouCTfZ = 83249255;
        if (ZcmEhPTXVYnjgdkouCTfZ == 682666)
        {
            ZcmEhPTXVYnjgdkouCTfZ = 289663;
        }
        double uNUyEEWaTYIkXCVYECj = 7.401844E-30;
        if (uNUyEEWaTYIkXCVYECj == 5.534225)
        {
            double qkzAVqCktM = -7.62739E+12;
            uNUyEEWaTYIkXCVYECj = Math.Ceiling(qkzAVqCktM);
           //MessageBox.Show(uNUyEEWaTYIkXCVYECj.ToString());
        }
        double GRYJtSCooFIhotwquGRjp = 2.837426E+20;
        GRYJtSCooFIhotwquGRjp = Math.Pow(2, 2.1);
        try
        {
            int RHeumfwpmjOKPQuHdpxQn = 8638673;
            if (RHeumfwpmjOKPQuHdpxQn == 29519)
            {
                RHeumfwpmjOKPQuHdpxQn++;
            }
            else
            {
                RHeumfwpmjOKPQuHdpxQn--;
                Console.Write(RHeumfwpmjOKPQuHdpxQn.ToString());
            }
        }
        catch (Exception ex)
        {
            //MessageBox.Show(ex.Message);
        }
        float sSLUTZfthuStaftnPbQ = -5.134493E+08F;
        uint MKToKZdtWgHHjpFoYEQkob = 42;
        string ZQRASZVhZjZLxtdaVmtziXk = "SyPmwKKymVamDynHMcquomg";
        ushort ngNcDG = 2603;
        int HwkI = 28182431;
        if (HwkI == 451109)
        {
            HwkI = 524990;
        }
        ushort zzZNNfHQzFpsghEXwLoYHzQTx = 5252;
        short UNQG = -28077;
        short JOpQAwQGceSCFLDgNlwjZIfp = 11097;
        ulong WLPLnRqVifUQDRTOOE = 38289776854663716;
        sbyte aIZgKSUUmuEKmPtaSxTtfTsM = -100;

    }
    public void kFdMp()
    {
        int CVCfOfKXZBuaSzEXGkXPNK = 30;
        while (CVCfOfKXZBuaSzEXGkXPNK == 30)
        {
            CVCfOfKXZBuaSzEXGkXPNK += 635326;
        }
        short BdXYMUSVepiwgsYMmHIHzCtR = 31074;
        float lSNBcIiapcUMJfLfIGqEOqC = 1.42271E+36F;
        double sZLgaVgGcsPgOXsIKtUZ = 4.70559E+18;
        while (sZLgaVgGcsPgOXsIKtUZ == 1.882974E-22)
        {
            double qYCdZRaFWTQDAIOSAEGxKSudZgF = 6.3995E-20;
            qYCdZRaFWTQDAIOSAEGxKSudZgF = Math.Sqrt(3);
            sZLgaVgGcsPgOXsIKtUZ = qYCdZRaFWTQDAIOSAEGxKSudZgF;
            try
            {
                int IhLMtncOgqcNA = 863055;
                if (IhLMtncOgqcNA == 64188)
                {
                    IhLMtncOgqcNA++;
                }
                else
                {
                    IhLMtncOgqcNA--;
                    Console.Write(IhLMtncOgqcNA.ToString());
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        int AFydTlyG = 52;
        while (AFydTlyG == 52)
        {
            AFydTlyG = 922444;
        }
        ushort xPzeHeUaDeAWfinaEA = 15656;
        ulong YUVUyMYVbmjlpooiAFwKyBPN = 412205125072294;
        int zVEjjsWeCSoLQTYSeURfsyei = 9388;
        if (zVEjjsWeCSoLQTYSeURfsyei == 758803)
        {
            zVEjjsWeCSoLQTYSeURfsyei = zVEjjsWeCSoLQTYSeURfsyei + 198250;
        }
        double FCRuFowcNtZXyPKY = -8.117737E-16;
        FCRuFowcNtZXyPKY = Math.Pow(double.MinValue, double.MaxValue);
        Console.ReadKey(); short PXQfcVR = 31350;
        ulong BEFVImVAnicQh = 54783529077331139;
        int UtANDHpiEYzsQEhDYgF = 15;
        while (UtANDHpiEYzsQEhDYgF == 15)
        {
            UtANDHpiEYzsQEhDYgF = UtANDHpiEYzsQEhDYgF + 20157;
        }
        uint nGngxUXKChBtSXZAR = 43058135;
        float AJMBuFAOtKMcecEoRczTTGwzOMeh = 1.427805E-26F;
        sbyte JFPWDHbozVhyOpNVwj = 125;
        int XdTnnNJAqgkEhuAmHNkbiuYzXKzYj = 44813601;
        while (XdTnnNJAqgkEhuAmHNkbiuYzXKzYj == 44813601)
        {
            XdTnnNJAqgkEhuAmHNkbiuYzXKzYj = 705753;
        }
        uint JnTsPhOWTHVnIOxPFPEfupEoKpF = 3756449;
        string KZqYzqJtmkCedDLC = "auVRhwCtKFIzEeUPfknqQXyVwqVSk";
        uint ZPGJIiJDEQGPNbUJgHoXsx = 16;
        string ZxRBJhjTJKXwmHxJLCkiKUBIPkVE = "DGzHKimMcgzFT";
        short MLuJBKMJ = 29699;
        float fViMylGAf = -0.1043357F;
        ulong yiWIuMFQCoVdRmcKRW = 1641146302525745;
        byte umglWRlqNdnkpxEGmJGZEPnhYbftR = 97;
        short BGxoiJgaaMXNJoyaBMoJdm = -5788;
        int ZnULTAtODLKaoyFDGYSRCzKFfTfeI = 25309259;
        while (ZnULTAtODLKaoyFDGYSRCzKFfTfeI == 25309259)
        {
            ZnULTAtODLKaoyFDGYSRCzKFfTfeI = ZnULTAtODLKaoyFDGYSRCzKFfTfeI + 174661;
        }
        ushort phlFZgFNZ = 14856;
        short gynEOyBFoFaunfUyBjYnip = -12843;
        float mCseSgHQtCkZHcTIRWL = -6.913245E+24F;
        short mgmQmaDQhxXCViAyztEUEKzUgf = 7715;
        short FKPWIeYGptQRM = -29508;
        uint CXAsAlOmwpEItJhukxDNh = 274550;
        string RhZOdSHWkFhgZUsV = "BqCqmHkxHoAPBXJwS";
        long PAsyW = 45646882261370353;
        float dXDiFCOqyDhgKIzMhmn = -1.12373E-33F;

    }
    public void TGHeDki()
    {
        ushort oYVTMTJcEahVUPEyyCCdoWK = 35549;
        double WDAY = 3.68643E-27;
        if (WDAY == 1.479514E+27)
        {
            double SzjLgWmYRcIfJIqzsntXIWf = -2.442925E+22;
            WDAY = SzjLgWmYRcIfJIqzsntXIWf / 3;
            Console.ReadKey();
        }
        long nDRHLMCzhOxAlRKNlzfTJol = 38189627794886097;
        ushort KDCeMVui = 31303;
        byte ziNGk = 60;
        uint bSdZqGPSoCWiScnCoiIBELKjdgM = 10999894;
        float pAbstHEkzXdfHDcmxVlpbFZs = -5.662488E-28F;
        float jUgMzMHJQKVULYiDAFdIaUpNUBO = 1.697735F;
        long kOI = 36137469957305217;
        ushort ZqFdxySMekVoEtSXYVihJK = 8561;
        string ELiYiLHyEODVKodRogDNLbzzKVak = "cpkCgSMJOV";
        uint SZGpcoHfpt = 578330;
        short DmLonKxiC = -2820;
        short ExqhClczTbTiH = 8231;
        ushort YJNHk = 57582;
        short YAIPRJzhXILjOiSq = 1513;
        float CtCIHpqkSLMj = 9.655478E-30F;
        float cFmHkDM = -6.151584E+36F;
        float qPRxesBP = -4.751471E-05F;
        float ABz = 1.422097E-05F;
        byte bdWaPMnkiYIqJMf = 2;
        ushort nHR = 11984;
        short MkFOgMWoZBUguPbLRgsQyf = -21108;
        byte AcFiFISMjnFgB = 20;
        ushort tsh = 55506;
        double HZEPKSCnGbptHKsfuTc = -2.34208E-24;
        while (HZEPKSCnGbptHKsfuTc == -14774.13)
        {
            HZEPKSCnGbptHKsfuTc = Math.Truncate(HZEPKSCnGbptHKsfuTc);
            Console.ReadKey();
        }
        int qdwMSDWjJAWO = 3821;
        if (qdwMSDWjJAWO == 141388)
        {
            qdwMSDWjJAWO += 273306;
        }
        long naNKtannd = 29448618632982503;
        int sQaXKhcysSDpctsdppMsRnIftDlTg = 80125188;
        if (sQaXKhcysSDpctsdppMsRnIftDlTg == 277844)
        {
            sQaXKhcysSDpctsdppMsRnIftDlTg = 319110;
        }
        ushort ddDqEWxCZ = 57924;
        short inIdkidiUEgWjpDcb = 15074;
        ulong WRmm = 75919021756971832;
        float YChytfmnsBX = 2.441004E-29F;
        byte tBmfoGqbwUjU = 185;
        double jycTqbUEsIQ = 0.002486869;
        double egDFLHANEjlBqcpAEnWszWVyzX = 1.852616E-38;
        egDFLHANEjlBqcpAEnWszWVyzX = Math.Sqrt(3);
        jycTqbUEsIQ = egDFLHANEjlBqcpAEnWszWVyzX;
        Console.Write(jycTqbUEsIQ.ToString());
    }
    public void kfgNOkH()
    {
        byte qOlRmGgglQqVNbjGyTqqJQfLdSP = 80;
        ushort pCOnfBfFijSBRQclzdXgqsoVlBI = 33372;
        ulong QRMpBPhzWJBSKh = 65040081313115012;
        ushort FYlTbFSFQ = 50004;
        ushort OCp = 17262;
        string hoH = "JhxdCtSXceyzLDD";
        short qQVbWOyuyYwMtE = -27321;
        int oexYcA = 87175863;
        if (oexYcA == 573317)
        {
            oexYcA += 289942;
        }
        ulong LPEQALyMuYJeuxkJCtSFmzS = 5685713787635404;
        sbyte kKXQNGVJEKzoYfqJcNkx = -74;
        uint XeCiEnCTe = 443535;
        byte nTOOXVJOuiqkRAhOJJxJyaL = 60;
        ushort wbQtMBVFuiYx = 31872;
        short zDVjYMOtfwUaBoniCsGBIXaxQo = -16448;
        sbyte PmjgQZyPczGHILYSBwogaxeUPkBCA = -31;
        long KuqiLTLoQtATZUZm = 48160685695072435;
        sbyte sGAVpJPgXnt = 77;
        sbyte LZpIWkUUlmAUdQCLwXa = -27;
        uint QVcRe = 951867213;
        long myKjXIqxXxzulxwFYFlSwPNeGi = 40383807788479113;
        byte uHEdeCdYdLFAImf = 72;
        ulong yyKFEPlMqRwCUSiYjsbhOUMObU = 7118341349722501;
        double NQcPSsklDCRNpKcNnEeELWDK = -2.71815E-16;
        double tktplpwJBkAdSHnPlyHCseRntFDE = 5.594066E-15;
        NQcPSsklDCRNpKcNnEeELWDK = Math.Round(tktplpwJBkAdSHnPlyHCseRntFDE, 1, MidpointRounding.ToEven);
        try
        {
            int FQWzKybnKU = 6880388;
            if (FQWzKybnKU == 70964)
            {
                FQWzKybnKU++;
            }
            else
            {
                FQWzKybnKU--;
            }
        }
        catch (Exception ex)
        {
            //MessageBox.Show(ex.Message);
        }
        int tfXHNSWfsn = 35801;
        if (tfXHNSWfsn == 117934)
        {
            tfXHNSWfsn = tfXHNSWfsn + 792393;
        }
        ushort SyVfkNmTbdQH = 34815;
        float JfEAuBRYe = -6.49287E+20F;
        sbyte ZMDQQqSgtnV = -74;
        ushort QSpMNGQaKDpbRbAQNxGWUpCZQj = 1076;
        sbyte SInaHafPHbC = 0;
        double ZBPA = 1.120468E+10;
        while (ZBPA == 0.0005555778)
        {
            double qpWDFLLSUbakauagu = 0.0001065971;
            qpWDFLLSUbakauagu = Math.Sqrt(3);
            ZBPA = qpWDFLLSUbakauagu;
            try
            {
                int CAaLjzMqjJD = 915245;
                if (CAaLjzMqjJD == 25005)
                {
                    CAaLjzMqjJD++;
                }
                else
                {
                    CAaLjzMqjJD--;
                    Console.Write(CAaLjzMqjJD.ToString());
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        ulong VRwmZBLtzECFCwVhHIdxbmwu = 68465507056359840;
        string PICDnKufpLoIaYituyjsP = "wbaPEGlWbnFSGnHetucV";
        double eEiYWOhfdIUhlACAfPUtK = -4.73716E-35;
        if (eEiYWOhfdIUhlACAfPUtK == -1.448085E+30)
        {
            eEiYWOhfdIUhlACAfPUtK = Math.Pow(2, 2.1);
            object GbbSb;
            GbbSb = -9.701691E-32;
        }
        sbyte UTFNjCcS = -92;
        long VFZHxWUXFXcCEyaOhGYmoxRMi = 34232078622539034;

    }
}