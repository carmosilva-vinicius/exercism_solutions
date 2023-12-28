using System;

public static class CentralBank
{
    public static string DisplayDenomination(long @base, long multiplier)
    {
      try{
        string result = checked(@base * multiplier).ToString();
        return result;
      }
      catch(OverflowException){
        return "*** Too Big ***";
      }
    }

    public static string DisplayGDP(float @base, float multiplier)
    {
      try{
        float result = checked(@base * multiplier);
        if(result > float.MaxValue){
          return "*** Too Big ***";
        }
        return result.ToString();
      }
      catch(OverflowException){
        return "*** Too Big ***";
      }
    }

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
      try{
        string result = checked(salaryBase * multiplier).ToString();
        return result;
      }
      catch(OverflowException){
        return "*** Much Too Big ***";
      }
    }
}
