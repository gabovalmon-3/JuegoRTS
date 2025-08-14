using UnityEngine;

public class EdificioMilitar : Building
{
    public GameObject prototipoSoldado;
    public Transform puntoSpawn;
    public ControladorUnidades controlador;

    private void Start()
    {
        buildingName = "Edificio Militar";
        cost = 75;
        Construct();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Entrenar presionando "E"
        {
            EntrenarUnidad();
        }
    }

    public void EntrenarUnidad()
    {
        // Obtener el costo desde el prefab
        UnidadMilitar unidad = prototipoSoldado.GetComponent<UnidadMilitar>();
        int costo = unidad != null ? unidad.costoEntrenamiento : 0;

        if (GameManager.Instance.GastarOro(costo))
        {
            GameObject clon = Instantiate(prototipoSoldado, puntoSpawn.position, Quaternion.identity);

            IUnidad nuevaUnidad = clon.GetComponent<IUnidad>();
            nuevaUnidad?.EjecutarAccion();

            UnidadMilitar unidadMilitar = clon.GetComponent<UnidadMilitar>();
        }
        else
        {
            Debug.Log("No tienes suficiente oro para entrenar esta unidad.");
        }
    }

}
