using GeoAPI.Geometries;
using ITS.Core.Bridges.Domain;
using ITS.Core.Bridges.Domain.Enums;
using ITS.GIS.MapEntities;
using ITS.GIS.MapEntities.Styles;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using NetTopologySuite.Operation.Buffer;

namespace ITS.MapObjects.BridgesMapObject
{
    /// <summary>
    /// Класс, содержащий всю информацию для отрисовки моста
    /// </summary>
    public class BridgeRenderGeometry
    {
        private static LineStyle startMarkStyle = new LineStyle(Color.Black, 1f, DashStyle.Solid);
        private Bridge _bridge;

        /// <summary>
        /// Осевая мостового сооружения
        /// </summary>
        public IFeature CenterLine { get; set; }
        /// <summary>
        /// Главная геометрия мостового сооружения
        /// </summary>
        public IGeometry MainGeometry { get; protected set; }
        /// <summary>
        /// Стиль главной геометрии мостового сооружения
        /// </summary>
        public AreaStyle MainGeometryStyle { get; protected set; }
        /// <summary>
        /// Отметка начала мостового сооружения
        /// </summary>
        public IGeometry StartMark { get; protected set; }
        /// <summary>
        /// Отметка начала мостового сооружения
        /// </summary>
        public IStyle StartMarkStyle =>
            startMarkStyle;
        /// <summary>
        /// Ширина линии с длиной моста
        /// </summary>
        public float BridgeLengthLabelWidth => 0.25f;
        /// <summary>
        /// Линии у краёв мостового сооружения
        /// </summary>
        public GraphicsPath BridgeLengthLabel { get; protected set; }

        public float BridgeLengthLabelFontSize { get; set; } = 2f;

        public BridgeRenderGeometry(Bridge bridge, IFeature centerLine)
        {
            Refresh(bridge, centerLine);
        }

        public void Refresh(Bridge bridge, IFeature centerLine)
        {
            _bridge = bridge;
            CenterLine = centerLine;

            MainGeometryStyle = GetStyle(_bridge.ConstructionType, _bridge.Status,
                _bridge.Obstacles?.Select(o => o.Type));
            //сокращение осевой линии на половину ширины обводки моста
            var lineCoords = centerLine.Geometry.Coordinates;
            Coordinate start1 = lineCoords[0];
            Coordinate start2 = lineCoords[1];
            Coordinate end1 = lineCoords[lineCoords.Length - 1];
            Coordinate end2 = lineCoords[lineCoords.Length - 2];
            float dx, dy;
            //todo: убрать лишние вызовы
            var angle = GetAngle(start1, start2);
            var borderLineWidthHalf = MainGeometryStyle.LineWidth / 2;
            dx = (float)(borderLineWidthHalf
                * Math.Cos(angle));
            dy = (float)(borderLineWidthHalf
                * Math.Sin(angle));
            var newLine = (IFeature)centerLine.Clone();
            newLine.Geometry.Coordinates[0] = new Coordinate(start1.X + dx, start1.Y + dy);
            angle = GetAngle(end1, end2);
            dx = (float)(borderLineWidthHalf
                * Math.Cos(angle));
            dy = (float)(borderLineWidthHalf
                * Math.Sin(angle));
            newLine.Geometry.Coordinates[lineCoords.Length - 1] = new Coordinate(end1.X + dx, end1.Y + dy);
            var width = _bridge.WidthDimensionB / 2 - borderLineWidthHalf;
            if (width < 0.2f)
            {
                width = 0.2f;
            }
            MainGeometry = GetBufferGeometry(newLine, width);
            if (BridgeConstants.BridgeLengthVisible)
            {
                BridgeLengthLabel = GetBridgeLengthLabel(centerLine, width, _bridge);
            }
            if (BridgeConstants.BridgeStartMarkVisible)
            {
                StartMark = GetStartMark(centerLine, _bridge);
            }
        }

        private LineString GetStartMark(IFeature centerLine, Bridge bridge)
        {
            Coordinate firstCoord;
            Coordinate secondCoord;
            if (!bridge.InversedStartOfBridge)
            {
                firstCoord = centerLine.Geometry.Coordinates[0];
                secondCoord = centerLine.Geometry.Coordinates[1];
            }
            else
            {
                firstCoord = centerLine.Geometry.Coordinates
                    [centerLine.Geometry.Coordinates.Length - 1];
                secondCoord = centerLine.Geometry.Coordinates
                    [centerLine.Geometry.Coordinates.Length - 2];
            }
            var dx = (secondCoord.X - firstCoord.X) / 10;
            var dy = (secondCoord.Y - firstCoord.Y) / 10;
            var line = new LineString(new[] {
                    firstCoord,
                    new Coordinate(firstCoord.X+dx,firstCoord.Y+dy)});
            return line;
        }

        //private GraphicsPath GetBridgeEdgeLines(IFeature feature, Bridge bridge)
        //{
        //    PointF firstCoord = new PointF((float)feature.Geometry.Coordinates[0].X,
        //        (float)feature.Geometry.Coordinates[0].Y);
        //    PointF secondCoord = new PointF((float)feature.Geometry.Coordinates[1].X,
        //        (float)feature.Geometry.Coordinates[1].Y);
        //    var dx = (secondCoord.X - firstCoord.X) / 10;
        //    var dy = (secondCoord.Y - firstCoord.Y) / 10;
        //    var path = new GraphicsPath();
        //    var newCoord = new PointF(firstCoord.X - dx, firstCoord.Y - dy);
        //    var newCoord2 = new PointF(firstCoord.X + dx, 
        //        firstCoord.Y + dy);
        //    path.AddLine(newCoord2, newCoord);

        //    var rotateMatrix = new Matrix();
        //    rotateMatrix.RotateAt(45, newCoord2);
        //    path.Transform(rotateMatrix);

        //    GraphicsPath res = new GraphicsPath();
        //    res.AddLine(newCoord2, newCoord);
        //    rotateMatrix.RotateAt(-90, newCoord2);
        //    res.Transform(rotateMatrix);
        //    res.AddPath(path, false);
        //    return res;
        //}

        private GraphicsPath GetBridgeLengthLabel(IFeature feature, float width, Bridge bridge)
        {
            var path = new GraphicsPath();
            Coordinate firstCoord;
            Coordinate secondCoord;
            if (bridge.InversedStartOfBridge)
            {
                firstCoord = feature.Geometry.Coordinates[0];
                secondCoord = feature.Geometry.Coordinates[1];
            }
            else
            {
                firstCoord = feature.Geometry.Coordinates
                    [feature.Geometry.Coordinates.Length - 1];
                secondCoord = feature.Geometry.Coordinates
                    [feature.Geometry.Coordinates.Length - 2];
            }
            PointF firstPoint = new PointF((float)firstCoord.X, (float)firstCoord.Y);
            var angleRad = GetAngle(firstCoord, secondCoord);
            var angle = angleRad * 180 / Math.PI;
            float sin = (float)Math.Sin(angleRad);
            float cos = (float)Math.Cos(angleRad);
            float dx = (width + MainGeometryStyle.LineWidth / 2) * sin;
            float dy = (width + MainGeometryStyle.LineWidth / 2) * cos;
            var addX = BridgeLengthLabelWidth / 2 * cos;
            var addY = BridgeLengthLabelWidth / 2 * sin;
            string text = $"Конец = {bridge.Length.ToString("F1")} м";
            var font = new Font(new FontFamily("Arial"),
                               BridgeLengthLabelFontSize, FontStyle.Regular, GraphicsUnit.Pixel);
            var size = System.Windows.Forms.TextRenderer.MeasureText(text, font);
            var addXtext = (size.Width) * sin;
            var addYtext = (size.Width) * cos;
            var rotateMatrix = new Matrix();
            PointF p1 = new PointF(
                firstPoint.X - addX - dx - addXtext,
                firstPoint.Y - addY + dy + addYtext);
            PointF p2 = new PointF(
                firstPoint.X - addX + dx,
                firstPoint.Y - addY - dy);
            //чтобы надпись была по другую сторону от линии
            PointF p3 = new PointF(p1.X, p1.Y - size.Height - 1f);
            path.AddString(text, font.FontFamily,
                (int)font.Style, font.Size, p3,
                StringFormat.GenericDefault);
            
            rotateMatrix.Translate(-p1.X, p1.Y);
            rotateMatrix.Scale(1, -1);
            rotateMatrix.Translate(p1.X, -p1.Y);
            rotateMatrix.RotateAt((float)(-angle - 270), p1);

            path.Transform(rotateMatrix);

            path.AddLine(p1, p2);
            return path;
        }

        public static double GetAngle(Coordinate center, Coordinate coord)
        {
            return Math.Atan2(coord.Y - center.Y, coord.X - center.X);
        }

        private IGeometry GetBufferGeometry(IFeature feature, double width)
        {
            return feature.Geometry.Buffer(width,
                         new BufferParameters()
                         {
                             EndCapStyle = GeoAPI.Operations.Buffer.EndCapStyle.Flat,
                             JoinStyle = GeoAPI.Operations.Buffer.JoinStyle.Round,
                         });
        }

        private AreaStyle GetStyle(BridgeType bridgeType, BridgeStatus status, IEnumerable<ObstacleType> bridgeObstaclesTypes)
        {
            int alfa = 255;
            if (bridgeObstaclesTypes != null)
                //Для дороги мост должен быть сильно прозрачным, чтобы через него была видна разметка
                if (bridgeObstaclesTypes.Contains(ObstacleType.Road))
                    alfa = 150;
                //Для Ж/Д мост должен быть немного прозрачным
                else if (bridgeObstaclesTypes.Contains(ObstacleType.Railway))
                    alfa = 220;
            AreaStyle style = new AreaStyle(
                new InteriorStyle((HatchStyle)13,
                    Color.FromArgb(alfa, 199, 199, 222),
                    Color.FromArgb(alfa, 237, 237, 237)),
                new LineStyle(Color.FromArgb(alfa, 192, 192, 192), 1f));
            Color c250_169_61 = Color.FromArgb(alfa, 250, 169, 61);
            Color c199_199_222 = Color.FromArgb(alfa, 199, 199, 222);
            Color c237_237_237 = Color.FromArgb(alfa, 237, 237, 237);
            Color c192_192_192 = Color.FromArgb(alfa, 192, 192, 192);
            Color c50_150_150 = Color.FromArgb(alfa, 50, 150, 150);
            Color c211_211_211 = Color.FromArgb(alfa, 211, 211, 211);
            Color c213_213_255 = Color.FromArgb(alfa, 213, 213, 255);
            Color c174_174_255 = Color.FromArgb(alfa, 174, 174, 255);
            Color c137_137_137 = Color.FromArgb(alfa, 137, 137, 137);
            Color c248_241_237 = Color.FromArgb(alfa, 248, 241, 237);
            Color c251_250_249 = Color.FromArgb(alfa, 251, 250, 249);
            switch (bridgeType)
            {
                case BridgeType.Overpass:
                    break;
                case BridgeType.Estacada:
                    break;
                case BridgeType.CattleDrive:
                    {
                        var interiorStyle = new InteriorStyle((HatchStyle)42,
                            Color.FromArgb(alfa, 206, 233, 190), Color.FromArgb(alfa, 89, 200, 100));
                        if (bridgeObstaclesTypes != null &&
                            bridgeObstaclesTypes.Contains(ObstacleType.Railway))
                        // если над железной дорогой
                        {
                            switch (status)
                            {
                                case BridgeStatus.Temporary:
                                case BridgeStatus.Set:
                                    style = new AreaStyle(
                                        interiorStyle,
                                        new LineStyle(Color.FromArgb(alfa, 67, 115, 55),
                                        3.0f, DashStyle.Solid));
                                    break;
                                case BridgeStatus.Required:
                                    style = new AreaStyle(
                                       interiorStyle,
                                       new LineStyle(c50_150_150, 2.0f, DashStyle.Solid));
                                    break;
                                case BridgeStatus.Repairs:
                                case BridgeStatus.Dismantle:
                                    style = new AreaStyle(
                                       interiorStyle,
                                       new LineStyle(c250_169_61, 2.0f, DashStyle.Dash));
                                    break;
                            }
                        }
                        else
                        {
                            switch (status)
                            {
                                case BridgeStatus.Temporary:
                                case BridgeStatus.Set:
                                    style = new AreaStyle(
                                        interiorStyle,
                                        new LineStyle(Color.FromArgb(alfa, 67, 115, 55),
                                        3.0f, DashStyle.Solid));
                                    break;
                                case BridgeStatus.Required:
                                    style = new AreaStyle(
                                       interiorStyle,
                                       new LineStyle(c50_150_150, 2.0f, DashStyle.Solid));
                                    break;
                                case BridgeStatus.Repairs:
                                case BridgeStatus.Dismantle:
                                    style = new AreaStyle(
                                       interiorStyle,
                                       new LineStyle(c250_169_61, 2.0f, DashStyle.Solid));
                                    break;
                            }
                        }
                    }
                    break;
                case BridgeType.Pontoon:
                    {
                        var interiorStyle = new InteriorStyle((HatchStyle)13,
                            c199_199_222, c237_237_237);
                        switch (status)
                        {
                            case BridgeStatus.Temporary:
                            case BridgeStatus.Set:
                                //todo: разобраться с толщиной 11.3, слишком большая, в стандарте 11.3, пока здесь 5
                                style = new AreaStyle(
                                    interiorStyle,
                                    new LineStyle(c137_137_137, 5f, DashStyle.Solid));
                                break;
                            case BridgeStatus.Required:
                                style = new AreaStyle(
                                   interiorStyle,
                                   new LineStyle(c50_150_150, 2.0f, DashStyle.Solid));
                                break;
                            case BridgeStatus.Repairs:
                            case BridgeStatus.Dismantle:
                                style = new AreaStyle(
                                   interiorStyle,
                                   new LineStyle(c250_169_61, 2.0f, DashStyle.Solid));
                                break;
                        }
                    }
                    break;
                case BridgeType.FillType:
                    break;
                case BridgeType.Viaduct:
                    {
                        var interiorStyle = new InteriorStyle((HatchStyle)15,
                           Color.FromArgb(alfa, 174, 255, 215), Color.FromArgb(alfa, 180, 180, 180));
                        switch (status)
                        {
                            case BridgeStatus.Temporary:
                            case BridgeStatus.Set:
                                style = new AreaStyle(
                                    interiorStyle,
                                    new LineStyle(Color.FromArgb(alfa, 176, 176, 176),
                                    2.0f, DashStyle.Solid));
                                break;
                            case BridgeStatus.Required:
                                style = new AreaStyle(
                                   interiorStyle,
                                   new LineStyle(c50_150_150, 2.0f, DashStyle.Solid));
                                break;
                            case BridgeStatus.Repairs:
                            case BridgeStatus.Dismantle:
                                style = new AreaStyle(
                                   interiorStyle,
                                   new LineStyle(c250_169_61, 2.0f, DashStyle.Dash));
                                break;
                        }
                    }
                    break;
                case BridgeType.Aqueduct:
                    {
                        var interiorStyle = new InteriorStyle((HatchStyle)37,
                           Color.FromArgb(255, 147, 201, 230), c237_237_237);
                        switch (status)
                        {
                            case BridgeStatus.Temporary:
                            case BridgeStatus.Set:
                                style = new AreaStyle(
                                    interiorStyle,
                                    new LineStyle(Color.FromArgb(alfa, 66, 105, 240),
                                    3.0f, DashStyle.Solid));
                                break;
                            case BridgeStatus.Required:
                                style = new AreaStyle(
                                   interiorStyle,
                                   new LineStyle(c50_150_150, 2.0f, DashStyle.Solid));
                                break;
                            case BridgeStatus.Repairs:
                            case BridgeStatus.Dismantle:
                                style = new AreaStyle(
                                   interiorStyle,
                                   new LineStyle(c250_169_61, 2.0f, DashStyle.Dash));
                                break;
                        }
                    }
                    break;
                case BridgeType.FlyingFerry:
                    break;
                case BridgeType.Drawbridge:
                    break;
                case BridgeType.Bridge:
                    {
                        var interiorStyle = new InteriorStyle((HatchStyle)13,
                           c199_199_222, c237_237_237);
                        switch (status)
                        {
                            case BridgeStatus.Temporary:
                            case BridgeStatus.Set:
                                style = new AreaStyle(
                                    interiorStyle,
                                    new LineStyle(c192_192_192,
                                    1.0f, DashStyle.Solid));
                                break;
                            case BridgeStatus.Required:
                                style = new AreaStyle(
                                   interiorStyle,
                                   new LineStyle(c50_150_150, 2.0f, DashStyle.Solid));
                                break;
                            case BridgeStatus.Repairs:
                            case BridgeStatus.Dismantle:
                                style = new AreaStyle(
                                   interiorStyle,
                                   new LineStyle(c250_169_61, 2.0f, DashStyle.Dash));
                                break;
                        }
                    }
                    break;
                case BridgeType.Tunnel:
                    break;
            }
            return style;
        }
    }
}