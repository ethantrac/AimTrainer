using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayClick : MonoBehaviour
{
    public AudioSource click;

    public void PlayClickSound() {
        click.Play();
    }
}
