namespace bangstar.Token;

/**
 * Responsible for turning a source string into a list of program readable
 * tokens which can be used for the AST later.
 */
public class Tokenizer(string source)
{
    private readonly string _source = source;
    private readonly List<Token> _tokens = new();
    private int _start = 0;
    private int _current = 0;
    private int _line = 1;

    public List<Token> ScanTokens()
    {
        while (_current < _source.Length)
        {
            _start = _current;
            ScanToken();
        }
        
        _tokens.Add(new Token(TokenType.Eof, "", null, _line));
        return _tokens;
    }

    private void ScanToken()
    {
        char ch = Advance();
        switch (ch)
        {
            case '(':
                AddToken(TokenType.LeftParenthesis);
                break;
            case ')':
                AddToken(TokenType.RightParenthesis);
                break;
            case '{':
                AddToken(TokenType.LeftBrace);
                break;
            case '}':
                AddToken(TokenType.RightBrace);
                break;
            case ',':
                AddToken(TokenType.Comma);
                break;
            case '.':
                AddToken(TokenType.Dot);
                break;
            case '-':
                AddToken(TokenType.Minus);
                break;
            case '+':
                AddToken(TokenType.Plus);
                break;
            case '*':
                AddToken(TokenType.Star);
                break;
            case ';':
                AddToken(TokenType.Semicolon);
                break;
            case '!':
                if (IsChar('*'))
                {
                    while (Peek() != '\n' && _current < _source.Length)
                    {
                        Advance();
                    }
                }
                else
                {
                    AddToken(IsChar('=') ? TokenType.BangEqual : TokenType.Bang);
                }
                break;
            case '=':
                AddToken(IsChar('=') ? TokenType.EqualEqual : TokenType.Equal);
                break;
            case '<':
                AddToken(IsChar('=') ? TokenType.LessEqual : TokenType.Less);
                break;
            case '>':
                AddToken(IsChar('=') ? TokenType.GreaterEqual : TokenType.Greater);
                break;
            case '/':
                AddToken(TokenType.Slash);
                break;
            case ' ':
            case '\r':
            case '\t':
                break;
            case '\n':
                _line++;
                break;
            default:
                Program.Error(_current, $"Unexpected token '{ch}'");
                break;
        }
        
        Console.WriteLine(_tokens.Last());
    }

    private char Advance()
    {
        return _source[_current++];
    }

    private bool IsChar(char ch)
    {
        if (_current >= _source.Length)
        {
            return false;
        }

        if (_source[_current] != ch)
        {
            return false;
        }
        
        _current++;
        return true;
    }

    private char Peek()
    {
        if (_current >= _source.Length)
        {
            return '\0'; // String terminator
        }
        
        return _source[_current];
    }

    private void AddToken(TokenType type)
    {
        AddToken(type, null);
    }

    private void AddToken(TokenType type, object? literal)
    {
        string text = _source[_start..(_current - 1)];
        _tokens.Add(new Token(type,text, literal, _line));
    }
}