using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BookManageSystem
{
    class test
    {
        protected void btnUpfile_CLicked(object sender, EventArgs e)
        {
            string file = Server.MapPath("..\\music\\") + Request["music"];//music���Ի�������Ŀ¼����Ӧ��ͬ�����ļ��ϴ���ͬ

            string filePath = this.file1.PostedFile.FileName;//����ϴ��ļ���·��
            string fileName = filePath.Substring(filePath.LastIndexOf("\\")+1);//����ļ���
            string fileExtend=filePath.Substring(filePath.LastIndexOf("."+1);//�����չ��
            if(!(fileExtend=="WMA"||fileExtend=="RM"||fileExtend=="MP3"))//�ж��Ƿ���֪����ʽ���ļ��������޷������ϴ�
            {
                Response.Write(baseclass.strJS("��ʽ����","history.back()"));
                Response.Write.End();
            }
            string serverPath=serverPath.MapPath("..\\music")+fileName;//���ļ����浽�������ϵ�·��
            //�ж��ļ��Ƿ����
            if(FileDialog.Exist(serverPath))
            {
                Response.Write(baseclass.strJS("�Բ����ļ��Ѵ���","history.back()"));
                Response.Write.End();
            }
            this.file1.PostedFile.SaveAs(serverPath);//�����ļ���������
            string itemid=Convert.ToString(Session["itemid"]);//��ȡDataList�ؼ���ItemIndex
            if(itemid.Length<2)
            {

            }

        }
    }
}
