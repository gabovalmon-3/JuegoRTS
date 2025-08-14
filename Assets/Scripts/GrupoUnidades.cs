using System.Collections.Generic;
using UnityEngine;

public class GrupoUnidades : IUnidadEjecutable
{
    private List<IUnidadEjecutable> miembros = new List<IUnidadEjecutable>();

    public void AgregarUnidad(IUnidadEjecutable unidad)
    {
        miembros.Add(unidad);
    }

    public void LimpiarGrupo()
    {
        miembros.Clear();
    }

    public void MoverA(Vector3 destino)
    {
        Debug.Log("Grupo se mueve a: " + destino + " con " + miembros.Count + " unidades");

        foreach (var unidad in miembros)
        {
            unidad.MoverA(destino);
        }
    }
    
    public void Seleccionar(bool estado)
    {
        foreach (var unidad in miembros)
        {
            unidad.Seleccionar(estado);
        }
    }
}
