
using System.Collections.Generic;
using ThirdPersonShooter.States;
using ThirdPersonShooter.Abstracts.States;

namespace ThirdPersonShooter.States
{
    public class StateMachine
    {
        List<StateTransformer> _stateTransformers = new List<StateTransformer>(); 
        List<StateTransformer> _anyStateTransformer = new List<StateTransformer>();

        IState _currentState;

        public void SetState(IState state) 
        {
            if (_currentState == state) return; //current state gelen state eşitse return et
            
            _currentState?.OnExit(); //değilse on exit
            _currentState = state;
            _currentState.OnEnter();
        }
        
        public void Tick()
        {
            StateTransformer stateTransformer = CheckForTransformer();
            if (stateTransformer != null);
            {
                SetState(stateTransformer.To);
            }
            _currentState.Tick();
        }

        private StateTransformer CheckForTransformer()
        {
            foreach (StateTransformer stateTransformer in _anyStateTransformer)
            {
                if (stateTransformer.Condition.Invoke()) return stateTransformer;
            }

            foreach (StateTransformer stateTransformer in _stateTransformers)
            {
                if (stateTransformer.Condition.Invoke() && _currentState == stateTransformer.From) return stateTransformer;
                
            }
            return null;
        }

        public void AddState(IState from,IState to, System.Func<bool> condition)
        {
            StateTransformer stateTransformer = new StateTransformer(from, to, condition);
            _stateTransformers.Add(stateTransformer);
        }
        
        //from nereden geldiği
        //to nereye gideceği

        public void AddAnyState(IState to,System.Func<bool>condition)
        {
            StateTransformer stateTransformer = new StateTransformer(null, to, condition);
            _anyStateTransformer.Add(stateTransformer);
        }
    }
    
}


