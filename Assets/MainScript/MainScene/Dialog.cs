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
        //일단 꺼둠
        Check_F.SetActive(false); //F 팝업

        foreach (GameObject go in Check_List) 
        { 
            go.SetActive(false);
        
        }

        Debug.Log("Check_List 내용:");
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
            //Debug.Log("플레이어 들어옴");
            //플레이어와의 트리거 작동시 ui 켜주기
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
        //if (other.CompareTag("Player") ) //태그가 플레이어면
        //{
        //    Debug.Log("플레이어 들어옴");
        //    //플레이어와의 트리거 작동시 ui 켜주기
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
            Debug.Log("플레이어 나감");
            if(Check_F != null)
            {
                Check_F.SetActive(false); //플레이어가 벗어나면 끄기

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

    private void OnTriggerEnter2D(Collider2D collision) //이렇게 check_F를 분리해서OnTriggerEnter로 안하면 지속적으로 계속 켜놔서 F를 눌러도 사라지자마자 다시 생김
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
