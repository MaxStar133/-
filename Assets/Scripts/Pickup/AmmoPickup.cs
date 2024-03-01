using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    // ���������� ��������, ������� ���� ������ ��������� ������
    public int minAmmoAmount = 2; 
    public int maxAmmoAmount = 5;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // ���������, ���� � ������� ������� �����
        {
            // ��������� ������� � ���������� ������
            FindObjectOfType<Pistolet>().GetComponent<Pistolet>().AddAmmo(Random.Range(minAmmoAmount,maxAmmoAmount+1));

            // ���������� ������ �������
            Destroy(gameObject);
        }
    }
}
