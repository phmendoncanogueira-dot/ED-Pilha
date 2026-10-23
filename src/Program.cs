using System;

public class Program
{
    static void Main()
    {
        Console.WriteLine("=== Parte 1: teste da Pilha ===");
        Pilha p = new Pilha(5);
        p.empilha(1); p.empilha(3); p.empilha(5); p.empilha(7);
        p.mostra();                              
        Console.WriteLine(p.desempilha());       
        Console.WriteLine(p.consultaTopo());    
        p.empilha(8); p.empilha(9);
        p.mostra();                            
        Console.WriteLine(p.cheia());         
        try { p.empilha(2); }
        catch (Exception e) { Console.WriteLine(e.Message); } 

        Pilha vz = new Pilha(2);
        try { vz.desempilha(); }
        catch (Exception e) { Console.WriteLine(e.Message); } 
        try { vz.consultaTopo(); }
        catch (Exception e) { Console.WriteLine(e.Message); } 

        Console.WriteLine("\n=== Parte 2: rastreio (confira com a tabela) ===");
        Pilha r = new Pilha(4);
        r.empilha(10); Passo("empilha(10)", r);
        r.empilha(20); Passo("empilha(20)", r);
        Console.WriteLine("  desempilha() -> " + r.desempilha()); Passo("", r);
        r.empilha(30); Passo("empilha(30)", r);
        r.empilha(40); Passo("empilha(40)", r);
        Console.WriteLine("  desempilha() -> " + r.desempilha()); Passo("", r);
        Console.WriteLine("  desempilha() -> " + r.desempilha()); Passo("", r);
        r.empilha(50); Passo("empilha(50)", r);

        Console.WriteLine("\n=== Parte 3.1: inverte ===");
        Console.WriteLine(UsosPilha.inverte("PUCMINAS"));   

        Console.WriteLine("\n=== Parte 3.2 (opcional): balanceado ===");
        string[] exprs = { "(a+b)*[c-d]", "{[()]}", "((a)", "a+b)", "([)]" };
        foreach (string e in exprs)
            Console.WriteLine($"{e,-14} -> {UsosPilha.balanceado(e).ToString().ToLower()}");

        Console.WriteLine("\n=== Parte 4: Bubble Sort com pilhas ===");
        Testa(new int[] { 5, 2, 9, 1, 7 });
        Testa(new int[] { 1, 2, 3, 4, 5 });   

        Console.WriteLine("\n=== Desafio: ordenaPilha ===");
        Pilha d = new Pilha(6);
        foreach (int x in new int[] { 4, 9, 1, 7, 3, 8 }) d.empilha(x);
        Console.Write("Antes : "); d.mostra();
        Pilha ord = BubblePilhas.ordenaPilha(d);
        Console.Write("Depois: "); ord.mostra();  
    }

    static void Passo(string op, Pilha p)
    {
        if (op != "") Console.Write("  " + op);
        Console.Write("  pilha = "); p.mostra();
        Console.WriteLine("  tamanho/topo = " + p.tamanho());
    }

    static void Testa(int[] v)
    {
        int comp;
        int[] o = BubblePilhas.bubblePilhas(v, out comp);
        Console.WriteLine($"Entrada: [{string.Join(", ", v)}]  Saída: [{string.Join(", ", o)}]  Comparações: {comp}");
    }
}
