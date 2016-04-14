// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.Extensions.PlatformAbstractions.Native;

namespace Microsoft.Extensions.PlatformAbstractions
{
    public class DefaultRuntimeEnvironment : IRuntimeEnvironment
    {
        public DefaultRuntimeEnvironment()
        {
            OperatingSystem = PlatformApis.GetOSName();
            OperatingSystemVersion = PlatformApis.GetOSVersion();
            OperatingSystemPlatform = PlatformApis.GetOSPlatform();

            RuntimeType = GetRuntimeType();
            RuntimeVersion = typeof(object).GetTypeInfo().Assembly.GetName().Version.ToString();
            RuntimeArchitecture = GetArch();
        }

        public Platform OperatingSystemPlatform { get; }

        public string OperatingSystemVersion { get; }

        public string OperatingSystem { get; }

        public RuntimeArchitecture RuntimeArchitecture { get; }

        public RuntimeType RuntimeType { get; }

        public string RuntimeVersion { get; }

#if NET451
        private RuntimeType GetRuntimeType() => Type.GetType("Mono.Runtime") != null ? RuntimeType.Mono : RuntimeType.NetFramework;
#else
        private RuntimeType GetRuntimeType() => RuntimeType.CoreCLR;
#endif

#if NET451
        private static RuntimeArchitecture GetArch() => Environment.Is64BitProcess ? RuntimeArchitecture.X64 : RuntimeArchitecture.X86;
#else
        private static RuntimeArchitecture GetArch()
        {
            switch (RuntimeInformation.ProcessArchitecture)
            {
                case Architecture.X86: return RuntimeArchitecture.X86;
                case Architecture.X64: return RuntimeArchitecture.X64;
                case Architecture.Arm: return RuntimeArchitecture.Arm;
                default: return RuntimeArchitecture.Unknown;
            }
        }
#endif

    }
}
