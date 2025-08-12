using UnityEngine;
using TMPro;

public class UIRecursosTMP : MonoBehaviour
{
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

        int cantidadE = GameObject.FindObjectsOfType<EnemigoIA>().Length;
        textoEnemigos.text = "Enemigos: " + cantidadE;
        
        textoOleada.text = "Oleada: " + oleadas.oleadaActual;
    }
    
}
