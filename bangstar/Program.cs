using bangstar.Tokens;

namespace bangstar;

class Program
{
    private static Tokenizer _tokenizer;
    private static bool _hadError;
    
    public static void Main(string[] args)
    {
        if (args.Length > 1)
        {
            Console.WriteLine("Usage: bangstar [script]");
        }
        else if (args.Length == 1)
        {
            RunFile(args[0]);
        }
        else
        {
            RunPrompt();
        }
    }

    private static void RunFile(string script)
    {
        byte[] scriptBytes = File.ReadAllBytes(script);
        Run(System.Text.Encoding.UTF8.GetString(scriptBytes));
        if (_hadError)
        {
            Environment.Exit(65);
        }
    }

    private static void RunPrompt()
    {
        while (true)
        {
            Console.Write("> ");
            string? line = Console.ReadLine();
            if (line == null)
            {
                break;
            }
            Run(line);
            _hadError = false;
        }
    }

    private static void Run(string source)
    {
        _tokenizer = new Tokenizer(source);
        _tokenizer.ScanTokens();
    }

    public static void Error(int line, string message)
    {
        Report(line, "", message);
    }

    private static void Report(int line, string where, string message)
    {
        Console.WriteLine($"[line {line}] Error {where}: {message}");
        _hadError = true;
    }
}