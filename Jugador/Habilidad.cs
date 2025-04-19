using System;

public class Hability 
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public int MaxUses {get ; set; }
    public int RemainingUses { get; set; }

    public Hability(string name, string description , int maxuses = 3)
    {
        Name = name;
        Description = description;
        IsActive = false;
        MaxUses = maxuses;
        RemainingUses = maxuses;
    }

    public virtual bool Active()
    {
       if (RemainingUses <= 0)
       {
         Console.WriteLine($"No te quedan usos de {Name}!");
         return false;
       }

       IsActive = true;
       RemainingUses--;
       Console.WriteLine($"Habilidad '{Name}' activada : {Description}");
       Console.WriteLine($"Usos restantes: {RemainingUses}/{MaxUses}");
       return true;
    }

    public virtual void Desactivate()
    {
        IsActive = false;
        Console.WriteLine($"Habilidad '{Name}' desactivada");
    }
}

public class TrampImmunity : Hability
{
    public TrampImmunity() : base("Inmunidad a Trampas", "Protege  a su jugador dr todas las trampas del laberinto")
    {
    }

    public override bool Active()
    {
       if (base.Active())
       {
         Console.WriteLine("Ahora eres inmune a las trampas!!");
         return true;
       }
       return false;
    }
}

public class ParalysisImmunity : Hability
{
    public DateTime AbilityEndTime { get; private set; }
  public ParalysisImmunity() : base("Inmune a la paralización ", "No puedes quedar paralizado", maxuses: 2)
  {
  }

    public override bool Active()
    {
       if (base.Active()) 
       {
         AbilityEndTime = DateTime.Now.AddSeconds(30);
         Console.WriteLine("Ahora eres inmune a la paralización!!!"); 
         return true;
       }
       return false;
    }

    public override void Desactivate()
    {
        base.Desactivate();
        Console.WriteLine("La inmunidad a la paralización se ha acabado");
    }
}

      public class ReverseTrapImmunity : Hability
  {
        public DateTime? AbilityEndTime {get; private set;}

        public ReverseTrapImmunity() : base("Inmunidad al retroceso", "Protege contra trampas que te hacen retroceder", maxuses: 2)
        {
        }

    public override bool Active()
    {
       if(base.Active())
       {
         AbilityEndTime = DateTime.Now.AddSeconds(30);
         Console.WriteLine("Ahora eres inmune al retroceso");
         return true;
       }
       return false;
    }
     public bool IsAbilityActive()
    {
      if (!AbilityEndTime.HasValue) return false;

      if (DateTime.Now < AbilityEndTime.Value)
      {
          return IsActive;
      }
      else
      {
         Desactivate();
         return false;
      }
     
    }

  } 

  public class HealthImmunity : Hability
  {
    public DateTime AbilityEndTime { get; set; }
     public HealthImmunity() : base("Inmunidad a la pérdida de vidas", "Impide que se te descuenten las vidas", maxuses:3)
     {
     }

    public override bool Active()
    {
        if (base.Active())
        {
           AbilityEndTime = DateTime.Now.AddSeconds(30);
           Console.WriteLine("Ahora eres inmune a la pérdida de vida por trampas!!");
           return true;
        }
         return false;
    }

    public bool IsAbilityActive()
    {
       if (DateTime.Now < AbilityEndTime)
       {
         return IsActive;
       }
       else
       {
         Desactivate();
         return false;
       }
    }

    public override void Desactivate()
    {
        base.Desactivate();
        Console.WriteLine("La inmunidad a la pérdida de vidas se ha acabado");
    }
  }

  public class DoubleMoveAbility : Hability
  {
    public DateTime AbilityEndTime {get ;  private set; }

    public DoubleMoveAbility() : base("Doble movimiento", "Puedes moverte dos casillas por turno", maxuses: 3)
    {
      
    }

    public override bool Active()
    {
        if (base.Active())
        {
          AbilityEndTime = DateTime.Now.AddSeconds(30);
          Console.WriteLine("Doble movimiento activado!! Puedes caminar dos casillas en este turno");
          return true;
        }
        return false;
    }
    public override void Desactivate()
    {
        base.Desactivate();
        Console.WriteLine("Doble movimiento desactivado");
    }

    public bool IsAbilityActive()
    {
      if (DateTime.Now < AbilityEndTime)
      {
        return IsActive;
      }
      else
      {
        Desactivate();
        return false;
      }
    }
  }