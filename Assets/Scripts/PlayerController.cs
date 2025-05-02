using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : BaseController //���̽� ��Ʈ�ѷ� ���
{


    protected override void Start()
    {

        base.Start();

    }

    protected override void HandleAction()
    {

        // Ű���� �Է��� ���� �̵� ���� ���
        float horizontal = Input.GetAxisRaw("Horizontal");//a/d
        float vertical = Input.GetAxisRaw("Vertical"); //w/s
        //���� ���� ����ȭ (�밢�� �ӵ� ����)
        movementDirection = new Vector2(horizontal, vertical).normalized;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("SpaceCheck"); //Ȯ�ο�
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpforce); //����
            
        }
    }

    //void OnMove(InputValue inputValue)
    //{
    //    // �Էµ� ���� ���� ���ͷ� �޾ƿ� (WASD ��)
    //    movementDirection = inputValue.Get<Vector2>();
    //    // �밢�� �̵� �� �ӵ� �����ϰ� �����ϱ� ���� ����ȭ
    //    movementDirection = movementDirection.normalized;
    //}



}
