using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance{get; private set;}
    [SerializeField]private AudioSource Slam, Jump, Walking, Shoot, PowerUp, FirstHit_Platform, SecondHit_Platform;
    [SerializeField]private Slider SFXSlider;
     private const string PLAYER_PREF_SFX_VOLUME = "SFX_Volume";
    private float volume;
    private void Awake() 
    {
        Instance = this;
        // Debug.Log(PlayerPrefs.GetFloat(PLAYER_PREF_SFX_VOLUME));
        if(!PlayerPrefs.HasKey(PLAYER_PREF_SFX_VOLUME))PlayerPrefs.SetFloat(PLAYER_PREF_SFX_VOLUME, 0.3f);
        volume = PlayerPrefs.GetFloat(PLAYER_PREF_SFX_VOLUME);
        
        
    }
    void Start()
    {
        float saveVolume = volume;
        if(SFXSlider.value == volume)
        {
            SFXSlider.value = 0;
        }
        SFXSlider.value = saveVolume;
        // Debug.Log(volume);
        
        UpdateSFX_Volume();
    }

    public void UpdateSFX_Volume(){
        volume = SFXSlider.value;
        if(Slam)Slam.volume = volume;
        if(Jump)Jump.volume = volume;
        if(Walking)Walking.volume = volume;
        if(Shoot)Shoot.volume = volume;
        if(PowerUp)PowerUp.volume = volume;
        if(FirstHit_Platform)FirstHit_Platform.volume = volume;
        if(SecondHit_Platform)SecondHit_Platform.volume = volume;
        // if(noStars_SFX)noStars_SFX.volume = volume;
        
        PlayerPrefs.SetFloat(PLAYER_PREF_SFX_VOLUME, volume);
        // Debug.Log(PlayerPrefs.GetFloat(PLAYER_PREF_SFX_VOLUME));
    }
    public void PlaySlam()
    {
        Slam.Play();
    }
    public void PlayJump()
    {
        Jump.Play();
    }
    public void PlayWalkingSFX()
    {
        Walking.Play();
    }
    public void StopWalkingSFX()
    {
        Walking.Stop();
    }
    public bool isWalkingSFXPlay()
    {
        return Walking.isPlaying;
    }
    public void PlayShoot()
    {
        Shoot.Play();
    }
    public void PlayPowerUp()
    {
        PowerUp.Play();
    }
    public void PlayFirstHit()
    {
        FirstHit_Platform.Play();
    }
    public void PlaySecondHit()
    {
        SecondHit_Platform.Play();
    }
}
