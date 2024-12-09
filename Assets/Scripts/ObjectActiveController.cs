using UnityEngine;

public class ObjectActiveController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer grayscaled_sr;
    [SerializeField] private SpriteRenderer colored_sr;

    public bool colored = false;

    void LateUpdate()
    {
        grayscaled_sr.enabled = !colored;
        colored_sr.enabled = colored;
    }
}
