using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.GameModule.Scripts.Excercises {
    public abstract class AbstractExcercise {

        protected readonly float size;

        public AbstractExcercise(float size) {
            this.size = size;
        }

        public abstract Vector2[] GetExcercise();

        public abstract Vector2[] GetUser(Vector2[] excercisePoints);

        public virtual void UpdateUser(Vector2[] points, Vector2 move) {
            points[points.Length - 1] += move;
        }

        public abstract Vector2[] GetSolution(Vector2[] excercisePoints);

        public abstract float Validate(Vector2[] excercisePoints, Vector2[] userPoints);
    }
}