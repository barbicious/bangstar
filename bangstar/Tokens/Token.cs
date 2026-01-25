namespace bangstar.Tokens;

/**
 * Represents the smallest unit in the interpreter, a token. These can either simply represent a value, or
 * hold one, such as a number.
 */
public class Token
{
    private readonly TokenType _tokenType;
    private readonly string _lexeme;
    private readonly object? _value;
    private readonly int _line;

    public Token(TokenType type, string lexeme, object? value, int line)
    {
        _tokenType = type;
        _lexeme = lexeme;
        _value = value;
        _line = line;
    }

    public override string ToString()
    {
        return _tokenType + " " + _lexeme + " " + _value;
    }
}