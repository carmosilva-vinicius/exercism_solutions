using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

static class LogLine
{
    private static readonly List<string> _logLevels = 
        new List<string> { "INFO", "WARNING", "ERROR" };
    
    public static string Message(string logLine)
    {
        string logMessage = "";
        foreach (string l in _logLevels)
            if(logLine.Contains(l))
            {
                int first = l.Length + 4;
                int last = logLine.Length;
                logMessage = logLine
                    .Substring(first, last - first)
                    .Trim();
            }   
        return logMessage;
    }

    public static string LogLevel(string logLine)
    {
        string logLevel = "";
        Match match = Regex.Match(logLine, @"\[(.*?)\]");
        if (match.Success)
            logLevel = match.Groups[1].Value;
        return logLevel.ToLower();
    }

    public static string Reformat(string logLine) =>
        $"{Message(logLine)} ({LogLevel(logLine)})";
}
