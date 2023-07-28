
using AssetTracking;

List<Asset> products = new List<Asset>();
TestData data = new TestData();
products.AddRange(data.getList());


while (true)
{
    // starting point, ask if user wants to add an asset
    Console.WriteLine("Press 'A' to add new asset");
    Console.WriteLine("Press 'P' to print all assets");
    string input = Console.ReadLine();
    if (input.ToLower().Trim() == "a")
    {
        addAsset();
    }
    else if (input.ToLower().Trim() == "p")
    {
        printList();
    }
}

void printList()
{
    List<Asset> sortedList = sortAssets();
    Console.WriteLine("Type".PadRight(15) + "Brand".PadRight(15) + "Model".PadRight(15) + "Purchase Date".PadRight(15) + "Price ($)");
    Console.WriteLine("".PadRight(70, '-'));

    foreach (Asset asset in sortedList)
    {
        printAsset(asset);
    }
}

void printAsset(Asset asset)
{
    bool red = printRed(asset);
    if (red) { Console.ForegroundColor = ConsoleColor.Red; }
    Console.WriteLine(asset.GetType().Name.PadRight(15) + asset.brand.PadRight(15) + asset.model.PadRight(15) + asset.purchaseDate.ToString("yyyy/MM/dd").PadRight(15) + asset.price);
    Console.ResetColor();
}

bool printRed(Asset asset)
{
    return asset.purchaseDate.AddYears(3) < DateTime.Now.AddMonths(3);
}

List<Asset> sortAssets()
{
    return products.OrderBy(c => c.ToString()).ThenBy(d => d.purchaseDate).ToList();
}


// method to add asset and its information
void addAsset()
{
    int i = 0;
    Console.WriteLine("Add asset information:");
    string input;
    int type = 0;
    string brand = "";
    string model = "";
    int price = 0;
    DateTime date = new DateTime();
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

    if (type == 1)
    {
        products.Add(new Phone(brand, model, price, date));
    }
    else if(type == 2)
    {
        products.Add(new Computer(brand, model, price, date));
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
        DateTime addedDate = new DateTime(y, m, d);
        if(addedDate > DateTime.Now)
        {
            try
            {
                throw new ArgumentOutOfRangeException("Can't add a future date");
            } catch (ArgumentOutOfRangeException) 
            { 
                Console.WriteLine("Can't add a future date");
                return getDate();
            }
        }
        else
        {
            return addedDate;
        }
    } catch (ArgumentOutOfRangeException) 
    {
        Console.WriteLine("Can't create date");
        return getDate(); 
    }
}