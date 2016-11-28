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
            for (int i = 0; i < mensagem.Length; i++)
            {
                for (int j = 0; j < Alfabeto.Length; j++)
                {
                    if(mensagem[i] == Alfabeto[j])
                    {
                        if((j + cifra) >= (Alfabeto.Length))
                        {
                            index = (j + cifra) - (Alfabeto.Length);
                        }
                        else
                        {
                            index = j + cifra;
                        }
                        mensagemFinal += Alfabeto[index];
                        cifra += deslocamento;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Você quer criptografar ou descriptografar? \n1.Criptografar\n2.Descriptografar");
            int resposta = int.Parse(Console.ReadLine());

            Console.WriteLine("Qual é cifra criptográfica?");
            int cifra = int.Parse(Console.ReadLine());

            Console.WriteLine("Qual o deslocamento?");
            int deslocamento = int.Parse(Console.ReadLine());

            Console.WriteLine("Qual é a sua mensagem?");
            string Mensagem = Console.ReadLine();

            string Alfabeto = "abcdefghijklmnopkrstuvwxyzçABCDEFGHIJKLMNOPQRSTUVWXYZÇ123456789 ";
            string AlfabetoReverso = "";

            for(int i = Alfabeto.Length - 1; i >= 0; i--)
            {
                AlfabetoReverso += Alfabeto[i].ToString();
            }
        
            string MensagemFinal;
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
