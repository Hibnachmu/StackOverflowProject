using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackOverflowProject.DomainModels;
using StackOverflowProject.ViewModels;
using StackOverflowProject.Repositories;
using AutoMapper;
using AutoMapper.Configuration;

namespace StackOverflowProject.ServiceLayer
{
    public interface IQuestionsService
    {
        void InsertQuestion(NewQuestionViewModel qvm);
        void UpdateQuestionDetails(EditQuestionViewModel qvm);
        void UpdateQuestionVotesCount(int qid, int value);
        void UpdateQuestionAnsersCount(int qid, int value);
        void UpdateQuestionViewsCount(int qid, int value);
        void DeleteQuestion(int qid);
        List<QuestionViewModel> GetQuestions();
        QuestionViewModel GetQuestionByQuestionID(int qid, int uid);
    }
    public class QuestionsService:IQuestionsService
    {
        IQuestionsRepository qr;

        public QuestionsService()
        {
            qr = new QuestionsRepository();
        }

        public void InsertQuestion(NewQuestionViewModel qvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<NewQuestionViewModel, Question>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Question q = mapper.Map<NewQuestionViewModel, Question>(qvm);
            qr.InsertQuestion(q);
        }

        public void UpdateQuestionDetails(EditQuestionViewModel qvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditQuestionViewModel, Question>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Question q = mapper.Map<EditQuestionViewModel, Question>(qvm);
            qr.UpdateQuestionDetails(q);
        }

        public void UpdateQuestionVotesCount(int qid, int value)
        {
            qr.UpdateQuestionVotesCount(qid, value);
        }

        public void UpdateQuestionAnsersCount(int qid, int value)
        {
            qr.UpdateQuestionAnswersCount(qid, value);
        }

        public void UpdateQuestionViewsCount(int qid, int value)
        {
            qr.UpdateQuestionViewsCount(qid, value);
        }

        public void DeleteQuestion(int qid)
        {
            qr.DeleteQuestion(qid);
        }

        public List<QuestionViewModel> GetQuestions()
        {
            List<Question> q = qr.GetQuestions();
            List<QuestionViewModel> qvm = null;
            if(q != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Question, QuestionViewModel>();
                    cfg.CreateMap<User, UserViewModel>();
                    cfg.CreateMap<Category, CategoryViewModel>();
                    cfg.CreateMap<Answer, AnswerViewModel>();
                    cfg.CreateMap<Vote, VoteViewModel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                qvm = mapper.Map<List<Question>, List<QuestionViewModel>>(q);
            }
            return qvm;
        }

        public QuestionViewModel GetQuestionByQuestionID(int qid, int uid = 0)
        {
            Question q = qr.GetQuestionByQuestionID(qid).FirstOrDefault();
            QuestionViewModel qvm = null;
            if(q != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Question, QuestionViewModel>();
                    cfg.CreateMap<User, UserViewModel>();
                    cfg.CreateMap<Category, CategoryViewModel>();
                    cfg.CreateMap<Answer, AnswerViewModel>();
                    cfg.CreateMap<Vote, VoteViewModel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                qvm = mapper.Map<Question, QuestionViewModel>(q);
            }

            foreach(var item in qvm.Answer)
            {
                item.CurrentUserVoteType = 0;
                VoteViewModel vote = item.Votes.Where(temp => temp.UserID == uid).FirstOrDefault();
                if(vote != null)
                {
                    item.CurrentUserVoteType = vote.VoteValue;
                }
            }
            return qvm;
        }
    }
}
