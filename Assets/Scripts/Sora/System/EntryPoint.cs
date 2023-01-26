using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sora_UI;
using Sora_Item;

namespace Sora_System
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField]
        private ScoreVew vew;

        private ScoreDataPresenter presenter = new();

        void Start()
        {
            presenter.Inject(new ItemDataModel(), vew);
        }
    }
}