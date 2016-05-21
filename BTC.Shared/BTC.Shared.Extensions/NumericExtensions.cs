namespace BTC.Shared.Extensions
{
    public static class NumericExtensions
    {
        /// <summary>
        /// Метод проверяет число на равенство нулю или null.
        /// </summary>
        /// <param name="a">Число</param>
        /// <returns>True, если число равно null или 0</returns>
        public static bool IsNullOrZero(this int? a)
        {
            return a == null || a == 0;
        }
    }
}