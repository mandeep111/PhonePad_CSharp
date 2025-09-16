using PhonePad.Domain.Interfaces;

namespace PhonePad.Application;

public class PhonePadService : IPhonePad
{
    private readonly IInputProcessor _processor;
    public PhonePadService(IInputProcessor processor) => _processor = processor;
    public string ProcessInput(string input) => _processor.Process(input);
}