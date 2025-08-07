using UnityEngine;

public class BasePrincipal : Building
{
    public int vida = 200;

    private void Start()
    {
        buildingName = "Base Principal";
        cost = 100;
        Construct();
    }

    public void RecibirDanio(int cantidad)
    {
        vida -= cantidad;
        Debug.Log("Base recibió " + cantidad + " de daño. Vida restante: " + vida);

        if (vida <= 0)
        {
            Debug.Log("¡BASE DESTRUIDA!");
            GameManager.Instance.Derrota();
            Destroy(gameObject); 
        }
    }

}
