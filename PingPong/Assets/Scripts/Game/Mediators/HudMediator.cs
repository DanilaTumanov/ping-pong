﻿using Game.Models;
using Game.Views;
using strange.extensions.mediation.impl;

namespace Game.Mediators
{
    public class HudMediator : Mediator
    {

        [Inject]
        public HudView View { get; private set; }
        
        [Inject]
        public IScoresModel ScoresModel { get; set; }


        public override void OnRegister()
        {
            base.OnRegister();
            
            ScoresModel.Scores.OnChanged += (oldS, newS) => View.SetScore(newS);
            ScoresModel.MaxScores.OnChanged += (oldS, newS) => View.SetMaxScore(newS);

            View.SetScore(0);
            View.SetMaxScore(ScoresModel.MaxScores.Value);
        }
    }
}
