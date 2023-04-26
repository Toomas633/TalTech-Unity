using UnityEngine;
using Zinnia.Tracking.Collision;

public class BumperController : MonoBehaviour
{
   public void Bounce(CollisionNotifier.EventData data)
   {
       data.CollisionData.rigidbody.velocity = Vector3.Reflect(data.CollisionData.rigidbody.velocity, Vector3.right);
   }
}
