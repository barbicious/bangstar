using bangstar.Tokens;

namespace bangstar.Syntax;

public class Unary(Token @operator, Expr expr) : Expr
{
    public Token Operator { get; set; } = @operator;
    public Expr Expr { get; set; } = expr;
}