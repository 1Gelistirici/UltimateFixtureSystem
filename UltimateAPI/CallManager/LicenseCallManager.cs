using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UltimateAPI.Entities;
using UltimateAPI.Manager;

namespace UltimateAPI.CallManager
{
    public class LicenseCallManager
    {
        public UltimateResult<List<License>> GetLicenses()
        {
            return LicenseManager.Instance.GetLicenses();
        }

        public UltimateResult<List<License>> DeleteLicense(License parameter)
        {
            return LicenseManager.Instance.DeleteLicense(parameter);
        }

        public UltimateResult<List<License>> AddLicense(License parameter)
        {
            return LicenseManager.Instance.AddLicense(parameter);
        }

        public UltimateResult<List<License>> UpdateLicense(License parameter)
        {
            return LicenseManager.Instance.UpdateLicense(parameter);
        }

    }
}
