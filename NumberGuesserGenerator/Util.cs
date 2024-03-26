namespace NumberGuesserGenerator;

public static class Util
{
    public static (ulong, ulong) GetBounds(string[] args)
    {
        ulong start = 1UL, end = ulong.MaxValue;
        
        if (args.Length > 0)
        {
            try
            {
                start = ulong.Parse(args[0]);
            }
            catch
            {
                start = 1UL;
            }
    
            try
            {
                end = ulong.Parse(args[1]);
            }
            catch
            {
                end = ulong.MaxValue - 1;
            }
        }

        return (start, end);
    }

    // A future version can do something more elaborate. This works for now.
    public static ulong GenerateSeed(ulong gameNumber) => gameNumber;

    public static string GetVersion() =>
        typeof(Util).Assembly.GetName().Version?.ToString() ?? "UNKNOWN";
}