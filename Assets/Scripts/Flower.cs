using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : UnityEngine.MonoBehaviour
{

    public AudioSource takeFlowerSound;

    public void TakeSound()
    {
        takeFlowerSound.Play();
    }

}
