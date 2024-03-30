using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TextMeshProUGUI bestScoreText;

    private void Start()
    {
        Persistence.Instance.LoadData();
        if (Persistence.Instance.dataFound)
        {
            bestScoreText.text = $"Best Score: {Persistence.Instance.playerName}, {Persistence.Instance.score}";
        } else
        {
            bestScoreText.text = "No high score yet! Be the first!";
        }
    }

    public void StartGame()
    {
        if (string.IsNullOrEmpty(nameInput.text))
        {
            Debug.Log("Please enter a name before starting");
            return;
        }

        Persistence.Instance.currentPlayer = nameInput.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
