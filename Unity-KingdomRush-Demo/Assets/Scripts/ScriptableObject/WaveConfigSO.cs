using UnityEngine;
[CreateAssetMenu(
    fileName="NewWaveConfigSO",
    menuName="WaveConfigSO"
    )]
public class WaveConfigSO : ScriptableObject
{
    [Header("敌人配置")]
    public GameObject enemyPrefab;
    public int enemyCount;
    public float IntervalBetweenEnemies;
    public float BeforeWaveTime;
    public int WaveIconIndex;
}