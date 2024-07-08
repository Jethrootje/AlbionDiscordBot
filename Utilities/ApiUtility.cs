using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AlbionDiscordBot.ApiResponses;
using Newtonsoft.Json;
using System.Xml.Linq;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.PixelFormats;
using System.IO;
using AlbionDiscordBot.Models;

namespace AlbionDiscordBot.Utilities
{
    public static class ApiUtility
    {
        private static async Task<string> WebRequest(string url)
        {
            using (var client = new HttpClient())
            {
                string uri = SavedConfig.Config.ApiUrl + url;
                var response = await client.GetAsync(uri);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return "{}";
                }

                return await response.Content.ReadAsStringAsync();
            }
        }

        public static async Task<Image<Rgba32>> GetRender(string url)
        {
            using (var client = new HttpClient())
            {
                string uri = SavedConfig.Config.RenderUrl + url;
                var response = await client.GetAsync(uri);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return null;
                }

                using (Stream stream = await response.Content.ReadAsStreamAsync())
                {
                    return Image.Load<Rgba32>(stream);
                }
            }
        }

        public static async Task<SearchResponse> Search(string arg)
        {
            string json = await WebRequest($"search?q={arg}");
            try
            {
                SearchResponse response = JsonConvert.DeserializeObject<SearchResponse>(json);
                return response;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error during deserialization: " + ex.Message);
            }

            return null;
        }

        public static async Task<List<EventsResponse>> GetEvents()
        {
            string json = await WebRequest($"events?limit=51");
            try
            {
                List<EventsResponse> response = JsonConvert.DeserializeObject<List<EventsResponse>>(json);
                return response;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error during deserialization: " + ex.Message);
            }

            return null;
        }

        public static async Task<Weapon> GetWeapon(string type)
        {
            if (type.Contains("@"))
            {
                type = type.Substring(0, type.IndexOf("@"));
            }

            string json = await WebRequest($"items/{type}/data");
            try
            {
                Weapon response = JsonConvert.DeserializeObject<Weapon>(json);
                return response;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error during deserialization: " + ex.Message);
            }

            return null;
        }
    }
}
