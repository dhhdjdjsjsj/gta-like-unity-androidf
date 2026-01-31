using UnityEngine;

namespace Project.Camera
{
    public sealed class ThirdPersonCamera : MonoBehaviour
    {
        [Header("Target")]
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 followOffset = new Vector3(0f, 3f, -6f);
        [SerializeField] private Vector3 lookOffset = new Vector3(0f, 1.4f, 0f);

        [Header("Rotation")]
        [SerializeField] private float rotationSpeed = 120f;
        [SerializeField] private Vector2 pitchLimits = new Vector2(-20f, 60f);

        [Header("Smoothing")]
        [SerializeField] private float positionDamping = 10f;

        [Header("Collision")]
        [SerializeField] private float collisionRadius = 0.25f;
        [SerializeField] private LayerMask obstructionLayers = ~0;

        [Header("Input")]
        [SerializeField] private bool inputEnabled = true;

        private float yaw;
        private float pitch;
        private Vector3 velocity;

        private void Awake()
        {
            if (target == null)
            {
                var player = GameObject.FindWithTag("Player");
                if (player != null)
                {
                    target = player.transform;
                }
            }
        }

        private void LateUpdate()
        {
            if (target == null)
            {
                return;
            }

            if (inputEnabled)
            {
                yaw += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
                pitch -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
            }

            pitch = Mathf.Clamp(pitch, pitchLimits.x, pitchLimits.y);

            var rotation = Quaternion.Euler(pitch, yaw, 0f);
            var desiredPosition = target.position + rotation * followOffset;
            var targetPoint = target.position + lookOffset;

            desiredPosition = ResolveCollision(targetPoint, desiredPosition);

            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, 1f / Mathf.Max(0.01f, positionDamping));
            transform.rotation = Quaternion.LookRotation(targetPoint - transform.position, Vector3.up);
        }

        private Vector3 ResolveCollision(Vector3 targetPoint, Vector3 desiredPosition)
        {
            var direction = desiredPosition - targetPoint;
            var distance = direction.magnitude;

            if (distance <= 0.001f)
            {
                return desiredPosition;
            }

            direction /= distance;

            if (Physics.SphereCast(targetPoint, collisionRadius, direction, out var hit, distance, obstructionLayers, QueryTriggerInteraction.Ignore))
            {
                return targetPoint + direction * Mathf.Max(0.1f, hit.distance - collisionRadius);
            }

            return desiredPosition;
        }
    }
}
