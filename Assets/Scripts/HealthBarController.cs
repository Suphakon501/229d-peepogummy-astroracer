using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Slider healthSlider; 
    public void SetHealth(int health)
    {
        healthSlider.value = health;
    }
}
