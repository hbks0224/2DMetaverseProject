using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YesNoDialog : Dialog
{

    //FŰ�� ��ȭ ���� �� Y�� N�Է¿� ���� �����ϴ� ��ũ��Ʈ
    protected override void DialogAdd()
    {

        //��ȭ ���϶��� ����
        if (isDialog == true)
        {

           // Debug.Log("ddddd");

            //Y �Է½� ���Ӿ����� �̵�
            if (Input.GetKeyDown(KeyCode.Y))
            {
                Debug.Log("input y go game");

                SceneManager.LoadScene("GameScene");

            }
            //N �Է½� ��ȭ�� ����ϰ� ���� UI�� ǥ��

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



                isDialog = false; //��ȭ ��

            }



    }   }
}
