namespace JianLi3
{
    class SendMail
    {
        /*        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                //确定smtp服务器地址。实例化一个Smtp客户端
                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(cmbBoxSMTP.Text);
                //生成一个发送地址
                string strFrom = string.Empty;
                if (cmbBoxSMTP.SelectedText == "smtp.163.com")
                    strFrom = txtUserName.Text + "@163.com";
                else
                    strFrom = txtUserName.Text + "@gmail.com";

                //构造一个发件人地址对象
                MailAddress from = new MailAddress(strFrom, txtDisplayName.Text, Encoding.UTF8);
                //构造一个收件人地址对象
                MailAddress to = new MailAddress(txtEmail.Text, txtToName.Text, Encoding.UTF8);

                //构造一个Email的Message对象
                MailMessage message = new MailMessage(from, to);

                //为 message 添加附件
                foreach (TreeNode treeNode in treeViewFileList.Nodes)
                {
                    //得到文件名
                    string fileName = treeNode.Text;
                    //判断文件是否存在
                    if (File.Exists(fileName))
                    {
                        //构造一个附件对象
                        Attachment attach = new Attachment(fileName);
                        //得到文件的信息
                        ContentDisposition disposition = attach.ContentDisposition;
                        disposition.CreationDate = System.IO.File.GetCreationTime(fileName);
                        disposition.ModificationDate = System.IO.File.GetLastWriteTime(fileName);
                        disposition.ReadDate = System.IO.File.GetLastAccessTime(fileName);
                        //向邮件添加附件
                        message.Attachments.Add(attach);
                    }
                    else
                    {
                        MessageBox.Show("文件" + fileName + "未找到！");
                    }
                }

                //添加邮件主题和内容
                message.Subject = txtSubject.Text;
                message.SubjectEncoding = Encoding.UTF8;
                message.Body = rtxtBody.Text;
                message.BodyEncoding = Encoding.UTF8;

                //设置邮件的信息
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = false;

                //如果服务器支持安全连接，则将安全连接设为true。
                //gmail支持，163不支持，如果是gmail则一定要将其设为true
                if (cmbBoxSMTP.SelectedText == "smpt.163.com")
                    client.EnableSsl = false;
                else
                    client.EnableSsl = true;

                //设置用户名和密码。
                //string userState = message.Subject;
                client.UseDefaultCredentials = false;
                string username = txtUserName.Text;
                string passwd = txtPassword.Text;
                //用户登陆信息
                NetworkCredential myCredentials = new NetworkCredential(username, passwd);
                client.Credentials = myCredentials;
                //发送邮件
                client.Send(message);
                //提示发送成功
                MessageBox.Show("发送成功!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }*/
    }

    class PeopleHeight
    {
        // http://wenwen.soso.com/z/q105781846.htm?ch=gr.shchwt
        public PeopleHeight(int fatherheight, int motherhight, bool sex,bool sport,bool diet)
        {
            faHeight = fatherheight;
            moHeight = motherhight;
            _sport = sport;
            _diet = diet;
            _sex = sex;
        }
        public int Height
        {
            get
            {
                int h;
                float add= 1;
                if(_sex)
                {
                    h= (int)((faHeight+moHeight)*0.54);
                }else{
                    h = (int)((faHeight*0.923+moHeight)/2);
                }

                if(_sport)
                    add += 0.02f;

                if(_diet)
                    add += 0.015f;

                return (int)(h*add);

            }
        }

        readonly int faHeight;
        readonly int moHeight;
        readonly bool _sex;// true male,false female
        readonly bool _sport;// 爱好体育
        readonly bool _diet;//卫生习惯
    }
}
