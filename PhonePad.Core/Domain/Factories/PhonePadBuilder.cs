public class PhonePadBuilder
{
    private IKeyMap _keyMap = PhoneKeyFactory.CreateClassicEnglish();
    private IProcessingRules _rules = new OldPhonePadRules();

    public PhonePadBuilder WithKeyMap(IKeyMap keyMap) { _keyMap = keyMap; return this; }
    public PhonePadBuilder WithRules(IProcessingRules rules) { _rules = rules; return this; }

    public IPhonePad Build()
    {
        var inputProcessor = new InputProcessorImpl(_keyMap, _rules);
        return new PhonePad(inputProcessor);
    }
}