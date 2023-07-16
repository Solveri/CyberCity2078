using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class FailGamePanelHandler : MonoBehaviour
{
    [SerializeField] Button mainMenuButton;
    [SerializeField] Button quitButton;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] RectTransform buttonParent;
    int playerScore;

    private void OnMainMenuButtonClick()
    {
        StartCoroutine(LoadSceneDelay());
        mainMenuButton.image.DOFade(0, 0.1f);
        StartCoroutine(DisableButton(mainMenuButton));

    }

    private void OnQuitButtonClick()
    {
        quitButton.image.DOFade(0, 0.1f);

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    void Start()
    {
        mainMenuButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        mainMenuButton.onClick.AddListener(OnMainMenuButtonClick);
        quitButton.onClick.AddListener(OnQuitButtonClick);
        scoreText.text = "Score: " + ScoreScript.playerScore;
        ScoreScript.playerScore = 0;
        buttonParent.DOAnchorPos(new Vector2(0, -200), 1f, true);
    }
    private IEnumerator LoadSceneDelay()
    {
        yield return new WaitForSeconds(0.13f);
        SceneManager.LoadScene(0);
    }
    private IEnumerator DisableButton(Button game)
    {
        yield return new WaitForSeconds(0.1f);
        game.gameObject.SetActive(false);
    }


}