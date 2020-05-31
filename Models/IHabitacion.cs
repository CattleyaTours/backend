using System;

public abstract class IHabitacion
{
    TipoHabitacion TipoHabitacion { get; }
    int capacidad { get; }
}

public class HabitacionSencilla : IHabitacion
{
    public TipoHabitacion TipoHabitacion => TipoHabitacion.HabitacionSencilla; 

    public int capacidad => 1;
}

internal class HabitacionDoble : IHabitacion
{
    public TipoHabitacion TipoHabitacion => TipoHabitacion.HabitacionDoble; 

    public int capacidad => 2;
}

internal class HabitacionFamiliar : IHabitacion
{
    public TipoHabitacion TipoHabitacion => TipoHabitacion.HabitacionFamiliar; 

    public int capacidad => 4;
}

internal class Suite : IHabitacion
{
    public TipoHabitacion TipoHabitacion => TipoHabitacion.Suite; 

    public int capacidad => 8;
}

public enum TipoHabitacion
{
    HabitacionSencilla,
    HabitacionDoble,
    HabitacionFamiliar,
    Suite
}


public class HabitacionFactory
{
    public IHabitacion Create(TipoHabitacion th)
    {
        switch (th)
        {
            case TipoHabitacion.HabitacionSencilla : 
                return new HabitacionSencilla();
            case TipoHabitacion.HabitacionDoble : 
                return new HabitacionDoble();
            case TipoHabitacion.HabitacionFamiliar : 
                return new HabitacionFamiliar();
            case TipoHabitacion.Suite : 
                return new Suite();
            default:
                throw new NotImplementedException();
        }
    }
}
