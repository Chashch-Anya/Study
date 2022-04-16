using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;
using System.Timers;

namespace SeaBattle
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        public static SoundPlayer musik = new SoundPlayer(@"C:\Users\USER\source\repos\SeaBattle\SeaBattle\Resources\муз\фон.wav");
        public SoundPlayer NoMiss = new SoundPlayer(@"C:\Users\USER\source\repos\SeaBattle\SeaBattle\Resources\муз\взрыв.wav");
        public SoundPlayer DGoDown = new SoundPlayer(@"C:\Users\USER\source\repos\SeaBattle\SeaBattle\Resources\муз\потоплен.wav");
        public SoundPlayer Win = new SoundPlayer(@"C:\Users\USER\source\repos\SeaBattle\SeaBattle\Resources\муз\победа.wav");
        public SoundPlayer NoWin = new SoundPlayer(@"C:\Users\USER\source\repos\SeaBattle\SeaBattle\Resources\муз\проигрыш.wav");
        public SoundPlayer Miss = new SoundPlayer(@"C:\Users\USER\source\repos\SeaBattle\SeaBattle\Resources\муз\мимо.wav");


        public static bool Start = false;//Игра началась?
        public static string Name;
        public static string[] BotName = { "Капитан Черная Борода", "Капитан Френсис Дрейк", "Капитан Барбаросса", "Грейс О`Мэлли", "Уильям Кидд" };

        // Переменные для бота

        // 0 - пустая клетка, 1 - палуба, 2 - зона вокруг корабля, 3 - попадание

        public static int[,] BotField = {{0,0,0,0,0,0,0,0,0,0},
                                         {0,0,0,0,0,0,0,0,0,0},
                                         {0,0,0,0,0,0,0,0,0,0},
                                         {0,0,0,0,0,0,0,0,0,0},
                                         {0,0,0,0,0,0,0,0,0,0},
                                         {0,0,0,0,0,0,0,0,0,0},
                                         {0,0,0,0,0,0,0,0,0,0},
                                         {0,0,0,0,0,0,0,0,0,0},
                                         {0,0,0,0,0,0,0,0,0,0},
                                         {0,0,0,0,0,0,0,0,0,0}};

        public int BotX;
        public int BotY;
        public int BotLocation = 0;//Расположеие корабля (1- горизонтально, 2-вертикально)
        public int BotDeck = 20;//Количество оставишихся палуб у соперника
        int BotShot = 0;// Количество ходов(выстрелов) компьютера
        bool BotMove = false; //Ход соперника?
        int BotDeckGoDown = 0;//Количство потопленных палуб у корабля

        //Переменные игрока
        public static int[,] UserField = {{0,0,0,0,0,0,0,0,0,0},
                                          {0,0,0,0,0,0,0,0,0,0},
                                          {0,0,0,0,0,0,0,0,0,0},
                                          {0,0,0,0,0,0,0,0,0,0},
                                          {0,0,0,0,0,0,0,0,0,0},
                                          {0,0,0,0,0,0,0,0,0,0},
                                          {0,0,0,0,0,0,0,0,0,0},
                                          {0,0,0,0,0,0,0,0,0,0},
                                          {0,0,0,0,0,0,0,0,0,0},
                                          {0,0,0,0,0,0,0,0,0,0}};
        public int UserX;
        public int UserY;
        public int UserLocation = 0;//Расположеие корабля (1- горизонтально, 2-вертикально)
        public int UserDeck = 20;//Количество оставишихся палуб
        bool UserMove = true;//Ход игрока?
        int UserShot = 0;// Количество ходов(выстреорв) игрока
        int UserDeckGoDown = 0;//Количство потопленных палуб у корабля
        string str;


        public void ShotAndDeckLabel()
        {
            UMove.Text = Convert.ToString(UserShot);
            BMove.Text = Convert.ToString(BotShot);
            UDeck.Text = Convert.ToString(UserDeck);
            BDeck.Text = Convert.ToString(BotDeck);
        }

        private void BName()
        {
            Random rnd = new Random();
            int k = rnd.Next(0, 5);
            ComputerName.Text = BotName[k];
            switch (k)
            {
                case 0:
                    CaptainBlackBeard Bot1 = new CaptainBlackBeard();
                    Bot1.Show();
                    break;
                case 1:
                    CaptainFrancisDrake Bot2 = new CaptainFrancisDrake();
                    Bot2.Show();
                    break;
                case 2:
                    CaptainBarbarossa Bot3 = new CaptainBarbarossa();
                    Bot3.Show();
                    break;
                case 3:
                    GraceOMelly Bot4 = new GraceOMelly();
                    Bot4.Show();
                    break;
                case 4:
                    WilliamKid Bot5 = new WilliamKid();
                    Bot5.Show();
                    break;
            }
        }

        //Начать новый бой
        private void NewFight_Click_1(object sender, EventArgs e)
        {
            NewGame();
            ShipArrangement F1 = new ShipArrangement();
            F1.Show();
            this.Hide();

        }

        private void NewGame()
        {
            Start = false;
            BotField = new int[10, 10];
            BotLocation = 0;
            BotDeck = 20;
            BotShot = 0;
            BotMove = false;
            BotDeckGoDown = 0;
            UserField = new int[10, 10];
            UserLocation = 0;
            UserDeck = 20;
            UserMove = true;
            UserShot = 0;
            UserDeckGoDown = 0;
        }
        //Правила игры
        private void Rules_Click(object sender, EventArgs e)
        {
            //Показ формы с правилами гры
            RulesOfTheGame Rules = new RulesOfTheGame();
            Rules.Show();
        }

        //Выход из игры
        private void Exit_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        //Показ формы с правилами игры
        private void Rules_Click_1(object sender, EventArgs e)
        {
            RulesOfTheGame rules = new RulesOfTheGame();
            rules.Show();
        }

        //При загрузке формы
        private void Main_Load(object sender, EventArgs e)
        {
            PlayerName.Text = Name;
            dataGridViewUser.Enabled = false;
            dataGridViewBot.Enabled = true;
            ShotAndDeckLabel();
            dataGridViewUser.RowCount = 10;
            dataGridViewBot.RowCount = 10;

            if (Start)
                ChatInp.Text = null;
            for (int i = 0; i < 10; i++)
                dataGridViewUser[0, i].Value = ShipArrangement.abc[i];
            for (int i = 1; i < 11; i++)
                for (int j = 0; j < 10; j++)
                    dataGridViewUser[i, j].Style.BackColor = System.Drawing.Color.White;

            for (int i = 0; i < 10; i++)
                dataGridViewBot[0, i].Value = ShipArrangement.abc[i];
            for (int i = 1; i < 11; i++)
                for (int j = 0; j < 10; j++)
                    dataGridViewBot[i, j].Style.BackColor = System.Drawing.Color.White;
            if (Start == true)
            {
                BName();
                pictureBox1.Dispose();
                for (int i = 0; i < 10; i++)
                    for (int j = 0; j < 10; j++)
                        ShipArrangement.Arrangement(dataGridViewUser, Main.UserField, i, j);
                str += "Бой начался. За вами право первогов выстрела" + "\n";
                ChatInp.Text = str + "\n";
                ChatInp.SelectionStart = ChatInp.TextLength;
                Cursor = Cursors.Default;
            }
        }

        private void dataGridViewBot_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGrid = (DataGridView)sender;
            DataGridViewSelectedCellCollection dataGridCellCollection = dataGrid.SelectedCells;
            DataGridViewCell dataGridViewCell = (DataGridViewCell)dataGridCellCollection[0];
            BotY = dataGridViewCell.RowIndex;
            BotX = dataGridViewCell.ColumnIndex - 1;
            UserShoot(BotX, BotY);
            UserShot++;
            ShotAndDeckLabel();
        }

        Random rnd = new Random();
        //"выстрел" противника
        private void RandomPoint()
        {
            do
            {
                UserX = rnd.Next(0, 10);
                UserY = rnd.Next(0, 10);
            }
            while (UserField[UserX, UserY] == 2 || UserField[UserX, UserY] == 3);
        }

        //Продолжение или конец игры
        private void ToWin()
        {
            if (UserDeck == 0)
            {
                BotMove = false;
                UserMove = false;

                for (int i = 0; i < 10; i++)
                    for (int j = 0; j < 10; j++)
                    {
                        ShipArrangement.Arrangement(dataGridViewUser, Main.UserField, i, j);
                        ShipArrangement.Arrangement(dataGridViewBot, Main.BotField, i, j);

                    }
                dataGridViewUser.Enabled = false;
                dataGridViewBot.Enabled = false;
                label1.Text = "Поражение";
                ChatInp.Text += "Поражение! Игра окончена";
                ChatInp.SelectionStart = ChatInp.TextLength;
                if (Sound.OtherS == true)
                {
                    NoWin.Play();
                }
                MessageBox.Show("Поражение! Игра окончена");

            }
            else if (BotDeck == 0)
            {
                BotMove = false;
                UserMove = false;
                dataGridViewUser.Enabled = false;
                dataGridViewBot.Enabled = false;
                label1.Text = "Победа";
                ChatInp.Text += "Победа! Игра окончена";
                if (Sound.OtherS == true)
                {
                    Win.Play();
                }
                ChatInp.SelectionStart = ChatInp.TextLength;
                MessageBox.Show("Победа! Игра окончена");


            }
        }


        //Ход игрока
        private void UserShoot(int x, int y)
        {
            if (x >= 0)
            {
                if (BotField[x, y] == 2 || BotField[x, y] == 3)
                {
                    UserShot--;
                    str += "Вы уже совершали выстрел в эту клетку. Повторите ход" + "\n";
                    ChatInp.Text = str;
                    ChatInp.SelectionStart = ChatInp.TextLength;
                }
                else
                {
                    if (BotField[x, y] == 1)
                    {
                        UserNoMiss(x, y);
                        ToWin();
                    }
                    else
                    {
                        BotField[x, y] = 3;
                        ShipArrangement.Arrangement(dataGridViewBot, BotField, x, y);
                        str += "Мимо! Право хода переходит сопернику" + "\n";
                        label1.Text = "Ход соперника";
                        ChatInp.Text = str;
                        ChatInp.SelectionStart = ChatInp.TextLength;
                        UserMove = false;
                        BotMove = true;
                        dataGridViewBot.Enabled = false;
                        timer1.Enabled = true;
                        if (Sound.OtherS == true)
                        {
                            Miss.Play();
                        }
                    }
                }
            }
        }

        //
        private void CheckUserShipLokal(int x1,int y1)
        {
            int loc;
            bool local = false;
            loc = rnd.Next(0, 4);
            while (!local)
            {
                switch (loc)
                {
                    case 0:
                        if (x1 + 1 > 9)
                        {
                            loc = rnd.Next(0, 4);
                        }
                        else if (UserField[x1 + 1, y1] == 2 || UserField[x1 + 1, y1] == 3) loc = rnd.Next(0, 4);
                        else
                        {
                            local = true;
                            x1++;
                        }
                        break;
                    case 1:
                        if (x1 - 1 < 0)
                        {
                            loc = rnd.Next(0, 4);
                        }
                        else if (UserField[x1 - 1, y1] == 2 || UserField[x1 - 1, y1] == 3) loc = rnd.Next(0, 4);
                        else
                        {
                            local = true;
                            x1--;
                        }
                        break;
                    case 2:
                        if (1 + y1 > 9) loc = rnd.Next(0, 4);
                        else if (UserField[x1, 1 + y1] == 2 || UserField[x1, 1 + y1] == 3) loc = rnd.Next(0, 4);
                        else
                        {
                            local = true;
                            y1++;
                        }
                        break;
                    case 3:
                        if (y1 - 1 < 0) loc = rnd.Next(0, 4);
                        else if (UserField[x1, y1 - 1] == 2 || UserField[x1, y1 - 1] == 3) loc = rnd.Next(0, 4);
                        else
                        {
                            local = true;
                            y1--;
                        }
                        break;

                }

            }

            if (UserField[x1, y1] == 1)
            {
                if (loc == 0 || loc == 1) UserLocation = 1;
                else UserLocation = 2;
                UserX = x1;
                UserY = y1;
                BotNoMiss();
            }
            else
            {
                BotMiss(x1, y1);

            }
        }
        //
        private void SmartComputer()
        {
            int x1 = UserX;
            int y1 = UserY;
            Random rnd = new Random();
            int loc;
            bool local = false;
            if (UserLocation == 0)
            {//определяем как расположен корабль
                CheckUserShipLokal(x1,y1);
            }
            else if (UserLocation == 1)
            {
                loc = rnd.Next(0, 2);
                while (!local)
                {
                    int i = x1;
                    switch (loc)
                    {
                        case 0:
                            if (x1 + 1 > 9)
                            {
                                loc = rnd.Next(0, 2);
                            }
                            else
                            {
                                while (i < 9)
                                {
                                    i++;
                                    if (UserField[i, y1] == 3) { break; }
                                    if (UserField[i, y1] == 1 || UserField[i, y1] == 0) { x1 = i; local = true; break; }
                                }
                                if (!local) loc = rnd.Next(0, 2);
                            }
                            break;
                        case 1:
                            if (x1 - 1 < 0)
                            {
                                loc = rnd.Next(0, 2);
                            }
                            else
                            {
                                while (i > 0)
                                {
                                    i--;
                                    if (UserField[i, y1] == 3) { break; }
                                    if (UserField[i, y1] == 1 || UserField[i, y1] == 0) { x1 = i; local = true; break; }
                                }
                                if (!local) loc = rnd.Next(0, 2);
                            }
                            break;
                    }
                }

                if (UserField[x1, y1] == 1)
                {
                    UserX = x1;
                    UserY = y1;
                    BotNoMiss();

                }
                else if (UserField[x1, y1] == 0)
                {
                    BotMiss(x1, y1);
                    if (x1 < UserX)
                        UserX = UserX + UserDeckGoDown - 1;
                    else UserX = UserX - UserDeckGoDown + 1;
                }

            }
            else if (UserLocation == 2)
            {
                loc = rnd.Next(0, 2);
                while (!local)
                {
                    int i = y1;
                    switch (loc)
                    {
                        case 0:
                            if (y1 + 1 > 9)
                            {
                                loc = rnd.Next(0, 2);
                            }
                            else
                            {
                                while (i < 9)
                                {
                                    i++;
                                    if (UserField[x1, i] == 3) { break; }
                                    if (UserField[x1, i] == 1 || UserField[x1, i] == 0) { y1 = i; local = true; break; }
                                }
                                if (!local) loc = rnd.Next(0, 2);
                            }
                            break;
                        case 1:
                            if (y1 - 1 < 0)
                            {
                                loc = rnd.Next(0, 2);
                            }
                            else
                            {
                                while (i > 0)
                                {
                                    i--;
                                    if (UserField[x1, i] == 3) { break; }
                                    if (UserField[x1, i] == 1 || UserField[x1, i] == 0) { y1 = i; local = true; break; }
                                }
                                if (!local) loc = rnd.Next(0, 2);
                            }
                            break;
                    }
                }

                if (UserField[x1, y1] == 1)
                {
                    UserX = x1;
                    UserY = y1;
                    BotNoMiss();

                }
                else
                {
                    BotMiss(x1, y1);
                    if (y1 < UserY)
                        UserY = UserY + UserDeckGoDown - 1;
                    else UserY = UserY - UserDeckGoDown + 1;
                }
            }

        }



        //Окрашивание клеток вокруг корабля
        private void Color(int[,] Field, int x, int y, int Localization, int DeckGoDown, DataGridView Data)
        { if (Localization == 0)
            {
                for (int i = x - 1; i <= x + 1; i++)
                    for (int j = y - 1; j <= y + 1; j++)
                    {
                        if (i >= 0 && i < 10 && j >= 0 && j < 10)
                        {
                            if (Field[i, j] == 0) Field[i, j] = 3;
                            ShipArrangement.Arrangement(Data, Field, i, j);
                        }
                    }
            }
            else if (Localization == 1)
            {
                for (int i = FindTheEdge(Field, x, y, Localization, DeckGoDown); i <= FindTheEdge(Field, x, y, Localization, DeckGoDown) + DeckGoDown + 1; i++)
                    for (int j = y - 1; j <= y + 1; j++)
                        if (i >= 0 && i < 10 && j >= 0 && j < 10)
                        {
                            if (Field[i, j] == 0) Field[i, j] = 3;
                            ShipArrangement.Arrangement(Data, Field, i, j);
                        }
            }
            else if (Localization == 2)
            {
                for (int j = FindTheEdge(Field, x, y, Localization, DeckGoDown); j <= FindTheEdge(Field, x, y, Localization, DeckGoDown) + DeckGoDown + 1; j++)
                    for (int i = x - 1; i <= x + 1; i++)
                        if (i >= 0 && i < 10 && j >= 0 && j < 10)
                        {
                            if (Field[i, j] == 0) Field[i, j] = 3;
                            ShipArrangement.Arrangement(Data, Field, i, j);
                        }
            }

        }

        //Поиск самой левой/верхней точки корабля
        private int FindTheEdge(int[,] Field, int x, int y, int Location, int DeckGoDown)
        {
            int edge = 0;

            if (Location == 1)
            {
                {

                    edge = x;
                    while ((Field[edge, y] == 2) && edge >= 0)
                    {
                        edge--;
                        if (edge < 0) break;
                    }
                }
            }
            else if (Location == 2)
            {
                edge = y;
                while ((Field[x, edge] == 2) && edge >= 0)
                {
                    edge--;
                    if (edge < 0) break;
                }
            }
            return edge;
        }

        //
        private void ComputerShoot()
        {
            if (UserDeck != 0)
            {
                if (UserDeckGoDown == 0)//Если корабль был добит, то ищет следующий
                {
                    RandomPoint();
                    if (UserField[UserX, UserY] == 1)
                    {
                        BotNoMiss();
                        ToWin();
                    }
                    else if (UserField[UserX, UserY] == 0)
                    {
                        BotMiss(UserX, UserY);
                        ShotAndDeckLabel();
                        return;
                    }
                }

                if (UserDeckGoDown != 0)//иначе добивает старый
                {
                    SmartComputer();

                }
            }
            else ToWin();


        }

        private void IfGoDown()
        {
            if (BotMove)
            {
                Color(UserField, UserX, UserY, UserLocation, UserDeckGoDown, dataGridViewUser);
                UserDeckGoDown = 0;
                str += "Ваш корабль потопили! Право хода остается за соперником" + "\n";
                ChatInp.Text = str;
                UserLocation = 0;
                ChatInp.SelectionStart = ChatInp.TextLength;


            }
            else if (UserMove)
            {
                Color(BotField, BotX, BotY, BotLocation, BotDeckGoDown, dataGridViewBot);
                BotDeckGoDown = 0;
                BotLocation = 0;
                str += "Корабль противника потоплен! Право хода остается за вами" + "\n";
                ChatInp.Text = str;
                ChatInp.SelectionStart = ChatInp.TextLength;

            }

        }

        private void BotMiss(int x, int y)
        {
            Chat(x, y);
            BotShot++;
            UserField[x, y] = 3;
            ShipArrangement.Arrangement(dataGridViewUser, UserField, x, y);
            str += "Противник промахивается! Право хода переходит вам" + "\n";
            label1.Text = "Ваш ход";
            ChatInp.Text = str;
            ChatInp.SelectionStart = ChatInp.TextLength;

            dataGridViewBot.Enabled = true;
            BotMove = false;
            UserMove = true;
            timer1.Enabled = false;
            this.Cursor = Cursors.Default;
        }

        private void BotNoMiss()
        {
            UserDeckGoDown++;
            UserDeck--;
            UserField[UserX, UserY] = 2;
            ShipArrangement.Arrangement(dataGridViewUser, UserField, UserX, UserY);
            if (GoDown(UserField, UserX, UserY, UserLocation, UserDeckGoDown))
            {

                if (Sound.OtherS == true)
                {
                    DGoDown.Play();
                }
                Chat(UserX, UserY);
                IfGoDown();
                BotShot++;
            }
            else
            {
                Chat(UserX, UserY);
                str += "В ваш корабль попали! Право хода остается за соперником" + "\n";
                BotShot++;
                ChatInp.Text = str;
                ChatInp.SelectionStart = ChatInp.TextLength;
            }
            ShotAndDeckLabel();
            if (Sound.OtherS == true)
            {
                NoMiss.Play();
            }

        }

        private bool GoDown(int[,] Field, int x, int y, int Location, int DeckGoDown)
        {
            //первое попадание по кораблю, проверка:является ли однопалубным
            //если корабль однопалубный, то он потоплен полностью
            if (Location == 0)
            {
                if (x != 0 && y != 0 && x != 9 && y != 9)
                {
                    if ((Field[x + 1, y] == 0 || Field[x + 1, y] == 3) && (Field[x, y + 1] == 0 || Field[x, y + 1] == 3)
                        && (Field[x - 1, y] == 0 || Field[x - 1, y] == 3) && (Field[x, y - 1] == 0 || Field[x, y - 1] == 3))
                    {
                        return true;
                    }
                    else return false;

                }
                else if (x == 0 && y != 0 && y != 9)
                {
                    if ((Field[x + 1, y] == 0 || Field[x + 1, y] == 3) && (Field[x, y + 1] == 0 || Field[x, y + 1] == 3)
                        && (Field[x, y - 1] == 0 || Field[x, y - 1] == 3))
                    {
                        return true;
                    }
                    else return false;
                }

                else if (x != 0 && y == 0 && x != 9)
                {
                    if ((Field[x + 1, y] == 0 || Field[x + 1, y] == 3) && (Field[x, y + 1] == 0 || Field[x, y + 1] == 3)
                        && (Field[x - 1, y] == 0 || Field[x - 1, y] == 3))
                    {
                        return true;
                    }
                    else return false;
                }

                if (y != 0 && x == 9 && y != 9)
                {
                    if ((Field[x, y + 1] == 0 || Field[x, y + 1] == 3) && (Field[x - 1, y] == 0 || Field[x - 1, y] == 3)
                        && (Field[x, y - 1] == 0 || Field[x, y - 1] == 3))
                    {
                        return true;
                    }
                    else return false;

                }
                if (x != 0 && x != 9 && y == 9)
                {
                    if ((Field[x + 1, y] == 0 || Field[x + 1, y] == 3) && (Field[x - 1, y] == 0 || Field[x - 1, y] == 3)
                        && (Field[x, y - 1] == 0 || Field[x, y - 1] == 3))
                    {
                        return true;
                    }
                    else return false;

                }
                if (x == 0 && y == 0)
                {
                    if ((Field[x + 1, y] == 0 || Field[x + 1, y] == 3) && (Field[x, y + 1] == 0 || Field[x, y + 1] == 3))
                    {
                        return true;
                    }
                    else return false;
                }
                if (x == 9 && y == 9)
                {
                    if ((Field[x - 1, y] == 0 || Field[x - 1, y] == 3) && (Field[x, y - 1] == 0 || Field[x, y - 1] == 3))
                    {
                        return true;
                    }
                    else return false;
                }
                if (x == 0 && y == 9)
                {
                    if ((Field[x + 1, y] == 0 || Field[x + 1, y] == 3) && (Field[x, y - 1] == 0 || Field[x, y - 1] == 3))
                    {
                        return true;
                    }
                    else return false;
                }
                if (y == 0 && x == 9)
                {
                    if ((Field[x, y + 1] == 0 || Field[x, y + 1] == 3) && (Field[x - 1, y] == 0 || Field[x - 1, y] == 3))
                    {
                        return true;
                    }
                    else return false;
                }
            }
            else if (Location == 1)
            {

                if (DeckGoDown == CheckDeck(Field, x, y, Location)) return true;
                else return false;


            }
            else if (Location == 2)
            {
                if (DeckGoDown == CheckDeck(Field, x, y, Location)) return true;
                else return false;

            }
            return false;
        }



        //Подсчет количества палуб в корабле
        private int CheckDeck(int[,] Field, int x, int y, int Location)
        {
            int chek = 0;
            if (Location == 1)
            {
                int i = x;
                chek = 0;
                while ((Field[i, y] == 2 || Field[i, y] == 1) && i < 10)
                {
                    i++;

                    if (i == 10) break;
                }
                i--;
                while ((Field[i, y] == 2 || Field[i, y] == 1) && i >= 0)
                {
                    chek++;
                    if (i == 0) break;
                    i--;

                }
            }
            else if (Location == 2)
            {

                int i = y;
                chek = 0;
                while ((Field[x, i] == 2 || Field[x, i] == 1) && i < 10)
                {
                    i++;
                    if (i == 10) break;
                }
                i--;
                while ((Field[x, i] == 2 || Field[x, i] == 1) && i >= 0)
                {
                    chek++;
                    if (i == 0) break;
                    i--;

                }

            }
            return chek;
        }

        //Подсчет количества потопленных палуб
        private int DeGoDown(int[,] Field, int x, int y, int Location)
        {
            int chek = 0;
            if (Location == 1)
            {
                int i = x;
                chek = 0;
                while ((Field[i, y] == 2 || Field[i, y] == 1) && i < 10)
                {
                    i++;

                    if (i == 10) break;
                }
                i--;
                while ((Field[i, y] == 2 || Field[i, y] == 1) && i >= 0)
                {
                    if (Field[i, y] == 2) chek++;
                    if (i == 0) break;
                    i--;

                }
            }
            else if (Location == 2)
            {

                int i = y;
                chek = 0;
                while ((Field[x, i] == 2 || Field[x, i] == 1) && i < 10)
                {
                    i++;
                    if (i == 10) break;
                }
                i--;
                while ((Field[x, i] == 2 || Field[x, i] == 1) && i >= 0)
                {
                    if (Field[x, i] == 2) chek++;
                    if (i == 0) break;
                    i--;

                }

            }
            return chek;
        }

        private void CheckBotShipLokal()
        {
            if (BotY == 0 && BotX != 0 && BotX != 9)
            {
                if (BotField[BotX + 1, BotY] == 2 || BotField[BotX - 1, BotY] == 2) BotLocation = 1;
                if (BotField[BotX, BotY + 1] == 2) BotLocation = 2;
            }
            else if (BotY != 0 && BotY != 9 && BotX != 0 && BotX != 9)
            {
                if (BotField[BotX + 1, BotY] == 2 || BotField[BotX - 1, BotY] == 2) BotLocation = 1;
                if (BotField[BotX, BotY + 1] == 2 || BotField[BotX, BotY - 1] == 2) BotLocation = 2;
            }
            else if (BotY == 9 && BotX != 0 && BotX != 9)
            {
                if (BotField[BotX + 1, BotY] == 2 || BotField[BotX - 1, BotY] == 2) BotLocation = 1;
                if (BotField[BotX, BotY - 1] == 2) BotLocation = 2;
            }
            else if (BotY != 0 && BotY != 9 && BotX == 0)
            {
                if (BotField[BotX + 1, BotY] == 2) BotLocation = 1;
                if (BotField[BotX, BotY + 1] == 2 || BotField[BotX, BotY - 1] == 2) BotLocation = 2;
            }
            else if (BotY != 0 && BotY != 9 && BotX == 9)
            {
                if (BotField[BotX - 1, BotY] == 2) BotLocation = 1;
                if (BotField[BotX, BotY + 1] == 2 || BotField[BotX, BotY - 1] == 2) BotLocation = 2;
            }
        }

        //Попадание
        private void UserNoMiss(int x, int y)
        {
            if (UserMove)
            {
                if (BotField[x, y] == 1)
                {
                    BotField[x, y] = 2;
                    CheckBotShipLokal();
                    BotDeckGoDown = DeGoDown(BotField, BotX, BotY, BotLocation);
                    ShipArrangement.Arrangement(dataGridViewBot, BotField, x, y);
                    if (GoDown(BotField, x, y, BotLocation, BotDeckGoDown))
                    {

                        if (Sound.OtherS == true)
                        {
                            DGoDown.Play();
                        }

                        IfGoDown();

                    }
                    else
                    {

                        str += "Попадание! Право хода остается за вами" + "\n";
                        ChatInp.Text = str;
                        ChatInp.SelectionStart = ChatInp.TextLength;
                    }
                }
                BotDeck--;
            }

            if (Sound.OtherS == true)
            {
                NoMiss.Play();
            }

        }

        private void dataGridViewBot_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGrid = (DataGridView)sender;
            DataGridViewSelectedCellCollection dataGridCellCollection = dataGrid.SelectedCells;
            DataGridViewCell dataGridViewCell = (DataGridViewCell)dataGridCellCollection[0];
            BotY = dataGridViewCell.RowIndex;
            BotX = dataGridViewCell.ColumnIndex - 1;
            if (BotX != -1) 
            { 
            dataGridViewBot.CurrentCell.Selected = false;
            Chat(BotX, BotY);
            UserShoot(BotX, BotY);
            UserShot++;
            ShotAndDeckLabel();
        }
    }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ComputerShoot();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //
        private void Chat(int x, int y)
        {
            if  (BotMove)
            {
                str += $"Ход соперника: {Convert.ToString(y+1)} {Book(x)}"+"\n";
                ChatInp.Text = str;
                ChatInp.SelectionStart = ChatInp.TextLength;
            }
            else if (UserMove&&BotField[x,y]!=3&& BotField[x, y] !=2)
            {
                str += $"Ваш ход: {Convert.ToString(y+1)} {Book(x)}"+"\n";
                ChatInp.Text = str;
                ChatInp.SelectionStart = ChatInp.TextLength;
            }
        }

        public string Book(int x)
        {
            if (x == 0) return "A";
            if (x == 1) return "Б";
            if (x == 2) return "В";
            if (x == 3) return "Г";
            if (x == 4) return "Д";
            if (x == 5) return "Е";
            if (x == 6) return "Ж";
            if (x == 7) return "З";
            if (x == 8) return "И";
            if (x == 9) return "К";
            return "";

        }


        private void Rating_Click(object sender, EventArgs e)
        {
            Table table = new Table();
            table.Show();
            this.Hide();

        }

        //save
        public string[,] Result = new string[2, 10];
        private void SaveResult()
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            Sound s = new Sound();
            s.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }

}

    


