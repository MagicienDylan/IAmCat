using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCountroller : MonoBehaviour
{
    public float runSpeed = 5;
    public float jumpSpeed = 5;
    public float fallSpeed = -2;

    private Rigidbody2D myRigidBody;
    private Animator myAni;
    private BoxCollider2D myFeet;
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAni = GetComponent<Animator>();
        myFeet = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGrounded();
        Flip();
        Run();
        Jump();
        Fall();
        
        
    }
    void CheckGrounded()
    {
        //����Ƿ��ǵ���
        isGrounded = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"));
        myAni.SetBool("IsGrounded", isGrounded);

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

        bool HaveHorizontapSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon && isGrounded;
        myAni.SetBool("IsRun",HaveHorizontapSpeed);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump")&&isGrounded)
        {
            Vector2 jumpVel = new Vector2(0.0f, jumpSpeed );
            myRigidBody.velocity = Vector2.up * jumpVel;
        }
        bool isJump = myRigidBody.velocity.y > 0.0f;
        myAni.SetBool("IsJump", isJump);
    }
    void Fall()
    {
        bool isFall = myRigidBody.velocity.y < fallSpeed && (isGrounded == false);
        myAni.SetBool("IsFall", isFall);
    }
}
