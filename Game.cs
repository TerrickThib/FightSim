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
        //Varibles
        bool gameOver = false;
        Monster currentMonster1;
        Monster currentMonster2;
        int currentMonsterIndex = 1;
        //Monsters
        Monster wompus;
        Monster thompus;
        Monster Backupwompus;
        Monster UnclePhil;

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
            Start();
            
            while (!gameOver)
            {
                Update();
            }
                                    
        }

        void Start()
        {
            //Monster 1
            wompus.name = "Wompus";
            wompus.attack = 15.0f;
            wompus.defense = 5.0f;
            wompus.health = 20.0f;


            //Monster 2
            thompus.name = "Thompus";
            thompus.attack = 15.0f;
            thompus.defense = 10.0f;
            thompus.health = 15.0f;

            //Monster3
            Backupwompus.name = "Backup Wompus";
            Backupwompus.attack = 25.6f;
            Backupwompus.defense = 5.0f;
            Backupwompus.health = 3.0f;

            //Monster4
            UnclePhil.name = "Uncle Phil";
            UnclePhil.attack = 100000000000f;
            UnclePhil.defense = 0f;
            UnclePhil.health = 1.0f;

            //Set starting fighters
            currentMonster1 = GetMonster(currentMonsterIndex);
            currentMonsterIndex++;
            currentMonster2 = GetMonster(currentMonsterIndex);

        }

        void Update()
        {
            Battle();
            UpdateCurrentMonsters();
            Console.ReadKey(true);
            Console.Clear();
        }

        Monster GetMonster(int monsterIndex)
        {
            Monster monster;
            monster.name = "None";
            monster.attack = 1;
            monster.defense = 1;
            monster.health = 1;

            if (monsterIndex == 1)
            {
                monster = UnclePhil;
            }
            else if (monsterIndex == 2)
            {
                monster = Backupwompus;
            }
            else if (monsterIndex == 3)
            {
                monster = wompus;
            }
            else if (monsterIndex == 4)
            {
                monster = thompus;
            }

            return monster;
        }

        /// <summary>
        /// Simulates one turn in the current monster fight
        /// </summary>
        void Battle()
        {
            //Print Monster1 stats
            PrintStats(currentMonster1);
            //Print Monster2 stats
            PrintStats(currentMonster2);

            //Monster 1 attacks Monster 2
            float damageTaken = Fight(currentMonster1, ref currentMonster2);
            Console.WriteLine(currentMonster2.name + " has taken " + damageTaken);

            //Monster 2 attacks Monster 1
            damageTaken = Fight(currentMonster2, ref currentMonster1);
            Console.WriteLine(currentMonster1.name + " has taken " + damageTaken);            
        }

        /// <summary>
        /// Changes one of the current fighters to be the next in the list 
        /// if it has died. Ends the game if all fighters in the list have bben used.
        /// </summary>
        void UpdateCurrentMonsters()
        {
            //If monster 1 has died
            if(currentMonster1.health <= 0)
            {
                //...increment the current monster index and swap out the monster
                currentMonsterIndex++;
                currentMonster1 = GetMonster(currentMonsterIndex);
            }
            //If monster 2 has died
            if(currentMonster2.health <= 0)
            {
                //...increment the current monster index and swap out the monster
                currentMonsterIndex++;
                currentMonster2 = GetMonster(currentMonsterIndex);
            }
            //If either monster is set to "None" andthe last monster has been set...
            if (currentMonster2.name == "None" || currentMonster1.name == "None" && currentMonsterIndex >= 4)
            {
                //...end the game
                Console.WriteLine("Simulation Over");
                gameOver = true;
            }
        }
                                       
    }

}
