using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    public GameObject Check_F;
    public List<GameObject> Check_List;
    bool active_F = false; //F�� ������ Ȯ���ϴ� ����
    bool isPlayerIn = false; // �÷��̾ ��ȭ �������� ���Դ��� Ȯ���ϴ� ����
    bool isDialog = false;// ��Ȯ������ Ȯ���ϴ� ����

    protected virtual void Start() // ���� �� �� ��� ui off
    {

        Check_F.SetActive(false);
        active_F = false;


        foreach (var go in Check_List)
            go.SetActive(false);

    }

    protected virtual void Update()
    {

        if (isPlayerIn)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {

                ShowDialog();

            }

        }

    }

    protected virtual void ShowDialog()
    {
        Check_F.SetActive(false);

        active_F = false;
        Debug.Log("F off");

        isDialog = true;
        Debug.Log("Dialog on");
        foreach (var go in Check_List)
            go.SetActive(true);


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerIn = true;
            Debug.Log("player in");
            Check_F.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerIn = false;
            Debug.Log("player out");
            Check_F.SetActive(false);
            isDialog = false;
            Debug.Log("Dialog off");

            foreach (var go in Check_List)
                go.SetActive(false);
        }
    }

    protected abstract void DialogAdd(); //�������̵�
}

