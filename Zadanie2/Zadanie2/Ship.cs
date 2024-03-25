using System.Collections;

namespace Zadanie2;

public class Ship
{
    protected ArrayList Containers { get; set; }
    protected double Speed { get; set; }
    protected int MaxSize { get; set; }
    protected double MaxWeight { get; set; }
    protected string Name { get; set; }

    public Ship(string name, double speed, int maxSize,double maxWeight)
    {
        this.Name = name;
        this.Speed = speed;
        this.MaxSize = maxSize;
        this.MaxWeight = maxWeight;
    }
    
}