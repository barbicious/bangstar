namespace bangstar.Tokens;

public enum TokenType
{
    LeftParenthesis, RightParenthesis, LeftBrace, RightBrace, Comma, Dot,
    Minus, Plus, Star, Slash, Semicolon,
    
    Bang, BangEqual,
    Equal, EqualEqual,
    Greater, GreaterEqual,
    Less, LessEqual,
    
    Identifier, Number, String,
    
    And, Or, If, Null, True, False, This, While, For,
    Method, Class, Else, Super, Return, Variable, Write,
    
    Eof,
}