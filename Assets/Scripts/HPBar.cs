using UnityEngine;
using System.Collections;

public class HPBar : MonoBehaviour {

    //HP Bar Textures used
    public Texture backgroundTexture;
    public Texture foregroundTexture;
    public Texture frameTexture;
    public Sprite s;

    // Texture Dimensions
    int healthWidth = 220;
    int healthHeight = 20;

    int healthMarginLeft = 64;
    int healthMarginTop = 35;

    int frameWidth = 266;
    int frameHeight = 65;

    int frameMarginLeft = 10;
    int frameMarginTop = 10;

    int bgWidth = 156;
    int bgHeight = 30;
    int bgMarginLeft = 64;
    int bgMarginTop = 30;

    //HP Variables
    private int _fullHealth = 220;
    private int _emptyHealth = 0;

    void OnGUI() {
        //Display Sprite in HP Bar Portrait
        Texture t = s.texture;
        Rect tr = s.textureRect;
        Rect r = new Rect(tr.x / t.width, tr.y / t.height, tr.width / t.width, tr.height / t.height);

        //Draw HUD HP Bar
        GUI.DrawTextureWithTexCoords(new Rect(12, 10, tr.width, tr.height), t, r);
        GUI.DrawTexture(new Rect(bgMarginLeft, bgMarginTop, bgMarginLeft + bgWidth, bgHeight), backgroundTexture, ScaleMode.ScaleToFit, true, 0);
        GUI.DrawTexture(new Rect(healthMarginLeft, healthMarginTop, healthWidth, healthHeight), foregroundTexture, ScaleMode.ScaleAndCrop, true, 0);
        GUI.DrawTexture(new Rect(frameMarginLeft, frameMarginTop, frameMarginLeft + frameWidth, frameMarginTop + frameHeight), frameTexture, ScaleMode.ScaleToFit, true, 0);        
    }

    public void ReduceHealth(float percent) {
        if (healthWidth > _emptyHealth) {
            healthWidth = (int)Mathf.Floor((float)(healthWidth) - percent * (float)healthWidth);
        }
    }

    public void EmptyHP() {
        healthWidth = _emptyHealth;
    }

    public void FillHP() {
        healthWidth = _fullHealth;
    }
}
