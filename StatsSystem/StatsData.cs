using System.Collections.Generic;
using UnityEngine;

namespace RStudio.StatsSystems
{
    [CreateAssetMenu]
    public class StatsData : ScriptableObject
    {
        [SerializeField]
        public Stat Health;

        [SerializeField]
        public Stat Mana;

        [SerializeField]
        public Stat Stamina;

        public void InitializeStats()
        {
            Health.InitializeValue();
            Mana.InitializeValue();
            Stamina.InitializeValue();
        }

        public void HandleQuestDamage(int Difficulty)
        {
            switch (Difficulty)
            {
                case 0:
                    Health.DecreaseValue(Random.Range(1, 6));
                    Mana.DecreaseValue(Random.Range(1, 6));
                    Stamina.DecreaseValue(Random.Range(1, 6));
                    break;
                case 1:
                    Health.DecreaseValue(Random.Range(6, 11));
                    Mana.DecreaseValue(Random.Range(6, 11));
                    Stamina.DecreaseValue(Random.Range(6, 11));
                    break;
                case 2:
                    Health.DecreaseValue(Random.Range(11, 16));
                    Mana.DecreaseValue(Random.Range(11, 16));
                    Stamina.DecreaseValue(Random.Range(11, 16));
                    break;
                case 3:
                    Health.DecreaseValue(Random.Range(16, 21));
                    Mana.DecreaseValue(Random.Range(16, 21));
                    Stamina.DecreaseValue(Random.Range(16, 21));
                    break;
                case 4:
                    Health.DecreaseValue(Random.Range(21, 31));
                    Mana.DecreaseValue(Random.Range(21, 31));
                    Stamina.DecreaseValue(Random.Range(21, 31));
                    break;
                case 5:
                    Health.DecreaseValue(Random.Range(31, 51));
                    Mana.DecreaseValue(Random.Range(31, 51));
                    Stamina.DecreaseValue(Random.Range(31, 51));
                    break;
                case 6:
                    Health.DecreaseValue(Random.Range(51, 101));
                    Mana.DecreaseValue(Random.Range(51, 101));
                    Stamina.DecreaseValue(Random.Range(51, 101));
                    break;
            }
        }
    }
}
