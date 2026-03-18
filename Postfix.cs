using System;

namespace calculator;

public class Postfix
{
    private Tokens _tokens;
    private string _example;
    
    
    public Postfix(Tokens tokens, string example)
    {
        _tokens = tokens;
        _example = example;
    }
    
    public int GetPriority(string symbol)
    {
        if (symbol == "+" || symbol == "-")
        {
            return 2;
        }
        else if (symbol == "*" || symbol == "/")
        {
            return 3;
        }
        else if (symbol == "^")
        {
            return 4;
        }
        else if (symbol == "(")
        {
            return 1;
        }
        return 0;
    }

    public static bool IsOperator(string symbol)
    {
        return symbol == "+" || symbol == "-" || symbol == "*" || symbol == "/";
    }
    
    
    public Queue ShuntingYardAlgorithm()
    {
        
        Stack stack = new Stack();
        Queue queue = new Queue();
        
        Queue inputTokens = _tokens.DivisionForTokens(_example);
        
        string previousToken = "";
        
        
        while (inputTokens.Count() > 0)
        {
            string token = inputTokens.Dequeue();
            
            // tryParse перевіряє, чи є рядок числом, враховуючи багатозначність та роздільники (крапки/коми).
            // out _ дозволяє перевірити тип, не зберігаючи результат у змінну
            // if num
            if (double.TryParse(token, out _))
            {
                queue.Enqueue(token);
            }
            
            // if operator
            if (IsOperator(token))
            {
                if (stack.Count == 0 || stack.Peek() == "("){stack.Push(token);}
                else if (GetPriority(stack.Peek()) < GetPriority(token) && stack.Count > 0)
                {
                    stack.Push(token);
                }
                else if (GetPriority(stack.Peek()) >= GetPriority(token))
                {
                    while (stack.Count > 0 && GetPriority(stack.Peek()) >= GetPriority(token) && stack.Peek() != "(")
                    {
                        queue.Enqueue(stack.Pop());
                    }
                    stack.Push(token);
                }
            }
            //if )
            if (token == "(")
            {
                if (double.TryParse(previousToken, out _) && !string.IsNullOrEmpty(previousToken))
                {
                    throw new Exception("dont have operator between num and ( ");
                }
                else
                {
                    stack.Push(token);
                }
            }
            //if (
            if (token == ")")
            {
                while (stack.Count > 0 && stack.Peek() != "(")
                {
                    queue.Enqueue(stack.Pop());
                }
                stack.Pop();
            }
            
            previousToken = token;
        }
        
        while (stack.Count > 0)
        {
            queue.Enqueue(stack.Pop());
        }
        return queue;
    }
}
