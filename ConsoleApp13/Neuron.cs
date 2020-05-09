using System;

public class Neuron
{
    double value { get; set; }
    public Neuron() { this.value = 0; }
    public double ReturnValue() { return this.value; }
	public void setValue(double value) { this.value = value; }
	//ActivationFunction
	public void AF()
	{
		double B = 1.23;
		//tanges hiperboliczny
		this.value= 2 / (1 + Math.Pow(Math.E, (-B * this.value))) - 1;
	}
}
