using Data_Structures.Helpers;

namespace Data_Structures.DataStructures.Tree
{
    public class BinarySearchTree
    {
        public int Length { get; private set; }
        public TreeNode root { get; private set; }

        public bool IsEmpty()
            => Length == 0;

        private TreeNode Add(int item, TreeNode r)
        {
            if (r == null)
            {
                TreeNode newNode = new TreeNode(item);
                r = newNode;
            }
            else if (item <= r.Item)
                r.Left = Add(item, r.Left);
            else
                r.Right = Add(item, r.Right);

            return r;
        }

        public void Add(int item)
        {
            root = Add(item, root);
        }

        private TreeNode GetMin(TreeNode r)
        {
            if (r == null)
                return null;

            if (r.Left == null)
                return r;

            return GetMin(r.Left);
        }

        public TreeNode GetMin()
            => GetMin(root);

        private TreeNode GetMax(TreeNode r)
        {
            if (r == null)
                return null;

            if (r.Right == null)
                return r;

            return GetMax(r.Right);
        }

        public TreeNode GetMax()
            => GetMax(root);

        private TreeNode Search(TreeNode r, int item)
        {
            if (r == null)
                throw new Exception("this node is not found");

            if (r.Item == item)
                return r;

            if (item <= r.Item)
                return Search(r.Left, item);

            return Search(r.Right, item);                 
        }

        public TreeNode Search(int key)
        {
            return Search(root, key);
        }

        private TreeNode GetCurrNode(TreeNode node, TreeNode r)
        {
            if (root == node)
                return null;

            if (r.Left == node || r.Right == node)
                return r;
            else if (node.Item <= r.Item)
                return GetCurrNode(node, r.Left);
            else
                return GetCurrNode(node, r.Right);
        }

        public bool Isleaf(TreeNode node)
            => node.Left == null && node.Right == null;

        public TreeNode GetSuccessor(TreeNode node)
        {
            if (node.Right == null)
            {
                TreeNode curr = GetCurrNode(node, root);

                if (node.Item > curr.Item)
                {
                    while (node.Item > curr.Item)
                        curr = GetCurrNode(curr, root);

                    return curr;
                }
                else
                    return GetCurrNode(node, root);
            }
            else
                return GetMin(node.Right);
        }

        public TreeNode GetPredecessor(TreeNode node)
        {
            if (node.Left == null)
            {
                TreeNode curr = GetCurrNode(node, root);

                if (node.Item <= curr.Item)
                {
                    while (node.Item < curr.Item)
                        curr = GetCurrNode(curr, root);

                    return curr;
                }
                else
                    return GetCurrNode(node, root);
            }
            else
                return GetMax(node.Left);
        }

        private void Delete(TreeNode r, int item)
        {
            if (r == null)
            {
                Console.WriteLine("This tree is empty");
                return;
            }

            if (item < r.Item)
                Delete(r.Left, item);

            else if (item > r.Item)
                Delete(r.Right, item);
            
            else
            {
                if (r.Left != null && r.Right != null)
                {
                    TreeNode successor = GetSuccessor(r);
                    removeOne(successor);
                    r.Item = successor.Item;
                }
                else
                {
                    removeOne(r);
                }
            }

            Length--;
        }

        public void Delete(int key)
            => Delete(root, key);

        private void removeOne(TreeNode r)
        {
            TreeNode curr = GetCurrNode(r, root);

            if (r.Left != null)
            {
                if (curr.Item < r.Item)
                    curr.Right = r.Left;
                else
                    curr.Left = r.Left;
            }
            else if (r.Right != null)
            {
                if (curr.Item < r.Item)
                    curr.Right = r.Right;
                else
                    curr.Left = r.Right;
            }
            else
            {
                if (curr.Item < r.Item)
                    curr.Right = null;
                else
                    curr.Left = null;
            }
        }

        public void PreOrder(TreeNode r)
        {
            if (r != null)
            {
                Console.Write(r.Item + " ");
                PreOrder(r.Left);
                PreOrder(r.Right);
            }
        }

        public void InOrder(TreeNode r)
        {
            if (r != null)
            {
                PreOrder(r.Left);
                Console.Write(r.Item + " ");
                PreOrder(r.Right);
            }
        }

        public void PostOrder(TreeNode r)
        {
            if (r != null)
            {
                PreOrder(r.Left);
                PreOrder(r.Right);
                Console.Write(r.Item + " ");
            }
        }
        
        public void LevelOrder(TreeNode r)
        {
            if (r == null)
                return;

            Queue<TreeNode> queue = new Queue<TreeNode>();  
            queue.Enqueue(r);   

            while (queue.Count > 0)
            {
                TreeNode node = queue.Peek();
                Console.Write(node.Item + " ");

                if (node.Left != null)
                    queue.Enqueue(node.Left);

                if (node.Right != null)
                    queue.Enqueue(node.Right);

                queue.Dequeue();    
            }
        }
    }
}