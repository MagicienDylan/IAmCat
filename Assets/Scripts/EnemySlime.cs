using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlime : Enemy
{
    public float speed;//�Զ��ƶ����ٶ�
    public float waitTime;//�ȴ�ʱ��
    private float startWaitTime;//��ʼʱ�ĵȴ�ʱ��

    public Transform movePos;//�ƶ���Ŀ���
    public Transform leftDownPos;//�ƶ���Χ�����½�
    public Transform rightUpPos;//�ƶ���Χ�����Ͻ�

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

}
