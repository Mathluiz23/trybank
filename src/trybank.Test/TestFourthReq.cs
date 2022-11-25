using Xunit;
using FluentAssertions;
using trybank;
using System;

namespace trybank.Test;

public class TestFourthReq
{
  [Theory(DisplayName = "Deve transefir um valor com uma conta logada")]
  [InlineData(0, 0)]
  public void TestTransferSucess(int balance, int value)
  {
    var trybank = new Trybank();
    trybank.RegisterAccount(0, 0, 0);
    trybank.RegisterAccount(1, 1, 0);
    trybank.Login(0, 0, 0);
    trybank.Deposit(balance);
    trybank.Transfer(1, 1, value);

    trybank.Bank[0, 3].Should().Be(balance - value);
  }

  [Theory(DisplayName = "Deve lançar uma exceção de usuário não logado")]
  [InlineData(0)]
  public void TestTransferWithoutLogin(int value)
  {
    var trybank = new Trybank();
    trybank.RegisterAccount(0, 0, 0);
    trybank.RegisterAccount(1, 1, 0);

    Action act = () => trybank.Transfer(1, 1, value);
    act.Should().Throw<AccessViolationException>();
  }

  [Theory(DisplayName = "Deve lançar uma exceção de usuário não logado")]
  [InlineData(0, 0)]
  public void TestTransferWithoutBalance(int balance, int value)
  {
    throw new NotImplementedException();
  }
}
