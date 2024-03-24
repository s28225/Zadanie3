namespace Zadanie2;

public abstract class Container
{
    private static int index = 0;
    protected double MaxWeight { get; set; }
    protected double CurrentWeight { get; set; }
    protected double ContainerHeight { get; set; }
    protected double Deep { get; set; }
    protected double Height { get; set; }
    public string SerialNumber { get; }

    public Container(double maxWeight, string type)
    {
        index++;
        this.MaxWeight = maxWeight;
        this.SerialNumber = "KON-" + type + "-" + index;
        this.CurrentWeight = 0;
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
        if (this.CurrentWeight - additionalWeight < 0)
        {
            Console.WriteLine("Invalid action, container cannot be unloaded on thi weight");
        }
        else
        {
            this.CurrentWeight -= additionalWeight;
        }
    }
}