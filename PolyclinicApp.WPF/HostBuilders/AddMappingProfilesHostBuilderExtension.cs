﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PolyclinicApp.Data.AutoMapper;

namespace PolyclinicApp.WPF.HostBuilders
{
    internal static class AddMappingProfilesHostBuilderExtension
    {
        public static IHostBuilder AddMappingProfiles(this IHostBuilder host)
        {
            return host.ConfigureServices(services =>
            {
                services.AddSingleton<Profile, DataMappingProfile>();
            });
        }
    }
}