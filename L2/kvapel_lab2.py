# Квапель, М8О-303Б-19
# ЛР2: Каркасная визуализация выпуклого многогранника. Удаление невидимых линий.
# Разработать формат представления многогранника и процедуру его каркасной отрисовки в ортографической и изометрической проекциях.
# Обеспечить удаление невидимых линий и возможность пространственных поворотов и масштабирования многогранника.
# Обеспечить автоматическое центрирование и изменение размеров изображения при изменении размеров окна.
# Вариант-4: Клин.


import numpy as np
import matplotlib.pyplot as plt
from mpl_toolkits.mplot3d.art3d import Poly3DCollection
from matplotlib.widgets import Button


def TransparentON(event):
    axis.add_collection3d(Poly3DCollection(
        frame, facecolors=[1, 0.4, 0.3], alpha=0.7, linewidths=1, edgecolors='black'))


def TransparentOFF(event):
    axis.add_collection3d(Poly3DCollection(
        frame, facecolors=[1, 0.4, 0.3], alpha=1, linewidths=1, edgecolors='black'))


f = plt.figure()
axis = f.add_subplot(111, projection='3d')

buttonON = f.add_subplot(863)
btnON = Button(buttonON, 'ВКЛ')
btnON.on_clicked(TransparentON)

buttonOFF = f.add_subplot(864)
btnOFF = Button(buttonOFF, 'ВЫКЛ')
btnOFF.on_clicked(TransparentOFF)

x = 10
y = 10
z = 20

p = np.array([
    [x / 2, -y / 2, -z / 2],
    [-x / 2, -y / 2, -z / 2],
    [-x / 2, y / 2, -z / 2],
    [x / 2, y / 2, -z / 2],
    [0, -y / 2, z / 2],
    [0, y / 2, z / 2]
])
frame = [
    [p[0], p[4], p[1]],
    [p[3], p[5], p[2]],
    [p[0], p[1], p[2], p[3]],
    [p[1], p[4], p[5], p[2]],
    [p[0], p[4], p[5], p[3]]
]

axis.scatter3D(p[:, 0], p[:, 1], p[:, 2], color='black')

axis.add_collection3d(Poly3DCollection(
    frame, facecolors=[1, 0.4, 0.3], alpha=0.7, linewidths=1, edgecolors='black'))

axis.set_xlabel('X', fontsize=15, color='blue')
axis.set_ylabel('Y', fontsize=15, color='blue')
axis.set_zlabel('Z', fontsize=15, color='blue')
axis.set_title('Квапель, Вариант-4: \"Клин\"\nПрозрачность')

plt.show()
