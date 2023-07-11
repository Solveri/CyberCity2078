using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class FailGamePanelHandler : MonoBehaviour
{
    [SerializeField] Button mainMenuButton;
    [SerializeField] Button quitButton;
    [SerializeField] TextMeshProUGUI scoreText;

    private void OnMainMenuButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    private void OnQuitButtonClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    void Start()
    {
        mainMenuButton.onClick.AddListener(OnMainMenuButtonClick);
        quitButton.onClick.AddListener(OnQuitButtonClick);
        scoreText.text = "Score: " + ScoreHandler.playerScore;
        ScoreHandler.playerScore = 0;
    }

   
}
