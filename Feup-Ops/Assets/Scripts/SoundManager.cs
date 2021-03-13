using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerHitSound, playerShootSound, playerJumpSound;
    public static AudioClip enemyNearSound, enemyDeathSound;
    public static AudioClip bossAttackSound;
    public static AudioClip collectableSound;
    static AudioSource audioSrc;

    void Start()
    {
        /*player related*/
        //playerHitSound = Resources.Load<AudioClip>("Sound/playerHit");
        playerShootSound = Resources.Load<AudioClip>("Sound/playerShoot");
        playerJumpSound = Resources.Load<AudioClip>("Sound/playerJump");

        /* enemy related */
        enemyDeathSound = Resources.Load<AudioClip>("Sound/enemyDeath");
        bossAttackSound = Resources.Load<AudioClip>("Sound/enemyNear");

        /* collectables related */
        collectableSound = Resources.Load<AudioClip>("Sound/collectableSound");
        audioSrc = GetComponent<AudioSource>();
    }
    void Update()
    {}

    public static void playSound(string clip, float volume){  

        switch(clip) {
            case "playerHit": audioSrc.PlayOneShot(playerHitSound, volume);
            break;
            case "playerShoot": audioSrc.PlayOneShot(playerShootSound, volume);
            break;
            case "playerJump": audioSrc.PlayOneShot(playerJumpSound, volume);
            break;
            case "enemyDeath": audioSrc.PlayOneShot(enemyDeathSound, volume);
            break;
            case "bossAtack": audioSrc.PlayOneShot(bossAttackSound, volume);
            break;
            case "collectable": audioSrc.PlayOneShot(collectableSound, volume);
            break;
        }
    }
}
