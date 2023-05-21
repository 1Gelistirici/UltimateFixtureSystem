using System.Collections.Generic;
using UltimateAPI.Entities;
using UltimateAPI.Manager;

namespace UltimateAPI.CallManager
{
    public class LicenseTypesCallManager
    {
        public UltimateResult<List<LicensesType>> GetLicensesTypes()
        {
            return LicenseTypesManager.Instance.GetLicensesTypes();
        }

        public UltimateResult<List<LicensesType>> GetLicensesType(LicensesType parameter)
        {
            return LicenseTypesManager.Instance.GetLicensesType(parameter);
        }

        public UltimateResult<List<LicensesType>> GetLicenseTypeByCompanyRefId(ReferansParameter parameter)
        {
            return LicenseTypesManager.Instance.GetLicenseTypeByCompanyRefId(parameter);
        }

        public UltimateResult<List<LicensesType>> DeleteLicensesType(LicensesType parameter)
        {
            return LicenseTypesManager.Instance.DeleteLicensesType(parameter);
        }

        public UltimateResult<List<LicensesType>> AddLicensesType(LicensesType parameter)
        {
            return LicenseTypesManager.Instance.AddLicensesType(parameter);
        }

        public UltimateResult<List<LicensesType>> UpdateLicenseType(LicensesType parameter)
        {
            return LicenseTypesManager.Instance.UpdateLicenseType(parameter);
        }









    }
}
