using System.Collections.Generic;
using UnityEngine;
/*
 *El script que genera las figuras en el mapa(cubo y cilindros) 
 * 
 */
public class BuilderFiguras : MonoBehaviour
{
    //Los campos en el editor, se pueden cambiar para definir el tamaño del mapa y las caracteristicas de las figuras
    [Header("Settings Figuras")] 
    public float anchoPlane = 50f;
    public float largoPlane = 50f;
    public int cantidadDeGrupos = 10;
    public int GruposMinimos = 1;
    public int GruposMaximos = 5;
    
    // Lista de constructores de figuras que implementan la interfaz IFigurasInterfaz
    private List<IFigurasInterfaz> figuras = new List<IFigurasInterfaz>();

    // Permite registrar un nuevo constructor (ej. BuilderCubos o BuilderCilindro)
    public void RegisterBuilder(IFigurasInterfaz builder)
    {
        figuras.Add(builder);
    }

    void Start()
    {
        // Por cada figura registrada
        foreach (IFigurasInterfaz builder in figuras)
        {
            // Se generan múltiples grupos según el valor de cantidadDeGrupos
            for (int i = 0; i < cantidadDeGrupos; i++)
            {
                GruposSpawn(builder);// Genera un grupo de figuras
            }
            
        }
    }
    // Genera un grupo de figuras usando un constructor específico
    void GruposSpawn(IFigurasInterfaz builder)
    {
        // Número aleatorio de figuras en este grupo
        int conteo = Random.Range(GruposMinimos, GruposMaximos +1);
        // Posición inicial aleatoria dentro del área especificada
        Vector3 posicionInicial = new Vector3(
            Random.Range(-anchoPlane / 2f, anchoPlane / 2f), 0, Random.Range(-largoPlane / 2f, largoPlane / 2f)
        );
        Vector3 posicionActual = posicionInicial;
        // Crea cada figura dentro del grupo
        for (int i = 0; i < conteo; i++)
        {
            // Instancia una figura en la posición actual y la coloca como hija del objeto que tiene este script
            builder.FigurasSpawn(posicionActual, this.transform);
            posicionActual += new Vector3(2f, 0, 0);  // Mueve la posición actual 2 unidades a la derecha para la próxima figura

        }
    }
}
