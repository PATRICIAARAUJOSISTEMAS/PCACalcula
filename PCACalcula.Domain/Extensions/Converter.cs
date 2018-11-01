namespace System
{
    public static class Converter
    {
        public static float ToTwoPlaces(this float number)
        {
            if (number <= 0)
                return 0;

           return Convert.ToSingle(String.Format("{0:00.0}", number));
        }
    }
}
