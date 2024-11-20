using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message GetByID(int id)
        {
            return _messageDal.Get(x => x.MessageID == id);
        }

        public List<Message> GetListInbox(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p && x.MessageStatus == true && x.DarftsStatus == false && x.ReadStatus == false);
        }

        public List<Message> GetListSendbox(string p)
        {
            return _messageDal.List(x => x.SenderMail == p && x.MessageStatus == true && x.DarftsStatus == false);
        }

        public List<Message> GetListTrash(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p && x.MessageStatus == false);
        }

        public List<Message> List()
        {
            return _messageDal.List();
        }

        public void MessageAdd(Message message)
        {
            message.MessageStatus = true;
            message.DarftsStatus = false;
            message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            _messageDal.Insert(message);
        }

        public void DraftsMessageAdd(Message message)
        {
            message.DarftsStatus = true;
            message.MessageStatus = true;
            message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            _messageDal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            _messageDal.Update(message);
        }

        public void MessageUpdate(Message message)
        {
            _messageDal.Update(message);
        }

        public List<Message> DraftsList(string p)
        {
            return _messageDal.List(x => x.SenderMail == p && x.DarftsStatus == true && x.MessageStatus == true);
        }

        public List<Message> GetListReadInbox(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p && x.MessageStatus == true && x.DarftsStatus == false && x.ReadStatus==true);
        }
    }
}
