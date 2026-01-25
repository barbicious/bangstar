using bangstar.Tokens;

namespace bangstar.Syntax;

public class Binary : Expr
{
    private readonly Expr _left;
    private readonly Token _operator;
    private readonly Expr _right;
}