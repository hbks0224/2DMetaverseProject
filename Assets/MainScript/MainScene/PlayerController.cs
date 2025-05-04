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



        // �ߺ� �Է��� �����ϱ� ���� ����
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            characterRenderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            characterRenderer.flipX = false;
        }


        //������ ȿ��
    }



}

    //protected override void Jump()  ��� ����
    //{

    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        Debug.Log("SpaceCheck"); //Ȯ�ο�
    //        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpforce); //����

    //    }
    //}





