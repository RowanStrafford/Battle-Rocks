using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    private bool isPaused = false;
    private bool fadeScreenIn = false;
    private bool fadeSettingsAndControlsScreenIn = false;
    private bool fadeSettings = false;
    private bool fadeControls = false;

    public float pauseScreenFadeSpeed;
    public float pauseScreenAlphaValue;

    public Text pauseText;
    public Image pauseScreen;
    public Image[] pauseMenuButtonsAndButtonText;
    public Image settingsAndControlsScreen;
    public Image settingsHeadingText;
    public Image controlsHeadingText;

    private AudioSource audio;
    public AudioClip mouseOverSound;

    void Start ()
    {
        audio = GetComponent<AudioSource>();

        pauseText.color = new Color(1, 1, 1, 0);                
        pauseScreen.color = new Color(1, 1, 1, 0);
        settingsAndControlsScreen.color = new Color(1, 1, 1, 0);
        settingsHeadingText.color = new Color(1, 1, 1, 0);
        controlsHeadingText.color = new Color(1, 1, 1, 0);
        
        for (int i = 0; i < pauseMenuButtonsAndButtonText.Length; i++)
        {
            pauseMenuButtonsAndButtonText[i].enabled = false;
            pauseMenuButtonsAndButtonText[i].color = new Color(1, 1, 1, 0);
        }
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space)) PauseButtonClicked();

        if (fadeSettingsAndControlsScreenIn)     // If the settings or controls screen should be faded in
        {
            for (int i = 0; i < pauseMenuButtonsAndButtonText.Length; i++)
            {
                FadeImage(pauseMenuButtonsAndButtonText[i], 0f, pauseScreenFadeSpeed);
            }

            FadeImage(settingsAndControlsScreen, 0.3f, pauseScreenFadeSpeed);
        }

        if(fadeSettings)
        {
            FadeImage(settingsHeadingText, 0.3f, pauseScreenFadeSpeed);
            controlsHeadingText.color = new Color(1, 1, 1, 0);
            return;
        }

        if (fadeControls)
        {
            FadeImage(controlsHeadingText, 0.3f, pauseScreenFadeSpeed);
            settingsHeadingText.color = new Color(1, 1, 1, 0);
            return;
        }

        if (fadeScreenIn)
        {
            FadeImage(pauseScreen, 0.3f, pauseScreenFadeSpeed);
            pauseText.color = new Color(1, 1, 1, Mathf.Lerp(pauseText.color.a, 0.3f, Time.deltaTime * pauseScreenFadeSpeed));


            for (int i = 0; i < pauseMenuButtonsAndButtonText.Length; i++)
            {
                FadeImage(pauseMenuButtonsAndButtonText[i], 0.3f, pauseScreenFadeSpeed);
                pauseMenuButtonsAndButtonText[i].enabled = true;
            }
        }
        else
        {
            pauseText.color = new Color(1, 1, 1, Mathf.Lerp(pauseText.color.a, 0f, Time.deltaTime * pauseScreenFadeSpeed));
            FadeImage(pauseScreen, 0f, pauseScreenFadeSpeed);
            FadeImage(settingsAndControlsScreen, 0f, pauseScreenFadeSpeed);
            FadeImage(settingsHeadingText, 0f, pauseScreenFadeSpeed);
            FadeImage(controlsHeadingText, 0f, pauseScreenFadeSpeed);


            for (int i = 0; i < pauseMenuButtonsAndButtonText.Length; i++)
            {
                FadeImage(pauseMenuButtonsAndButtonText[i], 0f, pauseScreenFadeSpeed);

                pauseMenuButtonsAndButtonText[i].enabled = false;
            }
        }
    }

    void FadeImage(Image imageToFade, float amountToFadeTo, float fadeSpeed)
    {
        imageToFade.color = new Color(1, 1, 1, Mathf.Lerp(imageToFade.color.a, amountToFadeTo, Time.deltaTime * fadeSpeed));
    }

    public void PauseButtonClicked()
    {
        if (isPaused) fadeScreenIn = false;
        else fadeScreenIn = true;

        isPaused = !isPaused;
    }

    public void ResumeGame()
    {
        fadeScreenIn = false;
    }

    public void DisplaySettings()
    {
        fadeSettings = true;
        fadeSettingsAndControlsScreenIn = true;        
    }

    public void DisplayControls()
    {
        fadeControls = true;
        fadeSettingsAndControlsScreenIn = true;
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene(0);  // Loads the main menu built to scene index 1
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
