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
    
    private Stack _stack = new Stack();
    private Queue _queue = new Queue();

    public void ShuntingYardAlgorithm()
    {
        while (_tokens.DivisionForTokens(_example).Count() > 0)
        {
            string token =_tokens.DivisionForTokens(_example).Dequeue();
            // tryParse перевіряє, чи є рядок числом, враховуючи багатозначність та роздільники (крапки/коми).
            // out _ дозволяє перевірити тип, не зберігаючи результат у змінну
            if (double.TryParse(token, out _))
            {
                _queue.Enqueue(token);
            }

            else if(_tokens.operators.Contains(token))
            {
                
            }
        }
        
    }
}