//using System;
//using System.Net;
//using System.Collections.Generic;
//using Newtonsoft.Json;
////
//namespace JSONHB
//{
//    public partial class Heartbeat
//    {
//        [JsonProperty("Altitude")]
//        public Altitude Altitude { get; set; }

//        [JsonProperty("Attitude")]
//        public Attitude Attitude { get; set; }

//        [JsonProperty("Batteries")]
//        public BatteryArray[] Batteries { get; set; }

//        [JsonProperty("Count")]
//        public long Count { get; set; }

//        [JsonProperty("CurrentSensors")]
//        public CurrentSensor[] CurrentSensors { get; set; }

//        [JsonProperty("Docked")]
//        public long Docked { get; set; }

//        [JsonProperty("GPSLocation")]
//        public GPSLocation GPSLocation { get; set; }

//        [JsonProperty("RSSI")]
//        public long RSSI { get; set; }

//        [JsonProperty("SecretKey")]
//        public string SecretKey { get; set; }

//        [JsonProperty("SightLine")]
//        public long SightLine { get; set; }

//        [JsonProperty("Status")]
//        public long Status { get; set; }

//        [JsonProperty("TemperatureSensors")]
//        public TemperatureSensor[] TemperatureSensors { get; set; }

//        [JsonProperty("UAVSerial")]
//        public string UAVSerial { get; set; }
//    }

//    public partial class TemperatureSensor
//    {
//        [JsonProperty("Sensor")]
//        public long Sensor { get; set; }

//        [JsonProperty("Temperature")]
//        public double Temperature { get; set; }
//    }

//    public partial class GPSLocation
//    {
//        [JsonProperty("Latitude")]
//        public double Latitude { get; set; }

//        [JsonProperty("Longitude")]
//        public double Longitude { get; set; }
//    }

//    public partial class CurrentSensor
//    {
//        [JsonProperty("Current")]
//        public double Current { get; set; }

//        [JsonProperty("Sensor")]
//        public long Sensor { get; set; }
//    }

//    public partial class BatteryArray
//    {
//        [JsonProperty("APReading")]
//        public double APReading { get; set; }

//        [JsonProperty("Batteries")]
//        public BatteryB[] Batteries { get; set; }

//        [JsonProperty("Type")]
//        public string Type { get; set; }
//    }

//    public partial class BatteryB
//    {
//        [JsonProperty("Battery")]
//        public long Battery { get; set; }

//        [JsonProperty("Cells")]
//        public double[] Cells { get; set; }
//    }

//    public partial class Attitude
//    {
//        [JsonProperty("Bearing")]
//        public double Bearing { get; set; }

//        [JsonProperty("Pitch")]
//        public double Pitch { get; set; }

//        [JsonProperty("Roll")]
//        public double Roll { get; set; }

//        [JsonProperty("Speed")]
//        public long Speed { get; set; }

//        [JsonProperty("Yaw")]
//        public double Yaw { get; set; }
//    }

//    public partial class Altitude
//    {
//        [JsonProperty("AboveGL")]
//        public long AboveGL { get; set; }

//        [JsonProperty("AboveSL")]
//        public long AboveSL { get; set; }
//    }

//}
