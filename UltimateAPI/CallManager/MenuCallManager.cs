using System.Collections.Generic;
using UltimateAPI.Entities;
using UltimateAPI.Manager;

namespace UltimateAPI.CallManager
{
    public class MenuCallManager
    {
        private static readonly object Lock = new object();
        private static volatile MenuCallManager _instance;
        public static MenuCallManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new MenuCallManager();
                        }
                    }
                }
                return _instance;
            }
        }


        public UltimateResult<List<Menu>> GetMenu()
        {
            UltimateResult<List<Menu>> result = MenuManager.Instance.GetMenus();

            if (result.Data != null)
            {

                foreach (Menu menuItem in result.Data.ToArray())
                {
                    if (menuItem.Dependency > 0)
                    {
                        Menu mainMenu = result.Data.Find(x => x.Id == menuItem.Dependency);
                        if (mainMenu != null)
                        {
                            if (mainMenu.Children == null)
                                mainMenu.Children = new List<Menu>();

                            mainMenu.Children.Add(menuItem);
                            result.Data.Remove(menuItem);
                        }
                    }

                }

            }


            return result;
        }

        public UltimateResult<List<Menu>> DeleteMenu(Menu parameter)
        {
            return MenuManager.Instance.DeleteMenu(parameter);
        }

        public UltimateResult<List<Menu>> AddMenu(Menu parameter)
        {
            return MenuManager.Instance.AddMenu(parameter);
        }

        public UltimateResult<List<Menu>> UpdateMenu(Menu parameter)
        {
            return MenuManager.Instance.UpdateMenu(parameter);
        }


    }
}
