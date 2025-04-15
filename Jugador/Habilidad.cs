using System;

public class Hability 
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }

    public Hability(string name, string description)
    {
        Name = name;
        Description = description;
        IsActive = false;
    }

    public virtual void Active()
    {
        IsActive = true;
        Console.WriteLine($"Habilidad '{Name}' actividad: {Description}");
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

    public override void Active()
    {
        base.Active();
        Console.WriteLine("Ahora eres inmune a las trampas!!");
    }
}