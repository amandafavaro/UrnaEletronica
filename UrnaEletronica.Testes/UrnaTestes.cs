using FluentAssertions;

namespace UrnaEletronica.Testes
{
    public class UrnaTestes
    {
        [Fact]
        public void ValidarDadosIniciais_Construtor_ConstruçãoValida()
        {
            // Arrange
            var urnaPadrao = new Urna()
            {
                VencedorEleicao = "",
                VotosVencedor = 0,
                Candidatos = new List<Candidato>(),
                EleicaoAtiva = false
            };

            // Act
            var urna = new Urna();

            // Assert
            urna.Should().BeEquivalentTo(urnaPadrao);
        }

        [Fact]
        public void ValidarInicioEncerramentoEleicao_EleicaoAtiva_DesativarEleicao()
        {
            // Arrange
            var urna = new Urna();
            urna.EleicaoAtiva = true;

            // Act
            urna.IniciarEncerrarEleicao();

            // Assert
            Assert.False(urna.EleicaoAtiva);
        }

        [Fact]
        public void ValidarInicioEncerramentoEleicao_EleicaoInativa_AtivarEleicao()
        {
            // Arrange
            var urna = new Urna();
            urna.EleicaoAtiva = false;

            // Act
            urna.IniciarEncerrarEleicao();

            // Assert
            Assert.True(urna.EleicaoAtiva);
        }

        [Fact]
        public void ValidarCadastroCandidato_NomeCandidato_RetornaUltimoCandidato()
        {
            // Arrange
            var urna = new Urna();

            var candidato1 = "Candidato 1";
            var candidato2 = "Candidato 2";
            var candidato3 = "Candidato 3";

            // Act
            urna.CadastrarCandidato(candidato1);
            urna.CadastrarCandidato(candidato2);
            urna.CadastrarCandidato(candidato3);

            // Assert
            var candidato = urna.Candidatos.LastOrDefault();
            Assert.Equal("Candidato 3", candidato.Nome);
        }

        [Fact]
        public void ValidarMetodoVotacao_CandidatoInvalido_RetornarFalse()
        {
            // Arrange
            var urna = new Urna();

            var candidato1 = "Candidato 1";
            var candidato2 = "Candidato 2";
            var candidato3 = "Candidato 3";

            urna.CadastrarCandidato(candidato1);
            urna.CadastrarCandidato(candidato2);

            // Act
            var voto = urna.Votar(candidato3);

            // Assert
            Assert.False(voto);
        }

        [Fact]
        public void ValidarMetodoVotacao_CandidatoValido_RetornarTrue()
        {
            // Arrange
            var urna = new Urna();

            var candidato1 = "Candidato 1";
            var candidato2 = "Candidato 2";

            urna.CadastrarCandidato(candidato1);
            urna.CadastrarCandidato(candidato2);

            // Act
            var voto = urna.Votar(candidato1);

            // Assert
            Assert.True(voto);
        }

        [Fact]
        public void ValidarResultadoVotacao_EleicaoValida_RetornarMensagem()
        {
            // Arrange
            var urna = new Urna();

            var candidato1 = "Candidato 1";
            var candidato2 = "Candidato 2";
            var candidato3 = "Candidato 3";

            urna.CadastrarCandidato(candidato1);
            urna.CadastrarCandidato(candidato2);
            urna.CadastrarCandidato(candidato3);

            urna.Votar(candidato1);
            urna.Votar(candidato2);
            urna.Votar(candidato3);
            urna.Votar(candidato2);
            urna.Votar(candidato2);
            urna.Votar(candidato3);

            var mensagem = $"Nome vencedor: {candidato2}. Votos: {3}";

            // Act
            var resultado = urna.MostrarResultadoEleicao();

            // Assert
            resultado.Should().Be(mensagem);
        }
    }
}
