using System.Collections.Generic;
using Characters;
using Gameplay;
using UnityEngine;

namespace Mechanics
{
    public class MoveMechanic
    {
        public void MoveAlongPath(List<OverlayTile> path, UnitInfo currentCharacter, float speed)
        {
            if (path.Count < 1) { return; }
            if (currentCharacter == null) { return; }

            var step = speed * Time.deltaTime;

            float zIndex = path[0].transform.position.z;
            Vector3 newPosition = Vector2.MoveTowards(currentCharacter.transform.position, path[0].transform.position, step);
            newPosition.z = zIndex;

            bool flipped = newPosition.x < currentCharacter.transform.position.x;
            currentCharacter.transform.rotation = Quaternion.Euler(new Vector3(0f, flipped ? 180f : 0f, 0f));

            currentCharacter.transform.position = newPosition;
            currentCharacter.animator.SetFloat("Forward", newPosition.magnitude);
            currentCharacter.SetMoving(true);

            if (Vector2.Distance(currentCharacter.transform.position, path[0].transform.position) < 0.00001f)
            {
                currentCharacter.SetStandingTile(path[0]);
                path.RemoveAt(0);

                if (path.Count == 0)
                {
                    currentCharacter.SetSelected(false);
                    currentCharacter.SetMoving(false);
                    currentCharacter.animator.SetFloat("Forward", 0);
                }
            }
        }
    }
}