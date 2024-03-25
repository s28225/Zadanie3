namespace Zadanie2;

public class ContainerC: Container
{
    protected string CurrentProduct { get; set; }
    protected double Temperature { get; set; }
    protected Dictionary<string, string> TemperatureProducts { get; set; }

    public ContainerC(double currentWeight, double maxWeight, string type, double temperature) : base(currentWeight,maxWeight, type)
    {
        TakeProducts();
        this.Temperature = temperature;
    }

    public override void LoadContainer(double additionalWeight, string product, DangerObjects dangerObjects)
    {
        if (CurrentProduct == null)
        {
            if (TemperatureProducts.ContainsKey(product))
            {
                if (this.Temperature < Double.Parse(TemperatureProducts[product]))
                {
                    Console.WriteLine("Temperature too low to keep this products");
                }
                else
                {
                    CurrentProduct = product;
                    ProcessLoad(additionalWeight);
                }
            }
            else
            {
                Console.WriteLine("There is no such product in the list ");
            }
        }
        else if (CurrentProduct == product)
        {
            ProcessLoad(additionalWeight);
        }else
        {
            Console.WriteLine("You cannot fill a container with another product");
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

    public void TakeProducts()
    {
        string filePath = "E:\\C#\\Project\\Zadanie3\\Zadanie2\\Zadanie2\\Products"; 

        if (File.Exists(filePath))
        {
            TemperatureProducts = new Dictionary<string, string>();

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(' ');
                if (parts.Length == 2) 
                {
                    TemperatureProducts.Add(parts[0], parts[1]); 
                }
            }
        }
        else
        {
            Console.WriteLine("File is not found");
        }
    }

    public void IncreaseTemperature(double temp)
    {
        this.Temperature += temp;
    }

    public void DecreaseTemperature(double temp)
    {
        if (CurrentProduct != null)
        {
            if (this.Temperature - temp < double.Parse(TemperatureProducts[CurrentProduct]))
            {
                Console.WriteLine("Action is not allowed, products need higher temperature");
            }
            else
            {
                this.Temperature -= temp;
            }
        }
        else
        {
            this.Temperature -= temp;
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
                CurrentProduct = null; 
            }
        }
    }
}