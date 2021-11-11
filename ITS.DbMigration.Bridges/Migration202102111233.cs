using System.Data;
using Migrator.Framework;

namespace ITS.DbMigration.Bridges
{
    [Migration(202102111233)]
    public class Migration202102111233 : Migration
    {
        public override void Up()
        {
            Database.AddColumn("bridges_bridge", new Column("longitude_scheme_lm", DbType.Single));
            Database.AddColumn("bridges_bridge", new Column("road_signs_before", DbType.String));
            Database.AddColumn("bridges_bridge", new Column("road_signs_after", DbType.String));
            Database.AddColumn("bridges_span_structure", new Column("expansion_joint_add_info", DbType.String, 140));
            Database.AddColumn("bridges_bridge", new Column("charact_obstacle_add_info", DbType.String));
            Database.RemoveColumn("bridges_bridge", "expansion_joints_type");

            #region Перенесение подмостового габарита в пролётные строения
            Database.AddColumn("bridges_span_structure", new Column("underbridge_clearance", DbType.Single));
            //запись подмостового габарита в пролёты
            Database.ExecuteNonQuery("update bridges_span_structure set underbridge_clearance = (select underbridge_clearance from bridges_bridge where id = bridge_id)");
            Database.RemoveColumn("bridges_bridge", "underbridge_clearance");
            #endregion

            #region Перенесение продольного уклона в пролётные строения
            Database.AddColumn("bridges_span_structure", new Column("slope_longitudinal", DbType.Single));
            Database.AddColumn("bridges_span_structure", new Column("slope_longitudinal_profile", DbType.Byte, (object)0));
            //запись продольного уклона в пролёты
            Database.ExecuteNonQuery("update bridges_span_structure set slope_longitudinal = (select slope_longitudinal from bridges_bridge where id = bridge_id)");
            Database.ExecuteNonQuery("update bridges_span_structure set slope_longitudinal_profile = (select slope_longitudinal_profile from bridges_bridge where id = bridge_id)");
            Database.RemoveColumn("bridges_bridge", "slope_longitudinal");
            Database.RemoveColumn("bridges_bridge", "slope_longitudinal_profile");
            #endregion

            //пересчёт качества мостового сооружения
            //Хорошее -> 5
            Database.ExecuteNonQuery("update bridges_bridge set quality_bridge_type = 4 where quality_bridge_type = 0");
            //Плохое -> 2
            //Database.ExecuteQuery("update bridges_bridge set quality_bridge_type = 1 where quality_bridge_type = 1");
            //Нет данных -> Нет данных
            Database.ExecuteNonQuery("update bridges_bridge set quality_bridge_type = 5 where quality_bridge_type = 2");

            //Исправление опечаток
            Database.ExecuteNonQuery("update bridges_defect_scroll_section set name = 'Повреждение поверхности цементобетона' where id = 18");
            Database.ExecuteNonQuery("update bridges_defect_scroll_section set full_name = '2 Дефекты элементов мостового полотна//2.1 Покрытие//2.1.5 Трещины цементобетона', name = 'Трещины цементобетона' where id = 19");
            Database.ExecuteNonQuery("update bridges_defect_scroll_section set name = 'Швы в плитах цементобетона' where id = 20");
            Database.ExecuteNonQuery("update bridges_defect_scroll_section set full_name = '2 Дефекты элементов мостового полотна//2.1 Покрытие//2.1.7 Разрушение плит', name = 'Разрушения плит цементобетона' where id = 21");
        }

        public override void Down()
        {
            Database.RemoveColumn("bridges_bridge", "longitude_scheme_lm");
            Database.RemoveColumn("bridges_bridge", "road_signs_before");
            Database.RemoveColumn("bridges_bridge", "road_signs_after");
            Database.RemoveColumn("bridges_span_structure", "expansion_joint_add_info");
            Database.RemoveColumn("bridges_bridge", "charact_obstacle_add_info");
            Database.AddColumn("bridges_bridge", new Column("expansion_joints_type", DbType.Byte, (object)0));
            Database.RemoveColumn("bridges_span_structure", "underbridge_clearance");
            Database.AddColumn("bridges_bridge", new Column("underbridge_clearance", DbType.Single));

            Database.RemoveColumn("bridges_span_structure", "slope_longitudinal");
            Database.RemoveColumn("bridges_span_structure", "slope_longitudinal_profile");
            Database.AddColumn("bridges_bridge", new Column("slope_longitudinal", DbType.Single));
            Database.AddColumn("bridges_bridge", new Column("slope_longitudinal_profile", DbType.Byte, (object)0));

            Database.ExecuteNonQuery("update bridges_bridge set quality_bridge_type = 0 where quality_bridge_type = 4");
            //Database.ExecuteNonQuery("update bridges_bridge set quality_bridge_type = 1 where quality_bridge_type = 1");
            Database.ExecuteNonQuery("update bridges_bridge set quality_bridge_type = 2 where quality_bridge_type = 5");
        }
    }
}
