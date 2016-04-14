using System;

namespace Microsoft.Extensions.PlatformAbstractions
{
    public struct Platform : IEquatable<Platform>
    {
        public string Name { get; }

        public static readonly Platform Unknown = new Platform();
        public static readonly Platform Windows = new Platform("windows");
        public static readonly Platform Linux = new Platform("linux");
        public static readonly Platform Darwin = new Platform("darwin");

        public Platform(string name)
        {
            Name = name.ToLower();
        }

        public bool Equals(Platform other) => string.Equals(Name, other.Name, StringComparison.Ordinal);
        public override bool Equals(object obj) => obj is Platform && Equals((Platform)obj);
        public override int GetHashCode() => Name.GetHashCode();

        public static bool operator==(Platform left, Platform right) => Equals(left, right);
        public static bool operator!=(Platform left, Platform right) => !Equals(left, right);
    }
}
