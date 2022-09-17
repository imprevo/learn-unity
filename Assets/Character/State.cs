namespace ControllerV1
{
    public abstract class State
    {
        protected CharacterStateMachine stateMachine;

        public State(CharacterStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public virtual void OnEnter() { }

        public virtual void OnLogicUpdate() { }

        public virtual void OnPhysicsUpdate() { }

        public virtual void OnExit() { }
    }
}
