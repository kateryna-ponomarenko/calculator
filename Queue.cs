using System;

namespace calculator;

public class Queue
{
    private ArrayList _queue = new ArrayList() ;

    public void Enqueue(string value)
    {
        _queue.Add(value);
    }

    public string Dequeue()
    {
        if (_queue.Count() == 0)
        {
            throw new Exception("is empty");
        }
        
        string firstPosition = _queue.GetAt(0);
        _queue.RemoveAt(0);
        return firstPosition;
    }
    
    public int Count()
    {
        return _queue.Count();
    }
    
    
}

