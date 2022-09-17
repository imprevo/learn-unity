namespace ControllerV1
{
    using UnityEngine;

    // TODO: extends from to AirState
    public class FallState : GroundedState
    {
        private float gravity = -10f;
        private Vector3 movement;

        public FallState(CharacterStateMachine sm, Character character) : base(sm, character)
        {
        }

        public override void OnEnter()
        {
            character.SetColor(Color.cyan);
            movement = Vector3.zero;
        }

        public override void OnLogicUpdate()
        {
            base.OnLogicUpdate();

            movement.y += gravity * Time.deltaTime;
            character.MoveDirection = movement;

            if (character.IsGrounded)
            {
                stateMachine.SwitchState(stateMachine.IdleState);
            }
        }
    }
}
