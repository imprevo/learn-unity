namespace ControllerV1
{
    using UnityEngine;

    public abstract class GroundedState : State
    {
        protected Character character;
        protected Vector3 moveDirection;
        protected Vector3 moveRotation;
        protected bool IsJump;
        protected bool IsAttack;

        protected float fireRate = 0.5f;
        protected float nextFireTime = 0f;

        protected CharacterInput CharacterInput => stateMachine.chInput;

        public GroundedState(CharacterStateMachine sm, Character character) : base(sm)
        {
            this.character = character;
        }

        public override void OnLogicUpdate()
        {
            CharacterInput.OnMove();
            moveDirection = CharacterInput.Movement;
            moveRotation = CharacterInput.Rotation;
            IsJump = CharacterInput.IsJump;
            IsAttack = CharacterInput.IsAttack;
        }

        // public void Move(float speed)
        // {
        //     character.Move(moveDirection * speed);
        // }

        // public void Rotate()
        // {
        //     character.Rotate(rotateDirection);
        // }

        protected void Fire()
        {
            if (IsAttack && Time.time > nextFireTime)
            {
                character.Fire();
                nextFireTime = Time.time + fireRate;
            }
        }

        // public void Jump()
        // {
        //     if (IsJump)
        //     {
        //         character.Jump();
        //     }
        // }
    }
}
