using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YesNoDialog : Dialog
{

    //F키로 대화 시작 후 Y나 N입력에 따라 동작하는 스크립트
    protected override void DialogAdd()
    {

        //대화 중일때만 동작
        if (isDialog == true)
        {

           // Debug.Log("ddddd");

            //Y 입력시 게임씬으로 이동
            if (Input.GetKeyDown(KeyCode.Y))
            {
                Debug.Log("input y go game");

                SceneManager.LoadScene("GameScene");

            }
            //N 입력시 대화를 취소하고 예외 UI만 표시

            if (Input.GetKeyDown(KeyCode.N))
            {
                Debug.Log("input n cancle dialog");

                foreach (GameObject go in Check_List)
                {
                    go.SetActive(false);
                    if (go.name == "NPC_Dwarf_Sad")
                    {


                        go.SetActive(true);
                    }

                }



                isDialog = false; //대화 끝

            }



    }   }
}
