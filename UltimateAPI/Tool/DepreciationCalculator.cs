using System;
using System.Collections.Generic;
using UltimateAPI.Entities;

namespace UltimateAPI.Tool
{
    public class DepreciationCalculator
    {
        private static readonly object Lock = new object();
        private static volatile DepreciationCalculator _instance;
        public static DepreciationCalculator Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new DepreciationCalculator();
                        }
                    }
                }
                return _instance;
            }
        }


        //Sabit Yıllık Tutar Yöntemi
        public UltimateResult<List<FixedAnnualAmountResult>> FixedAnnualAmount(FixedAnnualAmountModel parameter)
        {
            UltimateResult<List<FixedAnnualAmountResult>> result = new UltimateResult<List<FixedAnnualAmountResult>>();
            double activeValue = parameter.Cost;
            for (int year = 1; year <= parameter.EconomicSpine; year++)
            {
                double depreciationExpense = parameter.FixedAnnualAmount;
                double newActiveValue = activeValue - depreciationExpense;

                activeValue = newActiveValue;

                FixedAnnualAmountResult fixedAnnualAmountResult = new FixedAnnualAmountResult();
                fixedAnnualAmountResult.Year = year;
                fixedAnnualAmountResult.NewActiveValue = newActiveValue;
                fixedAnnualAmountResult.DepreciationExpense = depreciationExpense;
                result.Data.Add(fixedAnnualAmountResult);
            }

            return result;
        }


        //Azalan Bakiye Yöntemi
        public UltimateResult<DecreasingBalanceResult> DecreasingBalance(DecreasingBalanceModel parameter)
        {
            UltimateResult<DecreasingBalanceResult> result = new UltimateResult<DecreasingBalanceResult>();
            decimal balance = parameter.ValueReceived - parameter.Scrapvalue;
            decimal totaldepreciation = 0;

            for (int i = 1; i <= parameter.NumberOfLastMonth; i++)
            {
                decimal monthlyDepreciation = balance * parameter.MonthlyDepreciationRate;
                balance -= monthlyDepreciation;
                totaldepreciation += monthlyDepreciation;
            }

            result.Data.TotalDepreciation = totaldepreciation;
            return result;
        }


        //Üretim Miktarına Göre Amortisman Yöntemi
        public UltimateResult<DepreciationByProductionAmountResult> DepreciationByProductionAmount(DepreciationByProductionAmountModel parameter)
        {
            UltimateResult<DepreciationByProductionAmountResult> result = new UltimateResult<DepreciationByProductionAmountResult>();
            decimal totalProduction = parameter.ProductionCapacity * parameter.LifeSpanInYears;
            decimal productionRate = parameter.ProductionAmount / totalProduction;
            decimal annualDepreciation = (parameter.AssetCost - parameter.SalvageValue) * productionRate;
            
            result.Data.AnnualDepreciation = annualDepreciation;
            return result;
        }


    }
}
