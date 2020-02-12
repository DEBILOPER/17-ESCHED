using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Sched
{ 
    public enum WireType
    {
        TW, 
        THW,
        THHN
    }

    public enum ConduitType
    {
        PVC,
        EMT,
        IMC,
        RMC
    }

    public enum UnitType
    {
        None,
        DwellingUnit,
        NonDwellingUnit
    }

    public enum FileType
    {
        None,
        New,
        Open
    }

    public enum PhaseType
    {
        None,
        SinglePhase,
        ThreePhase
    }

    public enum VoltageValue
    {
        None,
        SINGLEPHASE_VOLTAGE = 230,
        THREEPHASE_VOLTAGE  = 400
    }

    public enum Three_Phase_AC_Motor
    {
        None,
        INDUCTION,
        SYNCHRONOUS
    }

    public enum BranchCircuit
    {
        LIGHTINGS,
        CONVENIENCE_OUTLET,
        RANGE,
        DRYER,
        LAUNDRY,
        ACU,
        MOTOR,
        OTHER_LOAD,
        SPARE
    }

    class Data
    {
        public static UnitType unitType   = UnitType.None;
        public static FileType fileType   = FileType.None;

        public static string Filename     = string.Empty;
        public static string Password     = string.Empty;

        public static void Reset()
        {
            unitType      = UnitType.None;
            fileType      = FileType.None;
            
            Filename      = string.Empty;
            Password      = string.Empty;
        }
    }

    class AdditionalData
    {
        string temperature = string.Empty;
        string length = string.Empty;
        string resistance = string.Empty;
        string currentCarryingConductor = string.Empty;
    }

    class CalculateMain
    {
        public bool calculated = false;

        public double largestMotor = 0d;

        public string AT = string.Empty;
        public UnitType unitType = UnitType.None;

        public string area = string.Empty;
        public double total_connected_load = 0d;
        public double total_net_load = 0d;
               
        public double LO = 0d;
        public double CO = 0d;
        public double ACU = 0d;
        public double MOTOR = 0d;
        public double RANGE = 0d;
        public double SPARE = 0d;
        public double DRYER = 0d;
        public double OTHER_LOAD = 0d;

        public double KAIC = 0d;
               
        public double conductorAmpacity = 0d;
        public double mainService = 0d;
        public string conductorSize = string.Empty;
        public string breakerSize = string.Empty;
        public string conduitSize = string.Empty;

        public BreakerType breakerType = BreakerType.NONE;
    }

    public enum OccupancyType
    {
        DwellingUnit,
        Hospitals,
        Hotels_Motels,
        Warehouses,
        Others
    }

    public enum BreakerType
    {
        NONE,
        SYNCHRONOUS,
        WOUND,
        INSTANTANEOUS_TRIP
    }
}
