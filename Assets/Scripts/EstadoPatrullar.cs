using UnityEngine;

public class EstadoPatrullar : IEstadoUnidadIA
{
    private Vector3 destinoActual;

    public void Ejecutar(EnemigoIA contexto)
    {
        if (destinoActual == Vector3.zero || Vector3.Distance(contexto.transform.position, destinoActual) < 0.2f)
        {
            destinoActual = contexto.ObtenerSiguientePunto().position;
        }

        contexto.MoverA(destinoActual);
    }
}
