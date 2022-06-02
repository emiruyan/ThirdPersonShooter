using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ThirdPersonShooter.Abstracts.States;
using UnityEngine;

namespace ThirdPersonShooter.States
{
    public class StateTransformer
    {
        public IState To { get;}
        public IState From { get;}
        public Func<bool> Condition { get;}

        public StateTransformer(IState from, IState to, Func<bool> condition)
        {
            From = from;
            To = to;
            Condition = condition;

        }
    }
}


