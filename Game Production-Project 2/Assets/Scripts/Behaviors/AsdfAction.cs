using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "asdf", story: "[f] aasd f", category: "Action", id: "5da8032808d4ecf2181249d60d1cb05f")]
public partial class AsdfAction : Action
{
    [SerializeReference] public BlackboardVariable<Enemy> F;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

