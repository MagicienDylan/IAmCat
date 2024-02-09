using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PlayerCountroller : MonoBehaviour
{
    public float runSpeed = 5;
    public float jumpSpeed = 5;
    public float fallSpeed = -2;
    public float doubleJumpSpeed = 3;
    public float attackSppeed = 2;//����ʱ�ƶ��Ĳ����ٶ�

    private Rigidbody2D myRigidBody;
    private Animator myAni;
    private BoxCollider2D myFeet;
    private bool isGrounded;
    private bool canDoubleJump;
    private bool IsAttack;
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
        Attack();
  


    }
    void CheckGrounded()
    {
        //����Ƿ��ǵ���
        isGrounded = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"));
        myAni.SetBool("IsGrounded", isGrounded);

    }
    void Flip()
    {
        //��תԤ���壬ֻ���ƶ�ʱ��ת
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
        if (IsAttack == false)
        {
            //��ȡˮƽ������뷽��
            float moverDir = Input.GetAxis("Horizontal");
            //�����µ��ƶ�������ˮƽ�ƶ�ʱy���ٶȱ��ֲ���
            Vector2 playerVel = new Vector2(moverDir * runSpeed, myRigidBody.velocity.y);
            myRigidBody.velocity = playerVel;

            bool HaveHorizontapSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon && isGrounded;
            myAni.SetBool("IsRun", HaveHorizontapSpeed);
        }


    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                Vector2 jumpVel = new Vector2(0.0f, jumpSpeed);
                myRigidBody.velocity = Vector2.up * jumpVel;
                canDoubleJump = true;
            }
            else
            {
                if (canDoubleJump)
                {
                    Vector2 doubleJumpVel = new Vector2(0.0f, doubleJumpSpeed);
                    myRigidBody.velocity = Vector2.up * doubleJumpVel;
                    canDoubleJump = false;
                }

            }

                

            
        }
        bool isJump = myRigidBody.velocity.y > 0.0f;
        myAni.SetBool("IsJump", isJump);
    }
    void Fall()
    {
        bool isFall = myRigidBody.velocity.y < fallSpeed;
        myAni.SetBool("IsFall", isFall);
    }

    void Attack()
    {
        //���space������attack
        if (Input.GetKeyDown(KeyCode.Space)&&(IsAttack == false))
        {
            IsAttack = true;
            myAni.SetTrigger("NormalAttack");
            myRigidBody.velocity = new Vector2(transform.localPosition.x*attackSppeed, 0.0f);

            if (transform.localRotation == Quaternion.Euler(0, 0, 0))//����
            {
                myRigidBody.velocity = new Vector2(attackSppeed, myRigidBody.velocity.y);
            }
            else if (transform.localRotation == Quaternion.Euler(0, -180, 0)|| transform.localRotation == Quaternion.Euler(0, 180, 0))//����
            {
                myRigidBody.velocity = new Vector2(-attackSppeed, myRigidBody.velocity.y);
            }
        }
        
    }
    void AttackOver()
    {
        IsAttack = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            //���˽��빥����Χʱ����������
            if (transform.localRotation == Quaternion.Euler(0, 0, 0))//���һ���
            {
                other.GetComponent<Enemy>().GetHit(new Vector2(1, 0));
            }
            if (transform.localRotation == Quaternion.Euler(0, -180, 0))//���һ���
            {
                other.GetComponent<Enemy>().GetHit(new Vector2(-1, 0));
            }
        }
    }
}
