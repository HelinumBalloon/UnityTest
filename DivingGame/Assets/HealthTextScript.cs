using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HealthTextScript : MonoBehaviour
{
    // TestMeshProUGUI is textmeshpro's type to be called
    public TextMeshProUGUI healthText;
    public int health = 100;
    public void loseHealth(int amount)
    {
        health -= amount;
        healthText.text = health.ToString();
    }
}
