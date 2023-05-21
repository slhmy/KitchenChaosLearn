using System;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask countersLayerMask;

    private Vector3 _lastMoveDirection;
    private bool _isWalking;
    
    private const float InteractionDistance = 2f;
    
    private const float RotateSpeed = 10f;
    private const float PlayerRadius = 0.7f;
    private const float PlayerHeight = 2f;

    private void Start() {
        gameInput.OnInteractAction += GameInput_OnInterAction;
    }

    private void GameInput_OnInterAction(object sender, EventArgs e) {
        var inputVector = gameInput.GetMovementVectorNormalized();
        var moveDirection = new Vector3(inputVector.x, 0, inputVector.y);
        if (moveDirection != Vector3.zero) {
            _lastMoveDirection = moveDirection;
        }
        
        if (Physics.Raycast(transform.position, _lastMoveDirection, out var raycastHit, InteractionDistance, countersLayerMask)) {
            if (raycastHit.transform.TryGetComponent(out ClearCounter clearCounter)) {
                clearCounter.Interact();
            }
        }
    }

    private void Update() {
        HandleMovement();
        HandleInteractions();
    }

    private void HandleInteractions() {
        var inputVector = gameInput.GetMovementVectorNormalized();
        var moveDirection = new Vector3(inputVector.x, 0, inputVector.y);
        if (moveDirection != Vector3.zero) {
            _lastMoveDirection = moveDirection;
        }
        
        if (Physics.Raycast(transform.position, _lastMoveDirection, out var raycastHit, InteractionDistance, countersLayerMask)) {
            if (raycastHit.transform.TryGetComponent(out ClearCounter clearCounter)) {
                // clearCounter.Interact();
            }
        }
    }

    private void HandleMovement() {
        var inputVector = gameInput.GetMovementVectorNormalized();
        var moveDirection = new Vector3(inputVector.x, 0, inputVector.y);
        var moveDistance = moveSpeed * Time.deltaTime;
        var transform1 = transform;
        
        _isWalking = moveDirection != Vector3.zero;
        transform1.forward = Vector3.Slerp(transform1.forward,moveDirection, Time.deltaTime * RotateSpeed);

        var position = transform1.position;
        moveDirection = GetEffectiveMoveDirection(position, moveDirection, moveDistance);
        position += moveDirection * (moveSpeed * Time.deltaTime);
        transform1.position = position;
    }

    private static Vector3 GetEffectiveMoveDirection(Vector3 position, Vector3 moveDirection, float moveDistance) {
        var canMoveInOrigin = !Physics.CapsuleCast(
        position, position + PlayerHeight * Vector3.up, PlayerRadius, moveDirection, moveDistance);
        if (canMoveInOrigin) return moveDirection;

        var moveDirectionX = new Vector3(moveDirection.x, 0, 0).normalized;
        var canMoveInX = !Physics.CapsuleCast(
         position, position + PlayerHeight * Vector3.up, PlayerRadius, moveDirectionX, moveDistance);
        if (canMoveInX) return moveDirectionX;
            
        var moveDirectionZ = new Vector3(0, 0, moveDirection.z).normalized;
        var canMoveInZ = !Physics.CapsuleCast(
            position, position + PlayerHeight * Vector3.up, PlayerRadius, moveDirectionZ, moveDistance);
        return canMoveInZ ? moveDirectionZ : Vector3.zero;
    }

    public bool IsWalking() {
        return _isWalking;
    }
}