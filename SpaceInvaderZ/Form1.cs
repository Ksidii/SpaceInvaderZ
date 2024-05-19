using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SpaceInvaderZ
{
    public partial class Form1 : Form
    {
        private int x, y, w, h;  // Zmienne do przechowywania pozycji i rozmiaru statku
        private int bulletWidth, bulletHeight;  // Zmienne do przechowywania rozmiaru pocisków
        private Rectangle Kwadrat;  // Prostokąt reprezentujący statek
        private List<Rectangle> bullets;  // Lista prostokątów reprezentujących pociski
        private List<int> bulletSpeeds;  // Lista prędkości pocisków
        private Image shipImage;  // Obraz statku
        private int bulletSpeed = -30;  // Prędkość pocisków
        private List<Rectangle> enemies;  // Lista prostokątów reprezentujących wrogów
        private Image enemyImage;  // Obraz wroga
        private int enemyWidth = 50;  // Szerokość wroga
        private int enemyHeight = 50;  // Wysokość wroga
        private int enemyRows = 3;  // Liczba rzędów wrogów
        private int enemiesPerRow = 12;  // Liczba wrogów w rzędzie

        public Form1()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            w = 25;  // Szerokość statku
            h = 25;  // Wysokość statku
            x = 100;  // Początkowa pozycja x
            bulletWidth = 5;  // Szerokość pocisków
            bulletHeight = 10;  // Wysokość pocisków
            Init_ShipPosition();  // Inicjalizacja pozycji statku
            Kwadrat = new Rectangle(x - w, y - h, 2 * w, 2 * h);  // Ustawienie prostokąta statku
            Init_Bullets();  // Inicjalizacja pocisków
            Init_Enemies();  // Inicjalizacja wrogów
            try
            {
                shipImage = Image.FromFile("spacesShip.png", true);  // Wczytanie obrazu statku
                enemyImage = Image.FromFile("enemy.png", true);  // Wczytanie obrazu wroga
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("Nie ma pliku");  // Wyświetlenie komunikatu o braku pliku
            }
            this.FormClosed += new FormClosedEventHandler(Form1_FormClosed);
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // Zamknij aplikację po zamknięciu okna gry
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (gameEnded)
            {
                Application.Exit(); // Zamknij aplikację, jeśli gra została ukończona
            }
        }

        private void Init_ShipPosition()
        {
            // Ustawienie pozycji y statku na podstawie wysokości panelu poleGry1
            y = poleGry1.ClientSize.Height - h * 2;
            Kwadrat.Y = y - h;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!gameEnded) // Dodaj warunek sprawdzający, czy gra nie została zakończona
            {
                UpdateBulletPositions();  // Aktualizacja pozycji pocisków
                CheckCollisions();  // Sprawdzenie kolizji
                poleGry1.Refresh();  // Odświeżenie panelu gry
            }
        }


        private void poleGry1_MouseMove(object sender, MouseEventArgs e)
        {
            x = e.X - w;  // Aktualizacja pozycji x statku na podstawie pozycji myszy
            poleGry1.Refresh();  // Odświeżenie panelu gry
        }

        private void poleGry1_MouseDown(object sender, MouseEventArgs e)
        {
            // Dodanie nowego pocisku do listy pocisków
            bullets.Add(new Rectangle(x + w / 2 - bulletWidth / 2, y - h, bulletWidth, bulletHeight));
            bulletSpeeds.Add(bulletSpeed);  // Dodanie prędkości dla nowego pocisku
        }

        private void poleGry1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            x = Math.Max(w, Math.Min(poleGry1.ClientSize.Width - 2 * w, x));  // Ograniczenie ruchu statku do obszaru panelu gry
            setKwadratX(x);  // Aktualizacja prostokąta statku
            if (shipImage != null)
            {
                g.DrawImage(shipImage, Kwadrat);  // Rysowanie obrazu statku
            }
            BulletRefresh(g);  // Odświeżenie pocisków
            EnemyRefresh(g);  // Rysowanie wrogów
        }

        private void setKwadratX(int x)
        {
            Kwadrat.X = x - w;  // Aktualizacja pozycji x prostokąta statku
            Kwadrat.Y = y - h;  // Aktualizacja pozycji y prostokąta statku
            Kwadrat.Width = 2 * w;  // Ustawienie szerokości prostokąta statku
            Kwadrat.Height = 2 * h;  // Ustawienie wysokości prostokąta statku
        }

        private void Init_Bullets()
        {
            bullets = new List<Rectangle>();  // Inicjalizacja listy prostokątów reprezentujących pociski
            bulletSpeeds = new List<int>();  // Inicjalizacja listy prędkości pocisków
        }

        private void UpdateBulletPositions()
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i] = new Rectangle(bullets[i].X, bullets[i].Y + bulletSpeeds[i], bullets[i].Width, bullets[i].Height);  // Aktualizacja pozycji pocisku
                if (bullets[i].Y <= 0)
                {
                    bullets.RemoveAt(i);  // Usunięcie pocisku, który wyszedł poza górną krawędź
                    bulletSpeeds.RemoveAt(i);  // Usunięcie prędkości pocisku
                    i--;  // Zmniejszenie indeksu, aby uwzględnić usunięcie elementu
                }
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            // Resetuj flagę gameEnded
            gameEnded = false;

            // Resetuj pozycję statku
            x = 100;
            Init_ShipPosition();

            // Usuń wszystkie pociski
            bullets.Clear();
            bulletSpeeds.Clear();

            // Przywróć wrogów
            Init_Enemies();

            // Odśwież panel gry
            poleGry1.Refresh();
        }

        private void BulletRefresh(Graphics g)
        {
            SolidBrush brush = new SolidBrush(Color.Cyan);
            foreach (var bullet in bullets)
            {
                g.FillRectangle(brush, bullet);  // Rysowanie pocisków
                g.DrawRectangle(new Pen(brush), bullet);  // Rysowanie krawędzi pocisków
            }
        }

        private void Init_Enemies()
        {
            enemies = new List<Rectangle>();  // Inicjalizacja listy prostokątów reprezentujących wrogów
            int panelWidth = poleGry1.ClientSize.Width;  // Szerokość panelu gry
            int totalEnemyWidth = enemiesPerRow * enemyWidth + (enemiesPerRow - 1) * 10;  // Szerokość wszystkich wrogów i odstępów
            int startX = (panelWidth - totalEnemyWidth) / 2;  // Początkowa pozycja x, aby wyśrodkować wrogów

            for (int row = 0; row < enemyRows; row++)
            {
                for (int col = 0; col < enemiesPerRow; col++)
                {
                    int xPos = startX + col * (enemyWidth + 10);  // Pozycja x wroga z odstępem 10 pikseli
                    int yPos = row * (enemyHeight + 10);  // Pozycja y wroga z odstępem 10 pikseli
                    enemies.Add(new Rectangle(xPos, yPos, enemyWidth, enemyHeight));  // Dodanie nowego wroga do listy
                }
            }
        }

        private void EnemyRefresh(Graphics g)
        {
            if (enemyImage != null)
            {
                foreach (var enemy in enemies)
                {
                    g.DrawImage(enemyImage, enemy);  // Rysowanie obrazu wroga
                }
            }
        }

        private bool gameEnded = false;

        private void CheckCollisions()
        {
            // Sprawdzenie kolizji dla każdego pocisku z każdym wrogiem
            List<int> bulletsToRemove = new List<int>();
            List<int> enemiesToRemove = new List<int>();

            for (int i = 0; i < bullets.Count; i++)
            {
                for (int j = 0; j < enemies.Count; j++)
                {
                    if (bullets[i].IntersectsWith(enemies[j]))
                    {
                        // Jeśli doszło do kolizji, zapisz indeksy do usunięcia
                        bulletsToRemove.Add(i);
                        enemiesToRemove.Add(j);
                        // Odtwórz dźwięk po zderzeniu
                        try
                        {
                            System.Media.SoundPlayer player = new System.Media.SoundPlayer("death.wav");
                            player.Play();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Błąd odtwarzania dźwięku: " + ex.Message);
                        }
                    }
                }
            }

            // Usuń elementy poza pętlą, aby uniknąć problemów z indeksami
            foreach (int index in bulletsToRemove.OrderByDescending(x => x))
            {
                bullets.RemoveAt(index);
                bulletSpeeds.RemoveAt(index);
            }

            foreach (int index in enemiesToRemove.OrderByDescending(x => x))
            {
                enemies.RemoveAt(index);
            }

            // Sprawdź, czy nie pozostały już żadne wrogowie
            if (enemies.Count == 0 && !gameEnded)
            {
                // Jeśli nie ma już wrogów, wyświetl komunikat o ukończeniu gry
                gameEnded = true;
                MessageBox.Show("Gratulacje! Gra ukończona!", "Koniec gry", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
