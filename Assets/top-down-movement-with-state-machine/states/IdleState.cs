namespace TopDownMovementWithStateMachine
{
    using UnityEngine;

    public class IdleState : GroundedState
    {
        public IdleState(CharacterStateMachine sm, Character character) : base(sm, character)
        {
        }

        public override void OnEnter()
        {
            character.SetColor(Color.blue);
            character.MoveDirection = Vector3.zero;
        }

        public override void OnLogicUpdate()
        {
            base.OnLogicUpdate();

            character.MoveRotation = moveRotation;

            if (moveDirection.magnitude != 0)
            {
                stateMachine.SwitchState(stateMachine.MoveState);
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
