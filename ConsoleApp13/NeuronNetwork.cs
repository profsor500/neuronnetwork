using System;
using System.Linq;
using System.Collections.Generic;

public class NeuronNetwork
{
	List<Layer> LayersList;
	public NeuronNetwork()
	{
		LayersList = new List<Layer>();
	}
	
	public double[] provide(double[] data)
	{
		double[] toforward=data;
		int i = 0;
		for (;i < LayersList.Count-1; i++)
		{
			LayersList[i].getdata(toforward);
			toforward = LayersList[i].ReturnProcessed();
		}
		LayersList[i].getdata(toforward);
		return LayersList[i].ReturnProcessed();
	}
	
	//dodaje warstwę na miejscu przedostatnim
	public void AddLayer(ushort neurons, ushort synapses)
	{
		LayersList.Add(new Layer(neurons, synapses));
	}
	public void print()
	{
		for (int i = 0; i < LayersList.Count; i++)
		{
			LayersList[i].print();
		}
	}
	public void CheckEfficiency(double[][] data, int dataCell)
	{
		int correct = 0;
		int all = data.Length;
		for (int i = 0; i < data.Length; i++)
		{
			if (data[i].Skip(dataCell).ToArray().SequenceEqual(Sharping(provide(data[i].Take(dataCell).ToArray())))) correct++;
		}
		Console.WriteLine("Efficiency of neuron network= "+ Math.Round(correct*100.0/all, 2)+"% ("+ correct + " of " + all+")");
		Console.WriteLine();
	}
	void print_table(double[] data)
	{
		for (int i = 0; i < data.Length; i++)
		{
			Console.Write(data[i] + " ");
		}
		Console.WriteLine("");
	}
	//ustawia jeden przy największym i 0 przy pozostałych 
	public static double[] Sharping(double[] data)
	{
		double maxValue = data.Max();
		int p = Array.IndexOf(data, maxValue);
		for (int i = 0; i < data.Length; i++)
		{
			data[i] = 0;
		}
		data[p] = 1;
		return data;
	}

}
