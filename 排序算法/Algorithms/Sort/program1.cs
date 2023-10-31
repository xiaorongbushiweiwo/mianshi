
public interface IMail
{
    int ID { get; }

    int Timestamp { get; }

    string Title { get; }

    string Content { get; }

    bool Readed { get; set; }
}

public class Mail : IMail
{

    public Mail(int ID, int timestamp, string title, string content)
    {
        this.ID = ID;
        this.Timestamp = timestamp;
        this.Title = title;
        this.Content = content;
        this.Readed = false;
    }

    public int ID { get; }

    public int Timestamp { get; }

    public string Title { get; }

    public string Content { get; }

    public bool Readed { get; set; }
    
}

public class MailManager
{
    private const int _maxMailNum = 5000;                                       //最大存储限制

    private List<int> readedMails = new List<int>();                            //记录已读邮件
    private List<int> mailIDs = new List<int>();                                //记录邮件id（有序）
    private Dictionary<int, Mail> mails = new Dictionary<int, Mail>();          //存储所有邮件（字典方便读取），借助字典的空间复杂度为O（n）
    

    //不确定新邮件收否会默认id递增，所以需要一次遍历一下
    //时间复杂度为O（n）
    public bool AddMail(Mail mail)
    {
        if (mail == null || mails.Count == 5000)
        {
            return false;
        }

        int i = 0;
        for (; i < mailIDs.Count; i++)
        {
            if (mailIDs[i] <= mail.ID)
            {
                break;
            }
            
        }
        mailIDs.Insert(i, mail.ID);
        mails.Add(mail.ID, mail);
        
        return true;
    }

    //删除mail
    //删除mailIDs里的时间复杂度为O（n）
    //删除mails里的时间复杂度为O（1）
    public bool DeleteMail(int ID)
    {
        foreach (var id in mailIDs)
        {
            if (id == ID)
            {
                mailIDs.Remove(id);
                mails.Remove(id);
                return true;
            }
        }
        return false;
    }

    //字典存储
    //时间复杂度为O（1）
    public Mail GetMail(int ID)
    {
        return mails[ID];
    }
    
    public bool DeleteAllMail()
    {
        mails.Clear();
        mailIDs.Clear();
        return true;
    }
    //删除已读，提前记录已读邮件
    //时间复杂度为O（n）
    public bool DeleteReadedMail()
    {
        foreach (var id in readedMails)
        {
            DeleteMail(id);
        }
        
        readedMails.Clear();
        return true;
    }

    //字典存储邮件
    //时间复杂度为O（1）
    public bool ReadedMail(int ID)
    {
        Mail mail = mails[ID];
        if (mail == null)
        {
            return false;
        }

        mails[ID].Readed = true;
        readedMails.Add(ID);
        return true;
    }

} 