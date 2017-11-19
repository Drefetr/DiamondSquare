using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGE
{
    /// <summary>
    /// Encapsulates the behavior and data-members of a cyclic array.
    /// </summary>
    class CyclicArray<T>
    {
        private T[,] array = new T[Conf.MapSize, Conf.MapSize];

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int j, int i]
        {
            get
            {
                if (i < 0) i += 1025; // odd
                if (j < 0) j += 1025; // odd
                int column = (i % Conf.MapSize);
                int row = (j % Conf.MapSize);
                return array[row, column];
            }

            set
            {
                if (i < 0) i += 1025; // odd
                if (j < 0) j += 1025; // odd
                int column = (i % Conf.MapSize);
                int row = (j % Conf.MapSize);
                array[row, column] = value;
            }
        }
    }
}
