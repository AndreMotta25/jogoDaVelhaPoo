using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Jogador
    {
        private int _pontos = 0;
        // vamos ter uma propriedade
        private bool _jogando = false;
        // como nao vai ser exposto para fora da classe, nao vamos fazer a propriedade
        private char[] _parts = new char[] { 'x', 'o' };
        private char _part = ' ';

        // PROPRIEDADES

        public string Nome { get; set; }
        public int Pontos { get; set; }
        public char Part { get { return _part; } }

        // ===============

        // ===============  METODOS ==============

        // so* aceita um valor inteiro
        public void AtribuirPontos(int pontos)
        {
            _pontos = pontos;
        }

        /*Escolhe a posicao do board*/
        public int Jogar()
        {
            Console.WriteLine("Qual posicao voce deseja jogar ? ");
            return int.Parse(Console.ReadLine());
        }
        private void SelecionaPeca(char peca)
        {
            if (peca == 'x' || peca == 'o')
            {
                _part = peca;
            }
        }

        /*Talvez transformar isso numa classe, uma composição no board eu diria  */
        public static List<Jogador> ValidaJogadores()
        {
            List<Jogador> jogadores = new List<Jogador>(2);
            int numeroDeJogadoresValidos = 0;
            while (numeroDeJogadoresValidos <= 1)
            {
                Console.WriteLine($"Digite o nome do {numeroDeJogadoresValidos + 1} jogador");
                string nomeJogador = Console.ReadLine();
                if (nomeJogador.Length > 0)
                {
                    // melhorar isso depois com o metodo construtor ou transformar em uma funcao
                    Jogador jogador = new Jogador();
                    var part = jogador._parts[numeroDeJogadoresValidos];
                    Console.WriteLine($"Voce vai ficar com a marcacao: {part}");
                    jogador.Nome = nomeJogador;
                    jogador.SelecionaPeca(part);
                    jogadores.Add(jogador);
                    numeroDeJogadoresValidos++;
                    Console.WriteLine("Digite qualquer tecla para continuar...");
                    Console.ReadKey();
                    Console.WriteLine();

                }
                else
                    Console.WriteLine("Por favor, Digite um caractere valido!");

            }
            return jogadores;
        }
    }
}
