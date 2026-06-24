using UnityEngine;
using UnityEngine.UI;

public class Destination : MonoBehaviour
{
    public int maxHealth = 25;
    public int currentHealth;
    [SerializeField] Text healthText;
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateUI();
        Debug.Log(currentHealth);
        if (currentHealth <= 0)
        {
            Debug.Log("游戏失败");
        }
    }
    public void UpdateUI()
    {
        healthText.text = currentHealth.ToString();
    }
}
