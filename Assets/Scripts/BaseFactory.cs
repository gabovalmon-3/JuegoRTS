using UnityEngine;

public class BaseFactory : BuildingFactory
{
    private GameObject prefab;

    public BaseFactory(GameObject prefab)
    {
        this.prefab = prefab;
    }

    public override GameObject CrearEdificio(Vector3 posicion)
    {
        int costo = 100;
        if (GameManager.Instance.GastarOro(costo))
        {
            return Object.Instantiate(prefab, posicion, Quaternion.identity);
        }

        return null;
    }
}
