using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource takeHealSound;
    public AudioSource takeDamageSound;
    public AudioSource backGroundMusic;
    public AudioSource goblinSound;
    public AudioSource goblinBossSound;
    public AudioSource bossMusic;

    private void Start()
    {
        backGroundMusic.Play();
    }
}
