using UnityEngine;
using UnityEngine.Events;

public class Town : MonoBehaviour
{
    public event UnityAction<Town> TownClicked;

    private void OnMouseUpAsButton() => TownClicked?.Invoke(this);
}
