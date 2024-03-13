using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageLocalData//��ȡ������Ʒ��Ϣ
{
    private static PackageLocalData instance;

    public static PackageLocalData Instance//���û�����ݣ����½�����
    {
        get
        {
            if (instance == null)
            {
                instance = new PackageLocalData();
            }
            return instance;
        }
    }
    public List<PackageLocalItem> items;//�����ļ�
    public void SavePackageData()//�洢
    { 
        string inventoryJson = JsonUtility.ToJson(this);//�����Ϣ���л�Ϊ�ַ���
        PlayerPrefs.SetString("PackageLocalItem", inventoryJson);
        PlayerPrefs.Save();
    }
    public List<PackageLocalItem> LoadPackage()
    {
        if (items != null)//�����ļ��Ѿ����ڣ�������Ѿ���ȡ�����ݣ�ֱ�ӷ���ֵ����
        {
            return items;
        }
        if (PlayerPrefs.HasKey("PackageLocalItem"))
        {
            string inventoryJson = PlayerPrefs.GetString("PackageLocalItem");
            PackageLocalData packageLocalData = JsonUtility.FromJson<PackageLocalData>(inventoryJson);//���ַ��������л�Ϊ����
            items = packageLocalData.items;
            return items;
        }
        else {
            items = new List<PackageLocalItem>();
            return items;
        }

    }
}

[System.Serializable]
public class PackageLocalItem
{
    //������Ҫ��������ݣ���Ʒ���ݣ���id���������Ƿ����»�õ�
    public string uid;
    public int id;
    public int num;
    public bool isNew;
    public override string ToString()
    {
        return string.Format("��id��={0}����num��={1}", id, num);
    }
}
