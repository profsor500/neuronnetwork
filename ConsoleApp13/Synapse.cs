using System;

public class Synapse
{
    double weigth { get; set; }
    public Synapse(double value) { this.weigth = value; }
    public double ReturnWeigth() { return this.weigth; }
    public void SetWeight(double NewWeight) { this.weigth = NewWeight; }

}