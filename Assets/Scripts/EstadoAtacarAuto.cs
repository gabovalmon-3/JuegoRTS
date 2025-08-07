using UnityEngine;

public class EstadoAtacarAuto : IEstadoUnidadJugador
{
    public void Ejecutar(UnidadMilitar unidad)
    {
        EnemigoIA[] enemigos = GameObject.FindObjectsOfType<EnemigoIA>();

        foreach (var enemigo in enemigos)
        {
            float distancia = Vector3.Distance(unidad.transform.position, enemigo.transform.position);

            if (distancia < 4f)
            {
                Debug.Log(unidad.tipoUnidad + " ataca automáticamente a " + enemigo.name);
                enemigo.RecibirDanio(10); // si querés, implementamos vida para enemigos también
                return;
            }
        }

        unidad.CambiarEstado(new EstadoIdle());
    }
}