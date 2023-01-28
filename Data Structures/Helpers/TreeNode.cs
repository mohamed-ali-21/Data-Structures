using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures.Helpers
{
    public class TreeNode
    {
        public int Item { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public TreeNode(int item, TreeNode left = null, TreeNode right = null)
        {
            Item=item;
            Left=left;
            Right=right;
        }
    }
}
