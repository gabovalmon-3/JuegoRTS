using UnityEngine;
using TMPro;

public class UIRecursosTMP : MonoBehaviour
{
    public TMP_Text textoOro;
    public TMP_Text textoUnidades;
    public TMP_Text textoEnemigos;
    public OleadasManager oleadas;
    public TMP_Text textoOleada;
    void Start()
    {
        GameManager.Instance.OnEnemigosVivosChange += ActualizarEnemigos;
        ActualizarEnemigos(GameManager.Instance.EnemigosVivos);
    }

    void OnDestroy()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnEnemigosVivosChange -= ActualizarEnemigos;
        }
    }

    void Update()
    {
        textoOro.text = "Oro: " + GameManager.Instance.oro;

        int cantidadU = UnidadMilitar.unidadesAliadas.Count;
        textoUnidades.text = "Unidades: " + cantidadU;

        textoOleada.text = "Oleada: " + oleadas.oleadaActual;
    }

    void ActualizarEnemigos(int cantidad)
    {
        textoEnemigos.text = "Enemigos: " + cantidad;
    }

}