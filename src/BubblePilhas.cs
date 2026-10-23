using System;

public static class BubblePilhas
{

    public static int[] bubblePilhas(int[] v, out int comparacoes)
    {
        int n = v.Length;
        comparacoes = 0;

        Pilha A = new Pilha(n);
        Pilha B = new Pilha(n);
        Pilha R = new Pilha(n);

        for (int i = 0; i < n; i++)
            A.empilha(v[i]);

        for (int restantes = n; restantes >= 1; restantes--)
        {
            int carry = A.desempilha();

            for (int k = 0; k < restantes - 1; k++)
            {
                int x = A.desempilha();
                comparacoes++;
                if (carry > x)
                {
                    B.empilha(x);          
                }
                else
                {
                    B.empilha(carry);      
                    carry = x;
                }
            }

            R.empilha(carry);              

            Pilha tmp = A; A = B; B = tmp;
        }

        int[] ordenado = new int[n];
        for (int i = 0; i < n; i++)
            ordenado[i] = R.desempilha();
        return ordenado;
    }

  
    public static Pilha ordenaPilha(Pilha p)
    {
        Pilha aux = new Pilha(p.tamanho()); 
        while (!p.vazia())
        {
            int t = p.desempilha();
            while (!aux.vazia() && aux.consultaTopo() > t)
                p.empilha(aux.desempilha());  
            aux.empilha(t);
        }
        return aux;
    }
}
