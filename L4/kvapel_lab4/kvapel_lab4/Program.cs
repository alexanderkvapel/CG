﻿// Квапель, М8О-303Б-19
// ЛР4: Создать графическое приложение с использованием OpenGL.
// Используя результаты Л.Р.№3, изобразить заданное тело (то же, что и в л.р. №3) с использованием средств OpenGL 2.1.
// Использовать буфер вершин. Точность аппроксимации тела задается пользователем.
// Обеспечить возможность вращения и масштабирования многогранника и удаление невидимых линий и поверхностей.
// Реализовать простую модель освещения на GLSL.
// Параметры освещения и отражающие свойства материала задаются пользователем в диалоговом режиме.
// Вариант-4: Полушарие.

namespace kvapel_lab4
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Plot plot = new Plot(600, 600);

            plot.Start();
        }
    }
}