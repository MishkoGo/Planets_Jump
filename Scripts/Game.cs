using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class Game : MonoBehaviour
{
    #region VAR
    public UnityEvent onMenu;
    public UnityEvent onLoading;
    public UnityEvent onStartGame;
    public UnityEvent onEndGame;
    public UnityEvent onResult;
    #endregion

    #region MONO
    private void Start()
    {
        SetToMenu();
    }
    #endregion
    
    #region FUNC
    public void ReloadLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void SetToMenu()
    {
        onMenu?.Invoke();
    }
    public void SetToLoading()
    {
        onLoading?.Invoke();
        Invoke(nameof(SetToGame), 2);
    }
    public void SetToGame()
    {
        onStartGame?.Invoke();
    }
    public void SetToResult()
    {
        onEndGame?.Invoke();
    }
    #endregion
}

