public record PhoneKey(char Digit, string Letters)
{
    public char GetLetterForPress(int pressCount)
        => Letters[(pressCount - 1) % Letters.Length];
}