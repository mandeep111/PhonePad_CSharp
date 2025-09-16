using System.Text;
using PhonePad.Domain.Interfaces;

namespace PhonePad.Application.Services;
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
        if (result.Length > 0) result.Remove(result.Length - 1, 1);
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
