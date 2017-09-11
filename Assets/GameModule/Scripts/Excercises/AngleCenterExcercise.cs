
using UnityEngine;

namespace Assets.GameModule.Scripts.Excercises {
    public class AngleCenterExcercise : AbstractExcercise {
        public AngleCenterExcercise(float size) : base(size) {
        }

        public override Vector2[] GetExcercise() {
            Vector2[] result = new Vector2[3];
            result[0] = new Vector2(Random.Range(0, 1f) * size, Random.Range(0, 1f) * size);
            result[1] = new Vector2(Random.Range(0, 1f) * size, Random.Range(0, 1f) * size);
            result[2] = new Vector2(Random.Range(0, 1f) * size, Random.Range(0, 1f) * size);
            return result;
        }

        public override Vector2[] GetUser(Vector2[] excercisePoints) {
            Vector2[] result = new Vector2[2];
            result[0] = excercisePoints[1];
            result[1] = new Vector2(Random.Range(0, 1f) * size, Random.Range(0, 1f) * size);
            return result;
        }

        public override float Validate(Vector2[] excercisePoints, Vector2[] userPoints) {
            float result = System.Math.Abs(Vector2.Angle(excercisePoints[1] - excercisePoints[0], excercisePoints[1] - userPoints[1]) -
                Vector2.Angle(excercisePoints[1] - userPoints[1], excercisePoints[1] - excercisePoints[2]));
            return result;
        }
    }
}
