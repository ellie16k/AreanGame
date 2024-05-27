using ArenaGame;
using ArenaGame.Heroes;
using ArenaGame.Weapons;

namespace WinFormArenaGame
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void gameNotification(GameEngine.NotificationArgs args)
        {
            TextBox tbAttacker;
            if (args.Attacker is Knight)
                tbAttacker = tbKnight;
            else
                tbAttacker = tbAssassin;

            tbAttacker.AppendText(
                $"{args.Attacker.Name} attacked {args.Defender.Name} with {Math.Round(args.Attack, 2)} and caused {Math.Round(args.Damage, 2)} damage.\r\n");

            DateTime dt = DateTime.Now;
            
            while (DateTime.Now - dt < TimeSpan.FromMilliseconds(300))
            {
                Application.DoEvents();
            }
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            lbWinner.Text = "";
            tbAssassin.Text = "";
            tbKnight.Text = "";
            lbWinner.Visible = false;

            // Add a mechanism to select different heroes or initialize them here
            List<Hero> heroes = new List<Hero>
    {
        new Knight("Knight", 10, 20, new Sword("Sword")),
        new Assassin("Assassin", 10, 5, new Dagger("Dagger")),
        new Mage("Mage", 8, 15, new Staff("Staff")),
        new Barbarian("Barbarian", 12, 18, new Axe("Axe"))
    };

            // Randomly choose two heroes for the fight
            Random random = new Random();
            Hero heroA = heroes[random.Next(heroes.Count)];
            Hero heroB;
            do
            {
                heroB = heroes[random.Next(heroes.Count)];
            } while (heroB == heroA);

            GameEngine gameEngine = new GameEngine()
            {
                HeroA = heroA,
                HeroB = heroB,
                NotificationsCallBack = gameNotification
            };

            imgFight.Enabled = true;
            gameEngine.Fight();
            imgFight.Enabled = false;

            lbWinner.Text = $"And the winner is:\n{gameEngine.Winner}";
            lbWinner.Visible = true;
        }


        private void lbWinner_Click(object sender, EventArgs e)
        {

        }

    }
}