using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{

    [SerializeField] ParticleSystem heartParticles;
    [SerializeField] Button yesButton;
    [SerializeField] Button noButton;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayHeartsAtButton(Transform buttonTransform)
    {
        heartParticles.transform.position = buttonTransform.position;
        heartParticles.Play();

        HideButtons();
    }
    private void HideButtons()
    {
        if (yesButton != null) yesButton.gameObject.SetActive(false);
        if (noButton != null) noButton.gameObject.SetActive(false);
    }
}

