
namespace FOG.SailsSocketIOClientDotNet
{
    public class SDKInfo
    {
        public const string VersionMeta = "__sails_io_sdk_version";
        public const string PlatformMeta = "__sails_io_sdk_platform";
        public const string LanguageMeta = "__sails_io_sdk_language";

        public string Version { get; private set; }
        public string Language { get; private set; }
        public string Platform { get; private set; }

        public string VersionString => $"{VersionMeta}={Version}&{PlatformMeta}={Platform}&{LanguageMeta}={Language}";

        public SDKInfo(string version, string language, string platform)
        {
            Version = version;
            Language = language;
            Platform = platform;
        }

    }
}
