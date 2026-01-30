namespace bangstar.Syntax;

public class Literal(Object value) : Expr
{
    public Object Value { get; set; } = value;
}