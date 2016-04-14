using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.PlatformAbstractions
{
    public struct RuntimeArchitecture : IEquatable<RuntimeArchitecture>
    {
        public string Name { get; }

        public static readonly RuntimeArchitecture Unknown = new RuntimeArchitecture();
        public static readonly RuntimeArchitecture X86 = new RuntimeArchitecture("x86");
        public static readonly RuntimeArchitecture X64 = new RuntimeArchitecture("x64");
        public static readonly RuntimeArchitecture Arm = new RuntimeArchitecture("arm");

        public RuntimeArchitecture(string name)
        {
            Name = name.ToLower();
        }

        public bool Equals(RuntimeArchitecture other) => string.Equals(Name, other.Name, StringComparison.Ordinal);
        public override bool Equals(object obj) => obj is RuntimeArchitecture && Equals((RuntimeArchitecture)obj);
        public override int GetHashCode() => Name.GetHashCode();

        public static bool operator==(RuntimeArchitecture left, RuntimeArchitecture right) => Equals(left, right);
        public static bool operator!=(RuntimeArchitecture left, RuntimeArchitecture right) => !Equals(left, right);
    }
}
