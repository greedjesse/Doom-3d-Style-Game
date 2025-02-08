using System;
using UnityEngine;

public class BridgeLevelLoader : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    [SerializeField] private LevelLoader levelLoader;

    [SerializeField] private Material arrowMat;
    private int _arrowFillRatioID;

    [SerializeField] private Vector3 playerSpawnPosition;
    [SerializeField] private float cameraDirection;
    [SerializeField] private int destination;

    private bool _eHeld;
    private float _timeHeld;
    [SerializeField] private float timeNeededToHeld = 1.0f;
    private bool CanTransfer => _timeHeld == timeNeededToHeld; 
    private bool _transferred;

    [HideInInspector] public bool collided;

    void Start()
    {
        _arrowFillRatioID = Shader.PropertyToID("_FillRatio");
        
        _timeHeld = 0.0f;
        _transferred = false;
        collided = false;
    }
    
    void Update()
    {
        _eHeld = Input.GetKey(KeyCode.E);
        if (_eHeld && collided)
        {
            _timeHeld += Time.deltaTime;
            _timeHeld = Math.Min(timeNeededToHeld, _timeHeld);
        }
        else if (_timeHeld < timeNeededToHeld)
        {
            _timeHeld -= Time.deltaTime;
            _timeHeld = Math.Max(0.0f, _timeHeld);
        }
        
        arrowMat.SetFloat(_arrowFillRatioID, CircleFunc(1.0f, 0.0f, 1.0f, _timeHeld / timeNeededToHeld * 0.6f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            collided = true;
            player.insideTeleporter = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            collided = false;
            player.insideTeleporter = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!_transferred && CanTransfer && other.gameObject.CompareTag("Player"))
        {
            _transferred = true;
            StartCoroutine(levelLoader.LoadLevel(destination, playerSpawnPosition, cameraDirection));
        }
    }

    private float ParabolicFunc(float a, float b, float c, float x)
    {
        return a * Mathf.Pow((x + b), 2) + c;
    }

    private float CircleFunc(float a, float b, float r, float x)
    {
        return Mathf.Sqrt(Mathf.Pow(r, 2) - Mathf.Pow(x - a, 2) + b);
    }
}
