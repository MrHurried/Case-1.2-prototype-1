using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] List<AudioClip> audioClips;
    int clipIndex = -1;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.volume = 0;
        clipIndex++;
        audioSource.clip = audioClips[clipIndex];
        audioSource.Play();

        StartCoroutine("PlayGameMusic");
    }

    IEnumerator PlayGameMusic()
    {
        while (true)
        {
            if (audioSource.isPlaying == false)
            {
                audioSource.volume = 0;
                clipIndex++;
                if (clipIndex > audioClips.Count-1)
                    clipIndex = 0;
                audioSource.clip = audioClips[clipIndex];
                audioSource.Play();
                
            }
            else if (audioSource.time > audioSource.clip.length - 10f)
            {
                audioSource.volume -= .1f * Time.deltaTime;
                yield return null;
            }
            else if (audioSource.time < 10f)
            {
                audioSource.volume += .1f * Time.deltaTime;
                yield return null;
            }
            else
            {
                yield return null;
            }
        }
    }
}
