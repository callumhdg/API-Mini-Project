using System.Configuration;

namespace TestLayer
{
    public static class AppConfigReader
    {
        public static readonly string BaseUrl = ConfigurationManager.AppSettings["base_url"];
    }
}
