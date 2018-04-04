using System.Collections;
using System.Collections.Generic;

namespace MonsterAR
{
    public class Status
    {
        int current;
        int maximum;


        public int Current { get { return current; } }
        public int Maximum { get { return maximum; } }


        public Status(int current, int maximum)
        {
            this.current = current;
            this.maximum = maximum;
        }

        public void Clear()
        {
            current = 0;
        }

        public void FullRestore()
        {
            current = maximum;
        }

        public void Restore(int value)
        {
            current = ((current + value) > maximum) ? maximum : (current + value);
        }

        public void Remove(int value)
        {
            current = ((current - value) < 0) ? 0 : (current - value);
        }
    }
}
