using System.Collections;

namespace Zadanie2;

public class Program
{
    public static void Main(string[] args)
    {
        List<Ship> ship = new List<Ship>();
        bool isFinished = false;
        string option;
        while (!isFinished)
        {
            try
            {
                Console.Write("List of ship:\n");
                foreach (Ship s in ship)
                {
                    Console.WriteLine(s);
                }

                Console.Write("List of container:\n");
                foreach (Ship s in ship)
                {
                    foreach (Container container in s.Containers)
                    {
                        Console.WriteLine(container);
                    }
                }

                if (ship.Count == 0)
                {
                    Console.WriteLine("1) Add ship");
                    Console.Write("Result: ");
                    option = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("1) Add ship");
                    Console.WriteLine("2) Delete ship");
                    Console.WriteLine("3) Add container");
                    Console.Write("Result: ");
                    option = Console.ReadLine();
                }

                if (option == "1")
                {
                    Console.WriteLine("Write a name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Write a speed: ");
                    double temp = Double.Parse(Console.ReadLine());
                    Console.WriteLine("Write a maxSize: ");
                    int maxSize = (int)Double.Parse(Console.ReadLine());
                    Console.WriteLine("Write a maxWeight: ");
                    double MaxWeight = Double.Parse(Console.ReadLine());
                    ship.Add(new Ship(name, temp, maxSize, MaxWeight));
                }
                else if (option == "3" && ship.Count != 0)
                {
                    Console.WriteLine("Choose a index of ship");
                    int index = (int)Double.Parse(Console.ReadLine());

                    Console.WriteLine("Choose a type (L, C, T");
                    string t = Console.ReadLine();
                    if (t.ToUpper() == "L")
                    {
                        Console.WriteLine("Write a containerWeight: ");
                        double conWeight = Double.Parse(Console.ReadLine());
                        Console.WriteLine("Write a maxWeight: ");
                        int MaxWeight = (int)Double.Parse(Console.ReadLine());
                        ContainerL container = new ContainerL(conWeight, MaxWeight, t);
                        ship[index - 1].LoadShip(container);
                    }
                    else if (t.ToUpper() == "G")
                    {
                        Console.WriteLine("Write a containerWeight: ");
                        double conWeight = Double.Parse(Console.ReadLine());
                        Console.WriteLine("Write a maxWeight: ");
                        int MaxWeight = (int)Double.Parse(Console.ReadLine());
                        Console.WriteLine("Write a pressure: ");
                        double pressure = Double.Parse(Console.ReadLine());
                        ContainerG container = new ContainerG(conWeight, MaxWeight, t, pressure);
                        ship[index - 1].LoadShip(container);
                    }
                    else if (t.ToUpper() == "C")
                    {
                        Console.WriteLine("Write a containerWeight: ");
                        double conWeight = Double.Parse(Console.ReadLine());
                        Console.WriteLine("Write a maxWeight: ");
                        int MaxWeight = (int)Double.Parse(Console.ReadLine());
                        Console.WriteLine("Write a temperature: ");
                        double temperature = Double.Parse(Console.ReadLine());
                        ContainerC container = new ContainerC(conWeight, MaxWeight, t, temperature);
                        ship[index - 1].LoadShip(container);
                    }
                }
                else if (option == "2")
                {
                    Console.WriteLine("Choose a index of ship");
                    int index = (int)Double.Parse(Console.ReadLine());
                    Ship temp = ship[index - 1];
                    ship.Remove(temp);
                }
                else if (option == "4")
                {
                    Console.WriteLine("Choose a index of ship");
                    int index = (int)Double.Parse(Console.ReadLine());
                    foreach (Container con in ship[index].Containers)
                    {
                        Console.WriteLine(con);
                    }

                    Console.WriteLine("Choose a index of Container");
                    int indexCon = (int)Double.Parse(Console.ReadLine());
                    Container current = ship[indexCon].Containers[indexCon];
                    if (current.SerialNumber[4] == 'L' || current.SerialNumber[4] == 'G')
                    {
                        Console.WriteLine("Choose action:\n" +
                                          "1)Load container\n" +
                                          "2)Unload container\n");
                        string number = Console.ReadLine();
                        if (number == "1" || number=="2")
                        {
                            Console.WriteLine("Write a addWeight: ");
                            double addWeight = Double.Parse(Console.ReadLine());
                            Console.WriteLine("Write a material: ");
                            string type = Console.ReadLine();
                            Console.WriteLine("Write a dangerous (1-danger, another-safe): ");
                            int dangerNumber = (int)Double.Parse(Console.ReadLine());
                            DangerObjects tempDanger;
                            if (dangerNumber == 1)
                            {
                                tempDanger = DangerObjects.Dangerous;
                            }
                            else
                            {
                                tempDanger = DangerObjects.Safe;
                            }

                            if (number=="2")
                            {
                                addWeight = addWeight * -1;
                            }
                            ship[index].UpdateWeightContainer(addWeight,current, type, tempDanger);
                        }
                    }
                    else if (current.SerialNumber[4] == 'C')
                    {
                        Console.WriteLine("Choose action:\n" +
                                          "1)Load container\n" +
                                          "2)Unload container\n");
                        string number = Console.ReadLine();
                        if (number == "1" || number =="2")
                        {
                            Console.WriteLine("Write a addWeight: ");
                            double addWeight = Double.Parse(Console.ReadLine());
                            Console.WriteLine("Write a liquid: ");
                            string type = Console.ReadLine();
                            Console.WriteLine("Write a dangerous (1-danger, another-safe): ");
                            int dangerNumber = (int)Double.Parse(Console.ReadLine());
                            DangerObjects tempDanger;
                            if (dangerNumber == 1)
                            {
                                tempDanger = DangerObjects.Dangerous;
                            }
                            else
                            {
                                tempDanger = DangerObjects.Safe;
                            }

                            if (number=="2")
                            {
                                addWeight = addWeight * -1;
                            }
                            ship[index].UpdateWeightContainer(addWeight,current, type, tempDanger);
                        }
                        else if (number == "2")
                        {
                            Console.WriteLine("Write a addWeight: ");
                            double addWeight = Double.Parse(Console.ReadLine());
                            current.UnloadContainer(addWeight);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Don't have type like this");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid Action, try again");
                Console.WriteLine("---------------------------");
            }
        }
    }
}