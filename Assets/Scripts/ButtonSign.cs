using UnityEngine;
using UnityEngine.Search;

public class ButtonSign : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    
    // [SerializeField] private Tags tag;
    // private enum Tags { ButtonEDisplay, };

    [SerializeField] private KeyCode keyCode;
    
    [SerializeField] private Material material;
    private int _matColor;

    [SerializeField] private float initialScale = 0.5f;
    [SerializeField] private float sizeDecreaseOffset = 0.2f;
    [SerializeField] private float scaleSpeedFactor = 6.0f;
    [SerializeField] private float alphaSpeedFactor = 6.0f;

    private bool _display; 
    private bool _keyDown;
    private float _alpha;
    private float _scale;
    
    void Start()
    {
        _matColor = Shader.PropertyToID("_Texture_Color_Multiplier");
        
        _display = false;
    }

    void Update()
    {
        _keyDown = Input.GetKey(keyCode);
    }

    void FixedUpdate()
    {
        // Transparency.
        _display = player.insideTeleporter;
        if (_display)
        {
            _alpha += (1 - _alpha) / alphaSpeedFactor;
        }
        else
        {
            _alpha += (0 - _alpha) / alphaSpeedFactor;
        }
        material.SetColor(_matColor, new Color(1, 1, 1, _alpha));
        
        // Scale.
        float targetScale = initialScale - (_keyDown ? sizeDecreaseOffset : 0);
        _scale += (targetScale - _scale) / scaleSpeedFactor;
        transform.localScale = new Vector3(_scale, _scale, _scale);
    }
    
    #region Collision
    
    // private void OnTriggerEnter(Collider other)
    // {
    //     switch (tag)
    //     {
    //         case Tags.ButtonEDisplay:
    //             if (other.CompareTag("Button E Display"))
    //             {
    //                 _display = true;
    //             }
    //             break;
    //         default:
    //             break;
    //     }
    // }
    //
    // private void OnTriggerExit(Collider other)
    // {
    //     switch (tag)
    //     {
    //         case Tags.ButtonEDisplay:
    //             if (other.CompareTag("Button E Display"))
    //             {
    //                 _display = false;
    //             }
    //             break;
    //         default:
    //             break;
    //     }
    // }
    
    #endregion
}
