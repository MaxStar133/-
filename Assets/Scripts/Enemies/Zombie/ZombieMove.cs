using UnityEngine;

public class ZombieMove : MonoBehaviour
{
	public float speed;

	private Transform playerPosition;

    private void Start()
    {
        PlayerMove playerMove = FindObjectOfType<PlayerMove>();
        if (playerMove != null)
        {
            playerPosition = playerMove.transform;
        }
        else
        {
            Debug.Log ("PlayerMove �� ������ � �����!");
        }
    }
        private void Update()
	{
        if (playerPosition != null)
        {   // ���������� ����� � ������
            transform.position = Vector2.MoveTowards(transform.position, playerPosition.position, speed * Time.deltaTime);

            // ������������ ����� � ������
            Vector3 direction = playerPosition.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
