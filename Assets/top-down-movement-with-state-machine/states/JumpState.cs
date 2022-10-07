namespace TopDownMovementWithStateMachine
{
    using UnityEngine;

    // TODO: extends from to AirState
    public class JumpState : GroundedState
    {
        private float gravity = -10f;
        private float jumpHeight = 3f;
        private Vector3 movement;

        public JumpState(CharacterStateMachine sm, Character character) : base(sm, character)
        {
        }

        public override void OnEnter()
        {
            character.SetColor(Color.yellow);
            movement = character.MoveDirection;
            movement.y = jumpHeight;
        }

        public override void OnLogicUpdate()
        {
            base.OnLogicUpdate();

            movement.y += gravity * Time.deltaTime;
            character.MoveDirection = movement;
            character.MoveRotation = moveRotation;

            if (movement.y < 0 && character.IsGrounded)
            {
                stateMachine.SwitchState(stateMachine.IdleState);
            }
        }
    }
}
