using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using UltimateAPI.Entities;
using UltimateAPI.Entities.Enums;
using UltimateDemerbas.Models;

namespace UltimateAPI.Manager
{
    public class EnumManager : BaseManager
    {
        private static readonly object Lock = new object();
        private static volatile EnumManager _instance;
        public static EnumManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new EnumManager();
                        }
                    }
                }
                return _instance;
            }

        }


        public UltimateResult<List<TextValue>> GetIsActiveTypes()
        {
            UltimateResult<List<TextValue>> result = new UltimateResult<List<TextValue>>();
            List<TextValue> typeList = new List<TextValue>();

            try
            {
                List<IsActive> datas = Enum.GetValues(typeof(IsActive)).Cast<IsActive>().ToList();
                foreach (IsActive logType in datas)
                {
                    typeList.Add(new TextValue { Text = EnumHelper.GetEnumDescription<IsActive>(logType.ToString()), Value = (int)logType });
                }

                result.Data = typeList;
            }
            catch (Exception ex)
            {
                Error(ex);
                result.Message = ex.ToString();
                result.IsSuccess = false;
                return result;
            }

            return result;
        }

        public UltimateResult<List<TextValue>> GetItemStatuTypes()
        {
            UltimateResult<List<TextValue>> result = new UltimateResult<List<TextValue>>();
            List<TextValue> typeList = new List<TextValue>();

            try
            {
                List<ItemStatu> datas = Enum.GetValues(typeof(ItemStatu)).Cast<ItemStatu>().ToList();
                foreach (ItemStatu logType in datas)
                {
                    typeList.Add(new TextValue { Text = EnumHelper.GetEnumDescription<ItemStatu>(logType.ToString()), Value = (int)logType });
                }

                result.Data = typeList;
            }
            catch (Exception ex)
            {
                Error(ex);
                result.Message = ex.ToString();
                result.IsSuccess = false;
                return result;
            }

            return result;
        }

        public UltimateResult<List<TextValue>> GetItemTypeTypes()
        {
            UltimateResult<List<TextValue>> result = new UltimateResult<List<TextValue>>();
            List<TextValue> typeList = new List<TextValue>();

            try
            {
                List<ItemType> datas = Enum.GetValues(typeof(ItemType)).Cast<ItemType>().ToList();
                foreach (ItemType logType in datas)
                {
                    typeList.Add(new TextValue { Text = EnumHelper.GetEnumDescription<ItemType>(logType.ToString()), Value = (int)logType });
                }

                result.Data = typeList;
            }
            catch (Exception ex)
            {
                Error(ex);
                result.Message = ex.ToString();
                result.IsSuccess = false;
                return result;
            }

            return result;
        }

        public UltimateResult<List<TextValue>> GetReportStatus()
        {
            UltimateResult<List<TextValue>> result = new UltimateResult<List<TextValue>>();
            List<TextValue> typeList = new List<TextValue>();

            try
            {
                List<ReportStatu> datas = Enum.GetValues(typeof(ReportStatu)).Cast<ReportStatu>().ToList();
                foreach (ReportStatu logType in datas)
                {
                    typeList.Add(new TextValue { Text = EnumHelper.GetEnumDescription<ReportStatu>(logType.ToString()), Value = (int)logType });
                }

                result.Data = typeList;
            }
            catch (Exception ex)
            {
                Error(ex);
                result.Message = ex.ToString();
                result.IsSuccess = false;
                return result;
            }

            return result;
        }
        
        public UltimateResult<List<TextValue>> GetProductTypes()
        {
            UltimateResult<List<TextValue>> result = new UltimateResult<List<TextValue>>();
            List<TextValue> typeList = new List<TextValue>();

            try
            {
                List<ProductType> datas = Enum.GetValues(typeof(ProductType)).Cast<ProductType>().ToList();
                foreach (ProductType logType in datas)
                {
                    typeList.Add(new TextValue { Text = EnumHelper.GetEnumDescription<ProductType>(logType.ToString()), Value = (int)logType });
                }

                result.Data = typeList;
            }
            catch (Exception ex)
            {
                Error(ex);
                result.Message = ex.ToString();
                result.IsSuccess = false;
                return result;
            }

            return result;
        }

        public UltimateResult<List<TextValue>> GetDepartments()
        {
            UltimateResult<List<TextValue>> result = new UltimateResult<List<TextValue>>();
            List<TextValue> typeList = new List<TextValue>();

            try
            {
                List<Departments> datas = Enum.GetValues(typeof(Departments)).Cast<Departments>().ToList();
                foreach (Departments logType in datas)
                {
                    typeList.Add(new TextValue { Text = EnumHelper.GetEnumDescription<Departments>(logType.ToString()), Value = (int)logType });
                }

                result.Data = typeList;
            }
            catch (Exception ex)
            {
                Error(ex);
                result.Message = ex.ToString();
                result.IsSuccess = false;
                return result;
            }

            return result;
        }
        
        public UltimateResult<List<TextValue>> GetGenders()
        {
            UltimateResult<List<TextValue>> result = new UltimateResult<List<TextValue>>();
            List<TextValue> typeList = new List<TextValue>();

            try
            {
                List<Gender> datas = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
                foreach (Gender logType in datas)
                {
                    typeList.Add(new TextValue { Text = EnumHelper.GetEnumDescription<Gender>(logType.ToString()), Value = (int)logType });
                }

                result.Data = typeList;
            }
            catch (Exception ex)
            {
                Error(ex);
                result.Message = ex.ToString();
                result.IsSuccess = false;
                return result;
            }

            return result;
        }

        public UltimateResult<List<TextValue>> GetImportanceLevels()
        {
            UltimateResult<List<TextValue>> result = new UltimateResult<List<TextValue>>();
            List<TextValue> typeList = new List<TextValue>();

            try
            {
                List<ImportanceLevel> datas = Enum.GetValues(typeof(ImportanceLevel)).Cast<ImportanceLevel>().ToList();
                foreach (ImportanceLevel logType in datas)
                {
                    typeList.Add(new TextValue { Text = EnumHelper.GetEnumDescription<ImportanceLevel>(logType.ToString()), Value = (int)logType });
                }

                result.Data = typeList;
            }
            catch (Exception ex)
            {
                Error(ex);
                result.Message = ex.ToString();
                result.IsSuccess = false;
                return result;
            }

            return result;
        }

        public UltimateResult<List<TextValue>> GetTaskActiveStatus()
        {
            UltimateResult<List<TextValue>> result = new UltimateResult<List<TextValue>>();
            List<TextValue> typeList = new List<TextValue>();

            try
            {
                List<ActiveStatu> datas = Enum.GetValues(typeof(ActiveStatu)).Cast<ActiveStatu>().ToList();
                foreach (ActiveStatu logType in datas)
                {
                    typeList.Add(new TextValue { Text = EnumHelper.GetEnumDescription<ActiveStatu>(logType.ToString()), Value = (int)logType });
                }

                result.Data = typeList;
            }
            catch (Exception ex)
            {
                Error(ex);
                result.Message = ex.ToString();
                result.IsSuccess = false;
                return result;
            }

            return result;
        }

    }
}
