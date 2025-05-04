using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Animator animator;
    Rigidbody2D _rigidbody;

    public float flapForce = 6f; // 점프력
    public float forwardSpeed = 3f;// 앞으로 가는 속도
    public bool isDead = false; //죽음?
    float deathcooldown = 0f;// 몇 초 뒤에 죽는가

    bool isFlap = false; // 점프 뛰었나?
    public bool godMod = false; // 치트

    GameManager gameManager;
    // Start is called before the first frame update
    void Start() //시작 될 때 실행
    {
        gameManager = GameManager.Instance;
        animator = GetComponentInChildren<Animator>(); // 컴포넌트 가져오기  InChildren은 하위오브젝트까지 컴포넌트가 있는지 확인
        _rigidbody = GetComponent<Rigidbody2D>(); // 컴포넌트 가져오기


        // 예외처리

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
    void Update() // 프레임마다 실행됨
    {
        if (isDead) // 죽었을때
        {
            if (deathcooldown <= 0f)
            {

                // 게임 재시작


                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))  // 클릭이나 스페이스바 입력시
                {
                    gameManager.GoHome(); // 홈으로

                }
            }
            else 
            {
                    deathcooldown -= Time.deltaTime;
            
            
            }

        }
        else //죽지 않았을때
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))  // 클릭이나 스페이스바 입력시
            { 
                    isFlap = true; // 점프했다고 true
            
            }






        }
    }


    private void FixedUpdate()
    {
        if (isDead) 
        {
            return;
        
        }

        Vector3 velocity = _rigidbody.velocity; //_rigidbody의 가속도를 '일단' 가져옴
        velocity.x = forwardSpeed;
        
        if (isFlap) // 점프했다면
        {
            velocity.y += flapForce;
            isFlap = false;

        }

        _rigidbody.velocity = velocity; //가져온 값을 적용

        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10), -90, 90); //Clamp는 범위내의 값을 제한함
        transform.rotation = Quaternion.Euler(0, 0, angle);





    }

    private void OnCollisionEnter2D(Collision2D collision) //충돌
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
