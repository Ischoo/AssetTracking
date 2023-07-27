
using AssetTracking;

List<Asset> products = new List<Asset>();


while (true)
{
    // starting point, ask if user wants to add an asset
    Console.WriteLine("Press 'A' to add new asset");
    string input = Console.ReadLine();
    if (input.ToLower().Trim() == "a")
    {
        addAsset();
    }
}


// method to add asset and its information
void addAsset()
{
    int i = 0;
    Console.WriteLine("Add asset information:");
    string input;
    int type;
    string brand;
    string model;
    int price;
    DateTime date;
    while (i < 5)
    {
        input = "";
        switch (i)
        {
            case 0:
                Console.Write("".PadRight(10) + "Asset type: Phone (1) or Computer (2) ");
                input = Console.ReadLine();
                try
                {
                    type = int.Parse(input);
                    if(type < 1 || type > 2)
                    {
                        try
                        {
                            throw new ArgumentOutOfRangeException("Please pick a valid option");

                        } catch (Exception e) { Console.WriteLine(e.Message); }
                    }
                    else
                    {
                        i++;
                    }
                } catch (FormatException) 
                {
                    Console.WriteLine("Input needs to be a number");
                }
                break;
            case 1:
                Console.Write("".PadRight(10) + "Enter brand name: ");
                input = Console.ReadLine();
                if(String.IsNullOrEmpty(input))
                {
                    try
                    {
                        throw new FormatException("Brand name can't be empty");
                    } catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    brand = input;
                    i++;
                }
                break;
            case 2:
                Console.Write("".PadRight(10) + "Enter model name: ");
                input = Console.ReadLine();
                if (String.IsNullOrEmpty(input))
                {
                    try
                    {
                        throw new FormatException("Model name can't be empty");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    model = input;
                    i++;
                }
                break;
            case 3:
                Console.Write("".PadRight(10) + "Enter asset price in dollars: ");
                input= Console.ReadLine();
                try
                {
                    price = int.Parse(input);
                    if (price < 0)
                    {
                        try
                        {
                            throw new ArgumentOutOfRangeException("Price can't be negative");

                        }
                        catch (Exception e) { Console.WriteLine(e.Message); }
                    }
                    else
                    {
                        i++;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Input needs to be a number");
                }
                break;
            case 4:
                Console.WriteLine("".PadRight(10) + "Enter purchase date: ");
                date = getDate();
                i++;
                break;
            default: break;

        }
    }

}

DateTime getDate()
{
    int j = 0;
    int y = 0, m = 0, d = 0;

    while (j < 3)
    {
        switch(j)
        {
            case 0:
                Console.Write("".PadRight(20) + "Year: ");
                try
                {
                    y = int.Parse(Console.ReadLine());
                    j++;
                } catch (FormatException) { Console.WriteLine("Input needs to be a number"); }
                break;
            case 1:
                Console.Write("".PadRight(20) + "Month: ");
                try
                {
                    m = int.Parse(Console.ReadLine());
                    j++;
                }
                catch (FormatException) { Console.WriteLine("Input needs to be a number"); }
                break;
            case 2:
                Console.Write("".PadRight(20) + "Day: ");
                try
                {
                    d = int.Parse(Console.ReadLine());
                    j++;
                }
                catch (FormatException) { Console.WriteLine("Input needs to be a number"); }
                break;
            default: break;
        }
    }
    try
    {
        return new DateTime(y, m, d);
    } catch (ArgumentOutOfRangeException) 
    {
        Console.WriteLine("Can't create date");
        return getDate(); 
    }
}