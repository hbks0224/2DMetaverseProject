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
        //DialogUI.SetActive(false); //대화 팝업
        //Check_Y_or_N.SetActive(false); //대화 팝업
        foreach (GameObject go in Check_List) 
        { 
            go.SetActive(false);
        
        }

    }

    private void OnTriggerStay2D(Collider2D other)             //단 한번만 호출
    {
        if (other.CompareTag("Player") )
        {
            Debug.Log("플레이어 들어옴");
            Check_F.SetActive(true); //플레이어와의 트리거 작동시 ui 켜주기

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
            Debug.Log("플레이어 나감");
            Check_F.SetActive(false); //플레이어가 벗어나면 끄기
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
