namespace System
{
    public static class Converter
    {
        public static float ToTwoPlaces(this double number)
        {
            if (number <= 0)
                return 0;

            var fator = (decimal)Math.Pow(10d, 2);
            var valorTruncado = Math.Floor((decimal)number * fator);

            return (float)(Math.Floor((Math.Round(valorTruncado, 2))) / fator);
        }
    }
}
