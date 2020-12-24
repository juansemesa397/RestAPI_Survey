using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.IServices;
using WebAPICore.Models;

namespace WebAPICore.Services
{
    public class QuestionOrderServices : IQuestionOrderServices
    {
        BD_SurveyContext dbContext;

        public QuestionOrderServices(BD_SurveyContext _db)
        {
            dbContext = _db;
        }

        public IEnumerable<QuestionOrder> GetQuestionOrder()
        {
            List<QuestionOrder> Getquestionorder = new List<QuestionOrder>();
            try
            {
                Getquestionorder = dbContext.QuestionOrders.FromSqlRaw("select * from VGetquestionorder").ToList();
            }
            catch (Exception)
            {

                throw;
            }
            
            return Getquestionorder;
        }

        public IEnumerable<QuestionOrder> InsertQuestionOrder(int question_id, int survey_id, int order)
        {
            List<QuestionOrder> questionorderInsert = new List<QuestionOrder>();
            List<QuestionOrder> questionorderUpdate = new List<QuestionOrder>();
            const int ordenAlet = 9999;
            questionorderInsert = dbContext.QuestionOrders.FromSqlRaw("EXECUTE usp_insertarQuestion_order {0}, {1}, {2}", question_id, survey_id, ordenAlet).ToList();
            
            int contador;
            int orderI = order;
            int ordenF= order;
            contador = order;

            while (contador <= question_id)
            {
                if (contador == question_id)
                {
                    questionorderInsert = dbContext.QuestionOrders.FromSqlRaw("EXECUTE usp_updateInsquestion_order {0}, {1}", ordenAlet, order).ToList();
                    contador++;
                }
                else
                {
                    ordenF++;
                    questionorderInsert = dbContext.QuestionOrders.FromSqlRaw("EXECUTE usp_updateInsquestion_order {0}, {1}", orderI, ordenF).ToList();
                    orderI++;
                    contador++;
                }

               
            }

            return questionorderInsert;

        }


        public IEnumerable<QuestionOrder> UpdateQuestionOrder(int IdSurvey, int PosicionI, int PosicionF)
        {
            List<QuestionOrder> questionorder = new List<QuestionOrder>();

            if (PosicionI < PosicionF)
            {
                int contadorI = 1;
                int contadoF = PosicionF;

                while (contadorI <= contadoF)
                {

                    if (contadorI == 1)
                    {

                        questionorder = dbContext.QuestionOrders.FromSqlRaw("EXECUTE usp_updateQuestion_order {0}, {1}, {2}", IdSurvey, PosicionI, PosicionF).ToList();
                    }
                    else
                    {
                        PosicionI++;
                        PosicionF = PosicionI - 1;
                        questionorder = dbContext.QuestionOrders.FromSqlRaw("EXECUTE usp_updateQuestion_order {0}, {1}, {2}", IdSurvey, PosicionI, PosicionF).ToList();
                    }

                    contadorI++;

                }


            }
            else
            {
                int contadorI = 1;
                int contadoF = PosicionI;

                while (contadorI < contadoF)
                {
                    if (contadorI == 1)
                    {

                        questionorder = dbContext.QuestionOrders.FromSqlRaw("EXECUTE usp_updateQuestion_order {0}, {1}, {2}", IdSurvey, PosicionI, PosicionF).ToList();
                    }
                    else
                    {
                        PosicionI= PosicionI-1;
                        PosicionF++;
                        questionorder = dbContext.QuestionOrders.FromSqlRaw("EXECUTE usp_updateQuestion_order {0}, {1}, {2}", IdSurvey, PosicionI, PosicionF).ToList();
                    }

                    contadorI++;

                }

            }


            
           return questionorder;

        }

    }
}
