using UnityEngine;

public class InteractionFight : Interaction
{
    protected override void OnAfterInteract()
    {
        SceneSelector.Instance.LoadScene("Fighting");
    }
}
