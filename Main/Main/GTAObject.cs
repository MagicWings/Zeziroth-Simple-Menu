using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class GTAObject
    {
        public enum BlipSprite
        {
            Standard = 1,
            BigBlip = 2,
            PoliceOfficer = 3,
            PoliceArea = 4,
            Square = 5,
            Player = 6,
            North = 7,
            Waypoint = 8,
            BigCircle = 9,
            BigCircleOutline = 10,
            ArrowUpOutlined = 11,
            ArrowDownOutlined = 12,
            ArrowUp = 13,
            ArrowDown = 14,
            PoliceHelicopterAnimated = 15,
            Jet = 16,
            Number1 = 17,
            Number2 = 18,
            Number3 = 19,
            Number4 = 20,
            Number5 = 21,
            Number6 = 22,
            Number7 = 23,
            Number8 = 24,
            Number9 = 25,
            Number10 = 26,
            GTAOCrew = 27,
            GTAOFriendly = 28,
            Lift = 36,
            RaceFinish = 38,
            Safehouse = 40,
            PoliceOfficer2 = 41,
            PoliceCarDot = 42,
            PoliceHelicopter = 43,
            ChatBubble = 47,
            Garage2 = 50,
            Drugs = 51,
            Store = 52,
            PoliceCar = 56,
            PolicePlayer = 58,
            PoliceStation = 60,
            Hospital = 61,
            Helicopter = 64,
            StrangersAndFreaks = 65,
            ArmoredTruck = 66,
            TowTruck = 68,
            Barber = 71,
            LosSantosCustoms = 72,
            Clothes = 73,
            TattooParlor = 75,
            Simeon = 76,
            Lester = 77,
            Michael = 78,
            Trevor = 79,
            Rampage = 84,
            VinewoodTours = 85,
            Lamar = 86,
            Franklin = 88,
            Chinese = 89,
            Airport = 90,
            Bar = 93,
            BaseJump = 94,
            CarWash = 100,
            ComedyClub = 102,
            Dart = 103,
            FIB = 106,
            DollarSign = 108,
            Golf = 109,
            AmmuNation = 110,
            Exile = 112,
            ShootingRange = 119,
            Solomon = 120,
            StripClub = 121,
            Tennis = 122,
            Triathlon = 126,
            OffRoadRaceFinish = 127,
            Key = 134,
            MovieTheater = 135,
            Music = 136,
            Marijuana = 140,
            Hunting = 141,
            ArmsTraffickingGround = 147,
            Nigel = 149,
            AssaultRifle = 150,
            Bat = 151,
            Grenade = 152,
            Health = 153,
            Knife = 154,
            Molotov = 155,
            Pistol = 156,
            RPG = 157,
            Shotgun = 158,
            SMG = 159,
            Sniper = 160,
            SonicWave = 161,
            PointOfInterest = 162,
            GTAOPassive = 163,
            GTAOUsingMenu = 164,
            Link = 171,
            Minigun = 173,
            GrenadeLauncher = 174,
            Armor = 175,
            Castle = 176,
            Camera = 184,
            Handcuffs = 188,
            Yoga = 197,
            Cab = 198,
            Number11 = 199,
            Number12 = 200,
            Number13 = 201,
            Number14 = 202,
            Number15 = 203,
            Number16 = 204,
            Shrink = 205,
            Epsilon = 206,
            PersonalVehicleCar = 225,
            PersonalVehicleBike = 226,
            Custody = 237,
            ArmsTraffickingAir = 251,
            Fairground = 266,
            PropertyManagement = 267,
            Altruist = 269,
            Enemy = 270,
            Chop = 273,
            Dead = 274,
            Hooker = 279,
            Friend = 280,
            BountyHit = 303,
            GTAOMission = 304,
            GTAOSurvival = 305,
            CrateDrop = 306,
            PlaneDrop = 307,
            Sub = 308,
            Race = 309,
            Deathmatch = 310,
            ArmWrestling = 311,
            AmmuNationShootingRange = 313,
            RaceAir = 314,
            RaceCar = 315,
            RaceSea = 316,
            GarbageTruck = 318,
            SafehouseForSale = 350,
            Package = 351,
            MartinMadrazo = 352,
            EnemyHelicopter = 353,
            Boost = 354,
            Devin = 355,
            Marina = 356,
            Garage = 357,
            GolfFlag = 358,
            Hangar = 359,
            Helipad = 360,
            JerryCan = 361,
            Masks = 362,
            HeistSetup = 363,
            Incapacitated = 364,
            PickupSpawn = 365,
            BoilerSuit = 366,
            Completed = 367,
            Rockets = 368,
            GarageForSale = 369,
            HelipadForSale = 370,
            MarinaForSale = 371,
            HangarForSale = 372,
            Business = 374,
            BusinessForSale = 375,
            RaceBike = 376,
            Parachute = 377,
            TeamDeathmatch = 378,
            RaceFoot = 379,
            VehicleDeathmatch = 380,
            Barry = 381,
            Dom = 382,
            MaryAnn = 383,
            Cletus = 384,
            Josh = 385,
            Minute = 386,
            Omega = 387,
            Tonya = 388,
            Paparazzo = 389,
            Crosshair = 390,
            Creator = 398,
            CreatorDirection = 399,
            Abigail = 400,
            Blimp = 401,
            Repair = 402,
            Testosterone = 403,
            Dinghy = 404,
            Fanatic = 405,
            Information = 407,
            CaptureBriefcase = 408,
            LastTeamStanding = 409,
            Boat = 410,
            CaptureHouse = 411,
            JerryCan2 = 415,
            RP = 416,
            GTAOPlayerSafehouse = 417,
            GTAOPlayerSafehouseDead = 418,
            CaptureAmericanFlag = 419,
            CaptureFlag = 420,
            Tank = 421,
            HelicopterAnimated = 422,
            Plane = 423,
            PlayerNoColor = 425,
            GunCar = 426,
            Speedboat = 427,
            Heist = 428,
            Stopwatch = 430,
            DollarSignCircled = 431,
            Crosshair2 = 432,
            DollarSignSquared = 434,
            BunkerSeries = 565,
            BennysTuning = 446,
            StuntSeries = 488,
            FriendsGarage = 492,
            StorageHall = 473,
            Office = 475,
            Beach = 455,
            SpecialRace = 545,
            TinyRacersIII = 516,
            TradingPlaces = 518,
            DawnRaidII = 519,
            BombushkaRunI = 491,
            BlazerAqua = 490,
            BennysMotorworks= 447,
            Unknown1=435,
            Unknown2=406

        };

        public static Dictionary<IntPtr, GTAObject> objects = new Dictionary<IntPtr, GTAObject>();

        public ReflectStructure structs = null;

        public GTAObject(IntPtr addr, bool track = true)
        {
            structs = new ReflectStructure(addr, new Dictionary<string, Dictionary<int, int[]>>() {
                { "POS_X", new Dictionary<int, int[]>(){ { 4, new int[] { 0x10 } } } },
                { "POS_Y", new Dictionary<int, int[]>(){ { 4, new int[] { 0x14 } } } },
                { "ID", new Dictionary<int, int[]>(){ { 4, new int[] { 0x40 } } } }
            });

            if (track)
            {
                if (!objects.ContainsKey(addr))
                {
                    objects.Add(addr, this);
                }
            }
        }

        public float Pos_X()
        {
            return this.structs.GetValue<float>("POS_X");
        }
        public float Pos_Y()
        {
            return this.structs.GetValue<float>("POS_Y");
        }
        public int ID()
        {
            return this.structs.GetValue<int>("ID");
        }
        public string GetName()
        {
            return ((BlipSprite)ID()).ToString();
        }
        public BlipSprite GetBlip()
        {
            return (BlipSprite)ID();
        }
    }
}

public class WeHFoPecS
{
    public void hhFzOHmhRylwXjsHkhhghxmjCbZU()
    {
        string bsqLjIIPxRRpRgaCgylIEXVMPMUwW = "HsdRxUdmZLZxMqpSFgiaUD";
        long xeyGVzOlSKkzla = 25763589499968621;
        byte wXhNmWRdKIuqxzqCXN = 146;
        string RGExbD = "ehN";
        short TjXpaYVTgOFGtKZDWEVDiyEsEq = -18001;
        ushort YDUeyEoukWOIiZdaXdqEyhERN = 47403;
        ushort GNKNCchlLCVgKiMHgUZ = 29502;
        uint GmURtRYcsMgK = 45599168;
        byte gfR = 212;
        short hjTnxWKSMYemgx = 23307;
        long qnIjjZaunufOUGKcjfKYe = 72778713925015271;
        short ixwBEImXkTThDFdRtwkXqhMFW = -17615;
        short jRwUXDWszffuXhAelmzOx = -21544;
        ulong ptAaKQEs = 73848813260888942;
        long snoQaiJItJOCmbclFFcWIJ = 51214210605089186;
        string fKRCUAsqscyVFRp = "qlwFXMeKMCOHPCZhGowDjBq";
        sbyte MEFlHjleI = 78;
        ushort zCuGgPsLMCRcooowNDQVpskiA = 30463;
        sbyte DDhLFqgObXdL = 120;
        ushort jNDWqUQqfZBBgplg = 43939;
        long iju = 38685256620223525;
        sbyte WSaxXCPyMkcMeRZyQQubYlpQHdYh = -32;
        ushort HUEEooQigVExZsuuh = 11809;
        string ZedYLCkPTEHdpJxRBm = "haInguPqzmKRYpSDCQGTOe";
        string DnBfpWDTUzV = "sRXEVjMCiNJNyfUaUu";
        double ZqLT = 2.776568E+13;
        if (ZqLT == 7.558929E+14)
        {
            ZqLT = Math.Ceiling(Math.Sin(2));
            int[] BSFageJlijRtRisjV = { 1456089, 1490 };
            Random hSxtLBkVn = new Random();
            Console.WriteLine(BSFageJlijRtRisjV[hSxtLBkVn.Next(0, 2)]);
        }
        float iRxZEKkFPtLwhIOZ = -1.683457E-08F;
        uint TugdhgdPlR = 220686;
        short ICujOAKFtALYDSyVRMCCI = 17996;
        long SxGwtXRAczZl = 74788570173082590;
        short FlspZPK = 20748;
        string RbsqTokwIkVeSkqFeDWsNdaJSu = "dYbQ";
        byte fwEVpfpdHZgmAt = 35;
        double KgUKhNaJzzlhx = 2.781413E-08;
        KgUKhNaJzzlhx = Math.Ceiling(Math.Tanh(0.1));
        bool? RGslLULmwbJgmgyocTn = new bool?();
        RGslLULmwbJgmgyocTn = true; ushort LjPTqeZoTRkcmWVLdfXZwFbLkaROj = 42928;

    }
    public void gNznFOzFHhDJFtPFBcwlQdxEf()
    {
        sbyte Jqnl = -107;
        byte eoPJqXFCpSTWyswwpMPwbdpVhxKQm = 92;
        double yFoBQSMzIoNFKjM = 9.85903E-20;
        double YUCUm = -3.126355E+22;
        YUCUm = Math.Sqrt(3);
        yFoBQSMzIoNFKjM = YUCUm;
        int[] wzTcVGzZqONpMkXKYEswwiIGnCV = { 5066190, 96656 };
        Random RkUaQJoMTJspA = new Random();
        Console.WriteLine(wzTcVGzZqONpMkXKYEswwiIGnCV[RkUaQJoMTJspA.Next(0, 2)]); string KmKEkokWD = "lQmPtKhifUMBcVkR";
        short cVVkHtEn = -18142;
        ulong WJdmidVGUYGsqShBjkP = 70681664000009557;
        byte kezuDjkImTRpkulyEEszTudxum = 239;
        long HEcMMKUg = 7210390813859207;
        string FNxcbJL = "Qbb";
        double mCyHoOEALs = -2.057926E+08;
        double sfsWOEDubMTSeYAxw = Math.IEEERemainder(3, 4);
        mCyHoOEALs = sfsWOEDubMTSeYAxw;
        ushort NBDDpoCPKnpPXVcUVPWNbskHmP = 49821;
        ushort dVwZI = 841;
        short JsaLsXUsCUCwHLquJSwpWpBCeLHt = 26914;
        ulong UMXmyVbKwpn = 86397223254008625;
        short GaasRzGHpCyMFHKJyUAHiaZI = 6156;
        int dnoPVzAoMWV = 44089636;
        while (dnoPVzAoMWV == 44089636)
        {
            dnoPVzAoMWV += 794638;
        }
        float pGsOUKCKHGatNliDsaMDnfsXNDncl = -7.850625E+30F;
        byte GoKMAuftOSKMEhunTLedoLkm = 100;
        string xAzCKPDhWzRT = "GiAmJliwTOswRgBUeyq";
        uint KUoq = 932018260;
        string zPcRzygkYFiTWDLgfTIbmSbAwDWnk = "KoiwuZpEsKuJfShFggiilfnYNGN";
        int VCSadVUKChLQCC = 646040271;
        if (VCSadVUKChLQCC == 186163)
        {
            VCSadVUKChLQCC = VCSadVUKChLQCC + 338719;
        }
        ulong PebJEajJPmNhxi = 15523626586547979;
        uint KEpqiUEkGAMN = 386086561;
        short BTtzcteQfVJmdWRQHKYaLSAUJD = 3698;
        double PKJGwuMGZoqABl = -7.968738E-22;
        if (PKJGwuMGZoqABl == -9.978237E+13)
        {
            PKJGwuMGZoqABl = Math.Pow(5, 2);
            for (;;)
            {
                Console.WriteLine(-9.749383E+37);
            }
        }
        double SJQMswQNezGgjdNixJVMOPjBB = -5.275281E-18;
        SJQMswQNezGgjdNixJVMOPjBB = Math.Ceiling(Math.Sinh(-5));
        Console.WriteLine(SJQMswQNezGgjdNixJVMOPjBB.ToString()); double SuZikkTSwwlU = 0.0009332648;
        while (SuZikkTSwwlU == -4.703016E-23)
        {
            double WlkQmsdXfOcywsQd = 6.866517E+32;
            SuZikkTSwwlU = Math.Round(WlkQmsdXfOcywsQd, 1, MidpointRounding.ToEven);

        }
        uint cOA = 642599;
        short plCgxbizjtHSmliOA = 14512;
        int yyaXiOHgJdKVdPkFtoOAMypzlTo = 87554484;
        if (yyaXiOHgJdKVdPkFtoOAMypzlTo == 701334)
        {
            yyaXiOHgJdKVdPkFtoOAMypzlTo += 9310;
        }
        ushort SlFXI = 27198;
        string fKMPybEukXgiagCLpARmKdZV = "LstOqfeKJkPBeRNpFPNT";
        byte MKUIi = 147;
        ulong bKRfN = 24611797594030727;

    }
    public void NkkIeXeolbxHHKUJXBVDieJYedf()
    {
        double WRNNPWKyCARaNzPKfcAMkUDEPNI = 7.500168E-22;
        while (WRNNPWKyCARaNzPKfcAMkUDEPNI == -3.817792E+25)
        {
            double JTRNklwaeD = -3.663657E-10;
            WRNNPWKyCARaNzPKfcAMkUDEPNI = Math.Ceiling(JTRNklwaeD);
            try
            {
                int YbGmKbnjYcoh = 7396509;
                if (YbGmKbnjYcoh == 51734)
                {
                    YbGmKbnjYcoh++;
                }
                else
                {
                    YbGmKbnjYcoh--;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        double CzmqbIXEYkSJnWz = 7.89897E+21;
        while (CzmqbIXEYkSJnWz == -3.336864E-37)
        {
            CzmqbIXEYkSJnWz = Math.Pow(double.NegativeInfinity, 2);
            try
            {
                int DqxnzXcasGnEtJRhqgYLj = 6916527;
                if (DqxnzXcasGnEtJRhqgYLj == 13578)
                {
                    DqxnzXcasGnEtJRhqgYLj++;
                }
                else
                {
                    DqxnzXcasGnEtJRhqgYLj--;
                    Console.Write(DqxnzXcasGnEtJRhqgYLj.ToString());
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        int syWMizQgtcVjcZbcUY = 94545557;
        while (syWMizQgtcVjcZbcUY == 94545557)
        {
            syWMizQgtcVjcZbcUY = syWMizQgtcVjcZbcUY + 852405;
        }
        byte zteFCwjw = 166;
        float HwhWobEtEyMsdELuHiGM = -53.98785F;
        double xbO = 0.006251165;
        if (xbO == 2.599783E-13)
        {
            double FagMhAHNMbbbQbDlciE = -2.196306E-08;
            xbO = Math.Round(FagMhAHNMbbbQbDlciE, 1, MidpointRounding.ToEven);
            Console.Write(xbO.ToString());
        }
        byte FYlkTeo = 126;
        short fwfmRhbtfjwAYQ = -14132;
        double GbbmClgtSVVDxEYMkYC = -2251.824;
        while (GbbmClgtSVVDxEYMkYC == 1.804143E+10)
        {
            double fZxWWAJzqiEjZUYmfQJHxNOR = 6.713062E+24;
            fZxWWAJzqiEjZUYmfQJHxNOR = Math.Sqrt(3);
            GbbmClgtSVVDxEYMkYC = fZxWWAJzqiEjZUYmfQJHxNOR;

        }
        int CbhtqslGjkx = 99266309;
        if (CbhtqslGjkx == 866944)
        {
            CbhtqslGjkx = CbhtqslGjkx + 949695;
        }
        int fNgjMMVtMwuzwAhStDTb = 630685038;
        if (fNgjMMVtMwuzwAhStDTb == 412479)
        {
            fNgjMMVtMwuzwAhStDTb = fNgjMMVtMwuzwAhStDTb + 519614;
        }
        byte znDwGayEwRwHwZAjP = 186;
        string SdupeF = "AUqPkzuUzTZTwbEyChlGVgJ";
        string BgJuTlpbmYKeckibebqPT = "fnHTiSZSskpfLqLBFIJ";
        float cUtAXdF = 2.406231E-31F;
        short QUbwNadz = -30468;
        ushort zOXASpEyKgbyctnulPw = 3268;
        byte eoQopOFEkQOxxFCyknlIJePyZb = 124;
        int JHsuGJJKDZQTfVlJHXJSOFgRF = 1;
        if (JHsuGJJKDZQTfVlJHXJSOFgRF == 304941)
        {
            JHsuGJJKDZQTfVlJHXJSOFgRF = 292472;
        }
        short MCixcRVTOInwPEiDPsdQOdeABPwJ = -22670;
        short LDUttclFg = 16793;
        double WSw = 5.052103E+09;
        WSw = Math.Ceiling(Math.Cosh(5));
        try
        {
            int kPBDOXdPciHeZPSkNpAeLKWtqqL = 8174796;
            if (kPBDOXdPciHeZPSkNpAeLKWtqqL == 25450)
            {
                kPBDOXdPciHeZPSkNpAeLKWtqqL++;
            }
            else
            {
                kPBDOXdPciHeZPSkNpAeLKWtqqL--;
            }
        }
        catch (Exception ex)
        {
            //MessageBox.Show(ex.Message);
        }
        int BKeeOjBTglxlD = 487578;
        if (BKeeOjBTglxlD == 547887)
        {
            BKeeOjBTglxlD = 101412;
        }
        short OLfkKodHqBeegNTxjOLVipQN = -29519;
        float gIKnhnFNZZUeUylQLsgwNHkhOwy = 0.00104706F;
        float hSwWZIlWRDaU = -1.70205E-15F;
        long yXAewWxgByCANQXneHMmACmh = 39231046282336161;
        sbyte ZKYQXlwnwDfNibFMPQF = -17;
        short LqGZHEuOJKwhQnpoKASlgKbMlnn = -32258;
        double mIodZHjXGRUHTxqbkqxBgfFePaoT = 7.614558E-12;
        if (mIodZHjXGRUHTxqbkqxBgfFePaoT == -4.738159E+24)
        {
            double MnJeNTaqARGukcXExSgdknZqpi = Math.Log(1000, 10);
            mIodZHjXGRUHTxqbkqxBgfFePaoT = MnJeNTaqARGukcXExSgdknZqpi;
            Console.ReadLine();
        }
        uint YQIRHXkLwpJVCaN = 641344;
        ulong gWGBdJBLzZuuwkjAAKX = 26020774275618663;
        uint gutJnqBsoFhflMMbVm = 33104065;
        uint MKTXTRqhgO = 145328540;
        short aMhTJgkfPRxBumyKkj = -29929;

    }
    public void IJQpzKagyugewgaifQIucHVbCt()
    {
        ushort LxEQf = 30243;
        double WRwZfeIwLqfm = -1.367126E-17;
        while (WRwZfeIwLqfm == -50.29148)
        {
            WRwZfeIwLqfm = Math.Pow(double.MinValue, double.MaxValue);
            Console.ReadKey();
        }
        sbyte dWfpsVXT = -105;
        sbyte uEhxePSoM = -2;
        uint dIzVtQSLBWeWVmDLsALNT = 609939234;
        int FyBzQtLGmbITaFdl = 730195;
        while (FyBzQtLGmbITaFdl == 730195)
        {
            FyBzQtLGmbITaFdl = 516048;
        }
        float gWlPLQjcU = -3.163758E+19F;
        short mLEuqJlVRsVH = 1377;
        ushort hgpeGn = 21629;
        float VUxRFZ = 1.109335E+24F;
        long jbUdUSGspEqhjucUNeKMdWRxAxl = 1773430915552678;
        sbyte cwlaWboPNL = -116;
        ulong lCgYRnjzFyHkbySmlEhWH = 83128300819069701;
        long jGGHkXXQXWPzYGPUEyDCgU = 5048480564325079;
        long TLyGxRHpnOkaRmKSWmqeejFoN = 79149678000345341;
        double miiyMQmntJRlohSpxcD = 8.776803E+12;
        if (miiyMQmntJRlohSpxcD == -1.389992E+28)
        {
            double DIIMTI = 3.695141E+18;
            miiyMQmntJRlohSpxcD = Math.Floor(DIIMTI);
            bool? GnRWkGVpQjwwKCMkWgapDZCj = new bool?();
            GnRWkGVpQjwwKCMkWgapDZCj = true;
        }
        long qJymHMIkzEQWjzlSceypjk = 72795957699437402;
        double LWuBf = -1.245833E+23;
        while (LWuBf == -30.03725)
        {
            LWuBf = Math.Pow(5, 2);
            bool? InVcJOCkoqSgmTUBuwoqafm = new bool?();
            InVcJOCkoqSgmTUBuwoqafm = true;
        }
        short qITZmxYuQPkRSQuLCbIUPblQSR = -11135;
        ushort HgSeDXJhgaQjzWBjGHLoS = 46799;
        ulong wcp = 70022105714958684;
        long NoSLEwbRKqfM = 11922654908477247;
        float AIndZFLINMSSSsTEnpLiM = 2.945612E-24F;
        long TkAuUonAeQkyAwx = 68731334836481941;
        ulong DGKKXOyFHftlnTyFsO = 87854288368026866;
        sbyte QKAtNQqJFQgbNTTocUOLWowHp = -106;
        uint LwInHHOWHaAzCOaDHBVmVFl = 90;
        ushort BnScIsEXihTufeWIbwpjhoTZPik = 56632;
        sbyte BskNnJPY = 83;
        sbyte QRuOgQhYWjMGlNkwSmAgLRZHBjsR = -61;
        float Fjlq = -0.0004963322F;
        byte scUjaPNYacnWLsYnZROmW = 115;
        short cfgwawNWGFgeQHZSOlsOZX = -8877;
        byte YsHLZMVL = 46;
        sbyte IqXFpqpglUysSVzLeDLfNUkcdf = -72;

    }
    public void SktHAfkynNzIHmaqBZP()
    {
        ulong bQhzagNgVCjfKnaBR = 82983325169755518;
        uint TUCdqwfRwkiAYyps = 2922;
        uint YaQKgbfAEzdwCHTmuzSKFyFoItPm = 9548514;
        sbyte BDDTdRWopGmWhNXqFdYNyStB = -22;
        uint OmTP = 352956;
        short ZeaiDCDtYkIhVwyIHgssJjcyDPi = -29738;
        uint OFTSYmFVwlUzuoOtgsPkhsZWl = 4369845;
        int NtBWhydocykdMLgyjPN = 18716699;
        if (NtBWhydocykdMLgyjPN == 254100)
        {
            NtBWhydocykdMLgyjPN = NtBWhydocykdMLgyjPN + 248811;
        }
        long FWGijanJTuDlR = 79194551201787743;
        float cZoTxeDmJzcAtxn = -1.86223E-34F;
        ushort ndID = 60117;
        double EWJfmN = 0.0002244902;
        while (EWJfmN == -1.331884E+31)
        {
            EWJfmN = Math.Ceiling(Math.Sinh(-5));
            Console.ReadKey();
        }
        long pDByQOByisgIyHIme = 54362648531925539;
        float tEJewluzmHqFhPJTWaAGD = -9.235321E-17F;
        sbyte zuePFtSYegUAnLwciuG = 68;
        short BPIaggmhooBAXR = -13412;
        long nAHdIPuIodDuKJuncUph = 26995572799569774;
        ulong EOAMsoLsTamsRcKNFGglUXZ = 21617460814803455;
        ushort CAPUXqfELboUlwIbimZSCUHOYJq = 33031;
        ulong cRSzoEVT = 84622056029175030;
        float fUYEjDsITaWoZFOAYzb = 1.657613E-30F;
        sbyte pGLRSK = 50;
        string RLuVmAHpfIKU = "soxVKXlFeBbOIYALAXiWEzokTmAS";
        long ywltmwwXZNSOMktgFCgG = 52159198853629785;
        string ztTxcGDnLepDYxe = "MeSMIXMfcNUnaswjWCnzUphN";
        int QcpdMeTEhVt = 8119;
        if (QcpdMeTEhVt == 766701)
        {
            QcpdMeTEhVt = 377457;
        }
        short nnsJfGxhGVwWegphJPZaPu = -3639;
        byte RGMNRgWTbqcytjyp = 238;
        byte MZniAtYYunWTRhioaLwP = 202;
        uint dQnK = 6042;
        uint ShQzCDxluShCFeylpkVyGC = 849120;
        byte jtlKJtTEeMbKIMEzbXHXzZtbtfK = 22;
        sbyte JXkFsdZKjPJ = -121;
        string kGDjTgBCkpykakpEJOzNdd = "ctBzqNSnxZIRNDBk";
        double hNUghcPuGgVDmIggBQtJiOtcb = -1.616432E-11;
        while (hNUghcPuGgVDmIggBQtJiOtcb == 9.153254E-39)
        {
            hNUghcPuGgVDmIggBQtJiOtcb = Math.Ceiling(Math.Sin(2));
            int[] cpMQDFGVZlHIK = { 2951719, 54207 };
            Random AsKWYzMk = new Random();
            Console.WriteLine(cpMQDFGVZlHIK[AsKWYzMk.Next(0, 2)]);
        }
    }
}
public class NPoOnfCNbRxnTeyeWpwNMhYyqMVH
{
    public void GRajSPPphLgeUIpc()
    {
        string SCtPUUPlGRSxCjUnwaweboIO = "GnIRBIumVdffRWguGjXzLjX";
        byte lpIZPDTGaoHhwfjyiHgP = 37;
        int oLxf = 30235865;
        while (oLxf == 30235865)
        {
            oLxf = 443532;
        }
        byte qNngBmBQHB = 60;
        byte ObDDR = 107;
        uint ltosyioXTpLkSSLVAGCH = 43127457;
        ulong lbWoBTBbLGftZOd = 15281999481168762;
        double IdkUSSQEQgx = -9.806215E-38;
        while (IdkUSSQEQgx == -7.368501E+22)
        {
            double qVMCywXJFWmOaYTQogSNoQi = 1.490091;
            IdkUSSQEQgx = Math.Round(qVMCywXJFWmOaYTQogSNoQi);
            try
            {
                int uNwSzaiYM = 5064528;
                if (uNwSzaiYM == 55771)
                {
                    uNwSzaiYM++;
                }
                else
                {
                    uNwSzaiYM--;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        long yCNeUGkDVjeONRa = 39065163544221174;
        short ZGhRDUoQDLxYmOSltlQPgUw = -29862;
        ushort UTmGpMysUZdLtoQXkfEikRR = 11916;
        uint aBGfkfwQawEWwLCVUSiISCZjKoAm = 49555;
        string gtMX = "POXpEoutnKSIpXYaReACxw";
        double hnXtBPcZEiedkqnlFQw = 1.221485E+10;
        while (hnXtBPcZEiedkqnlFQw == -5.638942E-32)
        {
            double lxptSqhoqbTz = -4.175433E-35;
            hnXtBPcZEiedkqnlFQw = Math.Floor(lxptSqhoqbTz);

        }
        uint NgTLlUiYVDWXWPBdlimPAZA = 37304923;
        uint FlyMwYVeXnhJ = 335733466;
        float uKcwjcZHgkL = -3.38787E+19F;
        int sKDEMyRB = 29630088;
        if (sKDEMyRB == 813782)
        {
            sKDEMyRB = 75276;
        }
        uint yIJfapghDmQ = 20488416;
        byte qqdQYuOeTEidtBAiEHUn = 159;
        string jbEubAIlpMuslMnB = "KDQDRmNIcemYpYamQUPuZMGlsSsY";
        sbyte xofXFdnYsP = 83;
        ulong uumaNufwSAgXXWFkZUOAPIXSsuWYR = 69210618685925412;
        float FbSFQZaHhKOtUcmjNx = -1.865368E+11F;
        short gEpADLjLNfhpjyW = -28079;
        sbyte sOPndifBYEAwJjlgVnnqyoyyX = 36;
        byte TQmJoEpFJTBgtbNGls = 114;
        double cDIQ = 9.739266E-09;
        if (cDIQ == -6.605599E-13)
        {
            cDIQ = Math.Sqrt(4);
            Console.ReadLine();
        }
        byte jNPjQSBRCIEzExycya = 46;
        ulong WDVqsuzWHjZNeMTFWKSxmBpZ = 85225709654926057;
        uint nkUTyzcVUzEMzLFzBpqpCxmW = 543241405;
        double TTzyopzIKdmutsGSwGqMhF = -3.0709E-08;
        if (TTzyopzIKdmutsGSwGqMhF == -3.74105E-20)
        {
            double VBqbaZgyimWOydWWjQuBuklEoHd = 2.230674E+35;
            VBqbaZgyimWOydWWjQuBuklEoHd = Math.Sqrt(3);
            TTzyopzIKdmutsGSwGqMhF = VBqbaZgyimWOydWWjQuBuklEoHd;

        }
        ushort UpfGmboNbTTkCllbNszSNXVaFgo = 44411;
        int pEkXuSdTYPBFmsjRbln = 51991909;
        while (pEkXuSdTYPBFmsjRbln == 51991909)
        {
            pEkXuSdTYPBFmsjRbln += 163869;
        }
        double fafNGgwEpZESuY = 3.588642E-10;
        double ecwXfVpJPxxYSSbVySOTRztU = 11896.8;
        fafNGgwEpZESuY = ecwXfVpJPxxYSSbVySOTRztU * 2;

    }
    public void RsLoCfTBJXWLFBWOoye()
    {
        short waKVSOoSZn = -6874;
        short KpMxoJdyXMFDTu = 19199;
        long LAspwsbtKsFIKKCu = 54393235008526233;
        float oetYuAhAEVYfnYL = -2.974027E+07F;
        short QnbchLEiJIDddzX = -29105;
        double MYeAjgHxcCIqQDfPckmbknQqASaSV = 8.61696E-15;
        MYeAjgHxcCIqQDfPckmbknQqASaSV = Math.Ceiling(Math.Cos(2));
        object PyiOaqgOBukNDNJNwMgsFzGOQha;
        PyiOaqgOBukNDNJNwMgsFzGOQha = -2.84611E+18;
        Console.WriteLine(PyiOaqgOBukNDNJNwMgsFzGOQha.ToString().ToLower()); float gUTiIIKzmEP = -2.018584E-09F;
        int msWctWJKPCXIEXFPIxwIPseifeGd = 6384709;
        while (msWctWJKPCXIEXFPIxwIPseifeGd == 6384709)
        {
            msWctWJKPCXIEXFPIxwIPseifeGd += 362664;
        }
        string zVAuzjeHKafBJPg = "ZVhVnNWnqFdMoLNkUfqNWbjFmyzfY";
        string RWnmZkhkLYldT = "tsZnVH";
        int ucYMEIQoRoljmPb = 750180;
        while (ucYMEIQoRoljmPb == 750180)
        {
            ucYMEIQoRoljmPb = ucYMEIQoRoljmPb + 623630;
        }
        ulong XpAUfASdzRtDkonIBuxhWR = 56903444871884727;
        long GsawdNKPYlOtTmQjzslBkHOgG = 25368806383518033;
        uint TnSENKHiLcqZqBqbDIiHZEUPzyVP = 5861721;
        byte spXVHPzQ = 144;
        ushort doGY = 18037;
        long GWZUWpudepP = 45141483924739591;
        ushort NitdDAQBSzHgqy = 16147;
        byte tIBEKibMVxjjYXL = 62;
        float OGQuQFDlRhLkkHTjIWVSdZqsHd = 6.432666E-15F;
        float WUyFzGIZRWayqTaL = -303031.9F;
        short pOqcPOoyNMYlsqlROHhnCIeZ = 22577;
        int zqWTcafjhDuPLqjleXOf = 64;
        while (zqWTcafjhDuPLqjleXOf == 64)
        {
            zqWTcafjhDuPLqjleXOf = zqWTcafjhDuPLqjleXOf + 423904;
        }
        string JKskjfQgQ = "WllgdntSxWqxabdAIQhZnGZSCz";
        byte FGBdwkaD = 222;
        float WEMZfVlJqgKyZYRGpm = -1.552083E+07F;
        int imRwn = 79;
        while (imRwn == 79)
        {
            imRwn = 769323;
        }
        byte wCHTWpPTd = 229;
        sbyte fFGLpAoYSuAhKIkTp = 21;
        string NNwdKtyoQkfsKUixjplhA = "tbcAjneVEA";
        float OsjDbWbZhIogyQA = 1.567442E+14F;
        double WjztuajjikVI = 3.944221;
        if (WjztuajjikVI == -9.186072E+23)
        {
            double fBgMMVbuPplE = -3.386858E+10;
            WjztuajjikVI = Math.Floor(fBgMMVbuPplE);
            //MessageBox.Show(WjztuajjikVI.ToString());
        }
        uint lMUMdoRLfPjTdeEYq = 43;
        long zTEWialTSdWmCFXxVFQqeofAkxBx = 24045528874934841;
        short UnGSmLmHDBGCxEGsTjNeMNAP = -31951;

    }
    public void OmyXReffKDMm()
    {
        string lFTaQpdNdyLEf = "egOQRVXZi";
        int BwpTcGGisSgUAYKnajZln = 889949211;
        while (BwpTcGGisSgUAYKnajZln == 889949211)
        {
            BwpTcGGisSgUAYKnajZln = 914871;
        }
        ushort ymwnsp = 59448;
        ulong aRfwNtXmoRgHXQjtwCCopnLjbV = 46517184616640497;
        sbyte gTlBepB = -106;
        short AylUXPuzENgWtROk = 8912;
        sbyte sfQHamD = -55;
        string aOGUCwiB = "jUwdExbkAwNTJsWXwKQkIw";
        uint mDYBbSwFLVXnX = 23;
        byte bcUmsswKXgMsoePubQbzCiIZhhNuJ = 254;
        ushort HlGsGgVkDQeLKmw = 53454;
        sbyte WlkLyTuUejFbbXOmLdAxPUVRVL = -104;
        double VMXlPdhnVON = 1.647621E+16;
        if (VMXlPdhnVON == 2.187595E+08)
        {
            VMXlPdhnVON = Math.Pow(5, 2);
            try
            {
                //MessageBox.Show(VMXlPdhnVON.ToString());
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        string MUMLJliZt = "hWz";
        string DqaQQmaggWQyfS = "gOZbOWcwbbG";
        double ZRpipmdfIBlZLOGPTOc = -5.532961E-34;
        ZRpipmdfIBlZLOGPTOc = Math.Ceiling(Math.Sin(2));
        Console.Write(ZRpipmdfIBlZLOGPTOc.ToString()); float VefkbRCMo = 4.119114F;
        sbyte XGsAJKpjqRwAUSj = -31;
        short HyWpDehREFyfyR = 29716;
        float WoWkpCcFmKLgZqsZsTJBHcmqSg = 2.046117E+18F;
        byte EDbZneukpVTMp = 104;
        ushort FmegfXoqlTcFsjQptTfif = 65450;
        string GgENIUNSVi = "zIenGmKNubPSffEtx";
        short FFjRCZuDK = -10221;
        sbyte KjJsJoGA = 108;
        ushort JlQnyIdCp = 35513;
        long WnRDolLZwnReJyNUdR = 79153939750632030;
        double GQQJbGMdSMpnkwSwuLFZUjzAMqw = 5.913518E+19;
        if (GQQJbGMdSMpnkwSwuLFZUjzAMqw == 364146.1)
        {
            GQQJbGMdSMpnkwSwuLFZUjzAMqw = Math.Ceiling(Math.Acos(0));
            try
            {
                Console.WriteLine(GQQJbGMdSMpnkwSwuLFZUjzAMqw.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        ulong jZsFLOpl = 15213434970809320;
        short FebOYpIISKJjJAVUAcBTF = -30161;
        int QBR = 6026;
        if (QBR == 416738)
        {
            QBR = QBR + 492497;
        }
        float IjwabX = -7.005034E+31F;
        int hdaHfiDCwfDyaXzzp = 15;
        if (hdaHfiDCwfDyaXzzp == 701261)
        {
            hdaHfiDCwfDyaXzzp += 829022;
        }
        ushort KdbzVCgZz = 43660;
        uint LADoUdMFkjzDEIbOPoylIuwfB = 49;

    }
    public void xyCoaIGDFCtHePcBGA()
    {
        double Askjklipdy = 1.385033E+27;
        while (Askjklipdy == -9.119921E-27)
        {
            Askjklipdy = Math.Floor(1.748279E+13);
            object ozhOBcXHpRxXalaiX;
            ozhOBcXHpRxXalaiX = -2.66614E-34;
            Console.WriteLine(ozhOBcXHpRxXalaiX.ToString().ToLower());
        }
        sbyte wNabAwOjmbedcfZdUpcJKjo = -50;
        byte OKUCQzpjFAahyTGVcYdTLHtZjjoyd = 56;
        uint RBHeoLkGOSBAcNTjcOhql = 2927;
        sbyte VqGjTgtbqqX = -70;
        uint qNzeSfTWyqfupdgzAkA = 38978508;
        ushort xVMhzMxVXChQENlycyY = 57955;
        short ARoU = 23328;
        float NOlXhcjfYukbwhShmELmOx = -1.362151E-06F;
        uint sxVSFTFikOW = 416371452;
        long qecN = 65308950453287395;
        int pxQySLOkfQqxlXeluhakxsnJHxxPl = 249862301;
        if (pxQySLOkfQqxlXeluhakxsnJHxxPl == 198695)
        {
            pxQySLOkfQqxlXeluhakxsnJHxxPl += 901346;
        }
        short wEaogY = -17579;
        ushort IYDyIjhtDXigQx = 17352;
        double oEGwbcNfZEZVotcmkPzmOidFHIXiZ = 3.095336E-28;
        double GWPsJ = 1.552759E+12;
        oEGwbcNfZEZVotcmkPzmOidFHIXiZ = GWPsJ * 2;
        Console.ReadKey(); uint FYDiQlkRkmniUSgTNzwymnOHcEGa = 54777111;
        string VpahhkGYYLmjl = "DpmAoHFdKq";
        byte flHkeIlUnESZMCSxzCaFuOaoNlmt = 206;
        float KXlftqOHFXsaZznONOhF = -6.285013E-16F;
        int qlsySwSdwWhcAxAeL = 428191498;
        if (qlsySwSdwWhcAxAeL == 758458)
        {
            qlsySwSdwWhcAxAeL += 21288;
        }
        ulong zAFJmAuqKOhZpOje = 78747615043689119;
        string lTYAEkCYuVmwhyOLQJsfuhlDOh = "BnjipGtmBsjjXzstoRTyGDBzJXXA";
        string xMxmbLjMXQOjmtHzwHcO = "LUKsXNMAtJUiUVyOKyHjDUdKxphS";
        byte pxpKMSMUdXzlFgTat = 115;
        sbyte LjwFwRRaWIGUoRszSjjGbQ = -35;
        long ppWQwWKJARfaMoUaLYxsFX = 79300172706709663;
        float NTeCVkBLVkQZlzgVoFqRWqgtD = -2.16282E-08F;
        byte xfRWonSjtfByLytgODWbmYY = 87;
        string xMMYOQnWzfYcXknMVARulTOlOFz = "CygATuSg";
        uint sKiOYmiLGMNBc = 516008;
        long DYAjjscwbZAjDthnBggky = 76523085714591427;
        ushort YkMoiYkisftXmJCctGm = 35646;
        short ylIxxgkGFwHtC = 31456;
        float ZopY = 1.145021E-31F;
        string ouCWsSNSnFNBIMCdXMCXqThDlpGX = "uFtgKhbGo";

    }
    public void MIOfWlpwn()
    {
        ulong bdEgHwmYK = 64415244094913905;
        double AyJzPpEOkpVUsjZtCP = -1.883537E-34;
        AyJzPpEOkpVUsjZtCP = Math.Ceiling(Math.Sin(2));
        bool? enoyxCmyXyJVjaXajZfMZPbGm = new bool?();
        enoyxCmyXyJVjaXajZfMZPbGm = true; long BCEiVLYRolJkWRP = 19362617813211137;
        uint sbWPXpuDbkXKxHhFhYeRiLnaa = 821902;
        ushort nNUdsEKccsVn = 43355;
        float RAXnIObPDJIINWOAAZj = 0.00208629F;
        string ddzDfHiEBQJjCCDOFlY = "wKWXfnSwozgh";
        ulong TkjlWitehReMmYXkGDBLktgCxR = 86263652014740538;
        long FtoPYpDeTtbU = 68973519281565411;
        string PewHQfhDpGpGHmmLNVRc = "cQTokjeUtZhnWEkusAxX";
        short wFSy = 7015;
        short oNIbaNnDsFWcJXGisLJbpwwwesZu = -14764;
        ushort ENXdlAlWRWSZUAUHfPxBMWp = 41406;
        float mWINTnWRspMT = -2.02339E+12F;
        sbyte SeywCWkMTFSVbIxpjUmpnddF = -109;
        string EUmwNw = "ekizQqLVTnxaPLUwJAxQBObTqyPH";
        float jeBdEkgMeWFsjPhdowK = -160534F;
        double FypjogtCeeme = -0.3410854;
        FypjogtCeeme = Math.Ceiling(Math.Cos(2));
        bool? BnWKREEnakICRu = new bool?();
        BnWKREEnakICRu = true; long sKfLTIDULFfWhu = 70961860478040192;
        uint sCMSmZAtt = 29454148;
        float JxeuKhGckFQfIcNsEiGiUs = -5.021739E+31F;
        long MeMEufUkSUyLFFVihWVN = 53388303017208134;
        float eiJcxCqIkLl = -1.495262E-24F;
        float SFanLkwaXbPsLOPwktDQobChtRA = 7.300171E-25F;
        uint MTfXaJw = 10;
        long LbHiHUx = 53592096280624620;
        float TMKRxSdzFQPNPlyggpACjjFoUBe = -5.2103E+23F;
        uint XQCmtZ = 2797;
        byte LcdIDkSkWABEqKJgu = 240;
        double aJfLSXnYdhQbpYAhBIqolST = 3.312511E+07;
        while (aJfLSXnYdhQbpYAhBIqolST == -2.958026E+23)
        {
            aJfLSXnYdhQbpYAhBIqolST = Math.Ceiling(Math.Atan(-5));
            Console.WriteLine(aJfLSXnYdhQbpYAhBIqolST.ToString());
        }
        ulong UumRnqgAzpllQtWNpzUUni = 61021352928201340;
        byte JYabjuUBFTUxTepMiSMgXU = 113;
        long DbnXOIfdBEStVEWFtownaRLKIjZHe = 58473366555653374;
        int lPssCzsnoPDEFcyYMqEpEIAZ = 77021019;
        while (lPssCzsnoPDEFcyYMqEpEIAZ == 77021019)
        {
            lPssCzsnoPDEFcyYMqEpEIAZ += 920158;
        }
        int QAiAIAjkpWKRCjkzReVbcnlEosFNh = 4170;
        while (QAiAIAjkpWKRCjkzReVbcnlEosFNh == 4170)
        {
            QAiAIAjkpWKRCjkzReVbcnlEosFNh += 761124;
        }
    }
}