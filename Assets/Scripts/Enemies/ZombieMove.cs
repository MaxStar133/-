using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
	[SerializeField] public float speed;

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
		{
			transform.position = Vector2.MoveTowards(transform.position, playerPosition.position, speed * Time.deltaTime);
		}
	}
}
