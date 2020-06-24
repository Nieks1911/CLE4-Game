using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Whenever you want to change scenes in unity use:
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void PlayGame() {
        // Pakt het huidige geladen level en doet er plus 1 bij, dus hij laad het volgende level, level 1.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame() {
        Debug.Log("Quit");
        Application.Quit();
    }
}
