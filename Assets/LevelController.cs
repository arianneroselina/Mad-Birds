using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private static int _nextLevelIndex = 1;
    private static int _levelFinished = 0;
    private Monster[] _monsters;

    private void OnEnable()
    {
        _monsters = FindObjectsOfType<Monster>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Monster monster in _monsters) 
        {
            if (monster != null)
                return;
        }

        Debug.Log("You killed all monsters!");

        if (_nextLevelIndex != _levelFinished)
        {
            _nextLevelIndex++;
            string nextLevelName = "Level" + _nextLevelIndex;

            if (_nextLevelIndex == 4)
            {
                Debug.Log("You win!");
                Application.Quit();
                UnityEditor.EditorApplication.isPlaying = false;
            }

            SceneManager.LoadScene(nextLevelName);

            _levelFinished++;
        }
    }
}
