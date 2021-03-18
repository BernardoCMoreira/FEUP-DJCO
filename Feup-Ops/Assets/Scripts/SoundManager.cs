
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    [SerializeField] float volume = 0.5f;

    public static AudioClip playerHitSound, playerShootSound, playerJumpSound;
    public static AudioClip enemyNearSound, enemyDeathSound;
    public static AudioClip bossAttackSound;
    public static AudioClip collectableSound;
    static AudioSource audioSrcActions;

    public AudioSource GameoverAudioSrc;
    public AudioSource WinAudioSrc;
    public AudioSource WinMITAudioSrc;
    public AudioSource gameAudioSrc;

    void Start()
    {
        /*player related*/
        //playerHitSound = Resources.Load<AudioClip>("Sound/playerHit"); --------
        playerShootSound = Resources.Load<AudioClip>("Sound/playerShoot");
        playerJumpSound = Resources.Load<AudioClip>("Sound/playerJump");

        /* enemy related */
        enemyDeathSound = Resources.Load<AudioClip>("Sound/enemyDeath");
        bossAttackSound = Resources.Load<AudioClip>("Sound/enemyNear");

        /* collectables related */
        collectableSound = Resources.Load<AudioClip>("Sound/collectableSound");
        audioSrcActions = GetComponent<AudioSource>();
    }

    private void Update(){
        if (SceneManager.GetActiveScene().name == "SampleScene"){
            gameAudioSrc.volume = volume;
            WinMITAudioSrc.volume = volume;
            WinAudioSrc.volume = volume;
            GameoverAudioSrc.volume = volume;
        }

        audioSrcActions.volume = volume;
    }

    public void SetVolume(float vol){
        volume=vol;
    }

    public static void playSound(string clip, float volume){       
        switch(clip) {
            case "playerHit": audioSrcActions.PlayOneShot(playerHitSound, volume);
            break;
            case "playerShoot": audioSrcActions.PlayOneShot(playerShootSound, volume);
            break;
            case "playerJump": audioSrcActions.PlayOneShot(playerJumpSound, volume);
            break;
            case "enemyDeath": audioSrcActions.PlayOneShot(enemyDeathSound, volume);
            break;
            case "bossAtack": audioSrcActions.PlayOneShot(bossAttackSound, volume);
            break;
            case "collectable": audioSrcActions.PlayOneShot(collectableSound, volume);
            break;
        }
    }
}
