using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update


    public float highPosY = 1f;
    public float lowPosY = 1f; //장애물이 상하로 이동할 때 얼마나 이동?

    public float holeSizeMin = 1f;
    public float holeSizeMax = 3f; //top과 bottom 사이의 공간을 얼마나 사용?

    public Transform topObject;
    public Transform bottomObject;

    public float widthPadding = 4f; // 오브젝트 사이의 폭
    GameManager gameManager;

    private void Start()
    {
        gameManager =GameManager.Instance;
    }

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstaclCount)
    {

        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2f;

        topObject.localPosition = new Vector3(0, halfHoleSize);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize); // 홀 사이즈 만큼 두 오브젝트를 벌림

        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0); // 마지막으로 놓인 오브젝트 뒤에 widthPadding 만큼 이동
        placePosition.y = Random.Range(lowPosY, highPosY);
        transform.position = placePosition; 

        return placePosition;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null) {
            gameManager.AddScore(1);
            
        }


    }
}
