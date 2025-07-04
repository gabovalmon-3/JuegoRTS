using UnityEngine;
/*
 *El spawner de las figuras en el mapa
 * 
 */
public interface IFigurasInterfaz
{
    void FigurasSpawn(Vector3 posicionInicial, Transform parent = null);
}
