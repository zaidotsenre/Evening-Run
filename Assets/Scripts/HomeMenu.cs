using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeMenu : MonoBehaviour
{
    [SerializeField] Button playButton;

    void Start()
    {
        playButton.onClick.AddListener(Play);
    }

    void Play ()
    {
        SceneManager.LoadScene("Play", LoadSceneMode.Single);
    }
}
