using System;
using System.Collections.Generic;
using PhonePad.Domain.Interfaces;
using PhonePad.Domain.Models;

namespace PhonePad.Infrastructure.Keymaps;
public class OldPhonePadKeys : IKeyMap
{
    private readonly IReadOnlyDictionary<char, PhoneKey> _map = new Dictionary<char, PhoneKey>
    {
        ['2'] = new PhoneKey('2',"ABC"),
        ['3'] = new PhoneKey('3',"DEF"),
        ['4'] = new PhoneKey('4',"GHI"),
        ['5'] = new PhoneKey('5',"JKL"),
        ['6'] = new PhoneKey('6',"MNO"),
        ['7'] = new PhoneKey('7',"PQRS"),
        ['8'] = new PhoneKey('8',"TUV"),
        ['9'] = new PhoneKey('9',"WXYZ"),
    };

    public bool Contains(char digit) => _map.ContainsKey(digit);

    public PhoneKey GetKey(char digit) =>
        _map.TryGetValue(digit, out var key) ? key : throw new ArgumentException($"Invalid key: {digit}");
}
