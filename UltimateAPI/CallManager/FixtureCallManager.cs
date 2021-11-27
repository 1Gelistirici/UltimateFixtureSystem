using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public UltimateResult<List<Fixture>> GetFixture(Fixture parameter)
        {
            return FixtureManager.Instance.GetFixture(parameter);
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
