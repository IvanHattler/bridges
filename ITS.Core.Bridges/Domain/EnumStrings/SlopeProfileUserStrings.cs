using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITS.Core.Bridges.Domain.Enums;
using ITS.Core.Bridges.Domain.Base;

namespace ITS.Core.Bridges.Domain.EnumStrings
{
    public class SlopeProfileUserStrings : EnumStrings<SlopeProfile>
    {
        private static readonly string StrConvexCurve = "Выпуклая кривая (V)";
        private static readonly string StrConcaveCurve = "Вогнутая кривая (Λ)";
        private static readonly string StrUp = "Подъём по ходу движения (/)";
        private static readonly string StrDown = "Спуск по ходу движения (\\)";

        public SlopeProfileUserStrings() { }
        private static SlopeProfileUserStrings instance;
        public static SlopeProfileUserStrings Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SlopeProfileUserStrings();
                }
                return instance;
            }
        }

        public override SlopeProfile GetElement(string name)
        {
            if (name == StrConvexCurve)
                return SlopeProfile.ConvexCurve;
            if (name == StrConcaveCurve)
                return SlopeProfile.ConcaveCurve;
            if (name == StrUp)
                return SlopeProfile.Up;
            if (name == StrDown)
                return SlopeProfile.Down;
            return SlopeProfile.Down;
        }

        public override string GetFullName(SlopeProfile slope_profile)
        {
            switch (slope_profile)
            {
                case SlopeProfile.ConvexCurve:
                    return StrConvexCurve;
                case SlopeProfile.ConcaveCurve:
                    return StrConcaveCurve;
                case SlopeProfile.Up:
                    return StrUp;
                case SlopeProfile.Down:
                    return StrDown;
                default:
                    break;
            }
            return null;
        }
    }
}
