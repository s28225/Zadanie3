namespace Zadanie2;

public abstract class Container
{
    private static int index = 0;
    protected int procent { get; set; }

    protected double MaxWeight { get; set; }
    public double CurrentWeight { get; set; }
    public double ContainerWeight { get; set; }
    protected double Deep { get; set; }
    protected double Height { get; set; }
    public string SerialNumber { get; }

    public Container(double containerWeight,double maxWeight, string type)
    {
        this.ContainerWeight = containerWeight;
        index++;
        this.MaxWeight = maxWeight;
        this.SerialNumber = "KON-" + type + "-" + index;
        this.CurrentWeight = 0;
    }

    public bool EqualsContainer(string name)
    {
        return this.SerialNumber==name;
    }

    public abstract void LoadContainer(double additionalWeight, string type, DangerObjects dangerObjects);
    public abstract void UnloadContainer(double additionalWeight);

    public override string ToString()
    {
        return SerialNumber + " -> " + CurrentWeight + "/" + MaxWeight;
    }
}