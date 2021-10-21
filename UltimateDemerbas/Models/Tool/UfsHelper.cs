namespace UltimateDemerbas.Models.Tool
{
    public static class UfsHelper
    {
        public static bool IsDebugActive
        {
            get
            {
#if DEBUG
                return true;
#else
                return false;
#endif
            }
        }
    }
}