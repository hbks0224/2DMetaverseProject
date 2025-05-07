using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//대화 인터페이스 기본 동작 정의

// NPC마다 다르게 동작 할 수 있도록 자식 클래스에서 DialogAdd() 재정의
public abstract class Dialog : MonoBehaviour
{
    public GameObject Check_F; //대화 범위 안에 들어왔을때 F 입력을 확인
    public List<GameObject> Check_List; //보여줄 UI 오브젝트 리스트
   // bool active_F = false; //F가 켜진걸 확인하는 변수 (지금은 사용안함)
    protected bool isPlayerIn = false; // 플레이어가 대화 범위내에 들어왔는지 확인하는 변수
    protected bool isDialog = false;// 대화중인지 확인하는 변수

    protected virtual void Start() // 시작 할 때 모든 ui off
    {

        Check_F.SetActive(false);
       // active_F = false;


        foreach (var go in Check_List)
            go.SetActive(false); //UI전부 끔

    }

    protected virtual void Update() 
    {

        if (isPlayerIn)
        {

            //범위 안에 있고 F입력시 대화 시작
            if (Input.GetKeyDown(KeyCode.F))
            {

                ShowDialog();

            }
            //자식 클래스에서 정의된 대로 동작
            DialogAdd();
        }

    }

    protected virtual void ShowDialog()
    {
        Check_F.SetActive(false); // F를 눌렀다면 F 패널 사라지게

      //  active_F = false;
        Debug.Log("F off");

        isDialog = true;
        Debug.Log("Dialog on");
        foreach (var go in Check_List)
        {
            go.SetActive(true); // 대화 UI on

            if (go.name == "NPC_Dwarf_Sad") // 이건 예외 오브젝트이기 때문에 끄기
            {


                go.SetActive(false);
            }
        }



    }

    private void OnTriggerEnter2D(Collider2D other) // 플레이어가 범위에 들어오면 F키 패널 on
    {
        if (other.CompareTag("Player"))
        {
            isPlayerIn = true;
            Debug.Log("player in");
            Check_F.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) // 플레이어가 범위에서 나가면 F 패널이랑 대화UI 전부 끔
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

    protected abstract void DialogAdd(); //오버라이드
}

