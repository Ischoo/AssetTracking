
using AssetTracking;

List<Asset> products = new List<Asset>();
List<Office> offices = new List<Office>();
TestData data = new TestData();
products.AddRange(data.getList());
offices.AddRange(data.getOffice());
Console.WriteLine("Write \"Exit\" at any point to exit program");

while (true)
{
    // starting point, ask if user wants to add an asset or to print the list
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
    else { Console.WriteLine("Invalid input"); }
}

bool userExit(string input)
{
    // check if user wants to exit the program
    return input.ToLower().Trim() == "exit";
}

void printList()
{
    // method that begins the printing process, starting with the titles
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
    // method that prints information about an asset
    // set text color to red or yellow if date is in correct range
    
    if (printRed(asset)) { Console.ForegroundColor = ConsoleColor.Red; }
    else if(printYellow(asset)) { Console.ForegroundColor = ConsoleColor.Yellow; }
    Console.WriteLine(asset.GetType().Name.PadRight(15) + asset.brand.PadRight(15) + asset.model.PadRight(15) + asset.office.country.PadRight(15) + 
        asset.purchaseDate.ToString("yyyy/MM/dd").PadRight(15) + asset.price.ToString().PadRight(15) + asset.office.currency.PadRight(15) + getLocalPrice(asset));
    Console.ResetColor();
}

bool printYellow(Asset asset)
{
    // check yellow, if within 6 months of end date
    return asset.purchaseDate.AddYears(3) < DateTime.Now.AddMonths(6);
}

bool printRed(Asset asset)
{
    // check red, if within 3 months of end date
    return asset.purchaseDate.AddYears(3) < DateTime.Now.AddMonths(3);
}

string getLocalPrice(Asset asset)
{
    // convert dollar prices to local currency
    return (Convert.ToDouble(asset.price) / asset.office.exchange).ToString("N2");
}



List<Asset> sortAssets()
{
    // sort list, by office then by purchase date
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
            case 0: // check if user wants to add a phone or computer
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
            case 1: // check brand name for the asset
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
            case 2: // check model name for the asset
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
            case 3: // check asset price in dollars
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
            case 4: // check purchase date, seperate method
                Console.WriteLine("".PadRight(10) + "Enter purchase date: ");
                date = getDate();
                i++;
                break;
            case 5: // check local office for asset
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
    // add asset to list based on input
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
    // method to set purchase date of the asset
    int j = 0;
    string input;
    int y = 0, m = 0, d = 0;

    while (j < 3)
    {
        switch(j)
        {
            case 0: // set year
                Console.Write("".PadRight(20) + "Year: ");
                input = Console.ReadLine();
                if (userExit(input)) { Environment.Exit(0); }
                try
                {
                    y = int.Parse(input);
                    j++;
                } catch (FormatException) { Console.WriteLine("Input needs to be a number"); }
                break;
            case 1: // set month
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
            case 2: // set day
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
        DateTime addedDate = new DateTime(y, m, d); // try to create a date
        if(addedDate > DateTime.Now)
        {
            try
            {
                throw new ArgumentOutOfRangeException("Can't add a future date");
            } catch (ArgumentOutOfRangeException) 
            { 
                Console.WriteLine("Can't add a future date");
                return getDate(); // can't add a future date, let user try again
            }
        }
        else
        {
            return addedDate;
        }
    } catch (ArgumentOutOfRangeException) 
    {
        Console.WriteLine("Can't create date");
        return getDate(); // if date can't be created, let user try again
    }
}