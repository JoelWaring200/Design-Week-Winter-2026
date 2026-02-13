using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer instance;

    [SerializeField] private AudioSource audioSource;

    private void Awake()
    {
       
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

     
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();

        
        if (audioSource != null && !audioSource.isPlaying)
            audioSource.Play();
    }
}
