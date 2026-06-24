using UnityEngine;
using UnityEngine.Pool;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance { get; private set; }

    [Header("弓箭池配置")]
    public Arrow arrowPrefab;
    [SerializeField] int defaultCapacity = 10;//池默认容量
    [SerializeField] int maxSize = 30;//池最大容量

    private ObjectPool<Arrow> bulletPool;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        bulletPool = new ObjectPool<Arrow>(
            createFunc: CreateArrow,
            actionOnGet: OnGetArrow,
            actionOnRelease: OnReleaseArrow,
            actionOnDestroy: DestroyArrow,
            collectionCheck: true,
            defaultCapacity: defaultCapacity,
            maxSize: maxSize
        );
    }

    public Arrow GetArrow()
    {
        return bulletPool.Get();
    }

    public void ReleaseArrow(Arrow arrow)
    {
        arrow.gameObject.SetActive(false);
        bulletPool.Release(arrow);
    }

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