using UnityEngine;
using UnityEngine.Serialization;

namespace ForestManagers
{
    public class AnimationController : MonoBehaviour
    {
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");
        private static readonly int Vertical = Animator.StringToHash("Vertical");
        private static readonly int Speed = Animator.StringToHash("Speed");
        [SerializeField] private Animator animator;
        
        public static AnimationController Instance{get; private set;}

        public void SetHorizontal()
        {
            animator.SetFloat(Horizontal, 0f);
        }

        public void SetVertical(int vertical)
        {
            animator.SetFloat(Vertical, 0f);
        }

        public void SetRunning(bool isRunning)
        {
            animator.SetBool(Speed, isRunning);
        }

        public void SetTrigger(string trigger)
        {
            
            SetTrigger(trigger);
            SetVertical(1);
        }
        
    }
}