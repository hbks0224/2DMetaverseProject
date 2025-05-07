using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


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

        Debug.Log("Check_List ����:");
        for (int i = 0; i < Check_List.Count; i++)
        {
            Debug.Log($"[{i}] {Check_List[i].name}");
            Check_List[i].SetActive(false);
        }

    }
    private void Update()
    {

        if (Check_F.activeSelf) 
        {
            //Debug.Log("�÷��̾� ����");
            //�÷��̾���� Ʈ���� �۵��� ui ���ֱ�
            // Check_F.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {

                Debug.Log("F Input Check");
                //DialogUI.SetActive(true);
                foreach (GameObject go in Check_List)
                {
                    go.SetActive(true);

                    if (go.name == "NPC_Dwarf_Sad")
                    {


                        go.SetActive(false);
                    }
                }
                if (Check_F.activeSelf)
                {
                    Check_F.SetActive(false);


                }

                


            }




        }


        if (Input.GetKeyDown(KeyCode.N) )
        {
            if (!Check_F.activeSelf)
            {

                Debug.Log("dddd");
                foreach (GameObject go in Check_List)
                {
                    go.SetActive(false);


                    if (go.name == "NPC_Dwarf_Sad")
                    {


                        go.SetActive(true);
                    }



                }

            }

            else
            {

                Debug.Log("Not Input N");

            }


        }

        if (Input.GetKeyDown(KeyCode.Y) )
        {
            if (!Check_F.activeSelf)
            {
                Debug.Log("input Y");
                //SceneManager.LoadScene("GameScene");





            }

            else
            {

                Debug.Log("Not Input Y");

            }


        }



    }


    private void OnTriggerStay2D(Collider2D other)          
    {
        //if (other.CompareTag("Player") ) //�±װ� �÷��̾��
        //{
        //    Debug.Log("�÷��̾� ����");
        //    //�÷��̾���� Ʈ���� �۵��� ui ���ֱ�
        //   // Check_F.SetActive(true);
        //    if (Input.GetKeyDown(KeyCode.F))
        //    {
                
        //        Debug.Log("F Input Check");
        //        //DialogUI.SetActive(true);
        //        foreach (GameObject go in Check_List)
        //        {
        //            go.SetActive(true);

        //            if (go.name == "NPC_Dwarf_Sad")
        //            {


        //                go.SetActive(false);
        //            }
        //        }
        //        if (Check_F.activeSelf)
        //        {
        //            Check_F.SetActive(false);
                    
                     
        //        }

                


        //    }




        //    if (Input.GetKeyDown(KeyCode.N) &&!Check_F.activeSelf)
        //    {
        //        foreach (GameObject go in Check_List)
        //        {
        //            go.SetActive(false);


        //            if (go.name == "NPC_Dwarf_Sad")
        //            {


        //                go.SetActive(true);
        //            }



        //        }

        //    }

        //    if (Input.GetKeyDown(KeyCode.Y)&& !Check_F.activeSelf)
        //    {

        //        SceneManager.LoadScene("GameScene");




        //    }
        //}
        

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("�÷��̾� ����");
            if(Check_F != null)
            {
                Check_F.SetActive(false); //�÷��̾ ����� ����

            }

            //DialogUI.SetActive(false);

            foreach (GameObject go in Check_List)
            {

                if (go != null)
                {
                    go.SetActive(false);

                }

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
