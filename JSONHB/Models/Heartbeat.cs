using System;

namespace JSONHB
{
    public static class Heartbeat
    {
        public static string UAVSerial { get; set; }
        public static string SecretKey { get; set; }
        public static int Count { get; set; }
        public static int FlightID { get; set; }
        public static int Status { get; set; }
        public static int RSSI { get; set; }
        public static double Latitude { get; set; }
        public static double Longitude { get; set; }
        public static double Alt_ASL { get; set; }
        public static double Alt_AGL { get; set; }
        public static double Yaw { get; set; }
        public static double Pitch { get; set; }
        public static double Roll { get; set; }
        public static double Bearing { get; set; }
        public static double Speed { get; set; }
        public static double Bat1 { get; set; }
        public static double Bat2 { get; set; }
        public static double Sensor1 { get; set; }
        public static double Sensor2 { get; set; }
        public static double Sensor3 { get; set; }
        public static double Sensor4 { get; set; }
        public static double Sensor5 { get; set; }
    }
}