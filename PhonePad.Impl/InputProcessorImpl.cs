using System.Text;
public class InputProcessorImpl : IInputProcessor
{
    private readonly BufferProcessor _buffer;
    private readonly IProcessingRules _rules;
    private readonly IKeyMap _keyMap;

    public InputProcessorImpl(IKeyMap keyMap, IProcessingRules rules)
    {
        _keyMap = keyMap;
        _buffer = new BufferProcessor(keyMap);
        _rules = rules;
    }

    public string Process(string input)
    {
        if (string.IsNullOrEmpty(input)) return string.Empty;
        var result = new StringBuilder();
        var buffer = new StringBuilder();

        foreach (var c in input)
        {
            if (_rules.IsFlush(c))
                _buffer.FlushBuffer(result, buffer);
            else if (_rules.IsBackspace(c))
                _buffer.HandleBackspace(result, buffer);
            else if (_rules.IsValidDigit(c, _keyMap))
                _buffer.HandleDigit(result, buffer, c);
            // else ignore invalid characters (or choose to error)
        }

        return result.ToString();
    }
}
