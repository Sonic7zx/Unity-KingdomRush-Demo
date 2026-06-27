using UnityEngine;

public class Enemy : MonoBehaviour
{   
    protected int maxHealth = 10;
    protected int damageToPlayer = 1;
    protected int getGold = 25;
    protected int defense = 0;
    private int currentHealth = 10;
    private Animator animator;
    public bool isAlive = true;
    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
        isAlive = true;
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == ("Destination"))
        {
            Destination destination = other.GetComponent<Destination>();
            if (destination != null)
            {
                destination.TakeDamage(damageToPlayer);
            }
            Destroy(gameObject);//当敌人到达终点时销毁
            WaveManager.Instance.OnEnemyDied();//提醒波次管理器此敌人死亡
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            animator.SetBool("isDead", true);
            isAlive = false;
        }
    }
    void DestroyEnemy()//由动画事件执行
    {
        Destroy(gameObject);
        GoldManager.Instance.AddGold(getGold);
        WaveManager.Instance.OnEnemyDied();
    }


}
