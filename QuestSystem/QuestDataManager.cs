using System;
using System.Collections.Generic;
using UnityEngine;
using RStudio.LevelSystem;
using RStudio.Utils.JsonFileSystem;

namespace RStudio.QuestSystem
{
    public class QuestDataManager : MonoBehaviour
    {
        [SerializeField]
        private QuestData _questData;

        [SerializeField]
        private LevelData _levelData;

        [SerializeField]
        private Transform _questContainerParent;

        [SerializeField]
        private GameObject _questContainerPrefab;

        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private AudioClip _questButtonSound;

        private QuestContainerUi _questContainerUi;

        private bool _isInitial;

        private void CreateQuest()
        {
            var questObject = Instantiate(_questContainerPrefab, _questContainerParent);

            var questUi = questObject.GetComponent<QuestContainerUi>();

            var questInfo = questObject.GetComponent<Quest>();

            var questName = _questData.GetRandomQuestName();
            var questDifficulty = _questData.GetQuestDifficulty(_levelData.Level);
            var questExpReward = _questData.GetExpReward(questDifficulty);
            var questGoldReward = _questData.GetGoldReward(questDifficulty);
            var questDuration = _questData.GetDuration(questDifficulty);

            questInfo.SetQuestValue(questName, questExpReward, questGoldReward, questDuration, questDifficulty);

            questUi.SetTextValues(questName, _questData.GetQuestDifficultyText(questDifficulty), questExpReward.ToString(), questGoldReward.ToString(), questDuration.ToString());
        }

        public void CreateQuests()
        {
            if (!_isInitial)
            {
                for (int i = 0; i < 5; i++)
                {
                    CreateQuest();
                }
            }

            _isInitial = true;
        }

        public void PlayQuestButtonSound()
        {
            _audioSource.PlayOneShot(_questButtonSound);
        }
    }
}

