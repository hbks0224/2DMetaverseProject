using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//캐릭터의 움직임을 담당하는 클래스
public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody; // 이동하기 위해 필요한 물리 컴포넌트 선언
    [SerializeField] public SpriteRenderer characterRenderer;
    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return movementDirection; } }

    //public float jumpforce = 1000f; //점프력
   
    

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>(); //리지드바디 컴포넌트를 get

    }


    protected virtual void Update()
    {
        HandleAction();
   
    }
    protected virtual void FixedUpdate()
    {
        Movment(movementDirection);
        //Jump();
    }

    private void Movment(Vector2 direction)
    {
        direction = direction * 8;


        _rigidbody.velocity = direction;
    }

    private void Movement(Vector2 direction)
    {

        direction = direction * 5; //이동 속도


        //실제 물리 이동
        _rigidbody.velocity = direction;

    }

    protected virtual void Start()
    {


    }

    protected virtual void HandleAction()
    {

    }

    //protected virtual void Jump()
    //{


    //}


}
