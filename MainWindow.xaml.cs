using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace laba_9
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Логика для LogicAnd
        private void CheckConditions_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool free = freeCheckBox.IsChecked ?? false;
                bool stair = stairCheckBox.IsChecked ?? false;

                LogicAnd logic = new LogicAnd(free, stair);

                bool canHire = logic.CanHireEmployees(free, stair);
                bool canGrow = logic.CanGrowStairs(free, stair);
                bool hasFree = logic.CanGetFree(free, stair);

                conditionsResult.Text = $"Можно нанимать: {(canHire ? "Да" : "Нет")}\n" +
                                     $"Карьерный рост: {(canGrow ? "Да" : "Нет")}\n" +
                                     $"Свободные места: {(hasFree ? "Да" : "Нет")}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void InvertLogic_Click(object sender, RoutedEventArgs e)
        {
            bool free = freeCheckBox.IsChecked ?? false;
            bool stair = stairCheckBox.IsChecked ?? false;

            LogicAnd logic = new LogicAnd(free, stair);
            bool result = !logic;

            conditionsResult.Text = $"Инвертированный результат: {(result ? "Да" : "Нет")}";
        }

        private void ShowAsString_Click(object sender, RoutedEventArgs e)
        {
            bool free = freeCheckBox.IsChecked ?? false;
            bool stair = stairCheckBox.IsChecked ?? false;

            LogicAnd logic = new LogicAnd(free, stair);
            logicAndInfo.Text = $"Текущее состояние: {logic}";
        }

        // Логика для Triangle
        private void CheckTriangles_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Проверка первого треугольника
                double a1 = double.Parse(sideA1.Text);
                double b1 = double.Parse(sideB1.Text);
                double c1 = double.Parse(sideC1.Text);
                Triangle triangle1 = new Triangle(a1, b1, c1);
                bool exists1 = (bool)triangle1;
                triangle1Exists.Text = $"Треугольник 1: {(exists1 ? "существует" : "не существует")}";

                // Проверка второго треугольника
                double a2 = double.Parse(sideA2.Text);
                double b2 = double.Parse(sideB2.Text);
                double c2 = double.Parse(sideC2.Text);
                Triangle triangle2 = new Triangle(a2, b2, c2);
                bool exists2 = (bool)triangle2;
                triangle2Exists.Text = $"Треугольник 2: {(exists2 ? "существует" : "не существует")}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
        private void CompareAreas_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double a1 = double.Parse(sideA1.Text);
                double b1 = double.Parse(sideB1.Text);
                double c1 = double.Parse(sideC1.Text);
                Triangle triangle1 = new Triangle(a1, b1, c1);

                double a2 = double.Parse(sideA2.Text);
                double b2 = double.Parse(sideB2.Text);
                double c2 = double.Parse(sideC2.Text);
                Triangle triangle2 = new Triangle(a2, b2, c2);

                if (!(bool)triangle1 || !(bool)triangle2)
                {
                    areasComparison.Text = "Один из треугольников не существует!";
                    return;
                }

                double area1 = !triangle1;
                double area2 = !triangle2;

                string result;
                if (Math.Abs(area1 - area2) < 0.001)
                    result = "Площади треугольников равны";
                else if (area1 > area2)
                    result = "Площадь первого треугольника больше";
                else
                    result = "Площадь второго треугольника больше";

                areasComparison.Text = $"Площадь 1: {area1:F2}\nПлощадь 2: {area2:F2}\n{result}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}
