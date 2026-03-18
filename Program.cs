using System;

namespace calculator;

class Program
{
    static void Main(string[] args)
    {
        Tokens tokens = new Tokens();
        // tokens.DivisionForTokens("9 + 7 ");

        Postfix postfix = new Postfix(tokens,"7*8+(5 + 9) ");
        
        Queue queue = postfix.ShuntingYardAlgorithm(); //??
        CalculateResult calculateResult = new CalculateResult(queue);
        string res = calculateResult.Result();
        Console.WriteLine(res);





    }
}
