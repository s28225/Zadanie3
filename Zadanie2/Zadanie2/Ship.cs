using System.Collections;

namespace Zadanie2;

public class Ship
{
    public List<Container> Containers { get; set; }
    protected double Speed { get; set; }
    protected int MaxSize { get; set; }
    protected double MaxWeight { get; set; }
    protected double CurrentWeight { get; set; }
    protected string Name { get; set; }

    public Ship(string name, double speed, int maxSize, double maxWeight)
    {
        this.Containers = new List<Container>();
        this.Name = name;
        this.Speed = speed;
        this.MaxSize = maxSize;
        this.MaxWeight = maxWeight;
        CurrentWeight = 0;
    }

    public void LoadShip(Container container)
    {
        if (!Containers.Contains(container))
        {
            if (Containers.Count + 1 > MaxSize)
            {
                Console.WriteLine("Maximum container capacity exceeded");
            }
            else
            {
                if (CurrentWeight + container.CurrentWeight + container.ContainerWeight > MaxWeight)
                {
                    Console.WriteLine("Maximum container capacity exceeded");
                }
                else
                {
                    Containers.Add(container);
                    this.CurrentWeight += container.CurrentWeight + container.ContainerWeight;
                }
            }
        }
    }
    
    public void ReplaceContainer(string name, Container container)
    {
        for (int i=0; i<Containers.Count;i++)
        {
            if (Containers[i].EqualsContainer(name))
            {
                Containers[i] = container;
                this.CurrentWeight -= (Containers[i].CurrentWeight + Containers[i].ContainerWeight);
                this.CurrentWeight += container.CurrentWeight + container.ContainerWeight;
            }
            else
            {
                Console.WriteLine("Container is not found");
            }
        }
    }

    public void ChangeContainerShip(Ship ship, string  name)
    {
        for (int i=0; i<Containers.Count;i++)
        {
            if (Containers[i].EqualsContainer(name))
            {
                ship.LoadShip(Containers[i]);
                this.DeleteContainer(Containers[i].SerialNumber);
            }
            else
            {
                Console.WriteLine("Container is not found");
            }
        }
    }

    public void DeleteContainer(string name)
    {
        for (int i=0; i<Containers.Count;i++)
        {
            if (Containers[i].EqualsContainer(name))
            {
                CurrentWeight -= (Containers[i].CurrentWeight + Containers[i].ContainerWeight); 
                this.Containers.Remove(Containers[i]);
            }
            else
            {
                Console.WriteLine("Container is not found");
            }
        }
        
    }

    public void UpdateWeightContainer(double additional, Container container, string type, DangerObjects dangerObjects)
    {
        double temp=container.CurrentWeight;
        container.LoadContainer(additional,type,dangerObjects);
        if (temp<container.CurrentWeight)
        {
            this.CurrentWeight += container.CurrentWeight + container.ContainerWeight;
        }else if (temp>container.CurrentWeight)
        {
            this.CurrentWeight -= container.CurrentWeight + container.ContainerWeight;
        }
    }

    public void LoadListsContainers(List<Container> containers)
    {
        double temp = 0;
        if (this.Containers.Count+containers.Count>MaxWeight)
        {
            Console.WriteLine("Maximum container capacity exceeded");
        }
        else
        {
            foreach (Container c in containers)
            {
                temp += c.CurrentWeight + c.ContainerWeight;
            }

            if (this.CurrentWeight + temp > MaxWeight)
            {
                Console.WriteLine("Maximum container capacity exceeded");
            }else 
            {
                foreach (Container c in containers)
                {
                    LoadShip(c);
                }
            }
        }
    }

    public override string ToString()
    {
        return Name + " (speed=" + Speed + ", maxContainerNum=" + MaxSize + ", maxWeight=" + MaxWeight + ")\n";
    }
}