using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace xxEncryptTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            labelTips0.Text = "1.确保电脑上已经安装好lua5.1(叉叉仅支持5.1)";
            labelTips1.Text = "2.加密时，程序会先把所有选择的源文件备份至'我的文档/xspBackup'目录下，但依然建议手动备份";
            labelTips2.Text = "3.拷贝encrypt.lua至源文件所在目录，在main.lua首行reqiure encrypt即可";
            labelTips3.Text = "4.还原备份功能会将'我的文档/xspBackup'中对应的文件移动至选择的项目文件夹";
            labelTips4.Text = "5.本程序默认不支持中文变量名，需要的请至Github下载源码自行添加中文转码";
        }

        public string[] filePaths = new string[1024];

        bool executeCmd(string cmd)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
            p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            p.StartInfo.CreateNoWindow = true;//不显示程序窗口
            p.Start();//启动程序

            //向cmd窗口发送输入信息
            p.StandardInput.WriteLine(cmd + " &exit");

            p.StandardInput.AutoFlush = true;
            //p.StandardInput.WriteLine("exit");
            //向标准输入写入要执行的命令。这里使用&是批处理命令的符号，表示前面一个命令不管是否执行成功都执行后面(exit)命令，如果不执行exit命令，后面调用ReadToEnd()方法会假死
            //同类的符号还有&&和||前者表示必须前一个命令执行成功才会执行后面的命令，后者表示必须前一个命令执行失败才会执行后面的命令



            //获取cmd窗口的输出信息
            string output = p.StandardOutput.ReadToEnd();

            //StreamReader reader = p.StandardOutput;
            //string line=reader.ReadLine();
            //while (!reader.EndOfStream)
            //{
            //    str += line + "  ";
            //    line = reader.ReadLine();
            //}

            p.WaitForExit();//等待程序执行完退出进程
            p.Close();


            Console.WriteLine(output);

            return true;
        }

        private void ButtonLoadFile_Click(object sender, EventArgs e)
        {
            //定义一个文件打开控件
            OpenFileDialog ofd = new OpenFileDialog();
            //设置打开对话框的初始目录，默认目录为exe运行文件所在的路径
            ofd.InitialDirectory = Application.StartupPath;
            //设置打开对话框的标题
            ofd.Title = "请选择需要加密的文件";
            //设置打开对话框可以多选
            ofd.Multiselect = true;
            //设置对话框打开的文件类型
            ofd.Filter = "lua文件|*.lua";
            //设置文件对话框当前选定的筛选器的索引
            ofd.FilterIndex = 2;

            ofd.InitialDirectory = System.Environment.CurrentDirectory + "\\xspworkspace";
            //设置对话框是否记忆之前打开的目录
            ofd.RestoreDirectory = false;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Array.Clear(filePaths, 0, filePaths.Length);
                Array.Copy(ofd.FileNames, filePaths, ofd.FileNames.Length);
                richTextBoxLoadFile.Text = "";
                richTextBoxEncryptFile.Text = "";
                foreach (string s in ofd.SafeFileNames)
                {
                    richTextBoxLoadFile.AppendText(s + "\r\n");
                }

                foreach (string s in ofd.FileNames)
                {
                    if (s.IndexOf("xspworkspace\\") == -1)
                    {
                        DialogResult dr = MessageBox.Show("请选择位于xspworkspace目录下的源文件！", "加载源文件");
                        richTextBoxLoadFile.Text = "";
                        richTextBoxEncryptFile.Text = "";
                        break;
                    }
                }
            }
        }

        private string formatFixLenStr(string s)
        {
            string tmp = s;
            if (s.Length <= 20){
                for (int i = 0; i < 25 - s.Length; i++){
                    tmp += " ";
                }
            }

            return tmp;
        }

        private void ButtonEncrypt_Click(object sender, EventArgs e)
        {
            foreach (string s in filePaths)
            {
                if (s == null)
                {
                    break;
                }

                System.IO.StreamReader srcfile = new System.IO.StreamReader(s);
                string firstLine = srcfile.ReadLine();
                Console.WriteLine(firstLine);
                if (firstLine.IndexOf("loadstring") == 0)
                {
                    richTextBoxEncryptFile.AppendText(formatFixLenStr(Path.GetFileName(s)) + "放弃加密  源文件是加密文件\r\n");
                    continue;
                }
                srcfile.Close();

                string cmd = "luac -o " + Path.GetFullPath(s + ".tmp") + " " + Path.GetFullPath(s);
                executeCmd(cmd);

                if (!File.Exists(Path.GetFullPath(s + ".tmp"))){
                    DialogResult dr = MessageBox.Show("未找到中间文件:" + Path.GetFullPath(s + ".tmp") + "，请确保安装好lua5.1！", "加密源文件");
                    break;
                }

                //备份源文件
                string bakRootDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\xspBackup\\";
                string currentSubDir = Path.GetDirectoryName(s).Substring(Path.GetDirectoryName(s).LastIndexOf("xspworkspace\\") + 13) + "\\";
                Console.WriteLine(bakRootDir + currentSubDir);
                if (!Directory.Exists(bakRootDir + currentSubDir))
                {
                    Directory.CreateDirectory(bakRootDir + currentSubDir);
                }
                if (!Directory.Exists(bakRootDir + "static_backup\\" + currentSubDir))      //静态备份，不受恢复备份影响
                {
                    Directory.CreateDirectory(bakRootDir + "static_backup\\" + currentSubDir);
                }

                try
                {
                    File.Copy(Path.GetFullPath(s), bakRootDir + "static_backup\\" + currentSubDir + Path.GetFileName(s), true);
                    File.Copy(Path.GetFullPath(s), bakRootDir + currentSubDir + Path.GetFileName(s), true);
                    richTextBoxEncryptFile.AppendText(formatFixLenStr(Path.GetFileName(s)) + "备份成功  ");
                }
                catch (Exception)
                {
                    richTextBoxEncryptFile.AppendText(formatFixLenStr(Path.GetFileName(s)) + "备份失败  放弃加密\r\n");
                    continue;
                }

                //将中间文件重写至原源文件
                try
                {
                    FileStream fssrc = new FileStream(Path.GetFullPath(s + ".tmp"), FileMode.Open);
                    BinaryReader brsrc = new BinaryReader(fssrc);

                    byte[] bsrc = new byte[fssrc.Length + 8];
                    int index = 0;

                    while (true)
                    {
                        try
                        {
                            byte b = brsrc.ReadByte();
                            bsrc[index] = b;
                            index++;
                        }
                        catch (EndOfStreamException)
                        {
                            break;
                        }
                    }

                    string encryptedStr = Convert.ToBase64String(bsrc);
                    encryptedStr = "loadstring(decode(\"" + encryptedStr + "\"))";
                    byte[] encryptedByte = Encoding.UTF8.GetBytes(encryptedStr);  

                    FileStream fsdst = new FileStream(Path.GetFullPath(s), FileMode.Truncate);
                    BinaryWriter bwdst = new BinaryWriter(fsdst);

                    bwdst.Write(encryptedByte);

                    bwdst.Close();
                    fsdst.Close();
                    brsrc.Close();
                    fssrc.Close();

                    richTextBoxEncryptFile.AppendText("加密成功\r\n");
                }
                catch (FileNotFoundException)
                {
                    DialogResult dr = MessageBox.Show("加密中间文件:" + Path.GetFullPath(s + ".tmp") + "失败！", "加密异常");
                    richTextBoxEncryptFile.AppendText("加密失败\r\n");
                    continue;
                }
                catch (DirectoryNotFoundException)
                {
                    DialogResult dr = MessageBox.Show("加密中间文件:" + Path.GetFullPath(s + ".tmp") + "失败！", "加密异常");
                    richTextBoxEncryptFile.AppendText("加密失败\r\n");
                    continue;
                }
                finally
                {
                    if (File.Exists(Path.GetFullPath(s + ".tmp")))
                    {
                        File.Delete(Path.GetFullPath(s + ".tmp"));
                    }
                }
            }
        }

        public static void CopyDirectory(String sourcePath, String destinationPath)
        {
            DirectoryInfo info = new DirectoryInfo(sourcePath);
            Directory.CreateDirectory(destinationPath);
            foreach (FileSystemInfo fsi in info.GetFileSystemInfos())
            {
                String destName = Path.Combine(destinationPath, fsi.Name);

                if (fsi is System.IO.FileInfo)          //如果是文件，复制文件 
                    File.Copy(fsi.FullName, destName, true);
                else                                    //如果是文件夹，新建文件夹，递归 
                {
                    Directory.CreateDirectory(destName);
                    CopyDirectory(fsi.FullName, destName);
                }
            }
        }

        //删除目录下的所有文件及文件夹
        private static void deleteDirFiles(string strPath)
        {
            //删除这个目录下的所有文件
            if (Directory.GetFiles(strPath).Length > 0)
            {
                foreach (string var in Directory.GetFiles(strPath))
                {
                    File.Delete(var);
                }
            }

            //删除这个目录下的所有子目录
            if (Directory.GetDirectories(strPath).Length > 0)
            {
                foreach (string var in Directory.GetDirectories(strPath))
                {
                    Directory.Delete(var, true);
                }
            }
        }

        public static void deleteEncFile(string dir)
        {
            if (Directory.Exists(dir)) //如果存在这个文件夹删除之 
            {
                foreach (string d in Directory.GetFileSystemEntries(dir))
                {
                    if (File.Exists(d))
                    {
                        if (d.IndexOf("_.lua") != -1)
                        {
                            Console.WriteLine(d);
                            File.Delete(d); //直接删除其中的文件       
                        }
                       
                    }
                    else
                    {
                        Console.WriteLine(d);
                        deleteEncFile(d); //递归删除子文件夹 }
                    }
                }
            }
        }

        private void ButtonRecover_Click(object sender, EventArgs e)
        {

            string bakDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\xspBackup\\";
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\xspBackup\\";

            dialog.Description = @"请选择\xspBackup\目录下要还原的项目文件夹";
            DialogResult result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
            if (dialog.SelectedPath.IndexOf("xspBackup\\") == -1)
            {
                MessageBox.Show(@"必须选择\xspBackup\目录下要还原的项目文件夹");
                return;
            }

            string selectPath = dialog.SelectedPath;
            Console.WriteLine(selectPath);
            string dstPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\xspworkspace\\";
            dstPath += Path.GetFullPath(selectPath).Substring(selectPath.LastIndexOf("xspBackup\\") + ("xspBackup\\").Length);
            Console.WriteLine(dstPath);

            CopyDirectory(selectPath, dstPath);

            deleteDirFiles(selectPath);
            deleteEncFile(dstPath);

            MessageBox.Show("还原成功！");
        }
    }
}
