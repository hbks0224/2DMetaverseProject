using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//��ȭ �������̽� �⺻ ���� ����

// NPC���� �ٸ��� ���� �� �� �ֵ��� �ڽ� Ŭ�������� DialogAdd() ������
public abstract class Dialog : MonoBehaviour
{
    public GameObject Check_F; //��ȭ ���� �ȿ� �������� F �Է��� Ȯ��
    public List<GameObject> Check_List; //������ UI ������Ʈ ����Ʈ
   // bool active_F = false; //F�� ������ Ȯ���ϴ� ���� (������ ������)
    protected bool isPlayerIn = false; // �÷��̾ ��ȭ �������� ���Դ��� Ȯ���ϴ� ����
    protected bool isDialog = false;// ��ȭ������ Ȯ���ϴ� ����

    protected virtual void Start() // ���� �� �� ��� ui off
    {

        Check_F.SetActive(false);
       // active_F = false;


        foreach (var go in Check_List)
            go.SetActive(false); //UI���� ��

    }

    protected virtual void Update() 
    {

        if (isPlayerIn)
        {

            //���� �ȿ� �ְ� F�Է½� ��ȭ ����
            if (Input.GetKeyDown(KeyCode.F))
            {

                ShowDialog();

            }
            //�ڽ� Ŭ�������� ���ǵ� ��� ����
            DialogAdd();
        }

    }

    protected virtual void ShowDialog()
    {
        Check_F.SetActive(false); // F�� �����ٸ� F �г� �������

      //  active_F = false;
        Debug.Log("F off");

        isDialog = true;
        Debug.Log("Dialog on");
        foreach (var go in Check_List)
        {
            go.SetActive(true); // ��ȭ UI on

            if (go.name == "NPC_Dwarf_Sad") // �̰� ���� ������Ʈ�̱� ������ ����
            {


                go.SetActive(false);
            }
        }



    }

    private void OnTriggerEnter2D(Collider2D other) // �÷��̾ ������ ������ FŰ �г� on
    {
        if (other.CompareTag("Player"))
        {
            isPlayerIn = true;
            Debug.Log("player in");
            Check_F.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) // �÷��̾ �������� ������ F �г��̶� ��ȭUI ���� ��
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

