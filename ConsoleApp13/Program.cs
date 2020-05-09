using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp13
{
    class Program
    {
        static void Main(string[] args)
        {
            //pobranie i konwersja bazy iris
            double[][] iris_dataset;
            iris_dataset = getdata_iris("C:/Users/profsor500/Desktop/Studia/SystemySztucznejInteligencji/iris_dataset.txt");
            //utwoprzenie sieci neuronowej
            NeuronNetwork NN = new NeuronNetwork();
            //pierwsza warstwa musi mieć 4 neurony - 4 dane wejściowe
            NN.AddLayer(4, 4);
            //kazda kolejna warstwa musi mieć tyle neuronów, co poprzednia protonów, aby uprościć przekazywanie danych
            NN.AddLayer(4, 4);
            NN.AddLayer(4, 4);
            NN.AddLayer(4, 4);
            //ostatnia warstwa musi mieć 3 Synapsy, co odpowiada 3 wyjściom.
            NN.AddLayer(4, 3);
            //NN.print();
            /*
            for (int i = 0; i < iris_dataset.Length; i++)
            {
                Console.Write(i + ") ");
                print_table(NN.provide(iris_dataset[i].Take(4).ToArray()));
            }
            */
            NN.CheckEfficiency(iris_dataset, 4);
            Console.ReadKey();

        }

        public static double[][] getdata_iris(string datapath)
        {
            string[] lines = File.ReadAllLines(@datapath);
            double[][] data = new double[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] tmp = lines[i].Split(',');
                data[i] = new double[tmp.Length + 2];
                for (int j = 0; j < tmp.Length - 1; j++)
                {
                    data[i][j] = Convert.ToDouble(tmp[j].Replace('.', ','));
                }
                //ustawienie gatunku gwiatu poza petla z powodu jego "innosci"
                if (tmp[tmp.Length - 1] == "Iris-setosa") { data[i][tmp.Length - 1] = 1; data[i][tmp.Length] = 0; data[i][tmp.Length + 1] = 0; }
                else if (tmp[tmp.Length - 1] == "Iris-versicolor") { data[i][tmp.Length - 1] = 0; data[i][tmp.Length] = 1; data[i][tmp.Length + 1] = 0; }
                else { data[i][tmp.Length - 1] = 0; data[i][tmp.Length] = 0; data[i][tmp.Length + 1] = 1; }
            }
            return data;
        }
        public static void print_table(double[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                Console.Write(data[i] + " ");
            }
            Console.WriteLine("");
        }
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



}
