using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int oro = 500; // recurso inicial

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public bool GastarOro(int cantidad)
    {
        if (oro >= cantidad)
        {
            oro -= cantidad;
            Debug.Log("Oro restante: " + oro);
            return true;
        }

        Debug.Log("No hay suficiente oro.");
        return false;
    }

    public void GanarOro(int cantidad)
    {
        oro += cantidad;
        Debug.Log("Oro ganado. Total: " + oro);
    }
    
    public void Victoria()
    {
        Debug.Log("¡VICTORIA!");
        Time.timeScale = 0f;

        // Mostrar panel o mensaje si agrego UI
    }
    
    public void Derrota()
    {
        Debug.Log("¡DERROTA!");
        Time.timeScale = 0f; // pausa el juego

        // podría activar un panel de UI
    }

}