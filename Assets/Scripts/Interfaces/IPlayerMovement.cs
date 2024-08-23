using UnityEngine;

public interface IPlayerMovement
{
    public Vector3 startingPosition {  get; set; }
    public void GoToStartingPosition();
}