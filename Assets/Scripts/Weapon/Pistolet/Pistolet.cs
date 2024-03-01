using System.Collections;
using UnityEngine;
using TMPro;

public class Pistolet : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float fireRate = 0.1f;
    [SerializeField] private AudioSource audioGun;
    [SerializeField] private TextMeshProUGUI Ammoes;


    public int minDamage;
    public int maxDamage;
    private bool canShoot = true;
    public float stun = 0.2f;
    public int maxAmmo = 7; // ������������ ���������� ��������
    public int currentAmmo; // ������� ���������� ��������


    private void Start()
    {
        Ammoes.text = currentAmmo + "/" + maxAmmo; // ����� �� ����� ���-�� ������
    }
    private void Update()
    {
        // ��� � ����� ��������� ������� �������
        Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);
        //
        // �������� �� ��������
        if (Input.GetMouseButton(0) && canShoot && currentAmmo > 0)
        {
            currentAmmo--;
            StartCoroutine(Shoot());
            audioGun.Play();
            AmmoUI();
        }
    }
    public void AddAmmo(int amount)
    {
        currentAmmo += amount; // ����������� ������� ���������� ��������
        currentAmmo = Mathf.Clamp(currentAmmo, 0, maxAmmo); // ������������ ���������� �������� ������������ ���������
        AmmoUI();
    }
    private void AmmoUI()
    {
        Ammoes.text = currentAmmo + "/" + maxAmmo;
    }
    private IEnumerator Shoot()
    {
        if (currentAmmo > 0)
        {
            canShoot = false;
            Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(fireRate);
            canShoot = true;
        }
    }
}