using System;


namespace calculator;

public class CalculateResult
{
    private Queue _Postfix;
    
    private string[] _operators = { "+","-","*","/","^"};

    public CalculateResult(Queue postfix)
    {
        _Postfix = postfix;
    }


    public double Operation(string operate, double a, double b)
    {
        if (operate  == "+") { return a + b; }
        if (operate == "-") { return a - b; }
        if (operate == "*") { return a * b; }
        if (operate == "/") { return a / b; }
        if  (operate == "^") { return Math.Pow(a, b); }
        return 0;
    }
    
    
    public string Result()
    {
        Stack calculator  = new Stack();

        while (_Postfix.Count() > 0)
        {
            string token = _Postfix.Dequeue();
            
            if (double.TryParse(token, out _ ))
            {
                calculator.Push(token);
            }

            else if (_operators.Contains(token))
            {
                if (calculator.Count < 2) 
                {
                    return "less than 2 in stack"; 
                }
                
                var num1 = double.Parse(calculator.Pop());
                var num2 = double.Parse(calculator.Pop());
                double operation = Operation(token, num2, num1);
                calculator.Push(operation.ToString());
                
            }
            //converting a string (text) into a number - double.Parse
            
            
        }
        
        if (calculator.Count == 0 )return "0";
        return calculator.Pop() ;
    }
}