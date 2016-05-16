// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Reflection;
using System.Runtime.Versioning;

namespace Microsoft.Extensions.PlatformAbstractions
{
    public class ApplicationEnvironment
    {
        private static readonly Lazy<Assembly> _entryAssembly = new Lazy<Assembly>(GetEntryAssembly);
        private static readonly Lazy<FrameworkName> _runtimeFramework = new Lazy<FrameworkName>(GetRuntimeFramework);
        private static readonly Lazy<string> _appBase = new Lazy<string>(GetApplicationBasePath);

        public string ApplicationBasePath { get; } = GetApplicationBasePath();

        public string ApplicationName { get; } = _entryAssembly.Value?.GetName().Name;

        public string ApplicationVersion { get; } = _entryAssembly.Value?.GetName().Version.ToString();

        public FrameworkName RuntimeFramework => _runtimeFramework.Value;

        private static FrameworkName GetRuntimeFramework()
        {
            string frameworkName = null;
#if NET451
            // Try the setup information
            frameworkName = AppDomain.CurrentDomain.SetupInformation.TargetFrameworkName;
#endif
            // Try the target framework attribute
            frameworkName = frameworkName ?? GetEntryAssembly()?.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName;

            return string.IsNullOrEmpty(frameworkName) ? null : new FrameworkName(frameworkName);
        }

        private static string GetApplicationBasePath()
        {
            var basePath =
#if NET451
                (string)AppDomain.CurrentDomain.GetData("APP_CONTEXT_BASE_DIRECTORY") ??
                AppDomain.CurrentDomain.BaseDirectory;
#else
                AppContext.BaseDirectory;
#endif
            return Path.GetFullPath(basePath);
        }

        private static Assembly GetEntryAssembly()
        {
#if NET451
            return Assembly.GetEntryAssembly();
#else
            // We use reflection because the API exists on almost all .NET Standard versions but is hidden
            // Technically, since it isn't in the standard, there may be a platform that does not support it,
            // but in that case we gracefully fail, returning null
            var getEntryAssemblyMethod =
                typeof(Assembly).GetMethod("GetEntryAssembly", BindingFlags.Static | BindingFlags.NonPublic) ??
                typeof(Assembly).GetMethod("GetEntryAssembly", BindingFlags.Static | BindingFlags.Public);
            return getEntryAssemblyMethod?.Invoke(obj: null, parameters: Array.Empty<object>()) as Assembly;
#endif
        }
    }
}
