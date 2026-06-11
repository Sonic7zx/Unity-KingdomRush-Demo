using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public static GoldManager Instance;
    [SerializeField] private int startingGold = 150;
    private int currentGold;
    [SerializeField] private Text goldText;

    void Awake()
    {   
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        currentGold = startingGold;
        UpdateUI();
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

    void UpdateUI()
    {
        if (goldText != null)
            goldText.text = currentGold.ToString();
    }
}