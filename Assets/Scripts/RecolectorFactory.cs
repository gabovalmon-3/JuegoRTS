using UnityEngine;

public class RecolectorFactory : BuildingFactory
{
    private GameObject prefab;

    public RecolectorFactory(GameObject prefab)
    {
        this.prefab = prefab;
    }

    public override GameObject CrearEdificio(Vector3 posicion)
    {
        int costo = 25;
        if (GameManager.Instance.GastarOro(costo))
        {
            return Object.Instantiate(prefab, posicion, Quaternion.identity);
        }

        return null;
    }
}