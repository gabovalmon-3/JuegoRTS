using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 *  El script que se encarga de aparecer los recursos en el plane, como el de las figuras, los reparte en posiciones aleatorias
 * El tamaño de los grupos lo hace el builder de recursos
 * 
 * 
 */
public class DirectorRecursos : MonoBehaviour
{
        public float anchoPlane = 50f;
        public float largoPlane = 50f;
        public int cantidadDeGrupos = 10;

        public GameObject spherePrefab;
        public GameObject capsulePrefab;

        private List<Vector3> usedPositions = new List<Vector3>();

      //Para que los grupos aparezcan junto con los obstaculos creo un spawner con delay
        void Start()
        {
            StartCoroutine(DelayedStart());
        }
        
        IEnumerator DelayedStart()
        {
            yield return new WaitForSeconds(0.1f); 
            SpawnResources();
        }
        //LLamo a los objects, se asignan en el editor 
        void SpawnResources()
        {
            BuilderRecursos ComidaBuilder = new BuilderRecursos(spherePrefab, TipoRecurso.Comida);
            BuilderRecursos MetalBuilder = new BuilderRecursos(capsulePrefab, TipoRecurso.Metal);

            List<BuilderRecursos> builders = new List<BuilderRecursos> { ComidaBuilder, MetalBuilder };

            for (int i = 0; i < cantidadDeGrupos; i++)
            {
                
                BuilderRecursos builder = builders[Random.Range(0, builders.Count)];
                
                int TamanhoGrupo = GenerarGruposAleatorios();
                
                
                Vector3? posicion = PosicionarRecursos(TamanhoGrupo);

                if (posicion.HasValue)
                {
                    builder.SpawnResourceGroup(posicion.Value, TamanhoGrupo, this.transform);
                }
            }
        }
        //Los groupos con tamaños aleatorios en los rangos definidos anteriormente
        int GenerarGruposAleatorios()
        {
            int[] tamanhos = { 1, 3, 5 };
            return tamanhos[Random.Range(0, tamanhos.Length)];
        }
        //La funcion para colocar los grupos en el plane 
        Vector3? PosicionarRecursos(int TamanhoGrupo)
        {
            int intentos = 100;
            //float checkRadius = TamanhoGrupo * 2f;
            
            while (intentos-- > 0)
            {
                Vector3 pos = new Vector3(
                    Random.Range(-anchoPlane / 2f, anchoPlane / 2f),
                    0,
                    Random.Range(-largoPlane / 2f, largoPlane / 2f)
                );

               
                {
                    usedPositions.Add(pos);
                    return pos;
                }
            }

            return null;
        }
    

}
