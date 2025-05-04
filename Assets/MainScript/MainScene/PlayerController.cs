using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : BaseController //베이스 컨트롤러 상속
{
    
    
    protected override void Start()
    {

        base.Start();
        

    }

    protected override void HandleAction()
    {

        // 키보드 입력을 통해 이동 방향 계산
        float horizontal = Input.GetAxisRaw("Horizontal");//a/d
        float vertical = Input.GetAxisRaw("Vertical"); //w/s
        //방향 백터 정규화 (대각선 속도 보정)
        movementDirection = new Vector2(horizontal, vertical).normalized;



        // 중복 입력을 방지하기 위한 조건
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            characterRenderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            characterRenderer.flipX = false;
        }


        //샤샤샥 효과
    }



}

    //protected override void Jump()  잠시 보류
    //{

    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        Debug.Log("SpaceCheck"); //확인용
    //        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpforce); //점프

    //    }
    //}





