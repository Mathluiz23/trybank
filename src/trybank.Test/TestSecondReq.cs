using Xunit;
using FluentAssertions;
using trybank;
using System;

namespace trybank.Test;

public class TestSecondReq
{
  [Theory(DisplayName = "Deve logar em uma conta!")]
  [InlineData(0, 0, 0)]
  public void TestLoginSucess(int number, int agency, int pass)
  {
    var trybank = new Trybank();
    trybank.RegisterAccount(number, agency, pass);
    trybank.Login(number, agency, pass);
  }

  [Theory(DisplayName = "Deve retornar exceção ao tentar logar em conta já logada")]
  [InlineData(0, 0, 0)]
  public void TestLoginExceptionLogged(int number, int agency, int pass)
  {
    var trybank = new Trybank();
    trybank.RegisterAccount(number, agency, pass);
    trybank.Login(number, agency, pass);
    Action act = () => trybank.Login(number, agency, pass);
    act.Should().Throw<AccessViolationException>();
  }

  [Theory(DisplayName = "Deve retornar exceção ao errar a senha")]
  [InlineData(0, 0, 0)]
  public void TestLoginExceptionWrongPass(int number, int agency, int pass)
  {
    var trybank = new Trybank();
    trybank.RegisterAccount(number, agency, pass);
    Action act = () => trybank.Login(number, agency, pass + 1);
    act.Should().Throw<ArgumentException>();
  }

  [Theory(DisplayName = "Deve retornar exceção ao digitar conta que não existe")]
  [InlineData(0, 0, 0)]
  public void TestLoginExceptionNotFounded(int number, int agency, int pass)
  {
    var trybank = new Trybank();
    trybank.RegisterAccount(number, agency, pass);
    Action act = () => trybank.Login(number + 1, agency, pass);
    act.Should().Throw<ArgumentException>();
  }

  [Theory(DisplayName = "Deve sair de uma conta!")]
  [InlineData(0, 0, 0)]
  public void TestLogoutSucess(int number, int agency, int pass)
  {
    var trybank = new Trybank();
    trybank.RegisterAccount(number, agency, pass);
    trybank.Login(number, agency, pass);
    trybank.Logout();
  }

  [Theory(DisplayName = "Deve retornar exceção ao sair quando não está logado")]
  [InlineData(0, 0, 0)]
  public void TestLogoutExceptionNotLogged(int number, int agency, int pass)
  {
    var trybank = new Trybank();
    trybank.RegisterAccount(number, agency, pass);
    Action act = () => trybank.Logout();
    act.Should().Throw<AccessViolationException>();
  }
}
