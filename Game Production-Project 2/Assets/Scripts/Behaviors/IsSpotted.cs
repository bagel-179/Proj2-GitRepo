using System;
using Unity.Behavior;
using UnityEngine;
using Unity.Properties;

#if UNITY_EDITOR
[CreateAssetMenu(menuName = "Behavior/Event Channels/isSpotted")]
#endif
[Serializable, GeneratePropertyBag]
[EventChannelDescription(name: "isSpotted", message: "[Target] has spotted [Agent]", category: "Events", id: "75835c4f9f8724e7ec958d4c818456c0")]
public partial class IsSpotted : EventChannelBase
{
    public delegate void IsSpottedEventHandler(GameObject Target, GameObject Agent);
    public event IsSpottedEventHandler Event; 

    public void SendEventMessage(GameObject Target, GameObject Agent)
    {
        Event?.Invoke(Target, Agent);
    }

    public override void SendEventMessage(BlackboardVariable[] messageData)
    {
        BlackboardVariable<GameObject> TargetBlackboardVariable = messageData[0] as BlackboardVariable<GameObject>;
        var Target = TargetBlackboardVariable != null ? TargetBlackboardVariable.Value : default(GameObject);

        BlackboardVariable<GameObject> AgentBlackboardVariable = messageData[1] as BlackboardVariable<GameObject>;
        var Agent = AgentBlackboardVariable != null ? AgentBlackboardVariable.Value : default(GameObject);

        Event?.Invoke(Target, Agent);
    }

    public override Delegate CreateEventHandler(BlackboardVariable[] vars, System.Action callback)
    {
        IsSpottedEventHandler del = (Target, Agent) =>
        {
            BlackboardVariable<GameObject> var0 = vars[0] as BlackboardVariable<GameObject>;
            if(var0 != null)
                var0.Value = Target;

            BlackboardVariable<GameObject> var1 = vars[1] as BlackboardVariable<GameObject>;
            if(var1 != null)
                var1.Value = Agent;

            callback();
        };
        return del;
    }

    public override void RegisterListener(Delegate del)
    {
        Event += del as IsSpottedEventHandler;
    }

    public override void UnregisterListener(Delegate del)
    {
        Event -= del as IsSpottedEventHandler;
    }
}

