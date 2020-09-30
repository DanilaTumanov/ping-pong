using Game.Models;
using Photon.Realtime;
using strange.extensions.mediation.impl;

namespace Game.Mediators
{
    public class AppMediator : Mediator
    {
    
        [Inject]
        public AppView View { get; set; }
    
        [Inject]
        public INetworkModel NetworkModel { get; set; }
    

        public override void OnRegister()
        {
            base.OnRegister();

            NetworkModel.Opponent.OnChanged += OpponentChangeHandler;
        }

        private void OpponentChangeHandler(Player oldOpponent, Player newOpponent)
        {
            if (newOpponent != null)
            {
                View.StartGame();
            }
        }
    }
}
