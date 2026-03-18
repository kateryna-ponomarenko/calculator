using System;

namespace calculator;

public class Tokens
{

    private string _buffer = "";
    // public Queue QueueForTokens { get; private set; } = new Queue();
    
    private string[] _operators = { "+","-","*","/",")","(","^"};

    public Queue DivisionForTokens(string example)
    {
        
        Queue QueueForTokens = new Queue();

        if (example.Equals(string.Empty))
        {
            throw  new ArgumentException("example is empty");
        }
        
     
        
        
        
        foreach (var symbol in example)
        {
            char element = symbol;
            bool isNumber = char.IsNumber(element);
            if (isNumber.Equals(true))
            {
                _buffer += element;
            }

            else if (symbol.Equals(' '))
            {
                if (_buffer.Length > 0)
                {
                    QueueForTokens.Enqueue(_buffer);
                    _buffer = "";
                }
                
            }

            else if (_operators.Contains(symbol.ToString()))
            {
                if (_buffer.Length > 0)
                {
                    QueueForTokens.Enqueue(_buffer);
                    _buffer = "";
                }
                
                // if prev == perator 
                
                
                QueueForTokens.Enqueue(symbol.ToString());
            }
            
        }

        if (_buffer.Length > 0)
        {
            QueueForTokens.Enqueue(_buffer);
        }
        return QueueForTokens;
    }
    
    
}
