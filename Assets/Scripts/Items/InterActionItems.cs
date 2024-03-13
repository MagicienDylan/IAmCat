using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterActionItems : MonoBehaviour
{
    // Start is called before the first frame update
    public Button attackButton;
    public Button speakButton;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("��ײ");
        }
        attackButton.gameObject.SetActive(false);//���ܹ�����Ҫ˵��
        speakButton.gameObject.SetActive(true);
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("�뿪");
        attackButton.gameObject.SetActive(true);
        speakButton.gameObject.SetActive(false);
    }
}
