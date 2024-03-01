using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // ���������, ���� � ������� ������� �����
        {
            // ��������� ������� � ���������� ������
            FindObjectOfType<PlayerHealth>().GetComponent<PlayerHealth>().AddAidKit();

            // ���������� ������ 
            Destroy(gameObject);
        }
    }
}
