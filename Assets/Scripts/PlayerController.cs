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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("SpaceCheck"); //확인용
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpforce); //점프
            
        }
    }

    //void OnMove(InputValue inputValue)
    //{
    //    // 입력된 방향 값을 벡터로 받아옴 (WASD 등)
    //    movementDirection = inputValue.Get<Vector2>();
    //    // 대각선 이동 시 속도 일정하게 유지하기 위해 정규화
    //    movementDirection = movementDirection.normalized;
    //}



}
