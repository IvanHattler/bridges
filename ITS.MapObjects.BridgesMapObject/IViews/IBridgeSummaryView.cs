using System;
using System.Collections.Generic;
using ITS.Core.Bridges.Domain;
using ITS.MapObjects.BridgesMapObject.EventArgses;

namespace ITS.MapObjects.BridgesMapObject.IViews
{
    public interface IBridgeSummaryView
    {
        /// <summary>
        /// Отображаемые ДТО.
        /// </summary>
        IEnumerable<Bridge> Model { get; set; }

        /// <summary>
        /// Отображает список объектов <see cref="Bridge"/> в таблице
        /// </summary>
        void View();

        /// <summary>
        /// Выводит окно на передний план.
        /// </summary>
        void ActivateView();

        /// <summary>
        /// Заполняет фильтры .
        /// </summary>
        /// <param name="filterDictionary">Фильтры и их возможные значения.</param>
        void FillBridgeFilters(IDictionary<ITS.Core.Domain.Filters.Filter, object> filterDictionary);

        /// <summary>
        /// Фильтры.
        /// </summary>
        ICollection<Core.Domain.Filters.Filter> BridgeFilters { get; }

        /// <summary>
        /// Отобразить  на карте.
        /// </summary>
        event EventHandler<BridgeEventArgs> ShowOnMap;

        /// <summary>
        /// Редактировать.
        /// </summary>
        event EventHandler<BridgeEventArgs> EditBridge;

        /// <summary>
        /// Применить фильтр.
        /// </summary>
        event EventHandler<EventArgs> LoadBridge;

        /// <summary>
        /// Экспортировать сводную ведомость в MS Word.
        /// </summary>
        event EventHandler<EventArgs> ExportToWord;

        /// <summary>
        /// Сохранить паспорта мостовых сооружений
        /// </summary>
        event EventHandler<EventArgs> SavePassports;
    }
}