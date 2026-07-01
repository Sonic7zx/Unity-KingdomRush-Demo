using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Arrow : MonoBehaviour
{
    [SerializeField] float speed = 15f;
    [SerializeField] int damage = 3;
    private Enemy targetEnemy;



    public void Initialize(Enemy target,Vector2 StartPos)
    {
        AudioManager.Instance.PlayArrowSFX();
        targetEnemy = target;
        gameObject.SetActive(true);
        transform.position = StartPos;

        Vector2 dir = transform.position - targetEnemy.transform.position;
        float aimAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, aimAngle);
    }
    void Update()
    {

        

        if (targetEnemy == null)//当敌人物体消失
        {
            ReturnToPool();
        }
        
        transform.position = Vector2.MoveTowards(transform.position, targetEnemy.transform.position, speed * Time.deltaTime);//箭矢飞向敌人
        
        if (Vector2.Distance(transform.position, targetEnemy.transform.position) < 0.05f)//当箭矢到达敌人位置时
        {
            if (targetEnemy == null)
            {
                ReturnToPool();
            }
            targetEnemy.TakeDamage(damage);
            ReturnToPool();
        }
    }
    void ReturnToPool()
    {
        BulletPool.Instance.ReleaseArrow(this);
    }
}
