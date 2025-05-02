using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ĳ������ �������� ����ϴ� Ŭ����
public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody; // �̵��ϱ� ���� �ʿ��� ���� ������Ʈ ����
    [SerializeField] private SpriteRenderer characterRenderer;
    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return movementDirection; } }

    public float jumpforce = 5f; //������

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>(); //������ٵ� ������Ʈ�� get

    }


    protected virtual void Update()
    {
        HandleAction();
   
    }
    protected virtual void FixedUpdate()
    {
        Movment(movementDirection);

    }

    private void Movment(Vector2 direction)
    {
        direction = direction * 5;


        _rigidbody.velocity = direction;
    }

    private void Movement(Vector2 direction)
    {

        direction = direction * 5; //�̵� �ӵ�


        //���� ���� �̵�
        _rigidbody.velocity = direction;

    }

    protected virtual void Start()
    {


    }

    protected virtual void HandleAction()
    {

    }



}
