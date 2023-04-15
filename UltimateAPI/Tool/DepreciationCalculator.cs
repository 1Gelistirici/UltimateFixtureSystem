﻿using System;
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
            //Sabit Yıllık Tutar = (Varlığın maliyeti - Tahmini geri kazanılabilir değer) / Tahmini Ömrü


            List<FixedAnnualAmountResult> datas = new List<FixedAnnualAmountResult>();
            UltimateResult<List<FixedAnnualAmountResult>> result = new UltimateResult<List<FixedAnnualAmountResult>>();
            double activeValue = parameter.Cost;
            for (int year = 1; year <= parameter.EconomicSpine; year++)
            {
                double depreciationExpense = parameter.FixedAnnualAmount;
                double newActiveValue = activeValue - depreciationExpense;

                activeValue = newActiveValue;

                FixedAnnualAmountResult data = new FixedAnnualAmountResult();
                data.Year = year;//Tahmini Ömrü
                data.NewActiveValue = newActiveValue;//
                data.DepreciationExpense = depreciationExpense;//
                datas.Add(data);
            }

            result.Data = datas;
            return result;
        }


        //Azalan Bakiye Yöntemi
        public UltimateResult<DecreasingBalanceResult> DecreasingBalance(DecreasingBalanceModel parameter)
        {
            DecreasingBalanceResult data = new DecreasingBalanceResult();
            UltimateResult<DecreasingBalanceResult> result = new UltimateResult<DecreasingBalanceResult>();
            decimal balance = parameter.ValueReceived - parameter.Scrapvalue;
            decimal totaldepreciation = 0;

            for (int i = 1; i <= parameter.NumberOfLastMonth; i++)
            {
                decimal monthlyDepreciation = balance * parameter.MonthlyDepreciationRate;
                balance -= monthlyDepreciation;
                totaldepreciation += monthlyDepreciation;
            }

            data.TotalDepreciation = totaldepreciation;
            result.Data = data;
            return result;
        }

        //Azalan Bakiye Yöntemi
        public UltimateResult<List<DecreasingBalanceV1Result>> DecreasingBalanceV1(DecreasingBalanceV1Model parameter)
        {
            DecreasingBalanceV1Result data = new DecreasingBalanceV1Result();
            UltimateResult<List<DecreasingBalanceV1Result>> result = new UltimateResult<List<DecreasingBalanceV1Result>>();
            result.Data = new List<DecreasingBalanceV1Result>();

            //parameter.Cost
            //parameter.EconmicLife
            //100 / 5 x 2 = 40 TL
            //(100-40) / 5 x 2= 24 TL

            data.TotalDepreciation = parameter.Cost / parameter.EconmicLife * 2;
            result.Data.Add(data);

            for (int i = 1; i < parameter.EconmicLife; i++)
            {
                data.TotalDepreciation = result.Data[result.Data.Count - 1].TotalDepreciation / parameter.EconmicLife * 2;
                result.Data.Add(data);
            }

            return result;
        }


        //Üretim Miktarına Göre Amortisman Yöntemi
        public UltimateResult<DepreciationByProductionAmountResult> DepreciationByProductionAmount(DepreciationByProductionAmountModel parameter)
        {
            //Amortisman gideri = (Varlık maliyeti - Tahmini satış değeri) / Tahmini üretim miktarı



            UltimateResult<DepreciationByProductionAmountResult> result = new UltimateResult<DepreciationByProductionAmountResult>();
            DepreciationByProductionAmountResult data = new DepreciationByProductionAmountResult();

            decimal totalProduction = parameter.ProductionCapacity * parameter.LifeSpanInYears;
            decimal productionRate = parameter.ProductionAmount / totalProduction;
            decimal annualDepreciation = (parameter.AssetCost - parameter.SalvageValue) * productionRate;

            data.AnnualDepreciation = annualDepreciation;
            result.Data = data;
            return result;
        }


    }
}
