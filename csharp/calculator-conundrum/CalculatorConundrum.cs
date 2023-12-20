public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string operation) =>
        operation switch
        {
            "+" => $"{operand1} {operation} {operand2} = {operand1 + operand2}",
            "*" => $"{operand1} {operation} {operand2} = {operand1 * operand2}",
            "/" => operand2 == 0? "Division by zero is not allowed."
                : $"{operand1} {operation} {operand2} = {operand1 / operand2}",
            "" => throw new System.ArgumentException("Operation cannot be empty", "operation"),
            null => throw new System.ArgumentNullException("operation", "Operation cannot be null"),
            _ => throw new System.ArgumentOutOfRangeException("operation", "Unknown operation")
        };
}
