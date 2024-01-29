using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCountroller : MonoBehaviour
{
    public float runSpeed = 5;
    private Rigidbody2D myRigidBody;
    private Animator myAni;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAni = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
        Run();
        
    }

    void Flip()
    {
        //��ת���飬ֻ���ƶ�ʱ��ת
        bool HaveHorizontapSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (HaveHorizontapSpeed)
        {
            if (myRigidBody.velocity.x > 0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else if (myRigidBody.velocity.x < -0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }

    }

    void Run()
    {
        //��ȡˮƽ������뷽��
        float moverDir = Input.GetAxis("Horizontal");
        //�����µ��ƶ�������ˮƽ�ƶ�ʱy���ٶȱ��ֲ���
        Vector2 playerVel = new Vector2(moverDir * runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVel;

        bool HaveHorizontapSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        myAni.SetBool("IsRun",HaveHorizontapSpeed);
    }

    void Jump()
    {
        
    }

}
