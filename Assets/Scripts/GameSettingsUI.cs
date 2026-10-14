using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Diagnostics;

public class GameSettingsUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField usernameInput;
    //i gave up on string method smh
    //[SerializeField] private string gameSceneName = "GameScene";

    private void Start()
    {
        // If the user navigated back to this scene, repopulate if needed
        if (UserSession.Instance != null && !string.IsNullOrEmpty(UserSession.Instance.Username))
            usernameInput.text = UserSession.Instance.Username;

        // Optional: auto-focus
        usernameInput?.ActivateInputField();
    }

    public void OnOkClicked()
    {
        string name = usernameInput.text?.Trim();

        if (string.IsNullOrEmpty(name))
        {
            // show small warning in case
            UnityEngine.Debug.Log("Please enter a username.");
            return;
        }

        // make sure there's a session holder (added on usersession)
        if (UserSession.Instance == null)
        {
            UnityEngine.Debug.LogError("UserSession is missing in this scene. Add the UserSession prefab/object here pls :D.");
            return;
        }

        UserSession.Instance.SetUsername(name);
        SceneManager.LoadScene(2);
    }

    public void OnCancelClicked()
    {
        // clear the stored username and reset name yipee
        UserSession.Instance?.Clear();

        // clear the inputs and keep the user here to pick a different name
        if (usernameInput != null)
        {
            usernameInput.text = string.Empty;
            usernameInput.ActivateInputField();
        }

        // migt uncomment if i add going back button lol:
        // SceneManager.LoadScene("SomeOtherScene");
    }
}