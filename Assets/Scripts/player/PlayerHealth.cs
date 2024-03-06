using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float timeToDamage;
    [SerializeField] private GameObject loseMenu;
    [SerializeField] private TextMeshProUGUI textAidKit;
    [SerializeField] private AudioSource audioDie;
    [SerializeField] private int currentAidKit=0;
    [SerializeField] private Animator anim;
    //[SerializeField] private int maxAidKit=5;

    public Image LineBar;
    private float MaxHP = 100;
    private Pistolet loseGun;
    private Rigidbody2D rb;
    private Zombie damage;
    private float time = 1;
    public bool playerDie = false;
    public int minHpAmount = 2;
    public int maxHpAmount = 5;

    private void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        loseGun = FindObjectOfType<Pistolet>().GetComponent<Pistolet>();
        textAidKit.text = currentAidKit + "x";
    }

    private void Update()
    {
       if (Input.GetButtonDown("Heal")){
            if (health < MaxHP && currentAidKit > 0)
            AddHp();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!playerDie)
        {
            if (collision.gameObject.TryGetComponent(out Zombie enemy))
            {
                time += Time.deltaTime;
                if (time >= timeToDamage)
                {
                    TakeDamage();
                    GetComponent<AudioSource>().Play();
                    time = 0;
                }
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Zombie enemy))
        {
            time = 1;
        }
    }
    private void TakeDamage()
    {
        anim.SetTrigger("takeDamage");
        damage = FindObjectOfType<Zombie>().GetComponent<Zombie>();
        health = health - Random.Range(damage.minDamageEnemy, damage.maxDamageEnemy+1);
        if (health < 0)
        {
            health = 0;
        }
        Fill();

        if (health <= 0)
        {
            audioDie.Play();
            health = 0; 
            loseMenu.SetActive(true);
            rb.bodyType = RigidbodyType2D.Static;
            playerDie = true;
            loseGun.enabled = false;
        }
    }
    public void AddAidKit()
    {
        currentAidKit++;
        textAidKit.text = currentAidKit + "x";
    }
    private void AddHp()
    {
        health += Random.Range(minHpAmount, maxHpAmount + 1);
        health = Mathf.Clamp(health, 0, MaxHP);
        Fill();
        currentAidKit--;
        textAidKit.text = currentAidKit + "x";
    }
    private void Fill()
    {
        LineBar.fillAmount = health / 100;
    }
}
