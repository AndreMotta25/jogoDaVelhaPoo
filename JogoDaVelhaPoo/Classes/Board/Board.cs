using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JogoDaVelhaPoo.Jogadores;

namespace JogoDaVelhaPoo.BoardGame
{
    public class Board
    {
        private Jogador[] _jogadores = new Jogador[2] { new Jogador(), new Jogador() };
        private List<Jogador> _teste = new List<Jogador>();
        private List<string> _posicoes = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        private int _jogadorDaVez = 0;
        private bool _playing = true;

        /*Vai iniciar o board e tambem reseta-lo*/
        public void InitBoard()
        {
            _jogadorDaVez = PrimeiroJogador();
            Console.WriteLine(_jogadores[0].Nome);
            Console.WriteLine("=================== Bem vindo ao jogo da velha c# =====================");
            for (int i = 0; i < 9; i++)
            {
                _posicoes[i] = $"{i + 1}";
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
            _posicoes[posicao - 1] = $"{jogador.Part}";
        }
        public void Turno(int jogador)
        {
            Console.WriteLine($"Quem joga é: {_jogadores[jogador].Nome}");
            RenderingBoard();
            int posicao = (_jogadores[jogador]).Jogar();
            Preencher(posicao, _jogadores[jogador]);
        }
        public void Jogadores()
        {
            var jogadoresLista = Jogador.ValidaJogadores();
            foreach (Jogador jogador in jogadoresLista)
            {
                //_jogadores.Append(jogador);
                _teste.Add(jogador);
            }
            foreach (Jogador jogador in _teste)
            {
                Console.WriteLine(jogador.Part);
            }

        }
        public void InitGame()
        {
            Jogadores();
            InitBoard();
            while (_playing)
            {
                _jogadorDaVez = _jogadorDaVez > 1 ? 0 : _jogadorDaVez;
                Turno(_jogadorDaVez);
                _jogadorDaVez++;
            }
        }
        public int PrimeiroJogador()
        {
            Random rnd = new Random();
            return rnd.Next(2);
        }
    }
}
