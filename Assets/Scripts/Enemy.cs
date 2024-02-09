using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;//���˻��˵��ٶ�
    private Vector2 direction;//���˱����˵ķ���
    private bool isHit;//�Ƿ��ܻ�
    private AnimatorStateInfo info;//��ȡ��������

    private Animator animator;
    private Rigidbody2D rigidbody;

    
    // Start is called before the first frame update
    void Start()
    {
        //��ȡ�������Ⱥ͸���
        animator = transform.GetComponent<Animator>();
        rigidbody = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        info = animator.GetCurrentAnimatorStateInfo(0);
        if(isHit)
        {
            rigidbody.velocity = direction * speed;
            
            if (info.normalizedTime >= 0.6f)
            {
                isHit = false;
                //�ڶ������ŵ�0.6sʱ�����ܻ�״̬
            }
        }
    }

    public void GetHit(Vector2 dirction)
    {
        //�����˷������˺���Դ����
        transform.localScale =new Vector3(-direction.x, 1, 1);
        isHit = true;
        this.direction = dirction;
        animator.SetTrigger("Hit");
    }
}
