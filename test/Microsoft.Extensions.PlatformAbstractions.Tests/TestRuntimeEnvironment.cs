namespace Microsoft.Extensions.PlatformAbstractions.Tests
{
    public class TestRuntimeEnvironment : IRuntimeEnvironment
    {
        public string OperatingSystem { get; set; }
        public Platform OperatingSystemPlatform { get; set; }
        public string OperatingSystemVersion { get; set; }
        public string RuntimeArchitecture { get; set; }
        public string RuntimePath { get; set; }
        public string RuntimeType { get; set; }
        public string RuntimeVersion { get; set; }
    }
}
