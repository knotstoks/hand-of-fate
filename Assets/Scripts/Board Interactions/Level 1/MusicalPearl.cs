using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicalPearl : MonoBehaviour
{
    public int pearlNumber;
    public AudioSource audioSource;
    public AudioClip sound;
    public bool isPlaying;
    public MusicalPearlManager musicalPearlManager;
    private void Start()
    {
        isPlaying = false;
    }
    private void OnMouseDown()
    {
        if (!isPlaying)
        {
            StartCoroutine(PlayNote());
        }
    }
    private IEnumerator PlayNote()
    {
        isPlaying = true;
        audioSource.PlayOneShot(sound);
        yield return new WaitForSeconds(1);
        musicalPearlManager.PearlPressed(pearlNumber);
        isPlaying = false;
    }
}
