using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{

    public GameObject dialogueUI;

    void Start()
    {
        //�ϴ� ����
        dialogueUI.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("�÷��̾� ����");
            dialogueUI.SetActive(true); //�÷��̾���� Ʈ���� �۵��� ui ���ֱ�
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("�÷��̾� ����");
            dialogueUI.SetActive(false); //�÷��̾ ����� ����
        }
    }
}
