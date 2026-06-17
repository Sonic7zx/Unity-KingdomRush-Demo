using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    private int index = 0;
    protected float speed = 2f;
    private Vector3 target; 
    private Vector3 offset;
    private int currentToWaypointIndex;
    private Enemy enemy;
    void Start()
    {
        enemy = GetComponent<Enemy>();
        offset = new Vector3(Random.Range(-0.7f, 0.7f), Random.Range(-0.7f, 0.7f), 0);
        if (waypoints.Length > 0)
        {
            transform.position = waypoints[0].position + offset;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        MoveToDestination();
    }
    void MoveToDestination()
    {   
        if (index < waypoints.Length && enemy.isAlive == true)
        {
            target = waypoints[index].position + offset;//目标点加偏移量
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);//向目标移动
        }
        if (Vector3.Distance(transform.position, target) < 0.05f)//如果到目标点
        {
            index++;
            if (index == waypoints.Length)
            {
                Debug.Log("到达终点");
            }
        }
    }
    public float RemainDistance()
    {
        // 第1步：计算「敌人当前位置 → 下一个路点」的距离
        float remainingDistance = Vector2.Distance(transform.position, target);

        // 第2步：累加「后续所有相邻路点之间」的距离
        for (int i = index; i < waypoints.Length - 1; i++)
        {
            remainingDistance += Vector2.Distance(waypoints[i].position, waypoints[i + 1].position);
        }

        return remainingDistance;
    }
}
