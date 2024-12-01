using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

class Program {
  public static void Main (string[] args) {
    
    var linhas = File.ReadAllLines("input.txt");

    List<int> leftList = new List<int>();
    List<int> rightList = new List<int>();

    foreach(var linha in linhas) {
      var numeros = linha.Trim().Split(new[] { ' ', '\t'}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
      leftList.Add(numeros[0]);
      rightList.Add(numeros[1]);
    }
    int distanciaTotal = calcularDistancia(leftList, rightList);

    Console.WriteLine($"A distância total é: {distanciaTotal}");
    
  }

  static int calcularDistancia(List<int> leftList, List<int> rightList) {
    leftList.Sort();
    rightList.Sort();

    int distanciaTotal = leftList.Zip(rightList, (a, b) => Math.Abs(a - b)).Sum();

    return distanciaTotal;
  }
}