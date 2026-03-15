namespace calculator;

public class Stack
{
    private const int Capacity = 50;

    private string[] _array = new string[Capacity];

    private int _pointer;

    public void Push(string value)
    {
        if (_pointer == _array.Length)
        {
            throw new Exception("Stack overflowed");
        }

        _array[_pointer] = value;
        _pointer++;
    }

    public string Pull()
    {
        if (_pointer == 0)
        {
            return null;
        }

        var value = _array[_pointer];
        _pointer--;
        return value;
    }
    
    // create pop & peek

    public string Pop()
    {
        if (_pointer <= 0)
        {
            throw new Exception("nothing in Stack");
        }
        
        _pointer--;
        var value = _array[_pointer];
        _array[_pointer] = string.Empty;
        
        return value;
    }

    public string Peek()
    {
        if (_pointer <= 0)
        {
            throw new Exception("nothing in Stack");
        }
        
        return _array[_pointer - 1];
    }
    
    
    
}
