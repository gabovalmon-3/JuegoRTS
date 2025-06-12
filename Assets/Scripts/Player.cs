using UnityEngine;
using UnityEngine.UI; // Import the UI namespace to access UI components like Slider
public class Player : MonoBehaviour

{
    private Slider slider; // Reference to the Slider component
    private int vida = 100; // Variable to hold the player's health
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        slider = GetComponent<Slider>(); // Get the Slider component attached to this GameObject
        PonerVidaMaxima(); // Set the maximum health value at the start

    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) // Check if the space key is pressed
        {
            vida -= 5; // Reduce the player's health by 5
            PonerVida(vida); // Call the method to receive damage
        }
    }

    private void PonerVidaMaxima()
    {
        slider.maxValue = vida; // Set the maximum value of the slider to 100
        slider.value = vida; // Set the current value of the slider to 100
    }

    private void PonerVida(int pVida)
    {
        slider.value = pVida; // Set the current value of the slider to vida
    }

}
