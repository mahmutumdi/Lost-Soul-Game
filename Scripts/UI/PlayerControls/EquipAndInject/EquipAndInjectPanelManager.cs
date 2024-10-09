using Events;
using UnityEngine;
using Utilities;

namespace UI.PlayerControls.EquipAndInject
{
    public class EquipAndInjectPanelManager : EventListenerMono
    {
        [SerializeField] private PlayerHealthBar _playerHealthBar;

        public string weaponState;
        
        protected override void RegisterEvents()
        {
            PlayerEvents.SyringeBTNAction += Syringe;
            PlayerEvents.PistolBTNAction += Pistol;
            PlayerEvents.RifleBTNAction += Rifle;
            PlayerEvents.SniperBTNAction += Sniper;
        }

        private void Pistol()
        {
            weaponState = "Pistol";
        }

        private void Rifle()
        {
            weaponState = "Rifle";
        }

        private void Sniper()
        {
            weaponState = "Sniper";
        }

        public void Syringe()
        {
            _playerHealthBar.Heal(60);
        }

        protected override void UnRegisterEvents()
        {
            PlayerEvents.SyringeBTNAction -= Syringe;
            PlayerEvents.PistolBTNAction -= Pistol;
            PlayerEvents.RifleBTNAction -= Rifle;
            PlayerEvents.SniperBTNAction -= Sniper;
        }
    }
}