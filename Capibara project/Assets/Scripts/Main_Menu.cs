using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Main_Menu : MonoBehaviour

{
    // Funzione per il bottone "Play"
    public void OnPlayButtonClick()
    {
        Debug.Log("Play button clicked!");
        // Esempio: Carica una scena chiamata "GameScene"
        SceneManager.LoadScene("ClipGioco");
    }

    // Funzione per il bottone "Exit"
    public void OnExitButtonClick()
    {
        Debug.Log("Exit button clicked!");

#if UNITY_EDITOR
        // Se siamo nell'editor, ferma la simulazione
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Se siamo in una build reale, chiudi l'applicazione
        Application.Quit();
#endif
    }
    public void OnCreditsButtonClick()
    {
        Debug.Log("Play button clicked!");
        // Esempio: Carica una scena chiamata "GameScene"
        SceneManager.LoadScene("Credits");
    }
}