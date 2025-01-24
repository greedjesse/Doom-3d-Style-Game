using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Animator animator;
    
    [SerializeField] private float fadeInDuration = 1.0f;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(LoadLevel(0));            
        }
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(fadeInDuration);
        SceneManager.LoadScene(levelIndex);
    }
}
