// OldPhonePadRules.cs
public class OldPhonePadRules : IProcessingRules
{
    public bool IsFlush(char c) => c == '#' || c == ' ';
    public bool IsBackspace(char c) => c == '*';
    public bool IsValidDigit(char c, IKeyMap keyMap) => char.IsDigit(c) && keyMap.Contains(c);
}