namespace ControllerV1
{
    public class CharacterStateFabric
    {
        private CharacterStateMachine sm;
        private Character character;

        public CharacterStateFabric(CharacterStateMachine sm, Character character)
        {
            this.sm = sm;
            this.character = character;
        }

        public IdleState Idle()
        {
            return new IdleState(sm, character);
        }

        public MoveState Move()
        {
            return new MoveState(sm, character);
        }

        public JumpState Jump()
        {
            return new JumpState(sm, character);
        }

        public FallState Fall()
        {
            return new FallState(sm, character);
        }
    }
}
