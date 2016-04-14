using System;

namespace Microsoft.Extensions.PlatformAbstractions
{
    public struct RuntimeType : IEquatable<RuntimeType>
    {
        public string Name { get; }

        public static readonly RuntimeType Unknown = new RuntimeType();
        public static readonly RuntimeType Mono = new RuntimeType("mono");
        public static readonly RuntimeType CoreCLR = new RuntimeType("coreclr");
        public static readonly RuntimeType NetFramework = new RuntimeType("netframework");

        public RuntimeType(string name)
        {
            Name = name.ToLower();
        }

        public bool Equals(RuntimeType other) => string.Equals(Name, other.Name, StringComparison.Ordinal);
        public override bool Equals(object obj) => obj is RuntimeType && Equals((RuntimeType)obj);
        public override int GetHashCode() => Name.GetHashCode();

        public static bool operator==(RuntimeType left, RuntimeType right) => Equals(left, right);
        public static bool operator!=(RuntimeType left, RuntimeType right) => !Equals(left, right);
    }
}
