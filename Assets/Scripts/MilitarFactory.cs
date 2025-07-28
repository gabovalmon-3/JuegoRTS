using UnityEngine;

public class MilitarFactory : BuildingFactory
{
    private GameObject prefab;

    public MilitarFactory(GameObject prefab)
    {
        this.prefab = prefab;
    }

    public override GameObject CrearEdificio(Vector3 posicion)
    {
        int costo = 50;
        if (GameManager.Instance.GastarOro(costo))
        {
            return Object.Instantiate(prefab, posicion, Quaternion.identity);
        }

        return null;
    }
}