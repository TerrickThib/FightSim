using System;
using System.Collections.Generic;
using System.Text;

namespace FightSim
{
    struct Monster
    {
        public string name;
        public float health;
        public float attack;
        public float defense;
    }
    

    class Game
    {
        //Function for monster attack
        float Fight(Monster attacker, ref Monster defender)
        {
            float damageTaken = CalculateDamage(attacker, defender);
            defender.health -= damageTaken;
            return damageTaken;
        }
        
        //Stats Function
        void PrintStats(Monster monster)
        {
            Console.WriteLine("Name: " + monster.name);
            Console.WriteLine("Health: " + monster.health);
            Console.WriteLine("Attack: " + monster.attack);
            Console.WriteLine("Defense: " + monster.defense);
        }
        
        //Dammage Function
        float CalculateDamage(float attack, float defense)
        {
            float damage = attack - defense;

            if (damage <= 0)
            {
                damage = 0;
            }

            return damage;
        }
        float CalculateDamage(Monster attacker, Monster defender)
        {
            return attacker.attack - defender.defense;
        }

        //Function For Fight 
        string StartBattle(ref Monster wompus, ref Monster thompus)
        {
            string matchResult = "No Contest";

            while (wompus.health > 0 && thompus.health > 0)
            {
                //Print Monster1 stats
                PrintStats(wompus);
                //Print Monster2 stats
                PrintStats(thompus);

                //Monster 1 attacks Monster 2
                float damageTaken = Fight(wompus, ref thompus);
                Console.WriteLine(thompus.name + " has taken " + damageTaken);

                //Monster 2 attacks Monster 1
                damageTaken = Fight(thompus, ref wompus);
                Console.WriteLine(wompus.name + " has taken " + damageTaken);

                Console.ReadKey(true);
                Console.Clear();
            }

            if (wompus.health < 0 && thompus.health <= 0)
            {
                matchResult = "Draw";
            }

            else if (wompus.health > 0)
            {
                matchResult = wompus.name;
            }
            else if (thompus.health > 0)
            {
                matchResult = thompus.name;
            }


            return matchResult;
        }
                                
        public void Run()
        {
            //Monster 1 Stats
            Monster wompus;
            wompus.name = "Wompus";
            wompus.attack = 15.0f;
            wompus.defense = 5.0f;
            wompus.health = 20.0f;


            //Monster 2
            Monster thompus;
            thompus.name = "Thompus";
            thompus.attack = 15.0f;
            thompus.defense = 10.0f;
            thompus.health = 15.0f;

            //Monster3
            Monster Backupwompus;
            Backupwompus.name = "Backup Wompus";
            Backupwompus.attack = 25.6f;
            Backupwompus.defense = 5.0f;
            Backupwompus.health = 3.0f;

            //Monster4
            Monster UnclePhil;
            UnclePhil.name = "Uncle Phil";
            UnclePhil.attack = 1000000f;
            UnclePhil.defense = 0f;
            UnclePhil.health = 1.0f;
            
            //Game Fight Starts
            string result = StartBattle(ref wompus, ref thompus);

            if (result == "Draw")
            {
                Console.WriteLine("Match was a draw. ");
            }
            else
            {
                Console.WriteLine(result + " wins!!");
            }

            result = StartBattle(ref Backupwompus, ref UnclePhil);

                                 
        }

        
                                       
    }

}
