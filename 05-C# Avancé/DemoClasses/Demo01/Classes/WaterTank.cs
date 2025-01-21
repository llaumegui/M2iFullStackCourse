namespace Demo01.Classes;

// Primary Constructor -> basically sorcery
public class WaterTank(double tareWeight, double totalCapacity)
{
    public double CurrentCapacity { get; private set; } = 0;
    public double TotalCapacity { get; private set; } = totalCapacity;
    public double TareWeight { get; private set; } = tareWeight;
    public double FillLevel => (CurrentCapacity / TotalCapacity) * 100;
    public static double TotalTanksCapacity { get; private set; } = 0;

    public WaterTank() : this(tareWeight: 20, totalCapacity: 100) { }
    
    public double TotalWeight => CurrentCapacity + TareWeight;

    public double Fill(double amount)
    {
        TotalTanksCapacity -= CurrentCapacity;
        double excess = (CurrentCapacity + amount) - TotalCapacity;
        CurrentCapacity = CurrentCapacity + amount > TotalCapacity ? TotalCapacity : CurrentCapacity + amount;
        TotalTanksCapacity += CurrentCapacity;
        
        return excess;
    }

    public double Drain(double amount)
    {
        double drained = 0;
        if (CurrentCapacity - amount <= 0)
        {
            drained = CurrentCapacity;
            CurrentCapacity = 0;
        }
        else
        {
            drained = amount;
            CurrentCapacity -= amount;
        }
        TotalTanksCapacity -= drained;
        return drained;
    }

    public override string ToString()
    {
        string output = "";
        output += $"WaterTank Current Capacity: {CurrentCapacity}/{TotalCapacity}\n";
        output += $"WaterTank Total Weight: {TotalWeight}\n";
        output += $"WaterTank Fill Level: {FillLevel}%\n";
        int fill = 0;
        for (int i = 0; i < 6;i++)
        {
            fill += Math.Ceiling(FillLevel / 20f) >= Math.Abs(5 - i) ? 1 : 0;
            
            if(fill>1)
                output += $"|/////|\n";
            else if(i==0)
                output += $" _____ \n";
            else if (i == 5)
                output += $"|_____|\n";
            else
                output += $"|     |\n";
        }
        output+= $"Current Capacity of all the tanks: {TotalTanksCapacity}\n";
        return output;
    }
}