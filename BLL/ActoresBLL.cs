using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Clase2_Registro.DAL;
using Clase2_Registro.Entidades;
public class ActoresBLL
{

    /// <summary>
    /// Permite guardar(modificar/insertar) una entidad(actor) en la base de datos, verificando si ya existia o si es nueva.
    ///</summary>
    ///<param name ="actor">Es la entidad(actor) que se desea insertar.</param>
    public static bool Guardar(Actores actor)
    {

        if(!Existe(actor.ActorId))
        {
            return Insertar(actor);
        }
        else
        {
            return Modificar(actor);
        }
    }

    /// <summary>
    /// Permite insertar una entidad(actor) en la base de datos.
    ///</summary>
    ///<param name ="actor">Es la entidad(actor) que se desea insertar.</param>
    private static bool Insertar(Actores actor)
    {
        Contexto contexto = new Contexto();
        bool insertado = false;

        try
        {
            contexto.Actores.Add(actor);
            insertado  = contexto.SaveChanges() > 0;
        }
        catch(Exception)
        {
            throw;
        }
        finally
        {
            contexto.Dispose();
        }

        return insertado;
    }

    /// <summary>
    /// Permite modificar una entidad(actor) en la base de datos.
    ///</summary>
    ///<param name ="actor">Es la entidad(actor) que se desea modificar.</param>
    private static bool Modificar(Actores actor)
    {
        Contexto contexto = new Contexto();
        bool modificado = false;

        try
        {
            contexto.Entry(actor).State = EntityState.Modified;
            modificado  = contexto.SaveChanges() > 0;
        }
        catch(Exception)
        {
            throw;
        }
        finally
        {
            contexto.Dispose();
        }

        return modificado;
    }

    /// <summary>
    /// Permite buscar una entidad(actor) en la base de datos.
    ///</summary>
    ///<param name ="id"> Es el ID de la entidad(actor) que desea buscar</param>
    public static Actores Buscar(int id)
    {
        Contexto contexto = new Contexto();
        Actores actor;

        try
        {
            actor = contexto.Actores.Find(id);
        }
        catch(Exception)
        {
            throw;
        }
        finally
        {
            contexto.Dispose();
        }

        return actor;
    }

    /// <summary>
    /// Permite eliminar una entidad(actor) en la base de datos.
    ///</summary>
    ///<param name ="id"> Es el ID de la entidad(actor) que desea buscar</param>
    public static bool Eliminar(int id)
    {
        Contexto contexto = new Contexto();
        bool eliminado = false;

        try
        {
            var actor = contexto.Actores.Find(id);
            if(actor != null)
            {
                contexto.Actores.Remove(actor);
                eliminado = contexto.SaveChanges() > 0;
            }
        }
        catch(Exception)
        {
            throw;
        }
        finally
        {
            contexto.Dispose();
        }

        return eliminado;
    }
    
    /// <summary>
    /// Permite verificar la existencia de una entidad(actor) con ese ID en la base de datos.
    ///</summary>
    ///<param name ="id"> Es el ID de la entidad(actor) que desea buscar</param>
    public static bool Existe(int id)
    {
        Contexto contexto = new Contexto();
        bool existe = false;

        try
        {
            existe = contexto.Actores.Any(e => e.ActorId == id);
        }
        catch(Exception)
        {
            throw;
        }
        finally
        {
            contexto.Dispose();
        }

        return existe;
    }
}