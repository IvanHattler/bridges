using System.Resources;
using ITS.MapObjects.BaseMapObject.Misc.PluginAttributes;
using ITS.MapObjects.BridgesMapObject.Properties;

namespace ITS.MapObjects.BridgesMapObject
{
    /// <summary>
    /// Предоставляет доступ к ресурсам плагина.
    /// </summary>
    internal class BridgePanelResourceHelper : ResourceHelperAbstract, IResourceHelper
    {
        /// <summary>
        /// Создает класс, который предоставляет доступ к ресурсам плагина.
        /// </summary>
        /// <param name="toolName">Имя инструмента.</param>
        public BridgePanelResourceHelper(string toolName)
            : base(toolName)
        {
        }

        protected override ResourceManager ResManager
        {
            get { return Resources.ResourceManager; }
        }
    }
}