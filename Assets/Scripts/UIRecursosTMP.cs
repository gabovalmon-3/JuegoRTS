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


    [SerializeField] private TMP_Text textoOro;
    [SerializeField] private TMP_Text textoUnidades;
    [SerializeField] private TMP_Text textoEnemigos;
    [SerializeField] private OleadasManager oleadas;
    [SerializeField] private TMP_Text textoOleada;

    public TMP_Text TextoOro => textoOro;
    public TMP_Text TextoUnidades => textoUnidades;
    public TMP_Text TextoEnemigos => textoEnemigos;
    public OleadasManager Oleadas => oleadas;
    public TMP_Text TextoOleada => textoOleada;

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

    
}
