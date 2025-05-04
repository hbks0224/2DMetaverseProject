using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Animator animator;
    Rigidbody2D _rigidbody;

    public float flapForce = 6f; // ������
    public float forwardSpeed = 3f;// ������ ���� �ӵ�
    public bool isDead = false; //����?
    float deathcooldown = 0f;// �� �� �ڿ� �״°�

    bool isFlap = false; // ���� �پ���?
    public bool godMod = false; // ġƮ

    GameManager gameManager;
    // Start is called before the first frame update
    void Start() //���� �� �� ����
    {
        gameManager = GameManager.Instance;
        animator = GetComponentInChildren<Animator>(); // ������Ʈ ��������  InChildren�� ����������Ʈ���� ������Ʈ�� �ִ��� Ȯ��
        _rigidbody = GetComponent<Rigidbody2D>(); // ������Ʈ ��������


        // ����ó��

        if (animator == null)
        {
            Debug.LogError("Not Founded Animator");

        }        
        if (_rigidbody == null)
        {
            Debug.LogError("Not Founded Rigidbody");

        }
            
    }

    // Update is called once per frame
    void Update() // �����Ӹ��� �����
    {
        if (isDead) // �׾�����
        {
            if (deathcooldown <= 0f)
            {

                // ���� �����


                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))  // Ŭ���̳� �����̽��� �Է½�
                {
                    gameManager.GoHome(); // Ȩ����

                }
            }
            else 
            {
                    deathcooldown -= Time.deltaTime;
            
            
            }

        }
        else //���� �ʾ�����
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))  // Ŭ���̳� �����̽��� �Է½�
            { 
                    isFlap = true; // �����ߴٰ� true
            
            }






        }
    }


    private void FixedUpdate()
    {
        if (isDead) 
        {
            return;
        
        }

        Vector3 velocity = _rigidbody.velocity; //_rigidbody�� ���ӵ��� '�ϴ�' ������
        velocity.x = forwardSpeed;
        
        if (isFlap) // �����ߴٸ�
        {
            velocity.y += flapForce;
            isFlap = false;

        }

        _rigidbody.velocity = velocity; //������ ���� ����

        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10), -90, 90); //Clamp�� �������� ���� ������
        transform.rotation = Quaternion.Euler(0, 0, angle);





    }

    private void OnCollisionEnter2D(Collision2D collision) //�浹
    {
        if (godMod)
        {

            return;

        }

        if (isDead) {


            return;
        }
        isDead = true;
        deathcooldown = 1f;

        animator.SetInteger("IsDie", 1);
        gameManager.GameOver();
    }
}
