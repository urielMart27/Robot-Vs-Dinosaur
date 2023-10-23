namespace Robot_Vs_DInosaur_Project
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Welcome welcome = new Welcome();
            Console.WriteLine();
            
                Battlefield battlefield= new Battlefield();
                battlefield.RunGame();

        }

        public class Welcome
        {
            public void DisplayAWelcomeMessage(string welcomemessage)
            {
                Console.WriteLine(welcomemessage);
            }
        }




        // Weapon Class
        public class Weapon
        {
            public string type;
            int attackPower;

            public Weapon(string type, int attackpower)
            {
                this.type = type;
                
                this.attackPower = attackpower;
            }
            public int GetWeaponDamage()
            {
                return attackPower;
            }
        }



        //Dinosaur Class
        public class Dinosaur
        {
            public string name;
            int health;
            int DinosaurAttackPower;

            public Dinosaur(string name, int DinosaurAttackPower, int health)
            {
                this.name = name;
                this.DinosaurAttackPower = DinosaurAttackPower;
                this.health = health;
            }
            public int GetHealth()
            {
                return health;
            }

            public void AttackRobot(Robot robot)
            {
                Console.WriteLine($"{name} attacks {robot.name} for {DinosaurAttackPower} damage!");
                robot.TakeDamage(DinosaurAttackPower);
                Console.WriteLine();
            }
            public void TakeDamage(int damage)
            {
                health -= damage;
                Console.WriteLine($"{name} now has {health}");
            }

        }

        // Robot Class
        public class Robot
        {
            public string name;
            int health;
            Weapon activeweapon;

            public Robot(string name, int health, Weapon activeweapon)
            {
                this.name = name;
                this.health = health;
                this.activeweapon = activeweapon;

            }
            public int GetHealth()
            {
                return health;
            }


            public void TakeDamage(int damage)
            {
                health -= damage;
                Console.WriteLine($"{name} now has {health} health");
            }
            public void AttackDinosaur(Dinosaur dinosaur)
            {
                if (activeweapon != null)
                {

                    int damage = activeweapon.GetWeaponDamage();
                    Console.WriteLine($"{name} attacks {dinosaur.name} with {activeweapon.type} for {damage} damage!");
                    dinosaur.TakeDamage(damage);
                    Console.WriteLine();
                }


            }

        }



        public class Battlefield
        {
            public void DisplayAWelcomeMessage()
            {
                Welcome welcome = new Welcome();
                welcome.DisplayAWelcomeMessage("Welcome to the Dinosaur vs. Robot game");
                Console.WriteLine();
            }
            public void BattleSequence(Dinosaur dinosaur, Robot robot)
            {
                while (dinosaur.GetHealth() > 0 && robot.GetHealth() > 0)
                {
                    dinosaur.AttackRobot(robot);
                    if (robot.GetHealth() <= 0)
                    {
                        break;
                    }
                    robot.AttackDinosaur(dinosaur);
                    if (dinosaur.GetHealth() <= 0)
                    {
                        break;
                    }
                }
            }
            public void AnnounceWinner(Dinosaur dinosaur, Robot robot)
            {
                
                    if (dinosaur.GetHealth() <= 0)
                    {
                        Console.WriteLine($"{robot.name} wins!");
                    }
                
                else if (robot.GetHealth() <= 0)
                {
                    Console.WriteLine($"{dinosaur.name} wins!");

                }
            
            }

            public void RunGame()
            {
                DisplayAWelcomeMessage();

                Dinosaur dinosaur = new Dinosaur("Triceratops", 20, 100);
                Weapon activeweapon = new Weapon("Sword", 15);
                Robot robot = new Robot("Ultron", 100, activeweapon);

                BattleSequence(dinosaur, robot);
                AnnounceWinner(dinosaur, robot);
            }

        }
    }
}

    
