using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(
    menuName = "LevelConfigSO",
    fileName = "NewLevelConfigSO"
    )]
public class LevelConfigSO : ScriptableObject
{
    [Header("关卡基本信息")]
    public string levelName = "第一关";
    public int startingGold = 150;
    public int DestinationHealth = 15;

    [Header("波次列表")]
    public List<WaveConfigSO> waves;

    [Header("胜利条件")]
    public int totalWavesToWin = 5;
}