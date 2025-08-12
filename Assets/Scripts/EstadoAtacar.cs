using UnityEngine;

public class EstadoAtacar : IEstadoUnidadIA
{
    private UnidadMilitar objetivo;
    private float tiempoAtaque = 1.5f;
    private float temporizador = 0f;
    private int danioPorAtaque = 20;
    private bool colorCambiado = false;

    private BasePrincipal basePrincipal;

    public EstadoAtacar(UnidadMilitar unidadObjetivo)
    {
        objetivo = unidadObjetivo;
        basePrincipal = GameObject.FindObjectOfType<BasePrincipal>();
    }

    public void Ejecutar(EnemigoIA contexto)
    {
        if (!colorCambiado)
        {
            contexto.CambiarColor(Color.red);
            colorCambiado = true;
        }

        // Si el objetivo fue destruido
        if (objetivo == null)
        {
            // Buscar otro objetivo cercano
            UnidadMilitar nuevaUnidad = BuscarUnidadCercana(contexto);
            if (nuevaUnidad != null)
            {
                objetivo = nuevaUnidad;
                return;
            }

            // Si no hay unidades, atacar la base
            if (basePrincipal != null)
            {
                float distanciaABase = Vector3.Distance(contexto.transform.position, basePrincipal.transform.position);

                if (distanciaABase > 1.5f)
                {
                    contexto.MoverA(basePrincipal.transform.position);
                }
                else
                {
                    temporizador -= Time.deltaTime;
                    if (temporizador <= 0f)
                    {
                        basePrincipal.RecibirDanio(danioPorAtaque);
                        temporizador = tiempoAtaque;
                    }
                }

                return;
            }

            // No hay nada más que hacer
            contexto.CambiarColor(Color.blue);
            contexto.CambiarEstado(new EstadoPatrullar());
            return;
        }

        // Atacar a la unidad si sigue viva
        float distancia = Vector3.Distance(contexto.transform.position, objetivo.transform.position);

        if (distancia > 10f)
        {
            contexto.CambiarColor(Color.blue);
            contexto.CambiarEstado(new EstadoPatrullar());
        }
        else if (distancia > 1.5f)
        {
            contexto.MoverA(objetivo.transform.position);
        }
        else
        {
            contexto.estrategiaCombate?.Atacar(contexto, objetivo);
        }
    }

    private UnidadMilitar BuscarUnidadCercana(EnemigoIA contexto)
    {
        UnidadMilitar[] unidades = GameObject.FindObjectsOfType<UnidadMilitar>();

        foreach (UnidadMilitar unidad in unidades)
        {
            float distancia = Vector3.Distance(contexto.transform.position, unidad.transform.position);
            if (distancia < 8f)
            {
                return unidad;
            }
        }

        return null;
    }
}
