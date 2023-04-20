using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class BotBaseState 
{

    public abstract void EnterState(BotStateManager bot);

    public abstract void UpdateState(BotStateManager bot);

    public abstract void OnCollisonEnter(BotStateManager bot);

    
}
