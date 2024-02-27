using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int ammoAmount = 2; // ���������� ��������, ������� ���� ������ ��������� ������

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // ���������, ���� � ������� ������� �����
        {
            // ��������� ������� � ���������� ������
            FindObjectOfType<Pistolet>().GetComponent<Pistolet>().AddAmmo(ammoAmount);

            // ���������� ������ �������
            Destroy(gameObject);
        }
    }
}
