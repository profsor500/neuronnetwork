using System;
using System.Collections.Generic;
public class Layer
{
    List<Neuron> NeuronsList { get; set; }
    List<List<Synapse>> SynapsesList { get; set; }
    public Layer(ushort NeuronNumber, ushort SynapsesNumber)
    {
        var rand = new Random();
        SynapsesList = new List<List<Synapse>>();
        NeuronsList = new List<Neuron>();
        //tworzenie listy neuronow
        for (int i = 0; i < NeuronNumber; i++)
        {
            NeuronsList.Add(new Neuron());
            SynapsesList.Add(new List<Synapse>());
            //dodawanie synpasów i'tego neuronu
            for (int j = 0; j < SynapsesNumber; j++)
            {
                //losowanie wagi z przedziału 
                SynapsesList[i].Add(new Synapse(rand.NextDouble()));
            }
        }
    }
    public int NoN()
    {
        return NeuronsList.Count;
    }
    public void getdata(double[] dataset)
    {
        for (int i = 0; i < dataset.Length; i++)
        {
            this.NeuronsList[i].setValue(dataset[i]);
        }
    }
    public void print()
    {
        for (int i = 0; i < NeuronsList.Count; i++)
        {
            Console.Write("neuron: "+NeuronsList[i].ReturnValue()+", Synapses: ");
            for (int j = 0; j < SynapsesList[i].Count; j++)
            {
                Console.Write(SynapsesList[i][j].ReturnWeigth() + " ");
            }
            Console.WriteLine("");
        }
    }
    
    public double[] ReturnProcessed()
    {
        double[] Results = new double[SynapsesList[0].Count];
        for (int i = 0; i < Results.Length; i++)
        {
            Results[i] = 0;
        }
        //do naprawienia
        for (int i = 0; i < NeuronsList.Count; i++)
        {
            //Console.WriteLine("NeuronsList.Count: " + NeuronsList.Count+ "i: "+i+"len: "+ SynapsesList[i].Count);
            for (int j = 0; j < SynapsesList[i].Count; j++)
            {
                NeuronsList[i].AF();
                //Console.WriteLine("SynapsesList.Count.Count: " + SynapsesList.Count+"j: " + j);
                Results[j] += NeuronsList[i].ReturnValue() * SynapsesList[i][j].ReturnWeigth();
            }
        }
        return Results;
    }
}