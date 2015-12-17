using Xunit;

namespace Microsoft.Extensions.PlatformAbstractions.Tests
{
    public class RuntimeEnvironmentTests
    {
        // Test RID generation
        [Theory]

        // Windows
        [InlineData("Windows", "6.1", Platform.Windows, "x86", "win7-x86")]
        [InlineData("Windows", "6.1", Platform.Windows, "x64", "win7-x64")]
        [InlineData("Windows", "6.2", Platform.Windows, "x86", "win8-x86")]
        [InlineData("Windows", "6.2", Platform.Windows, "x64", "win8-x64")]
        [InlineData("Windows", "6.3", Platform.Windows, "x86", "win81-x86")]
        [InlineData("Windows", "6.3", Platform.Windows, "x64", "win81-x64")]
        [InlineData("Windows", "10.0", Platform.Windows, "x86", "win10-x86")]
        [InlineData("Windows", "10.0", Platform.Windows, "x64", "win10-x64")]
        [InlineData("Windows", "10.0", Platform.Windows, "arm", "win10-arm")]

        // Generic Linux
        [InlineData("Linux", null, Platform.Linux, "x86", "linux-x86")]
        [InlineData("Linux", null, Platform.Linux, "x64", "linux-x64")]
        [InlineData("Linux", null, Platform.Linux, "arm", "linux-arm")]
        [InlineData("Linux", "", Platform.Linux, "x86", "linux-x86")]
        [InlineData("Linux", "", Platform.Linux, "x64", "linux-x64")]
        [InlineData("Linux", "", Platform.Linux, "arm", "linux-arm")]

        // Linux Distros
        [InlineData("Ubuntu", "14.04", Platform.Linux, "x86", "ubuntu.14.04-x86")]
        [InlineData("Ubuntu", "14.04", Platform.Linux, "x64", "ubuntu.14.04-x64")]
        [InlineData("Ubuntu", "14.04", Platform.Linux, "arm", "ubuntu.14.04-arm")]
        [InlineData("LinuxMint", "17.2", Platform.Linux, "x86", "linuxmint.17.2-x86")]
        [InlineData("LinuxMint", "17.2", Platform.Linux, "x64", "linuxmint.17.2-x64")]
        [InlineData("LinuxMint", "17.2", Platform.Linux, "arm", "linuxmint.17.2-arm")]
        [InlineData("CentOS", "7", Platform.Linux, "x86", "centos.7-x86")]
        [InlineData("CentOS", "7", Platform.Linux, "x64", "centos.7-x64")]
        [InlineData("CentOS", "7", Platform.Linux, "arm", "centos.7-arm")]

        // Mac OS X
        [InlineData("Darwin", null, Platform.Darwin, "x86", "osx-x86")]
        [InlineData("Darwin", null, Platform.Darwin, "x64", "osx-x64")]
        [InlineData("Darwin", null, Platform.Darwin, "arm", "osx-arm")]
        [InlineData("Darwin", "", Platform.Darwin, "x86", "osx-x86")]
        [InlineData("Darwin", "", Platform.Darwin, "x64", "osx-x64")]
        [InlineData("Darwin", "", Platform.Darwin, "arm", "osx-arm")]
        [InlineData("Darwin", "10.10", Platform.Darwin, "x86", "osx.10.10-x86")]
        [InlineData("Darwin", "10.10", Platform.Darwin, "x64", "osx.10.10-x64")]
        [InlineData("Darwin", "10.10", Platform.Darwin, "arm", "osx.10.10-arm")]
        public void RuntimeIdIsGeneratedCorrectly(string osName, string version, Platform platform, string architecture, string expectedRid)
        {
            var runtimeEnv = new TestRuntimeEnvironment()
            {
                OperatingSystem = osName,
                OperatingSystemVersion = version,
                OperatingSystemPlatform = platform,
                RuntimeArchitecture = architecture
            };
            Assert.Equal(expectedRid, runtimeEnv.GetRuntimeIdentifier());
        }
    }
}
