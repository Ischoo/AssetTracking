
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
                Console.Write("".PadRight(10) + "Asset type: Phone (1) or Computer (2)");
                input = Console.ReadLine();
                try
                {
                    type = int.Parse(input);
                    i++;
                } catch (Exception e) 
                {
                    Console.WriteLine(e.ToString());
                }
                Console.ReadLine();
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            default: break;

        }
    }

}