using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackOverflowProject.DomainModels;

namespace StackOverflowProject.Repositories
{
    public interface IQuestionsRepository
    {
        void InsertQuestion(Question q);
        void UpdateQuestionDetails(Question q);
        void UpdateQuestionVotesCount(int qid, int value);
        void UpdateQuestionAnswersCount(int qid, int value);
        void UpdateQuestionViewsCount(int qid);
        void DeleteQuestion(int qid);
        List<Question> GetQuestions();
        List<Question> GetQuestionByQuestionID(int qid);
    }
    class QuestionsRepository:IQuestionsRepository
    {
        StackOverflowDatabaseDBContext db;

        public QuestionsRepository()
        {
            db = new StackOverflowDatabaseDBContext();
        }

        public void InsertQuestion(Question q)
        {
            db.Questions.Add(q);
            db.SaveChanges();
        }

        public void UpdateQuestionDetails(Question q)
        {
            Question qs = db.Questions.Where(temp => temp.QuestionID == q.QuestionID).FirstOrDefault(); 
            if(qs != null)
            {
                qs.QuestionName = q.QuestionName;
                qs.QuestionDateAndTime = q.QuestionDateAndTime;
                qs.CategoryID = q.CategoryID;
                db.SaveChanges();
            }
        }

        public void UpdateQuestionVotesCount(int qid, int value)
        {
            Question qs = db.Questions.Where(temp => temp.QuestionID == qid).FirstOrDefault();
            if(qs != null)
            {
                qs.VotesCount += value;
                db.SaveChanges();
            }
        }

        public void UpdateQuestionAnswersCount(int qid, int value)
        {
            Question qs = db.Questions.Where(temp => temp.QuestionID == qid).FirstOrDefault();
            if(qs != null)
            {
                qs.AnswersCount += value;
                db.SaveChanges();
            }
        }

        public void UpdateQuestionViewsCount(int qid)
        {
            Question qs = db.Questions.Where(temp => temp.QuestionID == qid).FirstOrDefault();
            if(qs!=null)
            {
                qs.ViewsCount++;
                db.SaveChanges();
            }
        }

        public void DeleteQuestion(int qid)
        {
            Question qs = db.Questions.Where(temp => temp.QuestionID == qid).FirstOrDefault();
            if (qs != null)
            {
                db.Questions.Remove(qs);
                db.SaveChanges();
            }
        }

        public List<Question> GetQuestions()
        {
            List<Question> qs = db.Questions.OrderByDescending(temp => temp.QuestionDateAndTime).ToList();
            return qs;
        }

        public List<Question> GetQuestionByQuestionID(int qid)
        {
            List<Question> qs = db.Questions.Where(temp => temp.QuestionID == qid).ToList();
            return qs;
        }
    }
}
