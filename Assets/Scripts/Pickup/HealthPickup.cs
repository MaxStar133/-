using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    // ���������� ��, ������� ���� ������ ������
    public int minHpAmount = 2;
    public int maxHpAmount = 5;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // ���������, ���� � ������� ������� �����
        {
            // ��������� ������� � ���������� ������
            FindObjectOfType<PlayerHealth>().GetComponent<PlayerHealth>().AddHp(Random.Range(minHpAmount, maxHpAmount + 1));

            // ���������� ������ 
            Destroy(gameObject);
        }
    }
}
