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
        public List<FixedAnnualAmountResult> FixedAnnualAmount(FixedAnnualAmountModel parameter)
        {
            List<FixedAnnualAmountResult> result = new List<FixedAnnualAmountResult>();
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
                result.Add(fixedAnnualAmountResult);
            }

            return result;
        }






        
        //Azalan Bakiye Yöntemi
        public List<DecreasingBalanceResult> DecreasingBalance(DecreasingBalanceModel parameter)
        {
         
        }



        public class AmortismanHesabi
        {
            public decimal AlinanDeger { get; set; } // Satın alınan değer
            public decimal HurdaDegeri { get; set; } // Hurda değeri
            public decimal Omur { get; set; } // Amortisman ömrü
            public decimal AylikAmortismanOrani { get; set; } // Aylık amortisman oranı

            public AmortismanHesabi(decimal alinanDeger, decimal hurdaDegeri, decimal omur)
            {
                AlinanDeger = alinanDeger;
                HurdaDegeri = hurdaDegeri;
                Omur = omur;
                AylikAmortismanOrani = 1m / (12m * omur); // Aylık amortisman oranı hesaplama
            }

            public decimal AmortismanHesapla(int gecenAySayisi)
            {
                decimal bakiye = AlinanDeger - HurdaDegeri;
                decimal amortismanToplami = 0;

                for (int i = 1; i <= gecenAySayisi; i++)
                {
                    decimal aylikAmortisman = bakiye * AylikAmortismanOrani;
                    bakiye -= aylikAmortisman;
                    amortismanToplami += aylikAmortisman;
                }

                return amortismanToplami;
            }
        }









    }
}
