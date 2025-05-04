using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update


    public float highPosY = 1f;
    public float lowPosY = 1f; //��ֹ��� ���Ϸ� �̵��� �� �󸶳� �̵�?

    public float holeSizeMin = 1f;
    public float holeSizeMax = 3f; //top�� bottom ������ ������ �󸶳� ���?

    public Transform topObject;
    public Transform bottomObject;

    public float widthPadding = 4f; // ������Ʈ ������ ��
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
        bottomObject.localPosition = new Vector3(0, -halfHoleSize); // Ȧ ������ ��ŭ �� ������Ʈ�� ����

        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0); // ���������� ���� ������Ʈ �ڿ� widthPadding ��ŭ �̵�
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
