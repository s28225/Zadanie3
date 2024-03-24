namespace Zadanie2;

public class Container
{
    private static int index = 0;
    protected double MaxWeight { get; }
    protected double CurrentWeight { get; set; }
    protected double Deep { get; set; }
    public string SerialNumber { get; }

    public Container(double maxWeight, string type)
    {
        index++;
        this.MaxWeight = maxWeight;
        this.SerialNumber = "KON-" + type + "-" + index;
        this.CurrentWeight = 0;
        Console.WriteLine("Hello world!");
    }
    

    public void LoadContainer(double additionalWeight)
    {
        if (this.CurrentWeight + additionalWeight <= MaxWeight)
        {
            this.CurrentWeight += additionalWeight;
        }
        else
        {
            Console.WriteLine("Invalid action, maximum load capacity will be overfilled");
        }
    }

    public void UnloadContainer(double additionalWeight)
    {
        this.CurrentWeight -= additionalWeight;
    }
}