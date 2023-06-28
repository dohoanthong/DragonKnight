using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;

public class FireTrap : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] float activationDelay;
    [SerializeField] float activeTime;
    [SerializeField] Animator anim;
    [SerializeField] SpriteRenderer spriteRend;
    [SerializeField] AudioClip fireSound;
    [SerializeField] bool active; //when the trap is active and can hurt the player
    [SerializeField] Transform player;
    private void Awake()
    {
        StartCoroutine(ActivateFiretrap());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            if (active)
            {
                collision.GetComponentInChildren<PlayerHealth>().getDMG(damage);
            }
                   
        }
    }
    private IEnumerator ActivateFiretrap()
    {
        while (true)
        {
            spriteRend.color = Color.red;
            yield return new WaitForSeconds(activationDelay);

            spriteRend.color = Color.white; 
            active = true;
            anim.SetBool("active", true);
            SoundManager.Instant.PlaySound(fireSound);

            yield return new WaitForSeconds(activeTime);
            active = false;
            anim.SetBool("active", false);
        }
        
    }
}