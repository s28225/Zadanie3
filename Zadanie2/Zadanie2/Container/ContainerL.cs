namespace Zadanie2;

public class ContainerL :Container, IHazardNotifier
{
    protected string CurrentLiquid;
    protected DangerObjects? CurrentDangerous;

    public ContainerL(double containerWeight,double maxWeight, string type) : base(containerWeight, maxWeight, type)
    {
        this.CurrentLiquid = null;
    }

    public override void LoadContainer(double additionalWeight, string liquid, DangerObjects danger)
    {
        CheckAndInfo(danger);
        if (CurrentLiquid == null)
        {
            CurrentLiquid = liquid;
            CurrentDangerous = danger;
            if (CurrentDangerous == DangerObjects.Dangerous)
            {
                procent = 50;
            }else
            {
                procent = 90;
            }
            ProcessLoad(additionalWeight);
            
            
        }
        else if (CurrentLiquid == liquid && CurrentDangerous == danger)
        {
            ProcessLoad(additionalWeight);
        }else

        {
            Console.WriteLine("You cannot fill a container with another liquid");
        }
    }

    public void ProcessLoad(double additionalWeight)
    {
        if (CurrentWeight+additionalWeight <= MaxWeight*procent/100)
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
        if (this.CurrentWeight - additionalWeight < 0)
        {
            Console.WriteLine("Invalid action, container cannot be unloaded on this weight");
        }
        else
        {
            this.CurrentWeight -= additionalWeight;
            if (CurrentWeight==0)
            {
                CurrentLiquid = null;
                CurrentDangerous = null;
            }
        }
        
    }

    public void CheckAndInfo(DangerObjects dangerObjects)
    {
        if (dangerObjects == DangerObjects.Dangerous)
        {
            Console.WriteLine("You fill a container with a dangerous liquid\n");
        }
    }
}