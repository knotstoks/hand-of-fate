using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicalPearlManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip grandTheme;
    private int[] correctNotes;
    private int currentNote;
    private void Start()
    {
        currentNote = 0;
    }
    public void PearlPressed(int pearlNumber)
    {
        if (pearlNumber == correctNotes[currentNote])
        {
            currentNote++;

            // Check if the correct full combination was keyed in
            if (currentNote == correctNotes.Length)
            {
                RevealGem();
            }
        }
    }

    private void RevealGem()
    {
        // TODO: Animation and Sound
        audioSource.PlayOneShot(grandTheme);
    }
}
