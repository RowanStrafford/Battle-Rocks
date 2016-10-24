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

    void Start ()
    {
        pauseText.color = new Color(1, 1, 1, 0);                
        pauseScreen.color = new Color(1, 1, 1, 0);
        settingsAndControlsScreen.color = new Color(1, 1, 1, 0);
        settingsHeadingText.color = new Color(1, 1, 1, 0);
        controlsHeadingText.color = new Color(1, 1, 1, 0);
        
        for (int i = 0; i < pauseMenuButtonsAndButtonText.Length; i++)
        {
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
                pauseMenuButtonsAndButtonText[i].color = new Color(1, 1, 1, Mathf.Lerp(pauseMenuButtonsAndButtonText[i].color.a, 0f, Time.deltaTime * pauseScreenFadeSpeed));
            }

            settingsAndControlsScreen.color = new Color(1, 1, 1, Mathf.Lerp(settingsAndControlsScreen.color.a, pauseScreenAlphaValue, Time.deltaTime * pauseScreenFadeSpeed));
        }

        if(fadeSettings)
        {
            settingsHeadingText.color = new Color(1, 1, 1, Mathf.Lerp(settingsHeadingText.color.a, pauseScreenAlphaValue, Time.deltaTime * pauseScreenFadeSpeed));
            controlsHeadingText.color = new Color(1, 1, 1, 0);
            return;

        }

        if (fadeControls)
        {
            settingsHeadingText.color = new Color(1, 1, 1, 0);
            controlsHeadingText.color = new Color(1, 1, 1, Mathf.Lerp(controlsHeadingText.color.a, pauseScreenAlphaValue, Time.deltaTime * pauseScreenFadeSpeed));
            return;
        }

        if (fadeScreenIn)
        {            
            pauseScreen.color = new Color(1, 1, 1, Mathf.Lerp(pauseScreen.color.a, pauseScreenAlphaValue, Time.deltaTime * pauseScreenFadeSpeed));
            pauseText.color = new Color(1, 1, 1, Mathf.Lerp(pauseText.color.a, 0.3f, Time.deltaTime * pauseScreenFadeSpeed));

            for(int i = 0; i < pauseMenuButtonsAndButtonText.Length; i++)
            {
                pauseMenuButtonsAndButtonText[i].color = new Color(1, 1, 1, Mathf.Lerp(pauseMenuButtonsAndButtonText[i].color.a, pauseScreenAlphaValue, Time.deltaTime * pauseScreenFadeSpeed));
            }
        }
        else
        {            
            pauseScreen.color = new Color(1, 1, 1, Mathf.Lerp(pauseScreen.color.a, 0f, Time.deltaTime * pauseScreenFadeSpeed));       
            pauseText.color = new Color(1, 1, 1, Mathf.Lerp(pauseText.color.a, 0f, Time.deltaTime * pauseScreenFadeSpeed));

            for (int i = 0; i < pauseMenuButtonsAndButtonText.Length; i++)
            {
                pauseMenuButtonsAndButtonText[i].color = new Color(1, 1, 1, Mathf.Lerp(pauseMenuButtonsAndButtonText[i].color.a, 0f, Time.deltaTime * pauseScreenFadeSpeed));
            }
        }
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
