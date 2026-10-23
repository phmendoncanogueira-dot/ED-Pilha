using System;

/// <summary> </summary>
public static class UsosPilha
{

    public static string inverte(string s)
    {
        Pilha p = new Pilha(s.Length);
        foreach (char c in s)
            p.empilha(c);               
        char[] resultado = new char[s.Length];
        int i = 0;
        while (!p.vazia())
            resultado[i++] = (char)p.desempilha();
        return new string(resultado);
    }

  
    public static bool balanceado(string expr)
    {
        Pilha p = new Pilha(expr.Length);
        foreach (char c in expr)
        {
            if (c == '(' || c == '[' || c == '{')
            {
                p.empilha(c);
            }
            else if (c == ')' || c == ']' || c == '}')
            {
                if (p.vazia()) return false;          
                char abre = (char)p.desempilha();
                if (!casam(abre, c)) return false;   
            }
        }
        return p.vazia();                             
    }

    private static bool casam(char abre, char fecha)
    {
        return (abre == '(' && fecha == ')') ||
               (abre == '[' && fecha == ']') ||
               (abre == '{' && fecha == '}');
    }
}
