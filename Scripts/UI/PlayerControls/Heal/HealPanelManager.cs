using Events;
using UnityEngine;
using Utilities;

namespace UI.PlayerControls.Heal
{
    public class HealPanelManager : EventListenerMono
    {
        [SerializeField] private PlayerHealthBar _playerHealthBar;
        protected override void RegisterEvents()
        {
            PlayerEvents.BandageBTNAction += Bandage;
            PlayerEvents.MedkitBTNAction += Medkit;
        }

        protected override void UnRegisterEvents()
        {
            PlayerEvents.BandageBTNAction -= Bandage;
            PlayerEvents.MedkitBTNAction -= Medkit;
        }
        private void Bandage()
        {
            _playerHealthBar.Heal(30);
        }

        private void Medkit()
        {
            _playerHealthBar.Heal(100);
        }

    
    }
}
