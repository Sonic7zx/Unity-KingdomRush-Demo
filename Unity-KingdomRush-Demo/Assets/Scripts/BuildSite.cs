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
    private bool isBuilding = false;
    private bool isOpenMenu = false;
    public GameObject buildMenuPrefab;
    [SerializeField] GameObject currentMenu;
    [SerializeField] Canvas canvas;
    [Header("动画")]
    private Animator animator;
    private GameObject towerToBuild;//获取箭塔预制体

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        originalColor = sprite.color;
        originalScale = transform.localScale;

        animator = GetComponent<Animator>();
    }
    private void OnMouseEnter()
    {
        if (isBuilding) return;
        if (isOpenMenu) return;
        sprite.color = color;//悬停变色
        transform.localScale *= scaleMultiplier;//悬停放大
    }
    private void OnMouseExit()
    {   
        if (isBuilding) return;
        if (isOpenMenu) return;
        sprite.color = originalColor;//悬停变色结束
        transform.localScale = originalScale;//悬停放大结束
    }
    void OnMouseDown()
    {   
        if (isBuilding) return;
        if (currentMenu != null) return;
        if (buildMenuPrefab == null) return;
        if (sprite.color == originalColor && transform.localScale == originalScale)//如果不在悬停放大状态
        {
            sprite.color = color;//悬停变色
            transform.localScale *= scaleMultiplier;//悬停放大
        }
        AudioManager.Instance.PlayOpenMenuSFX();//播放打开菜单音效
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
        isOpenMenu = true;
    }
    public void ArcherTowerBuild(GameObject towerPrefab)
    {
        animator.SetBool("buildingArcherTower", true);
        towerToBuild = towerPrefab;
        isBuilding = true;
    }
    public void BuildAnimEnd()
    {
        if (towerToBuild != null)
        {
            Instantiate(towerToBuild, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
    public void OnMenuClosed()
    {
        isOpenMenu = false;
        currentMenu = null;
        sprite.color = originalColor;//悬停变色结束
        transform.localScale = originalScale;//悬停放大结束
    }
}
