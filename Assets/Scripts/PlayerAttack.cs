using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] int playerHealth = 100;
    [SerializeField] GameObject attackAnimation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerAttackAnimation();
    }
    private void PlayerAttackAnimation()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 corrVec = new Vector3 (0.1f, 0.1f, 0f);
            GameObject attack = Instantiate
                (attackAnimation, transform.position-corrVec, Quaternion.identity) as GameObject;
            Destroy(attack, 0.3f);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            DamageDealerScript damageDealer =
                other.gameObject.GetComponent<DamageDealerScript>();
            if (!damageDealer) { return; }
            PlayerDeath(damageDealer);
        }
    }

    private void PlayerDeath(DamageDealerScript damageDealer)
    {
        playerHealth -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (playerHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject, 2f);
    }
}
