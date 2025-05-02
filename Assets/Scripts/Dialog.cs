using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{

    public GameObject dialogueUI;

    void Start()
    {
        //일단 꺼둠
        dialogueUI.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("플레이어 들어옴");
            dialogueUI.SetActive(true); //플레이어와의 트리거 작동시 ui 켜주기
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("플레이어 나감");
            dialogueUI.SetActive(false); //플레이어가 벗어나면 끄기
        }
    }
}
