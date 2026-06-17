using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private Enemy targetEnemy;
    [SerializeField] private float range;
    private CircleCollider2D rangeCollider;
    [SerializeField]private List<Enemy> enemiesInRange = new List<Enemy>();//范围内敌人的列表

    [SerializeField] private Transform shootPos;
    private float shootCd = 0.8f;
    private float shootCdTimer = 0.5f;
    void Start()
    {
        rangeCollider = GetComponent<CircleCollider2D>();
        rangeCollider.radius = range;
        InitEnemies();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" && !enemiesInRange.Contains(other.GetComponent<Enemy>()))
        {   
            enemiesInRange.Add(other.GetComponent<Enemy>());
            Debug.Log("enemy in range");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            enemiesInRange.Remove(other.GetComponent<Enemy>());
            Debug.Log("enemy out of range");
        }
    }
    void Update()
    {
        if(targetEnemy == null || !targetEnemy.isAlive || !enemiesInRange.Contains(targetEnemy))
        {
            findEnemy();
        }
        if(targetEnemy != null && targetEnemy.isAlive)
        {
            shoot();
        }
    }
    void findEnemy()
    {
        Enemy nearestEnemy = null;
        float minRemainDistance = 9999f; // 初始设一个极大值

        // 遍历所有范围内的敌人
        for (int i = 0; i < enemiesInRange.Count; i++)
        {
            Enemy currentEnemy = enemiesInRange[i];

            //// 跳过空的、已经死亡的敌人
            //if (currentEnemy == null)
            //{
            //    continue;
            //}

            // 获取敌人到基地的剩余路径长度
            float remainDist = currentEnemy.GetComponent<EnemyMove>().RemainDistance();

            // 找到更短的，就更新为新目标
            if (remainDist < minRemainDistance)
            {
                minRemainDistance = remainDist;
                nearestEnemy = currentEnemy;
            }
        }

        // 锁定最终目标（没找到就是null）
        targetEnemy = nearestEnemy;
    }
    void shoot()
    {
        shootCdTimer += Time.deltaTime;
        if(shootCdTimer >= shootCd)
        {
            shootCdTimer = 0;
            Arrow arrow = PoolManager.Instance.GetArrow();
            arrow.Initialize(targetEnemy, shootPos.position);

        }
    }
    void InitEnemies()
    {
        Vector3 offset = new Vector3(0,0.5f,0);//偏移量
        Vector3 center = transform.position + offset;//中心点
        Collider2D[] initEnemies = Physics2D.OverlapCircleAll(center, range);//获取范围内的所有碰撞体
        
        for(int i =0; i < initEnemies.Length; i++)//遍历范围内的所有碰撞体
        {
            Collider2D hit = initEnemies[i];//获取碰撞体

            if (hit.TryGetComponent(out Enemy enemy))//判断碰撞体是否有Enemy组件
            {
                if (!enemiesInRange.Contains(enemy))//判断敌人是否已经在列表中
                {
                    enemiesInRange.Add(enemy);//将敌人添加到列表中
                }
            }
        }
    }
}
