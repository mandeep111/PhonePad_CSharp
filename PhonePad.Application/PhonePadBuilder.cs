using PhonePad.Domain.Interfaces;
using PhonePad.Application.Services;

namespace PhonePad.Application;
public class PhonePadBuilder
{
    private IKeyMap? _keyMap;
    private IProcessingRules? _rules;

    public PhonePadBuilder WithKeyMap(IKeyMap keyMap) { _keyMap = keyMap; return this; }
    public PhonePadBuilder WithRules(IProcessingRules rules) { _rules = rules; return this; }

    public IPhonePad Build()
    {
        if (_keyMap == null) throw new InvalidOperationException("KeyMap required");
        if (_rules == null) throw new InvalidOperationException("Rules required");

        var processor = new InputProcessorImpl(_keyMap, _rules);
        return new PhonePadService(processor);
    }
}
