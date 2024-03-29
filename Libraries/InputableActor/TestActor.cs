
using System;
using UnityEngine;

namespace InputableActor
{
#if TEST_THIS_LIBRARY

    [Serializable]
    public class TestHandler : InputHandler<float>
    {
        [SerializeField] private string message;

        public override void LoadSetting<TSetting>(string settingKey, TSetting setting)
        {
            if (settingKey == nameof(message) && (setting is string _message)) message = _message;
        }

        protected override void OnUpdate()
        {
        }

        ~TestHandler()
        {
            Debug.Log("TestHandler is Delete");
        }
    }

    public class TestActor : Actor<int, float>
    {
        [SerializeField] TestHandler handler = new();
        protected override void OnStart()
        {
            AddInputHandler(0, handler);
            LoadSetting(0, "message", "LoadSetting");
        }
        public void onDestroy()
        {
            Destroy();
            Debug.Log("Called At TestActor");
        }
    }
#endif
}

