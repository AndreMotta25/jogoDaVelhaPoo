﻿namespace Entidades
{
    public class JogoDaVelha
    {
        // agregacao
        private List<Jogador> _jogadores = new List<Jogador>();
        // composicao 
        private Tabuleiro _tabuleiro = new Tabuleiro();
        private int _jogadorDaVez;
        private bool _playing = true;

        public void AdicionarJogadores(List<Jogador> jogadores)
        {
            _jogadores = jogadores;
        }
        public void InitGame()
        {
            Regras();
            PrimeiroJogador();
            _playing = true;

            _tabuleiro.InitBoard();

            while (_playing)
            {
                _jogadorDaVez = _jogadorDaVez > 1 ? 0 : _jogadorDaVez;
                Turno(_jogadorDaVez);
                _jogadorDaVez++;
            }
        }
        private void Turno(int jogador)
        {
            Console.Clear();
            Console.WriteLine($"Quem joga é: {_jogadores[jogador].Nome}");
            _tabuleiro.RenderingBoard();
            int posicao = (_jogadores[jogador]).Jogar();
            _tabuleiro.Preencher(posicao, _jogadores[jogador]);
            // todo final de turno temos que verificar se alguem ganhou
            VerificaVencedor();
        }
        private void PrimeiroJogador()
        {

            Random rnd = new Random();
            _jogadorDaVez = rnd.Next(2);
            Console.WriteLine(_jogadorDaVez);



        }

        private void Regras()
        {
            Console.WriteLine("==========================================");
            Console.WriteLine();
            Console.WriteLine("================= Bem vindo ao jogo da velha C# ==================");
            Console.WriteLine("Modo de funcionamento do tabuleiro: use os numeros de 1 a 9 para preencher o tabuleiro");
            Console.WriteLine("Quando for sua vez de jogar voce vera uma tela semelhante a esta: ");
            Console.WriteLine();
            _tabuleiro.InitBoard();
            _tabuleiro.RenderingBoard();
            Console.WriteLine("Digite qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();

        }

        private void VerificaVencedor()
        {
            if (_tabuleiro.Venceu())
            {
                Console.WriteLine($"Parabens jogador {_jogadores[_jogadorDaVez].Nome}");
                _playing = false;
                Continuar();

            }
            else if (_tabuleiro.DeuVelha())
            {
                _playing = false;
                Console.WriteLine("O jogo deu velha");
            }
        }
        private void Continuar()
        {
            // quer continuar ? sim 
            // InitGame();
            // quer continuar ? nao 
            // mensagem de saida
        }
    }
}