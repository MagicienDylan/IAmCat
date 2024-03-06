using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;//�ñ༭�������л���

public enum StateType//��ö���������е�״̬
{
    Idle, Patrol, Chase, React, Attack
}


[Serializable]
public class Parameter
{
    //��ŵ��˵ĸ��ֲ�����ͨ��System���Զ����л���
    public int health;//����
    public float moveSpeed;//�ƶ��ٶ�
    public float chaseSpeed;//׷���ٶ�
    public float startWaitTime;//��ʼ�ȴ�ʱ��
    public float waitTime;//ͨ�õȴ�ʱ��
    
    public Transform[] patrolPoints;//Ѳ�߷�Χ
    public Transform[] chasePoints;//׷����Χ
    public Animator animator;

}

public class FSM : MonoBehaviour
{
    public IState currentState;//ÿһ��״̬������Ҫ��һ����ǰ��״̬
    public Parameter parameter = new Parameter();

    


    private Dictionary<StateType, IState> states = new Dictionary<StateType, IState>();//ʹ���ֵ��������е�״̬
    // Start is called before the first frame update
    void Start()
    {
        states.Add(StateType.Idle, new EnemyIdleState(this));
        states.Add(StateType.Patrol, new EnemyPatrolState(this));
        states.Add(StateType.Chase, new EnemyChaseState());
        states.Add(StateType.React, new EnemyReactState());
        states.Add(StateType.Attack, new EnemyAttackState());

        TransitionState(StateType.Idle);//���ó�ʼֵ
        parameter.animator = transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currentState.OnUpdate();
    }

    public void TransitionState(StateType type)
    {
        //ת��״̬ʱ����ִ�е�ǰ״̬��OnExit����
        if (currentState != null)//ǰ�����������ڵ�ǰ״̬
        {
            currentState.OnExit();
        }
        currentState = states[type];
        currentState.OnEnter();
    }

    //����״̬�µ�ͨ�ù��ܿ��Զ�д������
    public void FlipTowards(Transform target)//��Ŀ��ʱ��ת����
    {
        if (target != null)
        {
            if (transform.position.x > target.position.x)//Ŀ������
            {
                transform.localScale = new Vector3(-1*transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
            if (transform.position.x < target.position.x)//Ŀ������
            {
                transform.localScale = new Vector3(1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
        
    }
}
