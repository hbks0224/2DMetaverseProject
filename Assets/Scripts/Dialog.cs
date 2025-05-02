using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{

    public GameObject Check_F; 
    //public GameObject Check_Y_or_N;
    //public GameObject DialogUI;

    public List<GameObject> Check_List;

    void Start()
    {
        //�ϴ� ����
        Check_F.SetActive(false); //F �˾�
        //DialogUI.SetActive(false); //��ȭ �˾�
        //Check_Y_or_N.SetActive(false); //��ȭ �˾�
        foreach (GameObject go in Check_List) 
        { 
            go.SetActive(false);
        
        }

    }

    private void OnTriggerStay2D(Collider2D other)             //�� �ѹ��� ȣ��
    {
        if (other.CompareTag("Player") )
        {
            Debug.Log("�÷��̾� ����");
            Check_F.SetActive(true); //�÷��̾���� Ʈ���� �۵��� ui ���ֱ�

            if (Input.GetKey(KeyCode.F))
            {
                Debug.Log("F Input Check");
                //DialogUI.SetActive(true);
                foreach (GameObject go in Check_List)
                {
                    go.SetActive(true);

                }

            }

        }
        

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("�÷��̾� ����");
            Check_F.SetActive(false); //�÷��̾ ����� ����
                                      //DialogUI.SetActive(false);

            foreach (GameObject go in Check_List)
            {
                go.SetActive(false);

            }
        }
    }


    //private void YesOrNo()
    //{

    //    if()

    //}
    


}
