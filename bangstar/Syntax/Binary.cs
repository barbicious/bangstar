using bangstar.Tokens;

namespace bangstar.Syntax;

public class Binary(Expr left, Token @operator, Expr right) : Expr
{
    public Expr Left { get; set; } = left;
    public Token Operator { get; set; } = @operator;
    public Expr Right { get; set; } = right;
}