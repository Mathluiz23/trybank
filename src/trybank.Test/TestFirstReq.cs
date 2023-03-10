using Xunit;
using FluentAssertions;
using trybank;
using System;

namespace trybank.Test;

public class TestFirstReq
{
  [Theory(DisplayName = "Deve cadastrar contas com sucesso!")]
  [InlineData(0, 0, 0)]
  public void TestRegisterAccountSucess(int number, int agency, int pass)
  {
    var trybank = new Trybank();
    trybank.RegisterAccount(number, agency, pass);
    trybank.registeredAccounts.Should().Be(1);
  }

  [Theory(DisplayName = "Deve retornar ArgumentException ao cadastrar contas que já existem")]
  [InlineData(0, 0, 0)]
  public void TestRegisterAccountException(int number, int agency, int pass)
  {
    var trybank = new Trybank();
    trybank.RegisterAccount(number, agency, pass);
    Action act = () => trybank.RegisterAccount(number, agency, pass);
    act.Should().Throw<ArgumentException>();
  }
}