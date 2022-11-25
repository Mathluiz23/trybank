using Xunit;
using FluentAssertions;
using trybank;
using System;

namespace trybank.Test;

public class TestThirdReq
{
  [Theory(DisplayName = "Deve devolver o saldo em uma conta logada")]
  [InlineData(0)]
  public void TestCheckBalanceSucess(int balance)
  {
    var trybank = new Trybank();
    trybank.RegisterAccount(0, 0, 0);
    trybank.Login(0, 0, 0);
    trybank.Bank[0, 3] = balance;
    trybank.CheckBalance().Should().Be(balance);
  }

  [Theory(DisplayName = "Deve lançar uma exceção de usuário não logado")]
  [InlineData(0)]
  public void TestCheckBalanceWithoutLogin(int balance)
  {
    var trybank = new Trybank();
    trybank.RegisterAccount(0, 0, 0);
    trybank.Bank[0, 3] = balance;
    Action act = () => trybank.CheckBalance();
    act.Should().Throw<AccessViolationException>();
  }

  [Theory(DisplayName = "Deve depositar um saldo em uma conta logada")]
  [InlineData(0)]
  public void TestDepositSucess(int value)
  {
    var trybank = new Trybank();
    trybank.RegisterAccount(0, 0, 0);
    trybank.Login(0, 0, 0);
    trybank.Deposit(value);
    trybank.Bank[0, 3].Should().Be(value);
  }

  [Theory(DisplayName = "Deve lançar uma exceção de usuário não logado")]
  [InlineData(0)]
  public void TestDepositWithoutLogin(int value)
  {
    var trybank = new Trybank();
    trybank.RegisterAccount(0, 0, 0);
    Action act = () => trybank.Deposit(value);
    act.Should().Throw<AccessViolationException>();
  }

  [Theory(DisplayName = "Deve sacar um valor em uma conta logada")]
  [InlineData(0, 0)]
  public void TestWithdrawSucess(int balance, int value)
  {
    var trybank = new Trybank();
    trybank.RegisterAccount(0, 0, 0);
    trybank.Login(0, 0, 0);
    trybank.Bank[0, 3] = balance;
    trybank.Withdraw(value);
    trybank.Bank[0, 3].Should().Be(balance - value);
  }

  [Theory(DisplayName = "Deve lançar uma exceção de usuário não logado")]
  [InlineData(0)]
  public void TestWithdrawWithoutLogin(int value)
  {
    var trybank = new Trybank();
    trybank.RegisterAccount(0, 0, 0);
    Action act = () => trybank.Withdraw(value);
    act.Should().Throw<AccessViolationException>();
  }

  [Theory(DisplayName = "Deve lançar uma exceção de usuário não logado")]
  [InlineData(0, 0)]
  public void TestWithdrawWithoutBalance(int balance, int value)
  {
    throw new NotImplementedException();
  }
}