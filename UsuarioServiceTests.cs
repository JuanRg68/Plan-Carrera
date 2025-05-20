using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class UsuarioServiceTests
{
    private UsuarioService _servicio;

    [TestInitialize]
    public void Setup()
    {
        _servicio = new UsuarioService();
    }

    [TestMethod]
    public void Registrar_UsuarioValido_DeberiaRegistrarCorrectamente()
    {
        bool resultado = _servicio.Registrar("Ana");
        Assert.IsTrue(resultado);
        Assert.IsTrue(_servicio.ExisteUsuario("Ana"));
    }

    [TestMethod]
    public void Registrar_UsuarioRepetido_DeberiaFallar()
    {
        _servicio.Registrar("Carlos");
        bool resultado = _servicio.Registrar("Carlos");
        Assert.IsFalse(resultado);
    }

    [TestMethod]
    public void Registrar_NombreVacio_DeberiaFallar()
    {
        bool resultado = _servicio.Registrar("");
        Assert.IsFalse(resultado);
    }
}
