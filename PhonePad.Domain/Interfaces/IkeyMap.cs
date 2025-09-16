namespace PhonePad.Domain.Interfaces;
public interface IKeyMap
{
    bool Contains(char digit);
    PhoneKey GetKey(char digit);
}