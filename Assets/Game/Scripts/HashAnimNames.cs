using UnityEngine;

public class HashAnimNames : MonoBehaviour
{
   public int SpeedFloat = Animator.StringToHash("Speed");
   public int vSpeedFloat = Animator.StringToHash("vSpeed");
   public int Ground = Animator.StringToHash("Ground");
   public int Crouch = Animator.StringToHash("Crouch");
   public int NormalAttack = Animator.StringToHash("NormalAttack");
   public int Death = Animator.StringToHash("Death");
   public int SkeletonWalk = Animator.StringToHash("IsWalk");
   public int CoinRotation=Animator.StringToHash("IsCoinRotate");
}
