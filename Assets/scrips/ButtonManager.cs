using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AudioSource))]
public class ButtonManager : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;

    public AudioClip audioClip1;
    public AudioClip audioClip2;
    public AudioClip audioClip3;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Agrega los listeners para detectar cuando el mouse está sobre los botones
        AddHoverEvent(button1, audioClip1);
        AddHoverEvent(button2, audioClip2);
        AddHoverEvent(button3, audioClip3);
    }

    void AddHoverEvent(Button button, AudioClip audioClip)
    {
        EventTrigger trigger = button.gameObject.GetComponent<EventTrigger>();
        if (trigger == null)
        {
            trigger = button.gameObject.AddComponent<EventTrigger>();
        }

        EventTrigger.Entry entryEnter = new EventTrigger.Entry();
        entryEnter.eventID = EventTriggerType.PointerEnter;
        entryEnter.callback.AddListener((data) => { PlayAudioPreview(audioClip); });

        EventTrigger.Entry entryExit = new EventTrigger.Entry();
        entryExit.eventID = EventTriggerType.PointerExit;
        entryExit.callback.AddListener((data) => { StopAudioPreview(); });

        trigger.triggers.Add(entryEnter);
        trigger.triggers.Add(entryExit);
    }

    void PlayAudioPreview(AudioClip clip)
    {
        // Reproduce la vista previa del audio asociado al botón
        if (clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }

    void StopAudioPreview()
    {
        // Detiene la reproducción cuando el mouse sale del botón
        audioSource.Stop();
    }
}
