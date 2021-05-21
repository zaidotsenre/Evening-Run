using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] float minVelocity; 
    [SerializeField] float maxVelocity;
    [Range(0, 1)][SerializeField] float acceleration;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject background;
    [SerializeField] Text gameOverText;
    [SerializeField] Slider volumeSlider;

    public float Velocity { get { return velocity; } }
    float velocity;

    public UnityEvent onTomato;
    public UnityEvent onSoda;
    public UnityEvent onMilestone;
    public UnityEvent onGameOver;

    void Start ()
    {
        velocity = minVelocity;
        volumeSlider.value = AudioListener.volume;
        volumeSlider.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        StartCoroutine("LerpVelocity");
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (!pauseMenu.activeSelf)
                Pause();
            else
                Resume();
        }
    }

    // Sets the velocity back to minVelocity
    public void ResetVelocity ()
    {
        StopCoroutine("LerpVelocity");
        StartCoroutine("LerpVelocity");
    }

    IEnumerator LerpVelocity ()
    {
        float lerpTime = 0;
        while (true)
        {
            lerpTime += Time.deltaTime;
            velocity = Mathf.Lerp(minVelocity, maxVelocity, acceleration * lerpTime);
            yield return null;
        }
        
    }

    public void Resume ()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        background.SetActive(false);
        volumeSlider.gameObject.SetActive(false);
    }

    public void Pause ()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        background.SetActive(true);
    }

    public void AdjustVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }

    public void ToggleVolumeSlider()
    {
        volumeSlider.gameObject.SetActive(!volumeSlider.gameObject.activeSelf);
    }

    public void EndGame (bool smoothly)
    {
        if (smoothly)
            StartCoroutine("EndSmoothly");
        else
            LoadPostGame();
    }

    void LoadPostGame()
    {
        onGameOver.Invoke();
        SceneManager.LoadScene("Post-Game", LoadSceneMode.Single);
    }

    // Slow the game to a stop and show the game over text
    IEnumerator EndSmoothly ()
    {
        background.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        Color transparent = gameOverText.color;
        float t = 1.0f / 5.0f;
        float timeElapsed = 0.0f;
        while (timeElapsed < 5.0f)
        {
            timeElapsed += Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Lerp(1, 0, t * timeElapsed);
            transparent.a = Mathf.Lerp(0, 1, t * timeElapsed);
            gameOverText.color = transparent;
            yield return null;
        }
        LoadPostGame();
    }

    
}
