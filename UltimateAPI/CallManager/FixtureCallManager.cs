using System.Collections.Generic;
using System.Linq;
using UltimateAPI.Entities;
using UltimateAPI.Manager;

namespace UltimateAPI.CallManager
{
    public class FixtureCallManager
    {
        private static readonly object Lock = new object();
        private static volatile FixtureCallManager _instance;
        public static FixtureCallManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new FixtureCallManager();
                        }
                    }
                }
                return _instance;
            }

        }


        public UltimateResult<List<Fixture>> GetFixtures()
        {
            return FixtureManager.Instance.GetFixtures();
        }
        public UltimateResult<Fixture> GetFixture(Fixture parameter)
        {
            UltimateResult<Fixture> result = FixtureManager.Instance.GetFixture(parameter);

            if (result.IsSuccess)
            {
                if (result.Data.BillNo > 0)
                {
                    BillCallManager billCallManager = new BillCallManager();
                    result.Data.Bill = billCallManager.GetBills().Data.Find(x => x.Id == result.Data.BillNo);
                }

                CategoryCallManager categoryCallManager = new CategoryCallManager();
                result.Data.Category = categoryCallManager.GetCategories().Data.Find(x => x.Id == result.Data.CategoryNo);

                FixtureModelCallManager fixtureModelCallManager = new FixtureModelCallManager();
                result.Data.Model = fixtureModelCallManager.GetFixtureModels().Data.Find(x => x.Id == result.Data.ModelNo);
            }

            return result;
        }

        public UltimateResult<List<Fixture>> GetFixtureByUser(Fixture parameter)
        {
            return FixtureManager.Instance.GetFixtureByUser(parameter);
        }

        public UltimateResult<List<Fixture>> DeleteFixture(Fixture parameter)
        {
            return FixtureManager.Instance.DeleteFixture(parameter);
        }

        public UltimateResult<List<Fixture>> AddFixture(Fixture parameter)
        {
            return FixtureManager.Instance.AddFixture(parameter);
        }
        public UltimateResult<List<Fixture>> UpdateFixture(Fixture parameter)
        {
            return FixtureManager.Instance.UpdateFixture(parameter);
        }
    }
}
