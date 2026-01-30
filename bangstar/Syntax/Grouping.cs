namespace bangstar.Syntax;

public class Grouping(Expr expr) : Expr
{
    public Expr Expr { get; set; } = expr;
}