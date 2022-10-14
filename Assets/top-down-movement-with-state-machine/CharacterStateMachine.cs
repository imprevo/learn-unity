namespace LearnUnity.TopDownMovementWithStateMachine
{
    using UnityEngine;

    public class CharacterStateMachine : MonoBehaviour
    {
        private State currentState;

        public IdleState IdleState { get; private set; }
        public MoveState MoveState { get; private set; }
        public JumpState JumpState { get; private set; }
        public FallState FallState { get; private set; }

        [SerializeField]
        private Character character;

        [SerializeField]
        public CharacterInput chInput;
        private CharacterStateFabric csf;

        public void OnEnable()
        {
            csf = new CharacterStateFabric(this, character);
            IdleState = csf.Idle();
            MoveState = csf.Move();
            JumpState = csf.Jump();
            FallState = csf.Fall();

            InitState(IdleState);
        }

        public void Update()
        {
            currentState.OnLogicUpdate();
        }

        public void FixedUpdate()
        {
            currentState.OnPhysicsUpdate();
        }

        private void InitState(State nextState)
        {
            currentState = nextState;
            currentState.OnEnter();
        }

        public void SwitchState(State nextState)
        {
            currentState.OnExit();
            currentState = nextState;
            currentState.OnEnter();
        }
    }
}
