using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System;

namespace laba_9
{
    public class LogicAnd
    {
        private bool hasFreePlaces;
        private bool hasCareerGrowth;

        public LogicAnd()
        {
            hasFreePlaces = false;
            hasCareerGrowth = false;
        }

        public LogicAnd(bool free, bool stair)
        {
            hasFreePlaces = free;
            hasCareerGrowth = stair;
        }

        public bool CanHireEmployees(bool free, bool stair)
        {
            return free && stair;
        }

        public bool CanGrowStairs(bool free, bool stair)
        {
            return free && !stair;
        }

        public bool CanGetFree(bool free, bool stair)
        {
            return !free && stair;
        }

        // Унарный оператор !
        public static bool operator !(LogicAnd l)
        {
            return !(l.hasFreePlaces && l.hasCareerGrowth);
        }

        // Преобразование в строку
        public override string ToString()
        {
            return $"Free={hasFreePlaces}, Stair={hasCareerGrowth}";
        }
    }
}
