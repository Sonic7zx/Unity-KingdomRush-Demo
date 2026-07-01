using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public static GoldManager Instance;
    public int currentGold;
    [SerializeField] private Text goldText;

    void Awake()
    {   
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public bool HasEnough(int amount)
    {
        if(currentGold >= amount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Spend(int amount)
    {
        if (HasEnough(amount))
        {
            currentGold -= amount;
            UpdateUI();
        }
    }

    public void AddGold(int amount)
    {
        currentGold += amount;
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (goldText != null)
            goldText.text = currentGold.ToString();
    }
}