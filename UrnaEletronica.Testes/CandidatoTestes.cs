using FluentAssertions;

namespace UrnaEletronica.Testes
{
    public class CandidatoTestes
    {
        [Fact]
        public void ValidarVotos_QuantidadeVotos_VotosZerados()
        {
            // Arrange
            var candidato = new Candidato("Candidato");

            // Act
            var votos = candidato.Votos;

            // Assert
            Assert.Equal(0, votos);
        }

        [Fact]
        public void AdicionarVotos_QuantidadeVotos_MaisUmVoto()
        {
            // Arrange
            var candidato = new Candidato("Candidato");

            // Act
            candidato.AdicionarVoto();

            // Assert
            Assert.Equal(1, candidato.Votos);
        }

        [Fact]
        public void ValidarCandidato_AdicionarNome_NomeCorreto()
        {
            // Arrange
            var nome = "Candidato";

            // Acts
            var candidato = new Candidato(nome);

            // Assert
            candidato.Nome.Should().Be(nome);
        }
    }
}