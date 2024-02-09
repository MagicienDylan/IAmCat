using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed=3;//敌人击退的速度
    private Vector2 direction;//敌人被击退的方向
    private bool isHit;//是否受击
    private AnimatorStateInfo info;//获取动画进度

    private Animator animator;
    private Rigidbody2D Enemyrigidbody;

    
    // Start is called before the first frame update
    void Start()
    {
        //获取动画进度和刚体
        animator = transform.GetComponent<Animator>();
        Enemyrigidbody = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        info = animator.GetCurrentAnimatorStateInfo(0);
        if(isHit)
        {
            Enemyrigidbody.velocity = direction * speed;
            
            if (info.normalizedTime >= 1f)
            {
                isHit = false;
                //在动画播放到0.6s时结束受击状态
            }
        }
    }

    public void GetHit(Vector2 Hitdirction)
    {
        animator.SetTrigger("Hit");
        //将敌人方向朝向伤害来源方向
        transform.localScale =new Vector3(-Hitdirction.x*transform.localScale .x, transform .localScale .y, transform.localScale.z);
        isHit = true;
        this.direction = Hitdirction;
        
    }
}
