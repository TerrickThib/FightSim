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
        int currentMonsterIndex = 0;
        int currentScene = 0;
        
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
            //Arrary assignment
            int[] numbers = new int[4] { 1, 2, 3, 4};
            ArrayRepeat(numbers);
            while (!gameOver)
            {
                Update();
            }

            End();
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

            ResetCurrentMonsters();
        }

        void ResetCurrentMonsters()
        {
            currentMonsterIndex = 0;
            //Set starting fighters
            currentMonster1 = GetMonster(currentMonsterIndex);
            currentMonsterIndex++;
            currentMonster2 = GetMonster(currentMonsterIndex);
        }

        void UpdateCurrentScene()
        {
            switch (currentScene)
            {
                case 0:
                    DisplayStartMenu();
                    break;

                case 1:
                    Battle();
                    UpdateCurrentMonsters();
                    Console.ReadKey();
                    break;

                case 2:
                    DisplayRestartMenu();
                    break;

                default:
                    Console.WriteLine("Invalid scene index");
                    break;
            }
             
        }
        /// <summary>
        /// Gets an input from the player based on some decision
        /// </summary>
        /// <param name="description">The context for the decision</param>
        /// <param name="option1">The first choice the player has</param>
        /// <param name="option2">The second choice the player has</param>
        /// <param name="pauseInvalid">If true, the player must press a key to continue after inputting
        /// an incorrect value</param>
        /// <returns>A number representing which of the two options was choosen. Returns 0 if an
        /// invalid input was recieved</returns>
        int GetInput(string description, string option1, string option2, bool pauseInvalid = false)
        {
            //Print the context and options
            Console.WriteLine(description);
            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option2);

            //Get player input
            string input = Console.ReadLine();
            int choice = 0;

            //If the player typed 1...
            if (input == "1")
            {
                //...Set the return variable to be 1
                choice = 1;
            }
            //If the player typed 2...
            else if (input =="2")
            {
                //...Set the return variable to be 2
                choice = 2;
            }
            //If the player did not type a 1 or a 2
            else
            {
                //...Let them know the input was invalid
                Console.WriteLine("Invalid Input");

                //If we want to pause when an invalid input is recieved..
                if(pauseInvalid)
                {

                    Console.ReadKey(true);
                }
            }

            return choice;
        }
        /// <summary>
        /// Displays the starting menu. Gives the player the option to start 
        /// oe exit the simulation
        /// </summary>

        void DisplayStartMenu()
        {
            //Gets players choice
            int choice = GetInput("Welcome to Monster Fight Simulator and Uncle Phil", "Start Simulation", "Quit Appliocation");
            //If they chose to start the simulation...
            if (choice ==1)
            {
                //..start the battle scene
                currentScene = 1;
            }
            //Otherwise if they chose to exit...
            else if (choice ==2)
            {
                //...end the game
                gameOver = true;
            }
        }

        /// <summary>
        /// Displays the restart menu. Gives the player the option to restart or exit the program
        /// </summary>
        void DisplayRestartMenu()
        {
            //Gets the players choice
            int choice = GetInput("Simulation over. Would you like to play again?", "Yes", "No");

            //If the player chose to restart...
            if (choice == 1)
            {
                //...Set the current scene to be the start menu
                ResetCurrentMonsters();
                currentScene = 0;
            }
            //If player choose to end game
            else if (choice == 2)
            {
                //Ends the Simulation
                gameOver = true;
            }
        }

        /// <summary>
        /// Gets called every game loop
        /// </summary>
        void Update()
        {
            UpdateCurrentScene();
            Console.Clear();
        }

        void End()
        {
            Console.WriteLine("Guhbah fren");
        }

        Monster GetMonster(int monsterIndex)
        {
            Monster monster;
            monster.name = "None";
            monster.attack = 1;
            monster.defense = 1;
            monster.health = 1;

            if (monsterIndex == 0)
            {
                monster = UnclePhil;
            }
            else if (monsterIndex == 1)
            {
                monster = Backupwompus;
            }
            else if (monsterIndex == 2)
            {
                monster = wompus;
            }
            else if (monsterIndex == 3)
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
        //Array assignment       
        void ArrayRepeat(int[] numbers)
        {
            //int[] numbers = new int[5] { 1, 2, 3, 4, 5 };
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }
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
                //...go to the restart menu
                currentScene = 2;
            }
        }
                                       
    }

}
