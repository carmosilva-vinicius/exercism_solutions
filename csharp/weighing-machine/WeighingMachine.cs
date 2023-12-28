using System;

class WeighingMachine
{
    private double weight;
    public int Precision { get; }
    public double TareAdjustment { get; set; } = 5;
    public double Weight { get => weight; 
        set{
            if(value < 0){
                throw new ArgumentOutOfRangeException();
            }
            weight = value;
        }
    }

    public string DisplayWeight { get{
        weight -= TareAdjustment;
        return $"{weight.ToString($"F{Precision}")} kg";
    } }

    public WeighingMachine(int precision)
    {
        Precision = precision;
    }
}