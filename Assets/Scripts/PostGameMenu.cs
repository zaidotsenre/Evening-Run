using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PostGameMenu : MonoBehaviour
{
    [SerializeField] Text scoreUI;

    void Start()
    {
        int score = PlayerPrefs.GetInt("latestScore");
        scoreUI.text = score.ToString();
    }

    public void PlayAgain ()
    {
        SceneManager.LoadScene("Play", LoadSceneMode.Single);
    }
}
