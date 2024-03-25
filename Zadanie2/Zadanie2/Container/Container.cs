namespace Zadanie2;

public abstract class Container
{
    private static int index = 0;
    protected int procent { get; set; }

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

    public abstract void LoadContainer(double additionalWeight, string type, DangerObjects dangerObjects);
    public abstract void UnloadContainer(double additionalWeight);
}