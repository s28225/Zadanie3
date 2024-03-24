namespace Zadanie2;

public class ContainerL : Container, IHazardNotifier
{
    protected string CurrentLiquid;
    protected DangerLiquids? CurrentDangerous;
    protected int procent { get; set; }

    public ContainerL(double maxWeight, string type) : base(maxWeight, type)
    {
        this.CurrentLiquid = null;
    }

    public void LoadContainer(double additionalWeight, string liquid, DangerLiquids danger)
    {
        if (CurrentLiquid == null)
        {
            this.procent = CheckAndInfo(danger);
            ProcessLoad(additionalWeight);
            CurrentLiquid = liquid;
            CurrentDangerous = danger;
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

    public void UnloadContainer(double additionalWeight)
    {
        if (this.CurrentWeight - additionalWeight < 0)
        {
            Console.WriteLine("Invalid action, container cannot be unloaded on thi weight");
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

    public int CheckAndInfo(DangerLiquids dangerLiquids)
    {
        if (dangerLiquids == DangerLiquids.Dangerous)
        {
            Console.WriteLine("You fill a container with a dangerous liquid\n");
            return 50;
        }

        return 90;
    }
}