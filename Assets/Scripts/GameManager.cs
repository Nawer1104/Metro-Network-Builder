using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<Level> levels;

    public static GameManager Instance;

    private int startIndex = 0;

    private int currentIndex = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        levels[startIndex].gameObject.SetActive(true);

        currentIndex = startIndex;
    }

    public int GetCurrentIndex()
    {
        return currentIndex;
    }

    private void Update()
    {
        if (levels[currentIndex].enemies.Count == 0)
        {
            levels[currentIndex].gameObject.SetActive(false);

            currentIndex += 1;

            if (currentIndex == 3)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

                currentIndex = 0;
            }

            levels[currentIndex].gameObject.SetActive(true);
        }
    }
}