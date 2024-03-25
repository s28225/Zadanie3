namespace Zadanie2;

public class ContainerG : Container, IHazardNotifier
{
    protected double Pressure { get; set; }
    protected string CurrentGaz { get; set; }
    protected DangerObjects DangerObjects { get; set; }


    public ContainerG(double containerWeight, double maxWeight, string type, double pressure) : base(containerWeight,maxWeight, type)
    {
        this.procent = 5;
        this.Pressure = pressure;
    }

    public override void LoadContainer(double additionalWeight, string gaz, DangerObjects danger)
    {
        CheckAndInfo(danger);
        if (CurrentGaz == null)
        { 
            CurrentGaz = gaz;
            DangerObjects = danger;
            ProcessLoad(additionalWeight);
            
        }
        else if (CurrentGaz == gaz && DangerObjects == danger)
        {
            ProcessLoad(additionalWeight);
        }else

        {
            Console.WriteLine("You cannot fill a container with another gaz");
        }
    }

    public void ProcessLoad(double additionalWeight)
    {
        if (CurrentWeight+additionalWeight <= MaxWeight)
        {
            CurrentWeight += additionalWeight;
        }
        else
        {
            Console.WriteLine("Invalid action, maximum load capacity will be overfilled");
        }
    }

    public override void UnloadContainer(double additionalWeight)
    {
        if (CurrentWeight-additionalWeight<CurrentWeight*0.05)
        {
            Console.WriteLine("Invalid action, container cannot be unloaded on this weight");
            
        }
        else
        {
            CurrentWeight -= additionalWeight;
        }
    }

    public void CheckAndInfo(DangerObjects dangerObjects)
    {
        if (dangerObjects == DangerObjects.Dangerous)
        {
            Console.WriteLine("You fill a container("+this.SerialNumber+") with a dangerous gaz");
            
        }
    }
}