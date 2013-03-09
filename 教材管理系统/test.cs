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
            string file = Server.MapPath("..\\music\\") + Request["music"];//music可以换成其他目录，对应不同类型文件上传不同

            string filePath = this.file1.PostedFile.FileName;//获得上传文件的路径
            string fileName = filePath.Substring(filePath.LastIndexOf("\\")+1);//获得文件名
            string fileExtend=filePath.Substring(filePath.LastIndexOf("."+1);//获得拓展名
            if(!(fileExtend=="WMA"||fileExtend=="RM"||fileExtend=="MP3"))//判断是否是知道格式的文件，否则无法进行上传
            {
                Response.Write(baseclass.strJS("格式错误！","history.back()"));
                Response.Write.End();
            }
            string serverPath=serverPath.MapPath("..\\music")+fileName;//把文件保存到服务器上的路径
            //判断文件是否存在
            if(FileDialog.Exist(serverPath))
            {
                Response.Write(baseclass.strJS("对不起，文件已存在","history.back()"));
                Response.Write.End();
            }
            this.file1.PostedFile.SaveAs(serverPath);//保存文件到服务器
            string itemid=Convert.ToString(Session["itemid"]);//获取DataList控件中ItemIndex
            if(itemid.Length<2)
            {

            }

        }
    }
}
