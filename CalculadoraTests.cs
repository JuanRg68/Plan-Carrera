using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class CalculadoraTests
{
    private Calculadora _calc;

    [TestInitialize]
    public void Setup()
    {
        _calc = new Calculadora();
    }

    [TestMethod]
    public void Sumar_DeberiaRetornarSumaCorrecta()
    {
        int resultado = _calc.Sumar(2, 3);
        Assert.AreEqual(5, resultado);
    }

    [TestMethod]
    public void Dividir_EntreCero_DeberiaLanzarExcepcion()
    {
        Assert.ThrowsException<DivideByZeroException>(() => _calc.Dividir(10, 0));
    }
}
