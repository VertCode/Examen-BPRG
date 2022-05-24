using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class IngameGuiManager : MonoBehaviour
{
    public TextMeshProUGUI fpsCounterText;
    public TextMeshProUGUI waveCounterText;
    public TextMeshProUGUI killCounterText;
    private List<long> fpsLastFrames = new List<long>();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (fpsLastFrames.Count >= 100)
        {
            fpsLastFrames.RemoveAt(0);
        }

        long currentFPS = (int) (1.0f / Time.smoothDeltaTime);
        fpsLastFrames.Add(currentFPS);
        
        fpsCounterText.text = "FPS: " + getAverageFPS();
    }

    private long getAverageFPS()
    {
        long total = fpsLastFrames.Sum();

        return total / fpsLastFrames.Count;
    }
}
