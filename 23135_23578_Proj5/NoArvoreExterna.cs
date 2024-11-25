using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

  public class NoArvoreExterna<Dado> : IComparable<NoArvoreExterna<Dado>> 
                                where Dado : IComparable<Dado>, 
                                             IRegistro, 
                                             new()
  {
    Dado info;
    NoArvoreExterna<Dado> esq, dir;

    public NoArvoreExterna()
    {
      info = default(Dado);
      esq = dir = null;
    }

    public NoArvoreExterna(Dado informacao)
    {
      info = informacao;
      esq = dir = null;
    }

    public NoArvoreExterna(Dado informacao,  NoArvoreExterna<Dado> e,
                                      NoArvoreExterna<Dado> d)
    {
      info = informacao;
      esq = e;
      dir = d;
    }
    public Dado Info 
    { get => info; set => info = value; }
    public NoArvoreExterna<Dado> Esq 
    { get => esq; set => esq = value; }
    public NoArvoreExterna<Dado> Dir 
    { get => dir; set => dir = value; }

    public int CompareTo(NoArvoreExterna<Dado> outro)
    {
      if (outro != null)
         return this.info.CompareTo(outro.info);

      return -1;
    }

    public bool Equals(NoArvoreExterna<Dado> outro)
    {
      return this.info.Equals(outro.info);
    }

  }

