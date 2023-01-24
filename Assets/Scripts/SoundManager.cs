using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    // Start is called before the first frame update
    [SerializeField] private AudioClip buttonClick;
    [SerializeField] private AudioClip resetLevelSound;
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
