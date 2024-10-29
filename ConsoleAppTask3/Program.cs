class Converter
{
    private decimal USD;
    private decimal EUR;

    public Converter(decimal usd, decimal eur)
    {
        usd = USD;
        eur = EUR;
    }

    public decimal Convert(decimal amount, string fromCurrency, string toCurrency)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Сума від'ємна!");
        }

        fromCurrency = fromCurrency.ToUpper().Trim();
        toCurrency = toCurrency.ToUpper().Trim();

        if (fromCurrency == "UAH" && toCurrency == "USD")
        {
            return amount / USD;
        }
        else if (fromCurrency == "UAH" && toCurrency == "EUR")
        {
            return amount / EUR;
        }
        else if (fromCurrency == "USD" && toCurrency == "UAH")
        {
            return amount * USD;
        }
        else if (fromCurrency == "EUR" && toCurrency == "UAH")
        {
            return amount * EUR;
        }
        else if (fromCurrency == toCurrency)
        {
            return amount;
        }
        else
        {
            throw new ArgumentException("Неправильно написані валюти.");
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Converter converter = new Converter(41.24M, 45.13M);

            Console.WriteLine("Введіть назву валюти яку хочете конвертувати (UAH, USD, EUR): ");
            string fromCurrency = Console.ReadLine().ToUpper().Trim();

            Console.Write($"Введіть суму в {fromCurrency}: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Введіть назву валюти, в яку хочете конвертувати попередню валюту (UAH, USD, EUR): ");
            string toCurrency = Console.ReadLine().ToUpper().Trim();

            decimal result = converter.Convert(amount, fromCurrency, toCurrency);

            Console.WriteLine($"Результат конвертації: {result} {toCurrency}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Помилка: неправильний формат введених даних.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
