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

        foreach (GameObject go in Check_List) 
        { 
            go.SetActive(false);
        
        }

    }

    private void OnTriggerStay2D(Collider2D other)          
    {
        if (other.CompareTag("Player") ) //�±װ� �÷��̾��
        {
            Debug.Log("�÷��̾� ����");
            //�÷��̾���� Ʈ���� �۵��� ui ���ֱ�
           // Check_F.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                
                Debug.Log("F Input Check");
                //DialogUI.SetActive(true);
                foreach (GameObject go in Check_List)
                {
                    go.SetActive(true);
                }
                if (Check_F.activeSelf)
                {
                    Check_F.SetActive(false);
                     
                }
    
                //if (Check_F.activeSelf && Check_List[0].activeSelf && Check_List[1].activeSelf)
                //{

                //    Check_F.SetActive(false);
                //}

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

    private void OnTriggerEnter2D(Collider2D collision) //�̷��� check_F�� �и��ؼ�OnTriggerEnter�� ���ϸ� ���������� ��� �ѳ��� F�� ������ ������ڸ��� �ٽ� ����
    {
        if ( collision.CompareTag("Player"))
        {
            Check_F.SetActive(true);

        }
    }


    //private void YesOrNo()
    //{

    //    if()

    //}



}
