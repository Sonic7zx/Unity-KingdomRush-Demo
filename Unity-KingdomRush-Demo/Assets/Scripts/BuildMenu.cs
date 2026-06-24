using UnityEngine;
public class BuildMenu : MonoBehaviour
{
    private BuildSite currentSite;

    [Header("塔配置")]
    [SerializeField] GameObject arrowTowerPrefab;//获取箭塔预制体
    public int arrowTowerCost = 100;

    public void Initialize(BuildSite site)
    {
        currentSite = site;
    }

    public void OnArrowTowerClick()
    {
        if (GoldManager.Instance.HasEnough(arrowTowerCost))
        {
            GoldManager.Instance.Spend(arrowTowerCost);
            currentSite.ArcherTowerBuild(arrowTowerPrefab);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("金币不足，无法建造箭塔");
        }
    }

    public void OnCancelClick()
    {
        Destroy(gameObject);
    }
}