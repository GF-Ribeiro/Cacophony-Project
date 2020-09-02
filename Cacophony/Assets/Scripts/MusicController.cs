using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip music;
    public int musicBPM;

    AudioClip currentMusic;

    private int currentBPM;
    private float currentBPS;
    private float currentSPB;
    private float currentStartTime;

    private bool tempoMarker;

    public MusicObject musicObject;

    // Start is called before the first frame update
    void Start()
    {
        SetUpNewMusic(music, musicBPM);
    }

    private void SetUpNewMusic(AudioClip newMusic, int bpm)
    {
        currentBPM = bpm;
        currentBPS = currentBPM / 60f;
        currentSPB = 1f / currentBPS;
        audioSource.clip = newMusic;
        audioSource.loop = true;
        audioSource.Play();
        currentStartTime = Time.time;
        StopAllCoroutines();
        StartCoroutine(WaitUntilNextBeat());
    }

    private IEnumerator WaitUntilNextBeat()
    {
        yield return new WaitForSeconds(currentSPB);
        musicObject.Change();
        StartCoroutine(WaitUntilNextBeat());
    }

    public bool GetTempoMarker()
    {
        return tempoMarker;
    }
}
