using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CreateItemData/PackageData", fileName = "PackageTable")]
//������Ʒ�����ļ�
public class PackageTables : ScriptableObject//���������ļ�
{
    public List<packageItems> DataList = new List<packageItems>();
    //ʹ��һ���б�����������Ʒ
}

[Serializable]//���л����ɱ༭
public class packageItems
{
    public int id;//Ψһid
    public int type;//���ͣ�1=��ͨ��Ʒ��2=��װ��Ʒ
    public string name;//��Ʒ����
    public string description;//��Ʒ����
    public string imagePath;//ͼƬ·��
    public int num;//��Ʒ����

}
