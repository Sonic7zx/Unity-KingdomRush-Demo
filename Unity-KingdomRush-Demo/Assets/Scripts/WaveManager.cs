using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    public static WaveManager Instance { get; private set; }

    [Header("关卡配置")]
    [SerializeField] LevelConfigSO currentLevelConfig;

    [Header("运行时状态")]
    protected int currentWaveIndex = 0;
    private int enemiesAlive = 0;
    protected bool isWaveActive = false;
    protected bool isLevelComplete = false;

    private List<WaveConfigSO> waves;
    private Coroutine waveCoroutine;
    [Header("UI")]
    [SerializeField] Text waveUI;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        waves = currentLevelConfig.waves;//获取关卡配置中的波数

        if (GoldManager.Instance != null)//设置初始金币
        {
            GoldManager.Instance.currentGold = currentLevelConfig.startingGold;
            GoldManager.Instance.UpdateUI();
        }


        Destination destination = FindObjectOfType<Destination>();//设置初始血量
        if (destination != null)
        {
            destination.maxHealth = currentLevelConfig.DestinationHealth;
            destination.currentHealth = currentLevelConfig.DestinationHealth;
            destination.UpdateUI();
        }

        waveUI.text = 0 + " / " + waves.Count.ToString();//设置初始波数
    }

    void Start()
    {
        

        StartWaves();
    }

    public void StartWaves()
    {
        if (waveCoroutine != null) StopCoroutine(waveCoroutine);
        waveCoroutine = StartCoroutine(WaveRoutine());//开始协程
    }

    IEnumerator WaveRoutine()
    {
        for (int i = 0; i < waves.Count; i++)
        {
            currentWaveIndex = i;
            WaveConfigSO waveConfig = waves[i];
            isWaveActive = true;
            

            yield return new WaitForSeconds(waveConfig.BeforeWaveTime);

            UpdateWaveUI();

            for (int j = 0; j < waveConfig.enemyCount; j++)
            {
                SpawnEnemy(waveConfig.enemyPrefab);
                enemiesAlive++;
                yield return new WaitForSeconds(waveConfig.IntervalBetweenEnemies);
            }

            yield return new WaitUntil(() => enemiesAlive <= 0);

            isWaveActive = false;

            if (i == waves.Count - 1)
            {
                isLevelComplete = true;
                Debug.Log("关卡胜利！");
            }
        }
    }

    void SpawnEnemy(GameObject prefab)
    {
        Vector3 spawnPos = new Vector3(-18, -3, 0);
        GameObject enemyObj = Instantiate(prefab, spawnPos, Quaternion.identity);

        Enemy enemy = enemyObj.GetComponent<Enemy>();

    }


    public void OnEnemyDied()
    {
        enemiesAlive--;
    }
    
    void UpdateWaveUI()
    {
        waveUI.text = (currentWaveIndex + 1).ToString() + " / " + waves.Count.ToString();
    }
}