using UnityEngine;

public class PStudy : MonoBehaviour
{
    private void Start()
    {
        //int floor = 5;
        //for (int i = 1; i <= floor; ++i)
        //{
        //    string stars = "";
        //    string gap = "";
        //    for (int j = 0; j < i; ++j)
        //    {
        //        stars += "*";
        //    }
        //    Debug.Log(stars);
        //}
        //for (int i = 0; i < floor; ++i)
        //{
        //    string stars = "";
        //    for (int j = 1; j < floor-i; ++j)
        //    {
        //        stars += "*";
        //    }
        //    Debug.Log(stars);
        //}

    /*    int floor = 9;
        for (int i = 0; i <= floor; ++i)
        {
            string stars = "";
            string gap = " ";
            for (int j = floor - 1; j > i; j--)
            {
                gap += " ";
            }
            for (int k = 0; k < 2*i+1; ++k)
            {
                stars += "*";
            }
            Debug.Log(gap+stars);
        }
        for (int i = 0; i < floor; ++i)
        {
            string stars = "";
            string gap = " ";

            for (int j =0 ; j < i*2+1; ++j)
            {
                gap += " ";
            }
            for (int k = 0; k < 2*(floor-i)-1; ++k)
            {
                stars += "*";
            }
            Debug.Log(gap + stars);
        }*/

        Player player = new Player();
        player.Power();
        player.Damagae(20);
    }

    public class Player
    {
        private int hp = 150;
        private int power = 30;

        public void Power()
        {
            Debug.Log("플레이어의 힘은 " + this.power + " 입니다.");
        }

        public void Damagae(int damage)
        {
            Debug.Log("현재 체력 : " + this.hp);
            Debug.Log("현재 체력 : " + hp);
            hp-= damage;
            Debug.Log("입은 데미지 : " + damage);
            Debug.Log("현재 체력 : " + hp);
            Debug.Log("현재 체력 : " + this.hp);

        }
    }
}

//(2*floor-i)-1