using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : MonoBehaviour
{
    // 单例核心：全局唯一实例，任何脚本都能通过 PoolManager.Instance 调用
    public static PoolManager Instance { get; private set; }

    [Header("弓箭池配置")]
    public Arrow arrowPrefab;
    public int defaultCapacity = 10;//池默认容量
    public int maxSize = 30;//池最大容量

    private IObjectPool<Arrow> arrowPool;//

    void Awake()
    {
        // 单例校验：保证场景里永远只有一个PoolManager
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        // 可选：多关卡切换不销毁池，注释掉则切换场景会重置
        // DontDestroyOnLoad(gameObject);

        // 初始化全局弓箭对象池
        arrowPool = new ObjectPool<Arrow>(
            createFunc: CreateArrow,
            actionOnGet: OnGetArrow,
            actionOnRelease: OnReleaseArrow,
            actionOnDestroy: DestroyArrow,
            collectionCheck: true,
            defaultCapacity: defaultCapacity,
            maxSize: maxSize
        );
    }

    // ========== 对外公开方法：塔取箭、弓箭归还 ==========
    // 塔调用：从池里取出1支弓箭
    public Arrow GetArrow()
    {
        return arrowPool.Get();
    }

    // 弓箭调用：把自己归还回池
    public void ReleaseArrow(Arrow arrow)
    {
        arrow.gameObject.SetActive(false);
        arrowPool.Release(arrow);
    }

    // ========== 池内部生命周期回调 ==========
    Arrow CreateArrow()
    {
        Arrow newArrow = Instantiate(arrowPrefab, transform);
        return newArrow;
    }

    void OnGetArrow(Arrow arrow)
    {
        arrow.gameObject.SetActive(true);
    }

    void OnReleaseArrow(Arrow arrow)
    {
        arrow.gameObject.SetActive(false);
    }

    void DestroyArrow(Arrow arrow)
    {
        Destroy(arrow.gameObject);
    }
}