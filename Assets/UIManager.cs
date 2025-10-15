
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI playerHPText;
    public TextMeshProUGUI shadowHealthText;
    private HealthManager healthManager;
    // Start is called before the first frame update
    void Start()
    {
        healthManager = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerHPText.text = $"Player HP: {healthManager.playerHP}";
        shadowHealthText.text = $"Shadow Health: {healthManager.shadowHealth}";
    }
}
