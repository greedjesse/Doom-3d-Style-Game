using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] [Range(0.0f, 1.0f)] private float interpolateRatio;
    
    void Update()
    {
        transform.position = new Vector3(Mathf.Lerp(0.0f, 5.0f, interpolateRatio), 0.0f, 0.0f);
    }
}
