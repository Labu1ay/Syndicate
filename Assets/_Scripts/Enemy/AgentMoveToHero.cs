using System;
using _Scripts.Infastructure.Factory;
using _Scripts.Infastructure.Services;
using UnityEngine;
using UnityEngine.AI;

namespace _Scripts.Enemy {
    public class AgentMoveToHero : Follow {
        public NavMeshAgent Agent;
        private Transform _heroTransform;
        private const float MinimalDistance = 1;
        private IGameFactory _gameFactory;

        private void Start() {
            _gameFactory = AllServices.Container.Single<IGameFactory>();

            if (_gameFactory.HeroGameObject != null)
                InitializeHeroTransform();
            else 
                _gameFactory.HeroCreated += HeroCreated;
        }

        private void Update() {
            if(Initialized() && HeroNotReached())
                Agent.destination = _heroTransform.position;
        }

        private bool Initialized() {
            return _heroTransform != null;
        }

        private void InitializeHeroTransform() => _heroTransform = _gameFactory.HeroGameObject.transform;
        private void HeroCreated() => InitializeHeroTransform();
        
        private bool HeroNotReached() => Vector3.Distance(Agent.transform.position, _heroTransform.position) >= MinimalDistance;
    }
}