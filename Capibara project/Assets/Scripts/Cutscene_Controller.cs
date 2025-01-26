using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Cutscene_Manager : MonoBehaviour 
{
    private VideoPlayer Gioco;

    void Start()
    {
        // Ottieni il VideoPlayer collegato
        Gioco = GetComponent<VideoPlayer>();

        // Assegna un evento quando il video termina
        Gioco.loopPointReached += OnCutsceneEnd;
    }

    void OnCutsceneEnd(VideoPlayer vp)
    {
        Debug.Log("Cutscene terminata. Caricamento della scena di gioco...");
        SceneManager.LoadScene("SampleScene"); // Sostituisci con il nome della scena del gioco
    }
}
