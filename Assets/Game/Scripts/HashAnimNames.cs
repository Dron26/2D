using UnityEngine;

public class HashAnimNames : MonoBehaviour
{
     public static readonly int SpeedFloat = Animator.StringToHash("Speed");
     public static readonly int vSpeedFloat = Animator.StringToHash("vSpeed");
     public static readonly int Ground = Animator.StringToHash("Ground");
     public static readonly int Crouch = Animator.StringToHash("Crouch");
     public static readonly int NormalAttack = Animator.StringToHash("NormalAttack");
     public static readonly int Death = Animator.StringToHash("Death");
     public static readonly int SkeletonWalk = Animator.StringToHash("IsWalk");
     public static readonly int CoinRotation =Animator.StringToHash("IsCoinRotate");
}
