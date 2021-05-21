using UnityEngine;

public class Runner : MonoBehaviour
{
    [SerializeField] float sidewaysSpeed;
    [SerializeField] float leftBoundary;
    [SerializeField] float rightBoundary;
    [SerializeField] AudioClip sodaSound;
    [SerializeField] AudioClip biteSound;
    
    
    Animator runnerAnimator;
    AudioSource audioSource;
    
    void Start()
    {
        runnerAnimator = gameObject.GetComponentInChildren<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
        GameManager.instance.Resume();
    }

    void Update()
    {
        Move();

        // Set animation and sound speed to match the current velocity
        runnerAnimator.speed = 1.0f / 15.0f * GameManager.instance.Velocity;
        audioSource.pitch = 0.72f / 1.0f * runnerAnimator.speed * Time.timeScale;
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Milestone":
                GameManager.instance.onMilestone.Invoke();
                break;
            case "Tomato":
                GameManager.instance.onTomato.Invoke();
                audioSource.PlayOneShot(biteSound);
                break;
            case "Soda":
                GameManager.instance.onSoda.Invoke();
                audioSource.PlayOneShot(sodaSound);             
                break;
        }
    }

    // Moves the player side to side according to user input
    void Move()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.Clamp(newPosition.x + horizontalMove * Time.deltaTime * sidewaysSpeed, leftBoundary, rightBoundary);
        transform.position = newPosition;
    }
}