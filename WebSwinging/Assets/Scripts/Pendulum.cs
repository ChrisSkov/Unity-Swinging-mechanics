using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pendulum
{
    public Transform bob_tr;
    public Tether tether;
    public Arm arm;
    public Bob bob;

    Vector3 previousPosition;


    public void Initialize()
    {
        bob_tr.transform.parent = tether.tether_tr;
        arm.length = Vector3.Distance(bob_tr.transform.localPosition, tether.position);
    }

    public Vector3 MoveBob(Vector3 pos, float time)
    {
        bob.velocity += GetConstrainedVelocity(pos, previousPosition, time);
        bob.ApplyGravity();
        bob.ApplyDamping();
        bob.CapMaxSpeed();

        pos += bob.velocity * time;
        if (Vector3.Distance(pos, tether.position) < arm.length)
        {
            pos = Vector3.Normalize(pos - tether.position) * arm.length;
            arm.length = (Vector3.Distance(pos, tether.position));
            return pos;
        }

        previousPosition = pos;

        return pos;
    }

    public Vector3 MoveBob(Vector3 pos, Vector3 prevPos, float time)
    {
        bob.velocity += GetConstrainedVelocity(pos, prevPos, time);
        bob.ApplyGravity();
        bob.ApplyDamping();
        bob.CapMaxSpeed();

        pos += bob.velocity * time;
        if (Vector3.Distance(pos, tether.position) < arm.length)
        {
            pos = Vector3.Normalize(pos - tether.position) * arm.length;
            arm.length = (Vector3.Distance(pos, tether.position));
            return pos;
        }

        previousPosition = pos;

        return pos;
    }

    public Vector3 GetConstrainedVelocity(Vector3 currentPos, Vector3 previousPosition, float time)
    {
        float distanceToTether;
        Vector3 constrainedPosition;
        Vector3 predictedPosition;

        distanceToTether = Vector3.Distance(currentPos, tether.position);

        if (distanceToTether > arm.length)
        {
            constrainedPosition = Vector3.Normalize(currentPos - tether.position) * arm.length;
            predictedPosition = (constrainedPosition - previousPosition) / time;
            return predictedPosition;

        }
        return Vector3.zero;
    }

    public void SwitchTether(Vector3 newPosition)
    {
        bob_tr.transform.parent = null;
        tether.tether_tr.position = newPosition;
        bob_tr.transform.parent = tether.tether_tr;
        tether.position = tether.tether_tr.InverseTransformPoint(newPosition);
        arm.length = Vector3.Distance(bob_tr.localPosition, tether.position);
    }

    public Vector3 Fall(Vector3 pos, float time)
    {
        bob.ApplyGravity();
        bob.ApplyDamping();
        bob.CapMaxSpeed();
        pos += bob.velocity * time;
        return pos;
    }
}
