using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public GameObject basePrefab;
    public GameObject recolectorPrefab;
    public GameObject militarPrefab;

    private BuildingFactory currentFactory;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            currentFactory = new BaseFactory(basePrefab);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            currentFactory = new RecolectorFactory(recolectorPrefab);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            currentFactory = new MilitarFactory(militarPrefab);

        if (Input.GetMouseButtonDown(0) && currentFactory != null)
        {
            Vector3 posicion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            posicion.z = 0;
            currentFactory.CrearEdificio(posicion);
        }
    }
}