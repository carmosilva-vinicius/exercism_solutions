using System;
using System.Text;
using System.Text.RegularExpressions;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        identifier = identifier.Replace(' ', '_');
        identifier = identifier.Replace("\0", "CTRL");
        identifier = Regex.Replace(identifier, "[α-ω]", "");

        if(identifier.Contains('-'))
        {
            int index = identifier.IndexOf('-');
            var array = identifier.ToCharArray();
            array[index + 1] = Char.ToUpper(array[index + 1]);
            identifier = new string(array);
            identifier = identifier.Replace("-", "");
        }
   
        StringBuilder sb = new StringBuilder();
        foreach (char c in identifier){
            if(Char.IsLetter(c) || c == '_')
                sb.Append(c);
        }
        identifier = sb.ToString();
        
        return identifier;
    }
}
