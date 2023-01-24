using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    // Start is called before the first frame update
    [SerializeField] private AudioClip buttonClick;
    [SerializeField] private AudioClip resetLevelSound;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip winSound;
    [SerializeField] private AudioClip colorPickup;
    [SerializeField] private AudioClip colorLose;
    [SerializeField] private AudioClip backToColor;
    [SerializeField] GameObject UniClip;
    private void Awake()
    {
        instance= this;
    }
    void Start()
    {
        
    }
    public void playNextLevelSound()
    {
        GameObject clipper = Instantiate(UniClip);
        clipper.GetComponent<UniversalClipSpeaker>().PlayCLip(buttonClick);
    }
    public void playResetSound()
    {
        GameObject clipper = Instantiate(UniClip);
        clipper.GetComponent<UniversalClipSpeaker>().PlayCLip(resetLevelSound);
    }
    public void playJumpSound()
    {
        GameObject clipper = Instantiate(UniClip);
        clipper.GetComponent<UniversalClipSpeaker>().PlayCLip(jumpSound);
    }
    public void playWinSound()
    {
        GameObject clipper = Instantiate(UniClip);
        clipper.GetComponent<UniversalClipSpeaker>().PlayCLip(winSound);
    }
    public void playBackToColorSound()
    {
        GameObject clipper = Instantiate(UniClip);
        clipper.GetComponent<UniversalClipSpeaker>().PlayCLip(backToColor);
    }
    public void playLoseColorSound()
    {
        GameObject clipper = Instantiate(UniClip);
        clipper.GetComponent<UniversalClipSpeaker>().PlayCLip(colorLose);
    }
    public void playColorPickup()
    {
        GameObject clipper = Instantiate(UniClip);
        clipper.GetComponent<UniversalClipSpeaker>().PlayCLip(colorPickup);
    }
}
