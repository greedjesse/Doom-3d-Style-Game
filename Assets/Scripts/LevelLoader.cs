using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Animator animator;
    
    [SerializeField] private float fadeDuration = 0.5f;

    public static Vector3 PlayerSpawnPosition;
    public static float CameraYDirection;
    
    
    public IEnumerator LoadLevel(int levelIndex, Vector3 playerSpawnPos, float cameraYDir)
    {
        CameraYDirection = cameraYDir;
        PlayerSpawnPosition = playerSpawnPos;
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(fadeDuration);
        SceneManager.LoadScene(levelIndex);
    }
}
