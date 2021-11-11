using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITS.Core.Bridges.Helpers
{
    public static class DefectsHelper
    {
        /// <summary>
        /// Выдаёт описание параметра дефекта по его названию
        /// </summary>
        /// <param name="defectParamName">Название дефекта</param>
        /// <returns></returns>
        public static string GetParamDescription(string defectParamName)
        {
            string description = "";
            switch (defectParamName)
            {
                case "L":
                    description = "Размер поражённой части вдоль пролёта мостового сооружения, м";
                    break;
                case "H":
                    description = "Размер поражённой части по высоте мостового сооружения, м";
                    break;
                case "B":
                    description = "Размер поражённой части поперек мостового сооружения, м";
                    break;
                case "F":
                    description = "Площадь поражённой части, м^2";
                    break;
                case "l":
                    description = "Размер дефекта по длине мостового сооружения, м";
                    break;
                case "dh":
                case "h":
                    description = "Размер дефекта по высоте мостового сооружения, м";
                    break;
                case "b":
                    description = "Размер дефекта поперёк мостового сооружения, м";
                    break;
                case "df":
                case "f":
                    description = "Площадь дефекта, м^2";
                    break;
                case "A":
                    description = "Площадь ослабленной части сечения, м^2 или %";
                    break;
                case "N":
                    description = "Число деталей с одноимёнными дефектами";
                    break;
                case "n":
                    description = "Число дефектов одноимённых на элементе, детали";
                    break;
                case "V":
                    description = "Объём повреждения (дефекта), м^2";
                    break;
                case "T":
                    description = "Глубина дефекта, м";
                    break;
                case "W":
                    description = "Площадь выпучивания элемента (детали), м^2";
                    break;
                case "X":
                    description = "Смещение деталей или элементов вдоль мостового сооружения, м";
                    break;
                case "Y":
                    description = "Смещение деталей или элементов по высоте, м";
                    break;
                case "Z":
                    description = "Смещение деталей или элементов поперёк мостового сооружения, м";
                    break;
                case "ax":
                    description = "Угол поворота в плоскости XY, м";
                    break;
                case "ay":
                    description = "Угол поворота в плоскости YZ, м";
                    break;
                case "az":
                    description = "Угол поворота в плоскости ZX, м";
                    break;
                case "D":
                    description = "Шаг трещин, м";
                    break;
                case "C":
                    description = "Длина трещины, щели, м";
                    break;
                case "6":
                    description = "Величина раскрытия трещин, зазор щели, м";
                    break;
                case "S":
                    description = "Значение характеристики, указанной в ведомости дефектов";
                    break;
                case "Bl":
                    description = "да/нет";
                    break;
                case "L(F)":
                    description = "Размер поражённой части вдоль мостового сооружения, м (Площадь поражённой части, м^2)";
                    break;
                case "F или L":
                    description = "Площадь поражённой части, м^2 или размер поражённой части вдоль мостового сооружения, м";
                    break;
                case "F или l,C":
                    description = "Площадь поражённой части, м^2 или размер дефекта по длине мостового сооружения, м, длина трещины, щели, м";
                    break;
            }
            return description;
        }
    }
}
