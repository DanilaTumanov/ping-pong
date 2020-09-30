using Game.Models;
using Game.Signals;
using Game.Views;
using strange.extensions.mediation.impl;

namespace Game.Mediators
{
    public class StartMenuMediator : Mediator
    {
    
        [Inject]
        public StartMenuView View { get; set; }
    
        [Inject]
        public INetworkModel NetworkModel { get; set; }
        
        [Inject]
        public JoinGameSignal JoinGameSignal { get; set; }


        public override void OnRegister()
        {
            View.SetInvitationCode("");
            NetworkModel.InvitationCode.OnChanged += (oldC, newC) => View.SetInvitationCode(newC);
            View.OnJoinGamePressed += OnJoinGameHandler;
        }


        private void OnJoinGameHandler(string code)
        {
            JoinGameSignal.Dispatch(code);
        }
    }
}
