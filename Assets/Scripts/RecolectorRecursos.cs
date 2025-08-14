using UnityEngine;

public class RecolectorRecursos : Building
{
    public float tiempoEntreRecoleccion = 5f; // cada 5 segundos
    public int cantidadPorRecoleccion = 25;

    private float tiempoActual;

    private void Start()
    {
        buildingName = "Recolector";
        cost = 50;
        Construct();

        tiempoActual = tiempoEntreRecoleccion;
    }

    private void Update()
    {
        tiempoActual -= Time.deltaTime;

        if (tiempoActual <= 0f)
        {
            Recolectar();
            tiempoActual = tiempoEntreRecoleccion;
        }
    }

    private void Recolectar()
    {
        GameManager.Instance.GanarOro(cantidadPorRecoleccion);
        Debug.Log("Recolector produjo " + cantidadPorRecoleccion + " de oro.");
    }
}
