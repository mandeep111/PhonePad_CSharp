using System.Text;

public class BufferProcessor
{
    private readonly IKeyMap _keyMap;

    public BufferProcessor(IKeyMap keyMap) => _keyMap = keyMap;

    public void HandleDigit(StringBuilder result, StringBuilder buffer, char digit)
    {
        if (buffer.Length > 0 && buffer[0] != digit)
            FlushBuffer(result, buffer);

        buffer.Append(digit);
    }

    public void HandleBackspace(StringBuilder result, StringBuilder buffer)
    {
        FlushBuffer(result, buffer);
        if (result.Length > 0) result.Length--;
    }

    public void FlushBuffer(StringBuilder result, StringBuilder buffer)
    {
        if (buffer.Length == 0) return;
        var key = _keyMap.GetKey(buffer[0]);
        var letter = key.GetLetterForPress(buffer.Length);
        result.Append(letter);
        buffer.Clear();
    }
}
