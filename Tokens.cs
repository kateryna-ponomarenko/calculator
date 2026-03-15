namespace calculator;

public class Tokens
{

    private string _buffer = "";
    public Queue QueueForTokens { get; private set; } = new Queue();
    
    public string[] operators = { "+","-","*","/",")","(","^"};

    public Queue DivisionForTokens(string example)
    {
        if (example.Equals(string.Empty))
        {
            throw  new ArgumentException("example is empty");
        }
        
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // від'ємні числа and + 1 -5 + else for letters = tryparse
        
        
        
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
                continue;
            }

            else if (operators.Contains(symbol.ToString()))
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