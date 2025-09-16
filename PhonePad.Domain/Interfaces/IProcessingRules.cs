namespace PhonePad.Domain.Interfaces;
public interface IProcessingRules
{
    bool IsFlush(char c);
    bool IsBackspace(char c);
    bool IsValidDigit(char c, IKeyMap keyMap);
}
