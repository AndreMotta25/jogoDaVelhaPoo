using Entidades;

List<Jogador> jogadores = Jogador.ValidaJogadores();

JogoDaVelha jogo = new JogoDaVelha();
jogo.AdicionarJogadores(jogadores);
jogo.InitGame();