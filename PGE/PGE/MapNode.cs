using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGE
{
    /// <summary>
    /// MapNode encapsulates a kd-tree node.
    /// </summary>
    class MapNode
    {
        /// <summary>
        /// Cutting dimension.
        /// </summary>
        private int _cuttingDimension;

        /// <summary>
        /// 
        /// </summary>
        private Vector2 _vector;

        /// <summary>
        /// 
        /// </summary>
        private MapNode _left;

        /// <summary>
        /// 
        /// </summary>
        private MapNode _right;

        /// <summary>
        /// 
        /// </summary>
        public int CuttingDimension
        {
            get { return _cuttingDimension; }
            set { _cuttingDimension = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector2 Vector
        {
            get { return _vector; }
            set { _vector = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public MapNode Left
        {
            get { return _left; }
            set { _left = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public MapNode Right
        {
            get { return _right; }
            set { _right = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <param name="cuttingDimension"></param>
        public MapNode(Vector2 vector, int cuttingDimension)
        {
            _left = null;
            _right = null;
            _cuttingDimension = cuttingDimension;
            _vector = vector;
        }

        public MapNode Insert(Vector2 vector, MapNode node, int cuttingDimension)
        {
            if (null == node)
            {
                node = new MapNode(vector, cuttingDimension);            }
            else if (vector == node.Vector)
            {
                // dupe.
            }
            else if (vector.X > node.Vector.X) // (Actually test v. CD)
            {
                cuttingDimension = (cuttingDimension + 1) % Conf.Dimensions;
                node.Left = Insert(vector, node.Left, cuttingDimension);
            }
            else
            {
                cuttingDimension = (cuttingDimension + 1) % Conf.Dimensions;
                node.Right = Insert(vector, node.Right, cuttingDimension);
            }
            
            return node;
        }
    }
}
