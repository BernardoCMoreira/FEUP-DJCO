using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerHitSound, playerShootSound, playerJumpSound;
    public static AudioClip enemyNearSound, enemyDeathSound;
    public static AudioClip bossAttack;
    static AudioSource audioSrc;

    void Start()
    {
        /*player related*/
        playerHitSound = Resources.Load<AudioClip>("playerHit");
        playerShootSound = Resources.Load<AudioClip>("playerShoot");
        playerJumpSound = Resources.Load<AudioClip>("playerJump");

        /* enemy related */
        enemyNearSound = Resources.Load<AudioClip>("enemyNear");
        enemyDeathSound = Resources.Load<AudioClip>("Sound/explosion_26");
        bossAttack = Resources.Load<AudioClip>("bossAtack");

        audioSrc = GetComponent<AudioSource>();
    }
    void Update()
    {}

    public static void playSound(string clip){  

        switch(clip) {
            case "playerHit": audioSrc.PlayOneShot(playerHitSound);
            break;
            case "playerShoot": audioSrc.PlayOneShot(playerShootSound);
            break;
            case "playerJump": audioSrc.PlayOneShot(playerJumpSound);
            break;
            case "enemyNear": audioSrc.PlayOneShot(enemyNearSound);
            break;
            case "enemyDeath": audioSrc.PlayOneShot(enemyDeathSound, 1.0f); /* clip, volume */
            break;
            case "bossAtack": audioSrc.PlayOneShot(bossAttack);
            break;
        }
    }
}
