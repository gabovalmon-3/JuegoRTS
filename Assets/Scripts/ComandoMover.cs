using UnityEngine;

public class ComandoMover : IComando
{
    private UnidadMilitar unidad;
    private Vector3 destino;

    public ComandoMover(UnidadMilitar unidad, Vector3 destino)
    {
        this.unidad = unidad;
        this.destino = destino;
    }

    public void Ejecutar()
    {
        unidad.MoverA(destino);
    }
}
