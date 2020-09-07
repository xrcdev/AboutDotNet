using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AboutCSharpLanguage.YieldTest
{
    public class TestYield
    {
        public static void Main()
        {
            Console.WriteLine("begin");
            var list = GetList(new int[] { 1, 2, 3, 4, 5 });
            Console.WriteLine("set Data");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        private static IEnumerable<int> GetList(int[] vs)
        {
            GetListEnumerable rangEnumerable = new GetListEnumerable(-2);
            rangEnumerable.nums = vs;
            return rangEnumerable;
        }
    }

    public class GetListEnumerable : IEnumerable<int>, IEnumerator<int>
    {
        private int state;
        private int current;
        private int threadID;
        public int[] nums;
        public int[] s1_nums;
        public int s2;
        public int num53;

        public GetListEnumerable(int state)
        {
            this.state = state;
            this.threadID = Environment.CurrentManagedThreadId;
        }
        public int Current => current;

        public IEnumerator<int> GetEnumerator()
        {
            GetListEnumerable rangeEnumerable;

            if (state == -2 && threadID == Environment.CurrentManagedThreadId)
            {
                state = 0;
                rangeEnumerable = this;
            }
            else
            {
                rangeEnumerable = new GetListEnumerable(0);
            }

            rangeEnumerable.nums = nums;
            return rangeEnumerable;
        }

        public bool MoveNext()
        {
            Console.WriteLine("In MoveNext ");
            switch (state)
            {
                case 0:

                    state = -1;
                    s1_nums = nums;
                    s2 = 0;
                    num53 = s1_nums[s2];
                    current = num53;
                    state = 1;
                    return true;
                case 1:
                    state = -1;
                    s2++;

                    if (s2 < s1_nums.Length)
                    {
                        num53 = s1_nums[s2];
                        current = num53;
                        state = 1;
                        return true;
                    }

                    s1_nums = null;
                    return false;
            }
            return false;
        }

        public void Dispose() { }
        public void Reset() { }
        object? IEnumerator.Current => Current;

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

    }
}
