using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	[SerializeField]  public int health;
	private KilledEnemyDisplay enemyDisplay;
	[SerializeField] private AudioSource audioEnemy;
	private void Start()
    {
		enemyDisplay = FindObjectOfType<KilledEnemyDisplay>().GetComponent<KilledEnemyDisplay>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
   {
		  if(collision.gameObject.TryGetComponent(out Bullet bullet))
		  {
			TakeDamage();
			audioEnemy.Play();	
			Destroy(bullet.gameObject);
		  }
   }

   private void TakeDamage()
   {
    health-Gun.damage;

	if (health<=0)
	{
			gameObject.SetActive(false);
			enemyDisplay.KilledEnemy();
			health = 4;
	}
   }



}
 