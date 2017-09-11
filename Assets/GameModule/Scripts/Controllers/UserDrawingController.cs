using Assets.GameModule.Scripts.Excercises;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.GameModule.Scripts.Controllers {
    public class UserDrawingController : MonoBehaviour {
        [SerializeField]
        private UILineRenderer userLine;
        [SerializeField]
        private UILineRenderer excerciseLine;
        [SerializeField]
        private Text txtResult;

        private Vector2 lastclick = new Vector2(0, 0);
        private List<AbstractExcercise> excercises;
        private int index = 0;

        private IEnumerator Start() {
            yield return null;
            excercises = new List<AbstractExcercise>(
            new AbstractExcercise[] {
                new AngleCenterExcercise(GetComponent<RectTransform>().rect.width),
                new TriangleGravityCenterExcercise(GetComponent<RectTransform>().rect.width)
        });
            Reload();
        }

        private void Update() {
            Vector2? click = null;
#if UNITY_ANDROID && !UNITY_EDITOR
            if(Input.touchCount == 1) {
                click = Input.touches[0].position;

                if(Input.touches[0].phase == TouchPhase.Began)
                    lastclick = click.Value;
            }            
#else
            if(Input.GetMouseButton(0)) {
                click = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                if(Input.GetMouseButtonDown(0))
                    lastclick = click.Value;
            }
#endif
            if(click != null) {
                excercises[index].UpdateUser(userLine.Points, click.Value - lastclick);
                lastclick = click.Value;
                userLine.SetAllDirty();
            }
        }

        public void OnOkClick() {
            txtResult.text = excercises[index].Validate(excerciseLine.Points, userLine.Points).ToString();
            Reload();
        }

        private void Reload() {
            if(++index >= excercises.Count)
                index = 0;

            excerciseLine.Points = excercises[index].GetExcercise();
            excerciseLine.SetAllDirty();
            userLine.Points = excercises[index].GetUser(excerciseLine.Points);
            userLine.SetAllDirty();
        }
    }
}