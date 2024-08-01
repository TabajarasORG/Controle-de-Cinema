using ControleDeCinema.Dominio.ModuloFilme;

namespace ControleDeCinemaTestes;

[TestClass]
[TestCategory("Testes Unitarios")]
public class TesteUnitario
{
    [TestMethod]
    public void Deve_Cadastrar_Filme()
    {
        //Arrange
        Filme novoFilme;
        
        //Act
        novoFilme = new Filme("Filme de teste", "1:22", "test");
        
        //Assert
        Assert.AreEqual("Filme de teste",novoFilme.Titulo);
    }

    [TestMethod]
    public void Deve_Editar_Filme()
    {
        //Arrange
        Filme novoFilme = new Filme("Filme de teste", "1:22", "test");
        
        //Act
        novoFilme.Titulo = "Titulo Editado";
        
        //Assert
        Assert.AreEqual("Titulo Editado",novoFilme.Titulo);
    }
}