using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed=3;//���˻��˵��ٶ�
    private Vector2 direction;//���˱����˵ķ���
    private bool isHit;//�Ƿ��ܻ�
    private AnimatorStateInfo info;//��ȡ��������

    private Animator animator;
    private Rigidbody2D Enemyrigidbody;

    
    // Start is called before the first frame update
    void Start()
    {
        //��ȡ�������Ⱥ͸���
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
                //�ڶ������ŵ�0.6sʱ�����ܻ�״̬
            }
        }
    }

    public void GetHit(Vector2 Hitdirction)
    {
        animator.SetTrigger("Hit");
        //�����˷������˺���Դ����
        transform.localScale =new Vector3(-Hitdirction.x*transform.localScale .x, transform .localScale .y, transform.localScale.z);
        isHit = true;
        this.direction = Hitdirction;
        
    }
}
