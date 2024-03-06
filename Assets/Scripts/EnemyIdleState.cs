
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;




public class EnemyIdleState : IState
{
    private FSM manager;
    private Parameter parameter;
    private float timer;//Ѳ�ߵ���λ��ĵȴ�ʱ��

    public EnemyIdleState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    public void OnEnter() 
    {

        parameter.animator.Play("Idle");//����״̬ʱ��ʼidle
    }

    public void OnUpdate()
    {
        timer += Time.deltaTime;//��ʼidle��ʱ�䲻������
        if (timer >= parameter.waitTime)//�����ȴ�ʱ���ʼѲ��
        {
            manager.TransitionState(StateType.Patrol);
        }
    }  
    public void OnExit() 
    {
        timer = 0; 
    }
}
