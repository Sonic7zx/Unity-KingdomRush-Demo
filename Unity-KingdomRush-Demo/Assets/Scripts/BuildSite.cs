using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSite : MonoBehaviour
{
    [Header("悬停效果")]
    private SpriteRenderer sprite;
    [SerializeField] float scaleMultiplier = 1.2f;
    [SerializeField] Color32 color = new Color32(255, 255, 255, 255);
    private Color originalColor;
    private Vector3 originalScale;
    [Header("建造菜单")]
    public GameObject buildMenuPrefab;
    [SerializeField] GameObject currentMenu;
    [SerializeField] Canvas canvas;
    [Header("动画")]
    private Animator animator;
    private GameObject towerToBuild;//获取箭塔预制体

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        originalColor = sprite.color;
        originalScale = transform.localScale;

        animator = GetComponent<Animator>();
    }
    private void OnMouseEnter()
    {
        sprite.color = color;//悬停变色
        transform.localScale *= scaleMultiplier;//悬停放大
    }
    private void OnMouseExit()
    {
        sprite.color = originalColor;//悬停变色结束
        transform.localScale = originalScale;//悬停放大结束
    }
    void OnMouseDown()
    {
        if (currentMenu != null) return;
        if (buildMenuPrefab == null) return;
        GameObject menuIns = Instantiate(buildMenuPrefab, canvas.transform);//生成建造菜单
        Vector3 worldPos = transform.position;//获取世界坐标
        Vector2 screenPos = Camera.main.WorldToScreenPoint(worldPos);//将世界坐标转换为屏幕坐标
        menuIns.GetComponent<RectTransform>().position = screenPos;//将建造菜单位置设置为屏幕坐标

        // 初始化菜单
        BuildMenu menuScript = menuIns.GetComponent<BuildMenu>();//获取菜单脚本
        if (menuScript != null)//如果菜单脚本存在
        {
            menuScript.Initialize(this);
        }
        currentMenu = menuIns;
    }
    public void ArcherTowerBuild(GameObject towerPrefab)
    {
        animator.SetBool("buildingArcherTower", true);
        towerToBuild = towerPrefab;
    }
    public void BuildAnimEnd()
    {
        if (towerToBuild != null)
        {
            Instantiate(towerToBuild, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
