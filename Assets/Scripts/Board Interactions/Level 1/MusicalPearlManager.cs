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
    private bool gemRevealed;
    private void Start()
    {
        gemRevealed = false;
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
                // Play the theme
                audioSource.PlayOneShot(grandTheme);

                // TODO: Animation of Pearls lighting up

                // Reveal Gem if you haven't
                RevealGem();
            }
        }
        else
        {
            // Reset the counter
            currentNote = 0;

            // Check to see if the note pressed is the first one
            if (pearlNumber == correctNotes[0])
            {
                currentNote = 1;
            }
        }
    }

    private void RevealGem()
    {
        if (!gemRevealed)
        {
            gemRevealed = true;

            // TODO: Animation
            
        }
        
    }
}
