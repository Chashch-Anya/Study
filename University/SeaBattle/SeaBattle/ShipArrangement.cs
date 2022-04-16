using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaBattle
{
    public partial class ShipArrangement : Form
    {
        public ShipArrangement()
        {
            InitializeComponent();
        }

        //Объявление переменных
        public static int Location = 1; //Расположение корабля: вертикальное или горизонтальное
        public static int Ships4Deck = 1; // Количество 4х палубных
        public static int Ships3Deck = 2; // Количество 3х палубных
        public static int Ships2Deck = 3; // Количество 2х палубных
        public static int Ships1Deck = 4; // Количество 1х палубных
        public static int Deck;
        public static int x, y; //координаты клетки
        public bool CanPosition;
        public static string[] abc = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
        



        //Количество оставшихся нерасположенных кораблей
        private void updateStatusLabels()
        {
            Deck4Status.Text = Ships4Deck.ToString();
            Deck3Status.Text = Ships3Deck.ToString();
            Deck2Status.Text = Ships2Deck.ToString();
            Deck1Status.Text = Ships1Deck.ToString();
        }

        //Начать игру(пр полной расстановке кораблей). Закрытие формы 
        private void Start_Click(object sender, EventArgs e)
        {
            Main.Name = comboBox1.Text + " " +  textBox1.Text;
            Main.Start = true;
            CountShipClear();
            RandomShips(Main.BotField);
            Main F0 = new Main();
            F0.Show();
            this.Hide();

        }

      

        private void Random_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CountShipClear();
            ClearField(Main.UserField);
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    Arrangement(dataGridView1, Main.UserField, i, j);
            RandomShips(Main.UserField);
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    Arrangement(dataGridView1, Main.UserField, i, j)
                        ; this.Cursor = Cursors.Default;
            dataGridView1.Enabled = false;
            ToStart();
        }

        //Сброс расстановки кораблей
        private void ClearShipFieldUser()
        {
            CountShipClear();
            ClearField(Main.UserField);
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    Arrangement(dataGridView1, Main.UserField, i, j);
        }

        //Сброс количества расставленных кораблей
        public static void CountShipClear()
        {
            Ships4Deck = 1;
            Ships3Deck = 2;
            Ships2Deck = 3;
            Ships1Deck = 4;
        }

        //Очистка массива(обнуление)
        public void ClearField(int[,] Field)
        {
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    Field[i, j] = 0;
        }

        //Проверка на возможность установки корабля
        public static bool CheckShip(int Deck, int[,] Field, int x, int y, int Location)
        {
            int chek = 0;
            if (x != 0 && y != 0 && x != 9 && y != 9)
            {
                if (Location == 1) //горизонтальное
                {
                    if (x + Deck - 1 < 9)
                    {
                        for (int i = x - 1; i <= x + Deck; i++)
                            for (int j = y - 1; j <= y + 1; j++)
                                if (Field[i, j] == 0) chek++;

                        if (chek == (Deck + 2) * 3) return true;
                    }
                    else if (x + Deck - 1 == 9)
                    {
                        for (int i = x - 1; i <= x + Deck - 1; i++)
                            for (int j = y-1; j <= y + 1; j++)
                                if (Field[i, j] == 0) chek++;

                        if (chek == (Deck + 1) * 3) return true;
                    }
                }
                else if (Location == 2) //вертикальное
                {
                    if (y + Deck - 1 < 9)
                    {
                        for (int i = x - 1; i <= x + 1; i++)
                            for (int j = y - 1; j <= y + Deck; j++)
                                if (Field[i, j] == 0) chek++;

                        if (chek == (Deck + 2) * 3) return true;
                    }
                    else if (y + Deck - 1 == 9)
                    {
                        for (int i = x - 1; i <= x + 1; i++)
                            for (int j = y - 1; j <= y + Deck - 1; j++)
                                if (Field[i, j] == 0) chek++;

                        if (chek == (Deck + 1) * 3) return true;
                    }
                }

            }

            if (x == 0 && y != 0 && y != 9)
            {
                if (Location == 1) //горизонтальное
                {
                    for (int i = x; i <= x + Deck; i++)
                        for (int j = y - 1; j <= y + 1; j++)
                            if (Field[i, j] == 0) chek++;

                    if (chek == (Deck + 2) * 3 - 3) return true;
                }
                else if (Location == 2) //вертикальное
                {
                    if (y + Deck - 1 < 9)
                    {
                        for (int i = x; i <= x + 1; i++)
                            for (int j = y - 1; j <= y + Deck; j++)
                                if (Field[i, j] == 0) chek++;

                        if (chek == (Deck + 2) * 2) return true;
                    }
                    else if (y + Deck - 1 == 9)
                    {
                        for (int i = x; i <= x + 1; i++)
                            for (int j = y - 1; j <= y + Deck - 1; j++)
                                if (Field[i, j] == 0) chek++;

                        if (chek == (Deck + 1) * 2) return true;
                    }
                }

            }

            if (x != 0 && y == 0 && x!=9)
            {
                if (Location == 1) //горизонтальное
                {
                    if (x + Deck - 1 < 9)
                    {
                        for (int i = x - 1; i <= x + Deck; i++)
                            for (int j = y; j <= y + 1; j++)
                                if (Field[i, j] == 0) chek++;

                        if (chek == (Deck + 2) * 2) return true;
                    }
                    else if (x + Deck - 1 == 9)
                    {
                        for (int i = x - 1; i <= x + Deck - 1; i++)
                            for (int j = y; j <= y + 1; j++)
                                if (Field[i, j] == 0) chek++;

                        if (chek == (Deck + 1) * 2) return true;
                    }
                }
                else if (Location == 2) //вертикальное
                {
                    for (int i = x - 1; i <= x + 1; i++)
                        for (int j = y; j <= y + Deck; j++)
                            if (Field[i, j] == 0) chek++;

                    if (chek == (Deck + 1) * 3) return true;

                }
            }

            if (x == 9 )//
            {
                if (Location == 1) //горизонтальное
                {
                    if(y==0)
                    { 
                        for (int i = x - 1; i <= x ; i++)
                            for (int j = y ; j <= y + 1; j++)
                                if (Field[i, j] == 0) chek++;

                        if (chek == (Deck + 1) * 2) return true;
                    }
                    else if (y==9)
                    {
                        for (int i = x - 1; i <= x; i++)
                            for (int j = y - 1; j <= y; j++)
                                if (Field[i, j] == 0) chek++;

                        if (chek == (Deck + 1) * 2) return true;
                    }
                    else
                    {
                        for (int i = x - 1; i <= x; i++)
                            for (int j = y - 1; j <= y+1; j++)
                                if (Field[i, j] == 0) chek++;

                        if (chek == (Deck + 1) * 3) return true;
                    }
                }
                else if (Location == 2) //вертикальное
                {
                    if (y==0)
                    {
                        for(int i = x - 1; i <= x; i++)
                            for (int j = y; j <= y + Deck; j++)
                            if (Field[i, j] == 0) chek++;

                        if (chek == (Deck+ 1) * 2) return true;
                    }
                    else
                    if (y + Deck - 1 < 9)
                    {
                        for (int i = x-1; i <= x; i++)
                            for (int j = y - 1; j <= y + Deck; j++)
                                if (Field[i, j] == 0) chek++;

                        if (chek == (Deck + 2) * 2) return true;
                    }
                    else if (y + Deck - 1 == 9)
                    {
                        for (int i = x-1; i <= x; i++)
                            for (int j = y - 1; j <= y + Deck - 1; j++)
                                if (Field[i, j] == 0) chek++;

                        if (chek == (Deck + 1) * 2) return true;
                    }
                }
            }
            if (x == 0 && y == 0)
            {
                if (Location == 1) //горизонтальное
                {
                    for (int i = x; i <= x + Deck; i++)
                        for (int j = y; j <= y + 1; j++)
                            if (Field[i, j] == 0) chek++;
                }
                else if (Location == 2) //вертикальное
                {
                    for (int i = x; i <= x + 1; i++)
                        for (int j = y; j <= y + Deck; j++)
                            if (Field[i, j] == 0) chek++;
                }

                if (chek == (Deck + 1) * 2) return true;
            }

            if (y == 9 && x==0)
            {
                if (Location == 1) //горизонтальное
                {
                    for (int i = x; i <= x + Deck; i++)
                        for (int j = y - 1; j <= y ; j++)
                            if (Field[i, j] == 0) chek++;
                    if (chek == (Deck + 1) * 2) return true;

                }
                else if (Location == 2) //вертикальное
                {
                    if (Deck == 1) return true;
                    else return false;
                }
              
            }

            if (y == 9 && x != 0)
            {
                if (Location == 1) //горизонтальное
                {
                    if (x + Deck - 1 < 9)
                    {
                        for (int i = x - 1; i <= x + Deck; i++)
                            for (int j = y-1; j <= y; j++)
                                if (Field[i, j] == 0) chek++;

                        if (chek == (Deck + 2) * 2) return true;
                    }
                    else if (x + Deck - 1 == 9)
                    {
                        for (int i = x - 1; i <= x + Deck - 1; i++)
                            for (int j = y-1; j <= y ; j++)
                                if (Field[i, j] == 0) chek++;

                        if (chek == (Deck + 1) * 2) return true;
                    }

                }
                else if (Location == 2) //вертикальное
                {
                    if (Deck == 1) return true;
                    else return false;
                }

            }
            return false;
        }

        //Случайное
        public static void RandomShips(int[,] Field)
        {
            Random rnd = new Random();
            int x, y;
            while (Ships4Deck != 0)
            {
                x = rnd.Next(0, 9);//столбец
                y = rnd.Next(0, 9);//строка
                Location = rnd.Next(1, 3);
                Deck = 4;
                switch (Location)
                {
                    case 1:// горизонтальное
                        if (x > 6)
                        {
                            x = rnd.Next(0, 9);//столбец
                            y = rnd.Next(0, 9);//строка
                            Location = rnd.Next(1, 3);
                        }
                        else if (y >= 0 && y <= 9 && x >= 0 && x <= 6 && CheckShip(Deck, Field, x, y, Location))
                        {
                            for (int i = x; i < x + 4; i++)
                            {
                                Field[i, y] = 1;
                            }
                            Ships4Deck--;
                        }
                        else
                        {
                            x = rnd.Next(0, 9);//столбец
                            y = rnd.Next(0, 9);//строка
                            Location = rnd.Next(1, 3);
                        }
                        break;

                    case 2://вертикальное
                        if (y > 6)
                        {
                            x = rnd.Next(0, 9);//столбец
                            y = rnd.Next(0, 9);//строка
                            Location = rnd.Next(1, 3);
                        }
                        else if (x >= 0 && x <= 9 && y >= 0 && y <= 6 && CheckShip(Deck, Field, x, y, Location))
                        {
                            for (int i = y; i < y + 4; i++)
                            {
                                Field[x, i] = 1;
                            }
                            Ships4Deck--;

                        }
                        else
                        {
                            x = rnd.Next(0, 9);//столбец
                            y = rnd.Next(0, 9);//строка
                            Location = rnd.Next(1, 3);
                        }

                        break;
                }
            }

            while (Ships3Deck != 0)
            {
                x = rnd.Next(0, 9);//столбец
                y = rnd.Next(0, 9);//строка
                Location = rnd.Next(1, 3);
                Deck = 3;
                switch (Location)
                {
                    case 1:// горизонтальное
                        if (x > 7)
                        {
                            x = rnd.Next(0, 9);//столбец
                            y = rnd.Next(0, 9);//строка
                            Location = rnd.Next(1, 3);
                        }
                        else if (y >= 0 && y <= 9 && x >= 0 && x <= 7 && CheckShip(Deck, Field, x, y, Location))
                        {
                            for (int i = x; i < x + 3; i++)
                            {
                                Field[i, y] = 1;
                            }
                            Ships3Deck--;
                        }
                        else
                        {
                            x = rnd.Next(0, 9);//столбец
                            y = rnd.Next(0, 9);//строка
                            Location = rnd.Next(1, 3);
                        }
                        break;

                    case 2://вертикальное
                        if (y > 7)
                        {
                            x = rnd.Next(0, 9);//столбец
                            y = rnd.Next(0, 9);//строка
                            Location = rnd.Next(1, 3);
                        }
                        else if (x >= 0 && x <= 9 && y >= 0 && y <= 7 && CheckShip(Deck, Field, x, y, Location))
                        {
                            for (int i = y; i < y + 3; i++)
                            {
                                Field[x, i] = 1;
                            }
                            Ships3Deck--;
                        }
                        else
                        {
                            x = rnd.Next(0, 9);//столбец
                            y = rnd.Next(0, 9);//строка
                            Location = rnd.Next(1, 3);
                        }
                        break;
                }

            }

            while (Ships2Deck != 0)
            {
                x = rnd.Next(0, 9);//столбец
                y = rnd.Next(0, 9);//строка
                Location = rnd.Next(1, 3);
                Deck = 2;
                switch (Location)
                {
                    case 1:// горизонтальное
                        if (x > 8)
                        {
                            x = rnd.Next(0, 9);//столбец
                            y = rnd.Next(0, 9);//строка
                            Location = rnd.Next(1, 3);
                        }
                        else if (y >= 0 && y <= 9 && x >= 0 && x <= 8 && CheckShip(Deck, Field, x, y, Location))
                        {
                            for (int i = x; i < x + 2; i++)
                            {
                                Field[i, y] = 1;
                            }
                            Ships2Deck--;

                        }
                        else
                        {
                            x = rnd.Next(0, 9);//столбец
                            y = rnd.Next(0, 9);//строка
                            Location = rnd.Next(1, 3);
                        }
                        break;

                    case 2://вертикальное
                        if (y > 8)
                        {
                            x = rnd.Next(0, 9);//столбец
                            y = rnd.Next(0, 9);//строка
                            Location = rnd.Next(1, 3);
                        }
                        else if (x >= 0 && x <= 9 && y >= 0 && y <= 8 && CheckShip(Deck, Field, x, y, Location))
                        {

                            for (int i = y; i < y + 2; i++)
                            {
                                Field[x, i] = 1;
                            }
                            Ships2Deck--;

                        }
                        else
                        {
                            x = rnd.Next(0, 9);//столбец
                            y = rnd.Next(0, 9);//строка
                            Location = rnd.Next(1, 3);
                        }
                        break;
                }

            }

            while (Ships1Deck != 0)
            {
                x = rnd.Next(0, 9);//столбец
                y = rnd.Next(0, 9);//строка
                Deck = 1;
                if (x > 9)
                {
                    x = rnd.Next(0, 9);//столбец
                    y = rnd.Next(0, 9);//строка
                }
                else if (y >= 0 && y <= 9 && x >= 0 && x <= 9 && CheckShip(Deck, Field, x, y, Location))
                {
                    Field[x, y] = 1;
                    Ships1Deck--;

                }
                else
                {
                    x = rnd.Next(0, 9);//столбец
                    y = rnd.Next(0, 9);//строка
                }
            }
        }

        public static void Arrangement(DataGridView Data, int[,] Field, int i, int j)
        {          
                    switch (Field[i, j])
                    {
                        case 0://пустая клетка
                            Data[i + 1, j].Style.BackColor = System.Drawing.Color.White;
                            break;
                        case 1://палуба 
                            Data[i + 1, j].Style.BackColor = System.Drawing.Color.DarkBlue;
                            break;
                        case 3://зона вокруг корабля
                            Data[i + 1, j].Style.BackColor = System.Drawing.Color.LightBlue;
                            break;
                        case 2://попадание
                            Data[i + 1, j].Style.BackColor = System.Drawing.Color.Red;
                            break;
                    }
        }


        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void ShipAdd(int[,]Field , int x, int y)
        {
            if (Location == 1)
            {
                if (Ships4Deck != 0 && Deck == 4)
                {
                    if (x > 6)
                    {
                        MessageBox.Show("Невозможно расположить корабль");
                    }
                    else if (y >= 0 && y <= 9 && x >= 0 && x <= 6 && CheckShip(Deck, Main.UserField, x, y, Location))
                    {

                        for (int i = x; i < x + 4; i++)
                        {
                            dataGridView1[i + 1, y].Style.BackColor = System.Drawing.Color.DarkBlue;
                            Main.UserField[i, y] = 1;
                        }
                        Ships4Deck--;
                    }
                    else
                    {
                        MessageBox.Show("Невозможно расположить корабль");
                    }
                }
                else if (Ships4Deck == 0 && Deck == 4)
                {
                    MessageBox.Show("Все четырехпалубные корабли уже расположены!");
                }
                else if (Ships3Deck != 0 && Deck == 3)
                {
                    if (x > 7)
                    {
                        MessageBox.Show("Невозможно расположить корабль");
                    }
                    else if (y >= 0 && y <= 9 && x >= 0 && x <= 7 && CheckShip(Deck, Main.UserField, x, y, Location))
                    {
                        for (int i = x; i < x + 3; i++)
                        {
                            dataGridView1[i + 1, y].Style.BackColor = System.Drawing.Color.DarkBlue;

                            Main.UserField[i, y] = 1;

                        }
                        Ships3Deck--;
                    }
                    else
                    {
                        MessageBox.Show("Невозможно расположить корабль");

                    }
                }
                else
                     if (Ships3Deck == 0 && Deck == 3)
                {
                    MessageBox.Show("Все трехпалубные корабли уже расположены!");
                }
                else if (Ships2Deck != 0 && Deck == 2)
                {
                    if (x > 8)
                    {
                        MessageBox.Show("Невозможно расположить корабль");
                    }
                    else if (y >= 0 && y <= 9 && x >= 0 && x <= 8 && CheckShip(Deck, Main.UserField, x, y, Location))
                    {
                        for (int i = x; i < x + 2; i++)
                        {
                            dataGridView1[i + 1, y].Style.BackColor = System.Drawing.Color.DarkBlue;

                            Main.UserField[i, y] = 1;
                        }
                        Ships2Deck--;

                    }
                    else
                    {
                        MessageBox.Show("Невозможно расположить корабль");
                    }
                }
                else if (Ships2Deck == 0 && Deck == 2)
                {
                    MessageBox.Show("Все двухпалубные корабли уже расположены!");
                }
            }
            else if (Location == 2)
            {
                if (Ships4Deck != 0 && Deck == 4)
                {
                    if (y > 6)
                    {
                        MessageBox.Show("Невозможно расположить корабль");

                    }
                    else if (x >= 0 && x <= 9 && y >= 0 && y <= 6 && CheckShip(Deck, Main.UserField, x, y, Location))
                    {
                        for (int i = y; i < y + 4; i++)
                        {
                            dataGridView1[x + 1, i].Style.BackColor = System.Drawing.Color.DarkBlue;

                            Main.UserField[x, i] = 1;
                        }
                        Ships4Deck--;

                    }
                    else
                    {
                        MessageBox.Show("Невозможно расположить корабль");

                    }
                }
                else if (Ships4Deck == 0 && Deck == 4)
                {
                    MessageBox.Show("Все четырехпалубные корабли уже расположены!");
                }
                else if (Ships3Deck != 0 && Deck == 3)
                {
                    if (y > 7)
                    {
                        MessageBox.Show("Невозможно расположить корабль");
                    }
                    else if (x >= 0 && x <= 9 && y >= 0 && y <= 7 && CheckShip(Deck, Main.UserField, x, y, Location))
                    {
                        for (int i = y; i < y + 3; i++)
                        {
                            dataGridView1[x + 1, i].Style.BackColor = System.Drawing.Color.DarkBlue;

                            Main.UserField[x, i] = 1;
                        }
                        Ships3Deck--;
                    }
                    else
                    {
                        MessageBox.Show("Невозможно расположить корабль");

                    }
                }
                else if (Ships3Deck == 0 && Deck == 3)
                {
                    MessageBox.Show("Все трехпалубные корабли уже расположены!");
                }
                else if (Ships2Deck != 0 && Deck == 2)
                {
                    if (y > 8)
                    {
                        MessageBox.Show("Невозможно расположить корабль");

                    }
                    else if (x >= 0 && x <= 9 && y >= 0 && y <= 8 && CheckShip(Deck, Main.UserField, x, y, Location))
                    {

                        for (int i = y; i < y + 2; i++)
                        {
                            dataGridView1[x + 1, i].Style.BackColor = System.Drawing.Color.DarkBlue;

                            Main.UserField[x, i] = 1;
                        }
                        Ships2Deck--;

                    }
                    else
                    {
                        MessageBox.Show("Невозможно расположить корабль");

                    }
                }
                else if (Ships2Deck == 0 && Deck == 2)
                {
                    MessageBox.Show("Все двухпалубные корабли уже расположены!");
                }
            }

            if (Ships1Deck != 0 && Deck == 1)
            {
                if (x > 9)
                {
                    MessageBox.Show("Невозможно расположить корабль");

                }
                else if (y >= 0 && y <= 9 && x >= 0 && x <= 9 && CheckShip(Deck, Main.UserField, x, y, Location))
                {
                    dataGridView1[x + 1, y].Style.BackColor = System.Drawing.Color.DarkBlue;
                    Main.UserField[x, y] = 1;
                    Ships1Deck--;
                }
                else
                { 
                    MessageBox.Show("Невозможно расположить корабль");

                }
            }
            else if (Ships1Deck == 0 && Deck == 1)
            {
                MessageBox.Show("Все однопалубные корабли уже расположены!");
            }           
            updateStatusLabels();
            ToStart();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                Deck = 4;
                radioButton3.Checked = false;
                radioButton2.Checked = false;
                radioButton4.Checked = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                Deck = 3;
                radioButton1.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                Deck = 2;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton4.Checked = false;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                Deck = 1;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
            }
        }

        private void ShipArrangement_Load(object sender, EventArgs e)
        {
            Sound.SoundPlay();
            CountShipClear();
            updateStatusLabels();
            comboBox1.SelectedIndex = 0;
            ClearField(Main.UserField);
            comboBoxLocation.SelectedIndex = 0;
            dataGridView1.RowCount = 10;
            for (int i = 0; i < 10; i++)
                dataGridView1[0, i].Value = abc[i];
            for (int i = 1; i < 11; i++)
                for (int j = 0; j < 10; j++)
                    dataGridView1[i, j].Style.BackColor = System.Drawing.Color.White;
            ToStart();           
        }

        private void ToStart()
        {
            if (Ships4Deck + Ships3Deck + Ships2Deck + Ships1Deck == 0)
            {
                Start.Enabled = true;
            }
            else Start.Enabled = false;
        }

        
        private void Clear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dataGridView1.Enabled = true;
            ClearShipFieldUser();
            updateStatusLabels();
            ToStart();
        }

        //Выбор расположения корабля:вертикальное или горизонтальное
        private void comboBoxLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxLocation.SelectedIndex)
            {
                case 0:
                    Location = 1;//Вертикальное
                    break;
                case 1:
                    Location = 2;// Горизонтальное
                    break;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }

        }

        //событие - нажатие на ячейку (выбор клетки где будет расположен корабль)
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if ((radioButton1.Checked || radioButton2.Checked || radioButton3.Checked || radioButton4.Checked)
                && (comboBoxLocation.SelectedIndex == 1 || comboBoxLocation.SelectedIndex == 0))
            {
                DataGridView dataGrid = (DataGridView)sender;
                DataGridViewSelectedCellCollection dataGridCellCollection = dataGrid.SelectedCells;
                DataGridViewCell dataGridViewCell = (DataGridViewCell)dataGridCellCollection[0];
                y = dataGridViewCell.RowIndex;
                x = dataGridViewCell.ColumnIndex - 1;
                ShipAdd(Main.UserField, x, y);
                dataGridView1.CurrentCell.Selected = false;
                for (int i = 0; i < 10; i++)
                    for (int j = 0; j < 10; j++)
                        Arrangement(dataGridView1, Main.UserField, i, j);

            }
        }


    }
}
