using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class StarCollector : MonoBehaviour
{
    public Text starText; 
    public string sceneName; 
    private int starCount = 0; 

    private void Start()
    {
        UpdateStarText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Star")) 
        {
            Destroy(other.gameObject); 
            starCount++;
            UpdateStarText(); 

            if (starCount >= 12)
            {
                SceneManager.LoadScene(sceneName); 
            }
        }
    }

    private void UpdateStarText()
    {
        starText.text = "Stars: " + starCount + "/12";
    }
}
