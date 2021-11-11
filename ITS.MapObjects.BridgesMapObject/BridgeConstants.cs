using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using ITS.GIS.MapEntities.Styles;
using ITS.MapObjects.BridgesMapObject.Properties;
using Microsoft.Practices.Unity;

namespace ITS.MapObjects.BridgesMapObject
{
    /// <summary>
    /// Предоставляет доступ к константам и свойствам плагина.
    /// </summary>
    internal static class BridgeConstants
    {
        public static bool IsDrawSet = true;
        public static bool IsDrawRequired = true;
        public static bool IsDrawDismantle = true;
        public static bool IsDrawRepairs = true;
        public static bool IsDrawTemporary = true;

        public static AreaStyle defaultBridgeStyle = new AreaStyle(
            new InteriorStyle((HatchStyle)13,
                Color.FromArgb(255, 199, 199, 222),
                Color.FromArgb(255, 237, 237, 237)),
            new LineStyle(Color.FromArgb(255,192,192,192), 1f));
        
        #region Private Fields

        /// <summary>
        /// Название плагина дружественное пользователю (backing storage).
        /// </summary>
        private static string _toolName;

        /// <summary>
        /// Включен ли кастомный рендерер (backing storage).
        /// </summary>
        private static bool? _customRendererEnabled;

        /// <summary>
        /// Отображается ли начало моста на карте специальной меткой
        /// </summary>
        private static bool? _bridgeStartMarkVisible;

        /// <summary>
        /// Отображается ли длина моста на карте
        /// </summary>
        private static bool? _bridgeLengthVisible;

        /// <summary>
        /// Порядок слоя мостовых сооружений
        /// </summary>
        private static int _bridgeLayerOrderIndex = -1;

        #endregion

        #region Properties

        /// <summary>
        /// Название плагина дружественное пользователю.
        /// </summary>
        internal static string ToolName
        {
            get
            {
                if (string.IsNullOrEmpty(_toolName))
                {
                    _toolName = Resources.PluginToolName;
                }
                return _toolName;
            }
        }

        /// <summary>
        /// Включен ли кастомный рендерер.
        /// </summary>
        internal static bool CustomRendererEnabled
        {
            get
            {
                if (!_customRendererEnabled.HasValue)
                {
                    bool res = false;
                    if (ConfigurationManager.AppSettings.AllKeys.Contains("BridgeCustomRendererEnabled"))
                        bool.TryParse(ConfigurationManager.AppSettings["BridgeCustomRendererEnabled"], out res);
                    _customRendererEnabled = res;
                }
                return _customRendererEnabled.Value;
            }
        }

        /// <summary>
        /// Отображается ли начало моста на карте специальной меткой
        /// </summary>
        internal static bool BridgeStartMarkVisible
        {
            get
            {
                if (!_bridgeStartMarkVisible.HasValue)
                {
                    bool res = false;
                    if (ConfigurationManager.AppSettings.AllKeys.Contains("BridgeStartMarkVisible"))
                        bool.TryParse(ConfigurationManager.AppSettings["BridgeStartMarkVisible"], out res);
                    _bridgeStartMarkVisible = res;
                }
                return _bridgeStartMarkVisible.Value;
            }
        }

        /// <summary>
        /// Отображается ли длина моста на карте
        /// </summary>
        internal static bool BridgeLengthVisible
        {
            get
            {
                if (!_bridgeLengthVisible.HasValue)
                {
                    bool res = false;
                    if (ConfigurationManager.AppSettings.AllKeys.Contains("BridgeLengthVisible"))
                        bool.TryParse(ConfigurationManager.AppSettings["BridgeLengthVisible"], out res);
                    _bridgeLengthVisible = res;
                }
                return _bridgeLengthVisible.Value;
            }
        }

        /// <summary>
        /// IoC-контейнер плагина.
        /// </summary>
        internal static IUnityContainer Container
        {
            get
            {
                return
                    ProjectBase.Utils.Container.Container.PluginContainer(ToolName);
            }
        }

        internal static string BridgeLayerAlias
        {
            get
            {
                return
                    Resources.BridgeLayerAlias;
            }
        }

        /// <summary>
        /// Порядок слоя мостовых сооружений
        /// </summary>
        internal static int BridgeLayerOrderIndex
        {
            get
            {
                if (_bridgeLayerOrderIndex == -1)
                {
                    if (!int.TryParse(Resources.BridgeLayerOrderIndex, out _bridgeLayerOrderIndex))
                    {
                        throw new System.Exception($"Неправильная строка ресурсов {BridgeLayerOrderIndex}");
                    }
                }
                return _bridgeLayerOrderIndex;
            }
        }

        internal static string BridgeAttributeName
        {
            get { return "bridge"; }
        }
       

        #endregion
    }
}