﻿using UnityEngine;
using System.Collections;

namespace GM
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager instance;

        public bool bgSound = true;
        public bool efSound = true;

        [SerializeField]
        AudioSource mainAudio;
        [SerializeField]
        AudioSource effectAudio;
        [SerializeField]
        AudioSource effectAudio2;

        [SerializeField]
        AudioClip selectStage;

        [SerializeField]
        AudioClip ingameClip;
        [SerializeField]
        AudioClip rainClip;
        [SerializeField]
        AudioClip endingClip;

        [SerializeField]
        AudioClip deathPoliceClip;

        [SerializeField]
        AudioClip cabinetClip;
        [SerializeField]
        AudioClip doorClip;
        [SerializeField]
        AudioClip stairClip;

        [SerializeField]
        AudioClip gunClip;
        [SerializeField]
        AudioClip knifeClip;

        void Start()
        {
            instance = this;
            DontDestroyOnLoad(this);
        }

        public void ingameBG()
        {
            mainAudio.clip = ingameClip;
            mainAudio.Play();
        }
        public void rainBG()
        {
            mainAudio.clip = rainClip;
            mainAudio.Play();
        }
        public void endingBG()
        {
            mainAudio.clip = stairClip;
            mainAudio.Play();
        }

        public delegate void bgEffect();
        public IEnumerator changeVolume(bgEffect func)
        {
            while (mainAudio.volume > 0)
            {
                mainAudio.volume -= 0.05f;
                yield return new WaitForSeconds(0.07f);
            }
            func();
            while (mainAudio.volume < 1)
            {
                mainAudio.volume += 0.05f;
                yield return new WaitForSeconds(0.07f);
            }

        }

        public void deathPolice()
        {
            effectAudio.volume = 0.8f;
            effectAudio.clip = deathPoliceClip;
            effectAudio.Play();
        }

        public void cabinetIn()
        {
            effectAudio.volume = 1;
            effectAudio.clip = cabinetClip;
            effectAudio.Play();
        }

        public void doorIn()
        {
            effectAudio.volume = 1;
            effectAudio.clip = doorClip;
            effectAudio.Play();
        }

        public void stair()
        {
            effectAudio.volume = 1;
            effectAudio.clip = stairClip;
            effectAudio.Play();
        }

        public void byKnife()
        {
            effectAudio2.volume = 1;
            effectAudio2.clip = knifeClip;
            effectAudio2.Play();
        }
        public void byGun()
        {
            effectAudio2.volume = 1;
            effectAudio2.clip = gunClip;
            effectAudio2.Play();
        }
    }
}