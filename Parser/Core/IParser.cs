namespace Parser.Core
{
    interface IParser<T> where T : class
    {
        T Parse(string document);
    }
}
