using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenuBehavior : MainMenuBehaviour
{
    public static bool isPaused;
    public GameObject pauseMenu;
    public GameObject optionsMenu;

    public TextMeshProUGUI tmpVolumen;
    public TextMeshProUGUI tmpCalidad;

    // Start is called before the first frame update
    void Start()
    {
        UpdateQualityLabel();
        UpdateVolumeLabel();
        ChangeIsPaused(false);
        optionsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (!optionsMenu.activeInHierarchy){
                ChangeIsPaused(!isPaused);
            }else{
                OpenPauseMenu();
            }
        } 
    }

    public void ContinueGame(){
        ChangeIsPaused(false);
    }

    public void RestartGame(){
        LoadLevel(SceneManager.GetActiveScene().name);
    }

    private void ChangeIsPaused(bool pause){
        isPaused = pause;
        Time.timeScale = (isPaused ? 0 : 1);
        pauseMenu.SetActive(isPaused);
    }

    public void IncreaseQuality(){
        QualitySettings.IncreaseLevel(false);
        UpdateQualityLabel();
    }

    public void DecreaseQuality(){
        QualitySettings.DecreaseLevel(false);
        UpdateQualityLabel();
    }

    public void SetVolume(float value){
        AudioListener.volume = value;
        UpdateVolumeLabel();
    }

    private void UpdateQualityLabel(){
        int currentQuality = QualitySettings.GetQualityLevel();
        string qualityName = QualitySettings.names [currentQuality];
        tmpCalidad.text = "Calidad actual: " + qualityName;
    }

    private void UpdateVolumeLabel(){
        float audioVolume = AudioListener.volume * 100;
        tmpVolumen.text = "Volumen actual: " + audioVolume.ToString("f2") + "%";
    }

    public void OpenOptions(){
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void OpenPauseMenu(){
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
}