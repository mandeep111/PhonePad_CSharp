public class PhonePad : IPhonePad
{
    private readonly IInputProcessor _processor;
    public PhonePad(IInputProcessor processor) => _processor = processor;
    public string ProcessInput(string input) => _processor.Process(input);
}

// PhonePadBuilder.cs (fluent)

