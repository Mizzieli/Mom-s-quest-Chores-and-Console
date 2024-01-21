using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   [SerializeField]  AudioSource musicSource;
   [SerializeField]  AudioSource SFXSource;
   [SerializeField]  AudioSource GameOver;

   public AudioClip background;
   public AudioClip jump;
   public AudioClip gameOver;
   public AudioClip scoreIncrease;

   private void Start()
   {
      musicSource.clip = background;
      musicSource.Play();
   }

   public void PlaySFX(AudioClip clip)
   {
      SFXSource.PlayOneShot(clip);
   }
   
   public void PlayGameOver()
   {
      SFXSource.PlayOneShot(gameOver);
   }

   public void PlayScoreIncrease()
   {
      SFXSource.PlayOneShot(scoreIncrease);
   }
}
