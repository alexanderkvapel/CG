# Квапель, М8О-303Б-19
# ЛР1: Построение изображений 2D-кривых.
# Написать и отладить программу, строящую изображение заданной замечательной кривой.
# Обеспечить автоматическое масштабирование и центрирование кривой при изменении размеров окна.
# Вариант-9: ρ=aφ, 0≤φ≤B, ρ, φ - полярные координаты, a, B - константы, которая выбирается пользователем (a>0)

import numpy as np
import pylab as pb


def PlotGraphic(axis, a, B):
    d = 0.01
    phi = 0

    X = []
    Y = []

    phi = phi + d
    p = a * phi
    Xt = p * np.cos(phi)
    Yt = p * np.sin(phi)
    X.append(Xt)
    Y.append(Yt)

    while phi < B:
        phi = phi + d
        p = a * phi
        Xt = p * np.cos(phi)
        Yt = p * np.sin(phi)
        X.append(Xt)
        Y.append(Yt)
        axis.plot(X, Y, color='black')
        X.pop(0)
        Y.pop(0)

    pb.draw()


print('Архимедова спираль: ρ=aφ, 0≤φ≤B, a>0')
a = int(input('a = '))
B = int(input('B = '))

f, axis = pb.subplots()

axis.grid()
axis.set_xlabel('X', fontsize=15, color='blue')
axis.set_ylabel('Y', fontsize=15, color='blue')
axis.set_title('Архимедова спираль: ρ = aφ, 0≤φ≤' + str(B))
axis.axhline(0, color='blue')
axis.axvline(0, color='blue')

PlotGraphic(axis, a, B)
pb.show()
