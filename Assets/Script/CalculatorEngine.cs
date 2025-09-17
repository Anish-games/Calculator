using System;
using System.Data;

public class CalculatorEngine
{
    private string expression = "";
    private string lastResult = "";
    private bool justCalculated = false;

    public void AddNumber(string number)
    {
        if (justCalculated)
        {
            expression = "";
            justCalculated = false;
        }
        expression += number;
    }

    public void AddOperator(string op)
    {
        if (justCalculated)
        {
            expression = lastResult;  // continue from result
            justCalculated = false;
        }

        if (expression.Length > 0)
        {
            expression += " " + op + " ";
        }
    }

    public void Clear()
    {
        expression = "";
        lastResult = "";
        justCalculated = false;
    }

    public string GetExpression()
    {
        return expression;
    }

    public string GetResult()
    {
        try
        {
            string safeExpression = expression.Replace("×", "*").Replace("÷", "/");
            var result = new DataTable().Compute(safeExpression, "");
            lastResult = result.ToString();
            justCalculated = true;
            return lastResult;
        }
        catch
        {
            return "Error";
        }
    }
}
