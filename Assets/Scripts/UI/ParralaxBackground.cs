using Unity;
using UnityEngine;

public class ParralaxBackground : MonoBehaviour
{
    
    [SerializeField] private float parralaxEffect;

    private GameObject _cam;
    private float xPosition;

    private void Start()
    {
        _cam = Camera.main.gameObject;

        xPosition = transform.position.x;
    }

    private void Update()
    {
        float distanceToMove = _cam.transform.position.x * parralaxEffect;

        transform.position = new Vector3(xPosition + distanceToMove, transform.position.y);
    }
}
