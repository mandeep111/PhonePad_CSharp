public interface IKeyMap
{
    bool Contains(char digit);
    PhoneKey GetKey(char digit); // throws if not found
}