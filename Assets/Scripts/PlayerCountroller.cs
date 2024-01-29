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
        //翻转精灵，只有移动时翻转
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
        //获取水平轴的输入方向
        float moverDir = Input.GetAxis("Horizontal");
        //创建新的移动向量，水平移动时y轴速度保持不变
        Vector2 playerVel = new Vector2(moverDir * runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVel;

        bool HaveHorizontapSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        myAni.SetBool("IsRun",HaveHorizontapSpeed);
    }

    void Jump()
    {
        
    }

}
