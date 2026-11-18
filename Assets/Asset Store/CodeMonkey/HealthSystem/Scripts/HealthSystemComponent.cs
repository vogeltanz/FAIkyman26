using System;
using UnityEngine;
using UnityEngine.Events;

namespace CodeMonkey.HealthSystemCM {

    /// <summary>
    /// Adds a HealthSystem to a Game Object
    /// </summary>
    public class HealthSystemComponent : MonoBehaviour, IGetHealthSystem {

        [Tooltip("Maximum Health amount")]
        [SerializeField] private float healthAmountMax = 100f;

        [Tooltip("Starting Health amount, leave at 0 to start at full health.")]
        [SerializeField] private float startingHealthAmount;

        private HealthSystem healthSystem;

        public UnityEvent<GameObject> OnDead_HSC;


        private void Awake() {
            // Create Health System
            healthSystem = new HealthSystem(healthAmountMax);

            if (startingHealthAmount != 0) {
                healthSystem.SetHealth(startingHealthAmount);
            }

            healthSystem.OnDead += HealthSystem_OnDead;
        }

        private void HealthSystem_OnDead(object sender, EventArgs e) {
            OnDead_HSC?.Invoke(gameObject);
        }

        /// <summary>
        /// Get the Health System created by this Component
        /// </summary>
        public HealthSystem GetHealthSystem() {
            return healthSystem;
        }


    }

}