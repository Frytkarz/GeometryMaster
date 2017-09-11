using UnityEngine;

namespace Assets.GameModule.Scripts.Excercises {
    class TriangleGravityCenterExcercise : AbstractExcercise {
        Vector2 center;

        public TriangleGravityCenterExcercise(float size) : base(size) {
        }

        public override Vector2[] GetExcercise() {
            Vector2[] result = new Vector2[4];
            result[0] = new Vector2(Random.Range(0, 1f) * size, Random.Range(0, 1f) * size);
            result[1] = new Vector2(Random.Range(0, 1f) * size, Random.Range(0, 1f) * size);
            result[2] = new Vector2(Random.Range(0, 1f) * size, Random.Range(0, 1f) * size);
            result[3] = result[0];

            center = new Vector2(
                (result[0].x + result[1].x + result[2].x) / 3,
                (result[0].y + result[1].y + result[2].y) / 3);

            return result;
        }

        public override Vector2[] GetSolution(Vector2[] excercisePoints) {
            Vector2[] result = new Vector2[5];
            result[0] = excercisePoints[0];
            result[1] = result[3] = center;
            result[2] = excercisePoints[1];
            result[4] = excercisePoints[2];
            return result;
        }

        public override Vector2[] GetUser(Vector2[] excercisePoints) {
            Vector2[] result = new Vector2[5];
            result[0] = excercisePoints[0];
            result[1] = new Vector2(Random.Range(0, 1f) * size, Random.Range(0, 1f) * size);
            result[2] = excercisePoints[1];
            result[3] = result[1];
            result[4] = excercisePoints[2];
            return result;
        }

        public override void UpdateUser(Vector2[] points, Vector2 move) {
            points[1] = points[3] += move;
        }

        public override float Validate(Vector2[] excercisePoints, Vector2[] userPoints) {
            float edgeSum =
                Mathf.Sqrt(Mathf.Pow(excercisePoints[1].x - excercisePoints[0].x, 2) + Mathf.Pow(excercisePoints[1].y - excercisePoints[0].y, 2)) +
                Mathf.Sqrt(Mathf.Pow(excercisePoints[2].x - excercisePoints[1].x, 2) + Mathf.Pow(excercisePoints[2].y - excercisePoints[1].y, 2)) +
                Mathf.Sqrt(Mathf.Pow(excercisePoints[0].x - excercisePoints[2].x, 2) + Mathf.Pow(excercisePoints[0].y - excercisePoints[2].y, 2));

            float error = Mathf.Sqrt(Mathf.Pow(center.x - userPoints[1].x, 2) + Mathf.Pow(center.y - userPoints[1].y, 2));

            return (error * 100) / edgeSum;
        }
    }
}
