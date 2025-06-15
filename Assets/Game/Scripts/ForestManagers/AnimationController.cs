using UnityEngine;
using UnityEngine.Serialization;


namespace ForestManagers
{
    [DefaultExecutionOrder((-1))]
    public class AnimationController : MonoBehaviour
    {
        private static readonly int Horizontal = Animator.StringToHash("horizontal");
        private static readonly int Vertical = Animator.StringToHash("vertical");
        private static readonly int IsRunning = Animator.StringToHash("running");
        private static readonly int SpeedMultiplier = Animator.StringToHash("speedmultiplier");
        private const float BaseSpeedMultiplier = 0.5f;
        [SerializeField] private Animator animator;

        public static AnimationController Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        public void SetHorizontal(bool horizontal)
        {
            animator.SetBool(Horizontal, horizontal);
        }

        public void SetVertical(int vertical)
        {
            animator.SetInteger(Vertical, vertical);
        }

        public void SetRunning(bool isRunning)
        {
            animator.SetBool(IsRunning, isRunning);
        }

        public void SetTrigger(string trigger)
        {
            animator.SetTrigger(trigger);
            SetVertical(1);
        }

        public void SetSpeedMultiplier(float speedMultiplier)
        {
            speedMultiplier *= BaseSpeedMultiplier;
            animator.SetFloat(SpeedMultiplier, speedMultiplier);
        }
    }
}