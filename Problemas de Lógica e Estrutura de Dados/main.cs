/*
Solução Giovany da Silva Santos
*/
using System;
using static System.Console;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;

class MainClass {
  public static int CalcularFatorial(int numero){
    int fatorial = 1;

     for(int i = 1; i <= numero; i++){
       fatorial *= i;
     }
    return fatorial;
  }
//calcula premio - sobrecarga
  public static double CalcularPremio(double numero, string tipo , string fatorMultiplicativo){

  
    switch (tipo)
      {
          case "basic":

                return numero;
              break;
          
          case "vip":
                return numero * 1.2;
              break;
          
          case "premium":
                return numero * 1.5;
              break;
          
          case "deluxe":
                return numero * 1.8;
              break;
          

          case "special":
                return numero * 2;
              break;                                    

      }

 return 1;
  }
  //calcula premio - sobrecarga
  public static double CalcularPremio(double numero, string tipo, double fatorMultiplicativo){
   
    switch (tipo)
      {
          case "basic":{

                return numero * fatorMultiplicativo;
              break;
          }
          case "vip":{
                return numero * fatorMultiplicativo;
              break;
          }
          case "premium":{
                return numero * fatorMultiplicativo;
              break;
          }
          case "deluxe":{
                return numero * fatorMultiplicativo;
              break;
          }

          case "special":{
                return numero * fatorMultiplicativo;
              break;                                          
          }

      }

 return 1;
  }
  //funcao que verifica se um número eh primo
  public static bool primo(int numero){
    int div = 0;
    
    //0 ou 1 não são primos
    
    if(numero == 0 || numero == 1 ){
      return false;
    }
    
    //verifica a quantidade de divisores do número de acordo com o Crivo de Eratóstenes
   for(int i = 2 ; i <= Math.Sqrt(numero); i++){
   
     if(numero % i == 0){
       div++;
     }
   
   }

   //Se não possui divisor maior que 1, então é primo
   if(div==0){
        return true;
   }

   //senão não é primo
   return false;
  }
  
  public static int ContarNumerosPrimos(int numero){
  
  //variável para armazenar a quantidade de primos até o número  
   int quantidade = 0;
    
  //Conta a quantidade de primos  
    for (int i = 0; i<= numero; i++){
   
      if(primo(i)){
        quantidade++;
      }
   
    } 

  //retorna a quantidade de primos 
   return quantidade;
  }
   public static int CalcularVogais(string texto){
    //vetor de vogais
    char[] vogais = new char[] { 'a', 'e', 'i', 'o', 'u'};

    //variável para armazenar a quantidade de vogais na palavra
    int quantidadeVogais = 0;

    //conta as vogais
    foreach(char letra in texto){
    
      if(vogais.Contains(letra)){
        quantidadeVogais++;
      }

    }
    //retorna a quantidade de vogais
    return quantidadeVogais;
  }
  public static string CalcularValorComDescontoFormatado(string valor, string porcentagem){
    
    //Tratamento string
    valor = valor.Replace(".","").Replace(",",".").Replace("R$ ","");

    //Conversão para double
    double valorNumerico = Convert.ToDouble(valor);  
     
    //Tratamento string
    porcentagem = porcentagem.Replace("%","");

    //Conversão para double
    double porcentagemNumerica = Convert.ToDouble(porcentagem);

    //Cálculo correção
    double resultado = valorNumerico * (1 - porcentagemNumerica/100);

    //Conversão do cálculo para string e o tratamento necessário
    string resultadoString = resultado.ToString("C", CultureInfo.CurrentCulture).Replace("$","").Replace(".","T").Replace(",",".").Replace("T",",");

    //retorno do resultado em formato de string
    return "R$ " + resultadoString;
  }
  public static int CalcularDiferencaData(string dataIncial , string dataFinal){
      
     //Conversão da string para variável data
     //Para isso as partições das strings são passadas como aaaa/mm/dd no objeto DateTime  
     DateTime dataIni = new DateTime(Convert.ToInt32(dataIncial.Substring(4,4)), Convert.ToInt32(dataIncial.Substring(2,2)), Convert.ToInt32(dataIncial.Substring(0,2)));

     //Conversão da string para variável data
     //Para isso as partições das strings são passadas como aaaa/mm/dd no objeto DateTime
     DateTime dataFim = new DateTime(Convert.ToInt32(dataFinal.Substring(4,4)), Convert.ToInt32(dataFinal.Substring(2,2)), Convert.ToInt32(dataFinal.Substring(0,2)));

    //Retorno da diferença(dias) em módulos( parte númerica) das datas
    return Math.Abs((dataFim-dataIni).Days);
  }

 public static int[]  ObterElementosPares(int[] vetor){
  //vetor para armazenar os números pares do vetor recebido
  int[] pares;
 
  //lista auxiliar na operção de busca dos pares 
  List<int> lista = new List<int>();

  //busca pelos pares
  foreach(int valor in vetor){
    
    if(valor %2 == 0 ){
      lista.Add(valor);
    }

  }

  //Conversão de List para Array
  pares =  lista.ToArray();

 //retorno do vetor de pares
 return  pares;
 }

 public static string[] BuscarPessoa(string[] vetor, string palavra){
   //vetor para armazenamento dos nomes de pessoas
   string[] pessoas;
   //lista auxiliar no processo de busca
  List<string> lista = new List<string>();

  //busca por string que contém a substring
  foreach(string valor in vetor){
    
    if(valor.Contains(palavra)){
      lista.Add(valor);
    }

  }

  //Conversão de List para Array
  pessoas =  lista.ToArray();

  //Retorna o vetor dos nomes de pessoas 
  return pessoas;

 }

 public static int[][] TransformarEmMatriz(string valores){
   //lista auxiliar para a construção da matriz
   List<int> lista = new List<int>();
   //segunda listaauxiliar para a construção da matriz
   List<int[]> listaMatriz = new List<int[]>();
   
   //armazena o resulta final da matriz calculada
   int[][] matriz;

   //captura dos valores númericos 
   string[] vetorValores = valores.Split(",");
    
    //conversão de cada valor para inteiro
    foreach(string numero in vetorValores){
      lista.Add(Convert.ToInt32(numero));
    }
    
    //enquanto a lista não está vazio processe
    while(lista.Count !=0){
        
      //pega o primeiro elemento da lista  
      int primeiroValor = lista.First();
      lista.RemoveAt(0);
 
      //se lista não está vazia
      if(lista.Count != 0){
          //pegue o próximo elemento e remova da lista
          int segundoValor = lista.First();
          lista.RemoveAt(0);

          //crie um vetor e adiciona na listaMatriz
          listaMatriz.Add(new int[]{primeiroValor, segundoValor});
      }
      //se está vazia
      else{
          //crie um vetor com esse elemento e adione na listaMatriz
          listaMatriz.Add(new int[]{primeiroValor});
      }



    }
    
    //Converte para array de array
    matriz = listaMatriz.ToArray();

    //retorne a matriz resultante
    return matriz;
 }

 public static int[] ObterElementosFaltantes(int[] vetor1,int[] vetor2){
   
  //Captura dos valores faltantes no vetor 2
  IEnumerable<int> query = from valor in vetor1.Except(vetor2)
                            select valor;

  //lista auxiliar para obtenção de elementos faltantes
  List<int> lista = new List<int>();

 //Adição na lista
  foreach (var valor in query){
    lista.Add(valor);
  }
    //Captura dos valores faltantes no vetor 1
  query = from valor in vetor2.Except(vetor1)
                            select valor;

  //Adição na lista                          
  foreach (var valor in query){
    lista.Add(valor);
  }

  //conversão para array
  int[] vetor = lista.ToArray();

  //retorno do vetor de elementos faltantes
    return vetor;
 }

  public static void Main (string[] args) {
    
     
    //Testes

    Console.WriteLine (CalcularFatorial(5) == 120);//true
    Console.WriteLine (CalcularPremio(100, "vip", null) == 120.00);//true
    Console.WriteLine (CalcularPremio(100, "basic", 3) == 300.00);//true
    Console.WriteLine (ContarNumerosPrimos(10) == 4);//true
    Console.WriteLine (CalcularVogais("Luby Software") == 4);//true
    Console.WriteLine (CalcularValorComDescontoFormatado("R$ 6.800,00", "30%") == "R$ 4.760,00");//true
    Console.WriteLine (CalcularDiferencaData("10122020","25122020") == 15);//true
    
    int[] vetor = new int[] { 1,2,3,4,5 };
    Console.WriteLine (new int[] { 2, 4 }.SequenceEqual(ObterElementosPares(vetor)));//true 

    string[] Vetor = new string[] {
      "John Doe",
      "Jane Doe",
      "Alice Jones",
      "Bobby Louis",
      "Lisa Romero"
     };
     Console.WriteLine (new string[] { "John Doe", "Jane Doe" }.SequenceEqual(BuscarPessoa(Vetor, "Doe")));//true
     
     Console.WriteLine (new string[] { "Alice Jones" }.SequenceEqual(BuscarPessoa(Vetor, "Alice")));//true

     Console.WriteLine (new string[] { }.SequenceEqual(BuscarPessoa(Vetor, "James")));//true

   //a função de comparação não funciona para matriz, porém a função TransformarEmMatriz está implementada corretamente
     Console.WriteLine (new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 }, new int[] { 5, 6 } }.SequenceEqual(TransformarEmMatriz("1,2,3,4,5,6") ));

     int[] vetor1 = new int[] { 1,2,3,4,5 };
     int[] vetor2 = new int[] { 1,2,5 };
     
     Console.WriteLine (new int[] { 3, 4 }.SequenceEqual(ObterElementosFaltantes(vetor1, vetor2)));

     int[] vetor3 = new int[] { 1,4,5 };
     int[] vetor4 = new int[] { 1,2,3,4,5 };

     Console.WriteLine (new int[] { 2, 3 }.SequenceEqual(ObterElementosFaltantes(vetor3, vetor4)));

     int[] vetor5 = new int[] { 1,2,3,4 };
     int[] vetor6 = new int[] { 2,3,4,5 };

     Console.WriteLine (new int[] { 1, 5 }.SequenceEqual(ObterElementosFaltantes(vetor5, vetor6)));           

     int[] vetor7 = new int[] { 1,3,4,5 };
     int[] vetor8 = new int[] { 1,3,4,5 };
     Console.WriteLine (new int[] { }.SequenceEqual(ObterElementosFaltantes(vetor7, vetor8)));               
  }
 
}




