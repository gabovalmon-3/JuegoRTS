using UnityEngine;
/*
 *El script que maneja la construccion de los cubos, llamo a la interfaz de figuras con el metodo de spawn
 * abc
 */

public class BuilderCubos : IFigurasInterfaz
{
    public GameObject prefab; //El cubo desde el edito
    public float tamanhoMinimo = 1f, tamanhoMaximo = 3f; //Las dimensiones minimas del cubo

    public BuilderCubos(GameObject cuboPrefab, float tamanhoMinimo, float tamanhoMaximo) //Constructor
    {
        this.prefab = cuboPrefab;
        this.tamanhoMinimo = tamanhoMinimo;
        this.tamanhoMaximo = tamanhoMaximo;
    }
    
    public void FigurasSpawn(Vector3 PosicionInicial, Transform parent = null) //Llamado al metodo de la interfaz
    {       
        //Generando las dimensiones aleatorias de los cubos
            float anchoCubo = Random.Range(tamanhoMinimo, tamanhoMaximo);
            float altoCubo = Random.Range(tamanhoMinimo, tamanhoMaximo);
            float fondoCubo = Random.Range(tamanhoMinimo, tamanhoMaximo);
        //Generando la instancia de la figura 
            GameObject nuevoCubo = Object.Instantiate(prefab, parent);
            //Cambiando las dimensiones por los randoms y poniendo las posiciones en el suelo
            nuevoCubo.transform.localScale = new Vector3(anchoCubo, altoCubo, fondoCubo);
            nuevoCubo.transform.position = new Vector3(PosicionInicial.x, altoCubo / 2f, PosicionInicial.z);

        }
    }