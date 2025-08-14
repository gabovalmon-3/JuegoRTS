using UnityEngine;

public class UnidadSpawner : MonoBehaviour
{
    public GameObject prototipoUnidad;
    public Transform puntoSpawn;
    public ControladorUnidades controlador; // referencia al invocador

    public void GenerarUnidad()
    {
        GameObject clon = Instantiate(prototipoUnidad, puntoSpawn.position, Quaternion.identity);

        IUnidad unidad = clon.GetComponent<IUnidad>();
        unidad?.EjecutarAccion();

        // Selecciona automáticamente la unidad recién creada
        UnidadMilitar unidadMilitar = clon.GetComponent<UnidadMilitar>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GenerarUnidad();
        }
    }
}
