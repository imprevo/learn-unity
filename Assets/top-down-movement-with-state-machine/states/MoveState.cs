namespace TopDownMovementWithStateMachine
{
    using UnityEngine;

    public class MoveState : GroundedState
    {
        public MoveState(CharacterStateMachine sm, Character character) : base(sm, character)
        {
        }

        public override void OnEnter()
        {
            character.SetColor(Color.green);
        }

        public override void OnLogicUpdate()
        {
            base.OnLogicUpdate();

            character.MoveDirection = moveDirection;
            character.MoveRotation = moveRotation;

            if (moveDirection.magnitude == 0)
            {
                stateMachine.SwitchState(stateMachine.IdleState);
            }
            else if (CharacterInput.IsJump)
            {
                stateMachine.SwitchState(stateMachine.JumpState);
            }
            else if (!character.IsGrounded)
            {
                stateMachine.SwitchState(stateMachine.FallState);
            }
            else if (CharacterInput.IsAttack)
            {
                Fire();
            }
        }
    }
}
