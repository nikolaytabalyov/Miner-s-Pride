using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public enum PauseState {
        Paused,
        Unpaused
    }
    
    #region Variables
    [Header("Variables")]
    [SerializeField] private PauseState _pauseState;
    #endregion
    
    #region Components
    [Header("Components")]
    [SerializeField] private GameObject _pauseScreen;
    #endregion
    
    #region Unity Methods
    private void Start() {
        _pauseState = PauseState.Unpaused;
        Time.timeScale = 1;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) 
            HandlePauseState();
    }
    #endregion
    
    #region Other Methods
    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame() => Application.Quit();

    public void HandlePauseState() {
        if (_pauseState == PauseState.Unpaused) { // Switch to Paused
            _pauseState = PauseState.Paused;
            Time.timeScale = 0;
            _pauseScreen.SetActive(true);
        } 
        else { // Switch to Unpaused
            _pauseState = PauseState.Unpaused;
            Time.timeScale = 1;
            _pauseScreen.SetActive(false);
        }
    }
    #endregion
}
