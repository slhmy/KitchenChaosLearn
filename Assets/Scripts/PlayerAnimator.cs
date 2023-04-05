using UnityEngine;

public class PlayerAnimator : MonoBehaviour {
   private const string IsWalking = "IsWalking";
   
   private Animator _animator;

   [SerializeField] private Player player;
   private static readonly int Walking = Animator.StringToHash(IsWalking);

   private void Awake() {
      _animator = GetComponent<Animator>();
   }
   
   private void Update() {
      _animator.SetBool(Walking, player.IsWalking());
   }
}
