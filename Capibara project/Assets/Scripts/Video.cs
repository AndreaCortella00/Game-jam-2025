using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Video : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "gioco.mov");
        videoPlayer.loopPointReached += OnCutsceneEnd;
    }
    void OnCutsceneEnd(VideoPlayer vp)
    {
        Debug.Log("Cutscene terminata. Caricamento della scena di gioco...");
        SceneManager.LoadScene("SampleScene"); // Sostituisci con il nome della scena del gioco
    }

}
