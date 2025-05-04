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
        //일단 꺼둠
        Check_F.SetActive(false); //F 팝업

        foreach (GameObject go in Check_List) 
        { 
            go.SetActive(false);
        
        }

    }

    private void OnTriggerStay2D(Collider2D other)          
    {
        if (other.CompareTag("Player") ) //태그가 플레이어면
        {
            Debug.Log("플레이어 들어옴");
            //플레이어와의 트리거 작동시 ui 켜주기
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
            Debug.Log("플레이어 나감");
            Check_F.SetActive(false); //플레이어가 벗어나면 끄기
            //DialogUI.SetActive(false);

            foreach (GameObject go in Check_List)
            {
                go.SetActive(false);

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
