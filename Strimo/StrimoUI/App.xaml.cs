using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace StrimoUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDI2ODY1QDMxMzgyZTM0MmUzMG5GOHNDNmFjblZrUUR5QS96TlgzZ1lzVEx5eTlpdlZiSi8va0lXejhLTnM9");

        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDI2ODY1QDMxMzgyZTM0MmUzMG5GOHNDNmFjblZrUUR5QS96TlgzZ1lzVEx5eTlpdlZiSi8va0lXejhLTnM9");
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDI2ODY4QDMxMzkyZTMxMmUzMEYyaU44UldjRU0wM0RHdk1zbzV1YUc3MDFmN1hrSlVOWnJ3NVEwL2FjaGM9");
        }
    }
}
