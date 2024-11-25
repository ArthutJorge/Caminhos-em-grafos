using System;

public class NoFila<Dado> where Dado : IComparable<Dado>
{
    protected Dado info;
    NoFila<Dado> prox;

    public NoFila(Dado novaInfo, NoFila<Dado> proximo)
    {
        Info = novaInfo;
        Prox = proximo;
    }

    public NoFila(Dado novaInfo)
    {
        Info = novaInfo;
        Prox = null;
    }
    public Dado Info
    {
        get => info;
        set
        {
            if (value != null)
                info = value;
        }
    }

    public NoFila<Dado> Prox
    {
        get => prox;
        set => prox = value;
    }
}
