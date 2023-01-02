using Xunit;
using SuperCoder;

public class TestClass{
    [Theory]
    [InlineData(5)]
    [InlineData(7)]
    [InlineData(9)]
    
    
    public void MyFirstTheory(int number){
        Assert.True(Program.IsOdd(number));
        
    }

    [Fact]
    public void PassingAdd()
    {
        Assert.Equal(4, Program.Add(2,2));
    }
}