using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatterns : MonoBehaviour
{
    public struct PatternStep
    {
        public Vector2 direction;
        public float stepDuration;
        public string action;

        public PatternStep(Vector2 d, float time)
        {
            direction = d;
            stepDuration = time;
            action = "";
        }

        public PatternStep(Vector2 d, float time, string a)
        {
            direction = d;
            stepDuration = time;
            action = a;
        }
    }

    public PatternStep[] patternSteps;
    private float patternStepTimer = 0;
    private int patternStepIndex = 0; //index of currently active PatternStep
    public Vector2 dir;

    private AI enemyAi;

    bool waitingForStepToComplete = false;

    void Start()
    {
        enemyAi = GetComponent<AI>();
        dir = Vector2.zero;
        patternSteps = new PatternStep[9];
        patternSteps[0] = new PatternStep(new Vector2(1, 0), 4);
        patternSteps[1] = new PatternStep(new Vector2(0, 0), 1);
        patternSteps[2] = new PatternStep(new Vector2(0, 1), 1.5f);
        patternSteps[3] = new PatternStep(new Vector2(0, 0), 1);
        patternSteps[4] = new PatternStep(new Vector2(-1, 0), 4);
        patternSteps[5] = new PatternStep(new Vector2(0, 0), 1);
        patternSteps[6] = new PatternStep(new Vector2(0, -1), 1.5f);
        patternSteps[7] = new PatternStep(new Vector2(0, 0), 1);
        patternSteps[8] = new PatternStep(Vector2.zero, 3, "attack");
    }

    public Vector3 evaluatePattern()
    {
        Debug.Log("HERE");
        patternStepTimer += Time.deltaTime;

        dir = patternSteps[patternStepIndex].direction;
        if (patternSteps[patternStepIndex].action == "attack")
        {
            enemyAi.aiType = AI.AIType.vector;
        }
        else
        if (!waitingForStepToComplete)
        {
            waitingForStepToComplete = true;
            StartCoroutine(nextPatternStep(patternSteps[patternStepIndex]));
        }
        dir.Normalize();
        return dir;
    }

    void Update()
    {

    }

    IEnumerator nextPatternStep(PatternStep s)
    {
        yield return new WaitForSeconds(s.stepDuration);
        ++patternStepIndex;
        Debug.Log("Executing pattern step " + patternStepIndex.ToString());
        patternStepIndex %= patternSteps.Length;
        waitingForStepToComplete = false;
    }
}
