using Xunit;
using PhonePad.Application;
using PhonePad.Infrastructure.Keymaps;
using PhonePad.Infrastructure.Rules;
using PhonePad.Domain.Interfaces;


namespace PhonePad.Tests;
public class PhonePadTests
{
    private readonly IPhonePad _pad;

    public PhonePadTests()
    {
        _pad = new PhonePadBuilder()
            .WithKeyMap(new OldPhonePadKeys())
            .WithRules(new OldPhonePadRules())
            .Build();
    }

    [Fact]
    public void ShouldReturnE_For33() => Assert.Equal("E", _pad.ProcessInput("33#"));

    [Fact]
    public void ShouldReturnFalse() => Assert.NotEqual("D", _pad.ProcessInput("33#"));

    [Fact]
    public void ShouldReturnB_AfterBackspace() => Assert.Equal("B", _pad.ProcessInput("227*#"));

    [Fact]
    public void ShouldReturnHello_ForHelloSequence() => Assert.Equal("HELLO", _pad.ProcessInput("4433555 555666#"));

    [Fact]
    public void ShouldReturnTuring_ForTuringSequence() => Assert.Equal("TURING", _pad.ProcessInput("8 88777444666*664#"));
}
