using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cifra_De_César
{
    class Program
    {
        static void Encriptar(string Alfabeto, string mensagem, int cifra, int deslocamento, out string mensagemFinal)
        {
            int index = 0;
            mensagemFinal = "";

            /*O for(i) serve para passar as letras da mensagem do usuário
             *
             *O for(j) serve para comparar todas as letras de "Alfabeto" com a letra da mensagem na posição "i"
             */
            for (int i = 0; i < mensagem.Length; i++)
            {
                for (int j = 0; j < Alfabeto.Length; j++)
                {
                    if(mensagem[i] == Alfabeto[j])
                    {
                        if((j + cifra) >= (Alfabeto.Length))
                        {
                            /*Se a letra do alfabeto mais a cifra for igual última letra mais um, será igual a primeira letra
                             * (Alfabeto.Length - Alfabeto.Length = 0), e assim por diante.
                             */
                            index = (j + cifra) - (Alfabeto.Length);
                        }
                        else
                        {
                            index = j + cifra;
                        }
                        //Somando a letra criptografada coma mensagem
                        mensagemFinal += Alfabeto[index];

                        //deslocando o "disco"
                        cifra += deslocamento;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            string MensagemFinal;

            //Pegando informações
            Console.WriteLine("Você quer criptografar ou descriptografar? \n1.Criptografar\n2.Descriptografar");
            int resposta = int.Parse(Console.ReadLine());

            Console.WriteLine("Qual é cifra criptográfica?");
            int cifra = int.Parse(Console.ReadLine());

            Console.WriteLine("Qual o deslocamento?");
            int deslocamento = int.Parse(Console.ReadLine());

            Console.WriteLine("Qual é a sua mensagem?");
            string Mensagem = Console.ReadLine();

            //Colocando o alfabeto
            string Alfabeto = "abcdefghijklmnopkrstuvwxyzçABCDEFGHIJKLMNOPQRSTUVWXYZÇ123456789 ";
            //Vai servir para descriptografar sendo o inverso do padrão
            string AlfabetoReverso = "";

            //invertendo "Alfabeto"
            for(int i = Alfabeto.Length - 1; i >= 0; i--)
            {
                AlfabetoReverso += Alfabeto[i].ToString();
            }
        
            
            if (resposta == 1)
            {
                Encriptar(Alfabeto, Mensagem, cifra, deslocamento, out MensagemFinal);

                Console.WriteLine("A mensagem criptografada é: {0}", MensagemFinal);
            }
            else
            {
                Encriptar(AlfabetoReverso, Mensagem, cifra, deslocamento, out MensagemFinal);

                Console.WriteLine("A mensagem descriptografada é: {0}", MensagemFinal);
            }

            Console.ReadKey();
        }
    }
}
