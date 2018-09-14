using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace SpecFlowTask
{
    public class Settings
    {
        [JsonProperty("Login")]
        public static string Login { get; set; }

        [JsonProperty("Passwd")]
        public static string Passwd { get; set; }

        [JsonProperty("SiteUrl")]
        public static string SiteUrl { get; set; }

        [JsonProperty("Browser")]
        public static string Browser { get; set; }

        [JsonProperty("Settings")]
        public Settings Test { get; set; }

        public void SettingManager()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string json = File.ReadAllText($"{path}\\settings.json");
            var settings = JsonConvert.DeserializeObject<Settings>(json);
            
        }

    }
}
