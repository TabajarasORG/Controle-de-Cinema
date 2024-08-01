using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Infra.Orm.Compartilhado;
using ControleDeCinema.Infra.Orm.ModuloFilme;

namespace ControleDeCinemaTestes;

[TestClass]
[TestCategory("Testes Integrados")]
public class TesteIntegrado
{ 
    RepositorioFilme repositorioFilme;
    private ControleDeCinamaDbContext dbContext;

    [TestInitialize]
    public void Configura_Teste()
    {
        dbContext = new ControleDeCinamaDbContext();

        dbContext.Filmes.RemoveRange(dbContext.Filmes);

        repositorioFilme = new RepositorioFilme(dbContext);
    }

    [TestMethod]
    public void Deve_Inserir_Filme()
    {
        //Arrange
        Filme filme = new Filme("Titulo Teste", "1:22", "test");

        //Act
        repositorioFilme.Inserir(filme);

        //Assert
        Assert.IsNotNull(repositorioFilme);
    }
}