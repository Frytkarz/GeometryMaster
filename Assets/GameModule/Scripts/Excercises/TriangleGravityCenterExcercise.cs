using UnityEngine;

namespace Assets.GameModule.Scripts.Excercises {
    class TriangleGravityCenterExcercise : AbstractExcercise {
        public TriangleGravityCenterExcercise(float size) : base(size) {
        }

        public override Vector2[] GetExcercise() {
            Vector2[] result = new Vector2[4];
            result[0] = new Vector2(Random.Range(0, 1f) * size, Random.Range(0, 1f) * size);
            result[1] = new Vector2(Random.Range(0, 1f) * size, Random.Range(0, 1f) * size);
            result[2] = new Vector2(Random.Range(0, 1f) * size, Random.Range(0, 1f) * size);
            result[3] = result[0];
            return result;
        }

        public override Vector2[] GetUser(Vector2[] excercisePoints) {
            Vector2[] result = new Vector2[2];
            result[0] = excercisePoints[0];
            result[1] = new Vector2(Random.Range(0, 1f) * size, Random.Range(0, 1f) * size);
            return result;
        }

        public override float Validate(Vector2[] excercisePoints, Vector2[] userPoints) {
            Vector2 center = new Vector2(
                (excercisePoints[0].x + excercisePoints[1].x + excercisePoints[2].x) / 3,
                (excercisePoints[0].y + excercisePoints[1].y + excercisePoints[2].y) / 3);
            return Mathf.Sqrt(Mathf.Pow(center.x - userPoints[1].x, 2) + Mathf.Pow(center.y - userPoints[1].y, 2));
        }
    }
}
