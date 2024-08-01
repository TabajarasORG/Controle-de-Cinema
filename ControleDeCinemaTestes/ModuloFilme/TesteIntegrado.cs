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

    [TestMethod]
    public void Deve_Editar_Filme()
    {
        //Arrange
        var filme = new Filme("Titulo original", "1:45", "test");
        repositorioFilme.Inserir(filme);
        var filmeEditado = new Filme("Titulo editado", "1:45", "testEditado");
        
        //Act
        repositorioFilme.Editar(filme, filmeEditado);
        
        //Assert
        Assert.AreEqual("Titulo editado",filme.Titulo);
        Assert.AreNotEqual("Titulo original",filme.Titulo);
    }

    [TestMethod]
    public void Deve_Excluir_Filme()
    {
        //Arrange
        var filme = new Filme("Titulo", "1:45", "test");
        repositorioFilme.Inserir(filme);
        
        //Act
        repositorioFilme.Excluir(filme);
        
        //Assert
        var filmeSelecionado = repositorioFilme.SelecionarPorId(filme.Id);
        Assert.IsNull(filmeSelecionado);
    }
}