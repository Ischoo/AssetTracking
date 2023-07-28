
using AssetTracking;

List<Asset> products = new List<Asset>();
List<Office> offices = new List<Office>();
TestData data = new TestData();
products.AddRange(data.getList());
offices.AddRange(data.getOffice());
Console.WriteLine("Write \"Exit\" at any point to exit program");

while (true)
{
    // starting point, ask if user wants to add an asset
    Console.WriteLine("Press: 'A' to add | 'P' to print");
    
    string input = Console.ReadLine();
    if(userExit(input)) { Environment.Exit(0); }
    if (input.ToLower().Trim() == "a")
    {
        addAsset();
    }
    else if (input.ToLower().Trim() == "p")
    {
        printList();
    }
}

bool userExit(string input)
{
    return input.ToLower().Trim() == "exit";
}

void printList()
{
    List<Asset> sortedList = sortAssets();
    Console.WriteLine("Type".PadRight(15) + "Brand".PadRight(15) + "Model".PadRight(15) + "Country".PadRight(15) + "Purchase Date".PadRight(15) 
        + "Price ($)".PadRight(15) + "Currency".PadRight(15) + "Local price");
    Console.WriteLine("".PadRight(130, '-'));

    foreach (Asset asset in sortedList)
    {
        printAsset(asset);
    }
}

void printAsset(Asset asset)
{
    
    if (printRed(asset)) { Console.ForegroundColor = ConsoleColor.Red; }
    else if(printYellow(asset)) { Console.ForegroundColor = ConsoleColor.Yellow; }
    Console.WriteLine(asset.GetType().Name.PadRight(15) + asset.brand.PadRight(15) + asset.model.PadRight(15) + asset.office.country.PadRight(15) + 
        asset.purchaseDate.ToString("yyyy/MM/dd").PadRight(15) + asset.price.ToString().PadRight(15) + asset.office.currency.PadRight(15) + getLocalPrice(asset));
    Console.ResetColor();
}

bool printYellow(Asset asset)
{
    return asset.purchaseDate.AddYears(3) < DateTime.Now.AddMonths(6);
}

string getLocalPrice(Asset asset)
{
    return (Convert.ToDouble(asset.price) / asset.office.exchange).ToString("N2");
}

bool printRed(Asset asset)
{
    return asset.purchaseDate.AddYears(3) < DateTime.Now.AddMonths(3);
}

List<Asset> sortAssets()
{
    return products.OrderBy(c => c.office.country).ThenBy(d => d.purchaseDate).ToList();
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
    int office = 0;
    DateTime date = new DateTime();
    while (i < 6)
    {
        input = "";
        switch (i)
        {
            case 0:
                Console.Write("".PadRight(10) + "Asset type: Phone (1) or Computer (2) ");
                input = Console.ReadLine();
                if (userExit(input)) { Environment.Exit(0); }
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
                if (userExit(input)) { Environment.Exit(0); }
                if (String.IsNullOrEmpty(input))
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
                if (userExit(input)) { Environment.Exit(0); }
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
                if (userExit(input)) { Environment.Exit(0); }
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
            case 5:
                Console.WriteLine("".PadRight(10) + "Enter local office: Spain (1) | UK (2) | Sweden (3)");
                input = Console.ReadLine();
                if (userExit(input)) { Environment.Exit(0); }
                try
                {
                    office = int.Parse(input);
                    if (office < 1 || office > 3)
                    {
                        try
                        {
                            throw new ArgumentOutOfRangeException("Please pick a valid option");

                        }
                        catch (Exception e) { Console.WriteLine(e.Message); }
                    }
                    else
                    {
                        office--;
                        i++;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Input needs to be a number");
                }
                break;
            default: break;

        }
    }

    if (type == 1)
    {
        products.Add(new Phone(brand, model, price, date, offices[office]));
    }
    else if (type == 2)
    {
        products.Add(new Computer(brand, model, price, date, offices[office]));
    }

}

DateTime getDate()
{
    int j = 0;
    string input;
    int y = 0, m = 0, d = 0;

    while (j < 3)
    {
        switch(j)
        {
            case 0:
                Console.Write("".PadRight(20) + "Year: ");
                input = Console.ReadLine();
                if (userExit(input)) { Environment.Exit(0); }
                try
                {
                    y = int.Parse(input);
                    j++;
                } catch (FormatException) { Console.WriteLine("Input needs to be a number"); }
                break;
            case 1:
                Console.Write("".PadRight(20) + "Month: ");
                input = Console.ReadLine();
                if (userExit(input)) { Environment.Exit(0); }
                try
                {
                    m = int.Parse(input);
                    j++;
                }
                catch (FormatException) { Console.WriteLine("Input needs to be a number"); }
                break;
            case 2:
                Console.Write("".PadRight(20) + "Day: ");
                input = Console.ReadLine();
                if (userExit(input)) { Environment.Exit(0); }
                try
                {
                    d = int.Parse(input);
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