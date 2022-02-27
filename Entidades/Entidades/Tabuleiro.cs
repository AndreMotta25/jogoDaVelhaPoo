using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Tabuleiro
    {
        private List<string> _posicoes = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        private string[,] _posicoesVencedoras;
        public List<int> _posicoesPreenchidas = new List<int>();

        public void InitBoard()
        {
            _posicoes = new List<string>();
             _posicoesPreenchidas = new List<int>();
            for (int i = 0; i < 9; i++)
            {
                _posicoes.Add($"{i + 1}");
            }

        }
        public void RenderingBoard()
        {
            Console.WriteLine(_posicoes[0] + "|" + _posicoes[1] + "|" + _posicoes[2]);
            Console.WriteLine(_posicoes[3] + "|" + _posicoes[4] + "|" + _posicoes[5]);
            Console.WriteLine(_posicoes[6] + "|" + _posicoes[7] + "|" + _posicoes[8]);
        }
        public void Preencher(int posicao, Jogador jogador)
        {
            while (true)
            {
                if (_posicoesPreenchidas.Exists(p => p == posicao))
                {
                    Console.WriteLine("Lamento mas a casa que voce escolheu ja esta preenchida");
                    Console.WriteLine("Digite qualquer tecla para jogar novamente");
                    Console.ReadKey();
                    Console.WriteLine("Digite o numero da casa que voce deseja preencher:");
                    posicao = int.Parse(Console.ReadLine());
                }

                else
                    break;
            }
            _posicoes[posicao - 1] = $"{jogador.Part}";
            _posicoesPreenchidas.Add(posicao);


        }

        public bool Venceu()
        {
            _posicoesVencedoras = new string[,]
            {
                 { _posicoes[0], _posicoes[1],_posicoes[2] } , // linha 1
                 { _posicoes[3], _posicoes[4],_posicoes[5] }, // linha 2
                 { _posicoes[6], _posicoes[7],_posicoes[8] } , // linha 3
                 { _posicoes[0], _posicoes[4],_posicoes[8] } , // diagonal principal
                 { _posicoes[2], _posicoes[4],_posicoes[6] } , // diagonal secundaria
                 { _posicoes[0], _posicoes[3],_posicoes[6] } , // coluna 1
                 { _posicoes[1], _posicoes[4],_posicoes[7] } , // coluna 2
                 { _posicoes[2], _posicoes[5],_posicoes[8] } , // coluna 3
            };
            for (int dimensao1 = 0; dimensao1 < _posicoesVencedoras.GetLength(0); dimensao1++)
            {
                var posicao = "";
                for (int dimensao2 = 0; dimensao2 <= 2; dimensao2++)
                {
                    posicao += _posicoesVencedoras[dimensao1, dimensao2];
                    if (posicao == "xxx" || posicao == "ooo")
                    {
                        RenderingBoard();
                        return true;
                    }
                }
            }
            return false;
        }
        public bool DeuVelha()
        {
            if (_posicoesPreenchidas.Count >= 9 && !Venceu())
                return true;
            else
                return false;
        }
    }
}
