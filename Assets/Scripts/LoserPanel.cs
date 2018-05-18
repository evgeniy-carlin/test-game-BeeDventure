using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoserPanel : MonoBehaviour {

    public Character character;

    public void Retry()
    {
        Time.timeScale = 1f;
        Application.LoadLevel(0);
        character.LoserPanel.SetActive(false);
    }

}
