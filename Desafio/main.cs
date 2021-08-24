/*
Solução Giovany da Silva Santos
*/
using System.Collections.Generic;
using System;
using System.Threading;

//construção da classe produto
public class Produto{
  
  private string nome ;
  private double valor;
  private int quantidade;

//construtor da classe
  public Produto(string Nome, double Valor, int Quantidade){
      nome = Nome;
      valor = Valor;
      quantidade = Quantidade;
  }

  //get e set Nome
  public string Nome{
        get => nome;
        set => nome = value;
  }
  
  //get e set Valor
  public double Valor{
        get => valor;
        set => valor = value;
  }

  //get e set Quantidade
  public int Quantidade{
        get => quantidade;
        set => quantidade = value;
  }
}
//classe principal
class MainClass {

//funcao para cancelar compra
//essa funcao recebe um vetor de estoque e um vetor de compras atual
  public static void CancelarCompra(List<Produto>estoque,List<Produto>compras){

//Para cada produto no carrinho de compras devolva no estoque
    foreach(Produto po in compras){
      var indice = estoque.FindIndex(p => p.Nome == po.Nome );
      var produto = estoque[indice];

      if(produto != null){

         //devolve no estoque
          estoque[indice] = new Produto( produto.Nome,produto.Valor,produto.Quantidade+1); 
          //return true;
        
      }
    }

  }
  
  //Função para verificar estoque
  //Essa função recebe um vetor de produtos, que representam um estoque
  public static void VisualizarEstoque(List<Produto> estoque){

    Console.WriteLine("LISTA DE PRODUTOS");
    Console.WriteLine("******************************************");
    foreach(Produto p in estoque){

      Console.WriteLine("Produto: "+p.Nome+" Quantidade: "+p.Quantidade);
      Console.WriteLine("------------------------------------------");
    }
    Console.WriteLine("******************************************");
  }

//Função para calcular o total que será gasto na compra
//Essa função recebe um vetor de produtos, que representam uma compra
  public static double CalcularTotal(List<Produto> compras){
    double valorTotal = 0;
    
    foreach(Produto p in compras){
      valorTotal += p.Valor;
    }

    Console.WriteLine("Valor Total da Compra: "+valorTotal);
    return valorTotal;
  }

  //Função para realizar a compra de um produto
  //Função recebe o nome de um produto a ser pesquisado e um vetor de estoque
  public static bool ComprarProduto(string nome,List<Produto> estoque){

    var indice = estoque.FindIndex(p => p.Nome == nome );
    var produto = estoque[indice];

//Se produto foi encontrado retire do estoque
    if(produto !=null){
      if(produto.Quantidade >0){
        estoque[indice] = new Produto( produto.Nome,produto.Valor,produto.Quantidade-1); 
        return true;
      }
 //senão diga que não foi encontrado     
      else 
        return false;
    }
 //produto não encontrado   
    return false;
  }
  
  //função principal
  public static void Main (string[] args) {

//Lista de produto no estoque e carrinho de compra
     List<Produto> estoque = new List<Produto>();
     List<Produto> compras = new List<Produto>();

//Adição de alguns produtos no estoque
// nome produto, valor, quantidade
     estoque.Add( new  Produto("Celular",450.0,5));
     estoque.Add( new  Produto("Computador",1000.0,3));
     estoque.Add( new  Produto("Máquina de Lavar",600.0,2));
     estoque.Add( new  Produto("Batedeira",300.0,1));
     estoque.Add( new  Produto("Geladeira",700.0,10));
     estoque.Add( new  Produto("Fogão",500.0,4));
    

//operacao (inicial continuar ou sair)
    int operacao = 1;
    
    //loop operacao inicial
    while(operacao ==1){
          Console.WriteLine("Escolha uma opção");
          Console.WriteLine("1 - Fazer alguma operação");
          Console.WriteLine("x - Qualquer número para sair");
          

          operacao = Convert.ToInt32(Console.ReadLine());
          if(operacao != 1){
            Console.Clear();
            break;
          }
          Console.Clear();
           
          //varias opcoes
          int opcao = 1;
          //loop operacao de caixa
          while(opcao <=6 && opcao >=1){

          Console.WriteLine("Escolha uma opção");
          Console.WriteLine("1 - Celular R$450.00");
          Console.WriteLine("2 - Computador R$1000.00");
          Console.WriteLine("3 - Máquina de Lavar R$600.0");
          Console.WriteLine("4 - Batedeira R$300.0");
          Console.WriteLine("5 - Geladeira R$700.0");
          Console.WriteLine("6 - Fogão R$500.0");
          Console.WriteLine("7 - Visualizar estoque");
          Console.WriteLine("8 - Finalizar compra");     
          Console.WriteLine("x - Qualquer número para sair");
          
          //converte string para inteiro
          opcao = Convert.ToInt32(Console.ReadLine());
          
        //escolha da opcao
          switch(opcao){
            case 1:{//opcao celular

              if(ComprarProduto("Celular",estoque)){
                compras.Add(new Produto("Celular",450.00,1) );
              }
              else{
                Console.Write("Produto não disponível escolha outra opção");
                Thread.Sleep(2000);
              }
              //limpar tela ==> printar mensagem ==>  esperar 1 seg ==> limpar novamente
              Console.Clear();
              Console.WriteLine("Escolha uma nova opção...");
              Thread.Sleep(1000);
              Console.Clear();    
              break;
            }
            case 2:{//opcao computador
              if(ComprarProduto("Computador",estoque)){
                compras.Add(new Produto("Computador",1000.00,1) );
              }
              else{
                Console.Write("Produto não disponível escolha outra opção");
                Thread.Sleep(1000);
              } 
              
              //limpar tela ==> printar mensagem ==>  esperar 1 seg ==> limpar novamente
              Console.Clear();
              Console.WriteLine("Escolha uma nova opção....");
              Thread.Sleep(1000);
              Console.Clear();            
              break;
            }
            case 3:{//opcao máquina de lavar
              if(ComprarProduto("Máquina de Lavar",estoque)){
                compras.Add(new Produto("Máquina de Lavar",600.00,1) );
              }
              else{
                Console.Write("Produto não disponível escolha outra opção");
                Thread.Sleep(1000);
              }

              //limpar tela ==> printar mensagem ==>  esperar 1 seg ==> limpar novamente
              Console.Clear();
              Console.WriteLine("Escolha uma nova opção....");
              Thread.Sleep(1000);
              Console.Clear();                              
              break;
            }
            case 4:{//opcao de batedeira
              if(ComprarProduto("Batedeira",estoque)){
                compras.Add(new Produto("Batedeira",300.00,1) );
              }
              else{
                Console.Write("Produto não disponível escolha outra opção");
                Thread.Sleep(1000);
              }

              //limpar tela ==> printar mensagem ==>  esperar 1 seg ==> limpar novamente
              Console.Clear();
              Console.WriteLine("Escolha uma nova opção....");
              Thread.Sleep(1000);
              Console.Clear();                    
              break;
            }
            case 5:{//geladeira
              if(ComprarProduto("Geladeira",estoque)){
                compras.Add(new Produto("Geladeira",700.00,1) );
              }
              else{
                Console.Write("Produto não disponível escolha outra opção");
                Thread.Sleep(1000);
              }

              //limpar tela ==> printar mensagem ==>  esperar 1 seg ==> limpar novamente
              Console.Clear();
              Console.WriteLine("Escolha uma nova opção....");
              Thread.Sleep(1000);
              Console.Clear();                    
              break;
            }
            case 6:{//opcao fogão
              if(ComprarProduto("Fogão",estoque)){
                compras.Add(new Produto("Fogão",500.00,1) );
              }
              else{
                Console.Write("Produto não disponível escolha outra opção");
                Thread.Sleep(1000);
              }

              //limpar tela ==> printar mensagem ==>  esperar 1 seg ==> limpar novamente
              Console.Clear();
              Console.WriteLine("Escolha uma nova opção....");
              Thread.Sleep(1000);
              Console.Clear();                             
              break;
            }
            case 7:{//opcao visualizar estoque
              VisualizarEstoque(estoque);
              Thread.Sleep(5000);

              //limpar tela ==> printar mensagem ==>  esperar 1 seg ==> limpar novamente
              Console.Clear();
              Console.WriteLine("Escolha uma nova opção....");
              Thread.Sleep(1000);
              Console.Clear();   
              break;
            }
            case 8:{//opcao fechar compra

              //pedir valor ao cliente
              Console.Clear();
              Console.WriteLine("Digite o valor dado pelo Cliente no fomato $$$$.cc");
              double valorCliente = Convert.ToDouble(Console.ReadLine()); 
              double valorTotal = CalcularTotal(compras);

              //calcular troco
              double troco =  valorCliente - valorTotal ;
              if(troco >=0){// se o dinheiro dado cobre a compra então imprima sucesso
                Console.WriteLine("Compra efetuada com Sucesso! Troco do cliente: "+Convert.ToString(troco));
              }
              else{// senão peça mais dinheiro ou pergunte se quer cancelar a compra
                Console.WriteLine("Falta dinheiro!");
                Console.WriteLine("1 - Adicionar Dinheiro");
                Console.WriteLine("2 - Cancelar compra");
                int opcao2 = Convert.ToInt32(Console.ReadLine());

                switch(opcao2){

                  case 1:{//Adicionar mais dinheiro
                    Console.WriteLine("Digite um novo valor a ser adicionado");
                    Thread.Sleep(2000);
                    Console.Clear(); 

                    double novoValorCliente = Convert.ToDouble(Console.ReadLine()); 
                    troco = novoValorCliente + troco;//lembrando que troco estava negativo
                  
                    if(troco >= 0){//Sucesso
                      Console.WriteLine("Compra efetuda com Sucesso! Toco do cliente: "+Convert.ToString(troco));
                    
                    }
                    else{//impossível efetuar a compra ==> cancelar
                      Console.WriteLine("Cancelamento da Compra, falta dinheiro...");
                      CancelarCompra(estoque,compras);
                    }
                    Console.Clear();

                    break;
                  }
                  case 2:{//Cancelar a compra
                    Console.WriteLine("Cancelamento da Compra, falta dinheiro...");
                    CancelarCompra(estoque,compras);
                    Console.Clear();  
                    break;
                  }
                }
                

              }
              //esperar 2 seg e depois limpar tela
              Thread.Sleep(2000);
              Console.Clear();
              break;
            }
          }
          
        }
    }
  }
}