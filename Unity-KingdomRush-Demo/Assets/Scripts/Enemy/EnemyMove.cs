using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform waypointParent;
    [SerializeField] Transform[] waypoints;
    private int index = 0;
    protected float speed = 1.5f;
    private Vector3 target; 
    private Vector3 offset;
    [SerializeField] private Enemy enemy;
    void Awake()
    {
        enemy = GetComponent<Enemy>();
        waypointParent = GameObject.Find("Waypoints").transform;
        if (waypointParent != null)
        {
            int childCount = waypointParent.childCount;
            waypoints = new Transform[childCount];
            for (int i = 0; i < childCount; i++)
            {
                waypoints[i] = waypointParent.GetChild(i);
            }
        }

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
        //计算敌人当前位置到下一个路点的距离
        float remainingDistance = Vector2.Distance(transform.position, target);

        //累加后续所有相邻路点之间的距离
        for (int i = index; i < waypoints.Length - 1; i++)
        {
            remainingDistance += Vector2.Distance(waypoints[i].position, waypoints[i + 1].position);
        }

        return remainingDistance;
    }
}
