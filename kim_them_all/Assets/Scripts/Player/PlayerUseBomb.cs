 using UnityEngine;

namespace CompleteProject
{
    public class PlayerUseBomb : MonoBehaviour
    {
        GameObject nuke;

        public void UseBomb(ScriptHud hudDisplay)
        {
            if (GameObject.FindGameObjectWithTag("Bomb") == null)
                nuke = (GameObject)Instantiate(Resources.Load("NuclearBomb"), new Vector3(60, 20, 50), Quaternion.Euler(new Vector3(0, 0, -90)));
            else
                return;
        }
    }
}
