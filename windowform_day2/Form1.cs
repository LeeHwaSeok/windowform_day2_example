using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace windowform_day2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void b_add_Click(object sender, EventArgs e)
        {
            //공백 예외처리
            if (tb_group.Text == "" || tb_name.Text == "" || tb_phone.Text == "")
            {
                MessageBox.Show("내용을 입력하세요");
            }
            else
            { //데이터 추가형식 '배열'
                string[] slist = new string[] { tb_name.Text, tb_phone.Text, tb_group.Text };
                ListViewItem viewItem = new ListViewItem(slist);
                listView1.Items.Add(viewItem);

                //텍스트 초기화
                tb_phone.Clear();
                tb_group.Clear();
                tb_name.Clear();

            }
        }

        private void b_remove_Click(object sender, EventArgs e)
        {
            //아이템이 비어있을경우
            if (listView1.Items.Count != 0)
            {
                //              listView1.Items.RemoveAt(listView1.FocusedItem.Index);    1번 사용 가능
                listView1.FocusedItem.Remove();                          //2번 사용가능
            }
            else
            {
                MessageBox.Show("지울게 없습니다.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TreeNode node = new TreeNode(textBox1.Text);

            /*            if(treeView1.SelectedNode != null && treeView1.SelectedNode.IsSelected)
                        {
                            treeView1.SelectedNode.Nodes.Add(node); 
                        }
                        else
                        {
                            treeView1.Nodes.Add(node);
                        }*/
            //체크 + 선택이 되야만 추가 됌.
            if (treeView1.SelectedNode.Checked)
            {
                treeView1.SelectedNode.Nodes.Add(node);
            }
            else
            {
                treeView1.Nodes.Add(node);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            treeView1.SelectedNode.Remove();
        }


        List<TreeNode> chknode = new List<TreeNode>();
        void removechk(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Checked)
                {
                    chknode.Add(node);
                }
                else
                {
                    removechk(node.Nodes);
                }
            }
            foreach (TreeNode chkn in chknode)
            {
                nodes.Remove(chkn);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            removechk(treeView1.Nodes);
        }
    }
}
