using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace UnitTestProject1.common
{
    public class BrowserList
    {
        public BrowserList()
        {
        }

        private static IEnumerable<BrowserType> GetBrowserFromConfig()
        {
            var path = GetProjectDirectory();
            var settings = File.ReadAllText(Path.Combine(path, "TestParams.json"));
            var config = (JObject)JsonConvert.DeserializeObject(settings);
            var seleniumSettings = config["Selenium"];
            var browsers = (JArray)seleniumSettings["Browsers"];
            var res = browsers.Select(b => (BrowserType)Enum.Parse(typeof(BrowserType), b.ToString())).ToList();
            return res;
        }

        public static string GetProjectDirectory()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            path = Path.GetDirectoryName(path);
            DirectoryInfo info = new DirectoryInfo(path);
            path = info?.Parent?.Parent?.FullName;
            return path;
        }
    }
}