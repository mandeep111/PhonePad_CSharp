// PhonePadTests.cs (xUnit)
using Xunit;

public class PhonePadTests
{
    private readonly IPhonePad _pad = new PhonePadBuilder().Build();

    [Fact]
    public void SingleKeyPress() => Assert.Equal("E", _pad.ProcessInput("33#"));

    [Fact]
    public void Backspace() => Assert.Equal("B", _pad.ProcessInput("227*#"));

    [Fact]
    public void Hello() => Assert.Equal("HELLO", _pad.ProcessInput("4433555 555666#"));

    [Fact]
    public void Turing() => Assert.Equal("TURING", _pad.ProcessInput("8 88777444666*664#"));

    [Fact]
    public void EmptyInput() => Assert.Equal(string.Empty, _pad.ProcessInput(""));

    [Fact]
    public void OnlyHash() => Assert.Equal(string.Empty, _pad.ProcessInput("#"));

    [Fact]
    public void MultipleBackspaces() => Assert.Equal("A", _pad.ProcessInput("22*2#"));

    [Fact]
    public void ConsecutiveSpaces() => Assert.Equal("AA", _pad.ProcessInput("2 2#"));
}
