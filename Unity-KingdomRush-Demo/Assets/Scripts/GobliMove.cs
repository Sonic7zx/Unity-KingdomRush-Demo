using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GobliMove : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    private int index = 0;
    [SerializeField] float speed = 2f;
    private Vector3 target; 
    private Vector3 offset;
    void Start()
    {
        offset = new Vector3(Random.Range(-0.7f, 0.7f), Random.Range(-0.7f, 0.7f), 0);
        if (waypoints.Length > 0)
        {
            transform.position = waypoints[0].position + offset;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if (index < waypoints.Length)
        {
            target = waypoints[index].position + offset;
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
        if (Vector3.Distance(transform.position, target) < 0.05f)
        {
            index++;
            if (index == waypoints.Length)
            {
                Debug.Log("到达终点");
                Destroy(gameObject);  // 后续改为扣血逻辑
            }
        }
    }
}
