using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Destination : MonoBehaviour
{
    public int maxHealth = 25;
    public int currentHealth;
    [SerializeField] Text healthText;
    [SerializeField] GameObject missionFailedPrefab;
    [SerializeField] Transform canvasTransform;
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateUI();
        Debug.Log(currentHealth);
        if (currentHealth <= 0)
        {
            Failed();
        }
    }
    public void UpdateUI()
    {
        healthText.text = currentHealth.ToString();
    }
    private void Failed()
    {
        Instantiate(missionFailedPrefab, canvasTransform);
        Time.timeScale = 0;
        StartCoroutine(FailedCoroutine());
    }
    System.Collections.IEnumerator FailedCoroutine()
    {
        yield return new WaitForSecondsRealtime(3f);
        Time.timeScale = 1;
        SceneManager.LoadScene("LevelSelect");
    }
}
