using UnityEngine;

public class Rotador : MonoBehaviour
{
    [SerializeField] 
    private float velocidadRotacion = 3.0f; // Speed of rotation
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, velocidadRotacion * Time.deltaTime); // Rotate around the Y axis
    }
}
