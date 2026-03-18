using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0f, 3f, -10f);
    [SerializeField] private float positionSpeed = 5f;
    [SerializeField] private float rotationSpeed = 5f;

    private void Update()
    {
        if (target == null) return;

        // position in relation to the plane
        Vector3 targetedPosition = target.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, targetedPosition, positionSpeed * Time.deltaTime);
        
        // rotate to look at the plane
        Quaternion targetedRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetedRotation, rotationSpeed * Time.deltaTime);
    }
}
// linear interpolation should result in a smooth transition